using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Service;

namespace NTK.P2P
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class P2PService : NTKService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public abstract void p2pClientServer_Listen(NTKUser user);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        public abstract void p2pClientServer_Authentification(NTKUser user);
    }
}
