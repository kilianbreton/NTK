using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTK.Other;
using NTK.IO.Xml;
using NTK;
using NTK.Plugins;
using System.Diagnostics;
using NTK.Service;

namespace NTKAdmin
{
    public partial class ConOrLaunch : Form
    {
        public ConOrLaunch()
        {
            InitializeComponent();
            foreach(Network net in Config.netList)
            {
                listBox1.Items.Add(net.Name);
            }
            foreach(NTKService serv in Config.servicesList)
            {
                flatListBox2.AddItem("Sevice : "+serv.Config.name);
                cb_service.Items.Add(serv.Config.name);
            }
            foreach (IBasePlugin plug in Config.pluginsList)
            {
                flatListBox2.AddItem("Plugins : " + plug.getName());
            }
            switch (Config.startType.ToUpper())
            {
                case "LIST":
                    flatTabControl1.SelectedIndex = 1;
                    break;
                case "CONNECT":
                    flatTabControl1.SelectedIndex = 0;
                    break;
                case "PLUGINS":
                    flatTabControl1.SelectedIndex = 2;
                    break;
                default:
                    int id;
                    if (int.TryParse(Config.startType, out id))
                    {
                        --id;
                        XmlNode root = Config.netList[id].ClientCfg.getNode(0);
                        if (!Config.netList[id].Remote)
                        {
                            ProcessStartInfo notepadStartInfo = new ProcessStartInfo(@"Servers\" + Config.netList[id].Name + @"\NTKU.exe");
                            notepadStartInfo.Arguments = @"-c Config\" + Config.netList[id].Name + @"\server.xml";
                            Process notepad = Process.Start(notepadStartInfo);

                        }
                        var main = new Main();
                        main.Client = new NTKClient(root.getChildV("adrs"),
                            int.Parse(root.getChildV("port")),
                            root.getChildV("login"),
                            root.getChildV("pass"),
                            root.getChildV("seckey"));
                        main.Show();
                        this.Hide();
                    }
                    break;
            }

            foreach(CTYPE elem in (CTYPE[])Enum.GetValues(typeof(CTYPE)))
            {
                cb_ctype.Items.Add(elem.ToString());
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void formSkin1_Click(object sender, EventArgs e)
        {

        }

        private void flatLabel6_Click(object sender, EventArgs e)
        {

        }

        private void flatCheckBox1_CheckedChanged(object sender)
        {
            
            cb_ctype.Enabled = cb_local.Checked;
            cb_service.Enabled = cb_local.Checked;
            cb_db.Enabled = cb_local.Checked;
            tb_db_ip.Enabled = cb_local.Checked;
            tb_db_login.Enabled = cb_local.Checked;
            tb_db_pass.Enabled = cb_local.Checked;
            tb_base.Enabled = cb_local.Checked;
            cb_tls.Enabled = cb_local.Checked;
            
        }

        private void flatComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void clearDemForm()
        {
            tb_nom.Text = "";
            tb_dem_ip.Text = "";
            tb_dem_port.Text = "";
            tb_dem_login.Text = "";
            tb_dem_mdp.Text = "";
            tb_dem_key.Text = "";
            cb_local.Checked = false;
            cb_ctype.Enabled = false;
            cb_service.Enabled = false;
            cb_db.Enabled = false;
            tb_db_ip.Enabled = false;
            tb_db_login.Enabled = false;
            tb_db_pass.Enabled = false;
            tb_base.Enabled = false;
            cb_tls.Enabled = false;
            cb_ctype.SelectedValue = "";
            cb_ctype.Text = "";
            cb_service.SelectedValue = "";
            cb_service.Text = "";
            cb_db.SelectedValue = "";
            cb_db.Text = "";
            tb_db_ip.Text = "";
            tb_db_login.Text = "";
            tb_db_pass.Text = "";
            tb_base.Text = "";
            cb_tls.Checked = false;
        }
       
        private void listBox1_Click(object sender, MouseEventArgs e)
        {
        //    MessageBox.Show("fd");
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearDemForm();
            var selectedNet = listBox1.SelectedItem;
            bool end = false;
            int cpt = 0;
            while (!end && selectedNet != null)
            {
                if (selectedNet.Equals(Config.netList[cpt].Name))
                {
                    XmlNode root = Config.netList[cpt].ClientCfg.getNode(0);
                    tb_nom.Text = root.getChildV("name");
                    tb_dem_ip.Text = root.getChildV("adrs");
                    tb_dem_port.Text = root.getChildV("port");
                    tb_dem_login.Text = root.getChildV("login");
                    tb_dem_mdp.Text = root.getChildV("pass");
                    tb_dem_key.Text = root.getChildV("seckey");
                    if (!Config.netList[cpt].Remote)
                    {
                        cb_local.Checked = true;
                        
                        cb_ctype.Enabled = true;
                        cb_service.Enabled = true;
                        cb_db.Enabled = true;
                        tb_db_ip.Enabled = true;
                        tb_db_login.Enabled = true;
                        tb_db_pass.Enabled = true;
                        tb_base.Enabled = true;
                        cb_tls.Enabled = true;

                        root = Config.netList[cpt].ServerCfg.getNode(0);

                        cb_tls.Checked = (root.getChildV("tls").ToUpper().Equals("TRUE"));
                        cb_ctype.SelectedValue = root.getChildV("ctype");
                        cb_ctype.Text= root.getChildV("ctype");

                        cb_service.SelectedValue = root.getChild("service").getAttibuteV("name");
                        cb_service.Text = root.getChild("service").getAttibuteV("name");

                        cb_db.SelectedValue = root.getChild("database").getChildV("type");
                        cb_db.Text = root.getChild("database").getChildV("type");


                        tb_db_ip.Text = root.getChild("database").getChildV("host");
                        tb_db_login.Text = root.getChild("database").getChildV("user");
                        tb_db_pass.Text = root.getChild("database").getChildV("pass");
                        tb_base.Text = root.getChild("database").getChildV("name");

                    }
                    end = true;
                }
                else if (cpt == Config.netList.Count-1) { end = true; }
                else { cpt++; }

            }
        }

        private void flatButton4_Click(object sender, EventArgs e)
        {
            var ab = new AlertBox();
            ab.Show();
        }
       
        //Bouton démarrer
        private void flatButton7_Click(object sender, EventArgs e)
        {
            XmlNode root = Config.netList[listBox1.SelectedIndex].ClientCfg.getNode(0);
            if (!Config.netList[listBox1.SelectedIndex].Remote)
            {
                ProcessStartInfo notepadStartInfo = new ProcessStartInfo(@"Servers\" + listBox1.Text + @"\NTKU.exe");
                notepadStartInfo.Arguments = @"-c Config\" + listBox1.Text + @"\server.xml";
                Process notepad = Process.Start(notepadStartInfo);

            }

            var main = new Main();
            main.Client = new NTKClient(root.getChildV("adrs"),
                int.Parse(root.getChildV("port")),
                root.getChildV("login"), 
                root.getChildV("pass"),
                root.getChildV("seckey"));
            main.Show();
        }
    }
}
