using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

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
        }

        private void ConfigurarPlaceholder(TextBox textBox, string placeholder)
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
            if (!string.IsNullOrWhiteSpace(tbxCpf.Text) && tbxCpf.Text.Replace(",", "").Replace("-", "").Replace("_", "").Length != 11)
            {
                MostrarErro("CPF inválido. Deve conter 11 dígitos.", tbxCpf);
                return false;
            }

            return true;
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

        private void InserirUsuario(SqlConnection conn)
        {
            string sql = @"INSERT INTO Usuario 
                (Nome, Nascimento, Cpf, Rg, Email, Telefone, Cidade, Rua, Uf, Cep, Pais, Senha) 
                VALUES (@Nome, @Nascimento, @Cpf, @Rg, @Email, @Telefone, @Cidade, @Rua, @Uf, @Cep, @Pais, @Senha)";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", ObterValorCampo(tbxNome, "Digite seu nome completo"));
                cmd.Parameters.AddWithValue("@Nascimento", ObterValorDataNascimento());
                cmd.Parameters.AddWithValue("@Cpf", ObterValorCampo(tbxCpf));
                cmd.Parameters.AddWithValue("@Rg", ObterValorCampo(tbxRg, "Número do RG"));
                cmd.Parameters.AddWithValue("@Email", tbxEmail1.Text.Trim());
                cmd.Parameters.AddWithValue("@Telefone", ObterValorCampo(tbxTelefone));
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
            if (tbxNascimento.Text != "__/__/____" && !string.IsNullOrWhiteSpace(tbxNascimento.Text))
            {
                try
                {
                    return DateTime.Parse(tbxNascimento.Text.Trim());
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

            tbxEmail1.Clear();
            tbxSenha1.Clear();

            tbxCpf.Clear();
            tbxRg.Text = "Número do RG";
            tbxRg.ForeColor = SystemColors.GrayText;

            tbxNascimento.Clear();
            tbxTelefone.Clear();

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

        private void Form5_Load(object sender, EventArgs e) { }
        private void tbxEmail1_TextChanged(object sender, EventArgs e) { }
        private void tbxSenha1_TextChanged(object sender, EventArgs e) { }
    }
}