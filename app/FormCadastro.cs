    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Data.SQLite;
    using System.IO;

    namespace A
    {
        public partial class FormCadastro : Form
        {
            public FormCadastro()
            {
                InitializeComponent();
            }

            private void txt2_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; 
                }
            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
            {

            }

            private void FormCadastro_Load(object sender, EventArgs e)
            {

            }

            private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
            {

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            private void btnLimpar_Click(object sender, EventArgs e)
            {
                txt1.Clear();
                txt2.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox10.Clear();
                textBox9.Clear();
      
            }

            private void lblSemiTitulo9_Click(object sender, EventArgs e)
            {

            }

            private void textBox8_TextChanged(object sender, EventArgs e)
            {

            }

            private void textBox10_TextChanged(object sender, EventArgs e)
            {
        
            }
            private void CriarBanco()
            {
            string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "cadastro.db");


            if (!File.Exists(caminho))
                {
                    SQLiteConnection.CreateFile(caminho);

                    using (var conn = new SQLiteConnection("Data source=" + caminho))
                    {
                        conn.Open();

                        string sql = @"CREATE TABLE IF NOT EXISTS cadastro (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                nome TEXT,
                                celular TEXT,
                                telefone TEXT,
                                email TEXT,
                                cpf TEXT,
                                marca TEXT,
                                modelo TEXT,
                                cor TEXT,
                                chassis TEXT,
                                ano TEXT,
                                placa TEXT,
                                servico TEXT);";

                        using (var cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.ExecuteNonQuery();
                        } 
                    }
                }
            }

            private void btnEnviar_Click(object sender, EventArgs e)
            {

                CriarBanco();
                string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "cadastro.db");


            try
                {
                    using (SQLiteConnection conn = new SQLiteConnection("Data source = " + caminho))
                    {
                        conn.Open();

                        string checkSql = "SELECT COUNT(*) FROM cadastro WHERE placa = @placa";
                        using (SQLiteCommand checkCmd = new SQLiteCommand(checkSql, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@placa", textBox9.Text);
                            long count = (long)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show("Já existe um cadastro com essa placa!");
                                return;
                            }
                        }
                        string sql = @"INSERT INTO cadastro
                                    (nome, celular, telefone, email, cpf, marca, modelo, cor, chassis, ano, placa, servico)
                                        VALUES
                                    (@nome, @celular, @telefone, @email, @cpf, @marca, @modelo, @cor, @chassis, @ano, @placa, @servico)";

                        using (SQLiteCommand cmd = new SQLiteCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@nome", txt1.Text);
                            cmd.Parameters.AddWithValue("@celular", txt2.Text);
                            cmd.Parameters.AddWithValue("@telefone", textBox10.Text);
                            cmd.Parameters.AddWithValue("@email", textBox1.Text);
                            cmd.Parameters.AddWithValue("@cpf", textBox2.Text);
                            cmd.Parameters.AddWithValue("@marca", textBox3.Text);
                            cmd.Parameters.AddWithValue("@modelo", textBox4.Text);
                            cmd.Parameters.AddWithValue("@cor", textBox5.Text);
                            cmd.Parameters.AddWithValue("@chassis", textBox6.Text);
                            cmd.Parameters.AddWithValue("@ano", textBox7.Text);
                            cmd.Parameters.AddWithValue("@placa", textBox9.Text);
                            cmd.Parameters.AddWithValue("@servico", textBox8.Text);

                            cmd.ExecuteNonQuery();
                        }
                        conn.Close();   
                        MessageBox.Show("Dados enviados com sucesso!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar cadastro: {ex.Message}");
                }
            }

            private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

            private void textBox9_TextChanged(object sender, EventArgs e)
            {
                textBox9.Text = textBox9.Text.ToUpper();
                textBox9.SelectionStart = textBox9.Text.Length;
            }

            private void btnCancelar_Click(object sender, EventArgs e)
            {
                this.Close();  
            }

            private void txt1_TextChanged(object sender, EventArgs e)
            {

            }

        private void lblSemiTitulo5_Click(object sender, EventArgs e)
        {

        }

        private void lblSemiTitulo4_Click(object sender, EventArgs e)
        {

        }

        private void lblSemiTitulo6_Click(object sender, EventArgs e)
        {

        }

        private void lblSemiTitulo8_Click(object sender, EventArgs e)
        {

        }

        private void lblSemmiTitulo8_Click(object sender, EventArgs e)
        {

        }

        private void lblSemiTitulo7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
