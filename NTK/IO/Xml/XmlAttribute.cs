using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO.Xml
{
    /// <summary>
    /// Attribut XML
    /// </summary>
    public class XmlAttribute
    {
        private String name;
        private object value;
        
        /// <summary>
        /// Création d'un attribut
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public XmlAttribute(string name, object value)
        {
            this.name = name;
            this.value = value;
        }


        /// <summary>
        /// Nom
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Valeur
        /// </summary>
        public string Value { get => (string)value; set => this.value = value; }
        /// <summary>
        /// 
        /// </summary>
        public bool BValue { get => (bool)value; set => this.value = value; }
        /// <summary>
        /// 
        /// </summary>
        public long NValue { get => (long)value; set => this.value = value; }
        /// <summary>
        /// 
        /// </summary>
        public object OValue { get => value; set => this.value = value; }
    }
}
