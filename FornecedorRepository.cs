using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ControleDeEstoque.Data;

namespace ControleDeEstoque.Data.Repositories
{
    public class FornecedorRepository
    {
        /// <summary>
        /// Obtém APENAS fornecedores do usuário logado
        /// </summary>
        public DataTable ObterTodosFornecedores()
        {
            UserSession.VerificarSessao();

            const string query = @"
                SELECT 
                    Id_Fornecedor, 
                    Nome_For, 
                    Cnpj_For, 
                    Telefone_For, 
                    Email_For, 
                    Cidade_For, 
                    Rua_For, 
                    Cep_For, 
                    Data_Cadastro_For, 
                    estatus_For,
                    Id_Usuario
                FROM Fornecedor
                WHERE Id_Usuario = @IdUsuario
                ORDER BY Nome_For";

            return DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@IdUsuario", UserSession.IdUsuario));
        }

        /// <summary>
        /// Obtém fornecedores ativos do usuário para ComboBox
        /// </summary>
        public Dictionary<int, string> ObterFornecedoresParaCombo()
        {
            UserSession.VerificarSessao();

            const string query = @"
                SELECT Id_Fornecedor, Nome_For 
                FROM Fornecedor 
                WHERE estatus_For = 'A' AND Id_Usuario = @IdUsuario
                ORDER BY Nome_For";

            var fornecedores = new Dictionary<int, string>();
            var dataTable = DatabaseHelper.ExecuteQuery(query,
                new SqlParameter("@IdUsuario", UserSession.IdUsuario));

            foreach (DataRow row in dataTable.Rows)
            {
                fornecedores.Add(
                    Convert.ToInt32(row["Id_Fornecedor"]),
                    row["Nome_For"].ToString()
                );
            }

            return fornecedores;
        }

        /// <summary>
        /// Insere fornecedor vinculado ao usuário logado
        /// </summary>
        public bool InserirFornecedor(Fornecedor fornecedor)
        {
            UserSession.VerificarSessao();

            const string query = @"
                DECLARE @NextID INT;
                SELECT @NextID = ISNULL(MAX(Id_Fornecedor), 0) + 1 FROM Fornecedor;

                INSERT INTO Fornecedor 
                (Id_Fornecedor, Nome_For, Cnpj_For, Telefone_For, Email_For, 
                 Cidade_For, Rua_For, Cep_For, Data_Cadastro_For, estatus_For, Id_Usuario)
                VALUES 
                (@NextID, @Nome, @Cnpj, @Telefone, @Email, 
                 @Cidade, @Rua, @Cep, @DataCadastro, @Estatus, @IdUsuario)";

            var parameters = new[]
            {
                new SqlParameter("@Nome", fornecedor.Nome ?? (object)DBNull.Value),
                new SqlParameter("@Cnpj", fornecedor.Cnpj ?? (object)DBNull.Value),
                new SqlParameter("@Telefone", fornecedor.Telefone ?? (object)DBNull.Value),
                new SqlParameter("@Email", fornecedor.Email ?? (object)DBNull.Value),
                new SqlParameter("@Cidade", fornecedor.Cidade ?? (object)DBNull.Value),
                new SqlParameter("@Rua", fornecedor.Rua ?? (object)DBNull.Value),
                new SqlParameter("@Cep", fornecedor.Cep ?? (object)DBNull.Value),
                new SqlParameter("@DataCadastro", fornecedor.DataCadastro),
                new SqlParameter("@Estatus", fornecedor.Estatus ?? "A"),
                new SqlParameter("@IdUsuario", UserSession.IdUsuario)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Verifica se já existe um fornecedor com o mesmo CNPJ para o usuário
        /// </summary>
        public bool ExisteFornecedorPorCnpj(string cnpj)
        {
            UserSession.VerificarSessao();

            const string query = @"
                SELECT COUNT(1) 
                FROM Fornecedor 
                WHERE Cnpj_For = @Cnpj AND Id_Usuario = @IdUsuario";

            var parameters = new[]
            {
                new SqlParameter("@Cnpj", cnpj),
                new SqlParameter("@IdUsuario", UserSession.IdUsuario)
            };

            var result = DatabaseHelper.ExecuteScalar(query, parameters);
            return Convert.ToInt32(result) > 0;
        }
    }

    public class Fornecedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public string Estatus { get; set; } = "A";
    }
}