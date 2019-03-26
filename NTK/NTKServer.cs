/**********************************
 * NTK - Network Transport Kernel *
 * Server Class                   *
 * 03/07/2018                     *
 **********************************/
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Threading;
using NTK.EventsArgs;
using NTK.Other;
using NTK.Database;
using NTK.IO.Xml;
using NTK.Service;
using NTK.Security;
using NTK.Plugins;
using static NTK.Other.NTKF;
using static NTK.NTKCommands;
using static NTK.Separators;

namespace NTK
{
    /// <summary>
    /// Serveur tcp pouvant héberger un service
    /// </summary>
    public sealed class NTKServer
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ATTRIBUTS ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //Config
        private int port;
        private String name;
        private String stype;
        private NTKService service = new NTKS_Basic(NTKS_Basic.cfg());
        private CTYPE ctype;
        private bool tls = false;
        private bool plugins = false;
        private String secKey;
        private String confpath;
        private bool fileTransfert = true;
        //Security
        private NTKRsa rsa;
        private string asymName;
        private string symetricName;
        private IEncryptor defaultEncryptor = null;
        //IO
        private XmlDocument config;
        private Log_NTK logs;
        private NTKDatabase database;
        private bool header = true;
        //Etat
        private bool run = false;
        private bool pause = false;
        private bool stop = false;
        //Listes
        private List<Token> tokenlist = new List<Token>();
        private List<String> stopCodes = new List<String>();
        private List<NTKUser> userlist = new List<NTKUser>();
        private List<NTKService> extServices = new List<NTKService>();
        private List<NTKDatabase> extDatabase = new List<NTKDatabase>();
        private List<IEncryptor> extEncryptor = new List<IEncryptor>();
        private List<IBasePlugin> extPlugins = new List<IBasePlugin>();

        /// <summary>
        /// Lecture d'un message sur le flux
        /// </summary>
        public event EventHandler ReadMsg;
        

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// Créé un serveur basique
        /// </summary>
        /// <param name="port"></param>
        /// <param name="ctype"></param>
        public NTKServer(int port, CTYPE ctype)
        {
            this.port = port;
            this.ctype = ctype;
            rsa = new NTKRsa();  
        }
    
        /// <summary>
        /// Constructeur avec fichier de configuration
        /// </summary>
        /// <param name="configPath">Chemin vers le fichier</param>
        public NTKServer(string configPath)
        {
            this.confpath = configPath;
            parse();
            rsa = new NTKRsa();
        }
   
        /// <summary>
        /// Créé un serveur basique
        /// </summary>
        /// <param name="port">port d'écoute</param>
        /// <param name="ctype">type d'authentification</param>
        /// <param name="tls">communication chiffrée</param>
        /// <param name="secKey">clé de sécurité</param>
        /// <param name="db">connection à une base de données</param>
        public NTKServer(int port, CTYPE ctype, bool tls, String secKey, NTKDatabase db) {
            this.port = port;
            this.ctype = ctype;
            this.tls = tls;
            this.secKey = secKey;
            this.database = db;
        }

