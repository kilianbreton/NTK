using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Résultat d'identification
    /// </summary>
    public class IdentificationEventArgs : EventArgs
    {
        private Identification state;
        public IdentificationEventArgs(Identification state)
        {
            this.state = state;
        }

        public Identification State { get => state; }
    }
}

