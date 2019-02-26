using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTK.Database;

namespace MYSQLNET
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var main = new main();
            main.init(textBox1.Text, textBox2.Text, textBox3.Text);
            main.Show();
            this.Hide();
        }
    }
}
