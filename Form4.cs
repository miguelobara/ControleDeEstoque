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

        private void textBox2_Click(object sender, EventArgs e)
        {
            tbxNome_Prod.Clear();
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            tbxCategoria.Clear();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            tbxValidade.Clear();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            tbxDescricao.Clear();
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            this.tbxDescricao.Size = new System.Drawing.Size(728, 106);
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

        private void button2_Click(object sender, EventArgs e)
        {
            string conexao = "Data Source=sqlexpress;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

            // Coleta os dados dos campos do formulário
            string nome = tbxNome_Prod.Text;
            string categoria = tbxCategoria.Text;
            DateTime validade = DateTime.Parse(tbxValidade.Text); // Certifique-se de que o formato está correto
            string descricao = tbxDescricao.Text;

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string sql = @"INSERT INTO Produto 
                       (Nome_Prod, Categoria, Validade, Id_Tipo, Descricao) 
                       VALUES 
                       (@Nome, @Categoria, @Validade, @Tipo, @Descricao)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Categoria", categoria);
                cmd.Parameters.AddWithValue("@Validade", validade);
                cmd.Parameters.AddWithValue("@Descricao", descricao);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Produto adicionado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar produto: " + ex.Message);
                }
            }
        }


        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string conexao = "Data Source=sqlexpress;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";
            string nome = tbxNome_Tipo.Text;
            string unidade = tbxUnidade_Medida.Text;

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string sql = "INSERT INTO Tipo (Nome_Tipo, Unidade_Medida) VALUES (@Nome, @Unidade)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Unidade", unidade);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tipo adicionado com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar tipo: " + ex.Message);
                }
            }
        }

        private void btnRenomearTip_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnDeletarTipo_Click(object sender, EventArgs e)
        {
           
            
        }

        private void cmbNome_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string conexao = "Data Source=sqlexpress;Initial Catalog=CJ3027511PR2;User ID=aluno;Password=aluno;";

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                string sql = "SELECT Nome FROM Tipo";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbNome_Tipo.Items.Add(reader["Nome"].ToString());
                }
            }
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

        private void tbxNome_Tipo_Click(object sender, EventArgs e)
        {
            tbxNome_Tipo.Clear();
        }

        private void tbxUnidade_Medida_Click(object sender, EventArgs e)
        {
            tbxUnidade_Medida.Clear();
        }
    }
}

