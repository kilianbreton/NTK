using NTK.Database;
using NTK.Other;
using NTK.IO.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Plugins;

namespace NTKAdmin
{

    public class Network
    {
        private String name;
        private bool remote;
        private XmlDocument serverCfg;
        private XmlDocument clientCfg;


        public Network(string name, bool remote)
        {
            this.name = name;
            this.remote = remote;
        }

        public string Name { get => name; set => name = value; }
        public bool Remote { get => remote; set => remote = value; }
        public XmlDocument ServerCfg { get => serverCfg; set => serverCfg = value; }
        public XmlDocument ClientCfg { get => clientCfg; set => clientCfg = value; }
    }

    public static class Config
    {
        public static List<Network> netList = new List<Network>();
        public static List<NTKService> servicesList = new List<NTKService>();
        public static List<NTKDatabase> databaseList = new List<NTKDatabase>();
        public static List<IBasePlugin> pluginsList = new List<IBasePlugin>();
        public static String startType = "CONNEXION";


    }
}
