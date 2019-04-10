using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Arret de l'écoute
    /// </summary>
    public class StopEventArgs : EventArgs
    {
        private int code;

        public StopEventArgs(int code)
        {
            this.code = code;
        }

        public int Code { get => code; set => code = value; }
    }
}
