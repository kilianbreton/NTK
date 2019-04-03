/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * Client Class                                                                      *
 * ----------------------------------------------------------------------------------*
 *                                                                                   *
 * LICENSE: This program is free software: you can redistribute it and/or modify     *
 * it under the terms of the GNU General Public License as published by              *
 * the Free Software Foundation, either version 3 of the License, or                 *
 * (at your option) any later version.                                               *
 *                                                                                   *
 * This program is distributed in the hope that it will be useful,                   *
 * but WITHOUT ANY WARRANTY; without even the implied warranty of                    *
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                     *
 * GNU General Public License for more details.                                      *
 *                                                                                   *
 * You should have received a copy of the GNU General Public License                 *
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.             *
 *                                                                                   *
 * ----------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NTK.EventsArgs;
using NTK.Other;
using NTK.Security;
using NTK.Service;
using static NTK.Other.NTKF;
using static NTK.NTKCommands;
using static NTK.Separators;

namespace NTK
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnIdentificationEventHandler(object sender, IdentificationEventArgs args);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnReadEventHandler(object sender, MsgArgs args);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnWriteEventHandler(object sender, MsgArgs args);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnGetServiceEventHandler(object sender, GetServiceEventArgs args);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnConnectEventHandler(object sender, OnConnectEventArgs args);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnErrorEventHandler(object sender, OnErrorEventArgs args);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnStopEventHandler(object sender, StopEventArgs args);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void OnChangeStateHandler(object sender, StateEventArgs args);
   
    
    /// <summary>
    /// Client tcp
    /// </summary>
    public class NTKClient
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // EVENTS ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        /// <summary>
        /// 
        /// </summary>
        public event OnConnectEventHandler Connect;
        /// <summary>
        /// 
        /// </summary>
        public event OnIdentificationEventHandler Identification;
        /// <summary>
        /// 
        /// </summary>
        public event OnReadEventHandler ReadMsg;
        /// <summary>
        /// 
        /// </summary>
        public event OnGetServiceEventHandler GetService;
        /// <summary>
        /// 
        /// </summary>
        public event OnWriteEventHandler WriteMsg;
        /// <summary>
        /// 
        /// </summary>
        public event OnErrorEventHandler Error;
        /// <summary>
        /// 
        /// </summary>
        public event OnStopEventHandler Stop;
        /// <summary>
        /// 
        /// </summary>
        public event OnChangeStateHandler State;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// PROPRIETES ///////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private NTKUser user;
        private int port;
        private String adrs;
        private String stype;
        private NTKService service;
        private CTYPE ctype;
        private String seckey;
        private bool reg;
        private TcpClient client;
        private String login;
        private String pass;
        private Log_NTK logs;
        private USER_LVL lvl;

        //Listes (Plugins)
        private List<IEncryptor> extEncryptors = new List<IEncryptor>();
        private List<NTKService> extServices = new List<NTKService>();
     
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adrs"></param>
        /// <param name="port"></param>
        public NTKClient(String adrs,int port)
        {
            this.Adrs = adrs;
            this.Port = port;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adrs"></param>
        /// <param name="port"></param>
        /// <param name="login"></param>
        /// <param name="pass"></param>
        /// <param name="seckey"></param>
        /// <param name="reg"></param>
        public NTKClient(String adrs,int port, String login,String pass, String seckey = "none", bool reg = false)
        {
            this.Adrs = adrs;
            this.Port = port;
            this.Login = login;
            this.Pass = pass;
            this.reg = reg;
            if (seckey != "none")
            {
                this.Seckey = seckey;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES /////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
        /// <summary>
        /// 
        /// </summary>
        public void connect()
        {
            try
            {
                Client = new TcpClient(Adrs, Port);
                if (Client.Connected)
                {
                    NetworkStream stream = Client.GetStream();
                    StreamWriter sw = new StreamWriter(stream);
                    StreamReader sr = new StreamReader(stream);
                    User = new NTKUser(NTKF.generateToken(8),Client, new NTKAes());
                    User.Login=Login;
                    User.Pass=Pass;
                    User.Seckey=Seckey;
                    OnConnect(new OnConnectEventArgs(System.Data.ConnectionState.Open));
                    listenLoop(User);
                    if (user.IsBad)
                    {

                    }
                }
            }
            catch(Exception e)
            {
                addLogs(LogsTypes.CRITICAL, e.ToString() + "\n ------------------------------ \n" + e.Message);
                Console.WriteLine(e.Message + " : " + e.ToString());
            }
           
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        public void listenLoop(NTKUser u)
        {
            bool find = false;
            bool stop = false;
            while (u.Client.Connected && !stop)
            {
                try
                {
                    String tmp = u.readMsg();
                    addLogs(LogsTypes.NOTICE, tmp);
                    if (tmp.Contains(C_TYPE))
                    {
                        Ctype = setCtype(subsep(tmp, C_TYPE, ";"));
                    }
                    else if (tmp.Contains(S_TYPE))
                    {
                        Stype = NTKF.subsep(tmp, S_TYPE, ";");
                        find = true;
                        switch (Stype)
                        {
                            case "BASIC":
                                var conf = new ServiceConfig();
                                conf.authentification = false;
                                
                                service = new NTKS_Basic(conf);
                                Console.WriteLine("- OK");
                                break;
                            case "CN":
                                service = new NTKS_CyberNet(NTKS_CyberNet.basicConfig());
                                Console.WriteLine("- OK");
                                break;
                            case "SN":
                                service = new NTKS_SN();
                                Console.WriteLine("- OK");
                                break;
                            case "DPT":
                                service = new NTKS_DPT(NTKS_DPT.basicConfig(), null);
                                Console.WriteLine("- OK");
                                break;
                            default:
                                int cpt = 0;
                                while(cpt<extServices.Count && !extServices[cpt].Config.name.Equals(Stype)){ cpt++; }
                                if (extServices[cpt].Config.name.Equals(Stype))
                                {
                                    service = extServices[cpt];
                                    Console.WriteLine("- OK");
                                }
                                else
                                {
                                    Console.WriteLine("- Not found");
                                    find = false;
                                    user.writeMsg("GET SERVICE ASSEMBLY;");
                                    var res = user.readMsg();
                                    if (res.Contains("SEND>"))
                                    {
                                        //TODO: Transfert ServicePerso.dll
                                    }
                                }
                                break;
                        }
                        OnGetService(new GetServiceEventArgs(service));
                    }
                    else if (tmp.Contains(C_TLS))
                    {
                        bool tmptls = (bool.Parse(NTKF.subsep(tmp, C_TLS, ";")));
                        if (tmptls)
                        {
                            ident_tls(u);
                        }
                    }
                    else if (tmp.Contains(C_RL))
                    {
                        //AUTHENTIFICATION
                        switch(ctype)
                        {
                            case CTYPE.BASIC:
                                writeMsg(A_USER + Login + PV);
                                var result = readMsg();
                                if (result.Equals(A_OK))
                                {
                                    OnIdentification(new IdentificationEventArgs(NTK.Identification.Success));
                                }
                                else
                                {
                                    OnIdentification(new IdentificationEventArgs(NTK.Identification.PasswordError));
                                }
                                break;
                            case CTYPE.OTHER:
                                if (service.Config.authentification)
                                {
                                    service.c_authentification(user);
                                }
                                else
                                {
                                    throw new Exception("Aucune méthode d'authentification trouvé !");
                                }
                                break;
                            default:
                                if (reg)
                                {
                                    writeMsg(A_REG + login + V + pass + V + seckey + PV);
                                    var resultr = readMsg();
                                    if (resultr.Equals(A_OK))
                                    {
                                        OnIdentification(new IdentificationEventArgs(NTK.Identification.Success));
                                    }
                                }
                                else
                                {
                                    switch (lvl)
                                    {
                                        case USER_LVL.SUPER_ADMIN:
                                            //  exemple commande : A_SUPER_ADMIN>Kilian,password,seckey;
                                            writeMsg(A_SUPERADM + Login + V + Pass + V + Seckey + PV);
                                            break;
                                        case USER_LVL.ADMIN:
                                            writeMsg(A_ADMIN + Login + V + Pass + PV);
                                            break;
                                        case USER_LVL.USER:
                                            writeMsg(A_USER + Login + V + Pass + PV);
                                            break;
                                        case USER_LVL.SUB_SERVER:
                                            writeMsg(A_SUBS + Login + V + Pass + V + Seckey + PV);
                                            break;
                                        case USER_LVL.BOT:
                                            writeMsg(A_BOT + Pass + PV);   //(pass = token)
                                            break;
                                    }
                                    //On continue dans la boucle principale
                                    result = readMsg();
                                    if (result.Equals(A_OK))
                                    {
                                        OnIdentification(new IdentificationEventArgs(NTK.Identification.Success));
                                    }
                                    else
                                    {
                                        OnIdentification(new IdentificationEventArgs(NTK.Identification.PasswordError));
                                    }
                               
                                }
                                break;
                        }
                       
                    }
                    else if (tmp.Contains(C_STOP))
                    {
                        int code = int.Parse(subsep(tmp, C_STOP, Separators.PV.ToString()));
                        OnStop(new StopEventArgs(code));
                        stop = true;
                    }
                    if (find)
                    {
                        service.c_listen(u,tmp);
                        //Sortie de l'écoute
                        u.IsBad = true;
                    }
                }
                catch (Exception e)
                {
                    OnError(new OnErrorEventArgs("Exception", e.ToString()));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String readMsg()
        {
            String tmp = User.readMsg();
            MsgArgs argsE = new MsgArgs(tmp);
            OnReadMsg(argsE);
            addLogs(LogsTypes.NOTICE, tmp);
            return tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public void writeMsg(String msg)
        {
            MsgArgs argsE = new MsgArgs(User.Login + " : " + msg);
            OnWriteMsg(argsE);
            addLogs(LogsTypes.NOTICE, msg);
            User.writeMsg(msg);
        }

        /// <summary>
        /// Envoi d'un fichier
        /// </summary>
        /// <param name="path"></param>
        public void sendFile(String path)
        {
            addLogs(LogsTypes.NOTICE, "send file :  " + path);
            user.sendFile(path);
        }


        /// <summary>
        /// 
        /// </summary>
        public void closeConnection()
        {
            writeMsg(C_STOP);
            client.Close();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES ASYNCHRONES /////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task connectAsync()
        {
            try
            {
                Client = new TcpClient(Adrs, Port);
                if (Client.Connected)
                {
                    NetworkStream stream = Client.GetStream();
                    StreamWriter sw = new StreamWriter(stream);
                    StreamReader sr = new StreamReader(stream);
                    User = new NTKUser(NTKF.generateToken(8), Client);
                    User.Login = Login;
                    User.Pass = Pass;
                    User.Seckey = Seckey;
                    OnConnect(new OnConnectEventArgs(System.Data.ConnectionState.Open));
                    await listenLoopAsync(User);
                }
            }
            catch (Exception e)
            {
                addLogs(LogsTypes.CRITICAL, e.ToString() + "\n ------------------------------ \n" + e.Message);
                Console.WriteLine(e.Message + " : " + e.ToString());
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <returns></returns>
        public async Task listenLoopAsync(NTKUser u)
        {
            bool find = false;
            bool servstart = false;
            while (Client.Connected)
            {
                try
                {
                    String tmp = await u.readMsgAsync();
                    addLogs(LogsTypes.NOTICE, tmp);
                    if (tmp.Contains(C_TYPE))
                    {
                        Ctype = setCtype(subsep(tmp, C_TYPE, ";"));
                    }
                    else if (tmp.Contains(S_TYPE))
                    {
                        Stype = NTKF.subsep(tmp, S_TYPE, ";");
                        find = true;
                        switch (Stype)
                        {
                            case "BASIC":
                                var conf = new ServiceConfig();
                                conf.authentification = false;
                            
                                service = new NTKS_Basic(conf);
                                Console.WriteLine("- OK");
                                break;
                            case "CN":
                                service = new NTKS_CyberNet(NTKS_CyberNet.basicConfig());
                                Console.WriteLine("- OK");
                                break;
                            case "SN":
                                service = new NTKS_SN();
                                Console.WriteLine("- OK");
                                break;
                            case "DPT":
                                service = new NTKS_DPT(NTKS_DPT.basicConfig(), null);
                                Console.WriteLine("- OK");
                                break;
                            default:
                                Console.WriteLine("- Not found");
                                find = false;
                                //TO DO: Manage plugins
                                break;
                        }
                        OnGetService(new GetServiceEventArgs(service));
                    }
                    else if (tmp.Contains(C_TLS))
                    {
                        bool tmptls = (bool.Parse(NTKF.subsep(tmp, C_TLS, ";")));
                        if (tmptls)
                        {
                            await ident_tlsAsync(u);
                        }
                    }
                    else if (tmp.Contains(C_RL))
                    {
                        //AUTHENTIFICATION
                        if (Ctype.Equals(CTYPE.AUTH_ADM))
                        {
                            if (reg)
                            {
                                await writeMsgAsync(A_REG + login + "" + pass + "" + seckey);
                                var resultr = readMsg();
                                if (resultr.Equals(A_OK))
                                {
                                    OnIdentification(new IdentificationEventArgs(NTK.Identification.Success));
                                }
                            }
                            else
                            {
                                switch (lvl)
                                {
                                    case USER_LVL.SUPER_ADMIN:
                                        //  exemple commande : A_SUPER_ADMIN>Kilian,password,seckey;
                                        await writeMsgAsync(A_SUPERADM + Login + "," + Pass + "," + Seckey + ";");
                                        break;
                                    case USER_LVL.ADMIN:
                                        await writeMsgAsync(A_ADMIN + Login + "," + Pass + ";");
                                        break;
                                    case USER_LVL.USER:
                                        await writeMsgAsync(A_USER + Login + "," + Pass + ";");
                                        break;
                                    case USER_LVL.SUB_SERVER:
                                        await writeMsgAsync(A_SUBS + Login + "," + Pass + "," + Seckey + ";");
                                        break;
                                    case USER_LVL.BOT:
                                        await writeMsgAsync(A_BOT + Pass + ";");   //(pass = token)
                                        break;
                                }
                                //On continue dans la boucle principale
                                var result = readMsg();
                                if (result.Equals(A_OK))
                                {
                                    OnIdentification(new IdentificationEventArgs(NTK.Identification.Success));
                                }
                                else
                                {
                                    OnIdentification(new IdentificationEventArgs(NTK.Identification.PasswordError));
                                }

                            }
                        }
                        else
                        {

                        }
                    }
                    else if (tmp.Contains(C_STOP))
                    {
                        int code = int.Parse(subsep(tmp, C_STOP, Separators.PV.ToString()));
                        OnStop(new StopEventArgs(code));
                    }
                    if (find)
                    {
                        service.c_listen(u, tmp);
                    }
                }
                catch (Exception e)
                {
                    OnError(new OnErrorEventArgs("Exception", e.ToString()));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<String> readMsgAsync()
        {
            String tmp = await User.readMsgAsync();
            MsgArgs argsE = new MsgArgs(tmp);
            OnReadMsg(argsE);
            addLogs(LogsTypes.NOTICE, tmp);
            return tmp;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task writeMsgAsync(String msg)
        {
            MsgArgs argsE = new MsgArgs(User.Login + " : " + msg);
            OnWriteMsg(argsE);
            addLogs(LogsTypes.NOTICE, msg);
            await User.writeMsgAsync(msg);
        }

        /// <summary>
        /// Envoi un fichier de manière asynchrone
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task sendFileAsync(String path)
        {
            await user.sendFileAsync(path);
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task closeConnectionAsync()
        {
            await writeMsgAsync(C_STOP);
            client.Close();
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // EVENTS ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnIdentification(IdentificationEventArgs e)
        {
            if (Identification != null)
                Identification(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnGetService(GetServiceEventArgs e)
        {
            if (GetService != null)
                GetService(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnReadMsg(MsgArgs e)
        {
            if (ReadMsg != null)
                ReadMsg(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWriteMsg(MsgArgs e)
        {
            if (WriteMsg != null)
                WriteMsg(this, e);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnConnect(OnConnectEventArgs e)
        {
            if (Connect != null)
                Connect(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnError(OnErrorEventArgs e)
        {
            if(Error != null)
            {
                Error(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnStop(StopEventArgs e)
        {
            if (Stop != null)
            {
                Stop(this, e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnChangeState(StateEventArgs e)
        {
            if (State != null)
            {
                State(this, e);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PRIVEES /////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void ident_tls(NTKUser user)
        {
            addLogs(LogsTypes.NOTICE, "Sécurisation de la connexion");
            NTKRsa rsa = new NTKRsa(user.readMsg(), false);
            Random rnd = new Random();
            user.writeMsg(rsa.encrypt(user.Cipher.getKey()));
            user.Tls = true;
        }

        private void addLogs(String type, String text)
        {
            if (logs != null)
            {
                logs.add(new LogLine_NTK(this,type, text, DateTime.Now));
                logs.flush();
            }
        }

        private async Task ident_tlsAsync(NTKUser user)
        {
            addLogs(LogsTypes.NOTICE, "Sécurisation de la connexion");
            NTKRsa rsa = new NTKRsa(user.readMsg(), false);
            Random rnd = new Random();
            // user.Cipher = new NTKAes(NTKAes.CreateKey(rnd.Next(666666)));
            await user.writeMsgAsync(rsa.encrypt(user.Cipher.getKey()));
            user.Tls = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTER ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Utilisateur du client
        /// </summary>
        public NTKUser User { get => user; set => user = value; }
        /// <summary>
        /// Port de connexion
        /// </summary>
        public int Port { get => port; set => port = value; }
        /// <summary>
        /// Adresse IP ou domaine du serveur
        /// </summary>
        public string Adrs { get => adrs; set => adrs = value; }
        /// <summary>
        /// Nom du service à utiliser
        /// </summary>
        public string Stype { get => stype; set => stype = value; }
        /// <summary>
        /// Type de connexion (Mode d'authentification)
        /// </summary>
        public CTYPE Ctype { get => ctype; set => ctype = value; }
        /// <summary>
        /// Clée de sécurité (Connexion Admin)
        /// </summary>
        public string Seckey { get => seckey; set => seckey = value; }
        /// <summary>
        /// Client TCP
        /// </summary>
        public TcpClient Client { get => client; set => client = value; }
        /// <summary>
        /// Identifiant
        /// </summary>
        public string Login { get => login; set => login = value; }
        /// <summary>
        /// Mot de passe
        /// </summary>
        public string Pass { get => pass; set => pass = value; }
        /// <summary>
        /// Service en cour d'utilisation
        /// </summary>
        public NTKService Service { get => service; set => service = value; }
        /// <summary>
        /// Objet de log
        /// </summary>
        public Log_NTK Logs { get => logs; set => logs = value; }
        /// <summary>
        /// Niveau de l'utilisateur du client
        /// </summary>
        public USER_LVL Lvl { get => lvl; set => lvl = value; }
        /// <summary>
        /// Authentification par l'enregistrement
        /// </summary>
        public bool Reg { get => reg; set => reg = value; }
        /// <summary>
        /// Liste des algorithmes de chiffrement externe (Hos AES)
        /// </summary>
        public List<IEncryptor> ExtEncryptors { get => extEncryptors; set => extEncryptors = value; }
        /// <summary>
        /// Liste des services externe
        /// </summary>
        public List<NTKService> ExtServices { get => extServices; set => extServices = value; }
    }
}