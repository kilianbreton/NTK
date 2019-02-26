using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Other;

namespace NTK.P2P
{
    public abstract class P2PService : NTKService
    {
        public abstract void p2pClientServer_Listen(NTKUser user);

        public abstract void p2pClientServer_Authentification(NTKUser user);
    }
}
