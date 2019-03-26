using NTK.IO.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using NTK.Other;
using System.IO;
using NTK.IO;
using NTK.Plugins;
using NTK.Service;

namespace NTKAdmin
{
    public partial class LoadScreen : Form
    {
        public LoadScreen()
        {
            InitializeComponent();
        }

        private void LoadScreen_Load(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)this.load);

        }

        public void load()
        {
            XmlDocument cfg = new XmlDocument(@"Config\main.xml");
            XmlNode root = cfg.getNode(0);
            Config.startType = root.getChildV("startType");
            var netList = root.getChildList("network");
            int valPercent = (50 / netList.Count);
            foreach (XmlNode elem in netList)
            {
                //Thread.Sleep(1000);
                
                var newNet = new Network(
                    elem.getAttibuteV("name"),
                    elem.getAttibuteV("type").Equals("remote")  //bool
                    );
                newNet.ClientCfg = new XmlDocument(@"Config\" + newNet.Name + @"\client.xml");
                if (!newNet.Remote)
                {
                    newNet.ServerCfg = new XmlDocument(@"Config\" + newNet.Name + @"\server.xml");
                }

                flatProgressBar1.Value += valPercent;
                Config.netList.Add(newNet);


            }


          
          //  label1.Text = "Chargement des plugins ...";
            DirectoryInfo di = new DirectoryInfo(@"Plugins\");
            FileInfo[] fi = di.GetFiles();
            valPercent = (50 /fi.Length);
            foreach (FileInfo elem in fi)
            {
                if (!(elem.Name.Equals("NTK.dll") || elem.Name.Equals("MySql.Data.dll")) && elem.Extension.Equals(".dll"))
                {
                    //Thread.Sleep(1000);
                    DllLoader loader = new DllLoader(elem.FullName);
                   //  Config.servicesList.AddRange(loader.getClassInstancelike<NTKService>("NTKS_"));
                   // Config.pluginsList.AddRange(loader.getClassInstancelike<IBasePlugin>("NTKP_"));
                    Config.servicesList.AddRange(loader.getAllInstances<NTKService>());
                    Config.pluginsList.AddRange(loader.getAllInstances<IBasePlugin>());
                }
                flatProgressBar1.Value += valPercent;
            }


            ConOrLaunch con = new ConOrLaunch();
            con.Show();
            this.Close();
        }
    }
}
