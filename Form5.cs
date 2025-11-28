using System;
using System.Windows.Forms;
using ControleDeEstoque.Data.Repositories;
using ControleDeEstoque.Helpers;

namespace ControleDeEstoque
{
    public partial class Form5 : Form
    {
        private readonly UsuarioRepository _usuarioRepository;

        public Form5()
        {
            InitializeComponent();
            _usuarioRepository = new UsuarioRepository();
            this.AcceptButton = btnCriar;
            AplicarEstilosModernos();
        }

        private void AplicarEstilosModernos()
        {
            // Configura placeholders para melhor UX
            ConfigurarPlaceholder(tbxNome, "Digite seu nome completo");
            ConfigurarPlaceholder(tbxEmail1, "exemplo@email.com");
            ConfigurarPlaceholder(tbxRua, "Nome da rua e número");
            ConfigurarPlaceholder(tbxCidade, "Nome da cidade");
            ConfigurarPlaceholder(tbxUf, "UF");
            ConfigurarPlaceholder(tbxPais, "País");
            
            // Configurar placeholders para campos que não devem trim no início
            ConfigurarPlaceholderSemTrim(tbxRua, "Nome da rua e número");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidarTodosCampos())
            {
                CadastrarUsuario();
            }
        }

        private bool ValidarTodosCampos()
        {
            // Valida Nome
            if (string.IsNullOrWhiteSpace(tbxNome.Text) ||
                tbxNome.Text == "Digite seu nome completo")
            {
                return MostrarErro("Por favor, preencha o campo Nome.", tbxNome);
            }

            // Valida Email
            string email = tbxEmail1.Text;
            if (string.IsNullOrWhiteSpace(email) || email == "exemplo@email.com")
            {
                return MostrarErro("Por favor, preencha o campo Email.", tbxEmail1);
            }

            if (!ValidationHelper.ValidarEmail(email))
            {
                return MostrarErro("Por favor, insira um email válido.", tbxEmail1);
            }

            // Valida Senha
            if (string.IsNullOrWhiteSpace(tbxSenha1.Text))
            {
                return MostrarErro("Por favor, preencha o campo Senha.", tbxSenha1);
            }

            if (!ValidationHelper.ValidarSenha(tbxSenha1.Text))
            {
                return MostrarErro("A senha deve ter pelo menos 6 caracteres.", tbxSenha1);
            }

            // Valida CPF se fornecido
            string cpfLimpo = ValidationHelper.RemoverFormatacao(tbxCpf.Text);
            if (!string.IsNullOrWhiteSpace(cpfLimpo) &&
                cpfLimpo != "00000000000" &&
                cpfLimpo.Length == 11)
            {
                if (!ValidationHelper.ValidarCPF(cpfLimpo))
                {
                    return MostrarErro("CPF inválido. Verifique os dígitos.", tbxCpf);
                }
            }

            // Valida Data de Nascimento se fornecida
            if (tbxNascimento.MaskCompleted)
            {
                if (DateTime.TryParseExact(tbxNascimento.Text, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out DateTime data))
                {
                    if (!ValidationHelper.ValidarDataNascimento(data, false))
                    {
                        return MostrarErro("Data de nascimento inválida.", tbxNascimento);
                    }
                }
            }

            return true;
        }

