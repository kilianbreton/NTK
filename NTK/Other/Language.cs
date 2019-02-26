/***********************************
 * ARN - Abstract & Ressources NTK *
 * 18/07/2018                      *
 ***********************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NTK.Other
{
    public abstract class Language
    {
        //Kernel Messages-----------------------------------------------------------------------------
        public abstract String NTK { get; }
        public abstract String LOADING_SERVICE { get; }
        public abstract String LISTENING { get; }
        public abstract String DISCONNECTED { get; }
        //CMD_INT-------------------------------------------------------------------------------------
        public abstract String HELP { get; }
        public abstract String CI_DB { get; }
        public abstract String CI_CLIENT { get; }
        public abstract String CI_SERVER { get; }
        public abstract String CI_PLUGINS { get; }
        public abstract String CI_ENCRYPTION { get; }
        public abstract String CI_CGI { get; }
        public abstract String CI_EXIT { get; }
        public abstract String CI_ASK_SERVER { get; }
        public abstract String CI_ASK_USER { get; }
        public abstract String CI_ASK_BASE { get; }
        public abstract String CI_DB_RC { get; }
        public abstract String CI_db8ask { get; }
        public abstract String CI_DB_Q { get; }
        public abstract String CI_AYS { get; }
        public abstract String CI_SKS_TITLE { get; }






    }
}
