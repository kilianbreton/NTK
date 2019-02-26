using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTK;

namespace CLIENT_NTK
{
    public partial class Connect : Form
    {
        private Form1 mainfrm;
        public Connect(Form1 frm)
        {
            this.mainfrm = frm;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainfrm.Client = new NTKClient(textBox1.Text, int.Parse(textBox2.Text), textBox3.Text, textBox4.Text, textBox5.Text);
            mainfrm.start();
            this.Close();
        }
    }
}
