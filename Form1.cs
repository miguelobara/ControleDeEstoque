using System;
using System.Windows.Forms;
using ControleDeEstoque.Data.Repositories;
using ControleDeEstoque.Helpers;

namespace ControleDeEstoque
{
    public partial class Form1 : Form
    {
        private readonly UsuarioRepository _usuarioRepository;

        public Form1()
        {
            InitializeComponent();
            _usuarioRepository = new UsuarioRepository();

            // Configura tecla Enter para fazer login
            this.AcceptButton = btnEnter;
        }

        private void FrmEnter_Click(object sender, EventArgs e)
        {
            RealizarLogin();
        }

        private void RealizarLogin()
        {
            // Validações básicas
            string email = tbxEmail.Text.Trim();
            string senha = tbxSenha.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MostrarErro("Por favor, digite seu email.", tbxEmail);
                return;
            }

            //if (!ValidationHelper.ValidarEmail(email))
            //{
            //    MostrarErro("Por favor, digite um email válido.", tbxEmail);
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(senha))
            {
                MostrarErro("Por favor, digite sua senha.", tbxSenha);
                return;
            }

            try
            {
                // Valida credenciais usando o repositório
                if (_usuarioRepository.ValidarLogin(email, senha))
                {
                    AbrirFormularioPrincipal();
                }
                else
                {
                    MessageBox.Show("Email ou senha incorretos.", "Erro de Login",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxSenha.Clear();
                    tbxSenha.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar login: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AbrirFormularioPrincipal()
        {
            Form2 formPrincipal = new Form2();
            this.Hide();
            formPrincipal.ShowDialog();

            if (!this.IsDisposed)
            {
                LimparCampos();
                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Primeiro acesso - abre formulário de cadastro
            Form5 formCadastro = new Form5();
            this.Hide();
            formCadastro.ShowDialog();

            if (!this.IsDisposed)
                this.Show();
        }

        private void LimparCampos()
        {
            tbxEmail.Clear();
            tbxSenha.Clear();
            tbxEmail.Focus();
        }

        private void MostrarErro(string mensagem, Control controle)
        {
            MessageBox.Show(mensagem, "Validação",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controle.Focus();
        }

        // Eventos vazios necessários pelo Designer (podem ser removidos se não usados)
        private void texboxName_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void tbxSenha_TextChanged(object sender, EventArgs e) { }
    }
}