        private void CadastrarUsuario()
        {
            try
            {
                string email = tbxEmail1.Text;
                if (email == "exemplo@email.com")
                {
                    email = "";
                }

                // Verifica se email já existe
                if (_usuarioRepository.EmailExiste(email))
                {
                    MessageBox.Show("Este email já está cadastrado.", "Email Existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Verifica se CPF já existe (se foi fornecido)
                string cpfLimpo = ValidationHelper.RemoverFormatacao(tbxCpf.Text);
                if (!string.IsNullOrWhiteSpace(cpfLimpo) &&
                    cpfLimpo != "00000000000" &&
                    cpfLimpo.Length == 11)
                {
                    if (_usuarioRepository.CpfExiste(cpfLimpo))
                    {
                        MessageBox.Show("Este CPF já está cadastrado.", "CPF Existente",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Cria objeto usuário
                var usuario = new Usuario
                {
                    Nome = ObterValorCampo(tbxNome, "Digite seu nome completo"),
                    Email = email,
                    Senha = tbxSenha1.Text,
                    Cpf = ObterValorCampoMascarado(tbxCpf, "000.000.000-00"),
                    Rg = ObterValorCampoMascarado(tbxRg, "00.000.000-0"),
                    Telefone = ObterValorCampoMascarado(tbxTelefone, "(00) 00000-0000"),
                    Rua = ObterValorCampoSemTrimInicio(tbxRua, "Nome da rua e número"),
                    Cidade = ObterValorCampo(tbxCidade, "Nome da cidade"),
                    Uf = ObterValorCampo(tbxUf, "UF"),
                    Cep = ObterValorCampoMascarado(tbxCep, "00000-000"),
                    Pais = ObterValorCampo(tbxPais, "País"),
                    Nascimento = ObterDataNascimento()
                };

                // Cadastra usuário
                if (_usuarioRepository.CadastrarUsuario(usuario))
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao realizar cadastro. Tente novamente.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObterValorCampo(Control controle, string placeholder = "")
        {
            string texto = controle.Text;
            
            // Se o texto for exatamente igual ao placeholder, retorna null
            if (texto == placeholder)
                return null;
                
            // Se estiver vazio ou só espaços, retorna null
            if (string.IsNullOrWhiteSpace(texto))
                return null;
                
            return texto;
        }

        private string ObterValorCampoSemTrimInicio(Control controle, string placeholder = "")
        {
            string texto = controle.Text;
            
            // Se o texto for exatamente igual ao placeholder, retorna null
            if (texto == placeholder)
                return null;
                
            // Se estiver vazio, retorna null (mas preserva se tiver só espaços)
            if (string.IsNullOrEmpty(texto))
                return null;
                
            return texto;
        }

        private string ObterValorCampoMascarado(MaskedTextBox controle, string mascaraCompleta = "")
        {
            string texto = controle.Text;
            
            // Se o texto for exatamente igual à máscara completa (com underlines), retorna null
            if (texto.Replace('_', ' ').Trim() == mascaraCompleta.Replace('_', ' ').Trim())
                return null;
                
            // Se não preencheu a máscara completamente, retorna null
            if (!controle.MaskCompleted)
                return null;
                
            // Se estiver vazio, retorna null
            if (string.IsNullOrWhiteSpace(texto))
                return null;
                
            return texto;
        }

        private DateTime? ObterDataNascimento()
        {
            if (tbxNascimento.MaskCompleted &&
                DateTime.TryParseExact(tbxNascimento.Text, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out DateTime data))
            {
                return data;
            }
            return null;
        }

        private void LimparCampos()
        {
            tbxNome.Clear();
            tbxEmail1.Clear();
            tbxSenha1.Clear();
            tbxCpf.Clear();
            tbxRg.Clear();
            tbxNascimento.Clear();
            tbxTelefone.Clear();
            tbxRua.Clear();
            tbxCidade.Clear();
            tbxUf.Clear();
            tbxCep.Clear();
            tbxPais.Clear();
            
            // Reaplicar placeholders após limpar
            AplicarEstilosModernos();
            tbxNome.Focus();
        }

        private bool MostrarErro(string mensagem, Control controle)
        {
            MessageBox.Show(mensagem, "Validação",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controle.Focus();
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigurarPlaceholder(Control controle, string placeholder)
        {
            if (controle is TextBox textBox)
            {
                textBox.Enter += (s, e) =>
                {
                    if (textBox.Text == placeholder)
                    {
                        textBox.Text = "";
                        textBox.ForeColor = System.Drawing.SystemColors.WindowText;
                    }
                };

                textBox.Leave += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.Text = placeholder;
                        textBox.ForeColor = System.Drawing.SystemColors.GrayText;
                    }
                };

                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.SystemColors.GrayText;
                }
            }
        }

        private void ConfigurarPlaceholderSemTrim(Control controle, string placeholder)
        {
            if (controle is TextBox textBox)
            {
                textBox.Enter += (s, e) =>
                {
                    if (textBox.Text == placeholder)
                    {
                        textBox.Text = "";
                        textBox.ForeColor = System.Drawing.SystemColors.WindowText;
                    }
                };

                textBox.Leave += (s, e) =>
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        textBox.Text = placeholder;
                        textBox.ForeColor = System.Drawing.SystemColors.GrayText;
                    }
                };

                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = System.Drawing.SystemColors.GrayText;
                }
            }
        }

        private void Form5_Load(object sender, EventArgs e) { }
        private void tbxEmail1_TextChanged(object sender, EventArgs e) { }
        private void tbxSenha1_TextChanged(object sender, EventArgs e) { }
    }
}