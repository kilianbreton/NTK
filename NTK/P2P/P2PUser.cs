using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NTK.P2P
{
    /// <summary>
    /// 
    /// </summary>
    public class P2PUser : NTKUser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="client"></param>
        public P2PUser(String login, TcpClient client) : base(login, client)
        {

        }

    }
}
