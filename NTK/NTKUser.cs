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
   
    public class NTKUser
    {
        public delegate void OnReadEventHandler(object sender, MsgArgs args);
        public delegate void OnWriteEventHandler(object sender, MsgArgs args);
        public event OnReadEventHandler ReadMsg;
        public event OnWriteEventHandler WriteMsg;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ATTRIBUTS ////////////////////////////////////////////////////////////////////////////////////////////////////////////
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
        /// CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public NTKUser(String login, TcpClient client)
        {
            this.login = login;
            this.client = client;
            this.stream = client.GetStream();
            this.streamw = new StreamWriter(stream);
            this.streamr = new StreamReader(stream);
            cipher = new NTKAes(NTKAes.CreateKey(741));
        }

        public NTKUser(String login)
        {
            this.login = login;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS & SETTERS /////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public string Login { get => login; set => login = value; }
        public string Name { get => name; set => name = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Seckey { get => seckey; set => seckey = value; }
        public USER_LVL Lvl { get => lvl; set => lvl = value; }
        public IEncryptor Cipher { get => cipher; set => cipher = value; }
        public TcpClient Client { get => client; }
        public NetworkStream Stream { get => stream; }
        public StreamWriter Streamw { get => streamw;}
        public StreamReader Streamr { get => streamr;}
        public bool Tls { get => tls; set => tls = value; }
        public int Id { get => id; set => id = value; }
    }
}
