using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using CGE.OUT;
using NTK.IO.Xml;
using NTK.Database;
using NTK;
using static NTK.Other.NTKF;
using System.Diagnostics;

namespace NTKInt
{
    

    public class CmdInt
    {
       
        private NTKServer serv;
        private NTKClient client;
        private NTKDatabase db;
        private DataGrid dataGrid;
        private Loading loading;
        private Progress progress;
        private Process myProcess = null;
        private StreamWriter myStreamWriter;
        private StreamReader myStreamReader;
        public CmdInt() { }


        /// <summary>
        /// Obtient un objet CGEDataGrid à partir d'un résultat de requête SQL
        /// </summary>
        /// <param name="msr"></param>
        /// <param name="header"></param>
        /// <returns>Grille CGE</returns>
        public static DataGrid getGrid(MySqlDataReader msr, Boolean header = false)
        {
            DataGrid ret;
            if (msr != null)
            {
                var tab = new List<String[]>();
                while (msr.Read())
                {
                    var ntab = new String[msr.FieldCount];

                    for (int i = 0; i < msr.FieldCount; i++)
                    {
                        if (!msr.IsDBNull(i))
                        {
                            ntab[i] = msr.GetString(i);
                        }
                        else
                        {
                            ntab[i] = "   ";
                        }

                    }
                    tab.Add(ntab);
                }
                var compen = 0;
                if (header)
                {
                    compen = 1;
                }
                var finaltab = new String[tab.Count + compen, msr.FieldCount];
                if (header)
                {
                    for (int i = 0; i < msr.FieldCount; i++)
                    {
                        finaltab[0, i] = msr.GetName(i);
                    }
                }
                for (int i = compen; i < tab.Count; i++)
                {
                    for (int x = 0; x < msr.FieldCount; x++)
                    {
                        finaltab[i, x] = tab[i][x];
                    }
                }
                ret = new DataGrid(finaltab, header);
            }
            else
            {
                String[,] tab = new String[2, 2];
                tab[0, 0] = "Error";
                tab[0, 1] = "MSR is null !";
                tab[1, 0] = "Error";
                tab[1, 1] = "MSR is null !";
                ret = new DataGrid(tab);
            }
            return ret;
        }
        public void start()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                                         XXXXXX  XXXXXXXXXXXXXX  XXXX");
            Console.WriteLine("                                         XX  XX  XX    XX    XX  XX");
            Console.WriteLine("                                         XX  XX  XX    XX    XXXXXX");
            Console.WriteLine("                                         XX  XX  XX    XX    XX  XX");
            Console.WriteLine("                                         XX  XXXXXX    XX    XX  XXXX");
            Console.WriteLine("                                         ════════════════════════════");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Title = "NTK Console";
            
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("NTK Command 0.1");
            Console.WriteLine("- h for help.");
            loopInt();
        }

        public void loopInt()
        {
            var tmp = "";
            var stop = false;  
            while (!stop)
            {
                Console.Write("NTK>");
                tmp = Console.ReadLine();
                switch(tmp.ToUpper()){
                    case "H":
                        showHelp();
                        break;

                    case "DB":
                        var tmpdb = "";
                        while (tmpdb.ToUpper() != "Q") {
                            Console.Write("DB>");
                            tmpdb = Console.ReadLine();
                            if (tmpdb.ToUpper().IndexOf("RC") >= 0)   //Readconfig
                            {
                                var xmlp = new XmlDocument(subsep(tmpdb, "RC "));
                                var root = xmlp.getNode(0).getChild("database");
                                db = NTKD_MySql.getInstance( root.getChild("host").getValue(), root.getChild("user").getValue(), root.getChild("pass").getValue(), root.getChild("name").getValue());
                                mysqlLoop();
                            }
                            else if (tmpdb.ToUpper() == "ASK")
                            {
                                Console.Write("HOST : ");
                                var adrs = Console.ReadLine();
                                Console.Write("USER : ");
                                var user = Console.ReadLine();
                                Console.Write("PASS : ");
                                var pass = Console.ReadLine();
                                Console.Write("Base : ");
                                var dbn = Console.ReadLine();
                                db = NTKD_MySql.getInstance(adrs, user, pass, dbn);
                                mysqlLoop();



                            }
                            else if (tmpdb.ToUpper() == "H")
                            {
                                Console.WriteLine("RC #path         Read the configfile at #Path");
                                Console.WriteLine("ASK              Ask the config values");
                                Console.WriteLine("Q                Quit DB interface to main menu");
                            }





                           
                              
                            

                        }

                        break;

                    case "CGI":
                        var cgi = new CGInt();
                        cgi.start();
                        break;

                    //CLEAR---------------------------------------------------------
                    case "CLEAR":
                    case "CLS":
                        Console.Clear();
                        break;
                    //QUIT----------------------------------------------------------
                    case "Q":
                    case "QUIT":
                        Console.Write("Are you sure ?  ");
                        var tmpq = Console.ReadLine().ToUpper();
                        if (tmpq.Equals("Y") || tmpq.Equals("YES"))
                        {
                            stop = true;
                        }
                       
                        break;

                    case "SKS":
                        sks();
                        break;

                    case "SKC":
                        client = new NTKClient("", 0);
                        client.ToString();
                        break;

                    case "UPDATE":

                        update();
                        break;

                    case "V":
                    case "VERSION":
                        Console.WriteLine("NTK Kernel version : {0}", typeof(NTKServer).Assembly.GetName().Version);
                        Console.WriteLine("Server & Interface version : {0}", typeof(Program).Assembly.GetName().Version);
                        break;

                    case "CIPHER":
                        Console.WriteLine("1 - AES");
                        Console.WriteLine("2 - RSA");
                        break;

                    case "ERRORLIST":
                       
                        break;
                    default:
                        if (tmp.ToUpper().Contains("MAKE SERVER "))
                        {
                            String path = subsep(tmp, "MAKE SERVER".Length, ";");
                            Console.Write("Create config ? [Y/N] : ");
                            var tmp2 = Console.ReadLine();
                            while(!tmp2.ToUpper().Equals("Y") && !tmp2.ToUpper().Equals("N"))
                            {
                                Console.Write("Y or N : ");
                                tmp2 = Console.ReadLine();
                            }
                            if (tmp2.ToUpper().Equals("Y"))
                            {

                            }
                            Loading load = new Loading("Installation ...", true);
                            Thread.Sleep(500);
                            load.stop();
                        }
                        else
                        {
                            if(myProcess == null)
                            {
                                myProcess = new Process();
                                myProcess.StartInfo.FileName = "cmd.exe";
                                myProcess.StartInfo.UseShellExecute = false;
                                myProcess.StartInfo.WorkingDirectory = "C:\\";
                                myProcess.StartInfo.RedirectStandardInput = true;
                                myProcess.StartInfo.RedirectStandardOutput = true;
                               
                                myProcess.Start();
                                myStreamWriter = myProcess.StandardInput;
                                myStreamReader = myProcess.StandardOutput;
                                var task = ReadToEnd(myStreamReader);
                            }
                           

                            myStreamWriter.WriteLine(tmp);
                           
                          //  Console.Write(myStreamReader.ReadToEnd());
                            //  Console.WriteLine(mystreamreader.ReadToEnd());

                        }

                        break;
                }
            }

            myStreamWriter.Close();
            myProcess.WaitForExit();
            myProcess.Close();
        }//Methode

