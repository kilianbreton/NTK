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
            

            // NTKServer server = new NTKServer(@"D:\Programmation\NTK\Config\server.xml");
            IniDocument ind = new IniDocument(@"C:\wamp64\bin\php\php7.1.9\php.ini");
            /*     foreach(IniGroup grp in ind.Groups)
                 {
                     Console.WriteLine("* " + grp.Name.ToUpper());
                     foreach(IniValue val in grp.Values)
                     {
                         Console.WriteLine("  - " + val.Name + " = " + val.Value);
                     }
                 }*/
            ind.getGroup("SQL");
            Console.WriteLine(ind.print());
            Console.ReadKey();



            Type test = typeof(MVisiteur);

            var tab = test.GetMembers();
            foreach(MemberInfo prop in tab)
            {
                Console.WriteLine(prop.Name);
            }

          //  var lst = MVisiteur.all();
          
            
            Console.ReadLine();
         
            
        }



    }
}