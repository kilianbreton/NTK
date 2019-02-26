using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NTK.Other.NTKF;

namespace NTK.IO.Ini
{
    public class IniDocument
    {
        private List<IniGroup> groups = new List<IniGroup>();


        public IniDocument(String textOrPath, bool isPath = true)
        {
            List<String> texts = new List<String>();
            if (isPath)
            {
                texts.AddRange(System.IO.File.ReadAllLines(textOrPath));
            }
            else
            {
                string[] stringSeparators = new string[] { "\r\n" };
                texts.AddRange(textOrPath.Split(stringSeparators, StringSplitOptions.None));
            }

            //Parseur
            int index = -1;
            foreach (String line in texts)
            {
                if(line.Contains("[") && line.Contains("]") && line.IndexOf(";") != 0)
                {
                    index++;
                    groups.Add(new IniGroup(subsep(line, "[", "]")));
                }
                else if (index >= 0 && line.Contains("=") && line.IndexOf(";") != 0)  //Si un groupe existe et si ce n'est pas un commentaire
                {
                    groups[index].Values.Add(new IniValue(subsep(line,0,"="),subsep(line,"=")));
                }

            }


        }

        public IniGroup addGroup(String name, params IniValue[] vals)
        {
            return new IniGroup(name,vals);
        }

        public IniGroup addGroup(String name, List<IniValue> vals)
        {
            return new IniGroup(name, vals);
        }


        public IniGroup getGroup(String name)
        {
            IniGroup ret = null;
            int cpt = 0;

            while (cpt < groups.Count && !groups[cpt].Name.Equals(name)) { cpt++; }

            if (groups[cpt].Name.Equals(name))
                ret = groups[cpt];

            return ret;
        }

        public String print()
        {
            String ret = "";
            foreach(IniGroup grp in groups)
            {
                ret += grp.print() + "\n";
            }

            return ret;
        }

        public List<IniGroup> Groups { get => groups; set => groups = value; }
    }
}
