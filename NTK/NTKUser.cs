using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NTK.Security;
using NTK.EventsArgs;
using System.Threading;
using static NTK.Other.NTKF;
using static NTK.Separators;

namespace NTK
{
    /// <summary>
    /// Utilisateur NTK
    /// </summary>
    public class NTKUser
    {
        /// <summary>
        /// 
        /// </summary>
        public event OnReadEventHandler ReadMsg;
        /// <summary>
        /// 
        /// </summary>
        public event OnWriteEventHandler WriteMsg;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ATTRIBUTS ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private int id = 0;
        private String login;
        private String name;
        private String pass;
        private String seckey;
        private USER_LVL lvl;
        private IEncryptor cipher;
        private TcpClient client;
        private NetworkStream stream;
        private StreamWriter streamw;
        private StreamReader streamr;
        private Boolean tls = false;
        private Boolean isBad = false;
      
        //Constantes
        private const int FILE_BUFFERSIZE = 1024;
        private const int MSG_BUFFERSIZE = 64;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
        /// <summary>
        /// Créé un utilisateur connecté
        /// </summary>
        /// <param name="login"></param>
        /// <param name="client"></param>
        /// <param name="cipher"></param>
        public NTKUser(String login, TcpClient client, IEncryptor cipher = null)
        {
            this.login = login;
            this.client = client;
            this.stream = client.GetStream();
            this.streamw = new StreamWriter(stream);
            this.streamr = new StreamReader(stream);
            if (cipher == null)
                cipher = new NTKAes();
            this.cipher = cipher;
        }
        
        /// <summary>
        /// Créé un utilisateur en attente
        /// </summary>
        /// <param name="login"></param>
        public NTKUser(String login)
        {
            this.login = login;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        /// <summary>
        /// Lecture d'un message
        /// </summary>
        /// <returns></returns>
        public String readMsg()
        {
            String ret = "";
           
            if (Tls)
            {
                ret = cipher.decrypt(streamr.ReadLine());
            }
            else
            { 
                ret = Streamr.ReadLine();
            }
          
            OnReadMsg(new MsgArgs(ret));
            Console.WriteLine(this.login + " : " +ret);

            return ret;
        }

        /// <summary>
        /// Ecriture d'un message
        /// </summary>
        /// <param name="text">Message</param>
        public void writeMsg(String text)
        {
            MsgArgs argsE = new MsgArgs(this.login +" : "+ text);
            OnWriteMsg(argsE);
         
            Console.WriteLine(text);
            if (Tls)
            {
                Streamw.WriteLine(cipher.encrypt(text));
                Streamw.Flush();            
            }
            else
            {
                Streamw.WriteLine(text);
                Streamw.Flush();
            }         
        }

        /// <summary>
        /// envoi d'un fichier
        /// </summary>
        /// <param name="path">Fichier</param>
        public void sendFile(String path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                long fileSize = fs.Length;
                long sum = 0;   //sum here is the total of sent bytes.
                int count = 0;

                String msg = "SEND>" + fileSize + SV + fs.GetHashCode() + SV + subsep(path, ".") + SV + "none" + SPV;
                this.writeMsg(msg);

                byte[] data = new byte[1024];  //8Kb buffer .. you might use a smaller size also.
                while (sum < fileSize)
                {
                    count = fs.Read(data, 0, data.Length);
                    stream.Write(data, 0, count);
                    sum += count;
                }
                stream.Flush();
            }
        }

