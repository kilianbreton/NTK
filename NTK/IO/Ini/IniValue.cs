using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO.Ini
{
    public class IniValue
    {
        private String name;
        private String value;

        public IniValue(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public String print()
        { 
            return name + "=" + value;
        }
        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
