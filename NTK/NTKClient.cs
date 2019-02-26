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

namespace NTK
{
   
    public class NTKClient
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// EVENTS ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void OnIdentificationEventHandler(object sender, IdentificationEventArgs args);
        public delegate void OnReadEventHandler(object sender, MsgArgs args);
        public delegate void OnWriteEventHandler(object sender, MsgArgs args);
        public delegate void OnGetServiceEventHandler(object sender, GetServiceEventArgs args);
        public delegate void OnConnectEventHandler(object sender, OnConnectEventArgs args);
        public delegate void OnErrorEventHandler(object sender, OnErrorEventArgs args);
        public delegate void OnStopEventHandler(object sender, StopEventArgs args);

        public event OnConnectEventHandler Connect;
        public event OnIdentificationEventHandler Identification;
        public event OnReadEventHandler ReadMsg;
        public event OnGetServiceEventHandler GetService;
        public event OnWriteEventHandler WriteMsg;
        public event OnErrorEventHandler Error;
        public event OnStopEventHandler Stop;

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
        private NTKRsa rsa;
        private Log_NTK logs;
        private USER_LVL lvl;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public NTKClient(String adrs,int port)
        {
            this.Adrs = adrs;
            this.Port = port;
        }

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

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// METHODES /////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
                    User = new NTKUser(NTKF.generateToken(8),Client);
                    User.Login=Login;
                    User.Pass=Pass;
                    User.Seckey=Seckey;
                    OnConnect(new OnConnectEventArgs(System.Data.ConnectionState.Open));
                    listenLoop(User);
                }
            }
            catch(Exception e)
            {
                addLogs(LogsTypes.CRITICAL, e.ToString() + "\n ------------------------------ \n" + e.Message);
                Console.WriteLine(e.Message + " : " + e.ToString());
            }
           
        }

        public void listenLoop(NTKUser u)
        {
            bool find = false;
            bool servstart = false;
            while (Client.Connected)
            {
                try
                {
                    String tmp = u.readMsg();
                    addLogs(LogsTypes.NOTICE, tmp);
                    if (tmp.Contains(NTKCommands.C_TYPE))
                    {
                        Ctype = setCtype(subsep(tmp, NTKCommands.C_TYPE, ";"));
                    }
                    else if (tmp.Contains(NTKCommands.S_TYPE))
                    {
                        Stype = NTKF.subsep(tmp, NTKCommands.S_TYPE, ";");
                        find = true;
                        switch (Stype)
                        {
                            case "BASIC":
                                var conf = new ServiceConfig();
                                conf.authentification = false;
                                conf.ctype = ctype.ToString();
                                service = new NTKS_Basic(conf);
                                Console.WriteLine("- OK");
                                break;
                            case "CN":
                                service = new NTKS_CyberNet(NTKS_CyberNet.basicConfig());
                                Console.WriteLine("- OK");
                                break;
                            case "SN":
                                service = new NTKS_SN(this);
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
                    else if (tmp.Contains(NTKCommands.C_TLS))
                    {
                        bool tmptls = (bool.Parse(NTKF.subsep(tmp, NTKCommands.C_TLS, ";")));
                        if (tmptls)
                        {
                            ident_tls(u);
                        }
                    }
                    else if (tmp.Contains(NTKCommands.C_RL))
                    {
                        //AUTHENTIFICATION
                        if (Ctype.Equals(CTYPE.AUTH_ADM))
                        {
                            if (reg)
                            {
                                writeMsg(NTKCommands.A_REG + login + "" + pass + "" + seckey);
                                var resultr = readMsg();
                                if (resultr.Equals(NTKCommands.A_OK))
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
                                        writeMsg(NTKCommands.A_SUPERADM + Login + "," + Pass + "," + Seckey + ";");
                                        break;
                                    case USER_LVL.ADMIN:
                                        writeMsg(NTKCommands.A_ADMIN + Login + "," + Pass + ";");
                                        break;
                                    case USER_LVL.USER:
                                        writeMsg(NTKCommands.A_USER + Login + "," + Pass + ";");
                                        break;
                                    case USER_LVL.SUB_SERVER:
                                        writeMsg(NTKCommands.A_SUBS + Login + "," + Pass + "," + Seckey + ";");
                                        break;
                                    case USER_LVL.BOT:
                                        writeMsg(NTKCommands.A_BOT + Pass + ";");   //(pass = token)
                                        break;
                                }
                                //On continue dans la boucle principale
                                var result = readMsg();
                                if (result.Equals(NTKCommands.A_OK))
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
                    else if (tmp.Contains(NTKCommands.C_STOP))
                    {
                        int code = int.Parse(subsep(tmp, NTKCommands.C_STOP, Separators.PV.ToString()));
                        OnStop(new StopEventArgs(code));
                    }
                    if (find)
                    {
                      service.c_listen(u,tmp);
                    }
                }
                catch (Exception e)
                {
                    OnError(new OnErrorEventArgs("Exception", e.ToString()));
                }
            }
        }

        private void ident_tls(NTKUser user)
        {
            addLogs(LogsTypes.NOTICE, "Sécurisation de la connexion");
            NTKRsa rsa = new NTKRsa(user.readMsg(), false);
            Random rnd = new Random();
            user.writeMsg(rsa.encrypt(user.Cipher.getKey()));
            user.Tls = true;
        }

        public String readMsg()
        {
            String tmp = User.readMsg();
            MsgArgs argsE = new MsgArgs(tmp);
            OnReadMsg(argsE);
            addLogs(LogsTypes.NOTICE, tmp);
            return tmp;
        }

        public void writeMsg(String msg)
        {
            MsgArgs argsE = new MsgArgs(User.Login + " : " + msg);
            OnWriteMsg(argsE);
            addLogs(LogsTypes.NOTICE, msg);
            User.writeMsg(msg);
        }

        public void closeConnection()
        {
            writeMsg(NTKCommands.C_STOP);
            client.Close();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// METHODES ASYNCHRONES /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


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
                    if (tmp.Contains(NTKCommands.C_TYPE))
                    {
                        Ctype = setCtype(subsep(tmp, NTKCommands.C_TYPE, ";"));
                    }
                    else if (tmp.Contains(NTKCommands.S_TYPE))
                    {
                        Stype = NTKF.subsep(tmp, NTKCommands.S_TYPE, ";");
                        find = true;
                        switch (Stype)
                        {
                            case "BASIC":
                                var conf = new ServiceConfig();
                                conf.authentification = false;
                                conf.ctype = ctype.ToString();
                                service = new NTKS_Basic(conf);
                                Console.WriteLine("- OK");
                                break;
                            case "CN":
                                service = new NTKS_CyberNet(NTKS_CyberNet.basicConfig());
                                Console.WriteLine("- OK");
                                break;
                            case "SN":
                                service = new NTKS_SN(this);
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
                    else if (tmp.Contains(NTKCommands.C_TLS))
                    {
                        bool tmptls = (bool.Parse(NTKF.subsep(tmp, NTKCommands.C_TLS, ";")));
                        if (tmptls)
                        {
                            await ident_tlsAsync(u);
                        }
                    }
                    else if (tmp.Contains(NTKCommands.C_RL))
                    {
                        //AUTHENTIFICATION
                        if (Ctype.Equals(CTYPE.AUTH_ADM))
                        {
                            if (reg)
                            {
                                await writeMsgAsync(NTKCommands.A_REG + login + "" + pass + "" + seckey);
                                var resultr = readMsg();
                                if (resultr.Equals(NTKCommands.A_OK))
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
                                        await writeMsgAsync(NTKCommands.A_SUPERADM + Login + "," + Pass + "," + Seckey + ";");
                                        break;
                                    case USER_LVL.ADMIN:
                                        await writeMsgAsync(NTKCommands.A_ADMIN + Login + "," + Pass + ";");
                                        break;
                                    case USER_LVL.USER:
                                        await writeMsgAsync(NTKCommands.A_USER + Login + "," + Pass + ";");
                                        break;
                                    case USER_LVL.SUB_SERVER:
                                        await writeMsgAsync(NTKCommands.A_SUBS + Login + "," + Pass + "," + Seckey + ";");
                                        break;
                                    case USER_LVL.BOT:
                                        await writeMsgAsync(NTKCommands.A_BOT + Pass + ";");   //(pass = token)
                                        break;
                                }
                                //On continue dans la boucle principale
                                var result = readMsg();
                                if (result.Equals(NTKCommands.A_OK))
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
                    else if (tmp.Contains(NTKCommands.C_STOP))
                    {
                        int code = int.Parse(subsep(tmp, NTKCommands.C_STOP, Separators.PV.ToString()));
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

        private async Task ident_tlsAsync(NTKUser user)
        {
            addLogs(LogsTypes.NOTICE, "Sécurisation de la connexion");
            NTKRsa rsa = new NTKRsa(user.readMsg(), false);
            Random rnd = new Random();
            // user.Cipher = new NTKAes(NTKAes.CreateKey(rnd.Next(666666)));
            await user.writeMsgAsync(rsa.encrypt(user.Cipher.getKey()));
            user.Tls = true;
        }

        public async Task<String> readMsgAsync()
        {
            String tmp = await User.readMsgAsync();
            MsgArgs argsE = new MsgArgs(tmp);
            OnReadMsg(argsE);
            addLogs(LogsTypes.NOTICE, tmp);
            return tmp;
        }

        public async Task writeMsgAsync(String msg)
        {
            MsgArgs argsE = new MsgArgs(User.Login + " : " + msg);
            OnWriteMsg(argsE);
            addLogs(LogsTypes.NOTICE, msg);
            await User.writeMsgAsync(msg);
        }

        public async Task closeConnectionAsync()
        {
            await writeMsgAsync(NTKCommands.C_STOP);
            client.Close();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// EVENTS ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void OnIdentification(IdentificationEventArgs e)
        {
            if (Identification != null)
                Identification(this, e);
        }

        protected virtual void OnGetService(GetServiceEventArgs e)
        {
            if (GetService != null)
                GetService(this, e);
        }

        protected virtual void OnReadMsg(MsgArgs e)
        {
            if (ReadMsg != null)
                ReadMsg(this, e);
        }

        protected virtual void OnWriteMsg(MsgArgs e)
        {
            if (WriteMsg != null)
                WriteMsg(this, e);
        }
        
        protected virtual void OnConnect(OnConnectEventArgs e)
        {
            if (Connect != null)
                Connect(this, e);
        }

        protected virtual void OnError(OnErrorEventArgs e)
        {
            if(Error != null)
            {
                Error(this, e);
            }
        }

        protected virtual void OnStop(StopEventArgs e)
        {
            if (Stop != null)
            {
                Stop(this, e);
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// METHODES PRIVEES /////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void addLogs(String type, String text)
        {
            if (logs != null)
            {
                logs.add(new LogLine_NTK(this,type, text, DateTime.Now));
                logs.flush();
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// GETTER ///////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public NTKUser User { get => user; set => user = value; }
        public int Port { get => port; set => port = value; }
        public string Adrs { get => adrs; set => adrs = value; }
        public string Stype { get => stype; set => stype = value; }
        public CTYPE Ctype { get => ctype; set => ctype = value; }
        public string Seckey { get => seckey; set => seckey = value; }
        public TcpClient Client { get => client; set => client = value; }
        public string Login { get => login; set => login = value; }
        public string Pass { get => pass; set => pass = value; }
        public NTKService Service { get => service; set => service = value; }
        public Log_NTK Logs { get => logs; set => logs = value; }
        public USER_LVL Lvl { get => lvl; set => lvl = value; }
    }
}