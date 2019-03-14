using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Threading;
using NTK;
using System.Reflection;
using CGE.IN;
using CGE.OUT;
using System.IO;
using NTK.Database;
using NTK.Database.ORM;
using System.Diagnostics;
using System.Management;
using NTK.Other;
using NTK.IO;
using System.Data.SQLite;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using ServiceTest;
using NTK.IO.Xml;
using NTK.IO.Html;
using NTK.IO.IS;
using NTK.IO.Ini;
using NTK.Security;
using System.Security.Cryptography;

namespace NTKCGETester
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlDocument htmld = new HtmlDocument();
            htmld.addLinkHeader("stylesheet", "css/treeview.css");

            var body = htmld.getNode(0).addBody();
            body.addTitle("Class", TitleType.H1);
            body.addLink("http://google.com", "Google");

            var list = body.addList();
            list.addListNode("value");
            list.addListNode("value2");

            var table = body.addTable();
            table.addTableHeader("id", "name", "lastname", "birthdate");
            table.addTableValuesLine("1", "kilian", "breton", "07/04/1998");
            table.addTableValuesLine("2", "arnaud", "breton", "07/04/1998");

            Console.WriteLine(htmld.print());
            Console.ReadKey();
        }



    }
}