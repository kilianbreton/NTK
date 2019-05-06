using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;
using System.Data.SQLite;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Reflection;
using System.Diagnostics;
using System.Management;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
//cge
using CGE.IN;
using CGE.OUT;
//NTK
using NTK;
using NTK.Database;
using NTK.Database.ORM;
using NTK.Database.ORM.Core;
using NTK.Database.ORM.Attribute;
using NTK.Other;
using NTK.IO;
using NTK.IO.Xml;
using NTK.IO.Html;
using NTK.IO.IS;
using NTK.IO.Ini;
using NTK.Security;
using NTK.Api;
using static NTK.Other.NTKF;


namespace NTKCGETester
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument doc = new XmlDocument();

            doc[0]["logs"]["xmlrpc"].addAttribute("path", "D:\\log.txt");
            doc.getNode(0).getChild("logs").getChild("xmlrpc").Attributes.Add(new XmlAttribute("path", "D:\\log.txt"));

            string value = "";
            value = doc[0].Value;
            value = doc[0].getValue();

            value = doc[0]["child"].Value;
            value = doc[0].getChildV("child");




            doc.addNode("1").addChild("2").addChild("3","yo");
            doc[0].addChild("1");
            Console.Write(doc.print());


            Console.ReadKey();
        }



    }
}