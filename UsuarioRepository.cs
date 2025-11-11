using System;
using System.Data;
using System.Data.SqlClient;
using ControleDeEstoque.Data;

namespace ControleDeEstoque.Data.Repositories
{
    public class UsuarioRepository
    {
        /// <summary>
        /// Valida login e retorna dados do usuário
        /// </summary>
        public Usuario ValidarLoginCompleto(string email, string senha)
        {
            // CORRIGIDO: Nome da coluna para Id_Usuario
            const string query = @"
                SELECT Id_Usuario, Nome, Email
                FROM Usuario 
                WHERE Email = @Email AND Senha = @Senha";

            var parameters = new[]
            {
                new SqlParameter("@Email", email),
                new SqlParameter("@Senha", senha)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Usuario
                {
                    Id = Convert.ToInt32(row["Id_Usuario"]),
                    Nome = row["Nome"].ToString(),
                    Email = row["Email"].ToString()
                };
            }

            return null;
        }

        /// <summary>
        /// Valida apenas se credenciais existem
        /// </summary>
        public bool ValidarLogin(string email, string senha)
        {
            return ValidarLoginCompleto(email, senha) != null;
        }

        public bool EmailExiste(string email)
        {
            const string query = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";
            var count = (int)DatabaseHelper.ExecuteScalar(query,
                new SqlParameter("@Email", email));
            return count > 0;
        }

        public bool CpfExiste(string cpf)
        {
            const string query = "SELECT COUNT(*) FROM Usuario WHERE Cpf = @Cpf";
            var count = (int)DatabaseHelper.ExecuteScalar(query,
                new SqlParameter("@Cpf", cpf));
            return count > 0;
        }

        public bool CadastrarUsuario(Usuario usuario)
        {
            const string query = @"
                INSERT INTO Usuario 
                (Nome, Nascimento, Cpf, Rg, Email, Telefone, Cidade, Rua, Uf, Cep, Pais, Senha) 
                VALUES 
                (@Nome, @Nascimento, @Cpf, @Rg, @Email, @Telefone, @Cidade, @Rua, @Uf, @Cep, @Pais, @Senha)";

            var parameters = new[]
            {
                new SqlParameter("@Nome", usuario.Nome),
                new SqlParameter("@Nascimento", (object)usuario.Nascimento ?? DBNull.Value),
                new SqlParameter("@Cpf", (object)usuario.Cpf ?? DBNull.Value),
                new SqlParameter("@Rg", (object)usuario.Rg ?? DBNull.Value),
                new SqlParameter("@Email", usuario.Email),
                new SqlParameter("@Telefone", (object)usuario.Telefone ?? DBNull.Value),
                new SqlParameter("@Cidade", (object)usuario.Cidade ?? DBNull.Value),
                new SqlParameter("@Rua", (object)usuario.Rua ?? DBNull.Value),
                new SqlParameter("@Uf", (object)usuario.Uf ?? DBNull.Value),
                new SqlParameter("@Cep", (object)usuario.Cep ?? DBNull.Value),
                new SqlParameter("@Pais", (object)usuario.Pais ?? DBNull.Value),
                new SqlParameter("@Senha", usuario.Senha)
            };

            return DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
        }
    }

    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
        public string Pais { get; set; }
        public string Senha { get; set; }
    }
}