        static async Task ReadToEnd(StreamReader streamReader)
        {
            string allText = await streamReader.ReadToEndAsync();
            Console.WriteLine(allText);
        }

        private void sks()
        {
            serv = new NTKServer();
            Console.WriteLine("SKS Interface, q for main console");
            var tmp = Console.ReadLine();
            while (tmp != "q")
            {
                Console.Write("SKS>");
                tmp = Console.ReadLine();
                if (tmp.ToUpper().IndexOf("READ") >= 0)
                {
                    var path = subsep(tmp, "read ");
                    serv = new NTKServer(path);
                    Console.WriteLine("Port : " + serv.Port);
                    Console.WriteLine("CTYPE : " + serv.Ctype);

                }
                else if (tmp.ToUpper().Equals("START"))
                {
                    serv.start();
                }
                else if (tmp.ToUpper().Contains("MAKE "))
                {

                }

            }
        }
        private void mysqlLoop()
        {
            var tmpmsql = "[NA]";
            while (tmpmsql.ToUpper() != "Q")
            {
                if (db != null && tmpmsql != "[NA]")
                {
                    if (tmpmsql.ToUpper().Contains("BACKUP "))
                    {

                    }
                    else
                    {
                        MySqlDataReader msr = (MySqlDataReader) db.select(tmpmsql);
                        getGrid(msr, true).print();

                        db.closeConnection();
                    }
                   
                }
                Console.Write("DBQ>");
                tmpmsql = Console.ReadLine();
            }
        }
    
        private void showHelp()
        {
            Console.WriteLine("NTK HELP");
            Console.WriteLine("db           -Enter database interface");
            Console.WriteLine("skc          -Enter NTKClient configuration");
            Console.WriteLine("sks          -Enter NTKServer configuration");
            Console.WriteLine("plugins      -Enter plugins manager");
            Console.WriteLine("cypher       -Use ciphers and hash");
            Console.WriteLine("cgi          -Enter console graphical interface");
            Console.WriteLine("exit         -Exit console");
        }


        public void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        {
            //Console.WriteLine("-------------------------------------------------------------------------------");
            if(progress.getValue() != e.ProgressPercentage && e.ProgressPercentage <= 100)
            {
                progress.forward(e.ProgressPercentage);
            }
            
            if(e.ProgressPercentage == 100)
            {
                update();
            }
        }

        private void update()
        {
            loading = new Loading("Installation");
            loading.start();
            string zipPath = "D:\\testcs.zip";
            string extractPath = @"D:\NTK\";

            Console.WriteLine();
            Console.WriteLine();
            WebClient wc = new WebClient();
            progress = new Progress("Téléchargement");
            var url = new Uri("http://127.0.0.1/ntm/java.zip");
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressCallback);
            wc.DownloadFileAsync(url, "D:\\testcs.zip");
            // stop = true;
            // ZipFile.ExtractToDirectory(zipPath, extractPath);

            loading.stop();
            loopInt();
        }

    }//Clasee
    public class DownloadFileTaskAsyncExProgress
    {
        public int ProgressPercentage { get; set; }
      
    }
}//NameSpace
