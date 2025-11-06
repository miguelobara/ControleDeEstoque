using System;
using System.Data;
using System.Data.SqlClient;

namespace ControleDeEstoque.Data.Repositories
{
    /// <summary>
    /// Repositório para operações de usuários no banco de dados
    /// </summary>
    public class UsuarioRepository
    {
        /// <summary>
        /// Valida credenciais de login
        /// </summary>
        public bool ValidarLogin(string email, string senha)
        {
            const string query = @"
                SELECT COUNT(*) 
                FROM Usuario 
                WHERE Email = @Email AND Senha = @Senha";

            var parameters = new[]
            {
                new SqlParameter("@Email", email),
                new SqlParameter("@Senha", senha)
            };

            var count = (int)DatabaseHelper.ExecuteScalar(query, parameters);
            return count > 0;
        }

        /// <summary>
        /// Verifica se email já está cadastrado
        /// </summary>
        public bool EmailExiste(string email)
        {
            const string query = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";
            var count = (int)DatabaseHelper.ExecuteScalar(query,
                new SqlParameter("@Email", email));
            return count > 0;
        }

        /// <summary>
        /// Verifica se CPF já está cadastrado
        /// </summary>
        public bool CpfExiste(string cpf)
        {
            const string query = "SELECT COUNT(*) FROM Usuario WHERE Cpf = @Cpf";
            var count = (int)DatabaseHelper.ExecuteScalar(query,
                new SqlParameter("@Cpf", cpf));
            return count > 0;
        }

        /// <summary>
        /// Cadastra novo usuário no sistema
        /// </summary>
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

    /// <summary>
    /// Modelo de dados para Usuário
    /// </summary>
    public class Usuario
    {
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