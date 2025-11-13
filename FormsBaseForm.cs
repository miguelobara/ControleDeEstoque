using System;
using System.Drawing;
using System.Windows.Forms;
using ControleDeEstoque.Core;

namespace ControleDeEstoque.Forms
{
    /// <summary>
    /// Formulário base com funcionalidades comuns
    /// </summary>
    public class BaseForm : Form
    {
        protected Panel PanelHeader;
        protected Label LblTitle;
        protected Button BtnBack;
        protected string OriginalTitle;

        public BaseForm()
        {
            InitializeBase();
            ConfigureEvents();
        }

        private void InitializeBase()
        {
            // Configurações gerais
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.Silver;
            this.Font = new Font("Segoe UI", 9F);

            // Header
            PanelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = AppCore.PrimaryColor
            };

            LblTitle = new Label
            {
                Dock = DockStyle.Fill,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            BtnBack = new Button
            {
                Text = "← Voltar",
                Location = new Point(10, 15),
                Size = new Size(90, 30),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            BtnBack.FlatAppearance.BorderSize = 0;
            BtnBack.Click += (s, e) => Close();

            PanelHeader.Controls.Add(LblTitle);
            PanelHeader.Controls.Add(BtnBack);
            this.Controls.Add(PanelHeader);

            OriginalTitle = this.Text;
        }

        private void ConfigureEvents()
        {
            this.Load += BaseForm_Load;
            this.FormClosing += BaseForm_FormClosing;
            this.KeyPreview = true;
            this.KeyDown += BaseForm_KeyDown;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            try
            {
                UserSession.VerificarSessao();
                LblTitle.Text = this.Text;
                OnFormLoad();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Erro ao carregar formulário");
                this.Close();
            }
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && HasUnsavedChanges())
            {
                if (!AppCore.Confirm("Existem alterações não salvas. Deseja sair mesmo assim?"))
                {
                    e.Cancel = true;
                    return;
                }
            }

            OnFormClosing();
        }

        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Atalhos globais
            if (e.Control && e.KeyCode == Keys.S)
            {
                e.Handled = true;
                OnSaveShortcut();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                Close();
            }
            else if (e.KeyCode == Keys.F5)
            {
                e.Handled = true;
                OnRefreshShortcut();
            }
        }

        // ============ MÉTODOS VIRTUAIS PARA OVERRIDE ============

        protected virtual void OnFormLoad() { }
        protected virtual void OnFormClosing() { }
        protected virtual bool HasUnsavedChanges() => false;
        protected virtual void OnSaveShortcut() { }
        protected virtual void OnRefreshShortcut() { }

        // ============ MÉTODOS AUXILIARES ============

        protected void ShowLoader(string message = "Carregando...")
        {
            this.ShowLoader(message);
        }

        protected void HideLoader()
        {
            this.HideLoader(OriginalTitle);
        }

        protected bool ValidateRequired(Control control, string fieldName)
        {
            if (control is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
            {
                AppCore.ShowWarning($"{fieldName} é obrigatório");
                control.Focus();
                return false;
            }

            if (control is ComboBox cb && cb.SelectedIndex <= 0)
            {
                AppCore.ShowWarning($"{fieldName} é obrigatório");
                control.Focus();
                return false;
            }

            return true;
        }

        protected void ClearForm()
        {
            foreach (Control control in this.Controls)
                ClearControl(control);
        }

        private void ClearControl(Control control)
        {
            if (control is TextBox tb)
                tb.Clear();
            else if (control is ComboBox cb)
                cb.SelectedIndex = -1;
            else if (control is NumericUpDown nud)
                nud.Value = nud.Minimum;
            else if (control is CheckBox chk)
                chk.Checked = false;
            else if (control is DateTimePicker dtp)
                dtp.Value = DateTime.Now;

            if (control.HasChildren)
            {
                foreach (Control child in control.Controls)
                    ClearControl(child);
            }
        }
    }

    /// <summary>
    /// Formulário base para CRUDs
    /// </summary>
    public abstract class BaseCrudForm<T> : BaseForm where T : class, new()
    {
        protected DataGridView Grid;
        protected Panel PanelForm;
        protected Panel PanelButtons;
        protected Button BtnSave, BtnEdit, BtnDelete, BtnNew, BtnRefresh;

        protected bool EditMode = false;
        protected T CurrentItem;

        public BaseCrudForm()
        {
            InitializeCrudComponents();
        }

        private void InitializeCrudComponents()
        {
            // Grid
            Grid = new DataGridView
            {
                Dock = DockStyle.Fill,
                Location = new Point(0, 0)
            };
            Grid.ConfigureGrid();
            Grid.SelectionChanged += Grid_SelectionChanged;

            // Panel de formulário
            PanelForm = new Panel
            {
                Dock = DockStyle.Left,
                Width = 400,
                Padding = new Padding(10),
                BackColor = Color.White
            };

            // Panel de botões
            PanelButtons = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                BackColor = Color.Gainsboro,
                Padding = new Padding(10)
            };

