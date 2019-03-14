using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;
using NTK.IO;
using NTK.Other;
using NTK.Service;

namespace NTKUniversal_Server
{
    class Program
    {
        private
        static void Main(string[] args)
        {
           

            NTKServer server = null;
            //Arguments
            //-h
            //-v
            //-c #cfgPath
            //-a ask
            if (args.Length !=0)
            {
                switch (args[0])
                {
                    case "-h":
                        break;
                    case "-v":
                        break;
                    case "-c":
                        server = new NTKServer(args[1]);
                        break;
                    case "-a":
                        //TODO : ASK
                        break;
                    default:
                        
                        break;
                }
            }
            else
            {
                server = new NTKServer(@"D:\Programmation\NTK\ServerAdmin\Config\test1\server.xml");
            }
            if(server != null)
            {
                Console.Clear();
                Console.OutputEncoding = Encoding.Unicode;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.ForegroundColor = ConsoleColor.Yellow;
                /* Console.WriteLine(" XXXXXX  XXXXXXXXXXXXXX  XXXX");
                 Console.WriteLine(" XX  XX  XX    XX    XX  XX");
                 Console.WriteLine(" XX  XX  XX    XX    XXXXXX");
                 Console.WriteLine(" XX  XX  XX    XX    XX  XX");
                 Console.WriteLine(" XX  XXXXXX    XX    XX  XXXX 0.5");*/

                Console.WriteLine(" XXXXXX  XXXXXXXXXXXXXX  XXXXXX XX     XX");
                Console.WriteLine(" XX  XX  XX    XX    XX  XX     XX     XX");
                Console.WriteLine(" XX  XX  XX    XX    XXXXXX     XX     XX");
                Console.WriteLine(" XX  XX  XX    XX    XX  XX     XX     XX");
                Console.WriteLine(" XX  XXXXXX    XX    XX  XXXXXX XXXXXXXXX 0.5");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                // Console.WriteLine();

                if (server.Config.getNode(0).getChildV("plugins").ToUpper().Equals("TRUE"))
                {
                    Console.WriteLine(" Loading plugins");
                    List<NTKService> services = new List<NTKService>();

                    DirectoryInfo di = new DirectoryInfo(@"C:\Users\Kilia\source\repos\NTK\ServiceTest\bin\debug\");
                    FileInfo[] fi = di.GetFiles();
                    foreach(FileInfo elem in fi)
                    {
                        if (!(elem.Name.Equals("NTK.dll") || elem.Name.Equals("MySql.Data.dll")) && elem.Extension.Equals(".dll"))
                        {
                            DllLoader loader = new DllLoader(elem.FullName);
                            services.AddRange(loader.getClassInstancelike<NTKService>("NTKS_"));
                        } 
                    }
                    if(services.Count != 0)
                    {
                        server.ExtServices = services;
                    }
                    try
                    {
                        server.start();
                    }
                    catch (Exception e)
                    {

                    }
                }
            }

            Console.ReadLine();
        }
    }
}
