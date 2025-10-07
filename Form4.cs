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

        public Form4()
        {
            InitializeComponent();

            // CONECTA OS EVENTOS
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            this.btnNovaUnidade.Click += new System.EventHandler(this.btnNovaUnidade_Click);
            this.btnNovaCategoria.Click += new System.EventHandler(this.btnNovaCategoria_Click);
            this.tbxProcurar.TextChanged += new System.EventHandler(this.tbxProcurar_TextChanged);
            this.dgvProdutos.SelectionChanged += new System.EventHandler(this.dgvProdutos_SelectionChanged);

            // EVENTO PARA CALCULAR PREÇO RECOMENDADO
            this.tbxPrecoCompra.TextChanged += new System.EventHandler(this.tbxPrecoCompra_TextChanged);
            this.tbxPrecoVenda.TextChanged += new System.EventHandler(this.tbxPrecoVenda_TextChanged);
            this.tbxQuantidade.TextChanged += new System.EventHandler(this.tbxQuantidade_TextChanged);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            CarregarProdutos();
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // CARREGAR UNIDADES E CATEGORIAS PADRÃO
            CarregarUnidades();
            CarregarCategorias();

            // ESTILO MELHORADO PARA O DATAGRIDVIEW
            dgvProdutos.BackgroundColor = Color.White;
            dgvProdutos.BorderStyle = BorderStyle.None;
            dgvProdutos.EnableHeadersVisualStyles = false;
            dgvProdutos.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvProdutos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProdutos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvProdutos.RowHeadersVisible = false;
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
                // MUDANÇA: Usar int para quantidade
                int quantidade = 1;
                if (int.TryParse(tbxQuantidade.Text, out int qtd) && qtd > 0)
                {
                    quantidade = qtd;
                }

                // CÁLCULOS - TUDO UNITÁRIO
                decimal precoVendaRecomendadoUnitario = precoCompraUnitario * 1.30m; // 30% lucro
                decimal lucroUnitario = precoVendaRecomendadoUnitario - precoCompraUnitario;

                // CÁLCULOS TOTAIS (APENAS PARA INFORMAÇÃO)
                decimal valorTotalEstoque = precoCompraUnitario * quantidade;
                decimal valorTotalVendaRecomendado = precoVendaRecomendadoUnitario * quantidade;
                decimal lucroTotalPotencial = valorTotalVendaRecomendado - valorTotalEstoque;

                // ATUALIZA O CAMPO DE VENDA (UNITÁRIO)
                if (string.IsNullOrEmpty(tbxPrecoVenda.Text) || tbxPrecoVenda.Text == tbxPrecoCompra.Text)
                {
                    tbxPrecoVenda.Text = precoVendaRecomendadoUnitario.ToString("F2");
                }

                // MOSTRA INFORMAÇÕES CLARAS - COM CORES MELHORADAS
                if (quantidade > 1)
                {
                    lblPrecoVendaRecomendado.Text =
                        "Preço Venda Recomendado: R$ " + precoVendaRecomendadoUnitario.ToString("F2") + " (cada unidade)" + Environment.NewLine +
                        "Lucro por unidade: R$ " + lucroUnitario.ToString("F2") + " (+30%)" + Environment.NewLine +
                        "Valor total em estoque: R$ " + valorTotalEstoque.ToString("F2") + Environment.NewLine +
                        "Potencial de venda total: R$ " + valorTotalVendaRecomendado.ToString("F2") + Environment.NewLine +
                        "Lucro total potencial: R$ " + lucroTotalPotencial.ToString("F2");
                }
                else
                {
                    lblPrecoVendaRecomendado.Text =
                        "Preço Venda Recomendado: R$ " + precoVendaRecomendadoUnitario.ToString("F2") + Environment.NewLine +
                        "Lucro: R$ " + lucroUnitario.ToString("F2") + " (+30%)";
                }

                // CORES MELHORADAS PARA MELHOR CONTRASTE
                lblPrecoVendaRecomendado.ForeColor = Color.DarkBlue;
                lblPrecoVendaRecomendado.BackColor = Color.LightYellow;
                lblPrecoVendaRecomendado.BorderStyle = BorderStyle.FixedSingle;
                lblPrecoVendaRecomendado.Padding = new Padding(3);
                lblPrecoVendaRecomendado.AutoSize = false;
                lblPrecoVendaRecomendado.Size = new Size(300, 80);
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
                decimal precoRecomendado = precoCompra * 1.30m;
                int quantidade = 1;

                if (int.TryParse(tbxQuantidade.Text, out int qtd) && qtd > 0)
                {
                    quantidade = qtd;
                }

                if (precoVenda < precoRecomendado * 0.90m) // 10% abaixo do recomendado
                {
                    lblPrecoVendaRecomendado.ForeColor = Color.DarkRed;
                    lblPrecoVendaRecomendado.BackColor = Color.LightCoral;
                    lblPrecoVendaRecomendado.Text += Environment.NewLine + "ATENÇÃO: Preço abaixo do recomendado!";
                }
                else if (precoVenda > precoRecomendado * 1.20m) // 20% acima do recomendado
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

        // BOTÃO PARA ADICIONAR NOVA UNIDADE
        private void btnNovaUnidade_Click(object sender, EventArgs e)
        {
            string novaUnidade = ShowInputDialog("Digite o nome da nova unidade:", "Nova Unidade de Medida");

            if (!string.IsNullOrEmpty(novaUnidade))
            {
                // VERIFICA SE JÁ EXISTE
                if (!cbxUnidade.Items.Contains(novaUnidade))
                {
                    cbxUnidade.Items.Add(novaUnidade);
                    cbxUnidade.Text = novaUnidade;
                    MessageBox.Show("Unidade '" + novaUnidade + "' adicionada com sucesso!",
                                  "Sucesso",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("A unidade '" + novaUnidade + "' já existe!",
                                  "Aviso",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    cbxUnidade.Text = novaUnidade;
                }
            }
        }

        // BOTÃO PARA ADICIONAR NOVA CATEGORIA
        private void btnNovaCategoria_Click(object sender, EventArgs e)
        {
            string novaCategoria = ShowInputDialog("Digite o nome da nova categoria:", "Nova Categoria");

            if (!string.IsNullOrEmpty(novaCategoria))
            {
                // VERIFICA SE JÁ EXISTE
                if (!cbxTipo.Items.Contains(novaCategoria))
                {
                    cbxTipo.Items.Add(novaCategoria);
                    cbxTipo.Text = novaCategoria;
                    MessageBox.Show("Categoria '" + novaCategoria + "' adicionada com sucesso!",
                                  "Sucesso",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("A categoria '" + novaCategoria + "' já existe!",
                                  "Aviso",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Warning);
                    cbxTipo.Text = novaCategoria;
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

        // MÉTODO PARA SALVAR NO BANCO DE DADOS
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

                // VERIFICA SE TEM PREJUÍZO
                if (precoVenda < precoCompra)
                {
                    // MUDANÇA: Usar int para quantidade
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

                // CONVERSÃO DOS DEMAIS VALORES - MUDANÇA: usar int para quantidade
                int.TryParse(tbxQuantidade.Text, out int quantidadeFinal);
                int.TryParse(tbxFornecedor.Text, out int idFornecedor);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query;
                    if (modoEdicao)
                    {
                        // MODO EDIÇÃO - UPDATE
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
                                 Nome_Tipo = @NomeTipo
                                 WHERE Id_Prod = @IdProduto";
                    }
                    else
                    {
                        // MODO NOVO CADASTRO - INSERT
                        query = @"INSERT INTO Produto 
                                 (Nome_Prod, Categoria, Validade, Descricao, 
                                  Preco_Ven, Preco_Cmp, Quantidade_Prod, 
                                  Unidade_Medida_Prod, Id_Fornecedor, Nome_Tipo) 
                                 VALUES 
                                 (@Nome, @Categoria, @Validade, @Descricao, 
                                  @PrecoVenda, @PrecoCompra, @Quantidade, 
                                  @UnidadeMedida, @IdFornecedor, @NomeTipo)";
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
                        command.Parameters.AddWithValue("@IdFornecedor", idFornecedor);
                        command.Parameters.AddWithValue("@NomeTipo", cbxTipo.Text);

                        if (modoEdicao)
                        {
                            command.Parameters.AddWithValue("@IdProduto", produtoIdEmEdicao);
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

        // MÉTODO PARA CARREGAR PRODUTOS DO BANCO
        private void CarregarProdutos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Produto";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // MUDANÇA: Formatar quantidade como inteiro
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Quantidade_Prod"] != DBNull.Value && decimal.TryParse(row["Quantidade_Prod"].ToString(), out decimal quantidade))
                        {
                            row["Quantidade_Prod"] = ((int)quantidade).ToString();
                        }
                    }

                    dgvProdutos.DataSource = null;
                    dgvProdutos.DataSource = dataTable;

                    // RENOMEIA AS COLUNAS PARA PORTUGUÊS
                    if (dgvProdutos.Columns.Count > 0)
                    {
                        if (dgvProdutos.Columns.Contains("Nome_Prod"))
                            dgvProdutos.Columns["Nome_Prod"].HeaderText = "Nome do Produto";
                        if (dgvProdutos.Columns.Contains("Categoria"))
                            dgvProdutos.Columns["Categoria"].HeaderText = "Categoria";
                        if (dgvProdutos.Columns.Contains("Validade"))
                            dgvProdutos.Columns["Validade"].HeaderText = "Validade";
                        if (dgvProdutos.Columns.Contains("Preco_Ven"))
                            dgvProdutos.Columns["Preco_Ven"].HeaderText = "Preço Venda";
                        if (dgvProdutos.Columns.Contains("Preco_Cmp"))
                            dgvProdutos.Columns["Preco_Cmp"].HeaderText = "Preço Compra";
                        if (dgvProdutos.Columns.Contains("Quantidade_Prod"))
                            dgvProdutos.Columns["Quantidade_Prod"].HeaderText = "Quantidade";
                        if (dgvProdutos.Columns.Contains("Unidade_Medida_Prod"))
                            dgvProdutos.Columns["Unidade_Medida_Prod"].HeaderText = "Unidade";
                        if (dgvProdutos.Columns.Contains("Nome_Tipo"))
                            dgvProdutos.Columns["Nome_Tipo"].HeaderText = "Tipo";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODO PARA PROCURAR PRODUTOS
        private void ProcurarProdutos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Produto WHERE Nome_Prod LIKE @Procurar OR Categoria LIKE @Procurar";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@Procurar", "%" + tbxProcurar.Text + "%");

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // MUDANÇA: Formatar quantidade como inteiro na busca também
                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (row["Quantidade_Prod"] != DBNull.Value && decimal.TryParse(row["Quantidade_Prod"].ToString(), out decimal quantidade))
                        {
                            row["Quantidade_Prod"] = ((int)quantidade).ToString();
                        }
                    }

                    dgvProdutos.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao procurar produtos: " + ex.Message, "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // MÉTODO PARA DELETAR PRODUTO
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
                    string idProdutoValue = GetCellValue(row, "Id_Prod");

                    if (string.IsNullOrEmpty(idProdutoValue))
                    {
                        MessageBox.Show("Não foi possível identificar o produto selecionado.", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int idProduto = Convert.ToInt32(idProdutoValue);
                    string nomeProduto = GetCellValue(row, "Nome_Prod") ?? "Produto selecionado";

                    DialogResult result = MessageBox.Show(
                        "DELETAR PRODUTO" + Environment.NewLine + Environment.NewLine +
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

                            string query = "DELETE FROM Produto WHERE Id_Prod = @Id";
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Id", idProduto);
                                int rowsAffected = command.ExecuteNonQuery();

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

        // BOTÃO EDITAR - ATIVA MODO EDIÇÃO
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvProdutos.SelectedRows[0];
                string idProdutoValue = GetCellValue(row, "Id_Prod");

                if (!string.IsNullOrEmpty(idProdutoValue))
                {
                    modoEdicao = true;
                    produtoIdEmEdicao = Convert.ToInt32(idProdutoValue);

                    CarregarDadosParaEdicao(row);
                    AtivarModoEdicao();

                    MessageBox.Show("MODO EDIÇÃO ATIVADO!" + Environment.NewLine + Environment.NewLine +
                                  "Faça as alterações necessárias e clique em SALVAR para confirmar." + Environment.NewLine +
                                  "Use LIMPAR para cancelar a edição.",
                                  "Modo Edição",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
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
            tbxNome.Text = GetCellValue(row, "Nome_Prod");
            cbxTipo.Text = GetCellValue(row, "Categoria");
            cbxUnidade.Text = GetCellValue(row, "Unidade_Medida_Prod");
            tbxPrecoCompra.Text = GetCellValue(row, "Preco_Cmp");
            tbxDescricao.Text = GetCellValue(row, "Descricao");

            // MUDANÇA: Carregar quantidade sem casas decimais
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
            tbxFornecedor.Text = GetCellValue(row, "Id_Fornecedor");

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
            this.BackColor = Color.FromArgb(255, 192, 128);
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (modoEdicao)
            {
                DesativarModoEdicao();
            }

            LimparCampos();
            tbxNome.Focus();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            DeletarProduto();
        }

        private void tbxProcurar_TextChanged(object sender, EventArgs e)
        {
            ProcurarProdutos();
        }

        // EVENTO PARA CALCULAR PREÇO RECOMENDADO
        private void tbxPrecoCompra_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecoVendaRecomendado();
        }

        // EVENTO PARA VERIFICAR DIFERENÇA QUANDO O USUÁRIO DIGITA O PREÇO DE VENDA
        private void tbxPrecoVenda_TextChanged(object sender, EventArgs e)
        {
            VerificarDiferencaPreco();
        }

        // EVENTO PARA RECALCULAR QUANDO A QUANTIDADE MUDAR
        private void tbxQuantidade_TextChanged(object sender, EventArgs e)
        {
            CalcularPrecoVendaRecomendado();
        }

        // MÉTODO PARA PREENCHER CAMPOS (QUANDO SELECIONA NA GRADE)
        private void dgvProdutos_SelectionChanged(object sender, EventArgs e)
        {
            if (!modoEdicao && dgvProdutos.SelectedRows.Count > 0 && dgvProdutos.DataSource != null)
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

        // MÉTODO AUXILIAR PARA OBTER VALORES DE CÉLULAS COM SEGURANÇA
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
            tbxFornecedor.Clear();
            dtpValidade.Value = DateTime.Now;
            lblPrecoVendaRecomendado.Text = "";
            lblPrecoVendaRecomendado.Visible = false;
            lblPrecoVendaRecomendado.BackColor = this.BackColor;
            lblPrecoVendaRecomendado.Size = new Size(300, 13);
            lblPrecoVendaRecomendado.AutoSize = true;
            lblPrecoVenda.Text = "Preço Venda:";
        }
    }
}