        /// <summary>
        /// 
        /// </summary>
        public NTKServer() { }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        /// <summary>
        /// Methode de démarrage du serveur (Méthode bloquante) 
        /// </summary>
        public void start()
        {
            addLogs(LogsTypes.NOTICE, "Server start");
            try
            {
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.WriteLine(" Configuration :");
                Console.WriteLine(" - Port      :   " + port);
                Console.WriteLine(" - C_TYPE    :   " + ctype);
                Console.WriteLine(" - TLS       :   " + tls);
                Console.WriteLine("═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════");
                Console.ForegroundColor = ConsoleColor.Gray;

                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                TcpListener server = new TcpListener(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
                server.Start();
                
                //Todo : load dll dynamic
                loadService();

                if (ctype == CTYPE.OTHER && !service.Config.authentification)
                {
                    throw new Exception("Aucune méthode d'authentification n'a été toruvée : \nCTYPE = Other & Service.Authentification = false" );
                }

                addLogs(LogsTypes.NOTICE, "Listening");
                Console.WriteLine(" Listening ...");
              
                // Boucle d'accueil
                while (!stop)
                {
                    try {
                        //Création d'un utilisateur temporaire avec un login aléatoire
                        TcpClient client = server.AcceptTcpClient();
                        NTKUser newUser = new NTKUser(generateToken(8, true), client);
         
                        addLogs(LogsTypes.NOTICE, "New user " + newUser.Login);

                        //--------------Entête NTK--------------------------
                        if (header)
                        {
                            newUser.writeMsg(C_VERSION + typeof(NTKServer).Assembly.GetName().Version + PV);
                            newUser.writeMsg(C_TYPE + ctype + PV);
                            newUser.writeMsg(S_TYPE + stype + PV);
                            newUser.writeMsg(C_TLS + tls + PV);
                        }
                       
                        //Chiffrement de la communication
                        ident_tls(newUser);

                        //Selection de l'authentification et de l'écoute -> Thread
                        Thread myThread = new Thread(new ParameterizedThreadStart(selectServiceLisAuth));
                        myThread.Start(newUser);
                    }
                    catch(Exception e)
                    {
                       
                        Console.WriteLine("EndOf : UserThread\n" + e.ToString());
                    }
               }
                
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);

            }

        }
  
        /// <summary>
        /// Gére le protocole de chiffrement TLS
        /// </summary>
        /// <param name="user">Utilisateur</param>
        public void ident_tls(NTKUser user)
        {
            addLogs(LogsTypes.NOTICE, "TLS Identification : " + user.Name);
            if (this.tls)
            {
                user.writeMsg(rsa.getKey());    //Envoie de la clé publique
                String tmp = rsa.decrypt(user.readMsg());   //Réception de la clé symetrique (chiffrée)
                String key = subsep(tmp, "<key>", "</key>");  //Clé
                String iv = subsep(tmp, "<iv>", "</iv>");   //Vecteur d'initialisation
                Console.WriteLine(tmp);
                user.Cipher = new NTKAes(key, iv); //Instanciation de la classe de chiffrement
                user.Tls = true;    //Activation du chiffrement dans les methodes NTKUser.readMsg() && NTKUser.writeMsg(String)
             //   user.writeMsg("OK");
            }
        }
 
