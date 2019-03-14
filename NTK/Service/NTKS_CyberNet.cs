using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NTK.Other;
using static NTK.Other.NTKF;

namespace NTK.Service
{

    public struct CNCommands
    {
        public const String A_ADMIN = "A_ADMIN>";
        public const String A_COMPUTER = "A_COMPUTER>";
        public const String A_USER = "A_USER>";
        public const String A_NP = "A_NP>";

    }

    public class CNUser 
    {
        private String login;
        private String name;

        public CNUser(String login,String name)
        {
            this.login = login;
            this.name = name;
        }

        public string Login { get => login; set => login = value; }
        public string Name { get => name; set => name = value; }
    }


    public class NTKS_CyberNet : NTKService
    {

        private CNUser user = null; //Pour client
        private Dictionary<NTKUser, CNUser> computerUser = new Dictionary<NTKUser, CNUser>();
        private bool usePasswords = false;
        private bool timeLimit = false;


        public NTKS_CyberNet(ServiceConfig config) : base(config) { }

        public NTKS_CyberNet()
        {

        }
        public NTKS_CyberNet(List<NTKUser> userlist)
        {
            foreach(NTKUser elem in userlist)
            {
                computerUser.Add(elem, null);
            }
        }

        public override void s_authentification(NTKUser user, List<NTKUser> userlist = null, ServicelistenFunction listen = null)
        {
            throw new NotImplementedException();
        }

        public override void s_listen(NTKUser user)
        {
            bool stop = false;
            String tmp = "";
            while (!stop)
            {
                tmp = user.readMsg();
                // A_USER>login;
                if (tmp.Contains(CNCommands.A_USER) && user.Lvl == USER_LVL.USER && computerUser[user] == null)
                {
                    String login = subsep(tmp, CNCommands.A_USER, ";");
                    if (usePasswords)
                    {
                        user.writeMsg(CNCommands.A_NP);
                        String pass = user.readMsg();

                    }
                }
            }
        }
        public static ServiceConfig basicConfig()
        {
            var c = new ServiceConfig
            {
                authentification = false,
                stype = "CN",
               
            };
           
            
            //c.tables.Add();


            return c;
        }

      
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
           
        }
    }
}
