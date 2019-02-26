using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace CLIENT_NTK
{
    public struct Network
    {
        public int id;
        public String name;
        public String adrs;
        public int port;
        public String login;
        public String pass;
    }


    public sealed class Config
    {
        public static XmlDocument cfg;
        public static List<Network> networks = new List<Network>();
        public static String startType;
    }
}
