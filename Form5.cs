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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 product = new Form3();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // Form5
        //    // 
        //    this.ClientSize = new System.Drawing.Size(172, 503);
        //    this.Name = "Form5";
        //    this.ResumeLayout(false);

        //}
    }
}
