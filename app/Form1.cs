using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btn1_Click(object sender, EventArgs e)
        {
            FormCadastro formCad = new FormCadastro();
            formCad.Show();
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            FormVISUALIZAR formVISUALIZAR = new FormVISUALIZAR();
            formVISUALIZAR.Show();
        }
    }
}
