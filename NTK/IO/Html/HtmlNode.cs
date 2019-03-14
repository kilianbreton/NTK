using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.IO.Html
{
    /// <summary>
    /// 
    /// </summary>
    public enum TitleType
    {
        /// <summary>
        /// 
        /// </summary>
        H1,
        /// <summary>
        /// 
        /// </summary>
        H2,
        /// <summary>
        /// 
        /// </summary>
        H3,
        /// <summary>
        /// 
        /// </summary>
        H4,
        /// <summary>
        /// 
        /// </summary>
        H5
    }

    /// <summary>
    /// 
    /// </summary>
    public class HtmlNode : XmlNode
    {
        /// <summary>
        /// Création d'un noeud (Balise)
        /// </summary>
        /// <param name="name"></param>
        public HtmlNode(String name) : base(name) {}
        /// <summary>
        /// Création d'un noeud (Balise)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public HtmlNode(String name, String value) : base(name,value) {  }
        /// <summary>
        /// Création d'un noeud (Balise)
        /// </summary>
        /// <param name="name">Nom de la balise</param>
        /// <param name="value">Valeur si il y en a une (null sinon)</param>
        /// <param name="attributs">List des attributs</param>
        /// <param name="child">Balise enfant</param>
        public HtmlNode(String name, String value, List<XmlAttribute> attributs = null, XmlNode child = null)
            :base(name,value,attributs,child) {}



        /// <summary>
        /// Ajoute une balise de lien (A)
        /// </summary>
        /// <param name="link"></param>
        /// <param name="value"></param>
        /// <param name="att"></param>
        /// <returns></returns>
        public HtmlNode addLink(String link,String value = null, params XmlAttribute[] att)
        {
            var lst = new List<XmlAttribute>(att);
            HtmlNode ret = new HtmlNode("a",value,lst);
            ret.addAttribute("href", link);
            base.getChildList().Add(ret);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Libellé</param>
        /// <param name="type">Type de titre H1,H2...</param>
        /// <param name="att">Attributs</param>
        /// <returns></returns>
        public HtmlNode addTitle(String value, TitleType type, params XmlAttribute[] att)
        {
            var lst = new List<XmlAttribute>(att);
            HtmlNode ret = new HtmlNode(type.ToString(),value,lst);
            base.getChildList().Add(ret);
            return ret;
        }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="att"></param>
        /// <returns></returns>
        public HtmlNode addParagraph(String value, params XmlAttribute[] att)
        {
            var lst = new List<XmlAttribute>(att);
            HtmlNode ret = new HtmlNode("p", value, lst);
            base.getChildList().Add(ret);
            return ret;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="att"></param>
        /// <returns></returns>
        public HtmlNode addTable(params XmlAttribute[] att)
        {
            var lst = new List<XmlAttribute>(att);
            HtmlNode ret = new HtmlNode("table", null, lst);
            base.getChildList().Add(ret);
            return ret;
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="titles"></param>
        /// <returns></returns>
        public HtmlNode addTableHeader(params String[] titles)
        {
            HtmlNode ret = new HtmlNode("tr", null, null);
            foreach(String title in titles)
            {
                ret.addChild("th",title);
            }
            base.getChildList().Add(ret);
            
            return ret;
        }
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="titles"></param>
        /// <returns></returns>
        public HtmlNode addTableValuesLine(params String[] titles)
        {
            HtmlNode ret = new HtmlNode("tr", null, null);
            foreach (String title in titles)
            {
                ret.addChild("td",title);
            }
            base.getChildList().Add(ret);

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="att"></param>
        /// <returns></returns>
        public HtmlNode addList(params XmlAttribute[] att)
        {
            var lst = new List<XmlAttribute>(att);
            HtmlNode ret = new HtmlNode("ul",null, lst);
            base.getChildList().Add(ret);

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="att"></param>
        /// <returns></returns>
        public HtmlNode addListNode(String value,params XmlAttribute[] att)
        {
            var lst = new List<XmlAttribute>(att);
            HtmlNode ret = new HtmlNode("li", value, lst);
            base.getChildList().Add(ret);

            return ret;
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="att"></param>
        /// <returns></returns>
        public HtmlNode addImg(String path, params XmlAttribute[] att)
        {
            var lst = new List<XmlAttribute>(att);
            HtmlNode ret = new HtmlNode("img", null, lst);
            ret.addAttribute("href", path);
            base.getChildList().Add(ret);
            return ret;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="att"></param>
        /// <returns></returns>
        public HtmlNode addBody(params XmlAttribute[] att)
        {
            var lst = new List<XmlAttribute>(att);
            HtmlNode ret = new HtmlNode("body", null, lst);
            base.getChildList().Add(ret);
            return ret;
        }


        public HtmlNode addNav()
        {
            HtmlNode ret = null;

            return ret;
        }
    }
}
