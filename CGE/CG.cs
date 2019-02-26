using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE
{
    public static class CGEC
    {


        public static void write(String text, int x = -1, int y = -1)
        {
            if(!(x<0))
            {
                Console.SetCursorPosition(x, Console.CursorTop);
            }
            if (!(y<0))
            {
                Console.SetCursorPosition(Console.CursorTop,y);
            }

            Console.Write(text);
        }
 

    }
}
