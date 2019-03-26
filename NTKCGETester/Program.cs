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
         //   Console.WriteLine(sha256("mdp"));
            for(int i = 0; i < 100; i++)
            {
                var iv = NTKAes.CreateKey(100).iv;
                Console.WriteLine(Encoding.Default.GetString(iv) + "   :   " + iv.Length);
            }
         

            
            Console.ReadKey();
        }



    }
}