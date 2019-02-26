using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLIENT_NTK
{
    public partial class News_UC : UserControl
    {
        public News_UC(String title,String content)
        {
            InitializeComponent();
            flatGroupBox1.Text = title;
            label1.Text = content;
        }
    }
}
