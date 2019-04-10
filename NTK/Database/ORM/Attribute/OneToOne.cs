using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database.ORM.Attribute
{
    /// <summary>
    /// Relation OneToOne
    /// </summary>
    public class OneToOne : System.Attribute
    {
        private string targetTable;
        private string targetColumn;

        /// <summary>
        /// Création d'une relation OneOne
        /// </summary>
        /// <param name="targetTable"></param>
        /// <param name="targetColumn"></param>
        public OneToOne(string targetTable, string targetColumn)
        {
            this.targetTable = targetTable;
            this.targetColumn = targetColumn;
        }

        /// <summary>
        /// Table cible
        /// </summary>
        public string TargetTable { get => targetTable; set => targetTable = value; }
        /// <summary>
        /// Colonne cible
        /// </summary>
        public string TargetColumn { get => targetColumn; set => targetColumn = value; }
    }
}
