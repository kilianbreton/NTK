using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Database;
using NTK.EventsArgs;

namespace NTK.Other
{
    public struct ServiceConfig
    {
        public String name;
        public bool authentification;
        public bool useBasicListen;
        public string stype;
        public string ctype;
        public string path;
        public int maxdirsize;
        public int maxfilesize;
        public List<String[]> queryServiceData;
        public String tables_prefix;
        public String[] table;
        public DBStruct database;
        public NTKDatabase dbq;
    }

    public delegate void ServicelistenFunction(NTKUser user);

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// CLASSE /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public abstract class NTKService
    {

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// EVENTS ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void OnGetActuEventHandler(object sender, GetActuEventArgs e);
        public delegate void OnGetUserEventHandler(object sender, GetUserEventArgs e);
        public delegate void OnGetMsgEventHandler(object sender, GetMsgEventArgs e);
        public delegate void OnGetGrpEventHandler(object sender, GetGrpEventArgs e);

        public event OnGetActuEventHandler getActuEvent;
        public event OnGetUserEventHandler getUserEvent;
        public event OnGetGrpEventHandler getGrpEvent;
        public event OnGetMsgEventHandler getMsgEvent;

        private ServiceConfig config;
        protected NTKServer serv;
        protected NTKClient cli; 
     
        public NTKService(ServiceConfig config)
        {
            this.config = config;
        }

        public NTKService(NTKServer serv)
        {
            this.serv = serv;
        }

        public NTKService(NTKClient client)
        {
            this.cli = client;
        }

        public NTKService() { }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ABSTRACT /////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public abstract void initialize(params Object[] args);

        public abstract void s_authentification(NTKUser user, List<NTKUser> userlist = null, ServicelistenFunction listen = null);
        public abstract void s_listen(NTKUser user);

        public abstract void c_authentification(NTKUser user);
        public abstract void c_listen(NTKUser user,String cmd);

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Methodes Protected ///////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected String waitEndCommand(String startCommand,String endString,NTKUser user)
        {
            String tempDataSql = startCommand;
            var tmp = user.readMsg();
            while (!tmp.Contains("{;}"))
            {
                tempDataSql += tmp;
                tmp = user.readMsg();
            }
            tempDataSql += tmp;
            return tempDataSql;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// EVENTS ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnGetActu(GetActuEventArgs e)
        {
            if (getActuEvent != null)
                getActuEvent(this, e);
        }

        protected virtual void OnGetUser(GetUserEventArgs e)
        {
            if (getUserEvent != null)
                getUserEvent(this, e);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// GETTER ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ServiceConfig Config { get => config; set => config = value; }

    }
}
