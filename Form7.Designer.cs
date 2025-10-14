namespace ControleDeEstoque
{
    partial class Form7
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nomeForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefoneForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cepForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataCadastroForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fornecedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cJ3027511PR2DataSet5 = new ControleDeEstoque.CJ3027511PR2DataSet5();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.cJ3027511PR2DataSet = new ControleDeEstoque.CJ3027511PR2DataSet();
            this.cJ3027511PR2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fornecedorTableAdapter = new ControleDeEstoque.CJ3027511PR2DataSet5TableAdapters.FornecedorTableAdapter();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet5)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSetBindingSource)).BeginInit();
            this.SuspendLayout();

            // 
            // panel1 - Cabeçalho
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 60);
            this.panel1.TabIndex = 0;

            // 
            // label1 - Título
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(300, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Lista de Fornecedores";

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
            this.btnVoltar.Click += new System.EventHandler(this.button2_Click);

            // 
            // panel2 - Corpo
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(800, 330);
            this.panel2.TabIndex = 1;

            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeForDataGridViewTextBoxColumn,
            this.telefoneForDataGridViewTextBoxColumn,
            this.emailForDataGridViewTextBoxColumn,
            this.cepForDataGridViewTextBoxColumn,
            this.dataCadastroForDataGridViewTextBoxColumn,
            this.estatusForDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fornecedorBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(20, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 290);
            this.dataGridView1.TabIndex = 5;

            // 
            // nomeForDataGridViewTextBoxColumn
            // 
            this.nomeForDataGridViewTextBoxColumn.DataPropertyName = "Nome_For";
            this.nomeForDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeForDataGridViewTextBoxColumn.Name = "nomeForDataGridViewTextBoxColumn";
            this.nomeForDataGridViewTextBoxColumn.Width = 150;
            // 
            // telefoneForDataGridViewTextBoxColumn
            // 
            this.telefoneForDataGridViewTextBoxColumn.DataPropertyName = "Telefone_For";
            this.telefoneForDataGridViewTextBoxColumn.HeaderText = "Telefone";
            this.telefoneForDataGridViewTextBoxColumn.Name = "telefoneForDataGridViewTextBoxColumn";
            // 
            // emailForDataGridViewTextBoxColumn
            // 
            this.emailForDataGridViewTextBoxColumn.DataPropertyName = "Email_For";
            this.emailForDataGridViewTextBoxColumn.HeaderText = "E-mail";
            this.emailForDataGridViewTextBoxColumn.Name = "emailForDataGridViewTextBoxColumn";
            this.emailForDataGridViewTextBoxColumn.Width = 150;
            // 
            // cepForDataGridViewTextBoxColumn
            // 
            this.cepForDataGridViewTextBoxColumn.DataPropertyName = "Cep_For";
            this.cepForDataGridViewTextBoxColumn.HeaderText = "CEP";
            this.cepForDataGridViewTextBoxColumn.Name = "cepForDataGridViewTextBoxColumn";
            // 
            // dataCadastroForDataGridViewTextBoxColumn
            // 
            this.dataCadastroForDataGridViewTextBoxColumn.DataPropertyName = "Data_Cadastro_For";
            this.dataCadastroForDataGridViewTextBoxColumn.HeaderText = "Data Cadastro";
            this.dataCadastroForDataGridViewTextBoxColumn.Name = "dataCadastroForDataGridViewTextBoxColumn";
            this.dataCadastroForDataGridViewTextBoxColumn.Width = 120;
            // 
            // estatusForDataGridViewTextBoxColumn
            // 
            this.estatusForDataGridViewTextBoxColumn.DataPropertyName = "estatus_For";
            this.estatusForDataGridViewTextBoxColumn.HeaderText = "Status";
            this.estatusForDataGridViewTextBoxColumn.Name = "estatusForDataGridViewTextBoxColumn";
            this.estatusForDataGridViewTextBoxColumn.Width = 80;
            // 
            // fornecedorBindingSource
            // 
            this.fornecedorBindingSource.DataMember = "Fornecedor";
            this.fornecedorBindingSource.DataSource = this.cJ3027511PR2DataSet5;
            // 
            // cJ3027511PR2DataSet5
            // 
            this.cJ3027511PR2DataSet5.DataSetName = "CJ3027511PR2DataSet5";
            this.cJ3027511PR2DataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel3 - Rodapé
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.btnAdicionar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 390);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 60);
            this.panel3.TabIndex = 2;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(550, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Novo Fornecedor";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(680, 15);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(100, 30);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
           

            // 
            // cJ3027511PR2DataSet
            // 
            this.cJ3027511PR2DataSet.DataSetName = "CJ3027511PR2DataSet";
            this.cJ3027511PR2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cJ3027511PR2DataSetBindingSource
            // 
            this.cJ3027511PR2DataSetBindingSource.DataSource = this.cJ3027511PR2DataSet;
            this.cJ3027511PR2DataSetBindingSource.Position = 0;
            // 
            // fornecedorTableAdapter
            // 
            this.fornecedorTableAdapter.ClearBeforeFill = true;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Form7";
            this.Text = "Lista de Fornecedores";
            this.Load += new System.EventHandler(this.Form7_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet5)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.BindingSource cJ3027511PR2DataSetBindingSource;
        private CJ3027511PR2DataSet cJ3027511PR2DataSet;
        private CJ3027511PR2DataSet5 cJ3027511PR2DataSet5;
        private System.Windows.Forms.BindingSource fornecedorBindingSource;
        private CJ3027511PR2DataSet5TableAdapters.FornecedorTableAdapter fornecedorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefoneForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cepForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataCadastroForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatusForDataGridViewTextBoxColumn;
    }
}