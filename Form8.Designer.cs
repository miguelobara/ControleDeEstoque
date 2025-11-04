namespace ControleDeEstoque
{
    partial class Form8
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelMetricas = new System.Windows.Forms.Panel();
            this.lblLucroTopProduto = new System.Windows.Forms.Label();
            this.lblProdutoMaisLucrativo = new System.Windows.Forms.Label();
            this.lblMargemLucro = new System.Windows.Forms.Label();
            this.lblCustoTotal = new System.Windows.Forms.Label();
            this.lblReceitaTotal = new System.Windows.Forms.Label();
            this.lblLucroTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnFiltrarPeriodo = new System.Windows.Forms.Button();
            this.dtpFim = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridViewLucros = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panelMetricas.SuspendLayout();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLucros)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 60);
            this.panel1.TabIndex = 1;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(185, 25);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Análise de Lucros";
            // 
            // panelMetricas
            // 
            this.panelMetricas.BackColor = System.Drawing.Color.White;
            this.panelMetricas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMetricas.Controls.Add(this.lblLucroTopProduto);
            this.panelMetricas.Controls.Add(this.lblProdutoMaisLucrativo);
            this.panelMetricas.Controls.Add(this.lblMargemLucro);
            this.panelMetricas.Controls.Add(this.lblCustoTotal);
            this.panelMetricas.Controls.Add(this.lblReceitaTotal);
            this.panelMetricas.Controls.Add(this.lblLucroTotal);
            this.panelMetricas.Controls.Add(this.label8);
            this.panelMetricas.Controls.Add(this.label7);
            this.panelMetricas.Controls.Add(this.label6);
            this.panelMetricas.Controls.Add(this.label5);
            this.panelMetricas.Controls.Add(this.label4);
            this.panelMetricas.Controls.Add(this.label3);
            this.panelMetricas.Controls.Add(this.label2);
            this.panelMetricas.Location = new System.Drawing.Point(20, 80);
            this.panelMetricas.Name = "panelMetricas";
            this.panelMetricas.Size = new System.Drawing.Size(960, 100);
            this.panelMetricas.TabIndex = 2;
            // 
            // lblLucroTopProduto
            // 
            this.lblLucroTopProduto.AutoSize = true;
            this.lblLucroTopProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLucroTopProduto.Location = new System.Drawing.Point(820, 60);
            this.lblLucroTopProduto.Name = "lblLucroTopProduto";
            this.lblLucroTopProduto.Size = new System.Drawing.Size(57, 15);
            this.lblLucroTopProduto.TabIndex = 12;
            this.lblLucroTopProduto.Text = "R$ 0,00";
            // 
            // lblProdutoMaisLucrativo
            // 
            this.lblProdutoMaisLucrativo.AutoSize = true;
            this.lblProdutoMaisLucrativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProdutoMaisLucrativo.Location = new System.Drawing.Point(820, 30);
            this.lblProdutoMaisLucrativo.Name = "lblProdutoMaisLucrativo";
            this.lblProdutoMaisLucrativo.Size = new System.Drawing.Size(61, 15);
            this.lblProdutoMaisLucrativo.TabIndex = 11;
            this.lblProdutoMaisLucrativo.Text = "Nenhum";
            // 
            // lblMargemLucro
            // 
            this.lblMargemLucro.AutoSize = true;
            this.lblMargemLucro.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMargemLucro.Location = new System.Drawing.Point(650, 60);
            this.lblMargemLucro.Name = "lblMargemLucro";
            this.lblMargemLucro.Size = new System.Drawing.Size(27, 15);
            this.lblMargemLucro.TabIndex = 10;
            this.lblMargemLucro.Text = "0%";
            // 
            // lblCustoTotal
            // 
            this.lblCustoTotal.AutoSize = true;
            this.lblCustoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustoTotal.Location = new System.Drawing.Point(650, 30);
            this.lblCustoTotal.Name = "lblCustoTotal";
            this.lblCustoTotal.Size = new System.Drawing.Size(57, 15);
            this.lblCustoTotal.TabIndex = 9;
            this.lblCustoTotal.Text = "R$ 0,00";
            // 
            // lblReceitaTotal
            // 
            this.lblReceitaTotal.AutoSize = true;
            this.lblReceitaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceitaTotal.Location = new System.Drawing.Point(450, 60);
            this.lblReceitaTotal.Name = "lblReceitaTotal";
            this.lblReceitaTotal.Size = new System.Drawing.Size(57, 15);
            this.lblReceitaTotal.TabIndex = 8;
            this.lblReceitaTotal.Text = "R$ 0,00";
            // 
            // lblLucroTotal
            // 
            this.lblLucroTotal.AutoSize = true;
            this.lblLucroTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLucroTotal.Location = new System.Drawing.Point(450, 30);
            this.lblLucroTotal.Name = "lblLucroTotal";
            this.lblLucroTotal.Size = new System.Drawing.Size(57, 15);
            this.lblLucroTotal.TabIndex = 7;
            this.lblLucroTotal.Text = "R$ 0,00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(700, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Produto + Lucrativo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(700, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Produto + Lucrativo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(550, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Margem Lucro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Custo Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(350, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Receita Total:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Lucro Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Métricas:";
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.White;
            this.panelFiltros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFiltros.Controls.Add(this.btnAtualizar);
            this.panelFiltros.Controls.Add(this.btnExportar);
            this.panelFiltros.Controls.Add(this.btnFiltrarPeriodo);
            this.panelFiltros.Controls.Add(this.dtpFim);
            this.panelFiltros.Controls.Add(this.dtpInicio);
            this.panelFiltros.Controls.Add(this.label10);
            this.panelFiltros.Controls.Add(this.label9);
            this.panelFiltros.Location = new System.Drawing.Point(20, 200);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(960, 60);
            this.panelFiltros.TabIndex = 3;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(800, 20);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 6;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(700, 20);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 5;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnFiltrarPeriodo
            // 
            this.btnFiltrarPeriodo.Location = new System.Drawing.Point(450, 20);
            this.btnFiltrarPeriodo.Name = "btnFiltrarPeriodo";
            this.btnFiltrarPeriodo.Size = new System.Drawing.Size(75, 23);
            this.btnFiltrarPeriodo.TabIndex = 4;
            this.btnFiltrarPeriodo.Text = "Filtrar";
            this.btnFiltrarPeriodo.UseVisualStyleBackColor = true;
            this.btnFiltrarPeriodo.Click += new System.EventHandler(this.btnFiltrarPeriodo_Click);
            // 
            // dtpFim
            // 
            this.dtpFim.Location = new System.Drawing.Point(300, 20);
            this.dtpFim.Name = "dtpFim";
            this.dtpFim.Size = new System.Drawing.Size(120, 20);
            this.dtpFim.TabIndex = 3;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Location = new System.Drawing.Point(100, 20);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(120, 20);
            this.dtpInicio.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(250, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Fim:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Início:";
            // 
            // dataGridViewLucros
            // 
            this.dataGridViewLucros.AllowUserToAddRows = false;
            this.dataGridViewLucros.AllowUserToDeleteRows = false;
            this.dataGridViewLucros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewLucros.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLucros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLucros.Location = new System.Drawing.Point(20, 280);
            this.dataGridViewLucros.Name = "dataGridViewLucros";
            this.dataGridViewLucros.ReadOnly = true;
            this.dataGridViewLucros.Size = new System.Drawing.Size(960, 300);
            this.dataGridViewLucros.TabIndex = 4;
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.dataGridViewLucros);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.panelMetricas);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "Form8";
            this.Text = "Análise de Lucros";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form8_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMetricas.ResumeLayout(false);
            this.panelMetricas.PerformLayout();
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLucros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelMetricas;
        private System.Windows.Forms.Label lblLucroTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLucroTopProduto;
        private System.Windows.Forms.Label lblProdutoMaisLucrativo;
        private System.Windows.Forms.Label lblMargemLucro;
        private System.Windows.Forms.Label lblCustoTotal;
        private System.Windows.Forms.Label lblReceitaTotal;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnFiltrarPeriodo;
        private System.Windows.Forms.DateTimePicker dtpFim;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridViewLucros;
    }
}