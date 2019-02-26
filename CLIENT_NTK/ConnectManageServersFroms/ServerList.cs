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
    public partial class ServerList : Form
    {
        public ServerList()
        {
            InitializeComponent();
        }

        private void flatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flatButton4_Click(object sender, EventArgs e)
        {
            var ads = new AddServer();
            ads.Show();
        }
    }
}
