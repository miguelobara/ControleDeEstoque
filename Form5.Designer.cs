namespace ControleDeEstoque
{
    partial class Form5
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelForm = new System.Windows.Forms.Panel();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.tbxSenha1 = new System.Windows.Forms.TextBox();
            this.tbxEmail1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tbxCep = new System.Windows.Forms.MaskedTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbxPais = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxUf = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxCidade = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxRua = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbxRg = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxNascimento = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbxCpf = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxNome = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelMain.Controls.Add(this.panelForm);
            this.panelMain.Controls.Add(this.panelHeader);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(559, 650);
            this.panelMain.TabIndex = 0;
            // 
            // panelForm
            // 
            this.panelForm.AutoScroll = true;
            this.panelForm.BackColor = System.Drawing.Color.Silver;
            this.panelForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelForm.Controls.Add(this.btnCriar);
            this.panelForm.Controls.Add(this.btnVoltar);
            this.panelForm.Controls.Add(this.tbxSenha1);
            this.panelForm.Controls.Add(this.tbxEmail1);
            this.panelForm.Controls.Add(this.label18);
            this.panelForm.Controls.Add(this.label17);
            this.panelForm.Controls.Add(this.tbxCep);
            this.panelForm.Controls.Add(this.label16);
            this.panelForm.Controls.Add(this.tbxPais);
            this.panelForm.Controls.Add(this.label13);
            this.panelForm.Controls.Add(this.tbxUf);
            this.panelForm.Controls.Add(this.label10);
            this.panelForm.Controls.Add(this.tbxCidade);
            this.panelForm.Controls.Add(this.label15);
            this.panelForm.Controls.Add(this.tbxRua);
            this.panelForm.Controls.Add(this.label9);
            this.panelForm.Controls.Add(this.tbxTelefone);
            this.panelForm.Controls.Add(this.label14);
            this.panelForm.Controls.Add(this.tbxRg);
            this.panelForm.Controls.Add(this.label11);
            this.panelForm.Controls.Add(this.tbxNascimento);
            this.panelForm.Controls.Add(this.label12);
            this.panelForm.Controls.Add(this.tbxCpf);
            this.panelForm.Controls.Add(this.label7);
            this.panelForm.Controls.Add(this.tbxNome);
            this.panelForm.Controls.Add(this.label6);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 100);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.panelForm.Size = new System.Drawing.Size(559, 550);
            this.panelForm.TabIndex = 1;
            // 
            // btnCriar
            // 
            this.btnCriar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCriar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCriar.FlatAppearance.BorderSize = 0;
            this.btnCriar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(110)))), ((int)(((byte)(160)))));
            this.btnCriar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(150)))), ((int)(((byte)(200)))));
            this.btnCriar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCriar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCriar.ForeColor = System.Drawing.Color.White;
            this.btnCriar.Location = new System.Drawing.Point(260, 460);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(180, 40);
            this.btnCriar.TabIndex = 12;
            this.btnCriar.Text = "CRIAR CADASTRO";
            this.btnCriar.UseVisualStyleBackColor = false;
            this.btnCriar.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Green;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(60, 460);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(180, 40);
            this.btnVoltar.TabIndex = 13;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbxSenha1
            // 
            this.tbxSenha1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxSenha1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxSenha1.Location = new System.Drawing.Point(260, 180);
            this.tbxSenha1.MaxLength = 50;
            this.tbxSenha1.Name = "tbxSenha1";
            this.tbxSenha1.Size = new System.Drawing.Size(180, 25);
            this.tbxSenha1.TabIndex = 3;
            this.tbxSenha1.UseSystemPasswordChar = true;
            // 
            // tbxEmail1
            // 
            this.tbxEmail1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxEmail1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxEmail1.Location = new System.Drawing.Point(260, 130);
            this.tbxEmail1.MaxLength = 100;
            this.tbxEmail1.Name = "tbxEmail1";
            this.tbxEmail1.Size = new System.Drawing.Size(180, 25);
            this.tbxEmail1.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label18.Location = new System.Drawing.Point(257, 162);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 15);
            this.label18.TabIndex = 41;
            this.label18.Text = "Senha";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label17.Location = new System.Drawing.Point(257, 112);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 15);
            this.label17.TabIndex = 40;
            this.label17.Text = "Email";
            // 
            // tbxCep
            // 
            this.tbxCep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCep.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxCep.Location = new System.Drawing.Point(260, 380);
            this.tbxCep.Mask = "00000-000";
            this.tbxCep.Name = "tbxCep";
            this.tbxCep.Size = new System.Drawing.Size(180, 25);
            this.tbxCep.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label16.Location = new System.Drawing.Point(257, 362);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 15);
            this.label16.TabIndex = 38;
            this.label16.Text = "CEP";
            // 
            // tbxPais
            // 
            this.tbxPais.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxPais.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxPais.Location = new System.Drawing.Point(260, 330);
            this.tbxPais.MaxLength = 50;
            this.tbxPais.Name = "tbxPais";
            this.tbxPais.Size = new System.Drawing.Size(180, 25);
            this.tbxPais.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label13.Location = new System.Drawing.Point(257, 312);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 15);
            this.label13.TabIndex = 36;
            this.label13.Text = "País";
            // 
            // tbxUf
            // 
            this.tbxUf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxUf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbxUf.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxUf.Location = new System.Drawing.Point(260, 280);
            this.tbxUf.MaxLength = 2;
            this.tbxUf.Name = "tbxUf";
            this.tbxUf.Size = new System.Drawing.Size(180, 25);
            this.tbxUf.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(257, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 15);
            this.label10.TabIndex = 34;
            this.label10.Text = "UF";
            // 
            // tbxCidade
            // 
            this.tbxCidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCidade.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxCidade.Location = new System.Drawing.Point(260, 230);
            this.tbxCidade.MaxLength = 50;
            this.tbxCidade.Name = "tbxCidade";
            this.tbxCidade.Size = new System.Drawing.Size(180, 25);
            this.tbxCidade.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label15.Location = new System.Drawing.Point(257, 212);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(44, 15);
            this.label15.TabIndex = 32;
            this.label15.Text = "Cidade";
            // 
            // tbxRua
            // 
            this.tbxRua.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxRua.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxRua.Location = new System.Drawing.Point(260, 80);
            this.tbxRua.MaxLength = 150;
            this.tbxRua.Name = "tbxRua";
            this.tbxRua.Size = new System.Drawing.Size(180, 25);
            this.tbxRua.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(257, 62);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 15);
            this.label9.TabIndex = 30;
            this.label9.Text = "Rua";
            // 
            // tbxTelefone
            // 
            this.tbxTelefone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxTelefone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxTelefone.Location = new System.Drawing.Point(50, 380);
            this.tbxTelefone.Mask = "(00) 00000-0000";
            this.tbxTelefone.Name = "tbxTelefone";
            this.tbxTelefone.Size = new System.Drawing.Size(180, 25);
            this.tbxTelefone.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label14.Location = new System.Drawing.Point(47, 362);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 15);
            this.label14.TabIndex = 28;
            this.label14.Text = "Telefone";
            // 
            // tbxRg
            // 
            this.tbxRg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxRg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxRg.Location = new System.Drawing.Point(50, 330);
            this.tbxRg.Mask = "00.000.000-0";
            this.tbxRg.Name = "tbxRg";
            this.tbxRg.Size = new System.Drawing.Size(180, 25);
            this.tbxRg.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(47, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 15);
            this.label11.TabIndex = 26;
            this.label11.Text = "RG";
            // 
            // tbxNascimento
            // 
            this.tbxNascimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxNascimento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxNascimento.Location = new System.Drawing.Point(50, 280);
            this.tbxNascimento.Mask = "00/00/0000";
            this.tbxNascimento.Name = "tbxNascimento";
            this.tbxNascimento.Size = new System.Drawing.Size(180, 25);
            this.tbxNascimento.TabIndex = 5;
            this.tbxNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(47, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 15);
            this.label12.TabIndex = 24;
            this.label12.Text = "Data de Nascimento";
            // 
            // tbxCpf
            // 
            this.tbxCpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxCpf.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxCpf.Location = new System.Drawing.Point(50, 230);
            this.tbxCpf.Mask = "000.000.000-00";
            this.tbxCpf.Name = "tbxCpf";
            this.tbxCpf.Size = new System.Drawing.Size(180, 25);
            this.tbxCpf.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(47, 212);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "CPF";
            // 
            // tbxNome
            // 
            this.tbxNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxNome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbxNome.Location = new System.Drawing.Point(50, 80);
            this.tbxNome.MaxLength = 100;
            this.tbxNome.Name = "tbxNome";
            this.tbxNome.Size = new System.Drawing.Size(180, 25);
            this.tbxNome.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(47, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nome";
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.panelHeader.Controls.Add(this.lblTitulo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(559, 100);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(0, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(559, 100);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "CADASTRO DE USUÁRIO";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form5
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(559, 650);
            this.Controls.Add(this.panelMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema - Cadastro de Usuário";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.panelMain.ResumeLayout(false);
            this.panelForm.ResumeLayout(false);
            this.panelForm.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Button btnCriar;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.TextBox tbxSenha1;
        private System.Windows.Forms.TextBox tbxEmail1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.MaskedTextBox tbxCep;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbxPais;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxUf;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbxCidade;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxRua;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox tbxTelefone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox tbxRg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox tbxNascimento;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox tbxCpf;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxNome;
        private System.Windows.Forms.Label label6;
    }
}