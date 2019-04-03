/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * XmlDocument Class                                                                 *
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
using NTK;
using static NTK.Other.NTKF;


namespace NTK.IO.Xml
{
    /// <summary>
    /// 
    /// </summary>
    public class XmlDocument
    {
        int index = -1;
        private List<XmlNode> nodelist = new List<XmlNode>();
        private String[,] attributs;
        private String path;
   
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathortext"></param>
        /// <param name="ispath"></param>
        public XmlDocument(String pathortext, bool ispath = true)
        {
            String text;
            if (ispath)
            {
                text = System.IO.File.ReadAllText(pathortext);
                this.path = pathortext;
            }
            else
            {
                text = pathortext;
            }
           

            while (text.Contains("<!--"))   //Suppression des commentaires
            {
                text = delseps(text, "<!--", "-->");
            }
            if (text.Contains("<?xml"))
            {
                text = delseps(text, "<?xml", "?>");
            }
            XmlNode tmpDoc = XmlNode.parseNode(text,"root");

            this.nodelist = tmpDoc.getChildList();

        }
        /// <summary>
        /// 
        /// </summary>
        public XmlDocument() { }

    

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
        public bool read()
        {
            return (++index < nodelist.Count);
        }
 
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public XmlNode getNode()
        {
            XmlNode ret = null;
            if (index >= 0 && index > nodelist.Count)
            {
                ret = nodelist[index];
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String[,] getAttributs()
        {
            return attributs;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int count()
        {
            return nodelist.Count;
        }
    
        /// <summary>
       /// 
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
        public XmlNode getNode(int id)
        {
            XmlNode ret;
            if (id > nodelist.Count)
            {
                throw new Exception("Le noeud (enfant) n° " + id + " n'éxiste pas !");


            }
            else
            {
                ret = nodelist[id];
            }
            return ret;
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public XmlNode getNode(String name)
        {
            int compt = 0;
            bool find = false;
            XmlNode ret;
            while (compt < nodelist.Count && !find)
            {
                if (name.Equals(nodelist[compt].getName()))
                {
                    find = true;
                }
                else
                {

                    compt++;
                }

            }
            if (!find)
            {
                throw new Exception("Le noeud (racine) '"+ name + "' n'éxiste pas !");


            }
            else
            {
                ret = nodelist[compt];
            }
            return ret;
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public XmlNode addNode(String name)
        {
            var newChild = new XmlNode(name);
            nodelist.Add(newChild);
            return newChild;
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public XmlNode addNode(String name,String value)
        {
            var newChild = new XmlNode(name, value);
            nodelist.Add(newChild);
            return newChild;
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public XmlNode addNode(XmlNode child)
        {
            nodelist.Add(child);
            return child;
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteNode(int id)
        {
            bool ret;
            if (id > nodelist.Count)
            {
                throw new Exception("Le noeud (racine) n° " + id + "n'éxiste pas !");
                
            }
            else
            {
                nodelist.RemoveAt(id);
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool deleteNode(String name)
        {
            int compt = 0;
            bool find = false;

            while (compt < nodelist.Count && !find)
            {
                if (name.Equals(nodelist[compt].getName()))
                {
                    find = true;
                    nodelist.RemoveAt(compt);
                }
                else
                {
                    compt++;
                }
            }
            return find;
        }
  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public void write(String path)
        {
            System.IO.File.WriteAllText(path, print());
        }
  
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String print()
        {
            String ret = "";
            for (int i = 0; i < nodelist.Count; i++)
            {
                ret = ret + nodelist[i].print() + "\n";
            }
            return ret;
        }
 
        /// <summary>
         /// 
         /// </summary>
         /// <returns></returns>
        public String printWA()
        {
            String ret = "";
            for (int i = 0; i < nodelist.Count; i++)
            {
                ret = ret + nodelist[i].printWA();
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
    }
}
