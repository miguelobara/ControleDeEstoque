using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ControleDeEstoque.Data;

namespace ControleDeEstoque.Data.Repositories
{
    public class ProdutoRepository
    {
        /// <summary>
        /// Obtém APENAS os produtos do usuário logado
        /// </summary>
        public DataTable ObterTodosProdutos()
        {
            UserSession.VerificarSessao();

            const string query = @"
                SELECT 
                    p.Id_Prod, p.Nome_Prod, p.Categoria, p.Validade, p.Descricao, 
                    p.Preco_Ven, p.Preco_Cmp, p.Quantidade_Prod, 
                    p.Unidade_Medida_Prod, f.Nome_For as Fornecedor, p.juros
                FROM Produto p
                LEFT JOIN Fornecedor f ON p.Id_Fornecedor = f.Id_Fornecedor
                WHERE p.Id_Usuario = @IdUsuario
                ORDER BY p.Nome_Prod";

            return DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@IdUsuario", UserSession.IdUsuario));
        }

        /// <summary>
        /// Busca produtos do usuário logado com filtros
        /// </summary>
        public DataTable BuscarProdutos(string termo, bool buscarNome, bool buscarCategoria,
            bool buscarFornecedor, bool buscarDescricao)
        {
            UserSession.VerificarSessao();

            var conditions = new List<string>();
            var parameters = new List<SqlParameter>();

            // Sempre filtra pelo usuário
            conditions.Add("p.Id_Usuario = @IdUsuario");
            parameters.Add(new SqlParameter("@IdUsuario", UserSession.IdUsuario));

            if (buscarNome)
                conditions.Add("p.Nome_Prod LIKE @Termo");
            if (buscarCategoria)
                conditions.Add("p.Categoria LIKE @Termo");
            if (buscarFornecedor)
                conditions.Add("f.Nome_For LIKE @Termo");
            if (buscarDescricao)
                conditions.Add("p.Descricao LIKE @Termo");

            parameters.Add(new SqlParameter("@Termo", $"%{termo}%"));

            string query = $@"
                SELECT 
                    p.Id_Prod, p.Nome_Prod, p.Categoria, p.Validade, p.Descricao, 
                    p.Preco_Ven, p.Preco_Cmp, p.Quantidade_Prod, 
                    p.Unidade_Medida_Prod, f.Nome_For as Fornecedor, p.juros
                FROM Produto p
                LEFT JOIN Fornecedor f ON p.Id_Fornecedor = f.Id_Fornecedor
                WHERE {conditions[0]} AND ({string.Join(" OR ", conditions.GetRange(1, conditions.Count - 1))})
                ORDER BY p.Nome_Prod";

            return DatabaseHelper.ExecuteQuery(query, parameters.ToArray());
        }

        /// <summary>
        /// Insere produto vinculado ao usuário logado
        /// </summary>
        public bool InserirProduto(Produto produto)
        {
            UserSession.VerificarSessao();

            const string query = @"
                DECLARE @NextID INT;
                SELECT @NextID = ISNULL(MAX(Id_Prod), 0) + 1 FROM Produto;

                INSERT INTO Produto 
                (Id_Prod, Nome_Prod, Categoria, Validade, Descricao, Preco_Ven, Preco_Cmp, 
                 Quantidade_Prod, Unidade_Medida_Prod, Id_Fornecedor, juros, Id_Usuario) 
                VALUES 
                (@NextID, @Nome, @Categoria, @Validade, @Descricao, @PrecoVenda, @PrecoCompra, 
                 @Quantidade, @UnidadeMedida, @IdFornecedor, @Juros, @IdUsuario)";

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
                new SqlParameter("@Juros", produto.Juros),
                new SqlParameter("@IdUsuario", UserSession.IdUsuario)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Atualiza produto (apenas se pertencer ao usuário)
        /// </summary>
        public bool AtualizarProduto(Produto produto)
        {
            UserSession.VerificarSessao();

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
                WHERE Id_Prod = @IdProduto AND Id_Usuario = @IdUsuario";

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
                new SqlParameter("@Juros", produto.Juros),
                new SqlParameter("@IdUsuario", UserSession.IdUsuario)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Deleta produto (apenas se pertencer ao usuário)
        /// </summary>
        public bool DeletarProduto(int idProduto)
        {
            UserSession.VerificarSessao();

            const string query = @"
                DELETE FROM Produto 
                WHERE Id_Prod = @Id AND Id_Usuario = @IdUsuario";

            var parameters = new[]
            {
                new SqlParameter("@Id", idProduto),
                new SqlParameter("@IdUsuario", UserSession.IdUsuario)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        public decimal ObterPercentualLucroPadrao()
        {
            UserSession.VerificarSessao();

            const string query = @"
                SELECT TOP 1 juros 
                FROM Produto 
                WHERE juros IS NOT NULL AND juros > 0 AND Id_Usuario = @IdUsuario
                ORDER BY Id_Prod DESC";

            var result = DatabaseHelper.ExecuteScalar(query,
                new SqlParameter("@IdUsuario", UserSession.IdUsuario));

            return result != DBNull.Value && result != null
                ? Convert.ToDecimal(result)
                : 30m;
        }

        public bool AtualizarPercentualLucro(decimal novoPercentual)
        {
            UserSession.VerificarSessao();

            const string query = @"
                UPDATE Produto 
                SET juros = @Juros 
                WHERE juros IS NOT NULL AND Id_Usuario = @IdUsuario";

            var parameters = new[]
            {
                new SqlParameter("@Juros", novoPercentual),
                new SqlParameter("@IdUsuario", UserSession.IdUsuario)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) >= 0;
        }
    }

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