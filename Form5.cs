using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ControleDeEstoque
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            this.AcceptButton = btnCriar;

            // Adicionar placeholder manualmente (para versões antigas do .NET)
            AddPlaceholderText();
        }

        private void AddPlaceholderText()
        {
            // Simular placeholder para versões antigas
            tbxNascimento.Enter += (s, e) =>
            {
                if (tbxNascimento.Text == "DD/MM/AAAA")
                    tbxNascimento.Text = "";
            };

            tbxNascimento.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tbxNascimento.Text))
                    tbxNascimento.Text = "DD/MM/AAAA";
            };

            // Definir texto inicial
            if (string.IsNullOrWhiteSpace(tbxNascimento.Text))
                tbxNascimento.Text = "DD/MM/AAAA";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                CadastrarUsuario();
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(tbxNome.Text) || tbxNome.Text == "Nome")
            {
                MessageBox.Show("Por favor, preencha o campo Nome.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbxEmail1.Text) || tbxEmail1.Text == "Email")
            {
                MessageBox.Show("Por favor, preencha o campo Email.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxEmail1.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbxSenha1.Text))
            {
                MessageBox.Show("Por favor, preencha o campo Senha.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxSenha1.Focus();
                return false;
            }

            // Validar formato da data
            if (tbxNascimento.Text != "DD/MM/AAAA" && !string.IsNullOrWhiteSpace(tbxNascimento.Text))
            {
                try
                {
                    DateTime.Parse(tbxNascimento.Text);
                }
                catch
                {
                    MessageBox.Show("Por favor, insira uma data válida no formato DD/MM/AAAA.", "Data Inválida",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    tbxNascimento.Focus();
                    return false;
                }
            }

            return true;
        }

        private void CadastrarUsuario()
        {
            try
            {
                string conexao = "Data Source=SQLEXPRESS;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

                using (SqlConnection conn = new SqlConnection(conexao))
                {
                    conn.Open();

                    // Verificar se email já existe
                    string verificaSql = "SELECT COUNT(*) FROM Usuario WHERE Email = @Email";
                    using (SqlCommand verificaCmd = new SqlCommand(verificaSql, conn))
                    {
                        verificaCmd.Parameters.AddWithValue("@Email", tbxEmail1.Text.Trim());
                        int existe = (int)verificaCmd.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show("Este email já está cadastrado.", "Email Existente",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Inserir novo usuário
                    string sql = @"INSERT INTO Usuario 
                    (Nome, Nascimento, Cpf, Rg, Email, Telefone, Cidade, Rua, Uf, Cep, Pais, Senha) 
                    VALUES (@Nome, @Nascimento, @Cpf, @Rg, @Email, @Telefone, @Cidade, @Rua, @Uf, @Cep, @Pais, @Senha)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", tbxNome.Text.Trim());

                        // Tratar data de nascimento
                        if (tbxNascimento.Text != "DD/MM/AAAA" && !string.IsNullOrWhiteSpace(tbxNascimento.Text))
                            cmd.Parameters.AddWithValue("@Nascimento", DateTime.Parse(tbxNascimento.Text.Trim()));
                        else
                            cmd.Parameters.AddWithValue("@Nascimento", DBNull.Value);

                        cmd.Parameters.AddWithValue("@Cpf", string.IsNullOrWhiteSpace(tbxCpf.Text) ? DBNull.Value : (object)tbxCpf.Text.Trim());
                        cmd.Parameters.AddWithValue("@Rg", string.IsNullOrWhiteSpace(tbxRg.Text) ? DBNull.Value : (object)tbxRg.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", tbxEmail1.Text.Trim());
                        cmd.Parameters.AddWithValue("@Telefone", string.IsNullOrWhiteSpace(tbxTelefone.Text) ? DBNull.Value : (object)tbxTelefone.Text.Trim());
                        cmd.Parameters.AddWithValue("@Cidade", string.IsNullOrWhiteSpace(tbxCidade.Text) ? DBNull.Value : (object)tbxCidade.Text.Trim());
                        cmd.Parameters.AddWithValue("@Rua", string.IsNullOrWhiteSpace(tbxRua.Text) ? DBNull.Value : (object)tbxRua.Text.Trim());
                        cmd.Parameters.AddWithValue("@Uf", string.IsNullOrWhiteSpace(tbxUf.Text) ? DBNull.Value : (object)tbxUf.Text.Trim());
                        cmd.Parameters.AddWithValue("@Cep", string.IsNullOrWhiteSpace(tbxCep.Text) ? DBNull.Value : (object)tbxCep.Text.Trim());
                        cmd.Parameters.AddWithValue("@Pais", string.IsNullOrWhiteSpace(tbxPais.Text) ? DBNull.Value : (object)tbxPais.Text.Trim());
                        cmd.Parameters.AddWithValue("@Senha", tbxSenha1.Text);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LimparCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao cadastrar: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            tbxNome.Clear();
            tbxNascimento.Text = "DD/MM/AAAA";
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
            tbxNome.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form5_Load(object sender, EventArgs e) { }
        private void tbxEmail1_TextChanged(object sender, EventArgs e) { }
        private void tbxSenha1_TextChanged(object sender, EventArgs e) { }
    }
}