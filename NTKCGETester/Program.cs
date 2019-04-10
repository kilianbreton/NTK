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
//ServiceDll
using ServiceTest;
//CGE
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
using static NTK.Other.NTKF;


namespace NTKCGETester
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var obj = new MVisiteur("k98", "KBreton", "Breton", "Kilian", "Combrit", new Labo("FD5","Bichat"));
            var ser = new EntitySerializer<MVisiteur>();
            var table = ser.getDBS();
            Console.WriteLine(table.print());
            /*
            //Opens a file and serializes the object into it in binary format.
            Stream stream = File.Open(@"D:\data.xml", FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();

            //BinaryFormatter formatter = new BinaryFormatter();
            formatter.FilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            formatter.Serialize(stream, obj);
            formatter.AssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full;
            stream.Close();
          
            var testAn = typeof(MVisiteur).GetCustomAttribute<Table>();
            Console.WriteLine("--" + testAn.Name + "--");
            var fields = typeof(MVisiteur).GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach(MemberInfo m in fields)
            {
                Console.WriteLine("-" + m.Name);
                foreach(var a in m.GetCustomAttributes<Column>())
                {
                    Console.WriteLine(" -" + a.ColumnName + " : " + a.Type);
                   
                    
                }
            }
              */
            Console.ReadKey();
        }



    }
}