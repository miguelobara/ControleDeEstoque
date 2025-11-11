using System;
using System.Security.Cryptography;
using System.Text;

namespace ControleDeEstoque.Helpers
{
    /// <summary>
    /// NOVO: Helper para funcionalidades de segurança
    /// Inclui hash de senhas, geração de tokens, etc.
    /// </summary>
    public static class SecurityHelper
    {
        /// <summary>
        /// Gera hash SHA256 de uma senha
        /// USO FUTURO: Para substituir senhas em texto plano
        /// </summary>
        public static string HashSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha não pode ser vazia", nameof(senha));

            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        /// <summary>
        /// Verifica se uma senha corresponde ao hash
        /// </summary>
        public static bool VerificarSenha(string senha, string hashArmazenado)
        {
            if (string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(hashArmazenado))
                return false;

            string hashSenha = HashSenha(senha);
            return hashSenha.Equals(hashArmazenado, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Gera um salt aleatório para aumentar segurança
        /// </summary>
        public static string GerarSalt()
        {
            byte[] salt = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Gera hash com salt (mais seguro)
        /// </summary>
        public static string HashSenhaComSalt(string senha, string salt)
        {
            return HashSenha(senha + salt);
        }

        /// <summary>
        /// Valida força da senha
        /// </summary>
        public static PasswordStrength ValidarForcaSenha(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                return PasswordStrength.Invalida;

            int score = 0;

            // Comprimento
            if (senha.Length >= 8) score++;
            if (senha.Length >= 12) score++;

            // Maiúsculas
            if (System.Text.RegularExpressions.Regex.IsMatch(senha, @"[A-Z]"))
                score++;

            // Minúsculas
            if (System.Text.RegularExpressions.Regex.IsMatch(senha, @"[a-z]"))
                score++;

            // Números
            if (System.Text.RegularExpressions.Regex.IsMatch(senha, @"[0-9]"))
                score++;

            // Caracteres especiais
            if (System.Text.RegularExpressions.Regex.IsMatch(senha, @"[!@#$%^&*(),.?""':{}|<>]"))
                score++;

            if (score <= 2) return PasswordStrength.Fraca;
            if (score <= 4) return PasswordStrength.Media;
            return PasswordStrength.Forte;
        }

        /// <summary>
        /// Gera uma senha aleatória segura
        /// </summary>
        public static string GerarSenhaAleatoria(int comprimento = 12)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*";
            StringBuilder senha = new StringBuilder();

            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[comprimento];
                rng.GetBytes(randomBytes);

                foreach (byte b in randomBytes)
                {
                    senha.Append(chars[b % chars.Length]);
                }
            }

            return senha.ToString();
        }

        /// <summary>
        /// Protege string sensível (para logs)
        /// </summary>
        public static string MascararDados(string dados, int caracteresVisiveis = 4)
        {
            if (string.IsNullOrWhiteSpace(dados))
                return string.Empty;

            if (dados.Length <= caracteresVisiveis)
                return new string('*', dados.Length);

            return dados.Substring(0, caracteresVisiveis) +
                   new string('*', dados.Length - caracteresVisiveis);
        }

        /// <summary>
        /// Valida se string contém SQL injection
        /// </summary>
        public static bool ContemSQLInjection(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return false;

            string[] sqlKeywords = {
                "DROP", "DELETE", "INSERT", "UPDATE", "CREATE", "ALTER",
                "EXEC", "EXECUTE", "SCRIPT", "UNION", "SELECT", "--", "/*", "*/"
            };

            string upperInput = input.ToUpper();
            foreach (string keyword in sqlKeywords)
            {
                if (upperInput.Contains(keyword))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Sanitiza input do usuário
        /// </summary>
        public static string SanitizarInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Remove caracteres perigosos
            input = input.Replace("<", "&lt;")
                        .Replace(">", "&gt;")
                        .Replace("'", "&#39;")
                        .Replace("\"", "&quot;")
                        .Replace("&", "&amp;");

            return input.Trim();
        }

        /// <summary>
        /// Gera token de sessão único
        /// </summary>
        public static string GerarTokenSessao()
        {
            return Guid.NewGuid().ToString("N") +
                   DateTime.Now.Ticks.ToString("x");
        }

        /// <summary>
        /// Valida token de sessão
        /// </summary>
        public static bool ValidarToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return false;

            // Token deve ter pelo menos 32 caracteres
            if (token.Length < 32)
                return false;

            // Token deve ser alfanumérico
            return System.Text.RegularExpressions.Regex.IsMatch(token, @"^[a-zA-Z0-9]+$");
        }

        /// <summary>
        /// Criptografa string simples (para dados não sensíveis)
        /// NÃO usar para senhas - usar Hash
        /// </summary>
        public static string CriptografarString(string texto, string chave)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;

            byte[] textoBytes = Encoding.UTF8.GetBytes(texto);
            byte[] chaveBytes = Encoding.UTF8.GetBytes(chave.PadRight(32).Substring(0, 32));

            using (Aes aes = Aes.Create())
            {
                aes.Key = chaveBytes;
                aes.GenerateIV();

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    byte[] encrypted = encryptor.TransformFinalBlock(textoBytes, 0, textoBytes.Length);
                    byte[] resultado = new byte[aes.IV.Length + encrypted.Length];
                    Buffer.BlockCopy(aes.IV, 0, resultado, 0, aes.IV.Length);
                    Buffer.BlockCopy(encrypted, 0, resultado, aes.IV.Length, encrypted.Length);
                    return Convert.ToBase64String(resultado);
                }
            }
        }

