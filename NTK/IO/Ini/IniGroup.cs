using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NTK.Other.NTKF;


namespace NTK.IO.Ini
{
    public class IniGroup
    {
        private int index = -1;
        private String name;
        private List<IniValue> values = new List<IniValue>();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public IniGroup(String name)
        {
            this.name = name;
        }

        public IniGroup(String name, params IniValue[] vals)
        {
            this.name = name;
            this.values.AddRange(vals);
        }

        public IniGroup(String name, List<IniValue> vals)
        {
            this.name = name;
            this.values = vals;
        }

        public IniGroup() { }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool next()
        {
            return (++index < values.Count);
        }

        public IniValue get()
        {
            if (index < 0)
                return null;

            return values[index];
        }

        public IniValue getValueLine(String name)
        {
            IniValue ret = null;
            int cpt = 0;

            while (cpt < values.Count && !values[cpt].Name.Equals(name)) { cpt++; }

            if (values[cpt].Name.Equals(name))
                ret = values[cpt];

            return ret;
        }

        public String getValue(String name)
        {
            String ret = null;
            int cpt = 0;

            while (cpt < values.Count && !values[cpt].Name.Equals(name)) { cpt++; }

            if (values[cpt].Name.Equals(name))
                ret = values[cpt].Value;

            return ret;
        }

        public String print()
        {
            String ret = "[" + name + "]\n";
            foreach(IniValue val in values)
            {
                ret += val.print() + "\n";
            }

            return ret;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS & SETTERS /////////////////////////////////////////////////////////////////////////////////////////////////   
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name { get => name; set => name = value; }
        public List<IniValue> Values { get => values; set => values = value; }


    }
}
