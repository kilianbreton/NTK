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
    public enum TBType
    {
        /// <summary>
        /// 
        /// </summary>
        Text,
        /// <summary>
        /// 
        /// </summary>
        Int,
        /// <summary>
        /// 
        /// </summary>
        Float,
        /// <summary>
        /// 
        /// </summary>
        DateDMY,
        /// <summary>
        /// 
        /// </summary>
        DateHHMMSS,
        /// <summary>
        /// 
        /// </summary>
        Mail,
        /// <summary>
        /// 
        /// </summary>
        Tel,
        /// <summary>
        /// 
        /// </summary>
        Adress
    }

    /// <summary>
    /// 
    /// </summary>
    public class TextBox : CGEObject
    {
        private String name;
        private TBType type;
        private ConsoleColor block;
        private ConsoleColor back;
        private ConsoleColor text;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="block"></param>
        /// <param name="back"></param>
        /// <param name="text"></param>
        public TextBox(String name,TBType type,ConsoleColor block = ConsoleColor.DarkGray,
            ConsoleColor back = ConsoleColor.Cyan, ConsoleColor text = ConsoleColor.Black)
        {
            this.name = name;
            this.type = type;
            this.block = block;
            this.back = back;
            this.text = text;
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
        /// <returns></returns>
        public override string show()
        {
            var ret = "";
            Console.BackgroundColor = block;
            Console.ForegroundColor = text;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(NTKF.generStr(name.Length+20, " "));
            }
            Console.SetCursorPosition(1, 1);
            
            Console.Write(name+" ");
            Console.BackgroundColor = back;
            Console.WriteLine(NTKF.generStr(17, " "));
            Console.SetCursorPosition(name.Length+2, 1);
           

            bool stop = false;
            while (!stop)
            {
                var key = Console.ReadKey(true).Key;
                if (ret.Length < 15)
                {
                    switch (key)
                    {
                        case ConsoleKey.Enter:
                            Console.SetCursorPosition(0, 5);
                            Console.ResetColor();
                            stop = true;
                            break;
                        case ConsoleKey.Backspace:
                            if (ret.Length >= 1)
                            {
                                ret = ret.Substring(0, ret.Length - 1);
                                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                                Console.ForegroundColor = back;
                                Console.Write("1");
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                Console.ForegroundColor = text;
                            }
                            break;
                        case ConsoleKey.Delete:
                            if (ret.Length >= 1)
                            {
                                ret = ret.Substring(0, ret.Length - 1);
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                Console.ForegroundColor = back;
                                Console.Write("1");
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                Console.ForegroundColor = text;
                            }
                            break;
                        case ConsoleKey.Spacebar:
                            ret = ret + " ";
                            Console.Write(" ");
                            break;
                        case ConsoleKey.NumPad0:
                            ret = ret + "0";
                            Console.Write("0");
                            break;
                        case ConsoleKey.NumPad1:
                            ret = ret + "1";
                            Console.Write("1");
                            break;
                        case ConsoleKey.NumPad2:
                            ret = ret + "2";
                            Console.Write("2");
                            break;
                        case ConsoleKey.NumPad3:
                            ret = ret + "3";
                            Console.Write("3");
                            break;
                        case ConsoleKey.NumPad4:
                            ret = ret + "4";
                            Console.Write("4");
                            break;
                        case ConsoleKey.NumPad5:
                            ret = ret + "5";
                            Console.Write("5");
                            break;
                        case ConsoleKey.NumPad6:
                            ret = ret + "6";
                            Console.Write("6");
                            break;
                        case ConsoleKey.NumPad7:
                            ret = ret + "7";
                            Console.Write("7");
                            break;
                        case ConsoleKey.NumPad8:
                            ret = ret + "8";
                            Console.Write("8");
                            break;
                        case ConsoleKey.NumPad9:
                            ret = ret + "9";
                            Console.Write("9");
                            break;

                        default:
                            if (Console.CapsLock)
                            {
                                ret = ret + key.ToString().ToUpper();
                                Console.Write(key.ToString().ToUpper());
                            }
                            else
                            {
                                ret = ret + key.ToString().ToLower();
                                Console.Write(key.ToString().ToLower());
                            }
                            break;
                    }


      
                }
                else
                {
                 //   Console.ReadKey(true);
                    switch (key)
                    {
                        case ConsoleKey.Backspace:
                            if (ret.Length >= 1)
                            {
                                ret = ret.Substring(0, ret.Length - 1);
                     
                                Console.SetCursorPosition(Console.CursorLeft-1, Console.CursorTop);
                                Console.ForegroundColor = back;
                                Console.Write("1");
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                Console.ForegroundColor = text;
                            }
                            break;
                        case ConsoleKey.Enter:
                            Console.SetCursorPosition(0, 5);
                            Console.ResetColor();
                            stop = true;
                            break;
                    }
                }
            }
            //ret=Console.ReadLine();
            return ret;
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bad"></param>
        public override void stop(bool bad = false)
        {
            throw new NotImplementedException();
        }
    }
}
