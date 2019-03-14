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
    /// Changement d'état de la connection
    /// </summary>
    public class ConnectionEventArgs : EventArgs
    {
        private ConnectionState state;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="state"></param>
        public ConnectionEventArgs(ConnectionState state)
        {
            this.state = state;
        }
        
        /// <summary>
        /// Etat
        /// </summary>
        public ConnectionState State { get => state; }
    }
}

