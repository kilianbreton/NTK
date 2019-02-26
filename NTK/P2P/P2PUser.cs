using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NTK.P2P
{
    public class P2PUser : NTKUser
    {

        public P2PUser(String login, TcpClient client) : base(login, client)
        {

        }

    }
}
