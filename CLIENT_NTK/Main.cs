using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTK;
using NTK.Other;
using NTK.Service;
using NTK.IO;
using System.Threading;
using NTK.EventsArgs;
using CLIENT_NTK.UserControls;

namespace CLIENT_NTK
{
    public partial class Main : Form
    {
        private NTKClient client;
        private NTKService service;
        private Thread clientThread;

        public Main()
        {
            InitializeComponent();
            flp_news.Controls.Add(new News_UC("test",""));
            flp_users.Controls.Add(new User_UC("test"));
           
        }

        public void connect(string ip,int port,string login,string pass)
        {
            client = new NTKClient(ip, port, login, pass);
            client.Lvl = USER_LVL.USER;
            client.Connect += new OnConnectEventHandler(client_connect);
            client.GetService += new OnGetServiceEventHandler(client_getservice);
            //  client.Identification += new NTKClient.OnIdentificationEventHandler(client_ident);

            clientThread = new Thread(client.connect);
            clientThread.Start();
        }


        //-------------------------ACTIONS APRES CONNEXION----------------------------------------
        private void client_connect(object sender, OnConnectEventArgs args)
        {
            client.User.WriteMsg += new OnWriteEventHandler(client_WriteMsg);
            client.User.ReadMsg += new OnReadEventHandler(client_ReadMsg);
        }

        //------------------------ACTIONS APRES INITIALISATION DU SERVICE--------------------------
        private void client_getservice(object sender, GetServiceEventArgs args)
        {
            client.Service.getUserEvent += new OnGetUserEventHandler(service_getUserList);
            client.Service.getActuEvent += new OnGetActuEventHandler(service_getActu);
            /* client.Service.getGrpEvent += new NTKService.OnGetGrpEventHandler(service_getGrpList);
             client.Service.getMsgEvent += new NTKService.OnGetMsgEventHandler(service_getMsg);
 */
        }

        private void client_WriteMsg(object sender, MsgArgs args)
        {

            writeConsole(args.ReadText, Color.DodgerBlue);
        }
        private void client_ReadMsg(object sender, MsgArgs args)
        {
            writeConsole(args.ReadText, Color.Orange);
        }

        private void service_getActu(object sender, GetActuEventArgs args)
        {
            if (flp_users.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                rt_console.Invoke(new Action<Object, GetActuEventArgs>(service_getActu), sender, args);
            }
            else
            {
                while (args.next())
                {
                    flp_news.Controls.Add(new News_UC(args.getWriterUser() +" : " +args.getTitle(), args.getMSG()));
                }
            }
        }

        private void service_getUserList(object sender, GetUserEventArgs e)
        {
            if (flp_users.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                rt_console.Invoke(new Action<Object, GetUserEventArgs>(service_getUserList), sender, e);
            }
            else
            {
                while (e.next())
                {
                    flp_users.Controls.Add(new User_UC(e.getUserName()));
                }
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Methodes Privées ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void writeConsole(String text, Color color)
        {

            if (rt_console.InvokeRequired) //Permet de revenir au Thread de gestion des composants UI
            {
                rt_console.Invoke(new Action<String, Color>(writeConsole), text, color);
            }
            else
            {
                rt_console.SelectionColor = color;
                if (!string.IsNullOrWhiteSpace(rt_console.Text))
                {

                    rt_console.AppendText("\r\n" + text);

                }
                else
                {

                    rt_console.AppendText(text);
                }
                rt_console.ScrollToCaret();
            }

        }

        private void formSkin1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            client.writeMsg(textBox1.Text);
            textBox1.Clear();
        }
    }
}
