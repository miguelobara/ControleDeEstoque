using System;
using System.Data;
using System.Data.SqlClient;

namespace ControleDeEstoque.Data
{
    /// <summary>
    /// Classe centralizada para gerenciamento de conexões com o banco de dados
    /// MELHORADA: Adiciona logs, melhor tratamento de erros e transações
    /// </summary>
    public static class DatabaseHelper
    {
        private static readonly string ConnectionString =
            "Data Source=SQLEXPRESS;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

        /// <summary>
        /// Cria e retorna uma nova conexão com o banco de dados
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Executa uma query que retorna dados (SELECT)
        /// </summary>
        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
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
            catch (SqlException ex)
            {
                LogError("ExecuteQuery", query, ex);
                throw new Exception($"Erro ao executar consulta: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Executa uma query que não retorna dados (INSERT, UPDATE, DELETE)
        /// </summary>
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                LogError("ExecuteNonQuery", query, ex);
                throw new Exception($"Erro ao executar comando: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Executa uma query que retorna um único valor (COUNT, MAX, etc)
        /// </summary>
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
            catch (SqlException ex)
            {
                LogError("ExecuteScalar", query, ex);
                throw new Exception($"Erro ao executar consulta escalar: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// NOVO: Executa múltiplas operações em uma transação
        /// </summary>
        public static bool ExecuteTransaction(Action<SqlConnection, SqlTransaction> operations)
        {
            using (var connection = GetConnection())
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
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        LogError("ExecuteTransaction", "Transaction", ex);
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Verifica se a conexão com o banco está funcionando
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// NOVO: Verifica se uma tabela existe
        /// </summary>
        public static bool TableExists(string tableName)
        {
            try
            {
                string query = @"
                    SELECT COUNT(*) 
                    FROM INFORMATION_SCHEMA.TABLES 
                    WHERE TABLE_NAME = @TableName";

                var result = ExecuteScalar(query, new SqlParameter("@TableName", tableName));
                return Convert.ToInt32(result) > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// NOVO: Log de erros (pode ser expandido para arquivo/banco)
        /// </summary>
        private static void LogError(string method, string query, Exception ex)
        {
            string logMessage = $@"
=== ERRO NO BANCO DE DADOS ===
Método: {method}
Data/Hora: {DateTime.Now}
Query: {query}
Erro: {ex.Message}
StackTrace: {ex.StackTrace}
================================";

            System.Diagnostics.Debug.WriteLine(logMessage);
            // TODO: Implementar log em arquivo se necessário
        }

        /// <summary>
        /// NOVO: Backup do banco de dados
        /// </summary>
        public static bool BackupDatabase(string backupPath)
        {
            try
            {
                string query = $@"
                    BACKUP DATABASE CJ3027511PR2 
                    TO DISK = @BackupPath 
                    WITH FORMAT, MEDIANAME = 'SQLServerBackups', 
                    NAME = 'Full Backup of CJ3027511PR2';";

                ExecuteNonQuery(query, new SqlParameter("@BackupPath", backupPath));
                return true;
            }
            catch (Exception ex)
            {
                LogError("BackupDatabase", backupPath, ex);
                return false;
            }
        }
    }
}