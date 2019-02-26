using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTKAdmin
{
    public partial class AlertBox : Form
    {
        private bool value = false;

        public bool Value { get => value; set => this.value = value; }
        public FlatUITheme.FlatAlertBox AlertType { get => flatAlertBox1; set => flatAlertBox1 = value; }
        public FlatUITheme.FlatLabel label { get => flatLabel1; set => flatLabel1 = value; }

        public AlertBox()
        {
            InitializeComponent();
        }
    
        public AlertBox(String title, String text, FlatUITheme.FlatAlertBox._Kind kind)
        {
            InitializeComponent();
            this.formSkin1.Text = title;
            this.flatLabel1.Text = text;
            this.flatAlertBox1.kind = kind;
        }


        private void flatButton2_Click(object sender, EventArgs e)
        {
            value = true;
            this.Close();
        }

        private void flatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
