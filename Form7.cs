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
                // Limpa o DataGridView antes de carregar novos dados
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                // Obtém APENAS fornecedores do usuário logado
                DataTable fornecedores = _fornecedorRepository.ObterTodosFornecedores();

                // Configura o DataGridView
                dataGridView1.DataSource = fornecedores;

                // Configura as colunas
                if (dataGridView1.Columns.Count > 0)
                {
                    ConfigurarColunasDataGridView();
                }

                // CORREÇÃO: Atualiza label com quantidade formatada corretamente
                int quantidade = fornecedores.Rows.Count;
                label2.Text = $"Novo Fornecedor ({quantidade} {(quantidade == 1 ? "cadastrado" : "cadastrados")})";

                // Log de debug
                System.Diagnostics.Debug.WriteLine(
                    $"[FORM7] Usuário: {UserSession.Nome} (ID: {UserSession.IdUsuario}) " +
                    $"| Fornecedores: {quantidade}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColunasDataGridView()
        {
            // Oculta coluna ID
            OcultarColuna("Id_Fornecedor");
            OcultarColuna("Id_Usuario");

            // Configura colunas visíveis
            ConfigurarColuna("Nome_For", "Nome", 150);
            ConfigurarColuna("Telefone_For", "Telefone", 100);
            ConfigurarColuna("Email_For", "E-mail", 150);
            ConfigurarColuna("Cep_For", "CEP", 80);
            ConfigurarColuna("Data_Cadastro_For", "Data Cadastro", 100);
            ConfigurarColuna("estatus_For", "Status", 60);

            // Oculta colunas desnecessárias
            OcultarColuna("Cnpj_For");
            OcultarColuna("Cidade_For");
            OcultarColuna("Rua_For");
        }

        private void ConfigurarColuna(string nomeColuna, string headerText, int width)
        {
            if (dataGridView1.Columns.Contains(nomeColuna))
            {
                dataGridView1.Columns[nomeColuna].HeaderText = headerText;
                dataGridView1.Columns[nomeColuna].Width = width;
                dataGridView1.Columns[nomeColuna].HeaderCell.Style.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            }
        }

        private void OcultarColuna(string nomeColuna)
        {
            if (dataGridView1.Columns.Contains(nomeColuna))
                dataGridView1.Columns[nomeColuna].Visible = false;
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Formata a coluna de data
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Data_Cadastro_For" && e.Value != null)
            {
                if (DateTime.TryParse(e.Value.ToString(), out DateTime data))
                {
                    e.Value = data.ToString("dd/MM/yyyy");
                    e.FormattingApplied = true;
                }
            }

            // Formata a coluna de status
            if (dataGridView1.Columns[e.ColumnIndex].Name == "estatus_For" && e.Value != null)
            {
                string status = e.Value.ToString();
                e.Value = status == "A" ? "Ativo" : "Inativo";
                e.FormattingApplied = true;
            }
        }
    }
}