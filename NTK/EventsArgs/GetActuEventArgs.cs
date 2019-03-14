using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Obtention de la liste des actualités
    /// </summary>
    public class GetActuEventArgs : EventArgs, IEventEnum
    {
        private XmlNode root;
        private int indice = 0;
        private int indiceMax = 0;

        /// <summary>
        /// Constructeur 
        /// </summary>
        /// <param name="data">Résultat d'une requête 'Query Over NTK' (XML)</param>
        public GetActuEventArgs(String data)
        {
            XmlDocument xmlp = new XmlDocument(data, false);
            this.root = xmlp.getNode(0);
            this.indiceMax = root.getChild(0).count()-1;
        }
     
        /// <summary>
        /// Passe à l'actualité suivante
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
        public String getUserName()
        {
            return root.getChild("usrName").getChildV(indice);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getGrpName()
        {
            return root.getChild("grpName").getChildV(indice);
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
        public String getMSG()
        {
            return root.getChild("MSG").getChildV(indice);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getTitle()
        {
            return root.getChild("title").getChildV(indice);
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

      
        string IEventEnum.get(string name)
        {
            return root.getChild(name).getChildV(indice);
        }
    }
}

