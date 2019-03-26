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
using System.Threading;
using NTK.Other;
using NTK.EventsArgs;
using NTK.Service;
using NTK.Plugins;

namespace NTKAdmin
{
    public partial class Main : Form
    {
        private NTKClient client;
        private Thread clientThread;
        private NTKService service;
        private List<String> cmdlst = new List<String>();
        private int cmdId = 0;


        public Main()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// INITIALISATION ////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Main_Load(object sender, EventArgs e)
        {
            var uctest = new UsersControls.UCServer();
            flp_main.Controls.Add(uctest);
            this.BeginInvoke((MethodInvoker)this.launchClient);
            foreach(IBasePlugin plug in Config.pluginsList)
            {
                switch(plug.getField())
                {
                    case FieldMenu.WINDOW:

                        fenêtreToolStripMenuItem.DropDownItems.Add(plug.getName()).Click += new EventHandler(delegate (Object o, EventArgs a)                        {
                            manageStartPlug(plug);
                        });
                        break;
                    case FieldMenu.TAB:
                        ongletsToolStripMenuItem.DropDownItems.Add(plug.getName()).Click += new EventHandler(delegate (Object o, EventArgs a)
                        {
                            manageStartPlug(plug);
                        });
                        break;
                    case FieldMenu.TOOL:
                        outilsToolStripMenuItem.DropDownItems.Add(plug.getName()).Click += new EventHandler(delegate (Object o, EventArgs a)
                        {
                            manageStartPlug(plug);
                        });
                        break;
                    case FieldMenu.SETTINGS:
                        parametresToolStripMenuItem.DropDownItems.Add(plug.getName()).Click += new EventHandler(delegate (Object o, EventArgs a)
                        {
                            manageStartPlug(plug);
                        });
                        break;
                    case FieldMenu.OTHER:
                        ongletsToolStripMenuItem.DropDownItems.Add(plug.getName()).Click += new EventHandler(delegate (Object o, EventArgs a)
                        {
                            manageStartPlug(plug);
                        });
                        break;
                    case FieldMenu.NEW:
                        menuStrip1.Items.Add(plug.getName()).Click += new EventHandler(delegate (Object o, EventArgs a)
                        {
                            manageStartPlug(plug);
                        });
                        break;
                    case FieldMenu.CONTEXT:
                        ongletsToolStripMenuItem.DropDownItems.Add(plug.getName()).Click += new EventHandler(delegate (Object o, EventArgs a)
                        {
                            manageStartPlug(plug);
                        });
                        break;
                }
            }
        }

        private void manageStartPlug(IBasePlugin plug)
        {
            if (plug.getType().Equals(PluginType.FORM))
            {
                var nplug = (IPluginForm)plug;
                nplug.getStage().Show();
            }
            else
            {
                var nplug = (IPluginIntegrated)plug;
               
            }
        }

        private void launchClient()
        {
            client.Connect += new OnConnectEventHandler(client_connect);
            client.GetService += new OnGetServiceEventHandler(client_getservice);
            client.Identification += new OnIdentificationEventHandler(client_ident);
            client.Error += new OnErrorEventHandler(client_error);
            client.Stop += new OnStopEventHandler(client_stop);
            client.Logs = Log_NTK.getInstance(@"Logs\NTKClient.log");
            clientThread = new Thread(client.connect);
            clientThread.Start();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// CLIENT EVENT //////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void client_stop(object sender, StopEventArgs e)
        {
         /*   AlertBox ab = new AlertBox("Information", "Le serveur va se déconnecter [CODE : " + e.Code +"] : " + NTKF.getStopInfo(e.Code), FlatUITheme.FlatAlertBox._Kind.Info);
            ab.Show();*/
        }

        //-----------------------ACTIONS APRES ERREUR DANS CLIENT---------------------------------------
        private void client_error(Object sender,OnErrorEventArgs e)
        {
          /*  AlertBox ab = new AlertBox("Erreur", e.Text, FlatUITheme.FlatAlertBox._Kind.Error);
            ab.Show();*/
        }

        //-----------------------ACTIONS APRES AUTHENTIFICATION---------------------------------------
        private async void client_ident(object sender, IdentificationEventArgs args)
        {
            await client.User.writeMsgAsync("GET USERS;");
        }

        //------------------------ACTIONS APRES INITIALISATION DU SERVICE--------------------------
        private void client_getservice(object sender, GetServiceEventArgs args)
        {
            client.Service.getUserEvent += new OnGetUserEventHandler(service_getUserList);
            client.Service.getGrpEvent += new OnGetGrpEventHandler(service_getGrpList);
            client.Service.getActuEvent += new OnGetActuEventHandler(service_getActu);
            client.Service.getMsgEvent += new OnGetMsgEventHandler(service_getMsg);
           
        }

        //-------------------------ACTIONS APRES CONNEXION----------------------------------------
        private void client_connect(object sender, OnConnectEventArgs args)
        {
            client.User.WriteMsg += new OnWriteEventHandler(client_WriteMsg);
            client.User.ReadMsg += new OnReadEventHandler(client_ReadMsg);
        }

        //--------------------------ECRITURE------------------------------------------------------
        private void client_WriteMsg(object sender, MsgArgs args)
        {

            writeConsole(args.ReadText, Color.DodgerBlue);
        }
        //--------------------------LECTURE-------------------------------------------------------
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
            int id = 1;
            while (e.next())
            {
                dgw_users.Rows.Add(id++, e.getLogin(), e.getLVL(), e.getMail(), e.getPicid());
            }
        }
        
        //-------------------------GET GRPS------------------------------------------------------
        private void service_getGrpList(object sender, GetGrpEventArgs e)
        {

        }

        //-------------------------GET MSGS------------------------------------------------------
        private void service_getMsg(object sender, GetMsgEventArgs e)
        {

        }

        //-------------------------GET ACTU------------------------------------------------------
        private void service_getActu(object sender, GetActuEventArgs args)
        {
            while (args.next())
            {
                writeConsole(args.getMSG(), Color.Red);
            }
        }





        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// CONTROLS EVENT ////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //TODO : Ajouter évènement touche clavier
        //////   pour écupération des cmd précédentes  
       
       

        private void button1_Click(object sender, EventArgs e)
        {
            sendMsg();
        }

        private void b_console_Click(object sender, EventArgs e)
        {
            sendMsg();
        }

        private void fenêtreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void flatMax1_Click(object sender, EventArgs e)
        {

        }

        private void formSkin1_Click(object sender, EventArgs e)
        {

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

        private void sendMsg()
        {
            client.User.writeMsg(flatTextBox1.Text);
            cmdlst.Add(flatTextBox1.Text);
            cmdId = cmdlst.Count;
            flatTextBox1.Text = "";
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// GETTERS & SETTERS ///////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public NTKClient Client { get => client; set => client = value; }

        private void fichierToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\";
            var res = ofd.ShowDialog();
            if(res ==DialogResult.OK)
            {
                //  client.writeMsg("SEND>abcd{,}"+NTKF.subsep(ofd.FileName,".")+"{,}none{;}");
                // client.User.sendFile(ofd.FileName);
                client.User.sendFile(ofd.FileName);
            }
        }
    }
}
