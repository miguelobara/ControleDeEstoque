
using System;
using System.Data;
using System.Windows.Forms;
using ControleDeEstoque.Data.Repositories;

namespace ControleDeEstoque
{
    public partial class Form7 : Form
    {
        private readonly FornecedorRepository _fornecedorRepository;

        public Form7()
        {
            InitializeComponent();
            _fornecedorRepository = new FornecedorRepository();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            try
            {
                // Verifica se usuário está logado
                UserSession.VerificarSessao();

                // Atualiza título com nome do usuário
                this.Text = $"Fornecedores - {UserSession.Nome}";

                // Carrega apenas fornecedores do usuário logado
                CarregarFornecedoresDoUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void CarregarFornecedoresDoUsuario()
        {
            try
            {
                // Obtém APENAS fornecedores do usuário logado
                DataTable fornecedores = _fornecedorRepository.ObterTodosFornecedores();

                // Configura o DataGridView
                dataGridView1.DataSource = fornecedores;

                // Configura as colunas
                if (dataGridView1.Columns.Count > 0)
                {
                    dataGridView1.Columns["Id_Fornecedor"].Visible = false;
                    dataGridView1.Columns["Nome_For"].HeaderText = "Nome";
                    dataGridView1.Columns["Nome_For"].Width = 150;
                    dataGridView1.Columns["Telefone_For"].HeaderText = "Telefone";
                    dataGridView1.Columns["Telefone_For"].Width = 100;
                    dataGridView1.Columns["Email_For"].HeaderText = "E-mail";
                    dataGridView1.Columns["Email_For"].Width = 150;
                    dataGridView1.Columns["Cep_For"].HeaderText = "CEP";
                    dataGridView1.Columns["Cep_For"].Width = 80;
                    dataGridView1.Columns["Data_Cadastro_For"].HeaderText = "Data Cadastro";
                    dataGridView1.Columns["Data_Cadastro_For"].Width = 100;
                    dataGridView1.Columns["estatus_For"].HeaderText = "Status";
                    dataGridView1.Columns["estatus_For"].Width = 60;

                    // Oculta colunas desnecessárias
                    dataGridView1.Columns["Cnpj_For"].Visible = false;
                    dataGridView1.Columns["Cidade_For"].Visible = false;
                    dataGridView1.Columns["Rua_For"].Visible = false;
                }

                // Atualiza label com quantidade
                label2.Text = $"Novo Fornecedor ({fornecedores.Rows.Count} cadastrados)";

                // Log de debug
                System.Diagnostics.Debug.WriteLine(
                    $"[FORM7] Usuário: {UserSession.Nome} (ID: {UserSession.IdUsuario}) " +
                    $"| Fornecedores: {fornecedores.Rows.Count}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 product = new Form2();
            this.Hide();
            product.ShowDialog();
            this.Close();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            Form6 product = new Form6();
            this.Hide();
            product.ShowDialog();

            // Ao voltar, recarrega a lista
            if (!this.IsDisposed)
            {
                CarregarFornecedoresDoUsuario();
                this.Show();
            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Não fecha o aplicativo, apenas o formulário
        }
    }
}