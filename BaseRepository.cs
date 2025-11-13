using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ControleDeEstoque.Data.Repositories
{
    /// <summary>
    /// Repositório base genérico que elimina duplicação de código
    /// </summary>
    public abstract class BaseRepository<T> where T : class, new()
    {
        protected readonly string ConnectionString =
            "Data Source=SQLEXPRESS;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

        /// <summary>
        /// Executa query e retorna DataTable
        /// </summary>
        protected DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                var dataTable = new DataTable();
                var adapter = new SqlDataAdapter(command);
                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        /// <summary>
        /// Executa comando sem retorno (INSERT, UPDATE, DELETE)
        /// </summary>
        protected int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executa query que retorna valor único
        /// </summary>
        protected object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            using (var command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                return command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Executa transação com múltiplas operações
        /// </summary>
        protected bool ExecuteTransaction(Action<SqlConnection, SqlTransaction> operations)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        operations(connection, transaction);
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
        /// Cria parâmetro SQL com tratamento de nulos
        /// </summary>
        protected SqlParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        /// <summary>
        /// Verifica se registro existe
        /// </summary>
        protected bool Exists(string tableName, string column, object value)
        {
            var query = $"SELECT COUNT(*) FROM {tableName} WHERE {column} = @Value AND Id_Usuario = @IdUsuario";
            var count = (int)ExecuteScalar(query,
                CreateParameter("@Value", value),
                CreateParameter("@IdUsuario", UserSession.IdUsuario));
            return count > 0;
        }

        /// <summary>
        /// Obtém próximo ID disponível
        /// </summary>
        protected int GetNextId(string tableName, string idColumn)
        {
            var query = $"SELECT ISNULL(MAX({idColumn}), 0) + 1 FROM {tableName}";
            return Convert.ToInt32(ExecuteScalar(query));
        }

        /// <summary>
        /// Soft delete (inativa ao invés de deletar)
        /// </summary>
        protected bool SoftDelete(string tableName, string idColumn, int id)
        {
            var query = $@"UPDATE {tableName} 
                          SET Status = 'I', DataInativacao = @Data 
                          WHERE {idColumn} = @Id AND Id_Usuario = @IdUsuario";

            return ExecuteNonQuery(query,
                CreateParameter("@Id", id),
                CreateParameter("@Data", DateTime.Now),
                CreateParameter("@IdUsuario", UserSession.IdUsuario)) > 0;
        }

        /// <summary>
        /// Busca com paginação
        /// </summary>
        protected DataTable GetPaged(string query, int pageNumber, int pageSize, params SqlParameter[] parameters)
        {
            var pagedQuery = $@"{query}
                ORDER BY (SELECT NULL)
                OFFSET {(pageNumber - 1) * pageSize} ROWS
                FETCH NEXT {pageSize} ROWS ONLY";

            return ExecuteQuery(pagedQuery, parameters);
        }

        /// <summary>
        /// Conta total de registros
        /// </summary>
        protected int Count(string tableName, string whereClause = "", params SqlParameter[] parameters)
        {
            var query = $"SELECT COUNT(*) FROM {tableName} WHERE Id_Usuario = @IdUsuario";
            if (!string.IsNullOrEmpty(whereClause))
                query += $" AND {whereClause}";

            var paramList = new List<SqlParameter> { CreateParameter("@IdUsuario", UserSession.IdUsuario) };
            if (parameters != null)
                paramList.AddRange(parameters);

            return Convert.ToInt32(ExecuteScalar(query, paramList.ToArray()));
        }

        /// <summary>
        /// Busca por ID
        /// </summary>
        protected DataRow GetById(string tableName, string idColumn, int id)
        {
            var query = $@"SELECT * FROM {tableName} 
                          WHERE {idColumn} = @Id AND Id_Usuario = @IdUsuario";

            var dt = ExecuteQuery(query,
                CreateParameter("@Id", id),
                CreateParameter("@IdUsuario", UserSession.IdUsuario));

            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        /// <summary>
        /// Verifica sessão do usuário
        /// </summary>
        protected void VerificarSessao()
        {
            if (!UserSession.EstaLogado)
                throw new InvalidOperationException("Usuário não está logado");
        }
    }
}