        /// <summary>
        /// Descriptografa string
        /// </summary>
        public static string DescriptografarString(string textoCriptografado, string chave)
        {
            if (string.IsNullOrWhiteSpace(textoCriptografado))
                return string.Empty;

            try
            {
                byte[] dados = Convert.FromBase64String(textoCriptografado);
                byte[] chaveBytes = Encoding.UTF8.GetBytes(chave.PadRight(32).Substring(0, 32));

                using (Aes aes = Aes.Create())
                {
                    aes.Key = chaveBytes;
                    byte[] iv = new byte[16];
                    byte[] encrypted = new byte[dados.Length - 16];
                    Buffer.BlockCopy(dados, 0, iv, 0, 16);
                    Buffer.BlockCopy(dados, 16, encrypted, 0, encrypted.Length);
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                    {
                        byte[] decrypted = decryptor.TransformFinalBlock(encrypted, 0, encrypted.Length);
                        return Encoding.UTF8.GetString(decrypted);
                    }
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Log de atividades de segurança
        /// </summary>
        public static void LogAtividadeSeguranca(string acao, string usuario, bool sucesso)
        {
            string log = $@"
=== LOG DE SEGURANÇA ===
Data/Hora: {DateTime.Now}
Usuário: {usuario}
Ação: {acao}
Status: {(sucesso ? "SUCESSO" : "FALHA")}
========================";

            System.Diagnostics.Debug.WriteLine(log);

            // TODO: Pode salvar em arquivo ou banco se necessário
            // System.IO.File.AppendAllText("security.log", log + Environment.NewLine);
        }
    }

    /// <summary>
    /// Enum para força de senha
    /// </summary>
    public enum PasswordStrength
    {
        Invalida,
        Fraca,
        Media,
        Forte
    }

    /// <summary>
    /// EXEMPLO DE USO - Migração para senhas com hash
    /// </summary>
    public class ExemploMigracaoSeguranca
    {
        /*
        // 1. Adicionar coluna Salt na tabela Usuario
        ALTER TABLE Usuario ADD Salt VARCHAR(100) NULL;
        
        // 2. Atualizar UsuarioRepository.ValidarLoginCompleto
        public Usuario ValidarLoginCompleto(string email, string senha)
        {
            // Primeiro busca o salt do usuário
            string querySalt = "SELECT Id_Usu, Nome, Email, Salt FROM Usuario WHERE Email = @Email";
            DataTable dt = DatabaseHelper.ExecuteQuery(querySalt, 
                new SqlParameter("@Email", email));
            
            if (dt.Rows.Count == 0)
                return null;
            
            DataRow row = dt.Rows[0];
            string salt = row["Salt"]?.ToString() ?? "";
            
            // Gera hash da senha com o salt
            string senhaHash = SecurityHelper.HashSenhaComSalt(senha, salt);
            
            // Valida com o hash
            string queryValidar = @"
                SELECT Id_Usu, Nome, Email 
                FROM Usuario 
                WHERE Email = @Email AND Senha = @SenhaHash";
            
            DataTable dtValidacao = DatabaseHelper.ExecuteQuery(queryValidar,
                new SqlParameter("@Email", email),
                new SqlParameter("@SenhaHash", senhaHash));
            
            if (dtValidacao.Rows.Count > 0)
            {
                DataRow userRow = dtValidacao.Rows[0];
                return new Usuario
                {
                    Id = Convert.ToInt32(userRow["Id_Usu"]),
                    Nome = userRow["Nome"].ToString(),
                    Email = userRow["Email"].ToString()
                };
            }
            
            return null;
        }
        
        // 3. Atualizar CadastrarUsuario
        public bool CadastrarUsuario(Usuario usuario)
        {
            // Gera salt único para este usuário
            string salt = SecurityHelper.GerarSalt();
            
            // Gera hash da senha com o salt
            string senhaHash = SecurityHelper.HashSenhaComSalt(usuario.Senha, salt);
            
            // Valida força da senha antes de cadastrar
            var forca = SecurityHelper.ValidarForcaSenha(usuario.Senha);
            if (forca == PasswordStrength.Fraca)
            {
                throw new Exception("Senha muito fraca. Use letras maiúsculas, minúsculas, números e caracteres especiais.");
            }
            
            const string query = @"
                INSERT INTO Usuario 
                (Nome, Nascimento, Cpf, Rg, Email, Telefone, Cidade, Rua, Uf, Cep, Pais, Senha, Salt) 
                VALUES 
                (@Nome, @Nascimento, @Cpf, @Rg, @Email, @Telefone, @Cidade, @Rua, @Uf, @Cep, @Pais, @SenhaHash, @Salt)";
            
            var parameters = new[]
            {
                // ... outros parâmetros ...
                new SqlParameter("@SenhaHash", senhaHash),
                new SqlParameter("@Salt", salt)
            };
            
            bool sucesso = DatabaseHelper.ExecuteNonQuery(query, parameters) > 0;
            
            // Log de segurança
            SecurityHelper.LogAtividadeSeguranca("CADASTRO_USUARIO", usuario.Email, sucesso);
            
            return sucesso;
        }
        */
    }
}