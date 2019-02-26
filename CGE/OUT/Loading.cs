using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CGE.OUT
{
    public class Loading : CGEObject
    {
        private String name;
        private bool run;
        private Thread loop;

        public Loading(String name, bool run = false)
        {
            this.name = name;
            this.run = run;
            if (run)
            {
                loop = new Thread(loadLoop);
                loop.Start();
            }
            Console.OutputEncoding = Encoding.Unicode;
        }

        public override void draw(int i = 0)
        {
            throw new NotImplementedException();
        }

        public override string show()
        {
            throw new NotImplementedException();
        }

        public void start()
        {
            run = true;
            loop = new Thread(loadLoop);
            loop.Start();
            Console.CursorVisible = false;
        }

      
        public override void stop(bool bad = false)
        {
            run = false;
            loop.Abort();
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(name + " : ");
            NTKF.printOKBAD(bad);
            Console.CursorVisible = true;
           
        }

        private void loadLoop()
        {
            while (true)    // Boucle infini !!
            {
                Console.WriteLine(name + " [.  ]                   ");
                Thread.Sleep(200);
                Console.SetCursorPosition(0, Console.CursorTop-1);
                Console.WriteLine(name + " [.. ]                      ");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Thread.Sleep(200);
                Console.WriteLine(name + " [...]                   ");
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                Thread.Sleep(200);
            }

        }



    }
}
