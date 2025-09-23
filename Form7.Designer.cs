namespace ControleDeEstoque
{
    partial class Form7
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
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cJ3027511PR2DataSet = new ControleDeEstoque.CJ3027511PR2DataSet();
            this.cJ3027511PR2DataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cJ3027511PR2DataSet5 = new ControleDeEstoque.CJ3027511PR2DataSet5();
            this.fornecedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fornecedorTableAdapter = new ControleDeEstoque.CJ3027511PR2DataSet5TableAdapters.FornecedorTableAdapter();
            this.nomeForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefoneForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cepForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataCadastroForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatusForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 43);
            this.button2.TabIndex = 1;
            this.button2.Text = "Voltar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(683, 399);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 39);
            this.button3.TabIndex = 2;
            this.button3.Text = "Adicionar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(663, 366);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Novo Fornecedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(197, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeForDataGridViewTextBoxColumn,
            this.telefoneForDataGridViewTextBoxColumn,
            this.emailForDataGridViewTextBoxColumn,
            this.cepForDataGridViewTextBoxColumn,
            this.dataCadastroForDataGridViewTextBoxColumn,
            this.estatusForDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fornecedorBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 288);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(643, 150);
            this.dataGridView1.TabIndex = 5;
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
            // cJ3027511PR2DataSet5
            // 
            this.cJ3027511PR2DataSet5.DataSetName = "CJ3027511PR2DataSet5";
            this.cJ3027511PR2DataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // fornecedorBindingSource
            // 
            this.fornecedorBindingSource.DataMember = "Fornecedor";
            this.fornecedorBindingSource.DataSource = this.cJ3027511PR2DataSet5;
            // 
            // fornecedorTableAdapter
            // 
            this.fornecedorTableAdapter.ClearBeforeFill = true;
            // 
            // nomeForDataGridViewTextBoxColumn
            // 
            this.nomeForDataGridViewTextBoxColumn.DataPropertyName = "Nome_For";
            this.nomeForDataGridViewTextBoxColumn.HeaderText = "Nome_For";
            this.nomeForDataGridViewTextBoxColumn.Name = "nomeForDataGridViewTextBoxColumn";
            // 
            // telefoneForDataGridViewTextBoxColumn
            // 
            this.telefoneForDataGridViewTextBoxColumn.DataPropertyName = "Telefone_For";
            this.telefoneForDataGridViewTextBoxColumn.HeaderText = "Telefone_For";
            this.telefoneForDataGridViewTextBoxColumn.Name = "telefoneForDataGridViewTextBoxColumn";
            // 
            // emailForDataGridViewTextBoxColumn
            // 
            this.emailForDataGridViewTextBoxColumn.DataPropertyName = "Email_For";
            this.emailForDataGridViewTextBoxColumn.HeaderText = "Email_For";
            this.emailForDataGridViewTextBoxColumn.Name = "emailForDataGridViewTextBoxColumn";
            // 
            // cepForDataGridViewTextBoxColumn
            // 
            this.cepForDataGridViewTextBoxColumn.DataPropertyName = "Cep_For";
            this.cepForDataGridViewTextBoxColumn.HeaderText = "Cep_For";
            this.cepForDataGridViewTextBoxColumn.Name = "cepForDataGridViewTextBoxColumn";
            // 
            // dataCadastroForDataGridViewTextBoxColumn
            // 
            this.dataCadastroForDataGridViewTextBoxColumn.DataPropertyName = "Data_Cadastro_For";
            this.dataCadastroForDataGridViewTextBoxColumn.HeaderText = "Data_Cadastro_For";
            this.dataCadastroForDataGridViewTextBoxColumn.Name = "dataCadastroForDataGridViewTextBoxColumn";
            // 
            // estatusForDataGridViewTextBoxColumn
            // 
            this.estatusForDataGridViewTextBoxColumn.DataPropertyName = "estatus_For";
            this.estatusForDataGridViewTextBoxColumn.HeaderText = "estatus_For";
            this.estatusForDataGridViewTextBoxColumn.Name = "estatusForDataGridViewTextBoxColumn";
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Name = "Form7";
            this.Text = "Form7";
            this.Load += new System.EventHandler(this.Form7_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fornecedorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
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