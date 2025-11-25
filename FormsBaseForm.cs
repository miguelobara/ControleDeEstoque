using System;
using System.Drawing;
using System.Windows.Forms;

namespace ControleDeEstoque.Forms
{
    /// <summary>
    /// Formulário base SIMPLIFICADO com funcionalidades comuns
    /// </summary>
    public partial class BaseForm : Form
    {
        protected Panel PanelHeader;
        protected Label LblTitle;
        protected Button BtnBack;

        public BaseForm()
        {
            InitializeBase();
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
                BackColor = Color.RoyalBlue
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
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LblTitle.Text = this.Text;

            try
            {
                UserSession.VerificarSessao();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        protected bool ValidateRequired(Control control, string fieldName)
        {
            if (control is TextBox tb && string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show($"{fieldName} é obrigatório", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                control.Focus();
                return false;
            }

            if (control is ComboBox cb && cb.SelectedIndex <= 0)
            {
                MessageBox.Show($"{fieldName} é obrigatório", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
}