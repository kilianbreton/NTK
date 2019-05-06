using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Service
{
    class XmlRpc : NTKService
    {
        public override void c_authentification(NTKUser user)
        {
            throw new NotImplementedException();
        }

        public override void c_listen(NTKUser user, string cmd)
        {
            throw new NotImplementedException();
        }

        public override void initialize(params object[] args)
        {
            throw new NotImplementedException();
        }

        public override void s_authentification(NTKUser user, List<NTKUser> userlist, ServicelistenFunction listen)
        {
            throw new NotImplementedException();
        }

        public override void s_listen(NTKUser user)
        {
            throw new NotImplementedException();
        }
    }
}
