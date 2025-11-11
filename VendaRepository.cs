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
                        // 1. Obter informações do produto (preço e estoque atual)
                        var produtoInfo = ObterInformacoesProduto(venda.IdProduto, connection, transaction);
                        if (produtoInfo == null)
                            throw new Exception("Produto não encontrado.");

                        decimal precoUnitario = produtoInfo.Preco;
                        int estoqueAtual = produtoInfo.Estoque;

                        // 2. Verificar se há estoque suficiente
                        if (estoqueAtual < venda.Quantidade)
                            throw new Exception($"Estoque insuficiente. Disponível: {estoqueAtual}");

                        // 3. Calcular valor total
                        decimal valorTotal = precoUnitario * venda.Quantidade;

                        // 4. Inserir venda
                        string queryVenda = @"
                            INSERT INTO Venda (
                                Id_Produto, Id_Usuario, Quantidade, 
                                Valor_Unitario, Valor_Total, Data_Venda
                            ) 
                            VALUES (
                                @IdProduto, @IdUsuario, @Quantidade, 
                                @ValorUnitario, @ValorTotal, @DataVenda
                            )";

                        using (var command = new SqlCommand(queryVenda, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@IdProduto", venda.IdProduto);
                            command.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);
                            command.Parameters.AddWithValue("@Quantidade", venda.Quantidade);
                            command.Parameters.AddWithValue("@ValorUnitario", precoUnitario);
                            command.Parameters.AddWithValue("@ValorTotal", valorTotal);
                            command.Parameters.AddWithValue("@DataVenda", DateTime.Now);

                            command.ExecuteNonQuery();
                        }

                        // 5. Atualizar estoque do produto
                        string queryAtualizarEstoque = @"
                            UPDATE Produto 
                            SET Quantidade_Prod = Quantidade_Prod - @Quantidade
                            WHERE Id_Prod = @IdProduto AND Id_Usuario = @IdUsuario";

                        using (var command = new SqlCommand(queryAtualizarEstoque, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Quantidade", venda.Quantidade);
                            command.Parameters.AddWithValue("@IdProduto", venda.IdProduto);
                            command.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Obtém histórico de vendas do usuário logado
        /// </summary>
        public DataTable ObterVendas(DateTime dataInicio, DateTime dataFim)
        {
            UserSession.VerificarSessao();

            const string query = @"
                SELECT 
                    v.Id_Venda,
                    p.Nome_Prod as Produto,
                    v.Quantidade,
                    v.Valor_Unitario,
                    v.Valor_Total,
                    v.Data_Venda,
                    u.Nome as Vendedor
                FROM Venda v
                INNER JOIN Produto p ON v.Id_Produto = p.Id_Prod
                INNER JOIN Usuario u ON v.Id_Usuario = u.Id_Usuario
                WHERE v.Id_Usuario = @IdUsuario 
                    AND v.Data_Venda BETWEEN @DataInicio AND @DataFim
                ORDER BY v.Data_Venda DESC";

            var parameters = new[]
            {
                new SqlParameter("@IdUsuario", UserSession.IdUsuario),
                new SqlParameter("@DataInicio", dataInicio.Date),
                new SqlParameter("@DataFim", dataFim.Date.AddDays(1).AddSeconds(-1))
            };

            return DatabaseHelper.ExecuteQuery(query, parameters);
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
                        // 1. Obter informações da venda
                        var vendaInfo = ObterInformacoesVenda(idVenda, connection, transaction);
                        if (vendaInfo == null)
                            throw new Exception("Venda não encontrada.");

                        // 2. Restaurar estoque
                        string queryRestaurarEstoque = @"
                            UPDATE Produto 
                            SET Quantidade_Prod = Quantidade_Prod + @Quantidade
                            WHERE Id_Prod = @IdProduto AND Id_Usuario = @IdUsuario";

                        using (var command = new SqlCommand(queryRestaurarEstoque, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@Quantidade", vendaInfo.Quantidade);
                            command.Parameters.AddWithValue("@IdProduto", vendaInfo.IdProduto);
                            command.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);
                            command.ExecuteNonQuery();
                        }

                        // 3. Excluir venda
                        string queryExcluirVenda = @"
                            DELETE FROM Venda 
                            WHERE Id_Venda = @IdVenda AND Id_Usuario = @IdUsuario";

                        using (var command = new SqlCommand(queryExcluirVenda, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@IdVenda", idVenda);
                            command.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Obtém totais de vendas para relatórios
        /// </summary>
        public decimal ObterTotalVendasPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            UserSession.VerificarSessao();

            const string query = @"
                SELECT ISNULL(SUM(Valor_Total), 0) 
                FROM Venda 
                WHERE Id_Usuario = @IdUsuario 
                    AND Data_Venda BETWEEN @DataInicio AND @DataFim";

            var parameters = new[]
            {
                new SqlParameter("@IdUsuario", UserSession.IdUsuario),
                new SqlParameter("@DataInicio", dataInicio.Date),
                new SqlParameter("@DataFim", dataFim.Date.AddDays(1).AddSeconds(-1))
            };

            var result = DatabaseHelper.ExecuteScalar(query, parameters);
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }

        // Métodos auxiliares privados
        private ProdutoInfo ObterInformacoesProduto(int idProduto, SqlConnection connection, SqlTransaction transaction)
        {
            const string query = @"
                SELECT Preco_Ven, Quantidade_Prod 
                FROM Produto 
                WHERE Id_Prod = @IdProduto AND Id_Usuario = @IdUsuario";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdProduto", idProduto);
                command.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);

                using (var reader = command.ExecuteReader())
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

        private VendaInfo ObterInformacoesVenda(int idVenda, SqlConnection connection, SqlTransaction transaction)
        {
            const string query = @"
                SELECT Id_Produto, Quantidade 
                FROM Venda 
                WHERE Id_Venda = @IdVenda AND Id_Usuario = @IdUsuario";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdVenda", idVenda);
                command.Parameters.AddWithValue("@IdUsuario", UserSession.IdUsuario);

                using (var reader = command.ExecuteReader())
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

        // Classes auxiliares
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