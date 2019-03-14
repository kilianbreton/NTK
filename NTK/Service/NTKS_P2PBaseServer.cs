using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Other;
using NTK.P2P;

namespace NTK.Service
{
    public class NTKS_P2PBaseServer : P2PService
    {


        public override void c_authentification(NTKUser user)
        {
            throw new NotImplementedException();
        }

        public override void c_listen(NTKUser user,String cmd)
        {
            throw new NotImplementedException();
        }

        public override void initialize(params object[] args)
        {
            throw new NotImplementedException();
        }

        public override void p2pClientServer_Authentification(NTKUser user)
        {
            throw new NotImplementedException();
        }

        public override void p2pClientServer_Listen(NTKUser user)
        {
            throw new NotImplementedException();
        }

        public override void s_authentification(NTKUser user, List<NTKUser> userlist = null, ServicelistenFunction listen = null)
        {
            throw new NotImplementedException();
        }

        public override void s_listen(NTKUser user)
        {
            throw new NotImplementedException();
        }
    }
}
