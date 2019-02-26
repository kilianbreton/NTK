namespace MYSQLNET
{
    partial class main
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Server");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.home = new System.Windows.Forms.TabPage();
            this.Struct = new System.Windows.Forms.TabPage();
            this.data = new System.Windows.Forms.TabPage();
            this.sql = new System.Windows.Forms.TabPage();
            this.console = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.data.SuspendLayout();
            this.sql.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(1, 1);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Server";
            treeNode1.Text = "Server";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(211, 631);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.home);
            this.tabControl1.Controls.Add(this.Struct);
            this.tabControl1.Controls.Add(this.data);
            this.tabControl1.Controls.Add(this.sql);
            this.tabControl1.Controls.Add(this.console);
            this.tabControl1.Location = new System.Drawing.Point(212, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1075, 631);
            this.tabControl1.TabIndex = 1;
            // 
            // home
            // 
            this.home.Location = new System.Drawing.Point(4, 25);
            this.home.Name = "home";
            this.home.Padding = new System.Windows.Forms.Padding(3);
            this.home.Size = new System.Drawing.Size(1067, 602);
            this.home.TabIndex = 0;
            this.home.Text = "Home";
            this.home.UseVisualStyleBackColor = true;
            // 
            // Struct
            // 
            this.Struct.Location = new System.Drawing.Point(4, 25);
            this.Struct.Name = "Struct";
            this.Struct.Padding = new System.Windows.Forms.Padding(3);
            this.Struct.Size = new System.Drawing.Size(1067, 602);
            this.Struct.TabIndex = 1;
            this.Struct.Text = "Structure";
            this.Struct.UseVisualStyleBackColor = true;
            // 
            // data
            // 
            this.data.Controls.Add(this.dataGridView1);
            this.data.Location = new System.Drawing.Point(4, 25);
            this.data.Name = "data";
            this.data.Size = new System.Drawing.Size(1067, 602);
            this.data.TabIndex = 2;
            this.data.Text = "Data";
            this.data.UseVisualStyleBackColor = true;
            // 
            // sql
            // 
            this.sql.Controls.Add(this.button1);
            this.sql.Controls.Add(this.textBox1);
            this.sql.Location = new System.Drawing.Point(4, 25);
            this.sql.Name = "sql";
            this.sql.Size = new System.Drawing.Size(1067, 602);
            this.sql.TabIndex = 3;
            this.sql.Text = "Sql";
            this.sql.UseVisualStyleBackColor = true;
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(4, 25);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(1067, 602);
            this.console.TabIndex = 4;
            this.console.Text = "Console";
            this.console.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1067, 602);
            this.dataGridView1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1057, 554);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 563);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1057, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Execute";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 633);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.treeView1);
            this.Name = "main";
            this.Text = "main";
            this.tabControl1.ResumeLayout(false);
            this.data.ResumeLayout(false);
            this.sql.ResumeLayout(false);
            this.sql.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage home;
        private System.Windows.Forms.TabPage Struct;
        private System.Windows.Forms.TabPage data;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage sql;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabPage console;
    }
}