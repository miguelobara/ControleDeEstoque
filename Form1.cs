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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void FrmEnter_Click(object sender, EventArgs e)
        {
            string email = tbxEmail.Text;
            string senha = tbxSenha.Text;


            string conexao = "Data Source=sqlexpress;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";
           

                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();

                    // verifica se o email já existe
                    string verificasql = "select count(*) from Usuario where Email = @Email and Senha = @Senha";
                    using (SqlCommand cmd = new SqlCommand(verificasql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Senha", senha);

                        int existe = (int)cmd.ExecuteScalar();

                        if (existe > 0)
                        {
                            Form2 product = new Form2();
                            this.Visible = false;
                            product.ShowDialog();
                            if(!this.IsDisposed)
                                this.Visible = true;

                        }
                        else
                        {
                            MessageBox.Show("Email ou Senha incorretos");
                        }
                    }
                }
           
        }

        private void texboxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 product = new Form5();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tbxSenha_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
