using System;

namespace ControleDeEstoque
{
    /// <summary>
    /// Classe estática para gerenciar a sessão do usuário logado
    /// </summary>
    public static class UserSession
    {
        public static int IdUsuario { get; private set; }
        public static string Nome { get; private set; }
        public static string Email { get; private set; }
        public static bool EstaLogado { get; private set; }

        /// <summary>
        /// Inicia uma nova sessão de usuário
        /// </summary>
        public static void IniciarSessao(int idUsuario, string nome, string email)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            EstaLogado = true;
        }

        /// <summary>
        /// Encerra a sessão do usuário
        /// </summary>
        public static void EncerrarSessao()
        {
            IdUsuario = 0;
            Nome = string.Empty;
            Email = string.Empty;
            EstaLogado = false;
        }

        /// <summary>
        /// Verifica se há um usuário logado
        /// </summary>
        public static void VerificarSessao()
        {
            if (!EstaLogado)
            {
                throw new InvalidOperationException("Nenhum usuário está logado no sistema.");
            }
        }
    }
}