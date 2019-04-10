using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Message
    /// </summary>
    public class MsgArgs : EventArgs
    {
        private String text;
      

        public MsgArgs(String text)
        {
            this.text = text;
          
        }
        public string ReadText
        {
            get { return text; }
            set { this.text = value; }
        }

      
    }
}
