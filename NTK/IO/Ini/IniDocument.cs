/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * IniDocument Class                                                                      *
 * ----------------------------------------------------------------------------------*
 *                                                                                   *
 * LICENSE: This program is free software: you can redistribute it and/or modify     *
 * it under the terms of the GNU General Public License as published by              *
 * the Free Software Foundation, either version 3 of the License, or                 *
 * (at your option) any later version.                                               *
 *                                                                                   *
 * This program is distributed in the hope that it will be useful,                   *
 * but WITHOUT ANY WARRANTY; without even the implied warranty of                    *
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                     *
 * GNU General Public License for more details.                                      *
 *                                                                                   *
 * You should have received a copy of the GNU General Public License                 *
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.             *
 *                                                                                   *
 * ----------------------------------------------------------------------------------*/
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
    /// 
    /// </summary>
    public class IniDocument
    {
        private List<IniGroup> groups = new List<IniGroup>();
        private String path;

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
        /// 
        /// </summary>
        /// <returns></returns>
        public String print()
        {
            String ret = "";
            foreach(IniGroup grp in groups)
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
            var strm = File.Create(path);
            var sw = new StreamWriter(strm);
            sw.WriteLine(this.print());
            sw.Flush();
        }

        

        /// <summary>
        /// 
        /// </summary>
        public List<IniGroup> Groups { get => groups; set => groups = value; }
    }
}
