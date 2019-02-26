namespace CLIENT_NTK
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.formSkin1 = new FlatUITheme.FormSkin();
            this.tb_users_search = new FlatUITheme.FlatTextBox();
            this.flp_users = new System.Windows.Forms.FlowLayoutPanel();
            this.flatTabControl1 = new FlatUITheme.FlatTabControl();
            this.tabNews = new System.Windows.Forms.TabPage();
            this.flp_news = new System.Windows.Forms.FlowLayoutPanel();
            this.tabMsg = new System.Windows.Forms.TabPage();
            this.flatButton5 = new FlatUITheme.FlatButton();
            this.button1 = new System.Windows.Forms.Button();
            this.rt_console = new System.Windows.Forms.RichTextBox();
            this.flatButton2 = new FlatUITheme.FlatButton();
            this.flatButton4 = new FlatUITheme.FlatButton();
            this.flatButton3 = new FlatUITheme.FlatButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabFile = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formSkin1.SuspendLayout();
            this.flatTabControl1.SuspendLayout();
            this.tabNews.SuspendLayout();
            this.tabMsg.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.tb_users_search);
            this.formSkin1.Controls.Add(this.flp_users);
            this.formSkin1.Controls.Add(this.flatTabControl1);
            this.formSkin1.Controls.Add(this.menuStrip1);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(1364, 698);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "Kasita | Client";
            this.formSkin1.Click += new System.EventHandler(this.formSkin1_Click);
            // 
            // tb_users_search
            // 
            this.tb_users_search.BackColor = System.Drawing.Color.Transparent;
            this.tb_users_search.Location = new System.Drawing.Point(1082, 8);
            this.tb_users_search.MaxLength = 32767;
            this.tb_users_search.Multiline = false;
            this.tb_users_search.Name = "tb_users_search";
            this.tb_users_search.ReadOnly = false;
            this.tb_users_search.Size = new System.Drawing.Size(279, 34);
            this.tb_users_search.TabIndex = 2;
            this.tb_users_search.Tag = "";
            this.tb_users_search.Text = "Recherche";
            this.tb_users_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_users_search.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_users_search.UseSystemPasswordChar = false;
            // 
            // flp_users
            // 
            this.flp_users.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flp_users.Location = new System.Drawing.Point(1082, 50);
            this.flp_users.Margin = new System.Windows.Forms.Padding(1);
            this.flp_users.Name = "flp_users";
            this.flp_users.Size = new System.Drawing.Size(279, 648);
            this.flp_users.TabIndex = 1;
            // 
            // flatTabControl1
            // 
            this.flatTabControl1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatTabControl1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.flatTabControl1.Controls.Add(this.tabNews);
            this.flatTabControl1.Controls.Add(this.tabMsg);
            this.flatTabControl1.Controls.Add(this.tabFile);
            this.flatTabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatTabControl1.ItemSize = new System.Drawing.Size(120, 40);
            this.flatTabControl1.Location = new System.Drawing.Point(1, 50);
            this.flatTabControl1.Name = "flatTabControl1";
            this.flatTabControl1.SelectedIndex = 0;
            this.flatTabControl1.Size = new System.Drawing.Size(1082, 648);
            this.flatTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.flatTabControl1.TabIndex = 0;
            // 
            // tabNews
            // 
            this.tabNews.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabNews.Controls.Add(this.flp_news);
            this.tabNews.Location = new System.Drawing.Point(4, 44);
            this.tabNews.Name = "tabNews";
            this.tabNews.Padding = new System.Windows.Forms.Padding(3);
            this.tabNews.Size = new System.Drawing.Size(1074, 600);
            this.tabNews.TabIndex = 1;
            this.tabNews.Text = "Actualités";
            // 
            // flp_news
            // 
            this.flp_news.AutoScroll = true;
            this.flp_news.Location = new System.Drawing.Point(7, 6);
            this.flp_news.Name = "flp_news";
            this.flp_news.Size = new System.Drawing.Size(1061, 586);
            this.flp_news.TabIndex = 0;
            // 
            // tabMsg
            // 
            this.tabMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabMsg.Controls.Add(this.flatButton5);
            this.tabMsg.Controls.Add(this.button1);
            this.tabMsg.Controls.Add(this.rt_console);
            this.tabMsg.Controls.Add(this.flatButton2);
            this.tabMsg.Controls.Add(this.flatButton4);
            this.tabMsg.Controls.Add(this.flatButton3);
            this.tabMsg.Controls.Add(this.textBox1);
            this.tabMsg.Location = new System.Drawing.Point(4, 44);
            this.tabMsg.Name = "tabMsg";
            this.tabMsg.Size = new System.Drawing.Size(1074, 600);
            this.tabMsg.TabIndex = 2;
            this.tabMsg.Text = "Messages";
            // 
            // flatButton5
            // 
            this.flatButton5.BackColor = System.Drawing.Color.Transparent;
            this.flatButton5.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton5.Location = new System.Drawing.Point(868, 507);
            this.flatButton5.Name = "flatButton5";
            this.flatButton5.Rounded = false;
            this.flatButton5.Size = new System.Drawing.Size(98, 40);
            this.flatButton5.TabIndex = 10;
            this.flatButton5.Text = "Envoyer";
            this.flatButton5.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(896, 507);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(29, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rt_console
            // 
            this.rt_console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.rt_console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rt_console.Location = new System.Drawing.Point(7, 3);
            this.rt_console.Name = "rt_console";
            this.rt_console.Size = new System.Drawing.Size(1063, 498);
            this.rt_console.TabIndex = 8;
            this.rt_console.Text = "";
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.Transparent;
            this.flatButton2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.flatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton2.Location = new System.Drawing.Point(972, 507);
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Rounded = false;
            this.flatButton2.Size = new System.Drawing.Size(98, 43);
            this.flatButton2.TabIndex = 7;
            this.flatButton2.Text = "Fichiers";
            this.flatButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // flatButton4
            // 
            this.flatButton4.BackColor = System.Drawing.Color.Transparent;
            this.flatButton4.BaseColor = System.Drawing.Color.Teal;
            this.flatButton4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton4.Location = new System.Drawing.Point(972, 556);
            this.flatButton4.Name = "flatButton4";
            this.flatButton4.Rounded = false;
            this.flatButton4.Size = new System.Drawing.Size(98, 40);
            this.flatButton4.TabIndex = 6;
            this.flatButton4.Text = "Notes";
            this.flatButton4.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // flatButton3
            // 
            this.flatButton3.BackColor = System.Drawing.Color.Transparent;
            this.flatButton3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.flatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton3.Location = new System.Drawing.Point(868, 556);
            this.flatButton3.Name = "flatButton3";
            this.flatButton3.Rounded = false;
            this.flatButton3.Size = new System.Drawing.Size(98, 40);
            this.flatButton3.TabIndex = 5;
            this.flatButton3.Text = "Sondage";
            this.flatButton3.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(3, 507);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(861, 90);
            this.textBox1.TabIndex = 2;
            // 
            // tabFile
            // 
            this.tabFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.tabFile.Location = new System.Drawing.Point(4, 44);
            this.tabFile.Name = "tabFile";
            this.tabFile.Size = new System.Drawing.Size(1074, 600);
            this.tabFile.TabIndex = 3;
            this.tabFile.Text = "Fichiers";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem,
            this.paramètresToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(478, 8);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(233, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // Main
            // 
            this.AcceptButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1364, 698);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.formSkin1.PerformLayout();
            this.flatTabControl1.ResumeLayout(false);
            this.tabNews.ResumeLayout(false);
            this.tabMsg.ResumeLayout(false);
            this.tabMsg.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private FlatUITheme.FormSkin formSkin1;
        private System.Windows.Forms.FlowLayoutPanel flp_users;
        private FlatUITheme.FlatTabControl flatTabControl1;
        private System.Windows.Forms.TabPage tabNews;
        private System.Windows.Forms.TabPage tabMsg;
        private System.Windows.Forms.Button button1;
        private FlatUITheme.FlatButton flatButton2;
        private FlatUITheme.FlatButton flatButton4;
        private FlatUITheme.FlatButton flatButton3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage tabFile;
        private FlatUITheme.FlatTextBox tb_users_search;
        private System.Windows.Forms.FlowLayoutPanel flp_news;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paramètresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rt_console;
        private FlatUITheme.FlatButton flatButton5;
    }
}