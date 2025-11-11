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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ControleDeEstoque
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Email = tbxEmail1.Text;
            string senha = tbxSenha1.Text;

            string conexao = "Data Source=sqlexpress;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";


            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();

               // Verifica se o email já existe
                string verificaSql = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";
                using (SqlCommand verificaCmd = new SqlCommand(verificaSql, conn))
                {
                    verificaCmd.Parameters.AddWithValue("@Email", Email);
                    int existe = (int)verificaCmd.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("Este email já está cadastrado.");
                        return;
                    }
                }

                //Insere novo usuário
                string sql = "INSERT INTO Usuario (Email, Senha) VALUES (@Email, @Senha)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", senha);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cadastro realizado com sucesso!");
                tbxEmail1.Clear();
                tbxSenha1.Clear();
            }
        }
        

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Form1 product = new Form1();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }

        private void tbxEmail1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxEmail1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
