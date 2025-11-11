using System;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Verifica se há usuário logado
            if (!UserSession.EstaLogado)
            {
                MessageBox.Show("Sessão inválida. Faça login novamente.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Atualiza o título com o nome do usuário
            this.Text = $"Controle de Estoque - Usuário: {UserSession.Nome}";
            label1.Text = $"Bem-vindo, {UserSession.Nome}!";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 product = new Form4();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 product = new Form7();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Deseja sair e voltar à tela de login?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                UserSession.EncerrarSessao();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 product = new Form8();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Não fecha o aplicativo, apenas volta para o login
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = false;
            }
        }
    }
}