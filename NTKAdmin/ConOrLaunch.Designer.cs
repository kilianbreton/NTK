using System.Windows.Forms;

namespace NTKAdmin
{
    partial class ConOrLaunch
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cms_serverList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajouterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lancerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formSkin1 = new FlatUITheme.FormSkin();
            this.flatTabControl1 = new FlatUITheme.FlatTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flatTextBox1 = new FlatUITheme.FlatTextBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.flatButton3 = new FlatUITheme.FlatButton();
            this.flatButton2 = new FlatUITheme.FlatButton();
            this.flatButton1 = new FlatUITheme.FlatButton();
            this.tb_port = new FlatUITheme.FlatTextBox();
            this.tb_seckey = new FlatUITheme.FlatTextBox();
            this.tb_pass = new FlatUITheme.FlatTextBox();
            this.tb_login = new FlatUITheme.FlatTextBox();
            this.tb_ip = new FlatUITheme.FlatTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tb_db_pass = new FlatUITheme.FlatTextBox();
            this.flatButton5 = new FlatUITheme.FlatButton();
            this.flatButton4 = new FlatUITheme.FlatButton();
            this.flatLabel10 = new FlatUITheme.FlatLabel();
            this.flatLabel2 = new FlatUITheme.FlatLabel();
            this.tb_base = new FlatUITheme.FlatTextBox();
            this.tb_db_login = new FlatUITheme.FlatTextBox();
            this.tb_db_ip = new FlatUITheme.FlatTextBox();
            this.flatLabel9 = new FlatUITheme.FlatLabel();
            this.cb_db = new FlatUITheme.FlatComboBox();
            this.cb_service = new FlatUITheme.FlatComboBox();
            this.cb_ctype = new FlatUITheme.FlatComboBox();
            this.flatLabel8 = new FlatUITheme.FlatLabel();
            this.flatLabel7 = new FlatUITheme.FlatLabel();
            this.cb_tls = new FlatUITheme.FlatCheckBox();
            this.flatLabel1 = new FlatUITheme.FlatLabel();
            this.cb_local = new FlatUITheme.FlatCheckBox();
            this.flatLabel6 = new FlatUITheme.FlatLabel();
            this.tb_dem_key = new FlatUITheme.FlatTextBox();
            this.tb_dem_mdp = new FlatUITheme.FlatTextBox();
            this.tb_dem_login = new FlatUITheme.FlatTextBox();
            this.flatLabel5 = new FlatUITheme.FlatLabel();
            this.flatLabel4 = new FlatUITheme.FlatLabel();
            this.flatLabel3 = new FlatUITheme.FlatLabel();
            this.tb_dem_port = new FlatUITheme.FlatTextBox();
            this.tb_dem_ip = new FlatUITheme.FlatTextBox();
            this.tb_nom = new FlatUITheme.FlatTextBox();
            this.flatButton7 = new FlatUITheme.FlatButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.flatListBox2 = new FlatUITheme.FlatListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ajouterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.afficherConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_serverList.SuspendLayout();
            this.formSkin1.SuspendLayout();
            this.flatTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cms_serverList
            // 
            this.cms_serverList.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_serverList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem,
            this.editerToolStripMenuItem,
            this.supprimerToolStripMenuItem,
            this.lancerToolStripMenuItem});
            this.cms_serverList.Name = "cms_serverList";
            this.cms_serverList.Size = new System.Drawing.Size(148, 100);
            // 
            // ajouterToolStripMenuItem
            // 
            this.ajouterToolStripMenuItem.Name = "ajouterToolStripMenuItem";
            this.ajouterToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.ajouterToolStripMenuItem.Text = "Ajouter";
            // 
            // editerToolStripMenuItem
            // 
            this.editerToolStripMenuItem.Name = "editerToolStripMenuItem";
            this.editerToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.editerToolStripMenuItem.Text = "Editer";
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            // 
            // lancerToolStripMenuItem
            // 
            this.lancerToolStripMenuItem.Name = "lancerToolStripMenuItem";
            this.lancerToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.lancerToolStripMenuItem.Text = "Lancer";
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.flatTabControl1);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(741, 615);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "NTK Admin | Démarrer";
            this.formSkin1.Click += new System.EventHandler(this.formSkin1_Click);
            // 
            // flatTabControl1
            // 
            this.flatTabControl1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatTabControl1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatTabControl1.Controls.Add(this.tabPage1);
            this.flatTabControl1.Controls.Add(this.tabPage2);
            this.flatTabControl1.Controls.Add(this.tabPage3);
            this.flatTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatTabControl1.ItemSize = new System.Drawing.Size(120, 40);
            this.flatTabControl1.Location = new System.Drawing.Point(0, 48);
            this.flatTabControl1.Name = "flatTabControl1";
            this.flatTabControl1.SelectedIndex = 0;
            this.flatTabControl1.Size = new System.Drawing.Size(741, 567);
            this.flatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.flatTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage1.Controls.Add(this.flatTextBox1);
            this.tabPage1.Controls.Add(this.listBox2);
            this.tabPage1.Controls.Add(this.flatButton3);
            this.tabPage1.Controls.Add(this.flatButton2);
            this.tabPage1.Controls.Add(this.flatButton1);
            this.tabPage1.Controls.Add(this.tb_port);
            this.tabPage1.Controls.Add(this.tb_seckey);
            this.tabPage1.Controls.Add(this.tb_pass);
            this.tabPage1.Controls.Add(this.tb_login);
            this.tabPage1.Controls.Add(this.tb_ip);
            this.tabPage1.Location = new System.Drawing.Point(4, 44);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(733, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Connexion";
            // 
            // flatTextBox1
            // 
            this.flatTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.flatTextBox1.Location = new System.Drawing.Point(13, 404);
            this.flatTextBox1.MaxLength = 32767;
            this.flatTextBox1.Multiline = false;
            this.flatTextBox1.Name = "flatTextBox1";
            this.flatTextBox1.ReadOnly = false;
            this.flatTextBox1.Size = new System.Drawing.Size(443, 34);
            this.flatTextBox1.TabIndex = 39;
            this.flatTextBox1.Text = "Z5HX55T1IG";
            this.flatTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.flatTextBox1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.flatTextBox1.UseSystemPasswordChar = false;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.listBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox2.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 23;
            this.listBox2.Location = new System.Drawing.Point(488, -4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(242, 529);
            this.listBox2.TabIndex = 38;
            // 
            // flatButton3
            // 
            this.flatButton3.BackColor = System.Drawing.Color.Transparent;
            this.flatButton3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton3.Location = new System.Drawing.Point(464, -4);
            this.flatButton3.Name = "flatButton3";
            this.flatButton3.Rounded = false;
            this.flatButton3.Size = new System.Drawing.Size(22, 24);
            this.flatButton3.TabIndex = 8;
            this.flatButton3.Text = "+";
            this.flatButton3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.Transparent;
            this.flatButton2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.flatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton2.Location = new System.Drawing.Point(13, 459);
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Rounded = false;
            this.flatButton2.Size = new System.Drawing.Size(443, 42);
            this.flatButton2.TabIndex = 7;
            this.flatButton2.Text = "Token";
            this.flatButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.Transparent;
            this.flatButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton1.Location = new System.Drawing.Point(13, 286);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Rounded = false;
            this.flatButton1.Size = new System.Drawing.Size(443, 42);
            this.flatButton1.TabIndex = 6;
            this.flatButton1.Text = "Connexion";
            this.flatButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // tb_port
            // 
            this.tb_port.BackColor = System.Drawing.Color.Transparent;
            this.tb_port.Location = new System.Drawing.Point(372, 31);
            this.tb_port.MaxLength = 32767;
            this.tb_port.Multiline = false;
            this.tb_port.Name = "tb_port";
            this.tb_port.ReadOnly = false;
            this.tb_port.Size = new System.Drawing.Size(84, 34);
            this.tb_port.TabIndex = 4;
            this.tb_port.Text = "1141";
            this.tb_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_port.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_port.UseSystemPasswordChar = false;
            // 
            // tb_seckey
            // 
            this.tb_seckey.BackColor = System.Drawing.Color.Transparent;
            this.tb_seckey.Location = new System.Drawing.Point(13, 229);
            this.tb_seckey.MaxLength = 32767;
            this.tb_seckey.Multiline = false;
            this.tb_seckey.Name = "tb_seckey";
            this.tb_seckey.ReadOnly = false;
            this.tb_seckey.Size = new System.Drawing.Size(443, 34);
            this.tb_seckey.TabIndex = 3;
            this.tb_seckey.Text = "Z5HX55T1IG";
            this.tb_seckey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_seckey.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_seckey.UseSystemPasswordChar = false;
            // 
            // tb_pass
            // 
            this.tb_pass.BackColor = System.Drawing.Color.Transparent;
            this.tb_pass.Location = new System.Drawing.Point(13, 166);
            this.tb_pass.MaxLength = 32767;
            this.tb_pass.Multiline = false;
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.ReadOnly = false;
            this.tb_pass.Size = new System.Drawing.Size(443, 34);
            this.tb_pass.TabIndex = 2;
            this.tb_pass.Text = "1234";
            this.tb_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_pass.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_pass.UseSystemPasswordChar = true;
            // 
            // tb_login
            // 
            this.tb_login.BackColor = System.Drawing.Color.Transparent;
            this.tb_login.Location = new System.Drawing.Point(13, 99);
            this.tb_login.MaxLength = 32767;
            this.tb_login.Multiline = false;
            this.tb_login.Name = "tb_login";
            this.tb_login.ReadOnly = false;
            this.tb_login.Size = new System.Drawing.Size(443, 34);
            this.tb_login.TabIndex = 1;
            this.tb_login.Text = "Kilian";
            this.tb_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_login.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_login.UseSystemPasswordChar = false;
            // 
            // tb_ip
            // 
            this.tb_ip.BackColor = System.Drawing.Color.Transparent;
            this.tb_ip.Location = new System.Drawing.Point(13, 31);
            this.tb_ip.MaxLength = 32767;
            this.tb_ip.Multiline = false;
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.ReadOnly = false;
            this.tb_ip.Size = new System.Drawing.Size(353, 34);
            this.tb_ip.TabIndex = 0;
            this.tb_ip.Text = "127.0.0.1";
            this.tb_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_ip.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_ip.UseSystemPasswordChar = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.tb_db_pass);
            this.tabPage2.Controls.Add(this.flatButton5);
            this.tabPage2.Controls.Add(this.flatButton4);
            this.tabPage2.Controls.Add(this.flatLabel10);
            this.tabPage2.Controls.Add(this.flatLabel2);
            this.tabPage2.Controls.Add(this.tb_base);
            this.tabPage2.Controls.Add(this.tb_db_login);
            this.tabPage2.Controls.Add(this.tb_db_ip);
            this.tabPage2.Controls.Add(this.flatLabel9);
            this.tabPage2.Controls.Add(this.cb_db);
            this.tabPage2.Controls.Add(this.cb_service);
            this.tabPage2.Controls.Add(this.cb_ctype);
            this.tabPage2.Controls.Add(this.flatLabel8);
            this.tabPage2.Controls.Add(this.flatLabel7);
            this.tabPage2.Controls.Add(this.cb_tls);
            this.tabPage2.Controls.Add(this.flatLabel1);
            this.tabPage2.Controls.Add(this.cb_local);
            this.tabPage2.Controls.Add(this.flatLabel6);
            this.tabPage2.Controls.Add(this.tb_dem_key);
            this.tabPage2.Controls.Add(this.tb_dem_mdp);
            this.tabPage2.Controls.Add(this.tb_dem_login);
            this.tabPage2.Controls.Add(this.flatLabel5);
            this.tabPage2.Controls.Add(this.flatLabel4);
            this.tabPage2.Controls.Add(this.flatLabel3);
            this.tabPage2.Controls.Add(this.tb_dem_port);
            this.tabPage2.Controls.Add(this.tb_dem_ip);
            this.tabPage2.Controls.Add(this.tb_nom);
            this.tabPage2.Controls.Add(this.flatButton7);
            this.tabPage2.Location = new System.Drawing.Point(4, 44);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(733, 519);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Démarrer";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.ForeColor = System.Drawing.SystemColors.InactiveBorder;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(0, -1);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(169, 529);
            this.listBox1.TabIndex = 37;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_Click);
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // tb_db_pass
            // 
            this.tb_db_pass.BackColor = System.Drawing.Color.Transparent;
            this.tb_db_pass.Enabled = false;
            this.tb_db_pass.Location = new System.Drawing.Point(519, 368);
            this.tb_db_pass.MaxLength = 32767;
            this.tb_db_pass.Multiline = false;
            this.tb_db_pass.Name = "tb_db_pass";
            this.tb_db_pass.ReadOnly = false;
            this.tb_db_pass.Size = new System.Drawing.Size(206, 34);
            this.tb_db_pass.TabIndex = 36;
            this.tb_db_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_db_pass.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_db_pass.UseSystemPasswordChar = true;
            // 
            // flatButton5
            // 
            this.flatButton5.BackColor = System.Drawing.Color.Transparent;
            this.flatButton5.BaseColor = System.Drawing.SystemColors.MenuHighlight;
            this.flatButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton5.Location = new System.Drawing.Point(487, 470);
            this.flatButton5.Name = "flatButton5";
            this.flatButton5.Rounded = false;
            this.flatButton5.Size = new System.Drawing.Size(120, 32);
            this.flatButton5.TabIndex = 35;
            this.flatButton5.Text = "Enregistrer";
            this.flatButton5.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // flatButton4
            // 
            this.flatButton4.BackColor = System.Drawing.Color.Transparent;
            this.flatButton4.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flatButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton4.Location = new System.Drawing.Point(370, 470);
            this.flatButton4.Name = "flatButton4";
            this.flatButton4.Rounded = false;
            this.flatButton4.Size = new System.Drawing.Size(120, 32);
            this.flatButton4.TabIndex = 34;
            this.flatButton4.Text = "Supprimer";
            this.flatButton4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton4.Click += new System.EventHandler(this.flatButton4_Click);
            // 
            // flatLabel10
            // 
            this.flatLabel10.AutoSize = true;
            this.flatLabel10.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel10.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel10.ForeColor = System.Drawing.Color.White;
            this.flatLabel10.Location = new System.Drawing.Point(180, 419);
            this.flatLabel10.Name = "flatLabel10";
            this.flatLabel10.Size = new System.Drawing.Size(54, 23);
            this.flatLabel10.TabIndex = 33;
            this.flatLabel10.Text = "Base :";
            // 
            // flatLabel2
            // 
            this.flatLabel2.AutoSize = true;
            this.flatLabel2.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel2.ForeColor = System.Drawing.Color.White;
            this.flatLabel2.Location = new System.Drawing.Point(177, 373);
            this.flatLabel2.Name = "flatLabel2";
            this.flatLabel2.Size = new System.Drawing.Size(115, 23);
            this.flatLabel2.TabIndex = 32;
            this.flatLabel2.Text = "Login / MDP :";
            // 
            // tb_base
            // 
            this.tb_base.BackColor = System.Drawing.Color.Transparent;
            this.tb_base.Enabled = false;
            this.tb_base.Location = new System.Drawing.Point(307, 414);
            this.tb_base.MaxLength = 32767;
            this.tb_base.Multiline = false;
            this.tb_base.Name = "tb_base";
            this.tb_base.ReadOnly = false;
            this.tb_base.Size = new System.Drawing.Size(418, 34);
            this.tb_base.TabIndex = 31;
            this.tb_base.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_base.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_base.UseSystemPasswordChar = false;
            // 
            // tb_db_login
            // 
            this.tb_db_login.BackColor = System.Drawing.Color.Transparent;
            this.tb_db_login.Enabled = false;
            this.tb_db_login.Location = new System.Drawing.Point(307, 368);
            this.tb_db_login.MaxLength = 32767;
            this.tb_db_login.Multiline = false;
            this.tb_db_login.Name = "tb_db_login";
            this.tb_db_login.ReadOnly = false;
            this.tb_db_login.Size = new System.Drawing.Size(206, 34);
            this.tb_db_login.TabIndex = 30;
            this.tb_db_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_db_login.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_db_login.UseSystemPasswordChar = false;
            // 
            // tb_db_ip
            // 
            this.tb_db_ip.BackColor = System.Drawing.Color.Transparent;
            this.tb_db_ip.Enabled = false;
            this.tb_db_ip.Location = new System.Drawing.Point(307, 323);
            this.tb_db_ip.MaxLength = 32767;
            this.tb_db_ip.Multiline = false;
            this.tb_db_ip.Name = "tb_db_ip";
            this.tb_db_ip.ReadOnly = false;
            this.tb_db_ip.Size = new System.Drawing.Size(418, 34);
            this.tb_db_ip.TabIndex = 29;
            this.tb_db_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_db_ip.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_db_ip.UseSystemPasswordChar = false;
            // 
            // flatLabel9
            // 
            this.flatLabel9.AutoSize = true;
            this.flatLabel9.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel9.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel9.ForeColor = System.Drawing.Color.White;
            this.flatLabel9.Location = new System.Drawing.Point(177, 330);
            this.flatLabel9.Name = "flatLabel9";
            this.flatLabel9.Size = new System.Drawing.Size(39, 23);
            this.flatLabel9.TabIndex = 26;
            this.flatLabel9.Text = "IP : ";
            // 
            // cb_db
            // 
            this.cb_db.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cb_db.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_db.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_db.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_db.Enabled = false;
            this.cb_db.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cb_db.ForeColor = System.Drawing.Color.White;
            this.cb_db.FormattingEnabled = true;
            this.cb_db.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cb_db.ItemHeight = 18;
            this.cb_db.Items.AddRange(new object[] {
            "MySQL",
            "SQLServer",
            "SQLite",
            "Aucune"});
            this.cb_db.Location = new System.Drawing.Point(307, 283);
            this.cb_db.Name = "cb_db";
            this.cb_db.Size = new System.Drawing.Size(418, 24);
            this.cb_db.TabIndex = 25;
            this.cb_db.SelectedIndexChanged += new System.EventHandler(this.flatComboBox4_SelectedIndexChanged);
            // 
            // cb_service
            // 
            this.cb_service.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cb_service.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_service.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_service.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_service.Enabled = false;
            this.cb_service.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cb_service.ForeColor = System.Drawing.Color.White;
            this.cb_service.FormattingEnabled = true;
            this.cb_service.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cb_service.ItemHeight = 18;
            this.cb_service.Items.AddRange(new object[] {
            "BASIC",
            "CyberNet",
            "SN",
            "DEPOT",
            "Drive"});
            this.cb_service.Location = new System.Drawing.Point(307, 243);
            this.cb_service.Name = "cb_service";
            this.cb_service.Size = new System.Drawing.Size(418, 24);
            this.cb_service.TabIndex = 23;
            // 
            // cb_ctype
            // 
            this.cb_ctype.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.cb_ctype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_ctype.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_ctype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_ctype.Enabled = false;
            this.cb_ctype.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cb_ctype.ForeColor = System.Drawing.Color.White;
            this.cb_ctype.FormattingEnabled = true;
            this.cb_ctype.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cb_ctype.ItemHeight = 18;
            this.cb_ctype.Location = new System.Drawing.Point(307, 205);
            this.cb_ctype.Name = "cb_ctype";
            this.cb_ctype.Size = new System.Drawing.Size(337, 24);
            this.cb_ctype.TabIndex = 20;
            // 
            // flatLabel8
            // 
            this.flatLabel8.AutoSize = true;
            this.flatLabel8.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel8.ForeColor = System.Drawing.Color.White;
            this.flatLabel8.Location = new System.Drawing.Point(177, 282);
            this.flatLabel8.Name = "flatLabel8";
            this.flatLabel8.Size = new System.Drawing.Size(41, 23);
            this.flatLabel8.TabIndex = 24;
            this.flatLabel8.Text = "DB :";
            // 
            // flatLabel7
            // 
            this.flatLabel7.AutoSize = true;
            this.flatLabel7.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel7.ForeColor = System.Drawing.Color.White;
            this.flatLabel7.Location = new System.Drawing.Point(177, 242);
            this.flatLabel7.Name = "flatLabel7";
            this.flatLabel7.Size = new System.Drawing.Size(77, 23);
            this.flatLabel7.TabIndex = 22;
            this.flatLabel7.Text = "Service : ";
            // 
            // cb_tls
            // 
            this.cb_tls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.cb_tls.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.cb_tls.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cb_tls.Checked = false;
            this.cb_tls.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_tls.Enabled = false;
            this.cb_tls.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_tls.Location = new System.Drawing.Point(650, 206);
            this.cb_tls.Name = "cb_tls";
            this.cb_tls.Options = FlatUITheme.FlatCheckBox._Options.Style1;
            this.cb_tls.Size = new System.Drawing.Size(75, 22);
            this.cb_tls.TabIndex = 21;
            this.cb_tls.Text = "TLS";
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(177, 204);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(70, 23);
            this.flatLabel1.TabIndex = 19;
            this.flatLabel1.Text = "CType : ";
            // 
            // cb_local
            // 
            this.cb_local.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.cb_local.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.cb_local.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.cb_local.Checked = false;
            this.cb_local.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cb_local.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_local.Location = new System.Drawing.Point(652, 23);
            this.cb_local.Name = "cb_local";
            this.cb_local.Options = FlatUITheme.FlatCheckBox._Options.Style1;
            this.cb_local.Size = new System.Drawing.Size(75, 22);
            this.cb_local.TabIndex = 18;
            this.cb_local.Text = "Local";
            this.cb_local.CheckedChanged += new FlatUITheme.FlatCheckBox.CheckedChangedEventHandler(this.flatCheckBox1_CheckedChanged);
            // 
            // flatLabel6
            // 
            this.flatLabel6.AutoSize = true;
            this.flatLabel6.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel6.ForeColor = System.Drawing.Color.White;
            this.flatLabel6.Location = new System.Drawing.Point(177, 156);
            this.flatLabel6.Name = "flatLabel6";
            this.flatLabel6.Size = new System.Drawing.Size(43, 23);
            this.flatLabel6.TabIndex = 17;
            this.flatLabel6.Text = "Clé :";
            this.flatLabel6.Click += new System.EventHandler(this.flatLabel6_Click);
            // 
            // tb_dem_key
            // 
            this.tb_dem_key.BackColor = System.Drawing.Color.Transparent;
            this.tb_dem_key.Location = new System.Drawing.Point(307, 150);
            this.tb_dem_key.MaxLength = 32767;
            this.tb_dem_key.Multiline = false;
            this.tb_dem_key.Name = "tb_dem_key";
            this.tb_dem_key.ReadOnly = false;
            this.tb_dem_key.Size = new System.Drawing.Size(418, 34);
            this.tb_dem_key.TabIndex = 16;
            this.tb_dem_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_dem_key.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_dem_key.UseSystemPasswordChar = false;
            // 
            // tb_dem_mdp
            // 
            this.tb_dem_mdp.BackColor = System.Drawing.Color.Transparent;
            this.tb_dem_mdp.Location = new System.Drawing.Point(519, 105);
            this.tb_dem_mdp.MaxLength = 32767;
            this.tb_dem_mdp.Multiline = false;
            this.tb_dem_mdp.Name = "tb_dem_mdp";
            this.tb_dem_mdp.ReadOnly = false;
            this.tb_dem_mdp.Size = new System.Drawing.Size(206, 34);
            this.tb_dem_mdp.TabIndex = 15;
            this.tb_dem_mdp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_dem_mdp.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_dem_mdp.UseSystemPasswordChar = true;
            // 
            // tb_dem_login
            // 
            this.tb_dem_login.BackColor = System.Drawing.Color.Transparent;
            this.tb_dem_login.Location = new System.Drawing.Point(307, 105);
            this.tb_dem_login.MaxLength = 32767;
            this.tb_dem_login.Multiline = false;
            this.tb_dem_login.Name = "tb_dem_login";
            this.tb_dem_login.ReadOnly = false;
            this.tb_dem_login.Size = new System.Drawing.Size(206, 34);
            this.tb_dem_login.TabIndex = 14;
            this.tb_dem_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_dem_login.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_dem_login.UseSystemPasswordChar = false;
            // 
            // flatLabel5
            // 
            this.flatLabel5.AutoSize = true;
            this.flatLabel5.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel5.ForeColor = System.Drawing.Color.White;
            this.flatLabel5.Location = new System.Drawing.Point(177, 22);
            this.flatLabel5.Name = "flatLabel5";
            this.flatLabel5.Size = new System.Drawing.Size(57, 23);
            this.flatLabel5.TabIndex = 13;
            this.flatLabel5.Text = "Nom :";
            // 
            // flatLabel4
            // 
            this.flatLabel4.AutoSize = true;
            this.flatLabel4.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel4.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel4.ForeColor = System.Drawing.Color.White;
            this.flatLabel4.Location = new System.Drawing.Point(177, 65);
            this.flatLabel4.Name = "flatLabel4";
            this.flatLabel4.Size = new System.Drawing.Size(82, 23);
            this.flatLabel4.TabIndex = 12;
            this.flatLabel4.Text = "IP / Port :";
            // 
            // flatLabel3
            // 
            this.flatLabel3.AutoSize = true;
            this.flatLabel3.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatLabel3.ForeColor = System.Drawing.Color.White;
            this.flatLabel3.Location = new System.Drawing.Point(177, 109);
            this.flatLabel3.Name = "flatLabel3";
            this.flatLabel3.Size = new System.Drawing.Size(115, 23);
            this.flatLabel3.TabIndex = 11;
            this.flatLabel3.Text = "Login / MDP :";
            // 
            // tb_dem_port
            // 
            this.tb_dem_port.BackColor = System.Drawing.Color.Transparent;
            this.tb_dem_port.Location = new System.Drawing.Point(650, 60);
            this.tb_dem_port.MaxLength = 32767;
            this.tb_dem_port.Multiline = false;
            this.tb_dem_port.Name = "tb_dem_port";
            this.tb_dem_port.ReadOnly = false;
            this.tb_dem_port.Size = new System.Drawing.Size(75, 34);
            this.tb_dem_port.TabIndex = 9;
            this.tb_dem_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_dem_port.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_dem_port.UseSystemPasswordChar = false;
            // 
            // tb_dem_ip
            // 
            this.tb_dem_ip.BackColor = System.Drawing.Color.Transparent;
            this.tb_dem_ip.Location = new System.Drawing.Point(307, 60);
            this.tb_dem_ip.MaxLength = 32767;
            this.tb_dem_ip.Multiline = false;
            this.tb_dem_ip.Name = "tb_dem_ip";
            this.tb_dem_ip.ReadOnly = false;
            this.tb_dem_ip.Size = new System.Drawing.Size(337, 34);
            this.tb_dem_ip.TabIndex = 8;
            this.tb_dem_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_dem_ip.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_dem_ip.UseSystemPasswordChar = false;
            // 
            // tb_nom
            // 
            this.tb_nom.BackColor = System.Drawing.Color.Transparent;
            this.tb_nom.Location = new System.Drawing.Point(307, 17);
            this.tb_nom.MaxLength = 32767;
            this.tb_nom.Multiline = false;
            this.tb_nom.Name = "tb_nom";
            this.tb_nom.ReadOnly = false;
            this.tb_nom.Size = new System.Drawing.Size(337, 34);
            this.tb_nom.TabIndex = 7;
            this.tb_nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_nom.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_nom.UseSystemPasswordChar = false;
            // 
            // flatButton7
            // 
            this.flatButton7.BackColor = System.Drawing.Color.Transparent;
            this.flatButton7.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton7.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton7.Location = new System.Drawing.Point(604, 470);
            this.flatButton7.Name = "flatButton7";
            this.flatButton7.Rounded = false;
            this.flatButton7.Size = new System.Drawing.Size(120, 32);
            this.flatButton7.TabIndex = 4;
            this.flatButton7.Text = "Démarrer";
            this.flatButton7.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton7.Click += new System.EventHandler(this.flatButton7_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabPage3.Controls.Add(this.flatListBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 44);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(733, 519);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Plugins";
            // 
            // flatListBox2
            // 
            this.flatListBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatListBox2.items = new string[] {
        ""};
            this.flatListBox2.Location = new System.Drawing.Point(3, 2);
            this.flatListBox2.Name = "flatListBox2";
            this.flatListBox2.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatListBox2.Size = new System.Drawing.Size(727, 501);
            this.flatListBox2.TabIndex = 0;
            this.flatListBox2.Text = "flatListBox2";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterToolStripMenuItem1,
            this.afficherConfigurationToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(224, 52);
            // 
            // ajouterToolStripMenuItem1
            // 
            this.ajouterToolStripMenuItem1.Name = "ajouterToolStripMenuItem1";
            this.ajouterToolStripMenuItem1.Size = new System.Drawing.Size(223, 24);
            this.ajouterToolStripMenuItem1.Text = "Ajouter";
            // 
            // afficherConfigurationToolStripMenuItem
            // 
            this.afficherConfigurationToolStripMenuItem.Name = "afficherConfigurationToolStripMenuItem";
            this.afficherConfigurationToolStripMenuItem.Size = new System.Drawing.Size(223, 24);
            this.afficherConfigurationToolStripMenuItem.Text = "Afficher configuration";
            // 
            // ConOrLaunch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 615);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConOrLaunch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.cms_serverList.ResumeLayout(false);
            this.formSkin1.ResumeLayout(false);
            this.flatTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip cms_serverList;
        private System.Windows.Forms.ToolStripMenuItem ajouterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lancerToolStripMenuItem;
        private FlatUITheme.FormSkin formSkin1;
        private FlatUITheme.FlatTabControl flatTabControl1;
        private TabPage tabPage1;
        private FlatUITheme.FlatButton flatButton3;
        private FlatUITheme.FlatButton flatButton2;
        private FlatUITheme.FlatButton flatButton1;
        private FlatUITheme.FlatTextBox tb_port;
        private FlatUITheme.FlatTextBox tb_seckey;
        private FlatUITheme.FlatTextBox tb_pass;
        private FlatUITheme.FlatTextBox tb_login;
        private FlatUITheme.FlatTextBox tb_ip;
        private TabPage tabPage2;
        private ListBox listBox1;
        private FlatUITheme.FlatTextBox tb_db_pass;
        private FlatUITheme.FlatButton flatButton5;
        private FlatUITheme.FlatButton flatButton4;
        private FlatUITheme.FlatLabel flatLabel10;
        private FlatUITheme.FlatLabel flatLabel2;
        private FlatUITheme.FlatTextBox tb_base;
        private FlatUITheme.FlatTextBox tb_db_login;
        private FlatUITheme.FlatTextBox tb_db_ip;
        private FlatUITheme.FlatLabel flatLabel9;
        private FlatUITheme.FlatComboBox cb_db;
        private FlatUITheme.FlatComboBox cb_service;
        private FlatUITheme.FlatComboBox cb_ctype;
        private FlatUITheme.FlatLabel flatLabel8;
        private FlatUITheme.FlatLabel flatLabel7;
        private FlatUITheme.FlatCheckBox cb_tls;
        private FlatUITheme.FlatLabel flatLabel1;
        private FlatUITheme.FlatCheckBox cb_local;
        private FlatUITheme.FlatLabel flatLabel6;
        private FlatUITheme.FlatTextBox tb_dem_key;
        private FlatUITheme.FlatTextBox tb_dem_mdp;
        private FlatUITheme.FlatTextBox tb_dem_login;
        private FlatUITheme.FlatLabel flatLabel5;
        private FlatUITheme.FlatLabel flatLabel4;
        private FlatUITheme.FlatLabel flatLabel3;
        private FlatUITheme.FlatTextBox tb_dem_port;
        private FlatUITheme.FlatTextBox tb_dem_ip;
        private FlatUITheme.FlatTextBox tb_nom;
        private FlatUITheme.FlatButton flatButton7;
        private TabPage tabPage3;
        private FlatUITheme.FlatListBox flatListBox2;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem ajouterToolStripMenuItem1;
        private ToolStripMenuItem afficherConfigurationToolStripMenuItem;
        private FlatUITheme.FlatTextBox flatTextBox1;
        private ListBox listBox2;
    }
}

