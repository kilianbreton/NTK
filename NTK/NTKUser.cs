/**********************************
 * NTK - Netwotk Transport Kernel *
 * User Class                     *
 * 03/07/2018                     *
 **********************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NTK.Security;
using NTK.EventsArgs;
using static NTK.Other.NTKF;

namespace NTK
{
    /// <summary>
   /// Utilisateur d'un flux NTK
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
        public NTKUser(String login, TcpClient client)
        {
            this.login = login;
            this.client = client;
            this.stream = client.GetStream();
            this.streamw = new StreamWriter(stream);
            this.streamr = new StreamReader(stream);
            cipher = new NTKAes(NTKAes.CreateKey(741));
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
            try
            {
                if (Tls)
                {
                    ret = cipher.decrypt(streamr.ReadLine());
                }
                else
                {
                    ret = Streamr.ReadLine();
                }
            }
            catch (Exception e)
            {
            
            }
            MsgArgs argsE = new MsgArgs(ret);
            OnReadMsg(argsE);
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
            try
            {
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
            catch (Exception e)
            {
                Console.WriteLine(this.login + " : Disconnected");
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
        /// Réception d'un fichier
        /// </summary>
        /// <param name="path">Chemin de destination</param>
        public void reciveFile(String path)
        {
            byte[] RecData = new byte[FILE_BUFFERSIZE];
            int RecBytes;

            for (; ; )
            {
           
                try
                {    
                    
                    if (path != string.Empty)
                    {
                        int totalrecbytes = 0;
                        FileStream Fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                        while ((RecBytes = stream.Read(RecData, 0, RecData.Length)) > 0)
                        {
                            Fs.Write(RecData, 0, RecBytes);
                            totalrecbytes += RecBytes;
                        }
                        Fs.Close();
                    }
                    stream.Close();
                    client.Close();            
                }                
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //netstream.Close();
                }
            }
        }
        
        /// <summary>
        /// envoi d'un fichier
        /// </summary>
        /// <param name="path">Fichier</param>
        /// <param name="targetLogin">Cible (Utilisateur)</param>
        public void sendFile(String path,String targetLogin)
        {
            byte[] SendingBuffer = null;

            FileStream Fs = null;
          
            try
            {
                Fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(FILE_BUFFERSIZE)));

                int TotalLength = (int)Fs.Length, CurrentPacketLength;
                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > FILE_BUFFERSIZE)
                    {
                        CurrentPacketLength = FILE_BUFFERSIZE;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                    {
                        CurrentPacketLength = TotalLength;
                        SendingBuffer = new byte[CurrentPacketLength];
                        Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                        stream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                    }
                }


                Fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (Fs != null)
                {
                    Fs.Close();
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
        /// 
        /// </summary>
        public string Login { get => login; set => login = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Pass { get => pass; set => pass = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Seckey { get => seckey; set => seckey = value; }
        /// <summary>
        /// 
        /// </summary>
        public USER_LVL Lvl { get => lvl; set => lvl = value; }
        /// <summary>
        /// 
        /// </summary>
        public IEncryptor Cipher { get => cipher; set => cipher = value; }
        /// <summary>
        /// 
        /// </summary>
        public TcpClient Client { get => client; }
        /// <summary>
        /// 
        /// </summary>
        public NetworkStream Stream { get => stream; }
        /// <summary>
        /// 
        /// </summary>
        public StreamWriter Streamw { get => streamw;}
        /// <summary>
        /// 
        /// </summary>
        public StreamReader Streamr { get => streamr;}
        /// <summary>
        /// 
        /// </summary>
        public bool Tls { get => tls; set => tls = value; }
        /// <summary>
        /// 
        /// </summary>
        public int Id { get => id; set => id = value; }
    }
}
