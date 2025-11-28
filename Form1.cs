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
            this.AcceptButton = btnEnter;

            // Limpa qualquer sessão anterior
            UserSession.EncerrarSessao();
        }

        private void FrmEnter_Click(object sender, EventArgs e)
        {
            RealizarLogin();
        }

        private void RealizarLogin()
        {
            string email = tbxEmail.Text.Trim();
            string senha = tbxSenha.Text;

            if (string.IsNullOrWhiteSpace(email))
            {
                MostrarErro("Por favor, digite seu email.", tbxEmail);
                return;
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                MostrarErro("Por favor, digite sua senha.", tbxSenha);
                return;
            }

            try
            {
                // Valida credenciais e obtém dados do usuário
                var usuario = _usuarioRepository.ValidarLoginCompleto(email, senha);

                if (usuario != null)
                {
                    // INICIA A SESSÃO DO USUÁRIO
                    UserSession.IniciarSessao(usuario.Id, usuario.Nome, usuario.Email);

                    MessageBox.Show($"Bem-vindo, {usuario.Nome}!", "Login Realizado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                // Quando voltar, encerra a sessão
                UserSession.EncerrarSessao();
                LimparCampos();
                this.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
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

        private void texboxName_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void tbxSenha_TextChanged(object sender, EventArgs e) { }

        private void tbxSenha_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}