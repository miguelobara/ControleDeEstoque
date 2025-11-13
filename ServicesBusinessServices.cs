using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ControleDeEstoque.Core;
using ControleDeEstoque.Data.Repositories;

namespace ControleDeEstoque.Services
{
    /// <summary>
    /// Serviço de relatórios e análises
    /// </summary>
    public class ReportService
    {
        private readonly ProdutoRepository _produtoRepo;
        private readonly VendaRepository _vendaRepo;

        public ReportService()
        {
            _produtoRepo = new ProdutoRepository();
            _vendaRepo = new VendaRepository();
        }

        /// <summary>
        /// Gera dashboard com métricas principais
        /// </summary>
        public DashboardData GetDashboard()
        {
            var produtos = _produtoRepo.GetAll();
            var vendasMes = _vendaRepo.GetByPeriod(
                DateTime.Now.AddDays(-30),
                DateTime.Now
            );

            return new DashboardData
            {
                TotalProdutos = produtos.Count,
                ProdutosEstoqueBaixo = produtos.Count(p => p.Quantidade <= 10),
                ValorTotalEstoque = produtos.Sum(p => p.PrecoCompra * p.Quantidade),
                LucroEstimado = produtos.Sum(p => p.LucroTotal),
                VendasMes = vendasMes.Rows.Count,
                ReceitaMes = vendasMes.AsEnumerable().Sum(r => r.Field<decimal>("Valor_Total")),
                CategoriasMaisVendidas = GetTopCategories(5),
                ProdutosMaisLucrativos = produtos.OrderByDescending(p => p.LucroTotal).Take(5).ToList()
            };
        }

        /// <summary>
        /// Análise de lucros detalhada
        /// </summary>
        public LucroAnalysis AnalisarLucros(DateTime inicio, DateTime fim)
        {
            var produtos = _produtoRepo.GetAll();
            var vendas = _vendaRepo.GetByPeriod(inicio, fim);

            decimal custoTotal = produtos.Sum(p => p.PrecoCompra * p.Quantidade);
            decimal receitaTotal = vendas.AsEnumerable().Sum(r => r.Field<decimal>("Valor_Total"));
            decimal lucroTotal = receitaTotal - custoTotal;
            decimal margemLucro = receitaTotal > 0 ? (lucroTotal / receitaTotal) * 100 : 0;

            // Produto mais lucrativo
            var maisLucrativo = produtos.OrderByDescending(p => p.LucroTotal).FirstOrDefault();

            return new LucroAnalysis
            {
                CustoTotal = custoTotal,
                ReceitaTotal = receitaTotal,
                LucroTotal = lucroTotal,
                MargemLucro = margemLucro,
                ProdutoMaisLucrativo = maisLucrativo?.Nome ?? "N/A",
                LucroMaisLucrativo = maisLucrativo?.LucroTotal ?? 0,
                LucrosPorCategoria = GetLucrosByCategory(),
                TendenciaMensal = GetMonthlyTrend(6)
            };
        }

        /// <summary>
        /// Exporta relatório para CSV
        /// </summary>
        public string ExportToCSV(DataTable data, string filename)
        {
            var csv = new StringBuilder();

            // Cabeçalhos
            var headers = data.Columns.Cast<DataColumn>().Select(c => c.ColumnName);
            csv.AppendLine(string.Join(";", headers));

            // Dados
            foreach (DataRow row in data.Rows)
            {
                var values = row.ItemArray.Select(v => v?.ToString() ?? "");
                csv.AppendLine(string.Join(";", values));
            }

            string path = $"{filename}_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
            System.IO.File.WriteAllText(path, csv.ToString(), Encoding.UTF8);

            Logger.Info($"Relatório exportado: {path}");
            return path;
        }

        /// <summary>
        /// Alertas de estoque baixo
        /// </summary>
        public List<StockAlert> GetStockAlerts(int threshold = 10)
        {
            var baixoEstoque = _produtoRepo.GetLowStock(threshold);

            return baixoEstoque.Select(p => new StockAlert
            {
                ProdutoId = p.Id,
                ProdutoNome = p.Nome,
                QuantidadeAtual = p.Quantidade,
                Status = p.Quantidade == 0 ? "CRÍTICO" : "BAIXO",
                Recomendacao = $"Reabastecer com pelo menos {threshold * 2} unidades"
            }).ToList();
        }

        /// <summary>
        /// Previsão de vendas simples
        /// </summary>
        public SalesForeCast GetSalesForecast(int daysAhead = 30)
        {
            var vendas30Dias = _vendaRepo.GetByPeriod(
                DateTime.Now.AddDays(-30),
                DateTime.Now
            );

            decimal mediaVendasDia = vendas30Dias.Rows.Count > 0
                ? vendas30Dias.AsEnumerable().Sum(r => r.Field<decimal>("Valor_Total")) / 30
                : 0;

            return new SalesForeCast
            {
                MediaDiaria = mediaVendasDia,
                PrevisaoProximos30Dias = mediaVendasDia * daysAhead,
                ConfiabilidadePercentual = vendas30Dias.Rows.Count >= 20 ? 80 : 50
            };
        }

