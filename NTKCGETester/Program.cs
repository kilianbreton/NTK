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
using static NTK.Other.NTKF;

namespace NTKCGETester
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var test = new DirectoryInfo(@"D:\ManiaPlanet\Dedicated\BTSSIOLAN\UserData\Music");
            var files = test.GetFiles();
            var xml = new XmlDocument();
            var root = xml.addNode("song_files");

            foreach(FileInfo file in files)
            {
                root.addChild("song", file.Name);
            }
            Console.Write(xml.print());


            Console.ReadKey();
        }



    }
}