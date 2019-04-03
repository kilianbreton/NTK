using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Pipe
{
    /// <summary>
    /// Commande SET USERLIST
    /// </summary>
    public class NPM_UserList : NTKPipeMsg
    {
        private List<NTKUser> userlist;
        /// <summary>
        /// Créé une commande de définition de la liste utilisateur
        /// </summary>
        public NPM_UserList(List<NTKUser> userlist) : base(NPMType.SET, "USERLIST")
        {
            this.userlist = userlist;
        }
        /// <summary>
        /// Liste d'utilisateurs
        /// </summary>
        public List<NTKUser> Userlist { get => userlist; set => userlist = value; }
    }
}
