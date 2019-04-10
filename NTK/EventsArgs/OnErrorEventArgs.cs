using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Réception d'une erreur
    /// </summary>
    public class OnErrorEventArgs : EventArgs
    {
        private String type;
        private String text;

        public OnErrorEventArgs(string type, string text)
        {
            this.type = type;
            this.text = text;
        }

        public string Type { get => type; set => type = value; }
        public string Text { get => text; set => text = value; }
    }
}
