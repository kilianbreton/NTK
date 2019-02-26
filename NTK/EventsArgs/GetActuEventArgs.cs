using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.EventsArgs
{
    public class GetActuEventArgs : EventArgs, IEventEnum
    {
        private XmlNode root;
        private int indice = 0;
        private int indiceMax = 0;

        public GetActuEventArgs(String data)
        {
            XmlDocument xmlp = new XmlDocument(data, false);
            this.root = xmlp.getNode(0);
            this.indiceMax = root.getChild(0).count()-1;
        }
     
        public Boolean next()
        {
            return (++indice <= indiceMax);
        }

        public String getUserName()
        {
            return root.getChild("usrName").getChildV(indice);
        }
        public String getGrpName()
        {
            return root.getChild("grpName").getChildV(indice);
        }
        public String getDate()
        {
            return root.getChild("Date").getChildV(indice);
        }
        public String getPicid()
        {
            return root.getChild("picid").getChildV(indice);
        }
        public String getMSG()
        {
            return root.getChild("MSG").getChildV(indice);
        }
        public String getTitle()
        {
            return root.getChild("title").getChildV(indice);
        }
        public String getWriterUser()
        {
            return root.getChild("WriterUser").getChildV(indice);
        }
        public String getWriterGrp()
        {
            return root.getChild("WriterGrp").getChildV(indice);
        }

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

