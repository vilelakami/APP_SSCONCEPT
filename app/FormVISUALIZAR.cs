using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A
{
    public partial class FormVISUALIZAR : Form
    {
        public FormVISUALIZAR()
        {
            InitializeComponent();
        }

        private void lblPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormVISUALIZAR_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string textoOriginal = textBox9.Text;
            string textoMaiusculo = textoOriginal.ToUpper();

            if (textoOriginal != textoMaiusculo)
            {
                int posicaoCursor = textBox9.SelectionStart;
                textBox9.Text = textoMaiusculo;
                textBox9.SelectionStart = posicaoCursor;
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "cadastro.db"); ;
            string buscarPlaca = textBox1.Text.ToUpper();

            using (SQLiteConnection conn = new SQLiteConnection("Data source = " + caminho))
            {
                conn.Open();
                string sql = "SELECT * FROM cadastro WHERE placa = @placa";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@placa", buscarPlaca);

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            textBox2.Text = reader["nome"].ToString();
                            textBox3.Text = reader["celular"].ToString();
                            textBox4.Text = reader["telefone"].ToString();
                            textBox5.Text = reader["email"].ToString();
                            textBox6.Text = reader["cpf"].ToString();
                            textBox7.Text = reader["marca"].ToString();
                            textBox8.Text = reader["modelo"].ToString();
                            textBox9.Text = reader["cor"].ToString();
                            textBox10.Text = reader["chassis"].ToString();
                            textBox11.Text = reader["ano"].ToString();
                            textBox12.Text = reader["placa"].ToString();
                            textBox13.Text = reader["servico"].ToString();

                        }
                    }
                }

            }

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "cadastro.db");
            string placa = textBox11.Text.ToUpper();

            using (SQLiteConnection conn = new SQLiteConnection("Data source = " + caminho))
            {
                conn.Open();

                string sql = @"UPDATE cadastro SET
                                nome = @nome,
                                celular = @celular,
                                telefone = @telefone,
                                email = @email,
                                cpf = @cpf,
                                marca = @marca,
                                modelo = @modelo,
                                cor = @cor,
                                chassis = @chassis,
                                ano = @ano,
                                placa = @placa,
                                servico = @servico";


                using (SQLiteCommand cmd = new SQLiteCommand(sql, conn)) {

                    cmd.Parameters.AddWithValue("@nome", textBox2.Text);
                    cmd.Parameters.AddWithValue("@celular", textBox3.Text);
                    cmd.Parameters.AddWithValue("@telefone", textBox4.Text);
                    cmd.Parameters.AddWithValue("@email", textBox5.Text);
                    cmd.Parameters.AddWithValue("@cpf", textBox6.Text);
                    cmd.Parameters.AddWithValue("@marca", textBox7.Text);
                    cmd.Parameters.AddWithValue("@modelo", textBox8.Text);
                    cmd.Parameters.AddWithValue("@cor", textBox9.Text);
                    cmd.Parameters.AddWithValue("@chassis", textBox10.Text);
                    cmd.Parameters.AddWithValue("@ano", textBox11.Text);
                    cmd.Parameters.AddWithValue("@placa", placa);
                    cmd.Parameters.AddWithValue("@servico", textBox13.Text);

                    int atualizacao = cmd.ExecuteNonQuery();

                    if (atualizacao > 0)
                    {
                        MessageBox.Show("Atualização efetuada!");
                    }
                    else
                    {

                        MessageBox.Show("Erro ao atualizar!");

                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblServico_Click(object sender, EventArgs e)
        {

        }
    }
}
