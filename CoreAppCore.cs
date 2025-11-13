using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

namespace ControleDeEstoque.Core
{
    /// <summary>
    /// Núcleo do aplicativo - Gerencia configurações globais e recursos compartilhados
    /// </summary>
    public static class AppCore
    {
        // Configurações
        public const string APP_NAME = "Controle de Estoque Pro";
        public const string APP_VERSION = "2.0";
        public const int SESSION_TIMEOUT_MINUTES = 60;
        public const int CACHE_DURATION_MINUTES = 10;

        // Cores do tema
        public static readonly Color PrimaryColor = Color.RoyalBlue;
        public static readonly Color SecondaryColor = Color.Green;
        public static readonly Color DangerColor = Color.Crimson;
        public static readonly Color WarningColor = Color.Orange;
        public static readonly Color SuccessColor = Color.DarkGreen;
        public static readonly Color InfoColor = Color.SteelBlue;

        // Cache simples para dados frequentes
        private static Dictionary<string, CacheItem> _cache = new Dictionary<string, CacheItem>();

        /// <summary>
        /// Inicializa o aplicativo
        /// </summary>
        public static void Initialize()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ConfigurarEventosGlobais();
            Logger.Info("Aplicativo iniciado");
        }

        /// <summary>
        /// Configura tratamento global de erros
        /// </summary>
        private static void ConfigurarEventosGlobais()
        {
            Application.ThreadException += (s, e) =>
                ErrorHandler.HandleException(e.Exception, "Erro não tratado");

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                ErrorHandler.HandleException(e.ExceptionObject as Exception, "Erro fatal");
        }

        // ============ CACHE ============
        public static void CacheSet<T>(string key, T value, int minutesValid = CACHE_DURATION_MINUTES)
        {
            _cache[key] = new CacheItem
            {
                Data = value,
                Expiration = DateTime.Now.AddMinutes(minutesValid)
            };
        }

        public static T CacheGet<T>(string key) where T : class
        {
            if (_cache.TryGetValue(key, out CacheItem item))
            {
                if (item.Expiration > DateTime.Now)
                    return item.Data as T;

                _cache.Remove(key);
            }
            return null;
        }

        public static void CacheClear() => _cache.Clear();

        // ============ UTILITÁRIOS ============
        public static void ShowSuccess(string message, string title = "Sucesso") =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void ShowError(string message, string title = "Erro") =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void ShowWarning(string message, string title = "Atenção") =>
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static bool Confirm(string message, string title = "Confirmar") =>
            MessageBox.Show(message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

        // ============ FORMATAÇÃO ============
        public static string FormatCurrency(decimal value) => value.ToString("C2");
        public static string FormatDate(DateTime date) => date.ToString("dd/MM/yyyy");
        public static string FormatDateTime(DateTime date) => date.ToString("dd/MM/yyyy HH:mm");
        public static string FormatPercent(decimal value) => value.ToString("F2") + "%";

        private class CacheItem
        {
            public object Data { get; set; }
            public DateTime Expiration { get; set; }
        }
    }

    /// <summary>
    /// Logger simples para debug e auditoria
    /// </summary>
    public static class Logger
    {
        private static readonly string LogPath = "app.log";
        private static readonly object lockObj = new object();

        public static void Info(string message) => Log("INFO", message);
        public static void Warning(string message) => Log("WARN", message);
        public static void Error(string message, Exception ex = null) =>
            Log("ERROR", $"{message}{(ex != null ? $"\n{ex}" : "")}");

        private static void Log(string level, string message)
        {
            try
            {
                lock (lockObj)
                {
                    string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] {message}";
                    System.Diagnostics.Debug.WriteLine(logMessage);

                    // Descomente para salvar em arquivo:
                    // System.IO.File.AppendAllText(LogPath, logMessage + Environment.NewLine);
                }
            }
            catch { /* Não pode falhar */ }
        }
    }

    /// <summary>
    /// Tratador centralizado de erros
    /// </summary>
    public static class ErrorHandler
    {
        public static void HandleException(Exception ex, string context = "")
        {
            string message = string.IsNullOrEmpty(context)
                ? ex?.Message ?? "Erro desconhecido"
                : $"{context}:\n{ex?.Message ?? "Erro desconhecido"}";

            Logger.Error(context, ex);
            AppCore.ShowError(message);
        }

        public static bool TryExecute(Action action, string errorMessage = "Erro ao executar operação")
        {
            try
            {
                action();
                return true;
            }
            catch (Exception ex)
            {
                HandleException(ex, errorMessage);
                return false;
            }
        }

        public static T TryExecute<T>(Func<T> func, T defaultValue = default, string errorMessage = "")
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                HandleException(ex, errorMessage);
                return defaultValue;
            }
        }
    }

    /// <summary>
    /// Extensões úteis para WinForms
    /// </summary>
    public static class WinFormsExtensions
    {
        public static void ApplyTheme(this Form form)
        {
            form.BackColor = Color.Silver;
            form.Font = new Font("Segoe UI", 9F);
        }

        public static void StylePrimaryButton(this Button btn)
        {
            btn.BackColor = AppCore.PrimaryColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
        }

        public static void StyleSecondaryButton(this Button btn)
        {
            btn.BackColor = AppCore.SecondaryColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
        }

        public static void StyleDangerButton(this Button btn)
        {
            btn.BackColor = AppCore.DangerColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
        }

        public static void ConfigureGrid(this DataGridView grid)
        {
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = AppCore.PrimaryColor;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
        }

        public static void ShowLoader(this Form form, string message = "Carregando...")
        {
            form.Cursor = Cursors.WaitCursor;
            form.Text = $"{form.Text} - {message}";
        }

        public static void HideLoader(this Form form, string originalTitle)
        {
            form.Cursor = Cursors.Default;
            form.Text = originalTitle;
        }
    }
}