using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Other;
using static NTK.Other.NTKF;

namespace NTK.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class NTKS_Basic : NTKService
    {
        public NTKS_Basic(ServiceConfig config) : base(config) { }


        /******************
         * Partie serveur *
         ******************/

        public override void s_authentification(NTKUser user, List<NTKUser> userlist, ServicelistenFunction listen)       {
            var umsg = user.readMsg();
            var login = subsep(umsg, ">", ";");
            if (alreadyConnected(login,userlist))
            {
                user.writeMsg(NTKCommands.A_BAD);
            }
            else
            {
                user.writeMsg(NTKCommands.A_OK);
                if(listen != null)
                {
                    listen(user);
                }
            }

        }

        public override void s_listen(NTKUser user)
        {
            throw new NotImplementedException();
        }

        
        /******************
         * Partie Client  *
         ******************/
        public override void c_authentification(NTKUser user)
        {
            throw new NotImplementedException();
        }

        public override void c_listen(NTKUser user,String cmd)
        {
            throw new NotImplementedException();
        }

        /******************
         *     Autre      *
         ******************/

        public static ServiceConfig cfg()
        {
            var cfg = new ServiceConfig();
            cfg.authentification = true;
            cfg.name = "BASIC";
            return cfg;
        }

        public override void initialize(params object[] args)
        {
          
        }
    }
}
