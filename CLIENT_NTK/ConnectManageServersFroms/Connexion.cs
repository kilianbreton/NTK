using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIENT_NTK
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        private void flatGroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void flatTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void flatButton1_Click(object sender, EventArgs e)
        {

        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flatButton3_Click(object sender, EventArgs e)
        {
            var test = new ServerList();
            test.Show();
        }
    }
}
