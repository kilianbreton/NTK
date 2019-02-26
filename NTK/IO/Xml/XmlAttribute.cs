using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO.Xml
{
    public class XmlAttribute
    {
        private String name;
        private String value;

        public XmlAttribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
