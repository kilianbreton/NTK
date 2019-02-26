using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;
using NTK.IO.Xml;
using Microsoft;
using System.Data;
using Microsoft.Win32;

namespace NGET
{
    public class Client
    {
        private XmlDocument config;
        private bool checkAll;
        private String tmpPath;
        private NTKClient ntkc;
        private NTKUser user;
        public Client() {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE");
            var list = key.GetSubKeyNames();
            for(int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.ReadLine();
            String path = (String)key.GetValue("ConfigPath");
            Console.WriteLine(path);
            
            parse(path);

        }

        public void start()
        {

        }


        public void parse(String path)
        {
            config = new XmlDocument(path);
            checkAll = bool.Parse(config.getNode(0).getChildV("check_all"));
            tmpPath = config.getNode(0).getChildV("tmp_path");
        }


    }
}
