namespace ControleDeEstoque
{
    partial class Form6
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpDataCadastro = new System.Windows.Forms.DateTimePicker();
            this.mtbUf = new System.Windows.Forms.MaskedTextBox();
            this.mtbCep = new System.Windows.Forms.MaskedTextBox();
            this.mtbTelefone = new System.Windows.Forms.MaskedTextBox();
            this.mtbCnpj = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbxRua_For = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbxCidade_For = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxEmail_For = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxNome_For = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAdicionarFor = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 60);
            this.panel1.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(280, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 25);
            this.label11.TabIndex = 1;
            this.label11.Text = "Fornecedores";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Green;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(12, 12);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(75, 35);
            this.btnVoltar.TabIndex = 0;
            this.btnVoltar.Text = "← Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(684, 351);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.dtpDataCadastro);
            this.groupBox1.Controls.Add(this.mtbUf);
            this.groupBox1.Controls.Add(this.mtbCep);
            this.groupBox1.Controls.Add(this.mtbTelefone);
            this.groupBox1.Controls.Add(this.mtbCnpj);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbxRua_For);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbxCidade_For);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbxEmail_For);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxNome_For);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(20, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Fornecedor";
            // 
            // dtpDataCadastro
            // 
            this.dtpDataCadastro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataCadastro.Location = new System.Drawing.Point(450, 40);
            this.dtpDataCadastro.Name = "dtpDataCadastro";
            this.dtpDataCadastro.Size = new System.Drawing.Size(120, 23);
            this.dtpDataCadastro.TabIndex = 7;
            // 
            // mtbUf
            // 
            this.mtbUf.Location = new System.Drawing.Point(450, 150);
            this.mtbUf.Mask = "AA";
            this.mtbUf.Name = "mtbUf";
            this.mtbUf.Size = new System.Drawing.Size(50, 23);
            this.mtbUf.TabIndex = 5;
            // 
            // mtbCep
            // 
            this.mtbCep.Location = new System.Drawing.Point(250, 200);
            this.mtbCep.Mask = "00000-000";
            this.mtbCep.Name = "mtbCep";
            this.mtbCep.Size = new System.Drawing.Size(80, 23);
            this.mtbCep.TabIndex = 6;
            // 
            // mtbTelefone
            // 
            this.mtbTelefone.Location = new System.Drawing.Point(30, 200);
            this.mtbTelefone.Mask = "(00) 00000-0000";
            this.mtbTelefone.Name = "mtbTelefone";
            this.mtbTelefone.Size = new System.Drawing.Size(120, 23);
            this.mtbTelefone.TabIndex = 4;
            // 
            // mtbCnpj
            // 
            this.mtbCnpj.Location = new System.Drawing.Point(30, 100);
            this.mtbCnpj.Mask = "00,000,000/0000-00";
            this.mtbCnpj.Name = "mtbCnpj";
            this.mtbCnpj.Size = new System.Drawing.Size(150, 23);
            this.mtbCnpj.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(447, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Data Cadastro *";
            // 
            // tbxRua_For
            // 
            this.tbxRua_For.Location = new System.Drawing.Point(250, 100);
            this.tbxRua_For.Name = "tbxRua_For";
            this.tbxRua_For.Size = new System.Drawing.Size(320, 23);
            this.tbxRua_For.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "UF *";
            // 
            // tbxCidade_For
            // 
            this.tbxCidade_For.Location = new System.Drawing.Point(250, 40);
            this.tbxCidade_For.Name = "tbxCidade_For";
            this.tbxCidade_For.Size = new System.Drawing.Size(180, 23);
            this.tbxCidade_For.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(247, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "CEP *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Endereço *";
            // 
            // tbxEmail_For
            // 
            this.tbxEmail_For.Location = new System.Drawing.Point(30, 250);
            this.tbxEmail_For.Name = "tbxEmail_For";
            this.tbxEmail_For.Size = new System.Drawing.Size(300, 23);
            this.tbxEmail_For.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "E-mail *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Telefone *";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(247, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cidade *";
            // 
            // tbxNome_For
            // 
            this.tbxNome_For.Location = new System.Drawing.Point(30, 40);
            this.tbxNome_For.Name = "tbxNome_For";
            this.tbxNome_For.Size = new System.Drawing.Size(200, 23);
            this.tbxNome_For.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "CNPJ *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome Fornecedor *";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.btnLimpar);
            this.panel3.Controls.Add(this.btnAdicionarFor);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 411);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 60);
            this.panel3.TabIndex = 2;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Silver;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpar.Location = new System.Drawing.Point(450, 15);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 30);
            this.btnLimpar.TabIndex = 1;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnAdicionarFor
            // 
            this.btnAdicionarFor.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdicionarFor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarFor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdicionarFor.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarFor.Location = new System.Drawing.Point(560, 15);
            this.btnAdicionarFor.Name = "btnAdicionarFor";
            this.btnAdicionarFor.Size = new System.Drawing.Size(100, 30);
            this.btnAdicionarFor.TabIndex = 0;
            this.btnAdicionarFor.Text = "Adicionar";
            this.btnAdicionarFor.UseVisualStyleBackColor = false;
            this.btnAdicionarFor.Click += new System.EventHandler(this.btnAdicionarFor_Click);
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 471);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Fornecedores";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox mtbCnpj;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbxRua_For;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxCidade_For;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxEmail_For;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxNome_For;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAdicionarFor;
        private System.Windows.Forms.MaskedTextBox mtbTelefone;
        private System.Windows.Forms.MaskedTextBox mtbCep;
        private System.Windows.Forms.MaskedTextBox mtbUf;
        private System.Windows.Forms.DateTimePicker dtpDataCadastro;
        private System.Windows.Forms.Button btnLimpar;
    }
}