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
    public partial class NewServer : Form
    {
        public NewServer()
        {
            InitializeComponent();
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            RegKey rk = new RegKey();
            rk.Show();
            this.Close();
        }
    }
}
