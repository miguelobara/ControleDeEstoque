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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void btnAdicionarFor_Click(object sender, EventArgs e)
        {
            string conexao = "Data Source=SQLEXPRESS;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

            // Captura dos campos da interface
            string nome = tbxNome_For.Text.Trim();
            string cnpj = tbxCnpj_For.Text.Trim();
            string telefone = tbxTelefone_For.Text.Trim();
            string email = tbxEmail_For.Text.Trim();
            string cidade = tbxCidade_For.Text.Trim();
            string rua = tbxRua_For.Text.Trim();
            string uf = tbxUf_For.Text.Trim();
            string cep = tbxCep_For.Text.Trim();
            string estatus = "A"; // ou "I" se quiser usar checkbox futuramente


            // Validação de Data
            if (!DateTime.TryParse(tbxData_Cadastro_For.Text, out DateTime dataCadastro))
            {
                MessageBox.Show("Data de cadastro inválida.");
                return;
            }

            // Comando SQL (sem Id_Fornecedor, pois é gerado automaticamente)
            string query = @"
INSERT INTO Fornecedor 
(Nome_For, Cnpj_For, Telefone_For, Email_For, Cidade_For, Rua_For, Uf_For, Cep_For, Data_Cadastro_For, estatus_For)
VALUES 
(@Nome, @Cnpj, @Telefone, @Email, @Cidade, @Rua, @Uf, @Cep, @DataCadastro, @Estatus)";

            using (SqlConnection conn = new SqlConnection(conexao))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Parâmetros
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Cnpj", cnpj);
                cmd.Parameters.AddWithValue("@Telefone", telefone);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Cidade", cidade);
                cmd.Parameters.AddWithValue("@Rua", rua);
                cmd.Parameters.AddWithValue("@Uf", uf);
                cmd.Parameters.AddWithValue("@Cep", cep);
                cmd.Parameters.AddWithValue("@DataCadastro", dataCadastro);
                cmd.Parameters.AddWithValue("@Estatus", estatus);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fornecedor cadastrado com sucesso!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro de SQL: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado: " + ex.Message);
                }
            }
        }

        

        private void tbxEmail_For_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxRua_For_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form2 product = new Form2();
            this.Visible = false;
            product.ShowDialog();
            this.Visible = true;
        }
    }
}
