# NTK

**Network Transport Kernel**  


# Structure de la solution
* **Application**
  * CLIENT_NTK
  * NGET
  * NTKAdmin
  * NTKInt
  * NTKUniversalServer
* **Ressources**
  * CGE
  * NTK
  * OSS   
* **Tests**
  * NTKCGETester
  * NTKUnitTest
  * NTKPluginTest
  * NTKServiceTest
 
 # Structure de l'assembly NTK
 
<details>
  <summary>Structure NameSpaces et Classes</summary>
  
 * **Database**
    * **ORM**
      * BaseModel
    * **Struct**
      * DBStruct
      * DBSTable
      * DBSColumn
    * NTKDatabase
    * NTKD_Mysql
    * NTKD_Sqlite
    * NTKD_SqlServer
  * **EventArgs**
    * ConnectionEventArgs
    * GetActuEventArgs
    * GetGrpEventArgs
    * GetMsgEventArgs
    * GetServiceEventArgs
    * GetUserEventArgs
    * IdentificationEventArgs
    * MsgArgs
    * OnConnectEventArgs
    * OnErrorEventArgs
  * **IO**
    * DllLoader
    * FileManager
    * FMDirectory
    * FMRule
    * InstallScript
    * Log
    * Logline
    * SysInfo
  * **Other**
    * NTKService
    * *NTKF
    * Token
  * **P2P**
    * P2PService
    * P2PUser
  * **Plugins**
    * IBasePlugin
    * IPluginForm
    * IPluginIntegrated
  * **Security**
    * NTKRsa
    * NTKAes
  * **Services**
    * NTKS_Basic
    * NTKS_SN
    * NTKS_CyberNet
  * **Xml**
    * XmlDocument
    * XmlNode
    * XmlAttribute
  * NTKClient
  * NTKServer
  * NTKUser
  
  
 </details>
 
 # NTK Client implementation
 
 
 ``` C#
      main.Client = new NTKClient(ip, port, login,password,root.seckey);
 ```
 
``` C#
        private void launchClient()
        {
            client.Connect += new NTKClient.OnConnectEventHandler(client_connect);
            client.GetService += new NTKClient.OnGetServiceEventHandler(client_getservice);
            client.Identification += new NTKClient.OnIdentificationEventHandler(client_ident);
            clientThread = new Thread(client.connect);
            clientThread.Start();
        }
        
             //------------------------ACTIONS APRES INITIALISATION DU SERVICE--------------------------
        private void client_getservice(object sender, GetServiceEventArgs args)
        {
            client.Service.getUserEvent += new NTKService.OnGetUserEventHandler(service_getUserList);
            client.Service.getGrpEvent += new NTKService.OnGetGrpEventHandler(service_getGrpList);
            client.Service.getActuEvent += new NTKService.OnGetActuEventHandler(service_getActu);
            client.Service.getMsgEvent += new NTKService.OnGetMsgEventHandler(service_getMsg);
           
        }

        //-------------------------ACTIONS APRES CONNEXION----------------------------------------
        private void client_connect(object sender, OnConnectEventArgs args)
        {
            client.User.WriteMsg += new NTKUser.OnWriteEventHandler(client_WriteMsg);
            client.User.ReadMsg += new NTKUser.OnReadEventHandler(client_ReadMsg);
        }

        private void client_WriteMsg(object sender, MsgArgs args)
        {

            writeConsole(args.ReadText, Color.DodgerBlue);
        }
        private void client_ReadMsg(object sender, MsgArgs args)
        {
            writeConsole(args.ReadText, Color.Orange);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// SERVICE EVENT ///////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //-------------------------GET USERS------------------------------------------------------
        private void service_getUserList(object sender, GetUserEventArgs e)
        {
            dgw_users.Columns.Add("id","id");
            dgw_users.Columns.Add("login","login");
            dgw_users.Columns.Add("lvl","lvl");
            dgw_users.Columns.Add("mail","mail");
            dgw_users.Columns.Add("picid","picid");
            while (e.next())
            {
                dgw_users.Rows.Add(e.getId(), e.getLogin(), e.getLVL(), e.getMail(), e.getPicid());
            }
        }
 ```
 
  # NTK Server implementation
  
  **Avec un fichier de configuration**
  
  Code C#:
  ``` C#
   NTKServer server = new NTKServer(@"D:\Programmation\NTK\Config\server.xml");
   server.start();
  ```
  
  Fichier de configuration XML :
  
  ``` XML
  <server>
    <port>1141</port>
    <name>NomDuServeur</name>
    <ctype>AUTH_ADM</ctype>
    <tls>TRUE</tls> <!-- si la communication est chiffrée -->
    <Assymetric name="RSA" key="AUTO">
    <Symetric>AES</Symetric>
    <plugins>TRUE</plugins>
    <seckey>XF457Gf7Rfgytz85</seckey>
   
 
    <database>
        <type>MYSQL</type>
        <path>NONE</path>
        <host>127.0.0.1</host>
        <user>USER</user>
        <pass>PASS</pass>
        <name>dbname</name>
        <queryOverNTK>true</queryOverNTK> <!-- si les requêtes SQL à travers le socket sont autorisées -->
    </database>

    <service>
        <name>SN</name>
        <mode>GROUP_THREAD</mode>
        <prefix_table>sn_</prefix_table>
    </service>

    <modules>
        <!-- écriture simple-->
        <module>Postgre.dll</module>
        <module>SNP.dll</module>
        <module>MoreStats.dll</module>
        <module>SubTabENC.dll</module>
        <!-- écriture détaillée-->
        <module type="DB">Postgre.dll</module>
        <module type="SERVICE">SNP.dll</module>
        <module type="VISUAL">MoreStats.dll</module>
        <module type="ENCRYPTOR">SubTabENC.dll</module>
    </modules>

     <logs>
        <NTK>Logs\ntk.log</NTK>
        <Database>Logs\db.log</Database>
    </logs>

</server>
  ```
  
  **Sans fichier de configuration**
  
 Code C#:
  ``` C#
   
    NTKServer server = new NTKServer(1141, CTYPE.AUTH_ADM);
    server.SecKey = "XF457Gf7Rfgytz85";
    server.Tls = true;
    server.Plugins = true;
    server.ExtServices.Add(new NTKS_Test());
    server.Database = NTKD_MySql.getInstance("127.0.0.1", "user", "pass", "dbname");
    server.start();


  ```
  
  # Création d'un nouveau service
  
  ``` C#
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
            //pour la déconnection de l'utilisateur après une mauvaise authentification, utilisez user.isBad = true;
        }

        public override void c_listen(NTKUser user)
        {
            String msg = user.readMsg();
            if (msg.Equals("..."))
            {
                //............
            }
            //pour la déconnection de l'utilisateur, sortez de la fonction (utilisez un thread pour le client);
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

  ```
  
  
