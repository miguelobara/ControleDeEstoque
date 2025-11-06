using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace ControleDeEstoque.Data.Repositories
{
    /// <summary>
    /// Repositório para operações de fornecedores no banco de dados
    /// </summary>
    public class FornecedorRepository
    {
        /// <summary>
        /// Obtém todos os fornecedores
        /// </summary>
        public DataTable ObterTodosFornecedores()
        {
            const string query = @"
                SELECT 
                    Id_Fornecedor, Nome_For, Cnpj_For, Telefone_For, 
                    Email_For, Cidade_For, Rua_For, Cep_For, 
                    Data_Cadastro_For, estatus_For
                FROM Fornecedor
                ORDER BY Nome_For";

            return DatabaseHelper.ExecuteQuery(query);
        }

        /// <summary>
        /// Obtém fornecedores para ComboBox (Id e Nome)
        /// </summary>
        public Dictionary<int, string> ObterFornecedoresParaCombo()
        {
            const string query = @"
                SELECT Id_Fornecedor, Nome_For 
                FROM Fornecedor 
                WHERE estatus_For = 'A'
                ORDER BY Nome_For";

            var fornecedores = new Dictionary<int, string>();
            var dataTable = DatabaseHelper.ExecuteQuery(query);

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
        /// Insere novo fornecedor
        /// </summary>
        public bool InserirFornecedor(Fornecedor fornecedor)
        {
            const string query = @"
                DECLARE @NextID INT;
                SELECT @NextID = ISNULL(MAX(Id_Fornecedor), 0) + 1 FROM Fornecedor;

                INSERT INTO Fornecedor 
                (Id_Fornecedor, Nome_For, Cnpj_For, Telefone_For, Email_For, 
                 Cidade_For, Rua_For, Cep_For, Data_Cadastro_For, estatus_For)
                VALUES 
                (@NextID, @Nome, @Cnpj, @Telefone, @Email, 
                 @Cidade, @Rua, @Cep, @DataCadastro, @Estatus)";

            var parameters = new[]
            {
                new SqlParameter("@Nome", fornecedor.Nome),
                new SqlParameter("@Cnpj", fornecedor.Cnpj),
                new SqlParameter("@Telefone", fornecedor.Telefone),
                new SqlParameter("@Email", fornecedor.Email),
                new SqlParameter("@Cidade", fornecedor.Cidade),
                new SqlParameter("@Rua", fornecedor.Rua),
                new SqlParameter("@Cep", fornecedor.Cep),
                new SqlParameter("@DataCadastro", fornecedor.DataCadastro),
                new SqlParameter("@Estatus", fornecedor.Estatus)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Atualiza fornecedor existente
        /// </summary>
        public bool AtualizarFornecedor(Fornecedor fornecedor)
        {
            const string query = @"
                UPDATE Fornecedor SET
                    Nome_For = @Nome,
                    Cnpj_For = @Cnpj,
                    Telefone_For = @Telefone,
                    Email_For = @Email,
                    Cidade_For = @Cidade,
                    Rua_For = @Rua,
                    Cep_For = @Cep,
                    estatus_For = @Estatus
                WHERE Id_Fornecedor = @Id";

            var parameters = new[]
            {
                new SqlParameter("@Id", fornecedor.Id),
                new SqlParameter("@Nome", fornecedor.Nome),
                new SqlParameter("@Cnpj", fornecedor.Cnpj),
                new SqlParameter("@Telefone", fornecedor.Telefone),
                new SqlParameter("@Email", fornecedor.Email),
                new SqlParameter("@Cidade", fornecedor.Cidade),
                new SqlParameter("@Rua", fornecedor.Rua),
                new SqlParameter("@Cep", fornecedor.Cep),
                new SqlParameter("@Estatus", fornecedor.Estatus)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }

        /// <summary>
        /// Inativa fornecedor (soft delete)
        /// </summary>
        public bool InativarFornecedor(int idFornecedor)
        {
            const string query = @"
                UPDATE Fornecedor 
                SET estatus_For = 'I' 
                WHERE Id_Fornecedor = @Id";

            return DatabaseHelper.ExecuteNonQuery(query, 
                new SqlParameter("@Id", idFornecedor)) > 0;
        }
    }

    /// <summary>
    /// Modelo de dados para Fornecedor
    /// </summary>
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
        public DateTime DataCadastro { get; set; }
        public string Estatus { get; set; } = "A";
    }
}