            // Botões
            BtnSave = CreateButton("Salvar", 0, AppCore.PrimaryColor);
            BtnSave.Click += (s, e) => SaveItem();

            BtnEdit = CreateButton("Editar", 110, AppCore.InfoColor);
            BtnEdit.Click += (s, e) => EnterEditMode();

            BtnDelete = CreateButton("Deletar", 220, AppCore.DangerColor);
            BtnDelete.Click += (s, e) => DeleteItem();

            BtnNew = CreateButton("Novo", 330, AppCore.SecondaryColor);
            BtnNew.Click += (s, e) => EnterNewMode();

            BtnRefresh = CreateButton("Atualizar", 440, Color.Gray);
            BtnRefresh.Click += (s, e) => RefreshGrid();

            PanelButtons.Controls.AddRange(new[] { BtnSave, BtnEdit, BtnDelete, BtnNew, BtnRefresh });

            this.Controls.Add(Grid);
            this.Controls.Add(PanelForm);
            this.Controls.Add(PanelButtons);
            this.Controls.Add(PanelHeader);
        }

        private Button CreateButton(string text, int x, Color color)
        {
            var btn = new Button
            {
                Text = text,
                Location = new Point(x + 10, 10),
                Size = new Size(100, 35),
                BackColor = color,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btn.FlatAppearance.BorderSize = 0;
            return btn;
        }

        protected override void OnFormLoad()
        {
            base.OnFormLoad();
            RefreshGrid();
            SetupFormControls();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid.SelectedRows.Count > 0 && !EditMode)
            {
                CurrentItem = GetSelectedItem();
                if (CurrentItem != null)
                    LoadItemToForm(CurrentItem);
            }
        }

        private void EnterEditMode()
        {
            if (CurrentItem == null)
            {
                AppCore.ShowWarning("Selecione um item para editar");
                return;
            }

            EditMode = true;
            BtnSave.Text = "Salvar Edição";
            BtnEdit.Enabled = false;
            this.BackColor = Color.LightYellow;
        }

        private void EnterNewMode()
        {
            EditMode = false;
            CurrentItem = new T();
            ClearForm();
            BtnSave.Text = "Salvar Novo";
            BtnEdit.Enabled = false;
        }

        private void ExitEditMode()
        {
            EditMode = false;
            BtnSave.Text = "Salvar";
            BtnEdit.Enabled = true;
            this.BackColor = Color.Silver;
        }

        protected override void OnSaveShortcut() => SaveItem();
        protected override void OnRefreshShortcut() => RefreshGrid();

        private void SaveItem()
        {
            if (!ValidateForm())
                return;

            try
            {
                ShowLoader("Salvando...");

                T item = GetFormData();
                bool success = EditMode ? UpdateItem(item) : InsertItem(item);

                if (success)
                {
                    AppCore.ShowSuccess($"Item {(EditMode ? "atualizado" : "salvo")} com sucesso!");
                    RefreshGrid();
                    ExitEditMode();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Erro ao salvar");
            }
            finally
            {
                HideLoader();
            }
        }

        private void DeleteItem()
        {
            if (CurrentItem == null)
            {
                AppCore.ShowWarning("Selecione um item para deletar");
                return;
            }

            if (!AppCore.Confirm("Tem certeza que deseja deletar este item?"))
                return;

            try
            {
                ShowLoader("Deletando...");

                if (DeleteItemFromDb(CurrentItem))
                {
                    AppCore.ShowSuccess("Item deletado com sucesso!");
                    RefreshGrid();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Erro ao deletar");
            }
            finally
            {
                HideLoader();
            }
        }

        private void RefreshGrid()
        {
            try
            {
                ShowLoader("Carregando...");
                Grid.DataSource = LoadData();
                ConfigureGridColumns();
            }
            catch (Exception ex)
            {
                ErrorHandler.HandleException(ex, "Erro ao carregar dados");
            }
            finally
            {
                HideLoader();
            }
        }

        // ============ MÉTODOS ABSTRATOS ============

        protected abstract void SetupFormControls();
        protected abstract object LoadData();
        protected abstract void ConfigureGridColumns();
        protected abstract T GetSelectedItem();
        protected abstract void LoadItemToForm(T item);
        protected abstract T GetFormData();
        protected abstract bool ValidateForm();
        protected abstract bool InsertItem(T item);
        protected abstract bool UpdateItem(T item);
        protected abstract bool DeleteItemFromDb(T item);
    }
}