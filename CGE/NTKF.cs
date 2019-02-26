using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CGE
{
    public class NTKF
    {
        public NTKF() { }


      


        public static String delseps(String text, String sep1,String sep2)
        {
            return NTKF.subsep(text, 0, sep1) + NTKF.subsep(text, sep2);
        }

        public static String subsep(String text, String sep1, String sep2)
        {
            int startCut = text.IndexOf(sep1) + sep1.Length;
            int lengthCut = text.IndexOf(sep2) - startCut;
            return text.Substring(startCut, lengthCut);
        }

        public static String subsep(String text, int sep1, String sep2)
        {
         
            int lengthCut = text.IndexOf(sep2) - sep1;
            return text.Substring(sep1, lengthCut);
        }
        public static String subsep(String text, String sep1)
        {
            int startCut = text.IndexOf(sep1) + sep1.Length;

            int lengthCut = text.Length - startCut;

            return text.Substring(startCut, lengthCut);
        }


        public static int nbChar(string chaine, char lettre)
        {
            int nb = 0;
            foreach (char c in chaine)
            {
                if (c == lettre) nb++;
            }
            return nb;
        }


        //Vérifie si les arguments contiennent des chaines interdites (séparateurs)
       
       

        public static string sha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }

        public static void drawProgress(String name)
        {
          //  Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(name+" :");
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            Console.WriteLine("┃                                                  ┃");
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            Console.SetCursorPosition(0, Console.CursorTop - 2);
        }

        public static void forwardProgress(String name,int i)
        {
            Console.CursorVisible = false; 
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            
            Console.WriteLine(name+" : [" + ((i + 1)) + "%]");
            Console.SetCursorPosition(((i/2)+1), Console.CursorTop +1);
            Console.Write("█");
           
            if (i == 99)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.CursorVisible = true;
                printOKBAD();
                var test = new OUT.Loading("Installation");
                test.start();
                Thread.Sleep(5000);
                test.stop();

                String[,] tab = new String[2, 5];
                tab[0, 0] = "Colonne0";
                tab[0, 1] = "Col1";
                tab[0, 2] = "Col2";
                tab[0, 3] = "Col3";
                tab[0, 4] = "Col4";

                tab[1, 0] = "Data0";
                tab[1, 1] = "Data1";
                tab[1, 2] = "Data2";
                tab[1, 3] = "Data3";
                tab[1, 4] = "Data4";

                var ntest = new OUT.DataGrid(tab,true);
                //ntest.print();

            }
               
        }


        public static void printOKBAD(bool bad = false)
        {
            Console.Write("[");
            if (!bad)
            {   
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("OK");
              
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("BAD");
               
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("]                                                                ");
            Console.WriteLine();
            Console.WriteLine();
            // Console.WriteLine();
        }
        public static String generStr(int nb, String str)
        {
            var ret = "";
            for (int i = 0; i < nb; i++)
            {
                ret += str;
            }
            return ret;
        }

    }
}
