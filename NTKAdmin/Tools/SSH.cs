using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SuperSocket.ClientEngine.Proxy;
using Renci.SshNet;


namespace NTKAdmin.Tools
{
    public partial class SSH : Form
    {
        private SshClient client;

        public SSH()
        {
            InitializeComponent();
            client = new SshClient("", "", "");
            client.Connect();
            var cmd = client.CreateCommand("");
            var response = cmd.Execute();
        }

        private void formSkin1_Click(object sender, EventArgs e)
        {

        }
    }
}
