using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO
{
    /// <summary>
    /// Règle/Droit sur répertoire
    /// </summary>
    public class FMRule
    {
        private USER_LVL utype;
        private bool edit;
        private bool read;
        private bool write;
        private bool special;
        private bool show;

        public FMRule(USER_LVL utype, bool edit = false, bool read = false, bool write = false, bool special = false, bool show = false)
        {
            this.Utype = utype;
            this.Edit = edit;
            this.Read = read;
            this.Write = write;
            this.Special = special;
            this.Show = show;
        }

        public USER_LVL Utype { get => utype; set => utype = value; }
        public bool Edit { get => edit; set => edit = value; }
        public bool Read { get => read; set => read = value; }
        public bool Write { get => write; set => write = value; }
        public bool Special { get => special; set => special = value; }
        public bool Show { get => show; set => show = value; }
    }
}
