using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
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

       

        private void tbxEmail1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxSenha1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                // Coleta os dados dos TextBoxes
                string nome = tbxNome.Text;
                string nascimento = tbxNascimento.Text;
                string cpf = tbxCpf.Text;
                string rg = tbxRg.Text;
                string email = tbxEmail1.Text;
                string telefone = tbxTelefone.Text;
                string cidade = tbxCidade.Text;
                string rua = tbxRua.Text;
                string uf = tbxUf.Text;
                string cep = tbxCep.Text;
                string pais = tbxPais.Text;
                string senha = tbxSenha1.Text;

                // String de conexão
                string conexao = "Data Source=SQLEXPRESS;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();

                    // Verifica se o email já existe
                    string verificaSql = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";
                    using (SqlCommand verificaCmd = new SqlCommand(verificaSql, conn))
                    {
                        verificaCmd.Parameters.AddWithValue("@Email", email);
                        int existe = (int)verificaCmd.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show("Este email já está cadastrado.");
                            return;
                        }
                    }

                    // Insere novo usuário
                    string sql = @"INSERT INTO Usuario 
            (Nome, Nascimento, Cpf, Rg, Email, Telefone, Cidade, Rua, Uf, Cep, Pais, Senha) VALUES (@Nome, @Nascimento, @Cpf, @Rg, @Email, @Telefone, @Cidade, @Rua, @Uf, @Cep, @Pais, @Senha)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", nome);
                        cmd.Parameters.AddWithValue("@Nascimento", DateTime.Parse(nascimento));
                        cmd.Parameters.AddWithValue("@Cpf", cpf);
                        cmd.Parameters.AddWithValue("@Rg", rg);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Telefone", telefone);
                        cmd.Parameters.AddWithValue("@Cidade", cidade);
                        cmd.Parameters.AddWithValue("@Rua", rua);
                        cmd.Parameters.AddWithValue("@Uf", uf);
                        cmd.Parameters.AddWithValue("@Cep", cep);
                        cmd.Parameters.AddWithValue("@Pais", pais);
                        cmd.Parameters.AddWithValue("@Senha", senha);

                        cmd.ExecuteNonQuery(); 
                    }

                    MessageBox.Show("Cadastro realizado com sucesso!");

                    // Limpa os campos
                    tbxNome.Clear();
                    tbxNascimento.Clear();
                    tbxCpf.Clear();
                    tbxRg.Clear();
                    tbxEmail1.Clear();
                    tbxTelefone.Clear();
                    tbxCidade.Clear();
                    tbxRua.Clear();
                    tbxUf.Clear();
                    tbxCep.Clear();
                    tbxPais.Clear();
                    tbxSenha1.Clear();
                }
            }
        }


        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void texNacimento_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
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
