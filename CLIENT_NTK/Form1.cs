using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using NTK.EventsArgs;
using NTK;
using NTK.Other;
using NTK.Service;
using static NTK.NTKUser;
using static NTK.NTKClient;

namespace CLIENT_NTK
{
    public partial class Form1 : Form
    {
        private NTKClient client;
        private NTKS_SN service;
        private Thread clientThread;

        public Form1()
        {
            Connect co = new Connect(this);
            co.Show();
            InitializeComponent();
           
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //// Methodes Publiques ////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////



        public void start()
        {
            client.ReadMsg += new NTKClient.OnReadEventHandler(client_ReadMsg);
            client.WriteMsg += new NTKClient.OnWriteEventHandler(client_WriteMsg);
            client.GetService += new OnGetServiceEventHandler(client_getService);
            
            clientThread = new Thread(client.connect);
            clientThread.Start();
        }

        private void service_getActu(object sender, GetActuEventArgs args)
        {
            while (args.next())
            {
                writeConsole(args.getMSG(), Color.Red);
            }
        }

        private void client_getService(object sender, GetServiceEventArgs args)
        {
            //TODO: Event decl
            writeConsole("service !!", Color.Red);
            this.service = (NTKS_SN) args.get;
            this.service.getActuEvent += new NTKS_SN.OnGetActuEventHandler(service_getActu);
        }

        private void client_WriteMsg(object sender, MsgArgs args)
        {
           
            writeConsole(args.ReadText, Color.DodgerBlue);
        }
        private void client_ReadMsg(object sender, MsgArgs args)
        {
            writeConsole(args.ReadText, Color.Orange);
        }

        void writeConsole(String text, Color color)
        {

            if (rtb_Console.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                rtb_Console.Invoke(new Action<String, Color>(writeConsole), text, color);
            }
            else
            {
                rtb_Console.SelectionColor = color;
                if (!string.IsNullOrWhiteSpace(rtb_Console.Text))
                {

                    rtb_Console.AppendText("\r\n" + text);

                }
                else
                {

                    rtb_Console.AppendText(text);
                }
                rtb_Console.ScrollToCaret();
            }

        }


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //// Methodes Elements /////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void button1_Click(object sender, EventArgs e)
        {
            client.writeMsg(textBox1.Text);
            textBox1.Clear();
        }
        public NTKClient Client { get => client; set => client = value; }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
