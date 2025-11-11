using System;
using System.Data;
using System.Windows.Forms;
using ControleDeEstoque.Data.Repositories;
using ControleDeEstoque.Models;

namespace ControleDeEstoque
{
    public partial class Form9 : Form
    {
        private readonly VendaRepository _vendaRepository;
        private readonly ProdutoRepository _produtoRepository;
        private DataTable _produtosDisponiveis;

        public Form9()
        {
            InitializeComponent();
            _vendaRepository = new VendaRepository();
            _produtoRepository = new ProdutoRepository();

            // Configurações iniciais
            dtpFiltroInicio.Value = new DateTime(2025, 10, 2);
            dtpFiltroFim.Value = DateTime.Now;

            CarregarProdutos();
            CarregarHistoricoVendas();
        }

        private void CarregarProdutos()
        {
            try
            {
                _produtosDisponiveis = _produtoRepository.ObterTodosProdutos();

                // Preenche ComboBox
                cbxProduto.Items.Clear();
                cbxProduto.Items.Add("Selecione um produto");

                foreach (DataRow row in _produtosDisponiveis.Rows)
                {
                    int quantidade = row["Quantidade_Prod"] != DBNull.Value
                        ? Convert.ToInt32(Convert.ToDecimal(row["Quantidade_Prod"]))
                        : 0;

                    if (quantidade > 0)
                    {
                        string nome = row["Nome_Prod"].ToString();
                        cbxProduto.Items.Add($"{nome} (Estoque: {quantidade})");
                    }
                }

                cbxProduto.SelectedIndex = 0;

                // Exibe produtos disponíveis no grid
                dgvProdutosDisponiveis.DataSource = _produtosDisponiveis;

                if (dgvProdutosDisponiveis.Columns.Count > 0)
                {
                    dgvProdutosDisponiveis.Columns["Id_Prod"].Visible = false;
                    dgvProdutosDisponiveis.Columns["Nome_Prod"].HeaderText = "Produto";
                    dgvProdutosDisponiveis.Columns["Categoria"].HeaderText = "Categoria";
                    dgvProdutosDisponiveis.Columns["Quantidade_Prod"].HeaderText = "Estoque";
                    dgvProdutosDisponiveis.Columns["Preco_Ven"].HeaderText = "Preço";
                    dgvProdutosDisponiveis.Columns["Preco_Ven"].DefaultCellStyle.Format = "C2";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CbxProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxProduto.SelectedIndex > 0)
            {
                DataRow produto = _produtosDisponiveis.Rows[cbxProduto.SelectedIndex - 1];
                decimal preco = Convert.ToDecimal(produto["Preco_Ven"]);
                int estoque = Convert.ToInt32(Convert.ToDecimal(produto["Quantidade_Prod"]));

                lblPrecoUnitario.Text = preco.ToString("C2");
                lblEstoqueDisponivel.Text = $"Estoque disponível: {estoque} unidades";
                nudQuantidade.Maximum = estoque;
                CalcularTotal();
            }
            else
            {
                lblPrecoUnitario.Text = "R$ 0,00";
                lblEstoqueDisponivel.Text = "Estoque: -";
                lblTotal.Text = "R$ 0,00";
            }
        }

        private void NudQuantidade_ValueChanged(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            if (cbxProduto.SelectedIndex > 0)
            {
                DataRow produto = _produtosDisponiveis.Rows[cbxProduto.SelectedIndex - 1];
                decimal preco = Convert.ToDecimal(produto["Preco_Ven"]);
                decimal total = preco * nudQuantidade.Value;
                lblTotal.Text = total.ToString("C2");
            }
        }

        private void BtnRegistrarVenda_Click(object sender, EventArgs e)
        {
            if (cbxProduto.SelectedIndex <= 0)
            {
                MessageBox.Show("Selecione um produto.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataRow produto = _produtosDisponiveis.Rows[cbxProduto.SelectedIndex - 1];
                int idProduto = Convert.ToInt32(produto["Id_Prod"]);
                string nomeProduto = produto["Nome_Prod"].ToString();

                var venda = new Venda
                {
                    IdProduto = idProduto,
                    Quantidade = (int)nudQuantidade.Value,
                    IdUsuario = UserSession.IdUsuario
                };

                DialogResult confirmacao = MessageBox.Show(
                    $"Confirmar venda?\n\nProduto: {nomeProduto}\nQuantidade: {venda.Quantidade}\nTotal: {lblTotal.Text}",
                    "Confirmar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirmacao == DialogResult.Yes)
                {
                    if (_vendaRepository.RegistrarVenda(venda))
                    {
                        MessageBox.Show($"✅ Venda registrada com sucesso!\n\nTotal: {lblTotal.Text}",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregarProdutos();
                        CarregarHistoricoVendas();
                        cbxProduto.SelectedIndex = 0;
                        nudQuantidade.Value = 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar venda:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarHistoricoVendas()
        {
            try
            {
                var vendas = _vendaRepository.ObterVendas(dtpFiltroInicio.Value, dtpFiltroFim.Value);
                dgvVendas.DataSource = vendas;

                if (dgvVendas.Columns.Count > 0)
                {
                    dgvVendas.Columns["Id_Venda"].Visible = false;
                    dgvVendas.Columns["Produto"].HeaderText = "Produto";
                    dgvVendas.Columns["Quantidade"].HeaderText = "Qtd";
                    dgvVendas.Columns["Valor_Unitario"].HeaderText = "Preço Unit.";
                    dgvVendas.Columns["Valor_Unitario"].DefaultCellStyle.Format = "C2";
                    dgvVendas.Columns["Valor_Total"].HeaderText = "Total";
                    dgvVendas.Columns["Valor_Total"].DefaultCellStyle.Format = "C2";
                    dgvVendas.Columns["Data_Venda"].HeaderText = "Data";
                    dgvVendas.Columns["Data_Venda"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvVendas.Columns["Vendedor"].HeaderText = "Vendedor";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar histórico: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            CarregarHistoricoVendas();
        }

        private void BtnCancelarVenda_Click(object sender, EventArgs e)
        {
            if (dgvVendas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma venda para cancelar.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dgvVendas.SelectedRows[0];
                int idVenda = Convert.ToInt32(row.Cells["Id_Venda"].Value);
                string produto = row.Cells["Produto"].Value.ToString();
                decimal valor = Convert.ToDecimal(row.Cells["Valor_Total"].Value);

                DialogResult confirmacao = MessageBox.Show(
                    $"⚠️ CANCELAR VENDA?\n\nProduto: {produto}\nValor: {valor:C2}\n\nO estoque será restaurado.",
                    "Cancelar Venda", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacao == DialogResult.Yes)
                {
                    if (_vendaRepository.CancelarVenda(idVenda))
                    {
                        MessageBox.Show("Venda cancelada e estoque restaurado!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CarregarProdutos();
                        CarregarHistoricoVendas();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cancelar venda:\n{ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            // Carregamento inicial já feito no construtor
        }
    }
}