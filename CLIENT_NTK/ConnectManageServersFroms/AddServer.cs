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
    public partial class AddServer : Form
    {
        private bool tcOk = false;

        public bool TcOk { get => tcOk; set => tcOk = value; }

        public AddServer()
        {
            InitializeComponent();
        }

        private void flatToggle1_CheckedChanged(object sender)
        {
            if (flatToggle1.Checked)
            {
                tb_regkey.Enabled = false;
                tb_pass2.Enabled = false;
            }
            else
            {
                tb_regkey.Enabled = true;
                tb_pass2.Enabled = true;
            }
        }

        private void b_add_Click(object sender, EventArgs e)
        {
            var tc = new TestConnection(flatToggle1.Checked,tb_server.Text,int.Parse(tb_port.Text),tb_login.Text,tb_pass1.Text,tb_regkey.Text,this);
            tc.Show();
        }

        private void flatGroupBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
