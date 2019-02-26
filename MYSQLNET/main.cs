using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTK.Database;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace MYSQLNET
{
    public partial class main : Form
    {
        private NTKDatabase db;

        public main()
        {
            InitializeComponent();
        }

        public void init(String adrs,String user,String pass)
        {
            db = NTKD_MySql.getInstance(adrs, user, pass, "information_schema");
            var msr = (MySqlDataReader) db.select("SELECT SCHEMA_NAME FROM SCHEMATA;");
            while (msr.Read())
            {
                treeView1.Nodes[0].Nodes.Add(new TreeNode(msr.GetString("SCHEMA_NAME")));
            }
           // db.closeConnection();
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Name != "Server")
            {
                var msr = (MySqlDataReader)db.select("SELECT * FROM COLUMNS WHERE TABLE_NAME = '" + treeView1.SelectedNode.Text + "';");
                while (msr.Read())
                {
                    dataGridView1.Columns.Add(msr.GetString("COLUMN_NAME"), msr.GetString("COLUMN_NAME"));
                    
                }
            }
        }
    }
}
