using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;
using static NTK.Other.NTKF;


namespace NTK.IO.Xml
{
    public class XmlDocument
    {
        int index = -1;
        private List<XmlNode> nodelist = new List<XmlNode>();
        private String[,] attributs;
   
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public XmlDocument(String pathortext, bool ispath = true)
        {
            String text;
            if (ispath)
            {
                text = System.IO.File.ReadAllText(pathortext);
            }
            else
            {
                text = pathortext;
            }
           

            while (text.Contains("<!--"))   //Suppression des commentaires
            {
                text = delseps(text, "<!--", "-->");
            }
            XmlNode tmpDoc = XmlNode.parseNode(text,"root");

            this.nodelist = tmpDoc.getChildList();

        }
        public XmlDocument() { }

    

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

     
        public bool read()
        {
            return (++index < nodelist.Count);
        }

        public XmlNode getNode()
        {
            XmlNode ret = null;
            if (index >= 0 && index > nodelist.Count)
            {
                ret = nodelist[index];
            }

            return ret;
        }


        public String[,] getAttributs()
        {
            return attributs;
        }

        public int count()
        {
            return nodelist.Count;
        }
   
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

        public XmlNode addNode(String name)
        {
            var newChild = new XmlNode(name);
            nodelist.Add(newChild);
            return newChild;
        }

        public XmlNode addNode(String name,String value)
        {
            var newChild = new XmlNode(name, value);
            nodelist.Add(newChild);
            return newChild;
        }

        public XmlNode addNode(XmlNode child)
        {
            nodelist.Add(child);
            return child;
        }

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

        public void write(String path)
        {
            System.IO.File.WriteAllText(path, print());
        }

        public String print()
        {
            String ret = "";
            for (int i = 0; i < nodelist.Count; i++)
            {
                ret = ret + nodelist[i].print() + "\n";
            }
            return ret;
        }
     
        public String printWA()
        {
            String ret = "";
            for (int i = 0; i < nodelist.Count; i++)
            {
                ret = ret + nodelist[i].printWA();
            }
            return ret;
        }
    }
}
