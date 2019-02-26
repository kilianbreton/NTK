using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CGE.OUT;
using CGE.IN;
namespace NTKInt
{
    public class CGInt
    {
        private Screen screen;
        private Menu menu;
        private DataGrid datagrid;
        private Progress progress;
        private String[] mainmenu = new String[] { "Database","NTKClient","NTKServer","Plugins","Cyphers","UPDATE","Exit" };
        private String[] dbmenu = new String[] { "Configuration", "Informations", "SQL Interface", "Back" };
        private String[] ntkcmenu = new String[] { "Configuration", "Informations", "Connect", "Back" };
        private String[] ntksmenu = new String[] { "Configuration", "Informations", "Start", "Back" };
        private String[] pluginsmenu = new String[] { "View list", "Add", "Start", "Back" };
        private String[] cyphersmenu = new String[] { "SHA-256", "AES", "RSA", "Back" };


        public CGInt()
        {
            
            screen = new Screen(-1, -1, "Network Transport Kernel");
         
        }


        public void start()
        {
            bool stop = false;
            int res = -1;
            while (!stop)
            {


             
                switch (res)
                {
                    
                    case -1:
                        //MAIN MENU----------------------------------------------------------------------------------------------------------------
                        screen.draw();
                        menu = new Menu(mainmenu);
                        menu.setMarginsTxt(5);
                        menu.StartPosX = (Console.WindowHeight / 2) - (menu.Maxlength / 2);
                        menu.StartPosY = (Console.WindowWidth / 2) - (mainmenu.Length / 2) - 5;
                        menu.DefaultBackColor = ConsoleColor.DarkGray;
                        menu.start();
                        res = menu.IndiceM;
                        break;
                  
                    case 0:
                        //DB MENU-------------------------------------------------------------------------------------------------------------
                        screen.draw();
                        menu = new Menu(dbmenu);
                        menu.setMarginsTxt(5);
                        menu.StartPosX = (Console.WindowHeight / 2) - (menu.Maxlength / 2);
                        menu.StartPosY = (Console.WindowWidth / 2) - (mainmenu.Length / 2) - 5;
                        menu.DefaultBackColor = ConsoleColor.DarkGray;
                        menu.start();
                        res = menu.IndiceM;
                        switch (res)
                        {
                            case 0:

                                break;
                            case 1:

                                break;
                            case 2:

                                break;
                            case 3:
                                res = -1;
                                break;
                        }

                        break;
                    case 1:
                        //CLIENT MENU----------------------------------------------------------------------------------------------------
                        screen.draw();
                        menu = new Menu(ntkcmenu);
                        menu.setMarginsTxt(5);
                        menu.StartPosX = (Console.WindowHeight / 2) - (menu.Maxlength / 2);
                        menu.StartPosY = (Console.WindowWidth / 2) - (mainmenu.Length / 2) - 5;
                        menu.DefaultBackColor = ConsoleColor.DarkGray;
                        menu.start();
                        res = menu.IndiceM;
                        switch (res)
                        {
                            case 0:

                                break;
                            case 1:

                                break;
                            case 2:

                                break;
                            case 3:
                                res = -1;
                                break;
                        }
                        break;
                    case 2:
                        //SERVER MENU --------------------------------------------------------------------------------------------------
                        screen.draw();
                        menu = new Menu(ntksmenu);
                        menu.setMarginsTxt(5);
                        menu.StartPosX = (Console.WindowHeight / 2) - (menu.Maxlength / 2);
                        menu.StartPosY = (Console.WindowWidth / 2) - (mainmenu.Length / 2) - 5;
                        menu.DefaultBackColor = ConsoleColor.DarkGray;
                        menu.start();
                        res = menu.IndiceM;
                        switch (res)
                        {
                            case 0:

                                break;
                            case 1:

                                break;
                            case 2:

                                break;
                            case 3:
                                res = -1;
                                break;
                        }
                        break;
                    case 3:
                        //Plugins-----------------------------------------------------------------------------------------------
                        var plugs = new String[,] {
                            { "Nom", "Type" },
                            { "I2P", "Network" },
                            { "CyberNet", "Service" },
                            { "SocialNet", "Service" },
                            { "VOIP", "Protocol" },
                            { "CyberNet", "Service" },
                            { "SocialNet", "Service" },
                            { "VOIP", "Protocol" },
                            { "CyberNet", "Service" },
                            { "SocialNet", "Service" },
                            { "VOIP", "Protocol" },
                            { "CyberNet", "Service" },
                            { "SocialNet", "Service" },
                            { "VOIP", "Protocol" },
                        };
                        Console.ForegroundColor = ConsoleColor.Black;
                        try
                        {
                            screen.draw();
                            Console.SetCursorPosition(0, 10);
                            datagrid = new DataGrid(plugs,true);
                            datagrid.Startleftpos=(Console.WindowWidth / 2 - (10 / 2) -8);
                            datagrid.draw();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        Console.ReadKey();
                        res = -1;
                        break;
                    case 4:
                        screen.draw();
                        menu = new Menu(cyphersmenu);
                        menu.setMarginsTxt(5);
                        menu.StartPosX = (Console.WindowHeight / 2) - (menu.Maxlength / 2);
                        menu.StartPosY = (Console.WindowWidth / 2) - (mainmenu.Length / 2) - 5;
                        menu.DefaultBackColor = ConsoleColor.DarkGray;
                        menu.start();
                        res = menu.IndiceM;
                        switch (res)
                        {
                            case 0:

                                break;
                            case 1:

                                break;
                            case 2:

                                break;
                            case 3:
                                res = -1;
                                break;
                        }
                        break;

                    case 5: //Update

                        break;

                    case 6:     //Exit
                        stop = true;
                        Console.Clear();
                        Console.ResetColor();
                        break;
                }

            }
            Console.Clear();
            Console.ResetColor();
        }





    }
}
