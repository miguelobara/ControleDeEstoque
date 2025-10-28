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
        private System.Windows.Forms.CheckBox chkBuscarDescricao;
        private System.Windows.Forms.GroupBox groupBoxBusca;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.GroupBox groupBox1;

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
            this.chkBuscarDescricao = new System.Windows.Forms.CheckBox();
            this.chkBuscarFornecedor = new System.Windows.Forms.CheckBox();
            this.chkBuscarCategoria = new System.Windows.Forms.CheckBox();
            this.chkBuscarNome = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.groupBoxBusca.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbxProcurar
            // 
            this.tbxProcurar.Location = new System.Drawing.Point(73, 13);
            this.tbxProcurar.Name = "tbxProcurar";
            this.tbxProcurar.Size = new System.Drawing.Size(200, 23);
            this.tbxProcurar.TabIndex = 0;
            // 
            // tbxNome
            // 
            this.tbxNome.Location = new System.Drawing.Point(64, 33);
            this.tbxNome.Name = "tbxNome";
            this.tbxNome.Size = new System.Drawing.Size(200, 23);
            this.tbxNome.TabIndex = 1;
            // 
            // cbxTipo
            // 
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(89, 67);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(175, 23);
            this.cbxTipo.TabIndex = 2;
            // 
            // cbxUnidade
            // 
            this.cbxUnidade.FormattingEnabled = true;
            this.cbxUnidade.Location = new System.Drawing.Point(89, 97);
            this.cbxUnidade.Name = "cbxUnidade";
            this.cbxUnidade.Size = new System.Drawing.Size(175, 23);
            this.cbxUnidade.TabIndex = 3;
            // 
            // tbxPrecoCompra
            // 
            this.tbxPrecoCompra.Location = new System.Drawing.Point(95, 138);
            this.tbxPrecoCompra.Name = "tbxPrecoCompra";
            this.tbxPrecoCompra.Size = new System.Drawing.Size(200, 23);
            this.tbxPrecoCompra.TabIndex = 4;
            // 
            // tbxDescricao
            // 
            this.tbxDescricao.Location = new System.Drawing.Point(73, 178);
            this.tbxDescricao.Multiline = true;
            this.tbxDescricao.Name = "tbxDescricao";
            this.tbxDescricao.Size = new System.Drawing.Size(200, 60);
            this.tbxDescricao.TabIndex = 5;
            // 
            // tbxQuantidade
            // 
            this.tbxQuantidade.Location = new System.Drawing.Point(384, 30);
            this.tbxQuantidade.Name = "tbxQuantidade";
            this.tbxQuantidade.Size = new System.Drawing.Size(150, 23);
            this.tbxQuantidade.TabIndex = 6;
            // 
            // tbxPrecoVenda
            // 
            this.tbxPrecoVenda.Location = new System.Drawing.Point(387, 70);
            this.tbxPrecoVenda.Name = "tbxPrecoVenda";
            this.tbxPrecoVenda.Size = new System.Drawing.Size(150, 23);
            this.tbxPrecoVenda.TabIndex = 7;
            // 
            // tbxFornecedor
            // 
            this.tbxFornecedor.Location = new System.Drawing.Point(387, 104);
            this.tbxFornecedor.Name = "tbxFornecedor";
            this.tbxFornecedor.Size = new System.Drawing.Size(150, 23);
            this.tbxFornecedor.TabIndex = 8;
            // 
            // dtpValidade
            // 
            this.dtpValidade.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpValidade.Location = new System.Drawing.Point(387, 138);
            this.dtpValidade.Name = "dtpValidade";
            this.dtpValidade.Size = new System.Drawing.Size(150, 23);
            this.dtpValidade.TabIndex = 9;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(792, 18);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.TabIndex = 10;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.White;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpar.Location = new System.Drawing.Point(1093, 18);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(100, 30);
            this.btnLimpar.TabIndex = 11;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = false;
            // 
            // btnDeletar
            // 
            this.btnDeletar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnDeletar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDeletar.ForeColor = System.Drawing.Color.White;
            this.btnDeletar.Location = new System.Drawing.Point(965, 18);
            this.btnDeletar.Name = "btnDeletar";
            this.btnDeletar.Size = new System.Drawing.Size(100, 30);
            this.btnDeletar.TabIndex = 12;
            this.btnDeletar.Text = "Deletar";
            this.btnDeletar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(665, 18);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnNovaUnidade
            // 
            this.btnNovaUnidade.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNovaUnidade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaUnidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaUnidade.ForeColor = System.Drawing.Color.White;
            this.btnNovaUnidade.Location = new System.Drawing.Point(270, 96);
            this.btnNovaUnidade.Name = "btnNovaUnidade";
            this.btnNovaUnidade.Size = new System.Drawing.Size(25, 23);
            this.btnNovaUnidade.TabIndex = 14;
            this.btnNovaUnidade.Text = "+";
            this.btnNovaUnidade.UseVisualStyleBackColor = false;
            // 
            // btnNovaCategoria
            // 
            this.btnNovaCategoria.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnNovaCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovaCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovaCategoria.ForeColor = System.Drawing.Color.White;
            this.btnNovaCategoria.Location = new System.Drawing.Point(270, 65);
            this.btnNovaCategoria.Name = "btnNovaCategoria";
            this.btnNovaCategoria.Size = new System.Drawing.Size(25, 23);
            this.btnNovaCategoria.TabIndex = 15;
            this.btnNovaCategoria.Text = "+";
            this.btnNovaCategoria.UseVisualStyleBackColor = false;
            // 
            // btnMudarLucro
            // 
            this.btnMudarLucro.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMudarLucro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMudarLucro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMudarLucro.ForeColor = System.Drawing.Color.White;
            this.btnMudarLucro.Location = new System.Drawing.Point(120, 285);
            this.btnMudarLucro.Name = "btnMudarLucro";
            this.btnMudarLucro.Size = new System.Drawing.Size(25, 23);
            this.btnMudarLucro.TabIndex = 16;
            this.btnMudarLucro.Text = "+";
            this.btnMudarLucro.UseVisualStyleBackColor = false;
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Location = new System.Drawing.Point(557, 22);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.Size = new System.Drawing.Size(610, 297);
            this.dgvProdutos.TabIndex = 17;
            // 
            // lblProcurar
            // 
            this.lblProcurar.AutoSize = true;
            this.lblProcurar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProcurar.Location = new System.Drawing.Point(12, 19);
            this.lblProcurar.Name = "lblProcurar";
            this.lblProcurar.Size = new System.Drawing.Size(55, 15);
            this.lblProcurar.TabIndex = 18;
            this.lblProcurar.Text = "Procurar:";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNome.Location = new System.Drawing.Point(3, 36);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(43, 15);
            this.lblNome.TabIndex = 19;
            this.lblNome.Text = "Nome:";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTipo.Location = new System.Drawing.Point(3, 69);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(34, 15);
            this.lblTipo.TabIndex = 20;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblUnidade
            // 
            this.lblUnidade.AutoSize = true;
            this.lblUnidade.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUnidade.Location = new System.Drawing.Point(3, 100);
            this.lblUnidade.Name = "lblUnidade";
            this.lblUnidade.Size = new System.Drawing.Size(54, 15);
            this.lblUnidade.TabIndex = 21;
            this.lblUnidade.Text = "Unidade:";
            // 
            // lblPrecoCompra
            // 
            this.lblPrecoCompra.AutoSize = true;
            this.lblPrecoCompra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecoCompra.Location = new System.Drawing.Point(3, 141);
            this.lblPrecoCompra.Name = "lblPrecoCompra";
            this.lblPrecoCompra.Size = new System.Drawing.Size(86, 15);
            this.lblPrecoCompra.TabIndex = 22;
            this.lblPrecoCompra.Text = "Preço Compra:";
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDescricao.Location = new System.Drawing.Point(3, 181);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(61, 15);
            this.lblDescricao.TabIndex = 23;
            this.lblDescricao.Text = "Descrição:";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.AutoSize = true;
            this.lblQuantidade.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuantidade.Location = new System.Drawing.Point(306, 33);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(72, 15);
            this.lblQuantidade.TabIndex = 24;
            this.lblQuantidade.Text = "Quantidade:";
            // 
            // lblPrecoVenda
            // 
            this.lblPrecoVenda.AutoSize = true;
            this.lblPrecoVenda.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPrecoVenda.Location = new System.Drawing.Point(306, 73);
            this.lblPrecoVenda.Name = "lblPrecoVenda";
            this.lblPrecoVenda.Size = new System.Drawing.Size(75, 15);
            this.lblPrecoVenda.TabIndex = 25;
            this.lblPrecoVenda.Text = "Preço Venda:";
            // 
            // lblFornecedor
            // 
            this.lblFornecedor.AutoSize = true;
            this.lblFornecedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFornecedor.Location = new System.Drawing.Point(308, 107);
            this.lblFornecedor.Name = "lblFornecedor";
            this.lblFornecedor.Size = new System.Drawing.Size(70, 15);
            this.lblFornecedor.TabIndex = 26;
            this.lblFornecedor.Text = "Fornecedor:";
            this.lblFornecedor.Click += new System.EventHandler(this.lblFornecedor_Click);
            // 
            // lblValidade
            // 
            this.lblValidade.AutoSize = true;
            this.lblValidade.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValidade.Location = new System.Drawing.Point(324, 141);
            this.lblValidade.Name = "lblValidade";
            this.lblValidade.Size = new System.Drawing.Size(54, 15);
            this.lblValidade.TabIndex = 27;
            this.lblValidade.Text = "Validade:";
            // 
            // lblPrecoVendaRecomendado
            // 
            this.lblPrecoVendaRecomendado.AutoSize = true;
            this.lblPrecoVendaRecomendado.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblPrecoVendaRecomendado.Location = new System.Drawing.Point(324, 191);
            this.lblPrecoVendaRecomendado.Name = "lblPrecoVendaRecomendado";
            this.lblPrecoVendaRecomendado.Size = new System.Drawing.Size(154, 65);
            this.lblPrecoVendaRecomendado.TabIndex = 28;
            this.lblPrecoVendaRecomendado.Text = "Preço recomendado:\r\n- Preço compra: R$ 0,00\r\n- Lucro (30%): R$ 0,00\r\n- Preço vend" +
    "a sugerido: R$ 0,00\r\n- Margem real: 0%";
            this.lblPrecoVendaRecomendado.Visible = false;
            // 
            // lblPercentualLucro
            // 
            this.lblPercentualLucro.AutoSize = true;
            this.lblPercentualLucro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPercentualLucro.Location = new System.Drawing.Point(20, 288);
            this.lblPercentualLucro.Name = "lblPercentualLucro";
            this.lblPercentualLucro.Size = new System.Drawing.Size(87, 15);
            this.lblPercentualLucro.TabIndex = 29;
            this.lblPercentualLucro.Text = "Lucro: 30% (+)";
            // 
            // groupBoxBusca
            // 
            this.groupBoxBusca.Controls.Add(this.chkBuscarDescricao);
            this.groupBoxBusca.Controls.Add(this.chkBuscarFornecedor);
            this.groupBoxBusca.Controls.Add(this.chkBuscarCategoria);
            this.groupBoxBusca.Controls.Add(this.chkBuscarNome);
            this.groupBoxBusca.Controls.Add(this.tbxProcurar);
            this.groupBoxBusca.Controls.Add(this.lblProcurar);
            this.groupBoxBusca.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxBusca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxBusca.Location = new System.Drawing.Point(20, 20);
            this.groupBoxBusca.Name = "groupBoxBusca";
            this.groupBoxBusca.Size = new System.Drawing.Size(1173, 40);
            this.groupBoxBusca.TabIndex = 30;
            this.groupBoxBusca.TabStop = false;
            this.groupBoxBusca.Text = "Buscar por:";
            // 
            // chkBuscarDescricao
            // 
            this.chkBuscarDescricao.AutoSize = true;
            this.chkBuscarDescricao.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkBuscarDescricao.Location = new System.Drawing.Point(549, 15);
            this.chkBuscarDescricao.Name = "chkBuscarDescricao";
            this.chkBuscarDescricao.Size = new System.Drawing.Size(77, 19);
            this.chkBuscarDescricao.TabIndex = 19;
            this.chkBuscarDescricao.Text = "Descrição";
            this.chkBuscarDescricao.UseVisualStyleBackColor = true;
            // 
            // chkBuscarFornecedor
            // 
            this.chkBuscarFornecedor.AutoSize = true;
            this.chkBuscarFornecedor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkBuscarFornecedor.Location = new System.Drawing.Point(457, 15);
            this.chkBuscarFornecedor.Name = "chkBuscarFornecedor";
            this.chkBuscarFornecedor.Size = new System.Drawing.Size(86, 19);
            this.chkBuscarFornecedor.TabIndex = 2;
            this.chkBuscarFornecedor.Text = "Fornecedor";
            this.chkBuscarFornecedor.UseVisualStyleBackColor = true;
            // 
            // chkBuscarCategoria
            // 
            this.chkBuscarCategoria.AutoSize = true;
            this.chkBuscarCategoria.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkBuscarCategoria.Location = new System.Drawing.Point(374, 15);
            this.chkBuscarCategoria.Name = "chkBuscarCategoria";
            this.chkBuscarCategoria.Size = new System.Drawing.Size(77, 19);
            this.chkBuscarCategoria.TabIndex = 1;
            this.chkBuscarCategoria.Text = "Categoria";
            this.chkBuscarCategoria.UseVisualStyleBackColor = true;
            // 
            // chkBuscarNome
            // 
            this.chkBuscarNome.AutoSize = true;
            this.chkBuscarNome.Checked = true;
            this.chkBuscarNome.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBuscarNome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkBuscarNome.Location = new System.Drawing.Point(309, 15);
            this.chkBuscarNome.Name = "chkBuscarNome";
            this.chkBuscarNome.Size = new System.Drawing.Size(59, 19);
            this.chkBuscarNome.TabIndex = 0;
            this.chkBuscarNome.Text = "Nome";
            this.chkBuscarNome.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1213, 60);
            this.panel1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(500, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cadastro de Produtos";
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
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBoxBusca);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(1213, 405);
            this.panel2.TabIndex = 32;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.lblNome);
            this.groupBox1.Controls.Add(this.tbxNome);
            this.groupBox1.Controls.Add(this.lblTipo);
            this.groupBox1.Controls.Add(this.cbxTipo);
            this.groupBox1.Controls.Add(this.btnNovaCategoria);
            this.groupBox1.Controls.Add(this.lblUnidade);
            this.groupBox1.Controls.Add(this.cbxUnidade);
            this.groupBox1.Controls.Add(this.btnNovaUnidade);
            this.groupBox1.Controls.Add(this.lblPrecoCompra);
            this.groupBox1.Controls.Add(this.tbxPrecoCompra);
            this.groupBox1.Controls.Add(this.lblDescricao);
            this.groupBox1.Controls.Add(this.tbxDescricao);
            this.groupBox1.Controls.Add(this.lblQuantidade);
            this.groupBox1.Controls.Add(this.tbxQuantidade);
            this.groupBox1.Controls.Add(this.lblPrecoVenda);
            this.groupBox1.Controls.Add(this.tbxPrecoVenda);
            this.groupBox1.Controls.Add(this.lblFornecedor);
            this.groupBox1.Controls.Add(this.tbxFornecedor);
            this.groupBox1.Controls.Add(this.lblValidade);
            this.groupBox1.Controls.Add(this.dtpValidade);
            this.groupBox1.Controls.Add(this.lblPercentualLucro);
            this.groupBox1.Controls.Add(this.btnMudarLucro);
            this.groupBox1.Controls.Add(this.lblPrecoVendaRecomendado);
            this.groupBox1.Controls.Add(this.dgvProdutos);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(20, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1173, 325);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Produto";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.btnEditar);
            this.panel3.Controls.Add(this.btnSalvar);
            this.panel3.Controls.Add(this.btnDeletar);
            this.panel3.Controls.Add(this.btnLimpar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 465);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1213, 60);
            this.panel3.TabIndex = 33;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1213, 525);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Name = "Form4";
            this.Text = "Cadastro de Produtos";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.groupBoxBusca.ResumeLayout(false);
            this.groupBoxBusca.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }


    }
}