namespace CLIENT_NTK
{
    partial class Launch
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
            this.flatButton2 = new FlatUITheme.FlatButton();
            this.flatComboBox1 = new FlatUITheme.FlatComboBox();
            this.flatButton1 = new FlatUITheme.FlatButton();
            this.tb_port = new FlatUITheme.FlatTextBox();
            this.tb_pass = new FlatUITheme.FlatTextBox();
            this.tb_login = new FlatUITheme.FlatTextBox();
            this.tb_ip = new FlatUITheme.FlatTextBox();
            this.formSkin1.SuspendLayout();
            this.SuspendLayout();
            // 
            // formSkin1
            // 
            this.formSkin1.BackColor = System.Drawing.Color.White;
            this.formSkin1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.formSkin1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin1.Controls.Add(this.flatButton2);
            this.formSkin1.Controls.Add(this.flatComboBox1);
            this.formSkin1.Controls.Add(this.flatButton1);
            this.formSkin1.Controls.Add(this.tb_port);
            this.formSkin1.Controls.Add(this.tb_pass);
            this.formSkin1.Controls.Add(this.tb_login);
            this.formSkin1.Controls.Add(this.tb_ip);
            this.formSkin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin1.FlatColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.formSkin1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.formSkin1.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin1.HeaderMaximize = false;
            this.formSkin1.Location = new System.Drawing.Point(0, 0);
            this.formSkin1.Name = "formSkin1";
            this.formSkin1.Size = new System.Drawing.Size(470, 355);
            this.formSkin1.TabIndex = 0;
            this.formSkin1.Text = "Kasita | Démarrer";
            // 
            // flatButton2
            // 
            this.flatButton2.BackColor = System.Drawing.Color.Transparent;
            this.flatButton2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton2.Location = new System.Drawing.Point(429, 67);
            this.flatButton2.Name = "flatButton2";
            this.flatButton2.Rounded = false;
            this.flatButton2.Size = new System.Drawing.Size(26, 24);
            this.flatButton2.TabIndex = 46;
            this.flatButton2.Text = "+";
            this.flatButton2.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            // 
            // flatComboBox1
            // 
            this.flatComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.flatComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.flatComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.flatComboBox1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.flatComboBox1.ForeColor = System.Drawing.Color.White;
            this.flatComboBox1.FormattingEnabled = true;
            this.flatComboBox1.HoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatComboBox1.ItemHeight = 18;
            this.flatComboBox1.Location = new System.Drawing.Point(12, 65);
            this.flatComboBox1.Name = "flatComboBox1";
            this.flatComboBox1.Size = new System.Drawing.Size(411, 24);
            this.flatComboBox1.TabIndex = 45;
            this.flatComboBox1.SelectedIndexChanged += new System.EventHandler(this.flatComboBox1_SelectedIndexChanged);
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.Transparent;
            this.flatButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(168)))), ((int)(((byte)(109)))));
            this.flatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.flatButton1.Location = new System.Drawing.Point(12, 292);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Rounded = false;
            this.flatButton1.Size = new System.Drawing.Size(443, 42);
            this.flatButton1.TabIndex = 44;
            this.flatButton1.Text = "Connexion";
            this.flatButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click_1);
            // 
            // tb_port
            // 
            this.tb_port.BackColor = System.Drawing.Color.Transparent;
            this.tb_port.Location = new System.Drawing.Point(374, 114);
            this.tb_port.MaxLength = 32767;
            this.tb_port.Multiline = false;
            this.tb_port.Name = "tb_port";
            this.tb_port.ReadOnly = false;
            this.tb_port.Size = new System.Drawing.Size(84, 34);
            this.tb_port.TabIndex = 43;
            this.tb_port.Text = "1141";
            this.tb_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_port.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_port.UseSystemPasswordChar = false;
            // 
            // tb_pass
            // 
            this.tb_pass.BackColor = System.Drawing.Color.Transparent;
            this.tb_pass.Location = new System.Drawing.Point(12, 238);
            this.tb_pass.MaxLength = 32767;
            this.tb_pass.Multiline = false;
            this.tb_pass.Name = "tb_pass";
            this.tb_pass.ReadOnly = false;
            this.tb_pass.Size = new System.Drawing.Size(443, 34);
            this.tb_pass.TabIndex = 41;
            this.tb_pass.Text = "1234";
            this.tb_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_pass.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_pass.UseSystemPasswordChar = true;
            // 
            // tb_login
            // 
            this.tb_login.BackColor = System.Drawing.Color.Transparent;
            this.tb_login.Location = new System.Drawing.Point(12, 176);
            this.tb_login.MaxLength = 32767;
            this.tb_login.Multiline = false;
            this.tb_login.Name = "tb_login";
            this.tb_login.ReadOnly = false;
            this.tb_login.Size = new System.Drawing.Size(443, 34);
            this.tb_login.TabIndex = 40;
            this.tb_login.Text = "Kilian";
            this.tb_login.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_login.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_login.UseSystemPasswordChar = false;
            // 
            // tb_ip
            // 
            this.tb_ip.BackColor = System.Drawing.Color.Transparent;
            this.tb_ip.Location = new System.Drawing.Point(12, 114);
            this.tb_ip.MaxLength = 32767;
            this.tb_ip.Multiline = false;
            this.tb_ip.Name = "tb_ip";
            this.tb_ip.ReadOnly = false;
            this.tb_ip.Size = new System.Drawing.Size(353, 34);
            this.tb_ip.TabIndex = 39;
            this.tb_ip.Text = "127.0.0.1";
            this.tb_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.tb_ip.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tb_ip.UseSystemPasswordChar = false;
            // 
            // Launch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 355);
            this.Controls.Add(this.formSkin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Launch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Launch";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.formSkin1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FlatUITheme.FormSkin formSkin1;
        private FlatUITheme.FlatButton flatButton2;
        private FlatUITheme.FlatComboBox flatComboBox1;
        private FlatUITheme.FlatButton flatButton1;
        private FlatUITheme.FlatTextBox tb_port;
        private FlatUITheme.FlatTextBox tb_pass;
        private FlatUITheme.FlatTextBox tb_login;
        private FlatUITheme.FlatTextBox tb_ip;
    }
}