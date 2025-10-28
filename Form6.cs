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
using System.Text.RegularExpressions;

namespace ControleDeEstoque
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            ConfigureDataPicker();
            ConfigureMasks();
        }

        private void ConfigureDataPicker()
        {
            dtpDataCadastro.Format = DateTimePickerFormat.Short;
            dtpDataCadastro.Value = DateTime.Today;
        }

        private void ConfigureMasks()
        {
            // Configurar máscaras para melhor usabilidade
            mtbCnpj.Mask = "00,000,000/0000-00";
            mtbTelefone.Mask = "(00) 00000-0000";
            mtbCep.Mask = "00000-000";
            mtbUf.Mask = "AA";
        }

        private void btnAdicionarFor_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            string conexao = "Data Source=SQLEXPRESS;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

            // Captura dos campos da interface
            string nome = tbxNome_For.Text.Trim();
            string cnpj = mtbCnpj.Text.Replace(",", "").Replace("/", "").Replace("-", "").Replace(".", "");
            string telefone = mtbTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            string email = tbxEmail_For.Text.Trim();
            string cidade = tbxCidade_For.Text.Trim();
            string rua = tbxRua_For.Text.Trim();
            string uf = mtbUf.Text.ToUpper();
            string cep = mtbCep.Text.Replace("-", "");
            string estatus = "A";
            DateTime dataCadastro = dtpDataCadastro.Value;

            string query = @"
INSERT INTO Fornecedor 
(Nome_For, Cnpj_For, Telefone_For, Email_For, Cidade_For, Rua_For, Uf_For, Cep_For, Data_Cadastro_For, estatus_For)
VALUES 
(@Nome, @Cnpj, @Telefone, @Email, @Cidade, @Rua, @Uf, @Cep, @DataCadastro, @Estatus)";

            using (SqlConnection conn = new SqlConnection(conexao))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
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
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Fornecedor cadastrado com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparCampos();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Erro de SQL: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            // Validação básica dos campos
            if (string.IsNullOrWhiteSpace(tbxNome_For.Text))
            {
                MessageBox.Show("Por favor, informe o nome do fornecedor.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxNome_For.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(mtbCnpj.Text) || mtbCnpj.Text.Contains(" "))
            {
                MessageBox.Show("Por favor, informe um CNPJ válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                mtbCnpj.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbxEmail_For.Text) || !IsValidEmail(tbxEmail_For.Text))
            {
                MessageBox.Show("Por favor, informe um e-mail válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxEmail_For.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void LimparCampos()
        {
            tbxNome_For.Clear();
            mtbCnpj.Clear();
            mtbTelefone.Clear();
            tbxEmail_For.Clear();
            tbxCidade_For.Clear();
            tbxRua_For.Clear();
            mtbUf.Clear();
            mtbCep.Clear();
            dtpDataCadastro.Value = DateTime.Today;
            tbxNome_For.Focus();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Form7 product = new Form7();
            this.Hide();
            product.ShowDialog();
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

     
    }
}