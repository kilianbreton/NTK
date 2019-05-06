using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CGE.OUT
{
    /// <summary>
    /// Tableau de données
    /// </summary>
    public class DataGrid : CGEObject
    {
        private String[,] grid;
        private bool header;
        private int[] maxLength;
        private int startleftpos = 0;
        private int startToppos = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="header"></param>
        public DataGrid(String[,] grid, bool header = false)
        {
            this.grid = grid;
            this.header = header;
            OutputEncoding = Encoding.Unicode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="header"></param>
        public DataGrid(String[][] grid, bool header = false)
        {
            this.grid = new string[grid.GetLength(0),grid[0].Length];
            int i = 0;
            foreach (String[] g in grid)
            {
                int x = 0;
                foreach(String s in g)
                {
                    this.grid[i, x] = s;
                    x++;
                }
                i++;
            }
            this.header = header;
            OutputEncoding = Encoding.Unicode;
        }
   

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        public override void draw(int i = 0)
        {
            print();
        }

        /// <summary>
        /// 
        /// </summary>
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

            startToppos = CursorTop;

            for(int i = 0;i< grid.GetLength(0)+3; i++)
            {
               WriteLine(NTKF.generStr(MaxLength[MaxLength.Length-1]+5," "));
            }
            SetCursorPosition(0, startToppos);
          
            //Trait horisontal----------------------------------------------------------------------------------------
            for (int i = 0; i < MaxLength[grid.GetLength(1) - 1] + 4; i++)
            {
                traitHo += "─";
            }
            SetCursorPosition(Startleftpos, CursorTop);
            WriteLine("┏" + traitHo+ "┓");
            if (header)
            {
                SetCursorPosition(Startleftpos, CursorTop);
                Write("┃ " + grid[0, 0]);
                SetCursorPosition(Startleftpos, CursorTop);
                for (int i = 1;i< grid.GetLength(1); i++)
                {
                    SetCursorPosition(Startleftpos + MaxLength[i-1] + 4, CursorTop);
                    Write("┃ " + grid[0, i]);
                    SetCursorPosition(Startleftpos+MaxLength[i]+4, CursorTop);//TODO : gérer exception (Taille ecran)
                }
                Write(" ┃");
                WriteLine();
               
                startId = 1;
            }

            SetCursorPosition(Startleftpos, CursorTop);
            WriteLine("┣" + traitHo + "┫");
            for (int i = startId; i < grid.GetLength(0); i++)
            {
                SetCursorPosition(Startleftpos, CursorTop);
                Write("┃ " + grid[i, 0]);
                SetCursorPosition(Startleftpos + MaxLength[0] + 4, CursorTop);
                for (int x = 1; x < grid.GetLength(1); x++)
                {
                    SetCursorPosition(Startleftpos + MaxLength[x-1] + 4, CursorTop);
                    Write("┃ " + grid[i, x]);
                    SetCursorPosition(Startleftpos + MaxLength[x]+4, CursorTop);
                }
                Write(" ┃");
                WriteLine();
            }
            SetCursorPosition(Startleftpos, CursorTop);
            WriteLine("┗" + traitHo+ "┛");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string show()
        {
            print();
            return "0";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bad"></param>
        public override void stop(bool bad = false)
        {
            
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        public int[] MaxLength { get => maxLength; set => maxLength = value; }
        /// <summary>
        /// 
        /// </summary>
        public int Startleftpos { get => startleftpos; set => startleftpos = value; }

    }
}
