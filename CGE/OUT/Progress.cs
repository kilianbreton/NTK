using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE.OUT
{
    public class Progress : CGEObject
    {
        private String name;
        private int value;
      

        public Progress(String name,bool todraw = true)
        {
            Console.OutputEncoding = Encoding.Unicode;
            this.name = name;
            if (todraw)
            {
                draw();
            }
        }

        public override void draw(int i = 0)
        {
            Console.CursorVisible = false;
            Console.WriteLine(name + " :");
            Console.WriteLine("┏━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┓");
            if (i == 0)
            {
                Console.WriteLine("┃                                                  ┃");
            }
            else
            {
                Console.Write("┃");
                Console.Write(NTKF.generStr((i / 2 + 1), "█"));
                Console.Write(NTKF.generStr((i / 2 ), " "));
                Console.SetCursorPosition(51, Console.CursorTop);
                Console.WriteLine("┃");
            }
            Console.WriteLine("┗━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━┛");
            if (i == 100)
            {
                Console.CursorVisible = true;
            }
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop - 4);
            }
        }

      
        public void forward(int i)
        {
            value = i;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, Console.CursorTop-3);

            Console.WriteLine(name + " : [" + ((i + 1)) + "%]");
            Console.SetCursorPosition(((i / 2) + 1), Console.CursorTop-3);
            Console.Write("█");

            if (i == 99)
            {
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        
        public int getValue()
        {
            return value;
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
