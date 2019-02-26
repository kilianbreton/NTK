namespace CLIENT_NTK
{
    partial class AddServer
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
            this.flatGroupBox1 = new FlatUITheme.FlatGroupBox();
            this.tb_pass1 = new FlatUITheme.FlatTextBox();
            this.tb_login = new FlatUITheme.FlatTextBox();
            this.tb_port = new FlatUITheme.FlatTextBox();
            this.tb_server = new FlatUITheme.FlatTextBox();
            this.tb_regkey = new FlatUITheme.FlatTextBox();
            this.tb_pass2 = new FlatUITheme.FlatTextBox();
            this.flatToggle1 = new FlatUITheme.FlatToggle();
            this.flatLabel1 = new FlatUITheme.FlatLabel();
            this.b_cancel = new FlatUITheme.FlatButton();
            this.b_add = new FlatUITheme.FlatButton();
            this.flatGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flatGroupBox1
            // 
            this.flatGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.flatGroupBox1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.flatGroupBox1.Controls.Add(this.b_cancel);
            this.flatGroupBox1.Controls.Add(this.b_add);
            this.flatGroupBox1.Controls.Add(this.flatLabel1);
            this.flatGroupBox1.Controls.Add(this.flatToggle1);
            this.flatGroupBox1.Controls.Add(this.tb_pass2);
            this.flatGroupBox1.Controls.Add(this.tb_regkey);
            this.flatGroupBox1.Controls.Add(this.tb_pass1);
            this.flatGroupBox1.Controls.Add(this.tb_login);
            this.flatGroupBox1.Controls.Add(this.tb_port);
            this.flatGroupBox1.Controls.Add(this.tb_server);
            this.flatGroupBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatGroupBox1.Location = new System.Drawing.Point(4, 4);
            this.flatGroupBox1.Name = "flatGroupBox1";
            this.flatGroupBox1.ShowText = true;
            this.flatGroupBox1.Size = new System.Drawing.Size(438, 373);
            this.flatGroupBox1.TabIndex = 0;
            this.flatGroupBox1.Text = "Ajouter un serveur";
            this.flatGroupBox1.Click += new System.EventHandler(this.flatGroupBox1_Click);
            // 
            // tb_pass1
            // 
            this.tb_pass1.BackColor = System.Drawing.Color.Transparent;
            this.tb_pass1.Location = new System.Drawing.Point(16, 174);
            this.tb_pass1.MaxLength = 32767;
            this.tb_pass1.Multiline = false;
            this.tb_pass1.Name = "tb_pass1";
            this.tb_pass1.ReadOnly = false;
            this.tb_pass1.Size = new System.Drawing.Size(410, 34);
            this.tb_pass1.TabIndex = 7;
            this.tb_pass1.Text = "Password";
            this.tb_pass1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_pass1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_pass1.UseSystemPasswordChar = true;
            // 
            // tb_login
            // 
            this.tb_login.BackColor = System.Drawing.Color.Transparent;
            this.tb_login.Location = new System.Drawing.Point(16, 125);
            this.tb_login.MaxLength = 32767;
            this.tb_login.Multiline = false;
            this.tb_login.Name = "tb_login";
            this.tb_login.ReadOnly = false;
            this.tb_login.Size = new System.Drawing.Size(410, 34);
            this.tb_login.TabIndex = 6;
            this.tb_login.Text = "Login";
            this.tb_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_login.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_login.UseSystemPasswordChar = false;
            // 
            // tb_port
            // 
            this.tb_port.BackColor = System.Drawing.Color.Transparent;
            this.tb_port.Location = new System.Drawing.Point(307, 74);
            this.tb_port.MaxLength = 32767;
            this.tb_port.Multiline = false;
            this.tb_port.Name = "tb_port";
            this.tb_port.ReadOnly = false;
            this.tb_port.Size = new System.Drawing.Size(119, 34);
            this.tb_port.TabIndex = 5;
            this.tb_port.Text = "Port";
            this.tb_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_port.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_port.UseSystemPasswordChar = false;
            // 
            // tb_server
            // 
            this.tb_server.BackColor = System.Drawing.Color.Transparent;
            this.tb_server.Location = new System.Drawing.Point(16, 74);
            this.tb_server.MaxLength = 32767;
            this.tb_server.Multiline = false;
            this.tb_server.Name = "tb_server";
            this.tb_server.ReadOnly = false;
            this.tb_server.Size = new System.Drawing.Size(287, 34);
            this.tb_server.TabIndex = 4;
            this.tb_server.Text = "Serveur";
            this.tb_server.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_server.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_server.UseSystemPasswordChar = false;
            // 
            // tb_regkey
            // 
            this.tb_regkey.BackColor = System.Drawing.Color.Transparent;
            this.tb_regkey.Location = new System.Drawing.Point(16, 276);
            this.tb_regkey.MaxLength = 32767;
            this.tb_regkey.Multiline = false;
            this.tb_regkey.Name = "tb_regkey";
            this.tb_regkey.ReadOnly = false;
            this.tb_regkey.Size = new System.Drawing.Size(410, 34);
            this.tb_regkey.TabIndex = 8;
            this.tb_regkey.Text = "Clé d\'enregistrement";
            this.tb_regkey.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_regkey.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_regkey.UseSystemPasswordChar = false;
            // 
            // tb_pass2
            // 
            this.tb_pass2.BackColor = System.Drawing.Color.Transparent;
            this.tb_pass2.Location = new System.Drawing.Point(16, 225);
            this.tb_pass2.MaxLength = 32767;
            this.tb_pass2.Multiline = false;
            this.tb_pass2.Name = "tb_pass2";
            this.tb_pass2.ReadOnly = false;
            this.tb_pass2.Size = new System.Drawing.Size(410, 34);
            this.tb_pass2.TabIndex = 9;
            this.tb_pass2.Text = "Password";
            this.tb_pass2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_pass2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_pass2.UseSystemPasswordChar = true;
            // 
            // flatToggle1
            // 
            this.flatToggle1.BackColor = System.Drawing.Color.Transparent;
            this.flatToggle1.Checked = false;
            this.flatToggle1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatToggle1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.flatToggle1.Location = new System.Drawing.Point(325, 20);
            this.flatToggle1.Name = "flatToggle1";
            this.flatToggle1.Options = FlatUITheme.FlatToggle._Options.Style1;
            this.flatToggle1.Size = new System.Drawing.Size(76, 33);
            this.flatToggle1.TabIndex = 10;
            this.flatToggle1.Text = "flatToggle1";
            this.flatToggle1.CheckedChanged += new FlatUITheme.FlatToggle.CheckedChangedEventHandler(this.flatToggle1_CheckedChanged);
            // 
            // flatLabel1
            // 
            this.flatLabel1.AutoSize = true;
            this.flatLabel1.BackColor = System.Drawing.Color.Transparent;
            this.flatLabel1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatLabel1.ForeColor = System.Drawing.Color.White;
            this.flatLabel1.Location = new System.Drawing.Point(233, 28);
            this.flatLabel1.Name = "flatLabel1";
            this.flatLabel1.Size = new System.Drawing.Size(80, 19);
            this.flatLabel1.TabIndex = 1;
            this.flatLabel1.Text = "S\'enregister";
            // 
            // b_cancel
            // 
            this.b_cancel.BackColor = System.Drawing.Color.Transparent;
            this.b_cancel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(30)))), ((int)(((byte)(0)))));
            this.b_cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_cancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_cancel.Location = new System.Drawing.Point(16, 326);
            this.b_cancel.Name = "b_cancel";
            this.b_cancel.Rounded = false;
            this.b_cancel.Size = new System.Drawing.Size(106, 32);
            this.b_cancel.TabIndex = 1;
            this.b_cancel.Text = "Annuler";
            this.b_cancel.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // b_add
            // 
            this.b_add.BackColor = System.Drawing.Color.Transparent;
            this.b_add.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.b_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.b_add.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.b_add.Location = new System.Drawing.Point(320, 326);
            this.b_add.Name = "b_add";
            this.b_add.Rounded = false;
            this.b_add.Size = new System.Drawing.Size(106, 32);
            this.b_add.TabIndex = 2;
            this.b_add.Text = "Ajouter";
            this.b_add.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.b_add.Click += new System.EventHandler(this.b_add_Click);
            // 
            // AddServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(442, 380);
            this.Controls.Add(this.flatGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddServer";
            this.Text = "AddServer";
            this.flatGroupBox1.ResumeLayout(false);
            this.flatGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FlatGroupBox flatGroupBox1;
        private FlatUITheme.FlatButton b_cancel;
        private FlatUITheme.FlatButton b_add;
        private FlatUITheme.FlatLabel flatLabel1;
        private FlatUITheme.FlatToggle flatToggle1;
        private FlatUITheme.FlatTextBox tb_pass2;
        private FlatUITheme.FlatTextBox tb_regkey;
        private FlatUITheme.FlatTextBox tb_pass1;
        private FlatUITheme.FlatTextBox tb_login;
        private FlatUITheme.FlatTextBox tb_port;
        private FlatUITheme.FlatTextBox tb_server;
    }
}