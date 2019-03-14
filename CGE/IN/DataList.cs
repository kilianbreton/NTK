using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE.IN
{
    /// <summary>
    /// 
    /// </summary>
    public class DataList :CGEObject
    {
        private String[,] grid;
        private bool header;
        private int[] maxLength;
        private int indiceL = 0;
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="header"></param>
        public DataList(String[,] grid, bool header = false)
        {
            this.grid = grid;
            this.header = header;
            Console.OutputEncoding = Encoding.Unicode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        public override void draw(int i = 0)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void print()
        {

            maxLength = new int[grid.GetLength(1)];
            //Calcul de largeur max des colonnes-------------------------------------------------------------------------------
            //x=ligne i=colonne
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                maxLength[i] = grid[0, i].Length;
          
                for (int x = 0;x< grid.GetLength(0)-1; x++)
                {
                    
                    if (maxLength[i] < grid[x, i].Length)
                    {
                        
                        maxLength[i] = grid[x, i].Length;
                      
                    }
                }
            }

            for(int i = 1; i < maxLength.Length; i++)
            {
                maxLength[i] += maxLength[i - 1] + 5;
            }

     
         //Affichage------------------------------------------------------------------------------------------------

            var startId = 0;
            var traitHo = "";
         //   Console.BackgroundColor = ConsoleColor.DarkBlue;
         
            //Trait horisontal
            for (int i = 0; i < maxLength[grid.GetLength(1) - 1] + 4; i++)
            {
                traitHo += "─";
            }
            Console.WriteLine("┏" + traitHo+ "┓");
            if (header)
            {
                for(int i = 0;i< grid.GetLength(1); i++)
                {
                    Console.Write("┃ " + grid[0, i]);
                    Console.SetCursorPosition(maxLength[i]+4, Console.CursorTop);
                }
                Console.Write(" ┃");
                Console.WriteLine();
               
                startId = 1;
            }
            //  Console.BackgroundColor = ConsoleColor.DarkGreen;

            Console.WriteLine("┣" + traitHo + "┫");
            for (int i = startId; i < grid.GetLength(0); i++)
            {
                for(int x = 0; x < grid.GetLength(1); x++)
                {
                    Console.Write("┃ " + grid[i, x]);
                    Console.SetCursorPosition(maxLength[x]+4, Console.CursorTop);
                }
                Console.Write(" ┃");
                Console.WriteLine();
            }
            Console.WriteLine("┗" + traitHo+ "┛");

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
        public void start()
        {
            print();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bad"></param>
        public override void stop(bool bad = false)
        {
            
        }
    }
}
