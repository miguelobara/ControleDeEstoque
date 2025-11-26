// ====================================
// Program.cs - REFATORADO
// ====================================
using System;
using System.Windows.Forms;
using ControleDeEstoque.Core;
using ControleDeEstoque.Forms;

namespace ControleDeEstoque
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Inicializa o núcleo do aplicativo
            AppCore.Initialize();

            try
            {
                Logger.Info($"=== {AppCore.APP_NAME} v{AppCore.APP_VERSION} INICIADO ===");

                // Abre tela de login
                using (var loginForm = new Form1())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        // Usuário logado, abre menu principal
                        Application.Run(new Form2());
                    }
                }

                Logger.Info("Aplicativo encerrado normalmente");
            }
            catch (Exception ex)
            {
                Logger.Error("Erro fatal no aplicativo", ex);
                MessageBox.Show(
                    $"Erro fatal:\n{ex.Message}\n\nO aplicativo será encerrado.",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
