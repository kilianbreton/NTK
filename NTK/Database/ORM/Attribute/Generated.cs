using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Database.ORM.Core;

namespace NTK.Database.ORM.Attribute
{
    public class Generated : System.Attribute
    {
        private bool basic = true;

        public Generated() { }

        public Generated(ValueGenerator<Object> vg) {
            basic = false;

        }

        public bool Basic { get => basic; set => basic = value; }
    }
}
