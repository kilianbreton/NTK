using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE.OUT
{
    public class Screen : CGEObject
    {
        private List<CGEObject> elements = new List<CGEObject>();
        private ConsoleColor backgroundColor;
        private ConsoleColor foregroundColor;
        private int height = Console.WindowHeight;
        private int width = Console.WindowWidth;
        private String title = "~{NO}~";
        

        public Screen(int height = -1, int width = -1, String title="~{NO}~", ConsoleColor backcolor = ConsoleColor.DarkGray,ConsoleColor foreColor = ConsoleColor.Black)
        {
            if(!(height ==-1 && width == -1))
            {
                this.width = width;
                this.height = height;
            }
            this.backgroundColor = backcolor;
            this.foregroundColor = foreColor;
            this.title = title;
        }

        public Screen(ConsoleColor backcolor, ConsoleColor foreColor)
        {
           
            this.backgroundColor = backcolor;
            this.foregroundColor = foreColor;
            
        }






        public List<CGEObject> Elements { get => elements; set => elements = value; }
        public ConsoleColor BackgroundColor { get => backgroundColor; set => backgroundColor = value; }
        public ConsoleColor ForegroundColor { get => foregroundColor; set => foregroundColor = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }


        public override void draw(int i = 0)
        {
            Console.SetCursorPosition(0, 0);
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = foregroundColor;
            int startx = 0;
            if(title != "~{NO}~"){
                if(title.Length % 2 != 0)
                {
                    title = title + " ";
                }
                startx = 1;
                Console.Write(NTKF.generStr((width/2)-(title.Length/2), " "));
                Console.Write(title);
                Console.Write(NTKF.generStr((width / 2) - (title.Length / 2), " "));
            }

            for (int x = startx; x < height; x++)
            {
                Console.Write(NTKF.generStr(width, " "));
            }
            Console.SetCursorPosition(0, 0);
        }

        public override string show()
        {
            throw new NotImplementedException();
        }

      

       
        public override void stop(bool bad = false)
        {
            throw new NotImplementedException();
        }
    }
}
