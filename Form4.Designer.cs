namespace ControleDeEstoque
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Cpf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.senhaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cJ3027511PR2DataSet = new ControleDeEstoque.CJ3027511PR2DataSet();
            this.usuarioTableAdapter = new ControleDeEstoque.CJ3027511PR2DataSetTableAdapters.UsuarioTableAdapter();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tbxNome_Prod = new System.Windows.Forms.TextBox();
            this.tbxCategoria = new System.Windows.Forms.TextBox();
            this.tbxValidade = new System.Windows.Forms.TextBox();
            this.tbxDescricao = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tbxNome_Tipo = new System.Windows.Forms.TextBox();
            this.tbxUnidade_Medida = new System.Windows.Forms.TextBox();
            this.btnDeletarTipo = new System.Windows.Forms.Button();
            this.btnRenomearTip = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbNome_Tipo = new System.Windows.Forms.ComboBox();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cpf,
            this.emailDataGridViewTextBoxColumn,
            this.senhaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.usuarioBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(13, 298);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(727, 169);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // Cpf
            // 
            this.Cpf.DataPropertyName = "Senha";
            this.Cpf.HeaderText = "Cpf";
            this.Cpf.Name = "Cpf";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // senhaDataGridViewTextBoxColumn
            // 
            this.senhaDataGridViewTextBoxColumn.DataPropertyName = "Senha";
            this.senhaDataGridViewTextBoxColumn.HeaderText = "Senha";
            this.senhaDataGridViewTextBoxColumn.Name = "senhaDataGridViewTextBoxColumn";
            // 
            // usuarioBindingSource
            // 
            this.usuarioBindingSource.DataMember = "Usuario";
            this.usuarioBindingSource.DataSource = this.cJ3027511PR2DataSet;
            // 
            // cJ3027511PR2DataSet
            // 
            this.cJ3027511PR2DataSet.DataSetName = "CJ3027511PR2DataSet";
            this.cJ3027511PR2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // usuarioTableAdapter
            // 
            this.usuarioTableAdapter.ClearBeforeFill = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "busca";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(119, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "procurar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbxNome_Prod
            // 
            this.tbxNome_Prod.Location = new System.Drawing.Point(13, 50);
            this.tbxNome_Prod.Name = "tbxNome_Prod";
            this.tbxNome_Prod.Size = new System.Drawing.Size(100, 20);
            this.tbxNome_Prod.TabIndex = 3;
            this.tbxNome_Prod.Text = "Nome do Produto";
            this.tbxNome_Prod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbxNome_Prod.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // tbxCategoria
            // 
            this.tbxCategoria.Location = new System.Drawing.Point(13, 76);
            this.tbxCategoria.Name = "tbxCategoria";
            this.tbxCategoria.Size = new System.Drawing.Size(100, 20);
            this.tbxCategoria.TabIndex = 4;
            this.tbxCategoria.Text = "Categoria";
            this.tbxCategoria.Click += new System.EventHandler(this.textBox3_Click);
            // 
            // tbxValidade
            // 
            this.tbxValidade.Location = new System.Drawing.Point(13, 102);
            this.tbxValidade.Name = "tbxValidade";
            this.tbxValidade.Size = new System.Drawing.Size(100, 20);
            this.tbxValidade.TabIndex = 5;
            this.tbxValidade.Text = "Validade";
            this.tbxValidade.Click += new System.EventHandler(this.textBox4_Click);
            // 
            // tbxDescricao
            // 
            this.tbxDescricao.Location = new System.Drawing.Point(11, 180);
            this.tbxDescricao.MaxLength = 256;
            this.tbxDescricao.Multiline = true;
            this.tbxDescricao.Name = "tbxDescricao";
            this.tbxDescricao.Size = new System.Drawing.Size(101, 20);
            this.tbxDescricao.TabIndex = 6;
            this.tbxDescricao.Text = "Descricao";
            this.tbxDescricao.Click += new System.EventHandler(this.textBox5_Click);
            this.tbxDescricao.Enter += new System.EventHandler(this.textBox5_Enter);
            this.tbxDescricao.Leave += new System.EventHandler(this.textBox5_Leave);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(157, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "adicionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(157, 116);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "renomear";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(157, 142);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "deletar";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // tbxNome_Tipo
            // 
            this.tbxNome_Tipo.Location = new System.Drawing.Point(572, 47);
            this.tbxNome_Tipo.Name = "tbxNome_Tipo";
            this.tbxNome_Tipo.Size = new System.Drawing.Size(100, 20);
            this.tbxNome_Tipo.TabIndex = 12;
            this.tbxNome_Tipo.Text = "Nome";
            // 
            // tbxUnidade_Medida
            // 
            this.tbxUnidade_Medida.Location = new System.Drawing.Point(572, 95);
            this.tbxUnidade_Medida.Name = "tbxUnidade_Medida";
            this.tbxUnidade_Medida.Size = new System.Drawing.Size(100, 20);
            this.tbxUnidade_Medida.TabIndex = 13;
            this.tbxUnidade_Medida.Text = "Unidade De Medida";
            // 
            // btnDeletarTipo
            // 
            this.btnDeletarTipo.Location = new System.Drawing.Point(470, 102);
            this.btnDeletarTipo.Name = "btnDeletarTipo";
            this.btnDeletarTipo.Size = new System.Drawing.Size(75, 23);
            this.btnDeletarTipo.TabIndex = 15;
            this.btnDeletarTipo.Text = "DeletarTipo";
            this.btnDeletarTipo.UseVisualStyleBackColor = true;
            this.btnDeletarTipo.Click += new System.EventHandler(this.btnDeletarTipo_Click);
            // 
            // btnRenomearTip
            // 
            this.btnRenomearTip.Location = new System.Drawing.Point(470, 74);
            this.btnRenomearTip.Name = "btnRenomearTip";
            this.btnRenomearTip.Size = new System.Drawing.Size(75, 23);
            this.btnRenomearTip.TabIndex = 16;
            this.btnRenomearTip.Text = "RenomearTip";
            this.btnRenomearTip.UseVisualStyleBackColor = true;
            this.btnRenomearTip.Click += new System.EventHandler(this.btnRenomearTip_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(11, 154);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // cmbNome_Tipo
            // 
            this.cmbNome_Tipo.DataSource = this.usuarioBindingSource;
            this.cmbNome_Tipo.FormattingEnabled = true;
            this.cmbNome_Tipo.Location = new System.Drawing.Point(11, 128);
            this.cmbNome_Tipo.Name = "cmbNome_Tipo";
            this.cmbNome_Tipo.Size = new System.Drawing.Size(121, 21);
            this.cmbNome_Tipo.TabIndex = 18;
            this.cmbNome_Tipo.SelectedIndexChanged += new System.EventHandler(this.cmbNome_Tipo_SelectedIndexChanged);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(470, 48);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 19;
            this.btnAdicionar.Text = "AdicionarTipo";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(572, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "coloque aqui a unidade de medida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(551, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "coloque se e item de linpesa, bebida, etc";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(763, 479);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.cmbNome_Tipo);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnRenomearTip);
            this.Controls.Add(this.btnDeletarTipo);
            this.Controls.Add(this.tbxUnidade_Medida);
            this.Controls.Add(this.tbxNome_Tipo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbxDescricao);
            this.Controls.Add(this.tbxValidade);
            this.Controls.Add(this.tbxCategoria);
            this.Controls.Add(this.tbxNome_Prod);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.Text = "produto";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private CJ3027511PR2DataSet cJ3027511PR2DataSet;
        private System.Windows.Forms.BindingSource usuarioBindingSource;
        private CJ3027511PR2DataSetTableAdapters.UsuarioTableAdapter usuarioTableAdapter;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbxNome_Prod;
        private System.Windows.Forms.TextBox tbxCategoria;
        private System.Windows.Forms.TextBox tbxValidade;
        private System.Windows.Forms.TextBox tbxDescricao;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cpf;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn senhaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAdicionarTipo;
        private System.Windows.Forms.TextBox tbxNome_Tipo;
        private System.Windows.Forms.TextBox tbxUnidade_Medida;
        private System.Windows.Forms.Button btnDeletarTipo;
        private System.Windows.Forms.Button btnRenomearTip;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbNome_Tipo;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}