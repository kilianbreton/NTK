using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using NTK;
using NTK.EventsArgs;

namespace CLIENT_NTK
{
    public partial class TestConnection : Form
    {
        private NTKClient client;
        private AddServer frm;
        private Thread thclient;

        public TestConnection(bool reg, String adrs,int port,String login, String pass, String regkey = null,AddServer frm = null)
        {
            InitializeComponent();
            this.frm = frm;
            client = new NTKClient(adrs, port, login, pass,regkey,reg);
            client.Identification += new NTKClient.OnIdentificationEventHandler(client_ident);

            thclient = new Thread(client.connect);
            thclient.Start();

        }
        private void client_ident(object sender, IdentificationEventArgs args)
        {
            if (args.State.Equals(Identification.Success))
            {
                client.closeConnection();
                if(frm != null)
                {
                    frm.TcOk = true;
                }
                this.thclient.Abort();
                this.Close();
            }
        }
   
        private void TestConnection_Load(object sender, EventArgs e)
        {

        }
    }
}
