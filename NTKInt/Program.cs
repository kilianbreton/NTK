using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NTK;
using CGE.OUT;
using NTK.IO;
using NTK.Database;

namespace NTKInt
{
    class Program
    {
        static void Main(string[] args)
        {
        //    var saisie = new CGETextBox("Test :", TBType.Text);
            //      saisie.show();
         //   var isc = new InstallScript(@"D:\Programmation\NTK\isTest\is.is",true);

            if (args ==null || args.Length == 0)
            {
                var cmdInterface = new CmdInt();
                cmdInterface.start();
            }
            else
            {
                if (args[0].Equals("-h") || args[0].Equals("-help"))
                {
                    Console.WriteLine("HELP");
                    Console.WriteLine("-h                                   Help");
                    Console.WriteLine("-u [-all || -kernel || -server]      Update all or kernel or server");
                    Console.WriteLine("-i (default)                         Start console interface");
                    Console.WriteLine("-g                                   Start graphical interface");
                    Console.WriteLine("-v                                   Get version");
                    Console.WriteLine("-s [-p Port [+] -ct CTYPE [+] ");
                    Console.WriteLine("   -dbt type [+] -dbhost ip/path [+] Start server");
                    Console.WriteLine("   -dbu user [+] -dbp pass [+] ");
                    Console.WriteLine("   -dbn name]");
                    Console.WriteLine("   || -read CONFIG_PATH");
                    Console.WriteLine("   || -ask");
                    Console.WriteLine("-c [-h host [+] -p port [+]          Connect client");
                    Console.WriteLine("   -lvl lvl [+] -ul [+] -up [+] -seckey]");
                    Console.WriteLine("-n [+] -s || -c                      Create new server or client");
                    Console.WriteLine("-p                                   Parse installScript");
                }
                else if (args[0].Equals("-v") || args[0].Equals("-version"))
                {
                    Console.WriteLine("NTK Kernel version : {0}", typeof(NTKServer).Assembly.GetName().Version);
                    Console.WriteLine("Server & Interface version : {0}", typeof(Program).Assembly.GetName().Version);
                }
                else if (args[0].Equals("-i") || args[0].Equals("-interface"))
                {
                    var cmdInterface = new CmdInt();
                    cmdInterface.start();
                }
                else if (args[0].Equals("-u") || args[0].Equals("-update"))
                {
                    Console.WriteLine("UPDATE");
                }
                else if (args[0].Equals("-s") || args[0].Equals("-server"))
                {

                    if (args[1].Equals("-read") && args.Length >=3)
                    {
                        var server = new NTKServer(args[2]);
                        server.start();
                    }
                    else if (args[1].Equals("-ask"))
                    {
                        Console.Write("Server name : ");
                        var name = Console.ReadLine();
                        Console.Write("Port : ");
                        var port = int.Parse(Console.ReadLine());
                        Console.Write("Ctype : ");
                        var ctype = Console.ReadLine();
                        Console.Write("TLS [Y/N] : ");
                        var tls = bool.Parse(Console.ReadLine());
                        var masterpass = Console.ReadLine();
                        Console.Write("Security Key : ");
                        var seckey = Console.ReadLine();
                        Console.Write("DB Type : ");
                        var dbtype = Console.ReadLine();
                        Console.Write("DB Host : ");
                        var dbhost = Console.ReadLine();
                        Console.Write("DB User : ");
                        var dbuser = Console.ReadLine();
                        Console.Write("DB Pass : ");
                        var dbpass = Console.ReadLine();
                        Console.Write("DB Name : ");
                        var dbname = Console.ReadLine();
                        var server = new NTKServer(port, CTYPE.BASIC,tls,seckey, NTKD_MySql.getInstance(dbhost,dbuser,dbpass,dbname));

                    }
                  
                }
                else if (args[0].Equals("-c") || args[0].Equals("-client"))
                {
                    Console.WriteLine("CLIENT");
                }

                else if (args[0].Equals("-g") || args[0].Equals("-graphical"))
                {
                    var gint = new CGInt();
                    gint.start();
                }
                else if (args[0].Equals("-n") || args[0].Equals("-new"))
                {
                    if (args[1].Equals("-s") || args[1].Equals("-server"))
                    {
                        Console.Clear();
                        Console.Write("Server name : ");
                        var name = Console.ReadLine();
                        Console.Write("Port : ");
                        var port = int.Parse(Console.ReadLine());
                        Console.Write("Ctype : ");
                        var ctype = Console.ReadLine();
                        Console.Write("TLS [Y/N] : ");
                        var tls = Console.ReadLine();
                        Console.Write("Master Login : ");
                        var masterlogin = Console.ReadLine();
                        Console.Write("Master Pass : ");
                        var masterpass = Console.ReadLine();
                        Console.Write("Security Key : ");
                        var seckey = Console.ReadLine();
                        Console.Write("DB Type : ");
                        var dbtype = Console.ReadLine();
                        Console.Write("DB Host : ");
                        var dbhost = Console.ReadLine();
                        Console.Write("DB User : ");
                        var dbuser = Console.ReadLine();
                        Console.Write("DB Pass : ");
                        var dbpass = Console.ReadLine();
                        Console.Write("DB Name : ");
                        var dbname = Console.ReadLine();
                        Console.CursorVisible = false;
                        var createF = new Loading("Creating files", true);
                        Thread.Sleep(15000);
                        createF.stop();
                        Console.CursorVisible = true;
                        Console.Write("Start server ? [Y/N] : ");
                        Console.ReadLine();
                      
                    }
                    else
                    {
                       
                    }
                }
                else if (args[0].Equals("-p") || args[0].Equals("-parse"))
                {
                    String ispath = args[1];
                 
                   
                    InstallScript insc = new InstallScript(ispath);
                    insc.install();
                }

                else
                {
                    Console.WriteLine("Unknown args ! Try -help for more informations.");

                }


            }


        }
    }
}
