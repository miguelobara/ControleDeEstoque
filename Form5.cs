using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

namespace ControleDeEstoque
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.AcceptButton = btnCriar;
            AplicarEstilosModernos();
        }

        private void AplicarEstilosModernos()
        {
            // Aplicar bordas arredondadas e sombras visuais
            AplicarBordaArredondada(panelForm);
            AplicarBordaArredondada(btnCriar);
            AplicarBordaArredondada(btnVoltar);

            // Configurar placeholders modernos
            ConfigurarPlaceholders();
        }

        private void AplicarBordaArredondada(Control control)
        {
            // Simula bordas arredondadas através do FlatStyle
            if (control is Button button)
            {
                button.FlatAppearance.BorderSize = 0;
                button.FlatStyle = FlatStyle.Flat;
            }
        }

        private void ConfigurarPlaceholders()
        {
            // Configurar placeholders para campos específicos
            ConfigurarPlaceholder(tbxNome, "Digite seu nome completo");
            ConfigurarPlaceholder(tbxEmail1, "exemplo@email.com");
            ConfigurarPlaceholder(tbxRua, "Nome da rua e número");
            ConfigurarPlaceholder(tbxCidade, "Nome da cidade");
            ConfigurarPlaceholder(tbxUf, "UF");
            ConfigurarPlaceholder(tbxPais, "País");
            ConfigurarPlaceholder(tbxCep, "00000-000");
            ConfigurarPlaceholder(tbxRg, "Número do RG");
            ConfigurarPlaceholder(tbxCpf, "000.000.000-00");
            ConfigurarPlaceholder(tbxNascimento, "__/__/____");
            ConfigurarPlaceholder(tbxTelefone, "(00) 00000-0000");
        }

        private void ConfigurarPlaceholder(Control control, string placeholder)
        {
            // Para TextBox
            if (control is TextBox textBox)
            {
                ConfigurarPlaceholderTextBox(textBox, placeholder);
            }
            // Para MaskedTextBox
            else if (control is MaskedTextBox maskedTextBox)
            {
                ConfigurarPlaceholderMaskedTextBox(maskedTextBox, placeholder);
            }
        }

        private void ConfigurarPlaceholderTextBox(TextBox textBox, string placeholder)
        {
            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = SystemColors.WindowText;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = SystemColors.GrayText;
                }
            };

            // Configurar inicial
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void ConfigurarPlaceholderMaskedTextBox(MaskedTextBox maskedTextBox, string placeholder)
        {
            maskedTextBox.Enter += (s, e) =>
            {
                if (maskedTextBox.Text == placeholder)
                {
                    maskedTextBox.Text = "";
                    maskedTextBox.ForeColor = SystemColors.WindowText;
                }
            };

            maskedTextBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(maskedTextBox.Text) || maskedTextBox.Text == maskedTextBox.Mask)
                {
                    maskedTextBox.Text = placeholder;
                    maskedTextBox.ForeColor = SystemColors.GrayText;
                }
            };

            // Configurar inicial
            if (string.IsNullOrWhiteSpace(maskedTextBox.Text))
            {
                maskedTextBox.Text = placeholder;
                maskedTextBox.ForeColor = SystemColors.GrayText;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                CadastrarUsuario();
            }
        }

        private bool ValidarCampos()
        {
            // Validar Nome
            if (string.IsNullOrWhiteSpace(tbxNome.Text) || tbxNome.Text == "Digite seu nome completo")
            {
                MostrarErro("Por favor, preencha o campo Nome.", tbxNome);
                return false;
            }

            // Validar Email
            if (string.IsNullOrWhiteSpace(tbxEmail1.Text) || tbxEmail1.Text == "exemplo@email.com")
            {
                MostrarErro("Por favor, preencha o campo Email.", tbxEmail1);
                return false;
            }

            if (!ValidarEmail(tbxEmail1.Text.Trim()))
            {
                MostrarErro("Por favor, insira um email válido.", tbxEmail1);
                return false;
            }

            // Validar Senha
            if (string.IsNullOrWhiteSpace(tbxSenha1.Text))
            {
                MostrarErro("Por favor, preencha o campo Senha.", tbxSenha1);
                return false;
            }

            if (tbxSenha1.Text.Length < 6)
            {
                MostrarErro("A senha deve ter pelo menos 6 caracteres.", tbxSenha1);
                return false;
            }

            // Validar CPF
            string cpfLimpo = LimparCPF(tbxCpf.Text);
            if (!string.IsNullOrWhiteSpace(cpfLimpo) && cpfLimpo != "00000000000")
            {
                if (cpfLimpo.Length != 11)
                {
                    MostrarErro("CPF inválido. Deve conter 11 dígitos.", tbxCpf);
                    return false;
                }

                if (!ValidarCPF(cpfLimpo))
                {
                    MostrarErro("CPF inválido. Verifique os dígitos.", tbxCpf);
                    return false;
                }
            }

            // Validar Data de Nascimento
            if (!string.IsNullOrWhiteSpace(tbxNascimento.Text) && tbxNascimento.Text != "__/__/____")
            {
                if (!ValidarDataNascimento(tbxNascimento.Text))
                {
                    MostrarErro("Data de nascimento inválida. Use o formato DD/MM/AAAA.", tbxNascimento);
                    return false;
                }
            }

            return true;
        }

        private string LimparCPF(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf) || cpf == "000.000.000-00")
                return "";

            // Remove todos os caracteres não numéricos
            return System.Text.RegularExpressions.Regex.Replace(cpf, @"[^\d]", "");
        }

        private bool ValidarCPF(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se todos os dígitos são iguais
            if (cpf.All(c => c == cpf[0]))
                return false;

            // Calcula primeiro dígito verificador
            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (cpf[i] - '0') * (10 - i);

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            if (digito1 != (cpf[9] - '0'))
                return false;

            // Calcula segundo dígito verificador
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (cpf[i] - '0') * (11 - i);

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return digito2 == (cpf[10] - '0');
        }

        private bool ValidarDataNascimento(string data)
        {
            try
            {
                DateTime dt = DateTime.ParseExact(data, "dd/MM/yyyy", null);
                return dt <= DateTime.Now && dt.Year >= 1900;
            }
            catch
            {
                return false;
            }
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void MostrarErro(string mensagem, Control controle)
        {
            MessageBox.Show(mensagem, "Validação",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controle.Focus();
        }

        private void CadastrarUsuario()
        {
            try
            {
                string conexao = "Data Source=SQLEXPRESS;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();

                    // Verificar se email já existe
                    if (EmailJaCadastrado(conn, tbxEmail1.Text.Trim()))
                    {
                        MessageBox.Show("Este email já está cadastrado.", "Email Existente",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Verificar se CPF já existe (se foi informado)
                    string cpfLimpo = LimparCPF(tbxCpf.Text);
                    if (!string.IsNullOrWhiteSpace(cpfLimpo) && cpfLimpo != "00000000000")
                    {
                        if (CPFJaCadastrado(conn, cpfLimpo))
                        {
                            MessageBox.Show("Este CPF já está cadastrado.", "CPF Existente",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Inserir novo usuário
                    InserirUsuario(conn);

                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EmailJaCadastrado(SqlConnection conn, string email)
        {
            string verificaSql = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";
            using (SqlCommand verificaCmd = new SqlCommand(verificaSql, conn))
            {
                verificaCmd.Parameters.AddWithValue("@Email", email);
                return (int)verificaCmd.ExecuteScalar() > 0;
            }
        }

        private bool CPFJaCadastrado(SqlConnection conn, string cpf)
        {
            string verificaSql = "SELECT COUNT(*) FROM Usuario WHERE Cpf = @Cpf";
            using (SqlCommand verificaCmd = new SqlCommand(verificaSql, conn))
            {
                verificaCmd.Parameters.AddWithValue("@Cpf", cpf);
                return (int)verificaCmd.ExecuteScalar() > 0;
            }
        }

        private void InserirUsuario(SqlConnection conn)
        {
            string sql = @"INSERT INTO Usuario 
                (Nome, Nascimento, Cpf, Rg, Email, Telefone, Cidade, Rua, Uf, Cep, Pais, Senha) 
                VALUES (@Nome, @Nascimento, @Cpf, @Rg, @Email, @Telefone, @Cidade, @Rua, @Uf, @Cep, @Pais, @Senha)";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", ObterValorCampo(tbxNome, "Digite seu nome completo"));
                cmd.Parameters.AddWithValue("@Nascimento", ObterValorDataNascimento());

                // CPF - limpar e formatar
                string cpfLimpo = LimparCPF(tbxCpf.Text);
                cmd.Parameters.AddWithValue("@Cpf", string.IsNullOrWhiteSpace(cpfLimpo) || cpfLimpo == "00000000000" ?
                    (object)DBNull.Value : cpfLimpo);

                cmd.Parameters.AddWithValue("@Rg", ObterValorCampo(tbxRg, "Número do RG"));
                cmd.Parameters.AddWithValue("@Email", tbxEmail1.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefone", ObterValorCampo(tbxTelefone, "(00) 00000-0000"));
                cmd.Parameters.AddWithValue("@Cidade", ObterValorCampo(tbxCidade, "Nome da cidade"));
                cmd.Parameters.AddWithValue("@Rua", ObterValorCampo(tbxRua, "Nome da rua e número"));
                cmd.Parameters.AddWithValue("@Uf", ObterValorCampo(tbxUf, "UF"));
                cmd.Parameters.AddWithValue("@Cep", ObterValorCampo(tbxCep, "00000-000"));
                cmd.Parameters.AddWithValue("@Pais", ObterValorCampo(tbxPais, "País"));
                cmd.Parameters.AddWithValue("@Senha", tbxSenha1.Text);

                cmd.ExecuteNonQuery();
            }
        }

        private object ObterValorCampo(Control controle, string placeholder = "")
        {
            string texto = controle.Text.Trim();
            if (string.IsNullOrWhiteSpace(texto) || texto == placeholder)
                return DBNull.Value;
            return texto;
        }

        private object ObterValorDataNascimento()
        {
            if (tbxNascimento.MaskCompleted && !string.IsNullOrWhiteSpace(tbxNascimento.Text) && tbxNascimento.Text != "__/__/____")
            {
                try
                {
                    return DateTime.ParseExact(tbxNascimento.Text, "dd/MM/yyyy", null);
                }
                catch
                {
                    return DBNull.Value;
                }
            }
            return DBNull.Value;
        }

        private void LimparCampos()
        {
            // Limpar todos os campos e restaurar placeholders
            tbxNome.Text = "Digite seu nome completo";
            tbxNome.ForeColor = SystemColors.GrayText;

            tbxEmail1.Text = "exemplo@email.com";
            tbxEmail1.ForeColor = SystemColors.GrayText;

            tbxSenha1.Clear();

            tbxCpf.Text = "000.000.000-00";
            tbxCpf.ForeColor = SystemColors.GrayText;

            tbxRg.Text = "Número do RG";
            tbxRg.ForeColor = SystemColors.GrayText;

            tbxNascimento.Text = "__/__/____";
            tbxNascimento.ForeColor = SystemColors.GrayText;

            tbxTelefone.Text = "(00) 00000-0000";
            tbxTelefone.ForeColor = SystemColors.GrayText;

            tbxRua.Text = "Nome da rua e número";
            tbxRua.ForeColor = SystemColors.GrayText;

            tbxCidade.Text = "Nome da cidade";
            tbxCidade.ForeColor = SystemColors.GrayText;

            tbxUf.Text = "UF";
            tbxUf.ForeColor = SystemColors.GrayText;

            tbxCep.Text = "00000-000";
            tbxCep.ForeColor = SystemColors.GrayText;

            tbxPais.Text = "País";
            tbxPais.ForeColor = SystemColors.GrayText;

            tbxNome.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Melhorar a experiência do usuário com eventos adicionais
        private void tbxSenha1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Impedir caracteres especiais na senha se desejar
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbxCep_Leave(object sender, EventArgs e)
        {
            // Formatar CEP
            if (!string.IsNullOrWhiteSpace(tbxCep.Text) && tbxCep.Text != "00000-000")
            {
                string cep = tbxCep.Text.Replace("-", "").Trim();
                if (cep.Length == 8)
                {
                    tbxCep.Text = cep.Insert(5, "-");
                }
            }
        }

        // Formatar CPF automaticamente
        private void tbxCpf_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxCpf.Text) && tbxCpf.Text != "000.000.000-00")
            {
                string cpf = LimparCPF(tbxCpf.Text);
                if (cpf.Length == 11)
                {
                    tbxCpf.Text = $"{cpf.Substring(0, 3)}.{cpf.Substring(3, 3)}.{cpf.Substring(6, 3)}-{cpf.Substring(9, 2)}";
                }
            }
        }

        // Permitir apenas números no CPF
        private void tbxCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Formatar telefone automaticamente
        private void tbxTelefone_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbxTelefone.Text) && tbxTelefone.Text != "(00) 00000-0000")
            {
                string telefone = new string(tbxTelefone.Text.Where(char.IsDigit).ToArray());
                if (telefone.Length == 11)
                {
                    tbxTelefone.Text = $"({telefone.Substring(0, 2)}) {telefone.Substring(2, 5)}-{telefone.Substring(7, 4)}";
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e) { }
        private void tbxEmail1_TextChanged(object sender, EventArgs e) { }
        private void tbxSenha1_TextChanged(object sender, EventArgs e) { }
    }
}