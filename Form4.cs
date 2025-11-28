using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace ControleDeEstoque
{
    public partial class Form4 : Form
    {
        private string connectionString = "Data Source=SQLEXPRESS;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";
        private bool modoEdicao = false;
        private int produtoIdEmEdicao = 0;
        private decimal percentualLucro = 30m;
        private Dictionary<int, string> fornecedores = new Dictionary<int, string>();

        public Form4()
        {
            InitializeComponent();
            ConectarEventos();
        }

        private void ConectarEventos()
        {
            // Simplificado: Conecta todos os eventos em um único método
            btnSalvar.Click += btnSalvar_Click;
            btnLimpar.Click += btnLimpar_Click;
            btnDeletar.Click += btnDeletar_Click;
            btnEditar.Click += btnEditar_Click;
            btnNovaUnidade.Click += btnNovaUnidade_Click;
            btnNovaCategoria.Click += btnNovaCategoria_Click;
            btnMudarLucro.Click += btnMudarLucro_Click;
            tbxProcurar.TextChanged += tbxProcurar_TextChanged;

            // Checkboxes de busca
            chkBuscarNome.CheckedChanged += (s, e) => ProcurarProdutosInteligente();
            chkBuscarCategoria.CheckedChanged += (s, e) => ProcurarProdutosInteligente();
            chkBuscarFornecedor.CheckedChanged += (s, e) => ProcurarProdutosInteligente();
            chkBuscarDescricao.CheckedChanged += (s, e) => ProcurarProdutosInteligente();

            dgvProdutos.SelectionChanged += dgvProdutos_SelectionChanged;

            // Cálculo automático de preço
            tbxPrecoCompra.TextChanged += (s, e) => CalcularPrecoVendaRecomendado();
            tbxPrecoVenda.TextChanged += (s, e) => VerificarDiferencaPreco();
            nudQuantidade.ValueChanged += (s, e) => CalcularPrecoVendaRecomendado();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                UserSession.VerificarSessao();
                CarregarConfiguracoesJuros();
                CarregarUnidades();
                CarregarCategorias();
                CarregarFornecedores();
                CarregarProdutos();
                ConfigurarDataGridView();
                AtualizarLabelPercentualLucro();
            }
            catch (Exception ex)
            {
                MostrarErro($"Erro ao carregar formulário: {ex.Message}");
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.BorderStyle = BorderStyle.None;
            dgvProdutos.EnableHeadersVisualStyles = false;
            dgvProdutos.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvProdutos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProdutos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvProdutos.RowHeadersVisible = false;
        }

        // ===============================================
        // CARREGAMENTO DE DADOS
        // ===============================================

        private void CarregarConfiguracoesJuros()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT TOP 1 juros 
                        FROM Produto 
                        WHERE juros IS NOT NULL AND juros > 0 AND Id_Usuario = @IdUsuario
                        ORDER BY Id_Prod DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);
                        object result = cmd.ExecuteScalar();
                        percentualLucro = result != null && result != DBNull.Value
                            ? Convert.ToDecimal(result)
                            : 30m;
                    }
                }
            }
            catch
            {
                percentualLucro = 30m;
            }
        }

        private void CarregarFornecedores()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT Id_Fornecedor, Nome_For 
                        FROM Fornecedor 
                        WHERE Id_Usuario = @IdUsuario
                        ORDER BY Nome_For";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            fornecedores.Clear();
                            cbxFornecedor.Items.Clear();
                            cbxFornecedor.Items.Add("Selecione um fornecedor");

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string nome = reader.GetString(1);
                                fornecedores.Add(id, nome);
                                cbxFornecedor.Items.Add(nome);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarErro($"Erro ao carregar fornecedores: {ex.Message}");
            }
        }

        private void CarregarUnidades()
        {
            cbxUnidade.Items.Clear();
            cbxUnidade.Items.AddRange(new object[] {
                "Kg", "g", "L", "ml", "Unidade", "Caixa", "Pacote", "Fardo"
            });
        }

        private void CarregarCategorias()
        {
            cbxTipo.Items.Clear();
            cbxTipo.Items.AddRange(new object[] {
                "Limpeza", "Bebida", "Comida", "Higiene", "Bazar", "Outros"
            });
        }

        private void CarregarProdutos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            p.Id_Prod, p.Nome_Prod, p.Categoria, p.Validade, p.Descricao, 
                            p.Preco_Ven, p.Preco_Cmp, p.Quantidade_Prod, 
                            p.Unidade_Medida_Prod, f.Nome_For as Fornecedor, p.juros
                        FROM Produto p
                        LEFT JOIN Fornecedor f ON p.Id_Fornecedor = f.Id_Fornecedor
                        WHERE p.Id_Usuario = @IdUsuario
                        ORDER BY p.Nome_Prod";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProdutos.DataSource = dt;
                    AplicarConfiguracoesColunas();
                }
            }
            catch (Exception ex)
            {
                MostrarErro($"Erro ao carregar produtos: {ex.Message}");
            }
        }

        private void AplicarConfiguracoesColunas()
        {
            if (dgvProdutos.Columns.Count == 0) return;

            var configs = new Dictionary<string, (string Header, int Width)>
            {
                ["Id_Prod"] = ("ID", 50),
                ["Nome_Prod"] = ("Nome do Produto", 150),
                ["Categoria"] = ("Categoria", 100),
                ["Validade"] = ("Validade", 80),
                ["Descricao"] = ("Descrição", 200),
                ["Preco_Ven"] = ("Preço Venda", 90),
                ["Preco_Cmp"] = ("Preço Compra", 90),
                ["Quantidade_Prod"] = ("Quantidade", 80),
                ["Unidade_Medida_Prod"] = ("Unidade", 80),
                ["Fornecedor"] = ("Fornecedor", 120),
                ["juros"] = ("Juros %", 60)
            };

            foreach (var config in configs)
            {
                if (dgvProdutos.Columns.Contains(config.Key))
                {
                    dgvProdutos.Columns[config.Key].HeaderText = config.Value.Header;
                    dgvProdutos.Columns[config.Key].Width = config.Value.Width;
                }
            }
        }

        // ===============================================
        // BUSCA E FILTROS
        // ===============================================

        private void ProcurarProdutosInteligente()
        {
            string termo = tbxProcurar.Text.Trim();

            if (string.IsNullOrEmpty(termo))
            {
                CarregarProdutos();
                return;
            }

            try
            {
                var conditions = new List<string> { "p.Id_Usuario = @IdUsuario" };
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@IdUsuario", UserSession.IdUsuario),
                    new SqlParameter("@Termo", $"%{termo}%")
                };

                if (chkBuscarNome.Checked) conditions.Add("p.Nome_Prod LIKE @Termo");
                if (chkBuscarCategoria.Checked) conditions.Add("p.Categoria LIKE @Termo");
                if (chkBuscarFornecedor.Checked) conditions.Add("f.Nome_For LIKE @Termo");
                if (chkBuscarDescricao.Checked) conditions.Add("p.Descricao LIKE @Termo");

                if (conditions.Count == 1) conditions.Add("p.Nome_Prod LIKE @Termo");

                string query = $@"
                    SELECT 
                        p.Id_Prod, p.Nome_Prod, p.Categoria, p.Validade, p.Descricao, 
                        p.Preco_Ven, p.Preco_Cmp, p.Quantidade_Prod, 
                        p.Unidade_Medida_Prod, f.Nome_For as Fornecedor, p.juros
                    FROM Produto p
                    LEFT JOIN Fornecedor f ON p.Id_Fornecedor = f.Id_Fornecedor
                    WHERE {conditions[0]} AND ({string.Join(" OR ", conditions.GetRange(1, conditions.Count - 1))})
                    ORDER BY p.Nome_Prod";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());

                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvProdutos.DataSource = dt;
                    AplicarConfiguracoesColunas();
                }
            }
            catch (Exception ex)
            {
                MostrarErro($"Erro ao buscar produtos: {ex.Message}");
            }
        }

        private void tbxProcurar_TextChanged(object sender, EventArgs e)
        {
            ProcurarProdutosInteligente();
        }

        // ===============================================
        // CÁLCULOS
        // ===============================================

        private void CalcularPrecoVendaRecomendado()
        {
            if (!decimal.TryParse(tbxPrecoCompra.Text, out decimal precoCompra) || precoCompra <= 0)
            {
                lblPrecoVendaRecomendado.Visible = false;
                return;
            }

            int quantidade = (int)nudQuantidade.Value;

            decimal precoVendaRecomendado = precoCompra * (1 + percentualLucro / 100m);
            decimal lucroUnitario = precoVendaRecomendado - precoCompra;

            tbxPrecoVenda.Text = precoVendaRecomendado.ToString("F2");

            string texto = quantidade > 1
                ? $"Preço Venda Recomendado: R$ {precoVendaRecomendado:F2} (cada)\n" +
                  $"Lucro unitário: R$ {lucroUnitario:F2} (+{percentualLucro}%)\n" +
                  $"Valor total estoque: R$ {precoCompra * quantidade:F2}\n" +
                  $"Potencial venda: R$ {precoVendaRecomendado * quantidade:F2}\n" +
                  $"Lucro total: R$ {lucroUnitario * quantidade:F2}"
                : $"Preço Venda: R$ {precoVendaRecomendado:F2}\n" +
                  $"Lucro: R$ {lucroUnitario:F2} (+{percentualLucro}%)";

            lblPrecoVendaRecomendado.Text = texto;
            lblPrecoVendaRecomendado.ForeColor = Color.DarkBlue;
            lblPrecoVendaRecomendado.BackColor = Color.LightYellow;
            lblPrecoVendaRecomendado.BorderStyle = BorderStyle.FixedSingle;
            lblPrecoVendaRecomendado.Visible = true;

            VerificarDiferencaPreco();
        }

        private void VerificarDiferencaPreco()
        {
            if (!decimal.TryParse(tbxPrecoCompra.Text, out decimal precoCompra) ||
                !decimal.TryParse(tbxPrecoVenda.Text, out decimal precoVenda))
                return;

            decimal precoRecomendado = precoCompra * (1 + percentualLucro / 100m);

            if (precoVenda < precoRecomendado * 0.90m)
            {
                lblPrecoVendaRecomendado.ForeColor = Color.DarkRed;
                lblPrecoVendaRecomendado.BackColor = Color.LightCoral;
                lblPrecoVendaRecomendado.Text += "\nATENÇÃO: Preço abaixo do recomendado!";
            }
            else if (precoVenda > precoRecomendado * 1.20m)
            {
                lblPrecoVendaRecomendado.ForeColor = Color.Purple;
                lblPrecoVendaRecomendado.BackColor = Color.Lavender;
            }
            else
            {
                lblPrecoVendaRecomendado.ForeColor = Color.DarkGreen;
                lblPrecoVendaRecomendado.BackColor = Color.LightGreen;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                int? idFornecedor = ObterIdFornecedorSelecionado();

                decimal precoCompra = decimal.Parse(tbxPrecoCompra.Text);
                decimal precoVenda = decimal.Parse(tbxPrecoVenda.Text);
                int quantidade = (int)nudQuantidade.Value;

                // Verifica prejuízo
                if (!ConfirmarPrejuizo(precoCompra, precoVenda, quantidade))
                    return;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = modoEdicao
                        ? @"UPDATE Produto SET 
                            Nome_Prod = @Nome, Categoria = @Categoria, Validade = @Validade, 
                            Descricao = @Descricao, Preco_Ven = @PrecoVenda, Preco_Cmp = @PrecoCompra, 
                            Quantidade_Prod = @Quantidade, Unidade_Medida_Prod = @UnidadeMedida, 
                            Id_Fornecedor = @IdFornecedor, juros = @Juros
                           WHERE Id_Prod = @IdProduto AND Id_Usuario = @IdUsuario"
                        : @"DECLARE @NextID INT;
                           SELECT @NextID = ISNULL(MAX(Id_Prod), 0) + 1 FROM Produto;
                           
                           INSERT INTO Produto 
                           (Id_Prod, Nome_Prod, Categoria, Validade, Descricao, Preco_Ven, Preco_Cmp, 
                            Quantidade_Prod, Unidade_Medida_Prod, Id_Fornecedor, juros, Id_Usuario) 
                           VALUES 
                           (@NextID, @Nome, @Categoria, @Validade, @Descricao, @PrecoVenda, @PrecoCompra, 
                            @Quantidade, @UnidadeMedida, @IdFornecedor, @Juros, @IdUsuario)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", tbxNome.Text);
                        cmd.Parameters.AddWithValue("@Categoria", cbxTipo.Text);
                        cmd.Parameters.AddWithValue("@Validade", dtpValidade.Value);
                        cmd.Parameters.AddWithValue("@Descricao", tbxDescricao.Text ?? "");
                        cmd.Parameters.AddWithValue("@PrecoVenda", precoVenda);
                        cmd.Parameters.AddWithValue("@PrecoCompra", precoCompra);
                        cmd.Parameters.AddWithValue("@Quantidade", quantidade);
                        cmd.Parameters.AddWithValue("@UnidadeMedida", cbxUnidade.Text);
                        cmd.Parameters.AddWithValue("@IdFornecedor", (object)idFornecedor ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Juros", percentualLucro);
                        cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);

                        if (modoEdicao)
                            cmd.Parameters.AddWithValue("@IdProduto", produtoIdEmEdicao);

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show($"Produto {(modoEdicao ? "editado" : "salvo")} com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (modoEdicao) DesativarModoEdicao();
                            LimparCampos();
                            CarregarProdutos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarErro($"Erro ao salvar produto: {ex.Message}");
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(tbxNome.Text))
                return MostrarErro("Informe o nome do produto.", tbxNome);

            if (!decimal.TryParse(tbxPrecoCompra.Text, out decimal precoCompra) || precoCompra <= 0)
                return MostrarErro("Informe um preço de compra válido.", tbxPrecoCompra);

            if (!decimal.TryParse(tbxPrecoVenda.Text, out decimal precoVenda) || precoVenda <= 0)
                return MostrarErro("Informe um preço de venda válido.", tbxPrecoVenda);

            if (nudQuantidade.Value < 0)
                return MostrarErro("Informe uma quantidade válida.", nudQuantidade);

            string fornecedorSelecionado = cbxFornecedor.Text;
            if (!string.IsNullOrEmpty(fornecedorSelecionado) &&
                fornecedorSelecionado != "Selecione um fornecedor")
            {
                if (ObterIdFornecedorSelecionado() == null)
                    return MostrarErro("Fornecedor selecionado não encontrado.", cbxFornecedor);
            }

            return true;
        }

        private bool ConfirmarPrejuizo(decimal precoCompra, decimal precoVenda, int quantidade)
        {
            if (precoVenda >= precoCompra) return true;

            decimal prejuizoUnitario = precoCompra - precoVenda;
            decimal prejuizoTotal = prejuizoUnitario * quantidade;

            string msg = $"ATENÇÃO: PREJUÍZO DETECTADO!\n\n" +
                        $"Por unidade:\n" +
                        $"  • Preço Compra: R$ {precoCompra:F2}\n" +
                        $"  • Preço Venda: R$ {precoVenda:F2}\n" +
                        $"  • Prejuízo: R$ {prejuizoUnitario:F2}\n\n";

            if (quantidade > 1)
                msg += $"Total ({quantidade} unidades):\n  • Prejuízo Total: R$ {prejuizoTotal:F2}\n\n";

            msg += "Deseja continuar mesmo assim?";

            return MessageBox.Show(msg, "ALERTA - PREJUÍZO",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
        }

        // ===============================================
        // CRUD - EDITAR E DELETAR
        // ===============================================

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                MostrarErro("Selecione um produto para editar.");
                return;
            }

            try
            {
                DataGridViewRow row = dgvProdutos.SelectedRows[0];
                string idProduto = GetCellValue(row, "Id_Prod");

                if (!string.IsNullOrEmpty(idProduto))
                {
                    modoEdicao = true;
                    produtoIdEmEdicao = Convert.ToInt32(idProduto);
                    CarregarDadosParaEdicao(row);
                    AtivarModoEdicao();

                    MessageBox.Show($"Modo edição ativado!\n\nID: {idProduto}\n" +
                        "Faça as alterações e clique em SALVAR.", "Modo Edição",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MostrarErro($"Erro ao ativar modo edição: {ex.Message}");
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count == 0)
            {
                MostrarErro("Selecione um produto para deletar.");
                return;
            }

            try
            {
                DataGridViewRow row = dgvProdutos.SelectedRows[0];
                string idProduto = GetCellValue(row, "Id_Prod");
                string nomeProduto = GetCellValue(row, "Nome_Prod") ?? "Produto selecionado";

                var result = MessageBox.Show(
                    $"DELETAR PRODUTO\n\nID: {idProduto}\nNome: {nomeProduto}\n\n" +
                    "Tem certeza?", "Confirmar Deleção",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Produto WHERE Id_Prod = @Id AND Id_Usuario = @IdUsuario";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", Convert.ToInt32(idProduto));
                            cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);

                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("Produto deletado com sucesso!", "Sucesso",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CarregarProdutos();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarErro($"Erro ao deletar produto: {ex.Message}");
            }
        }

        private void CarregarDadosParaEdicao(DataGridViewRow row)
        {
            tbxNome.Text = GetCellValue(row, "Nome_Prod");
            cbxTipo.Text = GetCellValue(row, "Categoria");
            cbxUnidade.Text = GetCellValue(row, "Unidade_Medida_Prod");
            tbxPrecoCompra.Text = GetCellValue(row, "Preco_Cmp");
            tbxDescricao.Text = GetCellValue(row, "Descricao");

            string quantidade = GetCellValue(row, "Quantidade_Prod");
            if (decimal.TryParse(quantidade, out decimal qtd))
                nudQuantidade.Value = (int)qtd;

            tbxPrecoVenda.Text = GetCellValue(row, "Preco_Ven");

            string fornecedor = GetCellValue(row, "Fornecedor");
            cbxFornecedor.Text = !string.IsNullOrEmpty(fornecedor)
                ? fornecedor
                : "Selecione um fornecedor";

            string juros = GetCellValue(row, "juros");
            if (!string.IsNullOrEmpty(juros) && decimal.TryParse(juros, out decimal jurosProduto))
            {
                percentualLucro = jurosProduto;
                AtualizarLabelPercentualLucro();
            }

            string validade = GetCellValue(row, "Validade");
            if (DateTime.TryParse(validade, out DateTime dataValidade))
                dtpValidade.Value = dataValidade;

            CalcularPrecoVendaRecomendado();
        }

        private void AtivarModoEdicao()
        {
            this.BackColor = Color.FromArgb(255, 255, 225);
            btnSalvar.Text = "Salvar Edição";
            btnEditar.Enabled = false;
            this.Text = "Cadastro de Produtos - [EDITANDO]";
        }

        private void DesativarModoEdicao()
        {
            modoEdicao = false;
            produtoIdEmEdicao = 0;
            this.BackColor = Color.Silver;
            btnSalvar.Text = "Salvar";
            btnEditar.Enabled = true;
            this.Text = "Cadastro de Produtos";
        }

        // ===============================================
        // MÉTODOS AUXILIARES
        // ===============================================

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (modoEdicao)
            {
                DesativarModoEdicao();
                MessageBox.Show("Edição cancelada.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LimparCampos();
        }

        private void LimparCampos()
        {
            tbxProcurar.Clear();
            tbxNome.Clear();
            cbxTipo.SelectedIndex = -1;
            cbxUnidade.SelectedIndex = -1;
            tbxPrecoCompra.Clear();
            tbxDescricao.Clear();
            nudQuantidade.Value = 0;
            tbxPrecoVenda.Clear();
            cbxFornecedor.SelectedIndex = 0;
            dtpValidade.Value = DateTime.Now;
            lblPrecoVendaRecomendado.Visible = false;

            chkBuscarNome.Checked = true;
            chkBuscarCategoria.Checked = false;
            chkBuscarFornecedor.Checked = false;
            chkBuscarDescricao.Checked = false;
        }

        private void btnNovaUnidade_Click(object sender, EventArgs e)
        {
            string novaUnidade = ShowInputDialog("Digite o nome da nova unidade:", "Nova Unidade");
            if (!string.IsNullOrEmpty(novaUnidade))
            {
                cbxUnidade.Items.Add(novaUnidade);
                cbxUnidade.Text = novaUnidade;
            }
        }

        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            string novaCategoria = ShowInputDialog("Digite o nome da nova categoria:", "Nova Categoria");
            if (!string.IsNullOrEmpty(novaCategoria))
            {
                cbxTipo.Items.Add(novaCategoria);
                cbxTipo.Text = novaCategoria;
            }
        }

        private void btnMudarLucro_Click(object sender, EventArgs e)
        {
            string novoPercentual = ShowInputDialog(
                $"Percentual atual: {percentualLucro}%\n\nDigite o novo percentual:",
                "Alterar Lucro");

            if (decimal.TryParse(novoPercentual, out decimal novoValor) && novoValor > 0)
            {
                percentualLucro = novoValor;
                AtualizarLabelPercentualLucro();
                CalcularPrecoVendaRecomendado();
                MessageBox.Show($"Percentual alterado para {percentualLucro}%!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AtualizarLabelPercentualLucro()
        {
            lblPercentualLucro.Text = $"Lucro: {percentualLucro}% (+)";
        }

        private int? ObterIdFornecedorSelecionado()
        {
            string nomeFornecedor = cbxFornecedor.Text;

            if (string.IsNullOrEmpty(nomeFornecedor) || nomeFornecedor == "Selecione um fornecedor")
                return null;

            foreach (var fornecedor in fornecedores)
            {
                if (fornecedor.Value == nomeFornecedor)
                    return fornecedor.Key;
            }

            return null;
        }

        private string GetCellValue(DataGridViewRow row, string columnName)
        {
            if (dgvProdutos.Columns.Contains(columnName) &&
                row.Cells[columnName].Value != null &&
                row.Cells[columnName].Value != DBNull.Value)
            {
                return row.Cells[columnName].Value.ToString();
            }
            return "";
        }

        private bool MostrarErro(string mensagem, Control controle = null)
        {
            MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controle?.Focus();
            return false;
        }

        private string ShowInputDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 260 };
            TextBox textBox = new TextBox() { Left = 20, Top = 45, Width = 240 };
            Button confirmation = new Button()
            {
                Text = "OK",
                Left = 120,
                Top = 75,
                Width = 60,
                DialogResult = DialogResult.OK
            };

            confirmation.Click += (s, e) => prompt.Close();
            prompt.Controls.AddRange(new Control[] { textLabel, textBox, confirmation });
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void dgvProdutos_SelectionChanged(object sender, EventArgs e)
        {
            if (modoEdicao && dgvProdutos.SelectedRows.Count > 0)
            {
                try
                {
                    CarregarDadosParaEdicao(dgvProdutos.SelectedRows[0]);
                }
                catch { }
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Não fecha o aplicativo
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblFornecedor_Click(object sender, EventArgs e) { }
    }
}