using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE.OUT
{
    public class DataGrid : CGEObject
    {
        private String[,] grid;
        private bool header;
        private int[] maxLength;
        private int startleftpos = 0;
        private int startToppos = 0;


        public DataGrid(String[,] grid, bool header = false)
        {
            this.grid = grid;
            this.header = header;
            Console.OutputEncoding = Encoding.Unicode;
        }

        public int[] MaxLength { get => maxLength; set => maxLength = value; }
        public int Startleftpos { get => startleftpos; set => startleftpos = value; }

        public override void draw(int i = 0)
        {
            print();
        }

        public void print()
        {

            MaxLength = new int[grid.GetLength(1)];
            //Calcul de largeur max des colonnes-------------------------------------------------------------------------------
            //x=ligne i=colonne
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                MaxLength[i] = grid[0, i].Length;
                for (int x = 0;x< grid.GetLength(0)-1; x++)
                {
                    if (MaxLength[i] < grid[x, i].Length)
                    {
                        MaxLength[i] = grid[x, i].Length;      
                    }
                }
            }

            for(int i = 1; i < MaxLength.Length; i++)
            {
                MaxLength[i] += MaxLength[i - 1] + 5;
            }

     
            //Affichage------------------------------------------------------------------------------------------------

            var startId = 0;
            var traitHo = "";

            startToppos = Console.CursorTop;

            for(int i = 0;i< grid.GetLength(0)+3; i++)
            {
               Console.WriteLine(NTKF.generStr(MaxLength[MaxLength.Length-1]+5," "));
            }
            Console.SetCursorPosition(0, startToppos);
          
            //Trait horisontal----------------------------------------------------------------------------------------
            for (int i = 0; i < MaxLength[grid.GetLength(1) - 1] + 4; i++)
            {
                traitHo += "─";
            }
            Console.SetCursorPosition(Startleftpos, Console.CursorTop);
            Console.WriteLine("┏" + traitHo+ "┓");
            if (header)
            {
                Console.SetCursorPosition(Startleftpos, Console.CursorTop);
                Console.Write("┃ " + grid[0, 0]);
                Console.SetCursorPosition(Startleftpos, Console.CursorTop);
                for (int i = 1;i< grid.GetLength(1); i++)
                {
                    Console.SetCursorPosition(Startleftpos + MaxLength[i-1] + 4, Console.CursorTop);
                    Console.Write("┃ " + grid[0, i]);
                    Console.SetCursorPosition(Startleftpos+MaxLength[i]+4, Console.CursorTop);//TODO : gérer exception (Taille ecran)
                }
                Console.Write(" ┃");
                Console.WriteLine();
               
                startId = 1;
            }

            Console.SetCursorPosition(Startleftpos, Console.CursorTop);
            Console.WriteLine("┣" + traitHo + "┫");
            for (int i = startId; i < grid.GetLength(0); i++)
            {
                Console.SetCursorPosition(Startleftpos, Console.CursorTop);
                Console.Write("┃ " + grid[i, 0]);
                Console.SetCursorPosition(Startleftpos + MaxLength[0] + 4, Console.CursorTop);
                for (int x = 1; x < grid.GetLength(1); x++)
                {
                    Console.SetCursorPosition(Startleftpos + MaxLength[x-1] + 4, Console.CursorTop);
                    Console.Write("┃ " + grid[i, x]);
                    Console.SetCursorPosition(Startleftpos + MaxLength[x]+4, Console.CursorTop);
                }
                Console.Write(" ┃");
                Console.WriteLine();
            }
            Console.SetCursorPosition(Startleftpos, Console.CursorTop);
            Console.WriteLine("┗" + traitHo+ "┛");

        }

        public override string show()
        {
            print();
            return "0";
        }

      

        public override void stop(bool bad = false)
        {
            
        }
    }
}
