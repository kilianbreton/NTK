using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTK.IO.Xml;

namespace CLIENT_NTK
{
    public partial class Launch : Form
    {
        public Launch()
        {
            InitializeComponent();
            XmlDocument cfg = new XmlDocument(@"Config\Main.xml");
            XmlNode root = cfg.getNode(0);
            while (root.read())
            {
                XmlNode node = root.getNode();
                switch (node.getName())
                {
                    case "StartType":
                        Config.startType = node.getValue();
                        break;
                    case "Server":
                        var net = new Network
                        {
                            id = int.Parse(node.getAttibuteV("id")),
                            adrs = node.getChildV("ip"),
                            port = int.Parse(node.getChildV("port")),
                            login = node.getChildV("login"),
                            pass = node.getChildV("pass"),
                            name = node.getChildV("name")
                        };
                        Config.networks.Add(net);
                        flatComboBox1.Items.Add(net.name);
                        break;  
                }
            }
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            NewServer ns = new NewServer();
            ns.Show();

        }

        private void flatComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = flatComboBox1.SelectedIndex;
            tb_ip.Text = Config.networks[id].adrs;
            tb_port.Text = Config.networks[id].port.ToString();
            tb_login.Text = Config.networks[id].login;
            tb_pass.Text = Config.networks[id].pass;
        }

        private void flatButton1_Click_1(object sender, EventArgs e)
        {
            Main mainFrm = new Main();
            mainFrm.Show();
            mainFrm.connect(tb_ip.Text, int.Parse(tb_port.Text), tb_login.Text, tb_pass.Text);
        }
    }
}
