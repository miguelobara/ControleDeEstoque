using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    /// <summary>
    /// Form2 ATUALIZADO - Menu Principal com botão de Vendas
    /// </summary>
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

            // NOVO: Adiciona botão de vendas se não existir
            AdicionarBotaoVendas();
        }

        /// <summary>
        /// NOVO: Adiciona botão de vendas ao formulário
        /// </summary>
        private void AdicionarBotaoVendas()
        {
            // Verifica se o botão já existe
            bool botaoExiste = false;
            foreach (Control control in panel2.Controls)
            {
                if (control is Button btn && btn.Name == "btnVendas")
                {
                    botaoExiste = true;
                    break;
                }
            }

            if (!botaoExiste)
            {
                Button btnVendas = new Button
                {
                    Name = "btnVendas",
                    Text = "🛒 Vendas",
                    Location = new Point(125, 300), // Abaixo dos outros botões
                    Size = new Size(200, 120),
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 12, FontStyle.Bold)
                };

                btnVendas.FlatAppearance.BorderSize = 0;
                btnVendas.FlatAppearance.MouseDownBackColor = Color.DarkGreen;
                btnVendas.FlatAppearance.MouseOverBackColor = Color.ForestGreen;

                btnVendas.Click += BtnVendas_Click;

                panel2.Controls.Add(btnVendas);

                // Reposiciona o label de instrução se existir
                if (label2 != null)
                {
                    label2.Location = new Point(label2.Location.X, 60);
                }

                // Ajusta posição dos botões existentes se necessário
                if (button1 != null) // Adicionar Produto
                    button1.Location = new Point(125, 150);

                if (button2 != null) // Fornecedor
                    button2.Location = new Point(400, 150);

                if (button3 != null) // Lucros
                    button3.Location = new Point(675, 150);
            }
        }

        /// <summary>
        /// NOVO: Abre o formulário de vendas
        /// </summary>
        private void BtnVendas_Click(object sender, EventArgs e)
        {
            try
            {
                Form9 formVendas = new Form9();
                this.Visible = false;
                formVendas.ShowDialog();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao abrir sistema de vendas:\n{ex.Message}\n\n" +
                    "Certifique-se de que o Form9.cs foi adicionado ao projeto.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
            try
            {
                Form8 product = new Form8();
                this.Visible = false;
                product.ShowDialog();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao abrir análise de lucros:\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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