        /// <summary>
        /// Réception d'un fichier
        /// </summary>
        /// <param name="path">Chemin de destination</param>
        /// <param name="fileSize"></param>
        public void reciveFile(String path, long fileSize)
        {
            //long fileSize = // your file size that you are going to receive it.
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                int count = 0;
                long sum = 0;   //sum here is the total of received bytes.
                var data = new byte[1024 * 8];  //8Kb buffer .. you might use a smaller size also.
                while (sum < fileSize)
                {
                    if (stream.DataAvailable)
                    {
                        {
                            count = stream.Read(data, 0, data.Length);
                            fs.Write(data, 0, count);
                            sum += count;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Lecture d'un message
        /// </summary>
        /// <returns></returns>
        public async Task<String> readMsgAsync()
        {
            String ret = "";
            try
            {
                if (Tls)
                {
                    ret = await streamr.ReadLineAsync();
                    ret = cipher.decrypt(ret);
                }
                else
                {
                    ret = await Streamr.ReadLineAsync();
                }
            }
            catch (Exception e)
            {

            }
            MsgArgs argsE = new MsgArgs(ret);
            OnReadMsg(argsE);
            Console.WriteLine(this.login + " : " + ret);
            return ret;
        }
      
        /// <summary>
        /// Ecriture d'un message
        /// </summary>
        /// <param name="text">Message</param>
        /// <returns></returns>
        public async Task writeMsgAsync(String text)
        {
            MsgArgs argsE = new MsgArgs(this.login + " : " + text);
            OnWriteMsg(argsE);
            try
            {
                Console.WriteLine(text);
                if (Tls)
                {
                    await Streamw.WriteLineAsync(cipher.encrypt(text));
                    await Streamw.FlushAsync();
                }
                else
                {
                    await Streamw.WriteLineAsync(text);
                    await Streamw.FlushAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(this.login + " : Disconnected");
            }
        }
        
        
        /// <summary>
        /// envoi d'un fichier
        /// </summary>
        /// <param name="path">Fichier</param>
        public async Task sendFileAsync(String path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                long fileSize = fs.Length;
                long sum = 0;   //sum here is the total of sent bytes.
                int count = 0;
                
                String msg = "SEND>" + fileSize + SV + fs.GetHashCode() + SV + subsep(path,".") + SV + "none" + SPV;
                this.writeMsg(msg);

                byte[] data = new byte[1024];  //8Kb buffer .. you might use a smaller size also.
                while (sum < fileSize)
                {
                    count = await fs.ReadAsync(data, 0, data.Length);
                    await stream.WriteAsync(data, 0, count);
                    sum += count;
                }
                await stream.FlushAsync();
            }
        }

        /// <summary>
        /// Réception d'un fichier
        /// </summary>
        /// <param name="path">Chemin de destination</param>
        /// <param name="fileSize"></param>
        public async Task reciveFileAsync(String path, long fileSize)
        {
            //long fileSize = // your file size that you are going to receive it.
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                int count = 0;
                long sum = 0;   //sum here is the total of received bytes.
                var data = new byte[1024 * 8];  //8Kb buffer .. you might use a smaller size also.
                while (sum < fileSize)
                {
                    if (stream.DataAvailable)
                    {
                        {
                            count = await stream.ReadAsync(data, 0, data.Length);
                            await fs.WriteAsync(data, 0, count);
                            sum += count;
                        }
                    }
                }
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // EVENTS ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       
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


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS & SETTERS /////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Identifiant
        /// </summary>
        public string Login { get => login; set => login = value; }
        /// <summary>
        /// Nom
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Mot de passe
        /// </summary>
        public string Pass { get => pass; set => pass = value; }
        /// <summary>
        /// Clé de sécurité (si admin)
        /// </summary>
        public string Seckey { get => seckey; set => seckey = value; }
        /// <summary>
        /// Niveau utilisateur (USER_LVL)
        /// </summary>
        public USER_LVL Lvl { get => lvl; set => lvl = value; }
        /// <summary>
        /// Algorithme de chiffrement
        /// </summary>
        public IEncryptor Cipher { get => cipher; set => cipher = value; }
        /// <summary>
        /// Client TCP/IP
        /// </summary>
        public TcpClient Client { get => client; }
        /// <summary>
        /// Flux TCP
        /// </summary>
        public NetworkStream Stream { get => stream; }
        /// <summary>
        /// Ecriture dans le flux
        /// </summary>
        public StreamWriter Streamw { get => streamw;}
        /// <summary>
        /// Lecture dans le flux
        /// </summary>
        public StreamReader Streamr { get => streamr;}
        /// <summary>
        /// Protocole criptographique
        /// </summary>
        public bool Tls { get => tls; set => tls = value; }
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Si l'authentification a échoué ou si déconnexion forcée
        /// </summary>
        public bool IsBad { get => isBad; set => isBad = value; }
    }
}
