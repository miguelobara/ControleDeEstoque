namespace ControleDeEstoque
{
    partial class Form9
    {
        private System.ComponentModel.IContainer components = null;

        // Componentes da UI
        private System.Windows.Forms.Panel panelTopo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.GroupBox gbxNovaVenda;
        private System.Windows.Forms.ComboBox cbxProduto;
        private System.Windows.Forms.Label lblEstoqueDisponivel;
        private System.Windows.Forms.NumericUpDown nudQuantidade;
        private System.Windows.Forms.Label lblPrecoUnitario;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnRegistrarVenda;
        private System.Windows.Forms.DataGridView dgvProdutosDisponiveis;
        private System.Windows.Forms.GroupBox gbxHistorico;
        private System.Windows.Forms.DateTimePicker dtpFiltroInicio;
        private System.Windows.Forms.DateTimePicker dtpFiltroFim;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnCancelarVenda;
        private System.Windows.Forms.DataGridView dgvVendas;
        private System.Windows.Forms.Label lblProduto;
        private System.Windows.Forms.Label lblQtd;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblFiltro;
        private System.Windows.Forms.Label lblAte;

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
            this.panelTopo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.gbxNovaVenda = new System.Windows.Forms.GroupBox();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblPreco = new System.Windows.Forms.Label();
            this.lblQtd = new System.Windows.Forms.Label();
            this.lblProduto = new System.Windows.Forms.Label();
            this.btnRegistrarVenda = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPrecoUnitario = new System.Windows.Forms.Label();
            this.nudQuantidade = new System.Windows.Forms.NumericUpDown();
            this.lblEstoqueDisponivel = new System.Windows.Forms.Label();
            this.cbxProduto = new System.Windows.Forms.ComboBox();
            this.dgvProdutosDisponiveis = new System.Windows.Forms.DataGridView();
            this.gbxHistorico = new System.Windows.Forms.GroupBox();
            this.lblAte = new System.Windows.Forms.Label();
            this.lblFiltro = new System.Windows.Forms.Label();
            this.btnCancelarVenda = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.dtpFiltroFim = new System.Windows.Forms.DateTimePicker();
            this.dtpFiltroInicio = new System.Windows.Forms.DateTimePicker();
            this.dgvVendas = new System.Windows.Forms.DataGridView();
            this.panelTopo.SuspendLayout();
            this.gbxNovaVenda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosDisponiveis)).BeginInit();
            this.gbxHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTopo
            // 
            this.panelTopo.BackColor = System.Drawing.Color.RoyalBlue;
            this.panelTopo.Controls.Add(this.lblTitulo);
            this.panelTopo.Controls.Add(this.btnVoltar);
            this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopo.Location = new System.Drawing.Point(0, 0);
            this.panelTopo.Name = "panelTopo";
            this.panelTopo.Size = new System.Drawing.Size(1200, 60);
            this.panelTopo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(269, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "🛒 SISTEMA DE VENDAS";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Green;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnVoltar.ForeColor = System.Drawing.Color.White;
            this.btnVoltar.Location = new System.Drawing.Point(1000, 15);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(100, 35);
            this.btnVoltar.TabIndex = 1;
            this.btnVoltar.Text = "← Voltar";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.BtnVoltar_Click);
            // 
            // gbxNovaVenda
            // 
            this.gbxNovaVenda.Controls.Add(this.lblTotalLabel);
            this.gbxNovaVenda.Controls.Add(this.lblPreco);
            this.gbxNovaVenda.Controls.Add(this.lblQtd);
            this.gbxNovaVenda.Controls.Add(this.lblProduto);
            this.gbxNovaVenda.Controls.Add(this.btnRegistrarVenda);
            this.gbxNovaVenda.Controls.Add(this.lblTotal);
            this.gbxNovaVenda.Controls.Add(this.lblPrecoUnitario);
            this.gbxNovaVenda.Controls.Add(this.nudQuantidade);
            this.gbxNovaVenda.Controls.Add(this.lblEstoqueDisponivel);
            this.gbxNovaVenda.Controls.Add(this.cbxProduto);
            this.gbxNovaVenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbxNovaVenda.Location = new System.Drawing.Point(20, 80);
            this.gbxNovaVenda.Name = "gbxNovaVenda";
            this.gbxNovaVenda.Size = new System.Drawing.Size(400, 280);
            this.gbxNovaVenda.TabIndex = 1;
            this.gbxNovaVenda.TabStop = false;
            this.gbxNovaVenda.Text = "Nova Venda";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Location = new System.Drawing.Point(200, 165);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(54, 19);
            this.lblTotalLabel.TabIndex = 9;
            this.lblTotalLabel.Text = "TOTAL:";
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(20, 165);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(110, 19);
            this.lblPreco.TabIndex = 8;
            this.lblPreco.Text = "Preço Unitário:";
            // 
            // lblQtd
            // 
            this.lblQtd.AutoSize = true;
            this.lblQtd.Location = new System.Drawing.Point(20, 110);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(91, 19);
            this.lblQtd.TabIndex = 7;
            this.lblQtd.Text = "Quantidade:";
            // 
            // lblProduto
            // 
            this.lblProduto.AutoSize = true;
            this.lblProduto.Location = new System.Drawing.Point(20, 30);
            this.lblProduto.Name = "lblProduto";
            this.lblProduto.Size = new System.Drawing.Size(68, 19);
            this.lblProduto.TabIndex = 6;
            this.lblProduto.Text = "Produto:";
            // 
            // btnRegistrarVenda
            // 
            this.btnRegistrarVenda.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnRegistrarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarVenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarVenda.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarVenda.Location = new System.Drawing.Point(20, 230);
            this.btnRegistrarVenda.Name = "btnRegistrarVenda";
            this.btnRegistrarVenda.Size = new System.Drawing.Size(350, 35);
            this.btnRegistrarVenda.TabIndex = 5;
            this.btnRegistrarVenda.Text = "REGISTRAR VENDA";
            this.btnRegistrarVenda.UseVisualStyleBackColor = false;
            this.btnRegistrarVenda.Click += new System.EventHandler(this.BtnRegistrarVenda_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotal.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotal.Location = new System.Drawing.Point(200, 185);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(78, 25);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "R$ 0,00";
            // 
            // lblPrecoUnitario
            // 
            this.lblPrecoUnitario.AutoSize = true;
            this.lblPrecoUnitario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPrecoUnitario.ForeColor = System.Drawing.Color.Green;
            this.lblPrecoUnitario.Location = new System.Drawing.Point(20, 185);
            this.lblPrecoUnitario.Name = "lblPrecoUnitario";
            this.lblPrecoUnitario.Size = new System.Drawing.Size(64, 21);
            this.lblPrecoUnitario.TabIndex = 3;
            this.lblPrecoUnitario.Text = "R$ 0,00";
            // 
            // nudQuantidade
            // 
            this.nudQuantidade.Location = new System.Drawing.Point(20, 135);
            this.nudQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantidade.Name = "nudQuantidade";
            this.nudQuantidade.Size = new System.Drawing.Size(120, 25);
            this.nudQuantidade.TabIndex = 2;
            this.nudQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantidade.ValueChanged += new System.EventHandler(this.NudQuantidade_ValueChanged);
            // 
            // lblEstoqueDisponivel
            // 
            this.lblEstoqueDisponivel.AutoSize = true;
            this.lblEstoqueDisponivel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblEstoqueDisponivel.ForeColor = System.Drawing.Color.Blue;
            this.lblEstoqueDisponivel.Location = new System.Drawing.Point(20, 85);
            this.lblEstoqueDisponivel.Name = "lblEstoqueDisponivel";
            this.lblEstoqueDisponivel.Size = new System.Drawing.Size(59, 15);
            this.lblEstoqueDisponivel.TabIndex = 1;
            this.lblEstoqueDisponivel.Text = "Estoque: -";
            // 
            // cbxProduto
            // 
            this.cbxProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxProduto.FormattingEnabled = true;
            this.cbxProduto.Location = new System.Drawing.Point(20, 55);
            this.cbxProduto.Name = "cbxProduto";
            this.cbxProduto.Size = new System.Drawing.Size(350, 25);
            this.cbxProduto.TabIndex = 0;
            this.cbxProduto.SelectedIndexChanged += new System.EventHandler(this.CbxProduto_SelectedIndexChanged);
            // 
            // dgvProdutosDisponiveis
            // 
            this.dgvProdutosDisponiveis.AllowUserToAddRows = false;
            this.dgvProdutosDisponiveis.AllowUserToDeleteRows = false;
            this.dgvProdutosDisponiveis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProdutosDisponiveis.BackgroundColor = System.Drawing.Color.White;
            this.dgvProdutosDisponiveis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutosDisponiveis.Location = new System.Drawing.Point(440, 80);
            this.dgvProdutosDisponiveis.Name = "dgvProdutosDisponiveis";
            this.dgvProdutosDisponiveis.ReadOnly = true;
            this.dgvProdutosDisponiveis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProdutosDisponiveis.Size = new System.Drawing.Size(720, 280);
            this.dgvProdutosDisponiveis.TabIndex = 2;
            // 
            // gbxHistorico
            // 
            this.gbxHistorico.Controls.Add(this.lblAte);
            this.gbxHistorico.Controls.Add(this.lblFiltro);
            this.gbxHistorico.Controls.Add(this.btnCancelarVenda);
            this.gbxHistorico.Controls.Add(this.btnFiltrar);
            this.gbxHistorico.Controls.Add(this.dtpFiltroFim);
            this.gbxHistorico.Controls.Add(this.dtpFiltroInicio);
            this.gbxHistorico.Controls.Add(this.dgvVendas);
            this.gbxHistorico.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbxHistorico.Location = new System.Drawing.Point(20, 375);
            this.gbxHistorico.Name = "gbxHistorico";
            this.gbxHistorico.Size = new System.Drawing.Size(1140, 280);
            this.gbxHistorico.TabIndex = 3;
            this.gbxHistorico.TabStop = false;
            this.gbxHistorico.Text = "Histórico de Vendas";
            // 
            // lblAte
            // 
            this.lblAte.AutoSize = true;
            this.lblAte.Location = new System.Drawing.Point(295, 24);
            this.lblAte.Name = "lblAte";
            this.lblAte.Size = new System.Drawing.Size(30, 19);
            this.lblAte.TabIndex = 6;
            this.lblAte.Text = "até";
            // 
            // lblFiltro
            // 
            this.lblFiltro.AutoSize = true;
            this.lblFiltro.Location = new System.Drawing.Point(20, 25);
            this.lblFiltro.Name = "lblFiltro";
            this.lblFiltro.Size = new System.Drawing.Size(139, 19);
            this.lblFiltro.TabIndex = 5;
            this.lblFiltro.Text = "Filtrar por período:";
            // 
            // btnCancelarVenda
            // 
            this.btnCancelarVenda.BackColor = System.Drawing.Color.Crimson;
            this.btnCancelarVenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVenda.ForeColor = System.Drawing.Color.White;
            this.btnCancelarVenda.Location = new System.Drawing.Point(900, 20);
            this.btnCancelarVenda.Name = "btnCancelarVenda";
            this.btnCancelarVenda.Size = new System.Drawing.Size(200, 28);
            this.btnCancelarVenda.TabIndex = 4;
            this.btnCancelarVenda.Text = "Cancelar Venda Selecionada";
            this.btnCancelarVenda.UseVisualStyleBackColor = false;
            this.btnCancelarVenda.Click += new System.EventHandler(this.BtnCancelarVenda_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.SteelBlue;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.ForeColor = System.Drawing.Color.White;
            this.btnFiltrar.Location = new System.Drawing.Point(468, 20);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(80, 28);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.BtnFiltrar_Click);
            // 
            // dtpFiltroFim
            // 
            this.dtpFiltroFim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroFim.Location = new System.Drawing.Point(331, 24);
            this.dtpFiltroFim.Name = "dtpFiltroFim";
            this.dtpFiltroFim.Size = new System.Drawing.Size(120, 25);
            this.dtpFiltroFim.TabIndex = 2;
            // 
            // dtpFiltroInicio
            // 
            this.dtpFiltroInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltroInicio.Location = new System.Drawing.Point(158, 24);
            this.dtpFiltroInicio.Name = "dtpFiltroInicio";
            this.dtpFiltroInicio.Size = new System.Drawing.Size(120, 25);
            this.dtpFiltroInicio.TabIndex = 1;
            this.dtpFiltroInicio.Value = new System.DateTime(2025, 10, 2, 0, 0, 0, 0);
            // 
            // dgvVendas
            // 
            this.dgvVendas.AllowUserToAddRows = false;
            this.dgvVendas.AllowUserToDeleteRows = false;
            this.dgvVendas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVendas.BackgroundColor = System.Drawing.Color.White;
            this.dgvVendas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVendas.Location = new System.Drawing.Point(20, 60);
            this.dgvVendas.Name = "dgvVendas";
            this.dgvVendas.ReadOnly = true;
            this.dgvVendas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVendas.Size = new System.Drawing.Size(1100, 200);
            this.dgvVendas.TabIndex = 0;
            // 
            // Form9
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.gbxHistorico);
            this.Controls.Add(this.dgvProdutosDisponiveis);
            this.Controls.Add(this.gbxNovaVenda);
            this.Controls.Add(this.panelTopo);
            this.Name = "Form9";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Vendas";
            this.Load += new System.EventHandler(this.Form9_Load);
            this.panelTopo.ResumeLayout(false);
            this.panelTopo.PerformLayout();
            this.gbxNovaVenda.ResumeLayout(false);
            this.gbxNovaVenda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutosDisponiveis)).EndInit();
            this.gbxHistorico.ResumeLayout(false);
            this.gbxHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVendas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}