using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIENT_NTK.UserControls
{
    public partial class User_UC : UserControl
    {
        public User_UC(String name, bool connected = true)
        {
            InitializeComponent();
            this.label1.Text = name;
        }

    
        private void User_UC_Load(object sender, EventArgs e)
        {

        }
    }
}
