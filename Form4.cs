using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'cJ3027511PR2DataSet4.Tipo'. Você pode movê-la ou removê-la conforme necessário.
            this.tipoTableAdapter2.Fill(this.cJ3027511PR2DataSet4.Tipo);
            // TODO: esta linha de código carrega dados na tabela 'cJ3027511PR2DataSet4.Produto'. Você pode movê-la ou removê-la conforme necessário.
            this.produtoTableAdapter.Fill(this.cJ3027511PR2DataSet4.Produto);
            // TODO: esta linha de código carrega dados na tabela 'cJ3027511PR2DataSet2.Tipo'. Você pode movê-la ou removê-la conforme necessário.
            this.tipoTableAdapter1.Fill(this.cJ3027511PR2DataSet2.Tipo);
            // TODO: esta linha de código carrega dados na tabela 'cJ3027511PR2DataSet1.Tipo'. Você pode movê-la ou removê-la conforme necessário.
            this.tipoTableAdapter.Fill(this.cJ3027511PR2DataSet1.Tipo);

            this.usuarioTableAdapter.Fill(this.cJ3027511PR2DataSet.Usuario);

        }



        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        

        

        
        private void textBox5_Click(object sender, EventArgs e)
        {
            tbxDescricao.Clear();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            this.tbxDescricao.Size = new System.Drawing.Size(482, 59);
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            this.tbxDescricao.Size = new System.Drawing.Size(100, 22);
        }

        private void textBox6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }



        private void textBox7_Click(object sender, EventArgs e)
        {

        }
      

        private void btnRenomearTip_Click(object sender, EventArgs e)
        {


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tbxNome_Tipo_TextChanged(object sender, EventArgs e)
        {

        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.produtoTableAdapter.FillBy(this.cJ3027511PR2DataSet4.Produto);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy1ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.produtoTableAdapter.FillBy1(this.cJ3027511PR2DataSet4.Produto);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillBy2ToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.produtoTableAdapter.FillBy2(this.cJ3027511PR2DataSet4.Produto);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
 
        private void tbxNome_Tipo_Prod_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void tbxValidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

