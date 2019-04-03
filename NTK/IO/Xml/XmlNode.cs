﻿/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * XmlNode Class                                                                     *
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Other;
using static NTK.Other.NTKF;

namespace NTK.IO.Xml
{
    /// <summary>
    /// Noeud (ou balise) Xml
    /// </summary>
    public class XmlNode
    {
        private List<XmlNode> nodelist = new List<XmlNode>();
        private String value =null;
        private String name;
        int index = -1;

   

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Création d'un noeud (Balise)
        /// </summary>
        /// <param name="name"></param>
        public XmlNode(String name)
        {
            this.name = name;
        }
      
        /// <summary>
        /// Création d'un noeud (Balise)
        /// </summary>
        /// <param name="name">Nom de la balise</param>
        /// <param name="value">Valeur si il y en a une (null sinon)</param>
        /// <param name="attributs">List des attributs</param>
        /// <param name="child">Balise enfant</param>
        public XmlNode(String name, String value, List<XmlAttribute> attributs = null, XmlNode child = null)
        {
            this.name = name;
            this.value = value;
            if (attributs != null)
            {
                this.Attributs = attributs;
            }
            if (child != null)
            {
                nodelist = new List<XmlNode>();
                nodelist.Add(child);
            }
        }
  
        /// <summary>
        /// Création d'un noeud (Balise)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public XmlNode(String name, String value)
        {
            this.name = name;
            this.value = value;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes Publiques ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
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
            if (index >= 0 && index < nodelist.Count)
            {
                ret = nodelist[index];
            }

            return ret;
        }

