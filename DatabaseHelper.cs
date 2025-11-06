using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ControleDeEstoque.Data
{
    /// <summary>
    /// Classe centralizada para gerenciamento de conexões com o banco de dados
    /// </summary>
    public static class DatabaseHelper
    {
        // Centraliza a string de conexão em um único lugar
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

        /// <summary>
        /// Executa uma query que não retorna dados (INSERT, UPDATE, DELETE)
        /// </summary>
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
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

        /// <summary>
        /// Executa uma query que retorna um único valor (COUNT, MAX, etc)
        /// </summary>
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
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
    }
}