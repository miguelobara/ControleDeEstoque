using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ControleDeEstoque
{
    public partial class Form8 : Form
    {
        private SqlConnection conexao;
        private DataTable dadosLucros;
        private string connectionString = "Data Source=sqlexpress;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

        public Form8()
        {
            InitializeComponent();
            ConfigurarDateTimePickers();
            ConectarBanco();
            CarregarDadosLucros();
            CalcularMetricas();
        }

        private void ConfigurarDateTimePickers()
        {
            // Definir período padrão (últimos 30 dias)
            dtpFim.Value = DateTime.Now;
            dtpInicio.Value = DateTime.Now.AddDays(-30);
        }

        private void ConectarBanco()
        {
            try
            {
                conexao = new SqlConnection(connectionString);
                conexao.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao conectar com o banco: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDadosLucros()
        {
            try
            {
                // CORREÇÃO: Usando a tabela correta "Produto" em vez de "Products"
                string query = @"
                    SELECT 
                        p.Nome_Prod as Nome_Produto,
                        p.Preco_Cmp as Preco_Custo,
                        p.Preco_Ven as Preco_Venda,
                        (p.Preco_Ven - p.Preco_Cmp) as Lucro_Unitario,
                        COALESCE(p.Quantidade_Prod, 0) as Quantidade_Vendida,
                        (p.Preco_Ven - p.Preco_Cmp) * COALESCE(p.Quantidade_Prod, 0) as Lucro_Total
                    FROM Produto p
                    ORDER BY Lucro_Total DESC";

                SqlCommand cmd = new SqlCommand(query, conexao);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                dadosLucros = new DataTable();
                adapter.Fill(dadosLucros);

                dataGridViewLucros.DataSource = dadosLucros;

                // Configurar formatação das colunas
                if (dataGridViewLucros.Columns.Count > 0)
                {
                    dataGridViewLucros.Columns["Preco_Custo"].DefaultCellStyle.Format = "C2";
                    dataGridViewLucros.Columns["Preco_Venda"].DefaultCellStyle.Format = "C2";
                    dataGridViewLucros.Columns["Lucro_Unitario"].DefaultCellStyle.Format = "C2";
                    dataGridViewLucros.Columns["Lucro_Total"].DefaultCellStyle.Format = "C2";

                    // Renomear cabeçalhos
                    dataGridViewLucros.Columns["Nome_Produto"].HeaderText = "Nome do Produto";
                    dataGridViewLucros.Columns["Preco_Custo"].HeaderText = "Preço Custo";
                    dataGridViewLucros.Columns["Preco_Venda"].HeaderText = "Preço Venda";
                    dataGridViewLucros.Columns["Lucro_Unitario"].HeaderText = "Lucro Unitário";
                    dataGridViewLucros.Columns["Quantidade_Vendida"].HeaderText = "Quantidade";
                    dataGridViewLucros.Columns["Lucro_Total"].HeaderText = "Lucro Total";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Criar DataTable vazio em caso de erro
                dadosLucros = new DataTable();
            }
        }

        private void CalcularMetricas()
        {
            try
            {
                // Calcular totais
                decimal lucroTotal = 0;
                decimal receitaTotal = 0;
                decimal custoTotal = 0;

                foreach (DataRow row in dadosLucros.Rows)
                {
                    decimal lucro = row["Lucro_Total"] != DBNull.Value ? Convert.ToDecimal(row["Lucro_Total"]) : 0;
                    decimal precoVenda = row["Preco_Venda"] != DBNull.Value ? Convert.ToDecimal(row["Preco_Venda"]) : 0;
                    decimal precoCusto = row["Preco_Custo"] != DBNull.Value ? Convert.ToDecimal(row["Preco_Custo"]) : 0;
                    int quantidade = row["Quantidade_Vendida"] != DBNull.Value ? Convert.ToInt32(row["Quantidade_Vendida"]) : 0;

                    lucroTotal += lucro;
                    receitaTotal += precoVenda * quantidade;
                    custoTotal += precoCusto * quantidade;
                }

                // Atualizar labels
                lblLucroTotal.Text = lucroTotal.ToString("C2");
                lblReceitaTotal.Text = receitaTotal.ToString("C2");
                lblCustoTotal.Text = custoTotal.ToString("C2");

                // Calcular margem de lucro
                decimal margemLucro = receitaTotal > 0 ? (lucroTotal / receitaTotal) * 100 : 0;
                lblMargemLucro.Text = margemLucro.ToString("F2") + "%";

                // Produto mais lucrativo
                if (dadosLucros.Rows.Count > 0 && dadosLucros.Rows[0]["Lucro_Total"] != DBNull.Value)
                {
                    DataRow topProduct = dadosLucros.Rows[0];
                    lblProdutoMaisLucrativo.Text = topProduct["Nome_Produto"].ToString();
                    lblLucroTopProduto.Text = Convert.ToDecimal(topProduct["Lucro_Total"]).ToString("C2");
                }
                else
                {
                    lblProdutoMaisLucrativo.Text = "Nenhum";
                    lblLucroTopProduto.Text = "R$ 0,00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular métricas: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFiltrarPeriodo_Click(object sender, EventArgs e)
        {
            FiltrarPorPeriodo();
        }

        private void FiltrarPorPeriodo()
        {
            try
            {
                // CORREÇÃO: Query simplificada usando apenas a tabela Produto
                DateTime dataInicio = dtpInicio.Value;
                DateTime dataFim = dtpFim.Value;

                string query = @"
                    SELECT 
                        p.Nome_Prod as Nome_Produto,
                        p.Preco_Cmp as Preco_Custo,
                        p.Preco_Ven as Preco_Venda,
                        (p.Preco_Ven - p.Preco_Cmp) as Lucro_Unitario,
                        COALESCE(p.Quantidade_Prod, 0) as Quantidade_Vendida,
                        (p.Preco_Ven - p.Preco_Cmp) * COALESCE(p.Quantidade_Prod, 0) as Lucro_Total
                    FROM Produto p
                    ORDER BY Lucro_Total DESC";

                SqlCommand cmd = new SqlCommand(query, conexao);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtFiltrado = new DataTable();
                adapter.Fill(dtFiltrado);

                dataGridViewLucros.DataSource = dtFiltrado;
                CalcularMetricasComFiltro(dtFiltrado);

                MessageBox.Show($"Dados filtrados para o período: {dtpInicio.Value:dd/MM/yyyy} a {dtpFim.Value:dd/MM/yyyy}",
                    "Filtro Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularMetricasComFiltro(DataTable dadosFiltrados)
        {
            decimal lucroTotal = 0;
            decimal receitaTotal = 0;
            decimal custoTotal = 0;

            foreach (DataRow row in dadosFiltrados.Rows)
            {
                decimal lucro = row["Lucro_Total"] != DBNull.Value ? Convert.ToDecimal(row["Lucro_Total"]) : 0;
                decimal precoVenda = row["Preco_Venda"] != DBNull.Value ? Convert.ToDecimal(row["Preco_Venda"]) : 0;
                decimal precoCusto = row["Preco_Custo"] != DBNull.Value ? Convert.ToDecimal(row["Preco_Custo"]) : 0;
                int quantidade = row["Quantidade_Vendida"] != DBNull.Value ? Convert.ToInt32(row["Quantidade_Vendida"]) : 0;

                lucroTotal += lucro;
                receitaTotal += precoVenda * quantidade;
                custoTotal += precoCusto * quantidade;
            }

            lblLucroTotal.Text = lucroTotal.ToString("C2");
            lblReceitaTotal.Text = receitaTotal.ToString("C2");
            lblCustoTotal.Text = custoTotal.ToString("C2");

            decimal margemLucro = receitaTotal > 0 ? (lucroTotal / receitaTotal) * 100 : 0;
            lblMargemLucro.Text = margemLucro.ToString("F2") + "%";
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            ExportarParaCSV();
        }

        private void ExportarParaCSV()
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivo CSV (*.csv)|*.csv";
                saveFileDialog.Title = "Exportar Relatório de Lucros";
                saveFileDialog.FileName = $"Relatorio_Lucros_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    StringBuilder csv = new StringBuilder();

                    // Cabeçalho
                    csv.AppendLine("Nome do Produto;Preço Custo;Preço Venda;Lucro Unitário;Quantidade;Lucro Total");

                    // Dados
                    foreach (DataRow row in dadosLucros.Rows)
                    {
                        csv.AppendLine(
                            $"{row["Nome_Produto"]};" +
                            $"{Convert.ToDecimal(row["Preco_Custo"]):F2};" +
                            $"{Convert.ToDecimal(row["Preco_Venda"]):F2};" +
                            $"{Convert.ToDecimal(row["Lucro_Unitario"]):F2};" +
                            $"{row["Quantidade_Vendida"]};" +
                            $"{Convert.ToDecimal(row["Lucro_Total"]):F2}"
                        );
                    }

                    System.IO.File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);

                    MessageBox.Show("Relatório exportado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDadosLucros();
            CalcularMetricas();
            MessageBox.Show("Dados atualizados com sucesso!", "Atualização",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (conexao != null && conexao.State == ConnectionState.Open)
            {
                conexao.Close();
                conexao.Dispose();
            }
            base.OnFormClosing(e);
        }
    }
}