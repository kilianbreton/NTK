using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGE.OUT
{
    public enum AlertType
    {
        Information,Choice,Error,Blank
    }
    public class Alert : CGEObject
    {
        private String title;
        private String text;
        private ConsoleColor foreground;
        private ConsoleColor background;
        private AlertType type;
        private int limit = 25; //Limite de largeur
        private int height = 4; //+1 line(text) = 5

        public Alert(String title,String text, AlertType type)
        {
            this.title = title;
            this.text = text;
            this.type = type;
        }
        public Alert(String title, String text,ConsoleColor fore, ConsoleColor back)
        {
            this.title = title;
            this.text = text;
            this.foreground = fore;
            this.background = back;
           
        }








        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Methodes Héritées /////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////


        public override void draw(int i = 0)
        {
            throw new NotImplementedException();
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