        /// <summary>
        /// Boucle d'écoute
        /// </summary>
        /// <param name="user">Utilisateur</param>
        public void basicListen(NTKUser user)
        {
            while (user.Client.Connected && !user.IsBad)
            {
                var tmp = user.readMsg();
                if (!pause)
                {
                    
                    switch (user.Lvl) {
                        //SUPER_ADMIN--------------------------------------------------------------
                        case USER_LVL.SUPER_ADMIN:
                            if (tmp.Contains("C_DO_PAUSE;"))
                            {
                                pause = true;
                            }
                            else if (tmp.Contains("C_DO_STOP_"))    //C_DO_STOP_CODE; Code d'arret
                            {
                                writeToAll("C_STOP;", true);

                                stop = true;
                            }
                            else if (tmp.Contains("QON>"))
                            {
                                //QON>select * from sn_users;
                                //QON = Query Over NTK 
                                // permet des commande SQL à travers NTK qui retourne le résultat en XML
                                var query = subsep(tmp, "QON>", ";");
                                var answer = database.queryOverNTK(query);
                                user.writeMsg(answer);
                            }
                            else if (tmp.Contains("QONC>"))
                            {
                                var query = subsep(tmp, "QONC>", ";");
                                var answer = database.queryOverNTK(query, true);
                                user.writeMsg(answer);
                            }
                            else if (tmp.Contains("GET USERS;"))
                            {
                                var answer = database.queryOverNTK("select Login,sn_users.Name,sn_groups.name,LVL from sn_users " +
                                    "INNER JOIN sn_groups ON GrpID = sn_groups.id", true);
                                user.writeMsg(answer);
                            }
                         
                            else
                            {
                                commandesClassiques(tmp, user);
                            }
                            break;
                       
                        
                        //Commandes ADMIN----------------------------------------------------------------
                        case USER_LVL.ADMIN:

                            if (tmp.Contains(""))
                            {

                            }
                            else if (tmp.Contains(""))
                            {

                            }
                            else
                            {
                                commandesClassiques(tmp, user);
                            }
                            break;
                        //AUTRE--------------------------------------------------------------------------
                        default:
                            commandesClassiques(tmp, user);
                            break;
                }
               

                }
                else // Pause ---------------------------
                {
                    if (user.Lvl == USER_LVL.SUPER_ADMIN && tmp.Contains("C_STOP_PAUSE;"))
                    {
                        pause = false;
                    }
                }


            }//WEND
            
           

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PRIVEES //////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        //========================================[IDENTIFICATION]==========================================================

        private void selectServiceLisAuth(object user)
        {
            var u = (NTKUser)user;
            addLogs(LogsTypes.NOTICE, "SelectService : " + u.Name);
            //Enchainement des fonction d'identification et d'écoute en fonction de la config coté service

            //Selection de la fonction d'écoute
            ServicelistenFunction listenfunction = null;
            if (service.Config.useBasicListen)
            {
                listenfunction = new ServicelistenFunction(basicListen);
            }
            else
            {
                listenfunction = new ServicelistenFunction(service.s_listen);
            }
            //sélection de la fonction d'authentification
            try
            {
                switch (ctype)
                {
                    case CTYPE.BASIC:
                        identification_BASIC(u, listenfunction);
                        break;
                    case CTYPE.OTHER:
                        service.s_authentification(u, userlist, listenfunction);
                        break;
                    default:
                        identification_GLOBAL(u, listenfunction);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                addLogs(LogsTypes.CRITICAL, e.Message);
            }
        }

        private void identification_GLOBAL(NTKUser user, ServicelistenFunction func)
        {
            bool connected = false;
            int nbtent = 0;
            //Boucle d'authentification
            while (!connected && user.Client.Connected && nbtent <=3)
            {
                user.writeMsg(C_RL);
                
                //Authentification
                String umsg = user.readMsg();
                OnReadMsg(new MsgArgs(umsg));

                if (umsg.Contains(A_SUPERADM) && CTYPE.AUTH_USER_O != ctype)
                {
                    bool retid = id_admin(user, umsg);
                    connected = retid;
                }
                else if (umsg.Contains(A_USER))
                {
                    bool retid = id_user(user, umsg);
                    connected = retid;
                }
                else if (umsg.Contains(A_BOT))
                {
                }
                else if (umsg.Contains(A_SUBS) && ctype == CTYPE.AUTH_ADM_SUBS){
                    bool retid = id_subserver(user, umsg);
                    connected = retid;
                }
                else
                {
                    //NiveauUtilisateur inconnu
                }

                nbtent++;
            }


            //3 tentatives max
            if (nbtent > 3 || !connected)
            {
                user = null;    //Echec de connexion suppression de l'utilisateur
            }
            else
            {
                //TODO : Classe TokenList pour gérer les redondances
                //Génération d'un token:
                tokenlist.Add(new Token(generateToken(128), user.Login));

                //Boucle d'écoute (délégué) choisi par selectServiceLisAuth(user)
                func(user);

                //Déconnexion à la sortie de la fonction d'écoute
                connected = false;
                nbtent = 999;
            }
        }

        private void identification_BASIC(NTKUser user, ServicelistenFunction func)
        {
            bool connected = false;
            int nbtent = 0;
            //Boucle d'auhtentification
            while (!connected && user.Client.Connected && nbtent <= 3)
            {
             
                user.writeMsg(C_RL);
              

                //Authentification
                String umsg = user.readMsg();
                OnReadMsg(new MsgArgs(umsg));

                if (umsg.Contains(A_USER))
                {
                    var login = subsep(umsg, ">", ";");
                    if (alreadyConnected(login))
                    {
                        user.writeMsg(A_BAD);
                    }
                    else
                    {
                        user.writeMsg(A_OK);
                        connected = true;
                        user.Login = login;
                        user.Name = login;
                    }
                }
                nbtent++;
            }
            if (nbtent > 3 || !connected)
            {
                user = null;    //Echec de connexion suppression de l'utilisateur
            }
            else
            {
                userlist.Add(user);
                //TODO : Classe TokenList pour gérer les redondances
                //Génération d'un token:
                tokenlist.Add(new Token(generateToken(128), user.Login));

                //Boucle d'écoute (délégué) choisi par selectServiceLisAuth(user)
                func(user);

                //Déconnexion à la sortie de la fonction d'écoute
                connected = false;
                nbtent = 999;
            }
        }


        private bool id_user(NTKUser user, string umsg)
        {
            bool connected = false;
            var login = subsep(umsg, ">", ",");
            var pass = subsep(umsg, ",", ";");
            MySqlDataReader msr = (MySqlDataReader)database.select("SELECT * FROM sn_users WHERE Login='" + login + "';");
            bool end = false;
            while (msr.Read() && !end)
            {
               // database.closeConnection(); //Important !!!!!!!!!
                if (msr.GetString("Login").Equals(login) && msr.GetString("Password").Equals(sha256(pass)) && !alreadyConnected(login))
                {
                    connected = true;
                    end = true;
                    user.Login = login;
                    user.Lvl = setULVL(msr.GetString("LVL"));
                    userlist.Add(user);
                    user.writeMsg(A_OK);
             //       basicListen(userlist[userlist.Count - 1]);
                    
                }
                else
                {
                    user.writeMsg(A_BAD);
                }
            }
            return connected;
        }

        private bool id_admin(NTKUser user, string umsg)
        {
            bool connected = false;
            //  exemple commande : A_SUPER_ADMIN>Kilian,password,seckey;
            String[] argtab = subsep(umsg, ">", ";").Split(Separators.V);

            MySqlDataReader msr = (MySqlDataReader)database.select("SELECT * FROM sn_users WHERE Login='" + argtab[0] + "';");
            msr.Read();

            var dblogin = msr.GetString("Login");
            var dbpass = msr.GetString("Password");
            var hashpass = sha256(argtab[1]);
            var dblvl = msr.GetString("LVL");

            if (dblogin.Equals(argtab[0]) && dbpass.Equals(hashpass)
                && dblvl.Equals(USER_LVL.SUPER_ADMIN.ToString())
                && secKey.Equals(argtab[2]) && !alreadyConnected(argtab[0]))
            {
                user.Id = msr.GetInt32(0);
                user.Login = argtab[0];
                user.Lvl = USER_LVL.SUPER_ADMIN;
                userlist.Add(user);
                user.writeMsg(A_OK);
                connected = true;
            }
            else
            {
                user.writeMsg(A_BAD);
            
                //user.Client.Close();    //temporaire
            }
            return connected;
        }

        private bool id_subserver(NTKUser user, string umsg)
        {
            bool connected = false;
            //  exemple commande : A_SUPER_ADMIN>Kilian,password,seckey;
            String[] argtab = subsep(umsg, ">", ";").Split(Separators.V);



            MySqlDataReader msr = (MySqlDataReader)database.select("SELECT * FROM sn_subs WHERE Login='" + argtab[0] + "';");
            msr.Read();

            var dblogin = msr.GetString("Login");
            var dbpass = msr.GetString("Password");
            var hashpass = sha256(argtab[1]);
            var dblvl = msr.GetString("LVL");

            if (dblogin.Equals(argtab[0]) && dbpass.Equals(hashpass)
                && dblvl.Equals(USER_LVL.SUB_SERVER.ToString()))
            {

                user.Login = argtab[0];
                user.Lvl = USER_LVL.SUB_SERVER;
                userlist.Add(user);
                user.writeMsg(A_OK);
                connected = true;
            }
            else
            {
                user.writeMsg(A_BAD);

                //user.Client.Close();    //temporaire
            }
            return connected;
        }

        private bool id_bot(NTKUser user, string umsg)
        {
            return false;
        }

        private bool reg_user(NTKUser user, string umsg)
        {
            bool ret = false;
            //Syntaxe : A_REG>login,pass,name{,}regkey{;}
            if (umsg.Contains(SPV) && umsg.Contains(SPV) && nbChar(umsg, ',') == 2)
            {
                String[] tmpLPN = subsep(umsg, A_REG, SPV).Split(',');
                String login = tmpLPN[0];
                String pass = tmpLPN[1];
                String name = tmpLPN[2];
                String regKey = subsep(umsg, SV, SPV);

                String query = "SELECT login FROM sn_users WHERE login = '"+login+"';";
                var msr = database.select(query);
                bool continu = !msr.Read();
                msr.Close();
                if (continu)
                {
                    query = "SELECT * FROM sn_regkey WHERE RKEY LIKE '"+regKey+"';";
                    msr = database.select(query);
                    continu = msr.Read();
                    if (continu)
                    {

                    }
                }
            }
            
            return ret;
        }


        //========================================[AUTRE]===================================================================

        private void commandesClassiques(String tmp, NTKUser user)
        {
            if (tmp.Contains("MSG>") && tmp.Contains(SPV))
            {
                try { 
                    //MSG>Salut !{;}
                    //MSG> est une commande de message globale
                    tmp = "MSG>" + user.Name + SV + subsep(tmp, "MSG>", SPV) + SPV;
                    writeToAll(tmp);
                }
                catch (Exception)
                {
                    user.writeMsg(E_SYNTAX);
                }
            }
            else if (tmp.Contains("MSG_") && tmp.Contains(SPV) && tmp.Contains(CD))
            {
                try
                {
                    //MSG_#Target>#msg{;}
                    //MSG_#login> est une commande de message privé
                    var login = subsep(tmp, "MSG_", ">");
                    var content = subsep(tmp, ">", SPV);
                    getUser(login).writeMsg("MSG_" + user.Login + ">" + content + SPV);
                }
                catch (Exception)
                {
                    user.writeMsg(E_SYNTAX);
                }
            }
            else if (tmp.Contains("GET USERS;"))
            {
                var xmld = new XmlDocument();
                var root = xmld.addNode("USERLIST");
                foreach(NTKUser ul in userlist)
                {
                    var node = root.addChild(ul.Login);
                    node.addChild("Name",ul.Name);
                    node.addChild("Lvl",ul.Lvl.ToString());
                }
                user.writeMsg("UL_" + xmld.print() + SPV);

            }
            else if (tmp.Contains("SEND>") && tmp.Contains(SV) && tmp.Contains(SPV) && fileTransfert)
            {
                //  SEND>size{,}Hash{,}ext{,}Target{;}
                var lst = subsep(tmp, "SEND>", SPV).Split(new String[] { SV },StringSplitOptions.None);

                long.TryParse(lst[0], out long size);
                String hash = lst[1];
                String ext = lst[2];
                String target = lst[3];

                var path = @"D:\Programmation\NTK\Files\" + user.Name + "" + hash + "." + ext;

                Console.WriteLine(path);
                user.reciveFile(path, size);

                if (!target.Equals("none"))
                {
                    getUser(target).sendFile(path);
                }
            }
            else if (tmp.Equals("GET SERVICE ASSEMBLY;")){
                user.writeMsg("SEND>servAssembly{,}dll{;}");
                user.sendFile("TODO : MANAGE PATHS ASSEMBLIES");
            }
            else if (tmp.Contains("DISCONNECT;"))
            {
                user.IsBad=true;
            }
        }

        private void writeToAll(String msg,bool closeCon = false)
        {
            foreach(NTKUser uelem in userlist)
            {
                uelem.writeMsg(msg);
                if(closeCon){
                    uelem.Client.Close();
                }
            }
        }

        private bool alreadyConnected(String login)
        {
            bool ret = false;
            int cpt = 0;

            while(cpt < userlist.Count && !ret)
            {
                if (login.Equals(userlist[cpt].Login))
                {
                    ret = true;
                }
                cpt++;
            }

            return ret;
        }
      
        private NTKUser getUser(String name)
        {
            NTKUser ret = null;
            int cpt = 0;

            while (cpt < userlist.Count && !userlist[cpt].Name.Equals(name)) { cpt++; }
            if (userlist[cpt].Name.Equals(name)) {ret = userlist[cpt]; }

            return ret;
        }

        private void purgeTokens()
        {
            for(int i = tokenlist.Count-1; i >=0; i--)
            {
                if (!tokenlist[i].checkDate())
                {
                    tokenlist.RemoveAt(i);
                }
            }
        }

        private void parse()
        {
            //Lecture du fichier XML ---------------------------------------------------------------------------------------------
          
            XmlDocument xmlp = new XmlDocument(confpath);
            this.config = xmlp;
            XmlNode root = xmlp.getNode(0);

            while (root.read())
            {
                var node = root.getNode();
                switch (node.getName())
                {
                    case "port":
                        int.TryParse(node.getValue(),out port);
                        break;                                                                                                                 
                    case "name":
                        this.name = node.getValue();
                        break;
                    case "ctype":
                        this.ctype = setCtype(node.getValue());
                        break;
                    case "tls":
                        bool.TryParse(node.getValue(), out tls);
                        break;
                    case "plugins":
                        bool.TryParse(node.getValue(), out plugins);
                        break;
                    case "seckey":
                        this.secKey = node.getValue();
                        break;
                    case "service":
                        stype = node.getAttibuteV("name");
                        break;
                    case "FileTransfert":
                        bool.TryParse(node.getValue(), out fileTransfert);
                        break;
                    case "database":
                        //setDatabase(node);
                        
                        if (node.getChildV("type").Equals("MYSQL"))
                        {
                            database = NTKD_MySql.getInstance(node.getChildV("host"), node.getChildV("user"), node.getChildV("pass"), node.getChildV("name"), true);
                        }
                        break;
                    case "logs":
                        if (node.isChildExist("NTK")) { this.logs = Log_NTK.getInstance(node.getChildV("NTK")); }
                        if (node.isChildExist("Database") && database != null) {
                            this.database.Logs = Log_Database.getInstance(node.getChildV("Database"));
                        }
                        break;
                    default:
                        break;
                }
            }

            if (database != null)
            {
                database.tryConnection();
            }
        }

        private void addLogs(String type, String text)
        {
            if (logs != null)
            {
                logs.add(new LogLine_NTK(type, text, DateTime.Now));
                logs.flush();
            }
        }

        private void loadService()
        {
            addLogs(LogsTypes.NOTICE, "Loading services");
            Console.Write(" Loading service : " + stype);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            switch (stype)
            {
                case "BASIC":
                    var conf = new ServiceConfig
                    {
                        authentification = false,
                        useBasicListen = true
                    };

                    service = new NTKS_Basic(conf);
                    Console.WriteLine(" [OK]");
                    break;
                case "CN":
                    service = new NTKS_CyberNet(NTKS_CyberNet.basicConfig());
                    Console.WriteLine(" [OK]");
                    break;
                case "SN":
                    service = new NTKS_SN(NTKS_SN.basicConfig(), userlist);
                    Console.WriteLine(" [OK]");
                    break;
                case "DPT":
                    service = new NTKS_DPT(NTKS_DPT.basicConfig(), database);
                    Console.WriteLine(" [OK]");
                    break;
                default: // Chargement des services externes (.dll)
                    bool find = false;
                    bool end = false;
                    int cpt = 0;
                    while (!end)
                    {
                        if (cpt == extServices.Count) { end = true; }
                        else if (stype.Equals(extServices[cpt].Config.name))
                        {
                            service = extServices[cpt];
                            find = true;
                            end = true;
                            Console.WriteLine(" [OK]");
                        }
                        else { cpt++; }
                    }

                    if (!find)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" [BAD]");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        addLogs(LogsTypes.CRITICAL, "Service '" + stype + "' not found");
                        conf = new ServiceConfig
                        {
                            authentification = false,
                        };
                        service = new NTKS_Basic(conf);
                        addLogs(LogsTypes.CRITICAL, "Default Service 'BASIC' loaded");
                        Console.WriteLine("- Default Service 'BASIC' loaded");
                    }
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        private void setDatabase(XmlNode cfg)
        {
            var type = cfg.getChildV("type").ToUpper();
            switch (type)
            {
                case "MYSQL":
                    break;
                case "SQLITE":
                    break;
                case "SQLSERVER":
                    break;
                default:
                    int cpt = 0;
                    while(cpt < extDatabase.Count && !extDatabase[cpt].GetType().Name.Equals(type)) { cpt++; }
                    if (extDatabase[cpt].GetType().Name.Equals(type))
                    {

                    }
                    break;
            
            }
        }

        //===================================================[EVENTS]=======================================================

        private void OnReadMsg(EventArgs e)
        {
            if (ReadMsg != null)
                ReadMsg(this, e);
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS & SETTERS /////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
     
        /// <summary>
        /// 
        /// </summary>
        public int Port {get => port; set {     if (!run) { port = value; }   }}
        /// <summary>
        /// 
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Stype { get => stype; set => stype = value; }
        /// <summary>
        /// 
        /// </summary>
        public NTKService Service { get => service; }
        /// <summary>
        /// 
        /// </summary>
        public CTYPE Ctype { get => ctype; set => ctype = value; }
        /// <summary>
        /// 
        /// </summary>
        public bool Tls { get => tls; set => tls = value; }
        /// <summary>
        /// 
        /// </summary>
        public bool Plugins { get => plugins; set => plugins = value; }
        /// <summary>
        /// 
        /// </summary>
        public List<Token> Tokenlist { get => tokenlist; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> StopCodes { get => stopCodes; }
        /// <summary>
        /// 
        /// </summary>
        public List<NTKUser> Userlist { get => userlist; set => userlist = value; }
        /// <summary>
        /// 
        /// </summary>
        public NTKDatabase Database { get => database; set => database = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Confpath { get => confpath; set => confpath = value; }
        /// <summary>
        /// 
        /// </summary>
        public NTKRsa Rsa { get => rsa; }
        /// <summary>
        /// 
        /// </summary>
        public string SecKey { get => secKey; set => secKey = value; }
        /// <summary>
        /// 
        /// </summary>
        public bool Pause { get => pause; set => pause = value; }
        /// <summary>
        /// 
        /// </summary>
        public bool Stop { get => stop; set => stop = value; }
        /// <summary>
        /// 
        /// </summary>
        public XmlDocument Config { get => config; }
        /// <summary>
        /// 
        /// </summary>
        public List<NTKService> ExtServices { get => extServices; set => extServices = value; }
        /// <summary>
        /// 
        /// </summary>
        public Log_NTK Logs { get => logs; set => logs = value; }
        /// <summary>
        /// Si le serveur doit envoyer une entête NTK avant d'executer le service
        /// </summary>
        public bool Header { get => header; set => header = value; }
        /// <summary>
        /// Si le serveur est lancé
        /// </summary>
        public bool Run { get => run;}
        /// <summary>
        /// Liste des classes (externes) de connection à une base de données 
        /// </summary>
        public List<NTKDatabase> ExtDatabase { get => extDatabase; set => extDatabase = value; }
        /// <summary>
        /// Liste des classes (externes) de chiffrement
        /// </summary>
        public List<IEncryptor> ExtEncryptor { get => extEncryptor; set => extEncryptor = value; }
        /// <summary>
        /// 
        /// </summary>
        public List<IBasePlugin> ExtPlugins { get => extPlugins; set => extPlugins = value; }
        /// <summary>
        /// Si le transfert de fichiers est toléré
        /// </summary>
        public bool FileTransfert { get => fileTransfert; set => fileTransfert = value; }
    }
}