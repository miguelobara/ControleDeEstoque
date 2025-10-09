namespace ControleDeEstoque
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;

        // DECLARAÇÕES DOS CONTROLES
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
        private System.Windows.Forms.Button btnDeletar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNovaUnidade;
        private System.Windows.Forms.Button btnNovaCategoria;
        private System.Windows.Forms.Button btnMudarLucro;
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
        private System.Windows.Forms.Label lblPrecoVendaRecomendado;
        private System.Windows.Forms.Label lblPercentualLucro;
        private System.Windows.Forms.CheckBox chkBuscarNome;
        private System.Windows.Forms.CheckBox chkBuscarCategoria;
        private System.Windows.Forms.CheckBox chkBuscarFornecedor;
        private System.Windows.Forms.GroupBox groupBoxBusca;

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
            this.btnDeletar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNovaUnidade = new System.Windows.Forms.Button();
            this.btnNovaCategoria = new System.Windows.Forms.Button();
            this.btnMudarLucro = new System.Windows.Forms.Button();
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
            this.lblPrecoVendaRecomendado = new System.Windows.Forms.Label();
            this.lblPercentualLucro = new System.Windows.Forms.Label();
            this.groupBoxBusca = new System.Windows.Forms.GroupBox();
            this.chkBuscarFornecedor = new System.Windows.Forms.CheckBox();
            this.chkBuscarCategoria = new System.Windows.Forms.CheckBox();
            this.chkBuscarNome = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.groupBoxBusca.SuspendLayout();
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
            this.cbxTipo.Location = new System.Drawing.Point(120, 80);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(200, 21);
            this.cbxTipo.TabIndex = 2;
            // 
            // cbxUnidade
            // 
            this.cbxUnidade.FormattingEnabled = true;
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
            // btnDeletar
            // 
            this.btnDeletar.Location = new System.Drawing.Point(450, 400);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(75, 23);
            this.btnDeletar.TabIndex = 12;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(450, 430);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNovaUnidade
            // 
            this.btnNovaUnidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaUnidade.Location = new System.Drawing.Point(326, 110);
            this.btnNovaUnidade.Name = "btnNovaUnidade";
            this.btnNovaUnidade.Size = new System.Drawing.Size(25, 21);
            this.btnNovaUnidade.TabIndex = 14;
            this.btnNovaUnidade.Text = "+";
            this.btnNovaUnidade.UseVisualStyleBackColor = true;
            // 
            // btnNovaCategoria
            // 
            this.btnNovaCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaCategoria.Location = new System.Drawing.Point(326, 80);
            this.btnNovaCategoria.Name = "btnNovaCategoria";
            this.btnNovaCategoria.Size = new System.Drawing.Size(25, 21);
            this.btnNovaCategoria.TabIndex = 15;
            this.btnNovaCategoria.Text = "+";
            this.btnNovaCategoria.UseVisualStyleBackColor = true;
            // 
            // btnMudarLucro
            // 
            this.btnMudarLucro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMudarLucro.Location = new System.Drawing.Point(120, 355);
            this.btnMudarLucro.Name = "btnMudarLucro";
            this.btnMudarLucro.Size = new System.Drawing.Size(25, 21);
            this.btnMudarLucro.TabIndex = 16;
            this.btnMudarLucro.Text = "+";
            this.btnMudarLucro.UseVisualStyleBackColor = true;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(350, 50);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.Size = new System.Drawing.Size(843, 330);
            this.dgvProdutos.TabIndex = 17;
            // 
            // lblProcurar
            // 
            this.lblProcurar.AutoSize = true;
            this.lblProcurar.Location = new System.Drawing.Point(20, 23);
            this.lblProcurar.Name = "lblProcurar";
            this.lblProcurar.Size = new System.Drawing.Size(50, 13);
            this.lblProcurar.TabIndex = 18;
            this.lblProcurar.Text = "Procurar:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(20, 53);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 19;
            this.lblNome.Text = "Nome:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(20, 83);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 20;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Location = new System.Drawing.Point(20, 113);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(50, 13);
            this.lblUnidade.TabIndex = 21;
            this.lblUnidade.Text = "Unidade:";
            // 
            // lblPrecoCompra
            // 
            this.lblPrecoCompra.AutoSize = true;
            this.lblPrecoCompra.Location = new System.Drawing.Point(20, 143);
            this.lblPrecoCompra.Name = "lblPrecoCompra";
            this.lblPrecoCompra.Size = new System.Drawing.Size(77, 13);
            this.lblPrecoCompra.TabIndex = 22;
            this.lblPrecoCompra.Text = "Preço Compra:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(20, 173);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 23;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Location = new System.Drawing.Point(20, 243);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(65, 13);
            this.lblQuantidade.TabIndex = 24;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Location = new System.Drawing.Point(20, 273);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(72, 13);
            this.lblPrecoVenda.TabIndex = 25;
            this.lblPrecoVenda.Text = "Preço Venda:";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Location = new System.Drawing.Point(20, 303);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(64, 13);
            this.lblFornecedor.TabIndex = 26;
            this.lblFornecedor.Text = "Fornecedor:";
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.Location = new System.Drawing.Point(20, 333);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(51, 13);
            this.lblValidade.TabIndex = 27;
            this.lblValidade.Text = "Validade:";
            // 
            // lblPrecoVendaRecomendado
            // 
            this.lblPrecoVendaRecomendado.AutoSize = true;
            this.lblPrecoVendaRecomendado.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblPrecoVendaRecomendado.Location = new System.Drawing.Point(20, 380);
            this.lblPrecoVendaRecomendado.Name = "lblPrecoVendaRecomendado";
            this.lblPrecoVendaRecomendado.Size = new System.Drawing.Size(300, 120);
            this.lblPrecoVendaRecomendado.TabIndex = 28;
            // 
            // lblPercentualLucro
            // 
            this.lblPercentualLucro.AutoSize = true;
            this.lblPercentualLucro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentualLucro.Location = new System.Drawing.Point(20, 360);
            this.lblPercentualLucro.Name = "lblPercentualLucro";
            this.lblPercentualLucro.Size = new System.Drawing.Size(97, 13);
            this.lblPercentualLucro.TabIndex = 29;
            this.lblPercentualLucro.Text = "Lucro: 30% (+)";
            // 
            // groupBoxBusca
            // 
            this.groupBoxBusca.Controls.Add(this.chkBuscarFornecedor);
            this.groupBoxBusca.Controls.Add(this.chkBuscarCategoria);
            this.groupBoxBusca.Controls.Add(this.chkBuscarNome);
            this.groupBoxBusca.Location = new System.Drawing.Point(330, 10);
            this.groupBoxBusca.Name = "groupBoxBusca";
            this.groupBoxBusca.Size = new System.Drawing.Size(200, 40);
            this.groupBoxBusca.TabIndex = 30;
            this.groupBoxBusca.TabStop = false;
            this.groupBoxBusca.Text = "Buscar por:";
            // 
            // chkBuscarFornecedor
            // 
            this.chkBuscarFornecedor.AutoSize = true;
            this.chkBuscarFornecedor.Location = new System.Drawing.Point(145, 17);
            this.chkBuscarFornecedor.Name = "chkBuscarFornecedor";
            this.chkBuscarFornecedor.Size = new System.Drawing.Size(50, 17);
            this.chkBuscarFornecedor.TabIndex = 2;
            this.chkBuscarFornecedor.Text = "Forn.";
            this.chkBuscarFornecedor.UseVisualStyleBackColor = true;
            // 
            // chkBuscarCategoria
            // 
            this.chkBuscarCategoria.AutoSize = true;
            this.chkBuscarCategoria.Location = new System.Drawing.Point(70, 17);
            this.chkBuscarCategoria.Name = "chkBuscarCategoria";
            this.chkBuscarCategoria.Size = new System.Drawing.Size(73, 17);
            this.chkBuscarCategoria.TabIndex = 1;
            this.chkBuscarCategoria.Text = "Categoria";
            this.chkBuscarCategoria.UseVisualStyleBackColor = true;
            // 
            // chkBuscarNome
            // 
            this.chkBuscarNome.AutoSize = true;
            this.chkBuscarNome.Checked = true;
            this.chkBuscarNome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBuscarNome.Location = new System.Drawing.Point(10, 17);
            this.chkBuscarNome.Name = "chkBuscarNome";
            this.chkBuscarNome.Size = new System.Drawing.Size(55, 17);
            this.chkBuscarNome.TabIndex = 0;
            this.chkBuscarNome.Text = "Nome";
            this.chkBuscarNome.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(1213, 525);
            this.Controls.Add(this.groupBoxBusca);
            this.Controls.Add(this.lblPercentualLucro);
            this.Controls.Add(this.lblPrecoVendaRecomendado);
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
            this.Controls.Add(this.btnMudarLucro);
            this.Controls.Add(this.btnNovaCategoria);
            this.Controls.Add(this.btnNovaUnidade);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnDeletar);
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
            this.groupBoxBusca.ResumeLayout(false);
            this.groupBoxBusca.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}