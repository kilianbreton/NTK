using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;
using NTK.EventsArgs;
using NTK.Other;


namespace ServiceTest
{
   
    public class NTKS_Test : NTKService
    {
        public NTKS_Test() : base()
        {
            var ret = new ServiceConfig()
            {
                authentification = false,       //Si false on utilise l'authentification par défaut en fonction du CTYPE
                useBasicListen = true,          //Si true on utilise la lectures des commande de base interne au serveur
                name = "TEST"
            };
            base.Config = ret;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES CLIENT /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public override void c_authentification(NTKUser user)
        {
            String msg = user.readMsg();
            if (msg.Equals("..."))
            {
                //............
            }

        }

        public override void c_listen(NTKUser user,String cmd)
        {
            String msg = user.readMsg();
            if (msg.Equals("..."))
            {
                //............
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES SERVER /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        public override void s_authentification(NTKUser user, List<NTKUser> userlist = null, ServicelistenFunction listen = null)
        {
            String msg = user.readMsg();
            if (msg.Equals("..."))
            {
                //............
            }

        }

        public override void s_listen(NTKUser user)
        {
            String msg = user.readMsg();
            if (msg.Equals("..."))
            {
                //............
            }
        }
       
        
        
        
        
        
        
        
        
        /// <summary>
        /// param 1 = configPath
        /// param 2-3-4 = bool
        /// </summary>
        /// <param name="args"></param>
        public override void initialize(params object[] args)
        {
            
        }

    }




}