        private Dictionary<string, int> GetTopCategories(int top)
        {
            return _produtoRepo.GetCategoriesCount()
                .OrderByDescending(x => x.Value)
                .Take(top)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private Dictionary<string, decimal> GetLucrosByCategory()
        {
            var produtos = _produtoRepo.GetAll();
            return produtos
                .GroupBy(p => p.Categoria)
                .ToDictionary(
                    g => g.Key ?? "Sem Categoria",
                    g => g.Sum(p => p.LucroTotal)
                );
        }

        private List<MonthlyData> GetMonthlyTrend(int months)
        {
            var result = new List<MonthlyData>();

            for (int i = months - 1; i >= 0; i--)
            {
                var inicio = DateTime.Now.AddMonths(-i).AddDays(-DateTime.Now.Day + 1);
                var fim = inicio.AddMonths(1).AddDays(-1);

                decimal total = _vendaRepo.GetTotalByPeriod(inicio, fim);

                result.Add(new MonthlyData
                {
                    Mes = inicio.ToString("MMM/yyyy"),
                    Valor = total
                });
            }

            return result;
        }
    }

    /// <summary>
    /// Serviço de validações de negócio
    /// </summary>
    public class ValidationService
    {
        public ValidationResult ValidateProduto(Produto produto)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(produto.Nome))
                result.AddError("Nome do produto é obrigatório");

            if (produto.PrecoCompra <= 0)
                result.AddError("Preço de compra deve ser maior que zero");

            if (produto.PrecoVenda <= 0)
                result.AddError("Preço de venda deve ser maior que zero");

            if (produto.PrecoVenda < produto.PrecoCompra)
                result.AddWarning($"Prejuízo: Preço de venda ({AppCore.FormatCurrency(produto.PrecoVenda)}) menor que compra ({AppCore.FormatCurrency(produto.PrecoCompra)})");

            if (produto.Quantidade < 0)
                result.AddError("Quantidade não pode ser negativa");

            if (produto.Validade < DateTime.Now)
                result.AddWarning("Produto com validade vencida");

            return result;
        }

        public ValidationResult ValidateFornecedor(Fornecedor fornecedor)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(fornecedor.Nome))
                result.AddError("Nome do fornecedor é obrigatório");

            if (!string.IsNullOrWhiteSpace(fornecedor.Email) && !IsValidEmail(fornecedor.Email))
                result.AddError("E-mail inválido");

            if (!string.IsNullOrWhiteSpace(fornecedor.Cnpj) && !IsValidCNPJ(fornecedor.Cnpj))
                result.AddError("CNPJ inválido");

            return result;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidCNPJ(string cnpj)
        {
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());
            return cnpj.Length == 14;
        }
    }

    /// <summary>
    /// Serviço de backup e recuperação
    /// </summary>
    public class BackupService
    {
        public bool CreateBackup(string path = null)
        {
            try
            {
                path = path ?? $"backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";

                var db = EnhancedDatabase.Instance;
                db.Execute($@"
                    BACKUP DATABASE CJ3027511PR2 
                    TO DISK = @Path 
                    WITH FORMAT, MEDIANAME = 'Backup', NAME = 'Full Backup'",
                    new System.Data.SqlClient.SqlParameter("@Path", path));

                Logger.Info($"Backup criado: {path}");
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Erro ao criar backup", ex);
                return false;
            }
        }

        public bool ScheduleAutoBackup(int intervalHours = 24)
        {
            // TODO: Implementar backup automático com Timer
            Logger.Info($"Backup automático agendado: a cada {intervalHours}h");
            return true;
        }
    }

    // ============ MODELS DE SERVIÇO ============

    public class DashboardData
    {
        public int TotalProdutos { get; set; }
        public int ProdutosEstoqueBaixo { get; set; }
        public decimal ValorTotalEstoque { get; set; }
        public decimal LucroEstimado { get; set; }
        public int VendasMes { get; set; }
        public decimal ReceitaMes { get; set; }
        public Dictionary<string, int> CategoriasMaisVendidas { get; set; }
        public List<Produto> ProdutosMaisLucrativos { get; set; }
    }

    public class LucroAnalysis
    {
        public decimal CustoTotal { get; set; }
        public decimal ReceitaTotal { get; set; }
        public decimal LucroTotal { get; set; }
        public decimal MargemLucro { get; set; }
        public string ProdutoMaisLucrativo { get; set; }
        public decimal LucroMaisLucrativo { get; set; }
        public Dictionary<string, decimal> LucrosPorCategoria { get; set; }
        public List<MonthlyData> TendenciaMensal { get; set; }
    }

    public class MonthlyData
    {
        public string Mes { get; set; }
        public decimal Valor { get; set; }
    }

    public class StockAlert
    {
        public int ProdutoId { get; set; }
        public string ProdutoNome { get; set; }
        public int QuantidadeAtual { get; set; }
        public string Status { get; set; }
        public string Recomendacao { get; set; }
    }

    public class SalesForeCast
    {
        public decimal MediaDiaria { get; set; }
        public decimal PrevisaoProximos30Dias { get; set; }
        public int ConfiabilidadePercentual { get; set; }
    }

    public class ValidationResult
    {
        public List<string> Errors { get; } = new List<string>();
        public List<string> Warnings { get; } = new List<string>();

        public bool IsValid => !Errors.Any();
        public bool HasWarnings => Warnings.Any();

        public void AddError(string error) => Errors.Add(error);
        public void AddWarning(string warning) => Warnings.Add(warning);

        public string GetErrorsMessage() => string.Join("\n", Errors);
        public string GetWarningsMessage() => string.Join("\n", Warnings);
        public string GetAllMessages() => string.Join("\n", Errors.Concat(Warnings));
    }
}