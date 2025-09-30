namespace ControleDeEstoque
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;

        // DECLARAÇÕES DOS CONTROLES - ADICIONE ESTAS LINHAS
        private System.Windows.Forms.TextBox tbxProcurar;
        private System.Windows.Forms.TextBox tbxNome;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.ComboBox cbxUnidade;
        private System.Windows.Forms.TextBox tbxPrecoCompra;
        private System.Windows.Forms.TextBox tbxDescricao;
        private System.Windows.Forms.TextBox tbxQuantidade;
        private System.Windows.Forms.TextBox tbxPrecoVenda;
        private System.Windows.Forms.TextBox tbxFornecedor;
        private System.Windows.Forms.DateTimePicker dtpValidade;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.Label lblProcurar;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblUnidade;
        private System.Windows.Forms.Label lblPrecoCompra;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblPrecoVenda;
        private System.Windows.Forms.Label lblFornecedor;
        private System.Windows.Forms.Label lblValidade;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbxProcurar = new System.Windows.Forms.TextBox();
            this.tbxNome = new System.Windows.Forms.TextBox();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.cbxUnidade = new System.Windows.Forms.ComboBox();
            this.tbxPrecoCompra = new System.Windows.Forms.TextBox();
            this.tbxDescricao = new System.Windows.Forms.TextBox();
            this.tbxQuantidade = new System.Windows.Forms.TextBox();
            this.tbxPrecoVenda = new System.Windows.Forms.TextBox();
            this.tbxFornecedor = new System.Windows.Forms.TextBox();
            this.dtpValidade = new System.Windows.Forms.DateTimePicker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnDeletar = new System.Windows.Forms.Button();
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.lblProcurar = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblUnidade = new System.Windows.Forms.Label();
            this.lblPrecoCompra = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblPrecoVenda = new System.Windows.Forms.Label();
            this.lblFornecedor = new System.Windows.Forms.Label();
            this.lblValidade = new System.Windows.Forms.Label();
            this.cJ3027511PR2DataSet6 = new ControleDeEstoque.CJ3027511PR2DataSet6();
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtoTableAdapter = new ControleDeEstoque.CJ3027511PR2DataSet6TableAdapters.ProdutoTableAdapter();
            this.idProdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validadeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoVenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoCmpDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeTipoProdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidadeProdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadeMedidaProdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFornecedorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxProcurar
            // 
            this.tbxProcurar.Location = new System.Drawing.Point(120, 20);
            this.tbxProcurar.Name = "tbxProcurar";
            this.tbxProcurar.Size = new System.Drawing.Size(200, 20);
            this.tbxProcurar.TabIndex = 0;
            // 
            // tbxNome
            // 
            this.tbxNome.Location = new System.Drawing.Point(120, 50);
            this.tbxNome.Name = "tbxNome";
            this.tbxNome.Size = new System.Drawing.Size(200, 20);
            this.tbxNome.TabIndex = 1;
            // 
            // cbxTipo
            // 
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Items.AddRange(new object[] {
            "Limpeza",
            "Bebida",
            "Comida",
            "Outros"});
            this.cbxTipo.Location = new System.Drawing.Point(120, 80);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(200, 21);
            this.cbxTipo.TabIndex = 2;
            // 
            // cbxUnidade
            // 
            this.cbxUnidade.FormattingEnabled = true;
            this.cbxUnidade.Items.AddRange(new object[] {
            "Kg",
            "g",
            "L",
            "ml",
            "Unidade"});
            this.cbxUnidade.Location = new System.Drawing.Point(120, 110);
            this.cbxUnidade.Name = "cbxUnidade";
            this.cbxUnidade.Size = new System.Drawing.Size(200, 21);
            this.cbxUnidade.TabIndex = 3;
            // 
            // tbxPrecoCompra
            // 
            this.tbxPrecoCompra.Location = new System.Drawing.Point(120, 140);
            this.tbxPrecoCompra.Name = "tbxPrecoCompra";
            this.tbxPrecoCompra.Size = new System.Drawing.Size(200, 20);
            this.tbxPrecoCompra.TabIndex = 4;
            // 
            // tbxDescricao
            // 
            this.tbxDescricao.Location = new System.Drawing.Point(120, 170);
            this.tbxDescricao.Multiline = true;
            this.tbxDescricao.Name = "tbxDescricao";
            this.tbxDescricao.Size = new System.Drawing.Size(200, 60);
            this.tbxDescricao.TabIndex = 5;
            // 
            // tbxQuantidade
            // 
            this.tbxQuantidade.Location = new System.Drawing.Point(120, 240);
            this.tbxQuantidade.Name = "tbxQuantidade";
            this.tbxQuantidade.Size = new System.Drawing.Size(200, 20);
            this.tbxQuantidade.TabIndex = 6;
            // 
            // tbxPrecoVenda
            // 
            this.tbxPrecoVenda.Location = new System.Drawing.Point(120, 270);
            this.tbxPrecoVenda.Name = "tbxPrecoVenda";
            this.tbxPrecoVenda.Size = new System.Drawing.Size(200, 20);
            this.tbxPrecoVenda.TabIndex = 7;
            // 
            // tbxFornecedor
            // 
            this.tbxFornecedor.Location = new System.Drawing.Point(120, 300);
            this.tbxFornecedor.Name = "tbxFornecedor";
            this.tbxFornecedor.Size = new System.Drawing.Size(200, 20);
            this.tbxFornecedor.TabIndex = 8;
            // 
            // dtpValidade
            // 
            this.dtpValidade.Location = new System.Drawing.Point(120, 330);
            this.dtpValidade.Name = "dtpValidade";
            this.dtpValidade.Size = new System.Drawing.Size(200, 20);
            this.dtpValidade.TabIndex = 9;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(350, 400);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(350, 430);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 11;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(450, 400);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(75, 23);
            this.btnAdicionar.TabIndex = 12;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(450, 430);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 13;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AutoGenerateColumns = false;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProdDataGridViewTextBoxColumn,
            this.nomeProdDataGridViewTextBoxColumn,
            this.categoriaDataGridViewTextBoxColumn,
            this.validadeDataGridViewTextBoxColumn,
            this.idTipoDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn,
            this.precoVenDataGridViewTextBoxColumn,
            this.precoCmpDataGridViewTextBoxColumn,
            this.nomeTipoProdDataGridViewTextBoxColumn,
            this.quantidadeProdDataGridViewTextBoxColumn,
            this.unidadeMedidaProdDataGridViewTextBoxColumn,
            this.idFornecedorDataGridViewTextBoxColumn});
            this.dgvProdutos.DataSource = this.produtoBindingSource;
            this.dgvProdutos.Location = new System.Drawing.Point(350, 20);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.Size = new System.Drawing.Size(400, 350);
            this.dgvProdutos.TabIndex = 14;
            // 
            // lblProcurar
            // 
            this.lblProcurar.AutoSize = true;
            this.lblProcurar.Location = new System.Drawing.Point(20, 23);
            this.lblProcurar.Name = "lblProcurar";
            this.lblProcurar.Size = new System.Drawing.Size(50, 13);
            this.lblProcurar.TabIndex = 15;
            this.lblProcurar.Text = "Procurar:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(20, 53);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 16;
            this.lblNome.Text = "Nome:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 83);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 17;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Location = new System.Drawing.Point(20, 113);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(50, 13);
            this.lblUnidade.TabIndex = 18;
            this.lblUnidade.Text = "Unidade:";
            // 
            // lblPrecoCompra
            // 
            this.lblPrecoCompra.AutoSize = true;
            this.lblPrecoCompra.Location = new System.Drawing.Point(20, 143);
            this.lblPrecoCompra.Name = "lblPrecoCompra";
            this.lblPrecoCompra.Size = new System.Drawing.Size(77, 13);
            this.lblPrecoCompra.TabIndex = 19;
            this.lblPrecoCompra.Text = "Preço Compra:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(20, 173);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 20;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(20, 243);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 21;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Location = new System.Drawing.Point(20, 273);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(72, 13);
            this.lblPrecoVenda.TabIndex = 22;
            this.lblPrecoVenda.Text = "Preço Venda:";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(20, 303);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(64, 13);
            this.lblFornecedor.TabIndex = 23;
            this.lblFornecedor.Text = "Fornecedor:";
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.Location = new System.Drawing.Point(20, 333);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(51, 13);
            this.lblValidade.TabIndex = 24;
            this.lblValidade.Text = "Validade:";
            // 
            // cJ3027511PR2DataSet6
            // 
            this.cJ3027511PR2DataSet6.DataSetName = "CJ3027511PR2DataSet6";
            this.cJ3027511PR2DataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataMember = "Produto";
            this.produtoBindingSource.DataSource = this.cJ3027511PR2DataSet6;
            // 
            // produtoTableAdapter
            // 
            this.produtoTableAdapter.ClearBeforeFill = true;
            // 
            // idProdDataGridViewTextBoxColumn
            // 
            this.idProdDataGridViewTextBoxColumn.DataPropertyName = "Id_Prod";
            this.idProdDataGridViewTextBoxColumn.HeaderText = "Id_Prod";
            this.idProdDataGridViewTextBoxColumn.Name = "idProdDataGridViewTextBoxColumn";
            this.idProdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeProdDataGridViewTextBoxColumn
            // 
            this.nomeProdDataGridViewTextBoxColumn.DataPropertyName = "Nome_Prod";
            this.nomeProdDataGridViewTextBoxColumn.HeaderText = "Nome_Prod";
            this.nomeProdDataGridViewTextBoxColumn.Name = "nomeProdDataGridViewTextBoxColumn";
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            this.categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            // 
            // validadeDataGridViewTextBoxColumn
            // 
            this.validadeDataGridViewTextBoxColumn.DataPropertyName = "Validade";
            this.validadeDataGridViewTextBoxColumn.HeaderText = "Validade";
            this.validadeDataGridViewTextBoxColumn.Name = "validadeDataGridViewTextBoxColumn";
            // 
            // idTipoDataGridViewTextBoxColumn
            // 
            this.idTipoDataGridViewTextBoxColumn.DataPropertyName = "Id_Tipo";
            this.idTipoDataGridViewTextBoxColumn.HeaderText = "Id_Tipo";
            this.idTipoDataGridViewTextBoxColumn.Name = "idTipoDataGridViewTextBoxColumn";
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            // 
            // precoVenDataGridViewTextBoxColumn
            // 
            this.precoVenDataGridViewTextBoxColumn.DataPropertyName = "Preco_Ven";
            this.precoVenDataGridViewTextBoxColumn.HeaderText = "Preco_Ven";
            this.precoVenDataGridViewTextBoxColumn.Name = "precoVenDataGridViewTextBoxColumn";
            // 
            // precoCmpDataGridViewTextBoxColumn
            // 
            this.precoCmpDataGridViewTextBoxColumn.DataPropertyName = "Preco_Cmp";
            this.precoCmpDataGridViewTextBoxColumn.HeaderText = "Preco_Cmp";
            this.precoCmpDataGridViewTextBoxColumn.Name = "precoCmpDataGridViewTextBoxColumn";
            // 
            // nomeTipoProdDataGridViewTextBoxColumn
            // 
            this.nomeTipoProdDataGridViewTextBoxColumn.DataPropertyName = "Nome_Tipo_Prod";
            this.nomeTipoProdDataGridViewTextBoxColumn.HeaderText = "Nome_Tipo_Prod";
            this.nomeTipoProdDataGridViewTextBoxColumn.Name = "nomeTipoProdDataGridViewTextBoxColumn";
            // 
            // quantidadeProdDataGridViewTextBoxColumn
            // 
            this.quantidadeProdDataGridViewTextBoxColumn.DataPropertyName = "Quantidade_Prod";
            this.quantidadeProdDataGridViewTextBoxColumn.HeaderText = "Quantidade_Prod";
            this.quantidadeProdDataGridViewTextBoxColumn.Name = "quantidadeProdDataGridViewTextBoxColumn";
            // 
            // unidadeMedidaProdDataGridViewTextBoxColumn
            // 
            this.unidadeMedidaProdDataGridViewTextBoxColumn.DataPropertyName = "Unidade_Medida_Prod";
            this.unidadeMedidaProdDataGridViewTextBoxColumn.HeaderText = "Unidade_Medida_Prod";
            this.unidadeMedidaProdDataGridViewTextBoxColumn.Name = "unidadeMedidaProdDataGridViewTextBoxColumn";
            // 
            // idFornecedorDataGridViewTextBoxColumn
            // 
            this.idFornecedorDataGridViewTextBoxColumn.DataPropertyName = "Id_Fornecedor";
            this.idFornecedorDataGridViewTextBoxColumn.HeaderText = "Id_Fornecedor";
            this.idFornecedorDataGridViewTextBoxColumn.Name = "idFornecedorDataGridViewTextBoxColumn";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lblValidade);
            this.Controls.Add(this.lblFornecedor);
            this.Controls.Add(this.lblPrecoVenda);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.lblPrecoCompra);
            this.Controls.Add(this.lblUnidade);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.lblProcurar);
            this.Controls.Add(this.dgvProdutos);
            this.Controls.Add(this.btnDeletar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.dtpValidade);
            this.Controls.Add(this.tbxFornecedor);
            this.Controls.Add(this.tbxPrecoVenda);
            this.Controls.Add(this.tbxQuantidade);
            this.Controls.Add(this.tbxDescricao);
            this.Controls.Add(this.tbxPrecoCompra);
            this.Controls.Add(this.cbxUnidade);
            this.Controls.Add(this.cbxTipo);
            this.Controls.Add(this.tbxNome);
            this.Controls.Add(this.tbxProcurar);
            this.Name = "Form4";
            this.Text = "Cadastro de Produtos";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cJ3027511PR2DataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private CJ3027511PR2DataSet6 cJ3027511PR2DataSet6;
        private System.Windows.Forms.BindingSource produtoBindingSource;
        private CJ3027511PR2DataSet6TableAdapters.ProdutoTableAdapter produtoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn validadeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoVenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoCmpDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeTipoProdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidadeProdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadeMedidaProdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFornecedorDataGridViewTextBoxColumn;
    }
}