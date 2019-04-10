using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Réception d'un message
    /// </summary>
    public class GetMsgEventArgs : EventArgs, IEventEnum
    {
        private XmlNode root;
        private int indice = -1;
        private int indiceMax = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public GetMsgEventArgs(String data)
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
            return (++indice <= indiceMax);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getMsg()
        {
            return root.getChild("MSG").getChildV(indice);
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getTarget()
        {
            return root.getChild("target").getChildV(indice);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getDate()
        {
            return root.getChild("Date").getChildV(indice);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getPicid()
        {
            return root.getChild("picid").getChildV(indice);
        } 

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getWriterUser()
        {
            return root.getChild("WriterUser").getChildV(indice);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getWriterGrp()
        {
            return root.getChild("WriterGrp").getChildV(indice);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getID()
        {
            return root.getChild("ID").getChildV(indice);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string IEventEnum.get(string name)
        {
            return root.getChild(name).getChildV(indice);
        }
    }
}
