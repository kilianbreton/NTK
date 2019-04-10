using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database.ORM.Attribute
{
    /// <summary>
    /// Défini une table
    /// </summary>
    public class Table : System.Attribute
    {
        private String name;
        private DBSCollation charset;

        /// <summary>
        /// Création d'un lien entité->table
        /// </summary>
        /// <param name="name"></param>
        /// <param name="charset"></param>
        public Table(string name, DBSCollation charset = DBSCollation.utf8_bin)
        {
            this.name = name;
            this.charset = charset;
        }
        /// <summary>
        /// Nom de la table
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Interclassement
        /// </summary>
        public DBSCollation Charset { get => charset; set => charset = value; }
    }
}
