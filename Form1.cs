using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       

        private void FrmEnter_Click(object sender, EventArgs e)
        {
            string Email = tbxEmail.Text;
            string senha = tbxSenha.Text;
            MessageBox.Show("Email: " + Email + "\nSenha: " + senha );

            Form2 product = new Form2();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;

        }

        private void texboxName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 product = new Form3();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
