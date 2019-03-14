using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;
using NTK.Database;
using NTK.Other;
using NTK.Service;
using static NTK.Other.NTKF;

namespace Demo
{
    public class NTKS_MonService : NTKService
    {

        public NTKS_MonService() : 
            base(new ServiceConfig()
            {
                authentification = true,
                useBasicListen = false,
                dbq = NTKD_MySql.getInstance(),
                name = "MONSERVICE"
            })
        {
            
        }


        public override void initialize(params object[] args)
        {
            throw new NotImplementedException();
        }




        public override void c_authentification(NTKUser user)
        {
            throw new NotImplementedException();
        }

        public override void c_listen(NTKUser user, string cmd)
        {
            throw new NotImplementedException();
        }

      
        public override void s_authentification(NTKUser user, List<NTKUser> userlist = null, ServicelistenFunction listen = null)
        {
            var cmd = user.readMsg();
            if (cmd.Contains("/ADMIN>") && cmd.Contains(";"))
            {
                string[] args = subsep(cmd, "/ADMIN>", ";").Split(',');
                if(args[0].Equals("admin") && args[2].Equals("admin"))
                {
                    user.Lvl = USER_LVL.ADMIN;
                    user.Name = "administrateur";
                    user.Login = "admin";

                    if (listen != null)
                    {
                        listen(user);
                    }
                    else
                    {
                        s_listen(user);
                    }
                }
            }
            else if (cmd.Contains("/USER>") && cmd.Contains(";"))
            {
                string[] args = subsep(cmd, "/USER>", ";").Split(',');
                if (args[0].Equals("user") && args[2].Equals("user"))
                {
                    user.Lvl = USER_LVL.USER;
                    user.Name = "Utilisateur";
                    user.Login = "user";

                    if (listen != null)
                    {
                        listen(user);
                    }
                    else
                    {
                        s_listen(user);
                    }
                }
            }
            else
            {

            }


        }

        public override void s_listen(NTKUser user)
        {
            bool stop = false;

            while (!stop)
            {
                var cmd = user.readMsg();
                if (cmd.Equals("help"))
                {
                    user.writeMsg("/m>message global{;}");
                    user.writeMsg("/mp,userlogin>message privé à user{;}");
                    user.writeMsg("/close;");
                }
                else if (cmd.Equals("/close;"))
                {

                }
                else
                {

                }

            }



            user.Client.Close();
            user = null;
        }
    }
}
