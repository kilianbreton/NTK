using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Obtient la liste des groupes
    /// </summary>
    public class GetGrpEventArgs : EventArgs, IEventEnum
    {
        private XmlNode root;
        private int indice = -1;
        private int indiceMax = 0;
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public GetGrpEventArgs(String data)
        {
            XmlDocument xmlp = new XmlDocument(data, false);
            this.root = xmlp.getNode(0);
            this.indiceMax = root.getChild(0).count() - 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean next()
        {
            indice++;
            return (indice <= indiceMax);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getName()
        {
            return root.getChild("Name").getChildV(indice);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getType()
        {
            return root.getChild("Login").getChildV(indice);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getDescription()
        {
            return root.getChild("description").getChildV(indice);
        }
        public String getPicid()
        {
            return root.getChild("Avatar").getChildV(indice);
        }
        public String getId()
        {
            return root.getChild("id").getChildV(indice);
        }
        string IEventEnum.get(string name)
        {
            return root.getChild(name).getChildV(indice);
        }
    }
}