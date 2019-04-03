using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Changement d'état de la connexion
    /// </summary>
    public class StateEventArgs : EventArgs
    {
        private ConnectionState state;

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="state">Etat de la connexion</param>
        public StateEventArgs(ConnectionState state)
        {
            this.state = state;
        }
       
        /// <summary>
        /// Etat
        /// </summary>
        public ConnectionState State { get => state; set => state = value; }
    }
}
