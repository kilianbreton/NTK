using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO.Ini
{
    /// <summary>
    /// Valeur d'un groupe ini
    /// </summary>
    public class IniValue
    {
        private String name;
        private String value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public IniValue(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String print()
        { 
            return name + "=" + value;
        }


        /// <summary>
        /// 
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get => value; set => this.value = value; }
    }
}