        /// <summary>
        /// Methode utilisée par le parseur de XmlDocument
        /// </summary>
        /// <param name="text"></param>
        /// <param name="name"></param>
        /// <param name="attList"></param>
        /// <returns></returns>
        public static XmlNode parseNode(String text, String name, List<XmlAttribute> attList = null)
        {
            XmlNode newNode = new XmlNode(name, null, attList);
            List<XmlAttribute> tempAtt = null;
         
            while (text.Contains("<!--"))   //Suppression des commentaires
            {
                text = delseps(text, "<!--", "-->");
            }

            if (text.Contains("<?xml"))     //TODO: Gestion entête
            {
                text = delseps(text, "<?xml", "?>");
            }

          

            while (text.Contains("<") && text.Contains(">") && text.Contains("/"))//Si il y a une sous-balise (enfant)
            {
                try
                {       
                    bool endBalType = false;
                    String childname = subsep(text, "<", ">");  //Récupération du nom (avec arguments)
                    if (childname.Contains("/"))    //Si balise auto-fermante
                    {
                        endBalType = true;
                    }
                    String childnameEnd = childname;
                    //------------------------------------Parseur d'arguments------------------------------------------------
                    if (childname.Contains(" "))//Si il y a un espace dans le nom il y a des arguments ou une erreur de syntaxe
                    {
                        int nbEquals = nbChar(childname, '=');
                        int nbQuote = nbChar(childname, '"');

                        if (nbQuote == (nbEquals * 2))//arg="value"   //il doit y avoir 2 fois plus de ' " ' que de ' = '
                        {
                            String temp = childname;
                            childnameEnd = subsep(childname, 0, " ");
                            int cpt = 0;
                            tempAtt = new List<XmlAttribute>();
                            while (temp.IndexOf('"') >= 0)
                            {
                                String attname = subsep(temp, " ", "=");

                                temp = subsep(temp, "\"");
                                String attvalue = subsep(temp, 0, "\"");
                                tempAtt.Add(new XmlAttribute(attname, attvalue));

                                temp = subsep(temp, "\"");
                                cpt++;
                            }
                            if (temp == "/")
                            {
                                endBalType = true;
                            }
                        }
                        else
                        {
                            throw new Exception("Erreur de syntaxe dans les attributs de : " + childname);

                        }
                    }
                    //----------------------Fin parseur d'arguments-----------------------------------------------------------
        
                    String childStartbal = "<" + childname + ">";
                    
                    if (endBalType)
                    {
                        text = text.Substring(childStartbal.Length + text.IndexOf(childStartbal));
                        var nextNode = new XmlNode(childnameEnd,null,tempAtt);
                        newNode.addChild(nextNode);
                    }
                    else
                    {
                        String childendbal = "</" + childnameEnd + ">";
                        String childcontent = subsep(text, childStartbal, childendbal);
                        text = text.Substring(childendbal.Length + text.IndexOf(childendbal));
                        newNode.addChild(XmlNode.parseNode(childcontent, childnameEnd,tempAtt));
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }

            if (newNode.count() == 0)
            {
                newNode.setValue(text);
            }
            return newNode;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Attributs /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool haveAttributes()
        {
            return (Attributs != null);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="att"></param>
        /// <returns></returns>
        public XmlNode addAttribute(XmlAttribute att)
        {
            initAtt();
            Attributs.Add(att);
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public XmlNode addAttribute(String name, String value)
        {
            initAtt();
            Attributs.Add(new XmlAttribute(name, value));
            return this;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public XmlAttribute getAttribute(int id)
        {
            return Attributs[id];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public XmlAttribute getAttribute(String name)
        {
            int compt = 0;
            bool find = false;
            XmlAttribute ret = null;
            while (compt < Attributs.Count && !find)
            {
                if (name.Equals(Attributs[compt].Name))
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
              //  throw new Exception("Le noeud (enfant) '" + name + "' n'éxiste pas !");
            }
            else
            {
                ret = Attributs[compt];
            }
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public String getAttibuteV(String name)
        {
            return getAttribute(name).Value;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ChildNode /////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// retourne true si l'enfant n°<c>id</c> existe
        /// </summary>
        /// <param id="id"></param>
        /// <returns></returns>
        public bool isChildExist(int id)
        {
            return (id<nodelist.Count);
        }

        /// <summary>
        /// retourne true si l'enfant de nom name existe
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool isChildExist(String name)
        {
            var ret = false;
            var cpt = 0;
            while(cpt<nodelist.Count && !ret)
            {
                if (nodelist[cpt].getName().Equals(name))
                {
                    ret = true;
                }
                cpt++;
            }
            return ret;
        }
      
        /// <summary>
        /// Retourne le nombre n'enfant
        /// </summary>
        /// <returns></returns>
        public int count()
        {
            return nodelist.Count;
        }
       
        /// <summary>
       /// 
       /// </summary>
       /// <param name="name"></param>
       /// <returns></returns>
        public List<XmlNode> getChildList(String name)
        {
            var ret = new List<XmlNode>();

            foreach(XmlNode node in nodelist)
            {
                if (name.Equals(node.getName()))
                {
                    ret.Add(node);
                }
            }
            return ret;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<XmlNode> getChildList()
        {
            return nodelist;
        }
        
        /// <summary>
        /// Ontient l'enfant n°id du noeud
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public XmlNode getChild(int id)
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
        /// Ontient l'enfant "name" du noeud
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public XmlNode getChild(String name)
        {
            int compt = 0;
            bool find = false;
            XmlNode ret;
            while(compt < nodelist.Count && !find)
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
                throw new Exception("Le noeud (enfant) '" + name+ "' n'éxiste pas !");
            }
            else
            {
                ret = nodelist[compt];
            }
            return ret;
        }

        /// <summary>
        /// Obtient le nom de l'enfant n°id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String getChildN(int id)
        {
            String ret;
            if (id > nodelist.Count)
            {
                throw new Exception("Le noeud (enfant) n° " + id + " n'éxiste pas !");
            }
            else
            {
                ret = nodelist[id].getName(); ;
            }
            return ret;
        }

        /// <summary>
        /// Obtient la valeur de l'enfant n°id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String getChildV(int id)
        {
            String ret;
            if (id > nodelist.Count)
            {
                throw new Exception("Le noeud (enfant) n° " + id + " n'éxiste pas !");
            }
            else
            {
                ret = nodelist[id].getValue(); ;
            }
            return ret;
        }
      
        /// <summary>
        /// Obtient la valeur de l'enfant "name"
        /// </summary>
        /// <param name="name"></param>
        /// <returns>(Stringà value</returns>
        public String getChildV(String name)
        {
            int compt = 0;
            bool find = false;
            String ret;
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
                throw new Exception("Le noeud (enfant) '" + name + "' n'éxiste pas !");
            }
            else
            {
                ret = nodelist[compt].getValue();
            }
            return ret;
        }
     
        /// <summary>
        /// Ajout un enfant XmlNode
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        public XmlNode addChild(XmlNode child)
        {
            nodelist.Add(child);
            return child;
        }

        /// <summary>
        /// Créé un enfant XmlNode de nom Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>le boeud créé</returns>
        public XmlNode addChild(String name)
        {
            var newNode = new XmlNode(name);
            nodelist.Add(newNode);
            return newNode;
        }
        
        /// <summary>
        /// Créé un enfant XmlNode de nom name et de valeur value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns>le noeud créé</returns>
        public XmlNode addChild(String name, String value)
        {
            var newNode = new XmlNode(name,value);
            nodelist.Add(newNode);
            return newNode;
        }

        /// <summary>
        /// Supprime le noeud n°id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool deleteChild(int id)
        {
            bool ret;
            if (id > nodelist.Count)
            {
                throw new Exception("Le noeud (enfant) n° " + id + " n'éxiste pas !");
            }
            else
            {
                nodelist.RemoveAt(id);
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Supprime le noeud de nom name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool deleteChild(String name)
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

        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------------------

        /// <summary>
        /// Génère le noeud Xml
        /// </summary>
        /// <returns></returns>
        public String print()
        {
            String ret = "<" + name;
            if (haveAttributes())
            {
                foreach(XmlAttribute elem in Attributs)
                {
                    ret += " " + elem.Name + "=\"" + elem.Value + "\"";
                }
            }
                     
            ret += ">";
            if (value != null)
            {
                ret = ret + value;
                ret = ret + "</" + name + ">\n  ";
            }
            else
            {
                for(int i = 0; i < nodelist.Count; i++)
                {
                    ret = ret + "\n   " + nodelist[i].print();
                }
                ret = ret + "</" + name + ">";
            }

             return ret;
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String printWA()
        {
            String ret = "<" + name;
            if (haveAttributes())
            {
                foreach (XmlAttribute elem in Attributs)
                {
                    ret += elem.Name + "=\"" + elem.Value + "\"";
                }
            }

            ret += ">";
            if (value != null)
            {
                ret = ret + value;
                ret = ret + "</" + name + ">";
            }
            else
            {
                for (int i = 0; i < nodelist.Count; i++)
                {
                    ret = ret + nodelist[i].printWA();
                }
                ret = ret + "</" + name + ">";
            }

            return ret;
        }
     
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS & SETTERS /////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void setName(String name)
        {
            this.name = name;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getName()
        {
            return this.name;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void setValue(String value)
        {
            this.value = value;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getValue()
        {
            return this.value;
        }

        /// <summary>
        /// Liste des attributs
        /// </summary>
        public List<XmlAttribute> Attributs { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Methodes privées //////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void initAtt()
        {
            if (!haveAttributes())
            {
                Attributs = new List<XmlAttribute>();
            }
        }

    }
}