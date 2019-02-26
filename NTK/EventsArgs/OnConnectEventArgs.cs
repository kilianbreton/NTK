using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.EventsArgs
{
    public partial class OnConnectEventArgs : EventArgs
    {
        private ConnectionState state;

        public OnConnectEventArgs(ConnectionState state)
        {
            this.state = state;
        }

        public ConnectionState State { get => state; set => state = value; }
    }
}
