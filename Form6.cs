using System;
using System.Windows.Forms;
using ControleDeEstoque.Data.Repositories;

namespace ControleDeEstoque
{
    public partial class Form6 : Form
    {
        private readonly FornecedorRepository _fornecedorRepository;

        public Form6()
        {
            InitializeComponent();
            _fornecedorRepository = new FornecedorRepository();
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
            mtbCnpj.Mask = "00,000,000/0000-00";
            mtbTelefone.Mask = "(00) 00000-0000";
            mtbCep.Mask = "00000-000";
            mtbUf.Mask = "AA";
        }

        private void btnAdicionarFor_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                var fornecedor = new Fornecedor
                {
                    Nome = tbxNome_For.Text.Trim(),
                    Cnpj = mtbCnpj.Text.Replace(",", "").Replace("/", "").Replace("-", "").Replace(".", ""),
                    Telefone = mtbTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", ""),
                    Email = tbxEmail_For.Text.Trim(),
                    Cidade = tbxCidade_For.Text.Trim(),
                    Rua = tbxRua_For.Text.Trim(),
                    Cep = mtbCep.Text.Replace("-", ""),
                    DataCadastro = dtpDataCadastro.Value,
                    Estatus = "A"
                };

                if (_fornecedorRepository.InserirFornecedor(fornecedor))
                {
                    MessageBox.Show("Fornecedor cadastrado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar fornecedor.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
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

            if (string.IsNullOrWhiteSpace(tbxCidade_For.Text))
            {
                MessageBox.Show("Por favor, informe a cidade.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxCidade_For.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbxRua_For.Text))
            {
                MessageBox.Show("Por favor, informe o endereço.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbxRua_For.Focus();
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

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Não fecha o aplicativo
        }
    }
}