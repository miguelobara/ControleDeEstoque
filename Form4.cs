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
        // USA A MESMA STRING DE CONEXÃO QUE FUNCIONA PARA VOCÊ
        private string connectionString = "Data Source=SQLEXPRESS;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

        // VARIÁVEIS PARA CONTROLE DE EDIÇÃO
        private bool modoEdicao = false;
        private int produtoIdEmEdicao = 0;

        // VARIÁVEL PARA CONTROLE DO PERCENTUAL DE LUCRO
        private decimal percentualLucro = 30m; // Valor padrão 30%

        // DICIONÁRIO PARA ARMAZENAR FORNECEDORES (ID -> NOME)
        private Dictionary<int, string> fornecedores = new Dictionary<int, string>();

        public Form4()
        {
            InitializeComponent();

            // CONECTA OS EVENTOS CORRETAMENTE
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnNovaUnidade.Click += new System.EventHandler(this.btnNovaUnidade_Click);
            this.btnNovaCategoria.Click += new System.EventHandler(this.btnNovaCategoria_Click);
            this.btnNovoFornecedor.Click += new System.EventHandler(this.btnNovoFornecedor_Click);
            this.btnMudarLucro.Click += new System.EventHandler(this.btnMudarLucro_Click);
            this.tbxProcurar.TextChanged += new System.EventHandler(this.tbxProcurar_TextChanged);
            this.chkBuscarNome.CheckedChanged += new System.EventHandler(this.chkBuscarNome_CheckedChanged);
            this.chkBuscarCategoria.CheckedChanged += new System.EventHandler(this.chkBuscarCategoria_CheckedChanged);
            this.chkBuscarFornecedor.CheckedChanged += new System.EventHandler(this.chkBuscarFornecedor_CheckedChanged);
            this.chkBuscarDescricao.CheckedChanged += new System.EventHandler(this.chkBuscarDescricao_CheckedChanged);
            this.dgvProdutos.SelectionChanged += new System.EventHandler(this.dgvProdutos_SelectionChanged);

            // EVENTO PARA CALCULAR PREÇO RECOMENDADO
            this.tbxPrecoCompra.TextChanged += new System.EventHandler(this.tbxPrecoCompra_TextChanged);
            this.tbxPrecoVenda.TextChanged += new System.EventHandler(this.tbxPrecoVenda_TextChanged);
            this.tbxQuantidade.TextChanged += new System.EventHandler(this.tbxQuantidade_TextChanged);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            CarregarConfiguracoesJuros(); // CARREGA JUROS DO BANCO
            CarregarProdutos();
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // CARREGAR UNIDADES, CATEGORIAS E FORNECEDORES
            CarregarUnidades();
            CarregarCategorias();
            CarregarFornecedores();

            // ATUALIZAR LABEL DO PERCENTUAL DE LUCRO
            AtualizarLabelPercentualLucro();

            // ESTILO MELHORADO PARA O DATAGRIDVIEW
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.BorderStyle = BorderStyle.None;
            dgvProdutos.EnableHeadersVisualStyles = false;
            dgvProdutos.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvProdutos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProdutos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvProdutos.RowHeadersVisible = false;
        }

        // MÉTODO CORRIGIDO PARA CARREGAR FORNECEDORES DO BANCO - USANDO SUA TABELA
        private void CarregarFornecedores()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // CORREÇÃO: Nome da coluna correto - Id_Fornecedor
                    string query = "SELECT Id_Fornecedor, Nome_For FROM Fornecedor ORDER BY Nome_For";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            fornecedores.Clear();
                            cbxFornecedor.Items.Clear();

                            // Adiciona opção vazia
                            cbxFornecedor.Items.Add("Selecione um fornecedor");

                            while (reader.Read())
                            {
                                int idFornecedor = reader.GetInt32(0);
                                string nomeFornecedor = reader.GetString(1);
                                fornecedores.Add(idFornecedor, nomeFornecedor);
                                cbxFornecedor.Items.Add(nomeFornecedor);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar fornecedores: " + ex.Message, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODO PARA OBTER ID DO FORNECEDOR POR NOME
        private int? ObterIdFornecedorPorNome(string nomeFornecedor)
        {
            if (string.IsNullOrEmpty(nomeFornecedor) || nomeFornecedor == "Selecione um fornecedor")
                return null;

            foreach (var fornecedor in fornecedores)
            {
                if (fornecedor.Value == nomeFornecedor)
                    return fornecedor.Key;
            }
            return null;
        }

        // MÉTODO PARA OBTER NOME DO FORNECEDOR POR ID
        private string ObterNomeFornecedorPorId(int? idFornecedor)
        {
            if (!idFornecedor.HasValue) return "";

            if (fornecedores.ContainsKey(idFornecedor.Value))
                return fornecedores[idFornecedor.Value];

            return "";
        }

        // CARREGAR CONFIGURAÇÕES DE JUROS DO BANCO - CORRIGIDO
        private void CarregarConfiguracoesJuros()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // CORREÇÃO: Usando Id_Prod (nome correto da coluna)
                    string query = "SELECT TOP 1 juros FROM Produto WHERE juros IS NOT NULL AND juros > 0 ORDER BY Id_Prod DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            percentualLucro = Convert.ToDecimal(result);
                        }
                        else
                        {
                            percentualLucro = 30m;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar configurações de juros: " + ex.Message, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                percentualLucro = 30m;
            }
        }

        // SALVAR PERCENTUAL DE LUCRO NO BANCO
        private bool SalvarPercentualLucroNoBanco(decimal novoPercentual)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Produto SET juros = @Juros WHERE juros IS NOT NULL";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Juros", novoPercentual);
                        int result = command.ExecuteNonQuery();

                        if (result == 0)
                        {
                            query = "UPDATE TOP (1) Produto SET juros = @Juros";
                            command.CommandText = query;
                            command.ExecuteNonQuery();
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar percentual de lucro: " + ex.Message, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // MÉTODO PARA ADICIONAR NOVA UNIDADE
        private void btnNovaUnidade_Click(object sender, EventArgs e)
        {
            string novaUnidade = ShowInputDialog("Digite o nome da nova unidade de medida:", "Nova Unidade");

            if (!string.IsNullOrEmpty(novaUnidade))
            {
                cbxUnidade.Items.Add(novaUnidade);
                cbxUnidade.Text = novaUnidade;
                MessageBox.Show($"Unidade '{novaUnidade}' adicionada com sucesso!", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // MÉTODO PARA ADICIONAR NOVA CATEGORIA
        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            string novaCategoria = ShowInputDialog("Digite o nome da nova categoria:", "Nova Categoria");

            if (!string.IsNullOrEmpty(novaCategoria))
            {
                cbxTipo.Items.Add(novaCategoria);
                cbxTipo.Text = novaCategoria;
                MessageBox.Show($"Categoria '{novaCategoria}' adicionada com sucesso!", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // MÉTODO PARA ATUALIZAR A LISTA DE FORNECEDORES
        private void btnNovoFornecedor_Click(object sender, EventArgs e)
        {
            CarregarFornecedores();
            MessageBox.Show("Lista de fornecedores atualizada!", "Atualização",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // MÉTODO: BOTÃO PARA MUDAR PERCENTUAL DE LUCRO
        private void btnMudarLucro_Click(object sender, EventArgs e)
        {
            string novoPercentual = ShowInputDialog($"Percentual de lucro atual: {percentualLucro}%\n\nDigite o novo percentual:", "Alterar Percentual de Lucro");

            if (!string.IsNullOrEmpty(novoPercentual))
            {
                if (decimal.TryParse(novoPercentual, out decimal novoPercentualValue) && novoPercentualValue > 0)
                {
                    if (SalvarPercentualLucroNoBanco(novoPercentualValue))
                    {
                        percentualLucro = novoPercentualValue;
                        AtualizarLabelPercentualLucro();
                        CalcularPrecoVendaRecomendado();

                        MessageBox.Show($"Percentual de lucro alterado para {percentualLucro}%!", "Sucesso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, digite um percentual válido (ex: 25, 30, 40).", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // NOVO MÉTODO: BUSCA INTELIGENTE COM CHECKBOXES
        private void ProcurarProdutosInteligente()
        {
            string textoBusca = tbxProcurar.Text.Trim();

            if (string.IsNullOrEmpty(textoBusca))
            {
                CarregarProdutos();
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT p.Id_Prod, p.Nome_Prod, p.Categoria, p.Validade, p.Descricao, 
                                    p.Preco_Ven, p.Preco_Cmp, p.Quantidade_Prod, 
                                    p.Unidade_Medida_Prod, f.Nome_For as Fornecedor, p.juros
                                    FROM Produto p
                                    LEFT JOIN Fornecedor f ON p.Id_Fornecedor = f.Id_Fornecedor
                                    WHERE ";

                    List<string> conditions = new List<string>();
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    if (chkBuscarNome.Checked)
                    {
                        conditions.Add("p.Nome_Prod LIKE @Nome");
                        parameters.Add(new SqlParameter("@Nome", "%" + textoBusca + "%"));
                    }

                    if (chkBuscarCategoria.Checked)
                    {
                        conditions.Add("p.Categoria LIKE @Categoria");
                        parameters.Add(new SqlParameter("@Categoria", "%" + textoBusca + "%"));
                    }

                    if (chkBuscarFornecedor.Checked)
                    {
                        conditions.Add("f.Nome_For LIKE @Fornecedor");
                        parameters.Add(new SqlParameter("@Fornecedor", "%" + textoBusca + "%"));
                    }

                    if (chkBuscarDescricao.Checked)
                    {
                        conditions.Add("p.Descricao LIKE @Descricao");
                        parameters.Add(new SqlParameter("@Descricao", "%" + textoBusca + "%"));
                    }

                    if (conditions.Count == 0)
                    {
                        conditions.Add("p.Nome_Prod LIKE @Nome");
                        parameters.Add(new SqlParameter("@Nome", "%" + textoBusca + "%"));
                    }

                    query += string.Join(" OR ", conditions);

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    foreach (var param in parameters)
                    {
                        adapter.SelectCommand.Parameters.Add(param);
                    }

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Quantidade_Prod"] != DBNull.Value && decimal.TryParse(row["Quantidade_Prod"].ToString(), out decimal quantidade))
                        {
                            row["Quantidade_Prod"] = ((int)quantidade).ToString();
                        }
                    }

                    dgvProdutos.DataSource = dataTable;
                    AplicarConfiguracoesColunas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao procurar produtos: " + ex.Message, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODO AUXILIAR PARA APLICAR CONFIGURAÇÕES DAS COLUNAS
        private void AplicarConfiguracoesColunas()
        {
            if (dgvProdutos.Columns.Count > 0)
            {
                if (dgvProdutos.Columns.Contains("Id_Prod"))
                    dgvProdutos.Columns["Id_Prod"].HeaderText = "ID";
                if (dgvProdutos.Columns.Contains("Nome_Prod"))
                    dgvProdutos.Columns["Nome_Prod"].HeaderText = "Nome do Produto";
                if (dgvProdutos.Columns.Contains("Categoria"))
                    dgvProdutos.Columns["Categoria"].HeaderText = "Categoria";
                if (dgvProdutos.Columns.Contains("Validade"))
                    dgvProdutos.Columns["Validade"].HeaderText = "Validade";
                if (dgvProdutos.Columns.Contains("Descricao"))
                    dgvProdutos.Columns["Descricao"].HeaderText = "Descrição";
                if (dgvProdutos.Columns.Contains("Preco_Ven"))
                    dgvProdutos.Columns["Preco_Ven"].HeaderText = "Preço Venda";
                if (dgvProdutos.Columns.Contains("Preco_Cmp"))
                    dgvProdutos.Columns["Preco_Cmp"].HeaderText = "Preço Compra";
                if (dgvProdutos.Columns.Contains("Quantidade_Prod"))
                    dgvProdutos.Columns["Quantidade_Prod"].HeaderText = "Quantidade";
                if (dgvProdutos.Columns.Contains("Unidade_Medida_Prod"))
                    dgvProdutos.Columns["Unidade_Medida_Prod"].HeaderText = "Unidade";
                if (dgvProdutos.Columns.Contains("Fornecedor"))
                    dgvProdutos.Columns["Fornecedor"].HeaderText = "Fornecedor";
                if (dgvProdutos.Columns.Contains("juros"))
                    dgvProdutos.Columns["juros"].HeaderText = "Juros %";
            }
        }

        // EVENTOS DOS CHECKBOXES
        private void chkBuscarNome_CheckedChanged(object sender, EventArgs e)
        {
            ProcurarProdutosInteligente();
        }

        private void chkBuscarCategoria_CheckedChanged(object sender, EventArgs e)
        {
            ProcurarProdutosInteligente();
        }

        private void chkBuscarFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            ProcurarProdutosInteligente();
        }

        private void chkBuscarDescricao_CheckedChanged(object sender, EventArgs e)
        {
            ProcurarProdutosInteligente();
        }

        // MÉTODO ATUALIZADO: PROCURAR PRODUTOS
        private void tbxProcurar_TextChanged(object sender, EventArgs e)
        {
            ProcurarProdutosInteligente();
        }

        // MÉTODO: CARREGAR TODOS OS PRODUTOS
        private void CarregarProdutos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT p.Id_Prod, p.Nome_Prod, p.Categoria, p.Validade, p.Descricao, 
                                    p.Preco_Ven, p.Preco_Cmp, p.Quantidade_Prod, 
                                    p.Unidade_Medida_Prod, f.Nome_For as Fornecedor, p.juros
                                    FROM Produto p
                                    LEFT JOIN Fornecedor f ON p.Id_Fornecedor = f.Id_Fornecedor";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Quantidade_Prod"] != DBNull.Value && decimal.TryParse(row["Quantidade_Prod"].ToString(), out decimal quantidade))
                        {
                            row["Quantidade_Prod"] = ((int)quantidade).ToString();
                        }
                    }

                    dgvProdutos.DataSource = null;
                    dgvProdutos.DataSource = dataTable;

                    if (dgvProdutos.Columns.Count > 0)
                    {
                        if (dgvProdutos.Columns.Contains("Id_Prod"))
                        {
                            dgvProdutos.Columns["Id_Prod"].HeaderText = "ID";
                            dgvProdutos.Columns["Id_Prod"].Width = 50;
                        }

                        if (dgvProdutos.Columns.Contains("Nome_Prod"))
                        {
                            dgvProdutos.Columns["Nome_Prod"].HeaderText = "Nome do Produto";
                            dgvProdutos.Columns["Nome_Prod"].Width = 150;
                        }

                        if (dgvProdutos.Columns.Contains("Categoria"))
                        {
                            dgvProdutos.Columns["Categoria"].HeaderText = "Categoria";
                            dgvProdutos.Columns["Categoria"].Width = 100;
                        }

                        if (dgvProdutos.Columns.Contains("Validade"))
                        {
                            dgvProdutos.Columns["Validade"].HeaderText = "Validade";
                            dgvProdutos.Columns["Validade"].Width = 80;
                        }

                        if (dgvProdutos.Columns.Contains("Descricao"))
                        {
                            dgvProdutos.Columns["Descricao"].HeaderText = "Descrição";
                            dgvProdutos.Columns["Descricao"].Width = 200;
                        }

                        if (dgvProdutos.Columns.Contains("Preco_Ven"))
                        {
                            dgvProdutos.Columns["Preco_Ven"].HeaderText = "Preço Venda";
                            dgvProdutos.Columns["Preco_Ven"].Width = 90;
                        }

                        if (dgvProdutos.Columns.Contains("Preco_Cmp"))
                        {
                            dgvProdutos.Columns["Preco_Cmp"].HeaderText = "Preço Compra";
                            dgvProdutos.Columns["Preco_Cmp"].Width = 90;
                        }

                        if (dgvProdutos.Columns.Contains("Quantidade_Prod"))
                        {
                            dgvProdutos.Columns["Quantidade_Prod"].HeaderText = "Quantidade";
                            dgvProdutos.Columns["Quantidade_Prod"].Width = 80;
                        }

                        if (dgvProdutos.Columns.Contains("Unidade_Medida_Prod"))
                        {
                            dgvProdutos.Columns["Unidade_Medida_Prod"].HeaderText = "Unidade";
                            dgvProdutos.Columns["Unidade_Medida_Prod"].Width = 80;
                        }

                        if (dgvProdutos.Columns.Contains("Fornecedor"))
                        {
                            dgvProdutos.Columns["Fornecedor"].HeaderText = "Fornecedor";
                            dgvProdutos.Columns["Fornecedor"].Width = 120;
                        }

                        if (dgvProdutos.Columns.Contains("juros"))
                        {
                            dgvProdutos.Columns["juros"].HeaderText = "Juros %";
                            dgvProdutos.Columns["juros"].Width = 60;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODO: ATUALIZAR LABEL DO PERCENTUAL DE LUCRO
        private void AtualizarLabelPercentualLucro()
        {
            lblPercentualLucro.Text = $"Lucro: {percentualLucro}% (+)";
        }

        // CARREGAR UNIDADES PADRÃO
        private void CarregarUnidades()
        {
            cbxUnidade.Items.Clear();
            cbxUnidade.Items.AddRange(new object[] {
                "Kg", "g", "L", "ml", "Unidade", "Caixa", "Pacote", "Fardo"
            });
        }

        // CARREGAR CATEGORIAS PADRÃO
        private void CarregarCategorias()
        {
            cbxTipo.Items.Clear();
            cbxTipo.Items.AddRange(new object[] {
                "Limpeza", "Bebida", "Comida", "Higiene", "Bazar", "Outros"
            });
        }

        // MÉTODO PARA CALCULAR PREÇO DE VENDA RECOMENDADO
        private void CalcularPrecoVendaRecomendado()
        {
            if (decimal.TryParse(tbxPrecoCompra.Text, out decimal precoCompraUnitario) && precoCompraUnitario > 0)
            {
                int quantidade = 1;
                if (int.TryParse(tbxQuantidade.Text, out int qtd) && qtd > 0)
                {
                    quantidade = qtd;
                }

                decimal fatorLucro = 1 + (percentualLucro / 100m);
                decimal precoVendaRecomendadoUnitario = precoCompraUnitario * fatorLucro;
                decimal lucroUnitario = precoVendaRecomendadoUnitario - precoCompraUnitario;

                decimal valorTotalEstoque = precoCompraUnitario * quantidade;
                decimal valorTotalVendaRecomendado = precoVendaRecomendadoUnitario * quantidade;
                decimal lucroTotalPotencial = valorTotalVendaRecomendado - valorTotalEstoque;

                tbxPrecoVenda.Text = precoVendaRecomendadoUnitario.ToString("F2");

                if (quantidade > 1)
                {
                    lblPrecoVendaRecomendado.Text =
                        $"Preço Venda Recomendado: R$ {precoVendaRecomendadoUnitario:F2} (cada unidade)" + Environment.NewLine +
                        $"Lucro por unidade: R$ {lucroUnitario:F2} (+{percentualLucro}%)" + Environment.NewLine +
                        $"Valor total em estoque: R$ {valorTotalEstoque:F2}" + Environment.NewLine +
                        $"Potencial de venda total: R$ {valorTotalVendaRecomendado:F2}" + Environment.NewLine +
                        $"Lucro total potencial: R$ {lucroTotalPotencial:F2}";
                }
                else
                {
                    lblPrecoVendaRecomendado.Text =
                        $"Preço Venda Recomendado: R$ {precoVendaRecomendadoUnitario:F2}" + Environment.NewLine +
                        $"Lucro: R$ {lucroUnitario:F2} (+{percentualLucro}%)";
                }

                lblPrecoVendaRecomendado.ForeColor = Color.DarkBlue;
                lblPrecoVendaRecomendado.BackColor = Color.LightYellow;
                lblPrecoVendaRecomendado.BorderStyle = BorderStyle.FixedSingle;
                lblPrecoVendaRecomendado.Padding = new Padding(3);
                lblPrecoVendaRecomendado.AutoSize = false;
                lblPrecoVendaRecomendado.Size = new Size(300, 120);
                lblPrecoVendaRecomendado.Visible = true;
                VerificarDiferencaPreco();
            }
            else
            {
                lblPrecoVendaRecomendado.Text = "";
                lblPrecoVendaRecomendado.Visible = false;
                lblPrecoVendaRecomendado.BackColor = this.BackColor;
            }
        }

        // VERIFICA SE O PREÇO DIGITADO É DIFERENTE DO RECOMENDADO
        private void VerificarDiferencaPreco()
        {
            if (decimal.TryParse(tbxPrecoCompra.Text, out decimal precoCompra) &&
                decimal.TryParse(tbxPrecoVenda.Text, out decimal precoVenda))
            {
                decimal fatorLucro = 1 + (percentualLucro / 100m);
                decimal precoRecomendado = precoCompra * fatorLucro;
                int quantidade = 1;

                if (int.TryParse(tbxQuantidade.Text, out int qtd) && qtd > 0)
                {
                    quantidade = qtd;
                }

                if (precoVenda < precoRecomendado * 0.90m)
                {
                    lblPrecoVendaRecomendado.ForeColor = Color.DarkRed;
                    lblPrecoVendaRecomendado.BackColor = Color.LightCoral;
                    lblPrecoVendaRecomendado.Text += Environment.NewLine + "ATENÇÃO: Preço abaixo do recomendado!";
                }
                else if (precoVenda > precoRecomendado * 1.20m)
                {
                    lblPrecoVendaRecomendado.ForeColor = Color.Purple;
                    lblPrecoVendaRecomendado.BackColor = Color.Lavender;
                    lblPrecoVendaRecomendado.Text += Environment.NewLine + "Preço acima do recomendado";
                }
                else if (precoVenda >= precoRecomendado * 0.90m && precoVenda <= precoRecomendado * 1.20m)
                {
                    lblPrecoVendaRecomendado.ForeColor = Color.DarkGreen;
                    lblPrecoVendaRecomendado.BackColor = Color.LightGreen;
                }
            }
        }

        // MÉTODO AUXILIAR PARA INPUT BOX
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
            Button confirmation = new Button() { Text = "OK", Left = 120, Top = 75, Width = 60, DialogResult = DialogResult.OK };

            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        // MÉTODO PARA GERAR PRÓXIMO ID DISPONÍVEL
        private int GerarProximoId()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ISNULL(MAX(Id_Prod), 0) + 1 FROM Produto";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gerar próximo ID: " + ex.Message, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1; // Retorna 1 se houver erro
            }
        }

        // MÉTODO PARA SALVAR NO BANCO DE DADOS - CORRIGIDO COM GERAÇÃO DE ID
        private void SalvarProduto()
        {
            try
            {
                // VALIDAÇÕES
                if (string.IsNullOrEmpty(tbxNome.Text))
                {
                    MessageBox.Show("Por favor, informe o nome do produto.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxNome.Focus();
                    return;
                }

                if (!decimal.TryParse(tbxPrecoCompra.Text, out decimal precoCompra) || precoCompra <= 0)
                {
                    MessageBox.Show("Por favor, informe um preço de compra válido.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxPrecoCompra.Focus();
                    return;
                }

                if (!decimal.TryParse(tbxPrecoVenda.Text, out decimal precoVenda) || precoVenda <= 0)
                {
                    MessageBox.Show("Por favor, informe um preço de venda válido.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxPrecoVenda.Focus();
                    return;
                }

                // VALIDAÇÃO DO FORNECEDOR
                int? idFornecedor = null;
                if (!string.IsNullOrEmpty(cbxFornecedor.Text) && cbxFornecedor.Text != "Selecione um fornecedor")
                {
                    idFornecedor = ObterIdFornecedorPorNome(cbxFornecedor.Text);

                    if (!idFornecedor.HasValue)
                    {
                        MessageBox.Show("Fornecedor selecionado não encontrado no banco de dados.\n\nPor favor, selecione um fornecedor válido da lista.", "Fornecedor Não Encontrado",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbxFornecedor.Focus();
                        return;
                    }
                }

                // VERIFICA SE TEM PREJUÍZO
                if (precoVenda < precoCompra)
                {
                    int quantidade = 1;
                    int.TryParse(tbxQuantidade.Text, out quantidade);

                    decimal prejuizoUnitario = precoCompra - precoVenda;
                    decimal prejuizoTotal = prejuizoUnitario * quantidade;

                    string mensagemPrejuizo =
                        "ATENÇÃO: PREJUÍZO DETECTADO!" + Environment.NewLine + Environment.NewLine +
                        "Por unidade:" + Environment.NewLine +
                        "   • Preço Compra: R$ " + precoCompra.ToString("F2") + Environment.NewLine +
                        "   • Preço Venda: R$ " + precoVenda.ToString("F2") + Environment.NewLine +
                        "   • Prejuízo: R$ " + prejuizoUnitario.ToString("F2") + Environment.NewLine + Environment.NewLine;

                    if (quantidade > 1)
                    {
                        mensagemPrejuizo +=
                            "No total (" + quantidade.ToString() + " unidades):" + Environment.NewLine +
                            "   • Prejuízo Total: R$ " + prejuizoTotal.ToString("F2") + Environment.NewLine + Environment.NewLine;
                    }

                    mensagemPrejuizo += "Deseja continuar mesmo assim?";

                    DialogResult result = MessageBox.Show(
                        mensagemPrejuizo,
                        "ALERTA - PREJUÍZO",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.No)
                    {
                        tbxPrecoVenda.Focus();
                        return;
                    }
                }

                // CONVERSÃO DOS DEMAIS VALORES
                int.TryParse(tbxQuantidade.Text, out int quantidadeFinal);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // GERA PRÓXIMO ID SE FOR NOVO PRODUTO
                    int proximoId = 0;
                    if (!modoEdicao)
                    {
                        proximoId = GerarProximoId();
                    }

                    string query;
                    if (modoEdicao)
                    {
                        query = @"UPDATE Produto SET 
                                 Nome_Prod = @Nome, 
                                 Categoria = @Categoria, 
                                 Validade = @Validade, 
                                 Descricao = @Descricao, 
                                 Preco_Ven = @PrecoVenda, 
                                 Preco_Cmp = @PrecoCompra, 
                                 Quantidade_Prod = @Quantidade, 
                                 Unidade_Medida_Prod = @UnidadeMedida, 
                                 Id_Fornecedor = @IdFornecedor,
                                 juros = @Juros
                                 WHERE Id_Prod = @IdProduto";
                    }
                    else
                    {
                        query = @"INSERT INTO Produto 
                                 (Id_Prod, Nome_Prod, Categoria, Validade, Descricao, 
                                  Preco_Ven, Preco_Cmp, Quantidade_Prod, 
                                  Unidade_Medida_Prod, Id_Fornecedor, juros) 
                                 VALUES 
                                 (@IdProd, @Nome, @Categoria, @Validade, @Descricao, 
                                  @PrecoVenda, @PrecoCompra, @Quantidade, 
                                  @UnidadeMedida, @IdFornecedor, @Juros)";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nome", tbxNome.Text);
                        command.Parameters.AddWithValue("@Categoria", cbxTipo.Text);
                        command.Parameters.AddWithValue("@Validade", dtpValidade.Value);
                        command.Parameters.AddWithValue("@Descricao", tbxDescricao.Text ?? "");
                        command.Parameters.AddWithValue("@PrecoVenda", precoVenda);
                        command.Parameters.AddWithValue("@PrecoCompra", precoCompra);
                        command.Parameters.AddWithValue("@Quantidade", quantidadeFinal);
                        command.Parameters.AddWithValue("@UnidadeMedida", cbxUnidade.Text);

                        if (idFornecedor.HasValue)
                            command.Parameters.AddWithValue("@IdFornecedor", idFornecedor.Value);
                        else
                            command.Parameters.AddWithValue("@IdFornecedor", DBNull.Value);

                        command.Parameters.AddWithValue("@Juros", percentualLucro);

                        if (modoEdicao)
                        {
                            command.Parameters.AddWithValue("@IdProduto", produtoIdEmEdicao);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@IdProd", proximoId);
                        }

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            string mensagem = modoEdicao ? "editado" : "salvo";

                            MessageBox.Show("Produto " + mensagem + " com sucesso!", "Sucesso",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (modoEdicao)
                            {
                                DesativarModoEdicao();
                            }

                            LimparCampos();
                            CarregarProdutos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar produto: " + ex.Message, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODO PARA DELETAR PRODUTO - CORRIGIDO
        private void DeletarProduto()
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                try
                {
                    if (dgvProdutos.DataSource == null)
                    {
                        MessageBox.Show("Nenhum dado carregado para deletar.", "Aviso",
                                      MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    DataGridViewRow row = dgvProdutos.SelectedRows[0];
                    string nomeProduto = GetCellValue(row, "Nome_Prod") ?? "Produto selecionado";
                    string idProduto = GetCellValue(row, "Id_Prod") ?? "";

                    DialogResult result = MessageBox.Show(
                        "DELETAR PRODUTO" + Environment.NewLine + Environment.NewLine +
                        "ID: " + idProduto + Environment.NewLine +
                        "Nome: " + nomeProduto + Environment.NewLine + Environment.NewLine +
                        "Tem certeza que deseja deletar este produto?",
                        "Confirmar Deleção",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // CORREÇÃO: Usando Id_Prod (nome correto da coluna)
                            string queryDelete = "DELETE FROM Produto WHERE Id_Prod = @Id";
                            using (SqlCommand commandDelete = new SqlCommand(queryDelete, connection))
                            {
                                commandDelete.Parameters.AddWithValue("@Id", Convert.ToInt32(idProduto));
                                int rowsAffected = commandDelete.ExecuteNonQuery();

                                if (rowsAffected > 0)
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
                    MessageBox.Show("Erro ao deletar produto: " + ex.Message, "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um produto para deletar.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BOTÃO EDITAR - ATIVA MODO EDIÇÃO - CORRIGIDO
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvProdutos.SelectedRows[0];
                string idProduto = GetCellValue(row, "Id_Prod");

                if (!string.IsNullOrEmpty(idProduto))
                {
                    try
                    {
                        modoEdicao = true;
                        produtoIdEmEdicao = Convert.ToInt32(idProduto);

                        CarregarDadosParaEdicao(row);
                        AtivarModoEdicao();

                        MessageBox.Show("MODO EDIÇÃO ATIVADO!" + Environment.NewLine + Environment.NewLine +
                                      "ID do Produto: " + idProduto + Environment.NewLine +
                                      "Faça as alterações necessárias e clique em SALVAR para confirmar." + Environment.NewLine +
                                      "Use LIMPAR para cancelar a edição.",
                                      "Modo Edição",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao ativar modo edição: " + ex.Message, "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível identificar o produto selecionado.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um produto para editar.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Método para carregar dados para edição
        private void CarregarDadosParaEdicao(DataGridViewRow row)
        {
            if (!modoEdicao)
            {
                return;
            }

            tbxNome.Text = GetCellValue(row, "Nome_Prod");
            cbxTipo.Text = GetCellValue(row, "Categoria");
            cbxUnidade.Text = GetCellValue(row, "Unidade_Medida_Prod");
            tbxPrecoCompra.Text = GetCellValue(row, "Preco_Cmp");
            tbxDescricao.Text = GetCellValue(row, "Descricao");

            string quantidadeValue = GetCellValue(row, "Quantidade_Prod");
            if (decimal.TryParse(quantidadeValue, out decimal quantidadeDecimal))
            {
                tbxQuantidade.Text = ((int)quantidadeDecimal).ToString();
            }
            else
            {
                tbxQuantidade.Text = quantidadeValue;
            }

            tbxPrecoVenda.Text = GetCellValue(row, "Preco_Ven");

            // Carrega o nome do fornecedor em vez do ID
            string nomeFornecedor = GetCellValue(row, "Fornecedor");
            if (!string.IsNullOrEmpty(nomeFornecedor))
            {
                cbxFornecedor.Text = nomeFornecedor;
            }
            else
            {
                cbxFornecedor.SelectedIndex = 0; // "Selecione um fornecedor"
            }

            string jurosValue = GetCellValue(row, "juros");
            if (!string.IsNullOrEmpty(jurosValue) && decimal.TryParse(jurosValue, out decimal jurosProduto))
            {
                percentualLucro = jurosProduto;
                AtualizarLabelPercentualLucro();
            }

            string validadeValue = GetCellValue(row, "Validade");
            if (!string.IsNullOrEmpty(validadeValue) && DateTime.TryParse(validadeValue, out DateTime validade))
            {
                dtpValidade.Value = validade;
            }

            CalcularPrecoVendaRecomendado();
        }

        // Ativar visual do modo edição
        private void AtivarModoEdicao()
        {
            this.BackColor = Color.FromArgb(255, 255, 225);
            btnSalvar.Text = "Salvar Edição";
            btnEditar.Enabled = false;
            this.Text = "Cadastro de Produtos - [EDITANDO]";
        }

        // Desativar modo edição
        private void DesativarModoEdicao()
        {
            modoEdicao = false;
            produtoIdEmEdicao = 0;
            this.BackColor = Color.Silver;
            btnSalvar.Text = "Salvar";
            btnEditar.Enabled = true;
            this.Text = "Cadastro de Produtos";
        }

        // EVENT HANDLERS
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarProduto();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            if (modoEdicao)
            {
                DesativarModoEdicao();
                MessageBox.Show("Edição cancelada.", "Informação",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DeletarProduto();
        }

        // EVENTO PARA CALCULAR PREÇO RECOMENDADO
        private void tbxPrecoCompra_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecoVendaRecomendado();
        }

        private void tbxPrecoVenda_TextChanged(object sender, EventArgs e)
        {
            VerificarDiferencaPreco();
        }

        private void tbxQuantidade_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecoVendaRecomendado();
        }

        // MÉTODO PARA PREENCHER CAMPOS (QUANDO SELECIONA NA GRADE)
        private void dgvProdutos_SelectionChanged(object sender, EventArgs e)
        {
            if (modoEdicao && dgvProdutos.SelectedRows.Count > 0 && dgvProdutos.DataSource != null)
            {
                try
                {
                    DataGridViewRow row = dgvProdutos.SelectedRows[0];
                    CarregarDadosParaEdicao(row);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        // MÉTODO AUXILIAR PARA OBTER VALORES DE CÉLULAS
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

        private void LimparCampos()
        {
            tbxProcurar.Clear();
            tbxNome.Clear();
            cbxTipo.SelectedIndex = -1;
            cbxUnidade.SelectedIndex = -1;
            tbxPrecoCompra.Clear();
            tbxDescricao.Clear();
            tbxQuantidade.Clear();
            tbxPrecoVenda.Clear();
            cbxFornecedor.SelectedIndex = 0; // Volta para "Selecione um fornecedor"
            dtpValidade.Value = DateTime.Now;
            lblPrecoVendaRecomendado.Text = "";
            lblPrecoVendaRecomendado.Visible = false;
            lblPrecoVendaRecomendado.BackColor = this.BackColor;
            lblPrecoVendaRecomendado.Size = new Size(300, 120);
            lblPrecoVendaRecomendado.AutoSize = true;

            // Reseta os checkboxes de busca (nome marcado por padrão)
            chkBuscarNome.Checked = true;
            chkBuscarCategoria.Checked = false;
            chkBuscarFornecedor.Checked = false;
            chkBuscarDescricao.Checked = false;
        }

        private void lblFornecedor_Click(object sender, EventArgs e)
        {
            // Método vazio necessário para o evento
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Form2 product = new Form2();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }
    }
}