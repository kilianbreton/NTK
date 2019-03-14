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
    public class HtmlDocument : XmlDocument
    {
        private List<HtmlNode> nodelist = new List<HtmlNode>();
        /// <summary>
        /// 
        /// </summary>
        public HtmlDocument()
        {
            nodelist.Add(new HtmlNode("html"));
            nodelist[0].addChild("head");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public HtmlNode addLinkHeader(String type,String path)
        {
            HtmlNode ret = new HtmlNode("link");
            ret.addAttribute("rel", type);
            ret.addAttribute("href", path);
            getNode(0).getChild(0).addChild(ret);
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public new HtmlNode getNode(int id)
        {
            return nodelist[id];
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public new String print()
        {
            String ret = "";
            for (int i = 0; i < nodelist.Count; i++)
            {
                ret = ret + nodelist[i].print() + "\n";
            }
            return ret;
        }
    }
}
