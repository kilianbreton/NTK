using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO.IS
{
    public class Function
    {
        List<String> lst;
        string name;
        string type;

        public Function(string name, string type, string args, List<string> txt)
        {
            this.name = name;
            this.type = type;
            this.lst = txt;
            //todo : parse args
        }

        public bool execute(params String[] pars)
        {


            return false;
        }

    }
}
