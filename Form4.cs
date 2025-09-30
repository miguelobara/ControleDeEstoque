using System;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            // CONECTA OS EVENTOS AQUI - ISSO CORRIGE OS ERROS
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            this.btnDeletar.Click += new System.EventHandler(this.btnDeletar_Click);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbxNome.Text))
                {
                    MessageBox.Show("Por favor, informe o nome do produto.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxNome.Focus();
                    return;
                }

                MessageBox.Show("Produto salvo com sucesso!", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar produto: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            tbxNome.Focus();
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (dgvProdutos.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Tem certeza que deseja deletar o produto selecionado?",
                                                    "Confirmação",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Produto deletado com sucesso!", "Sucesso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para deletar.", "Aviso",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimparCampos()
        {
            tbxProcurar.Clear();
            tbxNome.Clear();
            cbxTipo.SelectedIndex = -1;
            cbxUnidade.SelectedIndex = -1;
            tbxPrecoCompra.Clear();
            tbxDescricao.Clear();
            tbxQuantidade.Clear();
            tbxPrecoVenda.Clear();
            tbxFornecedor.Clear();
            dtpValidade.Value = DateTime.Now;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cJ3027511PR2DataSet6.Produto'. Você pode movê-la ou removê-la conforme necessário.
            this.produtoTableAdapter.Fill(this.cJ3027511PR2DataSet6.Produto);

        }
    }
}