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
    public class Menu : CGEObject
    {
        private String[] tab;
        private int maxlength;
        private int indiceM = 0;
        private int startPosX=-1;
        private int startPosY=-1;
        private int moreWidth=0;
        private int center = 0;             //0=non centré || 1=centré
        private int marginLeft = 0;
        private int marginLeftTxt = 0;
        private int marginRightTxt = 0;
        private ConsoleColor defaultBackColor = ConsoleColor.DarkGray;
        private ConsoleColor defaultForeColor = ConsoleColor.Black;
        private ConsoleColor selectBackColor = ConsoleColor.DarkRed;
        private ConsoleColor selectForeColor = ConsoleColor.White;
        private bool canEsc=false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tab"></param>
        public Menu(String[] tab)
        {
            this.tab = tab;

            Maxlength = tab[0].Length;
            for (int i = 1; i < tab.Length; i++)
            {
                if (Maxlength < tab[i].Length)
                {
                    Maxlength = tab[i].Length;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String show()
        {
            Console.CursorVisible = false;
            if(StartPosX == -1 && StartPosY == -1)
            {
                StartPosX = Console.CursorTop;
                StartPosY = Console.CursorLeft;
            }
           
            var stop = false;
            while (!stop)
            {
                draw();
                Console.ForegroundColor = defaultForeColor;
                Console.BackgroundColor = defaultBackColor;
                var key = Console.ReadKey().Key;
                switch (key){
                    case ConsoleKey.UpArrow:
                        if(IndiceM == 0)
                        {
                            IndiceM = tab.Length-1;
                        }
                        else
                        {
                            IndiceM--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (IndiceM == tab.Length-1)
                        {
                            IndiceM = 0;
                        }
                        else
                        {
                            IndiceM++;
                        }
                        break;
                    case ConsoleKey.PageUp:
                        IndiceM = 0;
                        break;
                    case ConsoleKey.PageDown:
                        IndiceM = tab.Length-1;
                        break;
                    case ConsoleKey.Escape:
                        if (canEsc)
                        {
                            indiceM = -1;
                            stop = true;  
                        }
                        break;
                    case ConsoleKey.Enter:
                        stop = true;
                        break;

                    case ConsoleKey.NumPad0:
                        if(!(tab == null))
                        {
                            indiceM = 0;
                        }
                        break;
                    case ConsoleKey.NumPad1:
                        setIndice(1);
                        break;
                    case ConsoleKey.NumPad2:
                        setIndice(2);
                        break;
                    case ConsoleKey.NumPad3:
                        setIndice(3);
                        break;
                    case ConsoleKey.NumPad4:
                        setIndice(4);
                        break;
                    case ConsoleKey.NumPad5:
                        setIndice(5);
                        break;
                    case ConsoleKey.NumPad6:
                        setIndice(6);
                        break;
                    case ConsoleKey.NumPad7:
                        setIndice(7);
                        break;
                    case ConsoleKey.NumPad8:
                        setIndice(8);
                        break;
                    case ConsoleKey.NumPad9:
                        setIndice(9);
                        break;
                }

            }
           
            Console.CursorVisible = true;

            return tab[IndiceM];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="margin"></param>
        public void setMarginsTxt(int margin)
        {
            marginLeftTxt = margin;
            marginRightTxt = margin;
        }

        /// <summary>
        /// 
        /// </summary>
        private void draw() 
        {
            var tmp = "";
            Console.Clear();
            Console.SetCursorPosition(StartPosY, StartPosX);
            for(int i = 0; i < tab.Length; i++)
            {
                tmp = generStr(((MoreWidth/2)*Center)+MarginLeftTxt, " ")+ tab[i] + generStr(Maxlength - tab[i].Length, " ");
               
             
                //Couleur en fonction select ou non----------------------
                if (i == IndiceM)
                {
                    Console.BackgroundColor = SelectBackColor;
                    Console.ForegroundColor = SelectForeColor;
                }
                else
                {
                    Console.BackgroundColor = DefaultBackColor;
                    Console.ForegroundColor = DefaultForeColor;
                }
                //Ecriture--------------------------------------------------
                Console.Write(tmp + generStr((MoreWidth / 2)+MarginRightTxt, " ")+"\n");
                Console.SetCursorPosition(StartPosY, Console.CursorTop);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nb"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        private String generStr(int nb,String str)
        {
            var ret = "";
            for (int i = 0; i < nb; i++)
            {
                ret += str;
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        private void setIndice(int i)
        {
            if (i < tab.Length)
            {
                indiceM = i;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void start()
        {
            show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        public override void draw(int i = 0)
        {
            show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bad"></param>
        public override void stop(bool bad = false)
        {
            show();
        }





        //Getter & Setters---------------------------------------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        public int MarginLeft { get => marginLeft; set => marginLeft = value; }
        /// <summary>
        /// 
        /// </summary>
        public int MarginLeftTxt { get => marginLeftTxt; set => marginLeftTxt = value; }
        /// <summary>
        /// 
        /// </summary>
        public int IndiceM { get => indiceM; set => indiceM = value; }
        /// <summary>
        /// 
        /// </summary>
        public int StartPosX { get => startPosX; set => startPosX = value; }
        /// <summary>
        /// 
        /// </summary>
        public int MoreWidth { get => moreWidth; set => moreWidth = value; }
        /// <summary>
        /// 
        /// </summary>
        public int Center { get => center; set => center = value; }
        /// <summary>
        /// 
        /// </summary>
        public int MarginRightTxt { get => marginRightTxt; set => marginRightTxt = value; }
        /// <summary>
        /// 
        /// </summary>
        public int StartPosY { get => startPosY; set => startPosY = value; }
        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor DefaultBackColor { get => defaultBackColor; set => defaultBackColor = value; }
        /// <summary>
        /// 
        /// </summary>
        public int Maxlength { get => maxlength; set => maxlength = value; }
        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor DefaultForeColor { get => defaultForeColor; set => defaultForeColor = value; }
        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor SelectBackColor { get => selectBackColor; set => selectBackColor = value; }
        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor SelectForeColor { get => selectForeColor; set => selectForeColor = value; }
    }
}
