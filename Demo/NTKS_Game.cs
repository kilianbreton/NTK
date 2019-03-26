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
    public class NTKS_Game : NTKService
    {
        private int[][] grid;
        private int width;
        private int height;

        public NTKS_Game()
        {
            var conf = new ServiceConfig()
            {
                authentification = true,
                useBasicListen = false,
                dbc = NTKDatabase.getInstance(),
                name = "MonService",
                stype = "MS"
            };
            base.Config = conf;
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

                    listen(user);
                 
                }
                else
                {
                    user.IsBad = true;
                }
            }
            else if (cmd.Contains("/USER>") && cmd.Contains(";"))
            {
                string args = subsep(cmd, "/USER>", ";");
                if (!alreadyConnected(args,userlist))
                {
                    user.Lvl = USER_LVL.USER;
                    user.Name = args;
                    user.Login = args;
                    userlist.Add(user);
                    //Set default values



                    listen(user); 
                }
                else
                {
                    user.IsBad = true;
                }
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

                }   //pos>x,y;
                else if (cmd.Equals("pos>"))
                {

                }   //shoot>UP;
                else if (cmd.Equals("shoot>"))
                {

                }   //jump>left;
                else if (cmd.Equals("jump>;"))
                {

                }   //dir>down;
                else if (cmd.Equals("dir>"))
                {

                }   //return : grid>width,height;
                else if (cmd.Equals("getdim;"))
                {

                }
                else if (cmd.Equals("getpos;"))
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
