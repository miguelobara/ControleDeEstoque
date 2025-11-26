using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
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
        /// NOVO: Retorna lista de objetos Produto (para uso em forms modernos)
        /// </summary>
        public List<Produto> GetAll()
        {
            var dt = ObterTodosProdutos();
            var produtos = new List<Produto>();

            foreach (DataRow row in dt.Rows)
            {
                produtos.Add(new Produto
                {
                    Id = Convert.ToInt32(row["Id_Prod"]),
                    Nome = row["Nome_Prod"].ToString(),
                    Categoria = row["Categoria"].ToString(),
                    Validade = Convert.ToDateTime(row["Validade"]),
                    Descricao = row["Descricao"]?.ToString(),
                    PrecoVenda = Convert.ToDecimal(row["Preco_Ven"]),
                    PrecoCompra = Convert.ToDecimal(row["Preco_Cmp"]),
                    Quantidade = Convert.ToInt32(Convert.ToDecimal(row["Quantidade_Prod"])),
                    UnidadeMedida = row["Unidade_Medida_Prod"].ToString(),
                    Juros = row["juros"] != DBNull.Value ? Convert.ToDecimal(row["juros"]) : 30m
                });
            }

            return produtos;
        }

        /// <summary>
        /// NOVO: Busca produtos com opções
        /// </summary>
        public List<Produto> Search(string termo, SearchOptions options)
        {
            var produtos = GetAll();

            if (string.IsNullOrWhiteSpace(termo))
                return produtos;

            termo = termo.ToLower();

            return produtos.Where(p =>
                (options.SearchName && p.Nome.ToLower().Contains(termo)) ||
                (options.SearchCategory && p.Categoria?.ToLower().Contains(termo) == true) ||
                (options.SearchDescription && p.Descricao?.ToLower().Contains(termo) == true)
            ).ToList();
        }

        /// <summary>
        /// NOVO: Produtos com estoque baixo
        /// </summary>
        public List<Produto> GetLowStock(int threshold = 10)
        {
            return GetAll().Where(p => p.Quantidade <= threshold).ToList();
        }

        /// <summary>
        /// NOVO: Contagem de produtos por categoria
        /// </summary>
        public Dictionary<string, int> GetCategoriesCount()
        {
            return GetAll()
                .GroupBy(p => p.Categoria ?? "Sem Categoria")
                .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// NOVO: Fornecedores para ComboBox
        /// </summary>
        public Dictionary<int, string> GetForCombo()
        {
            UserSession.VerificarSessao();

            const string query = @"
                SELECT Id_Fornecedor, Nome_For 
                FROM Fornecedor 
                WHERE estatus_For = 'A' AND Id_Usuario = @IdUsuario
                ORDER BY Nome_For";

            var result = new Dictionary<int, string>();
            var dt = DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@IdUsuario", UserSession.IdUsuario));

            foreach (DataRow row in dt.Rows)
            {
                result.Add(
                    Convert.ToInt32(row["Id_Fornecedor"]),
                    row["Nome_For"].ToString()
                );
            }

            return result;
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
        /// NOVO: Insert simplificado
        /// </summary>
        public bool Insert(Produto produto)
        {
            return InserirProduto(produto);
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
        /// NOVO: Update simplificado
        /// </summary>
        public bool Update(Produto produto)
        {
            return AtualizarProduto(produto);
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

        /// <summary>
        /// NOVO: Delete simplificado
        /// </summary>
        public bool Delete(int id)
        {
            return DeletarProduto(id);
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

    /// <summary>
    /// Classe Produto com propriedades calculadas
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

        // Propriedades calculadas
        public decimal LucroUnitario => PrecoVenda - PrecoCompra;
        public decimal LucroTotal => LucroUnitario * Quantidade;
        public decimal MargemLucro => PrecoCompra > 0 ? (LucroUnitario / PrecoCompra) * 100 : 0;
    }

   
    public class SearchOptions
    {
        public bool SearchName { get; set; } = true;
        public bool SearchCategory { get; set; } = false;
        public bool SearchDescription { get; set; } = false;
    }
}