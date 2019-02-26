using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.EventsArgs
{
    public class ConnectionEventArgs : EventArgs
    {
        private ConnectionState state;
        public ConnectionEventArgs(ConnectionState state)
        {
            this.state = state;
        }

        public ConnectionState State { get => state; }
    }
}

