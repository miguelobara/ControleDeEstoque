using System;
using System.Data;
using System.Data.SqlClient;
using ControleDeEstoque.Models;
using ControleDeEstoque.Data;

namespace ControleDeEstoque.Data.Repositories
{
    public class VendaRepository
    {
        /// <summary>
        /// Registra uma nova venda com transação
        /// </summary>
        public bool RegistrarVenda(Venda venda)
        {
            UserSession.VerificarSessao();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Obter informações do produto
                        var produtoInfo = ObterInformacoesProduto(venda.IdProduto, connection, transaction);
                        if (produtoInfo == null)
                            throw new Exception("Produto não encontrado.");

                        // 2. Verificar estoque
                        if (produtoInfo.Estoque < venda.Quantidade)
                            throw new Exception($"Estoque insuficiente. Disponível: {produtoInfo.Estoque}");

                        // 3. Calcular valor
                        decimal valorTotal = produtoInfo.Preco * venda.Quantidade;

                        // 4. Inserir venda
                        string queryVenda = @"
                            INSERT INTO Venda (Id_Produto, Id_Usuario, Quantidade, 
                                             Valor_Unitario, Valor_Total, Data_Venda) 
                            VALUES (@IdProduto, @IdUsuario, @Quantidade, 
                                   @ValorUnitario, @ValorTotal, @DataVenda)";

                        using (var cmd = new SqlCommand(queryVenda, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdProduto", venda.IdProduto);
                            cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);
                            cmd.Parameters.AddWithValue("@Quantidade", venda.Quantidade);
                            cmd.Parameters.AddWithValue("@ValorUnitario", produtoInfo.Preco);
                            cmd.Parameters.AddWithValue("@ValorTotal", valorTotal);
                            cmd.Parameters.AddWithValue("@DataVenda", DateTime.Now);
                            cmd.ExecuteNonQuery();
                        }

                        // 5. Atualizar estoque
                        string queryEstoque = @"
                            UPDATE Produto 
                            SET Quantidade_Prod = Quantidade_Prod - @Quantidade
                            WHERE Id_Prod = @IdProduto AND Id_Usuario = @IdUsuario";

                        using (var cmd = new SqlCommand(queryEstoque, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Quantidade", venda.Quantidade);
                            cmd.Parameters.AddWithValue("@IdProduto", venda.IdProduto);
                            cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Obtém vendas do usuário por período
        /// </summary>
        public DataTable ObterVendas(DateTime inicio, DateTime fim)
        {
            UserSession.VerificarSessao();

            string query = @"
                SELECT v.Id_Venda, p.Nome_Prod as Produto, v.Quantidade,
                       v.Valor_Unitario, v.Valor_Total, v.Data_Venda,
                       u.Nome as Vendedor
                FROM Venda v
                INNER JOIN Produto p ON v.Id_Produto = p.Id_Prod
                INNER JOIN Usuario u ON v.Id_Usuario = u.Id_Usuario
                WHERE v.Id_Usuario = @IdUsuario 
                  AND v.Data_Venda BETWEEN @Inicio AND @Fim
                ORDER BY v.Data_Venda DESC";

            return DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@IdUsuario", UserSession.IdUsuario),
                new SqlParameter("@Inicio", inicio.Date),
                new SqlParameter("@Fim", fim.Date.AddDays(1).AddSeconds(-1)));
        }

        /// <summary>
        /// MÉTODO ADICIONADO: GetByPeriod para compatibilidade
        /// </summary>
        public DataTable GetByPeriod(DateTime inicio, DateTime fim)
        {
            return ObterVendas(inicio, fim);
        }

        /// <summary>
        /// MÉTODO ADICIONADO: GetTotalByPeriod
        /// </summary>
        public decimal GetTotalByPeriod(DateTime inicio, DateTime fim)
        {
            UserSession.VerificarSessao();

            string query = @"
                SELECT ISNULL(SUM(Valor_Total), 0) 
                FROM Venda 
                WHERE Id_Usuario = @IdUsuario 
                  AND Data_Venda BETWEEN @Inicio AND @Fim";

            var result = DatabaseHelper.ExecuteScalar(query,
                new SqlParameter("@IdUsuario", UserSession.IdUsuario),
                new SqlParameter("@Inicio", inicio.Date),
                new SqlParameter("@Fim", fim.Date.AddDays(1).AddSeconds(-1)));

            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        /// <summary>
        /// Cancela venda e restaura estoque
        /// </summary>
        public bool CancelarVenda(int idVenda)
        {
            UserSession.VerificarSessao();

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Obter info da venda
                        var vendaInfo = ObterInformacoesVenda(idVenda, connection, transaction);
                        if (vendaInfo == null)
                            throw new Exception("Venda não encontrada.");

                        // Restaurar estoque
                        string queryEstoque = @"
                            UPDATE Produto 
                            SET Quantidade_Prod = Quantidade_Prod + @Quantidade
                            WHERE Id_Prod = @IdProduto AND Id_Usuario = @IdUsuario";

                        using (var cmd = new SqlCommand(queryEstoque, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@Quantidade", vendaInfo.Quantidade);
                            cmd.Parameters.AddWithValue("@IdProduto", vendaInfo.IdProduto);
                            cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);
                            cmd.ExecuteNonQuery();
                        }

                        // Excluir venda
                        string queryDelete = @"
                            DELETE FROM Venda 
                            WHERE Id_Venda = @IdVenda AND Id_Usuario = @IdUsuario";

                        using (var cmd = new SqlCommand(queryDelete, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@IdVenda", idVenda);
                            cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // ========== MÉTODOS PRIVADOS ==========
        private ProdutoInfo ObterInformacoesProduto(int idProduto, SqlConnection conn, SqlTransaction trans)
        {
            string query = @"
                SELECT Preco_Ven, Quantidade_Prod 
                FROM Produto 
                WHERE Id_Prod = @IdProduto AND Id_Usuario = @IdUsuario";

            using (var cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@IdProduto", idProduto);
                cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ProdutoInfo
                        {
                            Preco = Convert.ToDecimal(reader["Preco_Ven"]),
                            Estoque = Convert.ToInt32(Convert.ToDecimal(reader["Quantidade_Prod"]))
                        };
                    }
                }
            }
            return null;
        }

        private VendaInfo ObterInformacoesVenda(int idVenda, SqlConnection conn, SqlTransaction trans)
        {
            string query = @"
                SELECT Id_Produto, Quantidade 
                FROM Venda 
                WHERE Id_Venda = @IdVenda AND Id_Usuario = @IdUsuario";

            using (var cmd = new SqlCommand(query, conn, trans))
            {
                cmd.Parameters.AddWithValue("@IdVenda", idVenda);
                cmd.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new VendaInfo
                        {
                            IdProduto = Convert.ToInt32(reader["Id_Produto"]),
                            Quantidade = Convert.ToInt32(reader["Quantidade"])
                        };
                    }
                }
            }
            return null;
        }

        private class ProdutoInfo
        {
            public decimal Preco { get; set; }
            public int Estoque { get; set; }
        }

        private class VendaInfo
        {
            public int IdProduto { get; set; }
            public int Quantidade { get; set; }
        }
    }
}