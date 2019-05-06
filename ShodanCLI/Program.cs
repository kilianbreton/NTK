using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGE;
using CGE.IN;
using CGE.OUT;

namespace ShodanCLI
{
    class Program
    {
        private static String[][] commands = new string[][] {
           new string[]{"Command","Description"},   //Header
           new string[]{"HELP","Show HELP"},
           new string[]{"PROTOCOLS","Show protocols list"},
           new string[]{"SCAN","Start scan port"},
           new string[]{"",""},
        
        };


        static void Main(string[] args)
        {
            if(args.Length > 0)
            {

            }
            else
            {
                bool stop = false;
                while (!stop)
                {
                    Console.Write("Shodan>");
                    String txt = Console.ReadLine();
                    switch (txt.ToUpper())
                    {
                        case "Q":
                        case "EXIT":
                            stop = true;
                            break;
                        case "H":
                        case "HELP":
                            showHelp();
                            break;
                    }
                }


            }


        }

        private static void showHelp()
        {
            var grid = new DataGrid(commands,true);
            grid.print();
         /*   foreach (String[] cmd in commands)
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(cmd[0]);
                Console.ResetColor();
                Console.Write("                 ");
                Console.Write(cmd[1]  + "\n");
            }*/
        }


    }
}
