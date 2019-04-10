using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Réception des utilisateurs
    /// </summary>
    public class GetUserEventArgs : EventArgs, IEventEnum
    {
        private XmlNode root;
        private int indice = -1;
        private int indiceMax = 0;

        public GetUserEventArgs(String data)
        {
            XmlDocument xmlp = new XmlDocument(data, false);
            this.root = xmlp.getNode(0);
            this.indiceMax = root.getChild(0).count() - 1;
        }


        public Boolean next()
        {
            return (++indice <= indiceMax);
        }


        public String getUserName()
        {
            return root.getChild("Name").getChildV(indice);
        }
        public String getLogin()
        {
            return root.getChild("Login").getChildV(indice);
        }
        public String getMail()
        {
            return root.getChild("Mail").getChildV(indice);
        }
        public String getPicid()
        {
            return root.getChild("AvatarID").getChildV(indice);
        }
        public String getLVL()
        {
            return root.getChild("LVL").getChildV(indice);
        }
        public String getId()
        {
            return root.getChild("ID").getChildV(indice);
        }
        
        public String get(String name)
        {
            return root.getChild(name).getChildV(indice);
        }


    }
}
