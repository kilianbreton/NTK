using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NTK.Other.NTKF;

namespace NTK.IO.Ini
{
    /// <summary>
    /// Représente un fichier INI
    /// </summary>
    public class IniDocument
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// PROPRIETES ///////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private List<IniGroup> groups = new List<IniGroup>();
        private List<IniValue> values = new List<IniValue>();
        private String path;
        private int indexGroup = -1;
        private int indexValue = -1;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textOrPath"></param>
        /// <param name="isPath"></param>
        public IniDocument(String textOrPath, bool isPath = true)
        {
            List<String> texts = new List<String>();
            if (isPath)
            {
                texts.AddRange(System.IO.File.ReadAllLines(textOrPath));
                this.path = textOrPath;
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

        /// <summary>
        /// Création d'un nouveau documlent ini en mémoire
        /// </summary>
        public IniDocument() { }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES /////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Recherche si un groupe éxiste
        /// </summary>
        /// <param name="name">nom du groupe</param>
        /// <returns></returns>
        public bool isGroupExist(String name)
        {
            int cpt = 0;
            bool ret = false;
            while(cpt < groups.Count && !ret)
            {
                if (groups[cpt].Name.Equals(name)) { ret = true; }
                cpt++;
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        public IniGroup addGroup(String name, params IniValue[] vals)
        {
            var g = new IniGroup(name, vals);
            groups.Add(g);
            return g;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vals"></param>
        /// <returns></returns>
        public IniGroup addGroup(String name, List<IniValue> vals)
        {
            var g = new IniGroup(name, vals);
            groups.Add(g);
            return g;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IniGroup getGroup(String name)
        {
            IniGroup ret = null;
            int cpt = 0;

            while (cpt < groups.Count && !groups[cpt].Name.Equals(name)) { cpt++; }

            if (groups[cpt].Name.Equals(name))
                ret = groups[cpt];

            return ret;
        }
      
        /// <summary>
        /// Ajoute une valeur dans le document
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public IniDocument addValue(String name, String value)
        {
            this.values.Add(new IniValue(name, value));
            return this;
        }

        /// <summary>
        /// Ajoute une valeu dans le documlent
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public IniDocument addValue(IniValue value)
        {
            this.values.Add(value);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool nextGroup()
        {
            return (++indexGroup < groups.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool nextValue()
        {
            return (++indexValue < values.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IniGroup getCurrentGrp()
        {
            return groups[indexGroup];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IniValue getCurrentValue()
        {
            return values[indexValue];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String print()
        {
            String ret = "";

            foreach (IniValue val in values)
            {
                ret += val.print() + "\n";
            }

            foreach (IniGroup grp in groups)
            {
                ret += grp.print() + "\n";
            }

            return ret;
        }

        /// <summary>
        /// Save File
        /// </summary>
        public void save()
        {
            if (path != null)
            {
                var strm = File.Create(path);
                var sw = new StreamWriter(strm);
                sw.WriteLine(this.print());
                sw.Flush();
            }
            else
            {
                throw new UnknowPathException();
            }
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void save(String path)
        {
            this.path = path;
            var strm = File.Create(path);
            var sw = new StreamWriter(strm);
            sw.WriteLine(this.print());
            sw.Flush();
        }
       
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTER ///////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        public List<IniGroup> Groups { get => groups; set => groups = value; }
      
        /// <summary>
        /// 
        /// </summary>
        public List<IniValue> Values { get => values; set => values = value; }
    }
}
