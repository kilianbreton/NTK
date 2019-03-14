﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Database;
using NTK.EventsArgs;

namespace NTK.Service
{
    /// <summary>
    /// Pointeur vers méthode d'écoute
    /// </summary>
    /// <param name="user"></param>
    public delegate void ServicelistenFunction(NTKUser user);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnGetActuEventHandler(object sender, GetActuEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnGetUserEventHandler(object sender, GetUserEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnGetMsgEventHandler(object sender, GetMsgEventArgs e);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void OnGetGrpEventHandler(object sender, GetGrpEventArgs e);


    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CLASSE /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// Service (protocole) de communication
    /// </summary>
    public abstract class NTKService
    {

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // EVENTS ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

      
        /// <summary>
        /// 
        /// </summary>
        public event OnGetActuEventHandler getActuEvent;
        /// <summary>
        /// 
        /// </summary>
        public event OnGetUserEventHandler getUserEvent;
        /// <summary>
        /// 
        /// </summary>
        public event OnGetGrpEventHandler getGrpEvent;
        /// <summary>
        /// 
        /// </summary>
        public event OnGetMsgEventHandler getMsgEvent;


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ATTRIBUTS ////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private ServiceConfig config;
        protected NTKServer serv;
        protected NTKClient cli;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Initialisation d'un service avec configuration
        /// </summary>
        /// <param name="config"></param>
        public NTKService(ServiceConfig config)
        {
            this.config = config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serv"></param>
        public NTKService(NTKServer serv)
        {
            this.serv = serv;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public NTKService(NTKClient client)
        {
            this.cli = client;
        }

        /// <summary>
        /// Initialisation d'un service avec une configuration interne
        /// </summary>
        public NTKService() { }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ABSTRACT /////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public abstract void initialize(params Object[] args);

        /// <summary>
        /// Methode d'authentification coté serveur
        /// </summary>
        /// <remarks>
        /// Si l'authentification réussie, utilisez listen(user); sinon user.IsBad; avant de sortir de la méthode.
        /// </remarks>  
        /// <permission cref="System.Security.PermissionSet">PUBLIC</permission>
        /// <param name="user">Utilisateur</param>
        /// <param name="userlist">Liste des utilisateurs</param>
        /// <param name="listen">Méthode d'écoute selectionnée par le serveur</param>
        public abstract void s_authentification(NTKUser user, List<NTKUser> userlist, ServicelistenFunction listen);

        /// <summary>
        /// Methode d'écoute coté serveur
        /// </summary>
        /// <param name="user"></param>
        public abstract void s_listen(NTKUser user);
      
        /// <summary>
        /// Methode d'authentification coté client
        /// </summary>
        /// <param name="user"></param>
        public abstract void c_authentification(NTKUser user);
     
        /// <summary>
        /// Methode d'écoute coté client
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cmd"></param>
        public abstract void c_listen(NTKUser user,String cmd);

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes Protected ///////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startCommand"></param>
        /// <param name="endString"></param>
        /// <param name="user"></param>
        /// <returns></returns>
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


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // EVENTS ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnGetActu(GetActuEventArgs e)
        {
            if (getActuEvent != null)
                getActuEvent(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnGetUser(GetUserEventArgs e)
        {
            if (getUserEvent != null)
                getUserEvent(this, e);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTER ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
        /// <summary>
        /// 
        /// </summary>
        public ServiceConfig Config { get => config; set => config = value; }

    }
}