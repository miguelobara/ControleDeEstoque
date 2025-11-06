using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ControleDeEstoque.Data.Repositories
{
    /// <summary>
    /// Repositório para operações de produtos no banco de dados
    /// </summary>
    public class ProdutoRepository
    {
        /// <summary>
        /// Obtém todos os produtos com informações do fornecedor
        /// </summary>
        public DataTable ObterTodosProdutos()
        {
            const string query = @"
                SELECT 
                    p.Id_Prod, p.Nome_Prod, p.Categoria, p.Validade, p.Descricao, 
                    p.Preco_Ven, p.Preco_Cmp, p.Quantidade_Prod, 
                    p.Unidade_Medida_Prod, f.Nome_For as Fornecedor, p.juros
                FROM Produto p
                LEFT JOIN Fornecedor f ON p.Id_Fornecedor = f.Id_Fornecedor
                ORDER BY p.Nome_Prod";

            return DatabaseHelper.ExecuteQuery(query);
        }

        /// <summary>
        /// Busca produtos com filtros múltiplos
        /// </summary>
        public DataTable BuscarProdutos(string termo, bool buscarNome, bool buscarCategoria, 
            bool buscarFornecedor, bool buscarDescricao)
        {
            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            if (buscarNome)
            {
                conditions.Add("p.Nome_Prod LIKE @Termo");
            }
            if (buscarCategoria)
            {
                conditions.Add("p.Categoria LIKE @Termo");
            }
            if (buscarFornecedor)
            {
                conditions.Add("f.Nome_For LIKE @Termo");
            }
            if (buscarDescricao)
            {
                conditions.Add("p.Descricao LIKE @Termo");
            }

            if (conditions.Count == 0)
            {
                conditions.Add("p.Nome_Prod LIKE @Termo");
            }

            parameters.Add(new SqlParameter("@Termo", $"%{termo}%"));

            string query = $@"
                SELECT 
                    p.Id_Prod, p.Nome_Prod, p.Categoria, p.Validade, p.Descricao, 
                    p.Preco_Ven, p.Preco_Cmp, p.Quantidade_Prod, 
                    p.Unidade_Medida_Prod, f.Nome_For as Fornecedor, p.juros
                FROM Produto p
                LEFT JOIN Fornecedor f ON p.Id_Fornecedor = f.Id_Fornecedor
                WHERE {string.Join(" OR ", conditions)}
                ORDER BY p.Nome_Prod";

            return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
        }

        /// <summary>
        /// Insere novo produto no banco
        /// </summary>
        public bool InserirProduto(Produto produto)
        {
            const string query = @"
                DECLARE @NextID INT;
                SELECT @NextID = ISNULL(MAX(Id_Prod), 0) + 1 FROM Produto;

                INSERT INTO Produto 
                (Id_Prod, Nome_Prod, Categoria, Validade, Descricao, Preco_Ven, Preco_Cmp, 
                 Quantidade_Prod, Unidade_Medida_Prod, Id_Fornecedor, juros) 
                VALUES 
                (@NextID, @Nome, @Categoria, @Validade, @Descricao, @PrecoVenda, @PrecoCompra, 
                 @Quantidade, @UnidadeMedida, @IdFornecedor, @Juros)";

            var parameters = new[]
            {
                new SqlParameter("@Nome", produto.Nome),
                new SqlParameter("@Categoria", produto.Categoria),
                new SqlParameter("@Validade", produto.Validade),
                new SqlParameter("@Descricao", (object)produto.Descricao ?? DBNull.Value),
                new SqlParameter("@PrecoVenda", produto.PrecoVenda),
                new SqlParameter("@PrecoCompra", produto.PrecoCompra),
                new SqlParameter("@Quantidade", produto.Quantidade),
                new SqlParameter("@UnidadeMedida", produto.UnidadeMedida),
                new SqlParameter("@IdFornecedor", (object)produto.IdFornecedor ?? DBNull.Value),
                new SqlParameter("@Juros", produto.Juros)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Atualiza produto existente
        /// </summary>
        public bool AtualizarProduto(Produto produto)
        {
            const string query = @"
                UPDATE Produto SET 
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

            var parameters = new[]
            {
                new SqlParameter("@IdProduto", produto.Id),
                new SqlParameter("@Nome", produto.Nome),
                new SqlParameter("@Categoria", produto.Categoria),
                new SqlParameter("@Validade", produto.Validade),
                new SqlParameter("@Descricao", (object)produto.Descricao ?? DBNull.Value),
                new SqlParameter("@PrecoVenda", produto.PrecoVenda),
                new SqlParameter("@PrecoCompra", produto.PrecoCompra),
                new SqlParameter("@Quantidade", produto.Quantidade),
                new SqlParameter("@UnidadeMedida", produto.UnidadeMedida),
                new SqlParameter("@IdFornecedor", (object)produto.IdFornecedor ?? DBNull.Value),
                new SqlParameter("@Juros", produto.Juros)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Deleta produto do banco
        /// </summary>
        public bool DeletarProduto(int idProduto)
        {
            const string query = "DELETE FROM Produto WHERE Id_Prod = @Id";
            return DatabaseHelper.ExecuteNonQuery(query, 
                new SqlParameter("@Id", idProduto)) > 0;
        }

        /// <summary>
        /// Obtém percentual de lucro padrão
        /// </summary>
        public decimal ObterPercentualLucroPadrao()
        {
            const string query = @"
                SELECT TOP 1 juros 
                FROM Produto 
                WHERE juros IS NOT NULL AND juros > 0 
                ORDER BY Id_Prod DESC";

            var result = DatabaseHelper.ExecuteScalar(query);
            return result != DBNull.Value && result != null 
                ? Convert.ToDecimal(result) 
                : 30m;
        }

        /// <summary>
        /// Atualiza percentual de lucro de todos os produtos
        /// </summary>
        public bool AtualizarPercentualLucro(decimal novoPercentual)
        {
            const string query = "UPDATE Produto SET juros = @Juros WHERE juros IS NOT NULL";
            return DatabaseHelper.ExecuteNonQuery(query, 
                new SqlParameter("@Juros", novoPercentual)) >= 0;
        }
    }

    /// <summary>
    /// Modelo de dados para Produto
    /// </summary>
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public DateTime Validade { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal PrecoCompra { get; set; }
        public int Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
        public int? IdFornecedor { get; set; }
        public decimal Juros { get; set; }
    }
}