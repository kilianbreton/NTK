using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Pipe
{   //##################################################################################################
    //#Commandes SET####################################################################################
    //##################################################################################################
    
    /// <summary>
    /// Réception d'une liste d'utilisateurs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void onSetUserListEventHandler(object sender, NPM_UserList args);
    /// <summary>
    /// Réception d'une liste de tokens
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void onSetTokenListEventHandler(object sender, NPM_UserList args);
    /// <summary>
    /// Réception d'une connexion à une bdd
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void onSetDatabaseEventHandler(object sender, NPM_UserList args);
    /// <summary>
    /// Réception de la variable d'activation du chiffrement
    /// </summary>
    /// <param name="sender"></param>
    /// <param name=""></param>
    public delegate void onSetTlsActiveEventHandler(object sender, NPM_UserList args);
    /// <summary>
    /// Réception des algorithmes de chiffrement
    /// </summary>
    /// <param name="sender"></param>
    /// <param name=""></param>
    public delegate void onSetTlsAlgorithmEventHandler(object sender, NPM_UserList args);
    /// <summary>
    /// Stop le serveur
    /// </summary>
    /// <param name="sender"></param>
    /// <param name=""></param>
    public delegate void onSetStop(object sender, NPM_UserList args);


    //##################################################################################################
    //#Commandes GET####################################################################################
    //##################################################################################################

    /// <summary>
    /// Demande la liste des utilisateurs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnGetUserList(object sender, NTKPipeMsg args);
    /// <summary>
    /// Demande la liste des tokens
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnGetTokenList(object sender, NTKPipeMsg args);
    /// <summary>
    /// Demande la connexion à la base de données
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnGetDatabase(object sender, NTKPipeMsg args);
    /// <summary>
    /// Demande des informations sur le protocole cryptographique à utiliser
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnGetTlsInfos(object sender, NTKPipeMsg args);

    public delegate void OnGetUserList(object sender, NTKPipeMsg args);

    public delegate void OnGetUserList(object sender, NTKPipeMsg args);




    /// <summary>
    /// Canal de communication inter-serveurs
    /// </summary>
    public class NTKServerPipe
    {
        private List<NTKServer> servers = new List<NTKServer>();
        private int masterId = -1;


        /// <summary>
        /// Créé un canal vierge
        /// </summary>
        public NTKServerPipe() { }

        /// <summary>
        /// Créer un canal entre les serveurs passés en paramètres
        /// </summary>
        /// <param name="servers"></param>
        public NTKServerPipe(params NTKServer[] servers)
        {
            this.servers.AddRange(servers);
            foreach(NTKServer serv in servers)
            {

            }
        }





        public void write(NTKPipeMsg msg, NTKServer sender)
        {
            if(msg.Type == NPMType.SET)
            {

            }
            else
            {
                switch (msg.Text)
                {
                    case "USERLIST":
                        NPM_UserList nmsg = (NPM_UserList)msg;
                        break;
                    case "KICK":

                        break;

                }
            }
        }

        



        /// <summary>
        /// Liste des serveurs
        /// </summary>
        public List<NTKServer> Servers { get => servers; set => servers = value; }
        /// <summary>
        /// Id du serveur maitre
        /// </summary>
        public int MasterId { get => masterId; set => masterId = value; }
    }
}
