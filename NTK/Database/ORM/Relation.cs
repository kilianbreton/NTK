using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database.ORM
{
    public class Relation
    {
        private DBSColumn column;
        private RelationType type;
   
        public Relation(DBSColumn col,RelationType type)
        {
            this.column = col;
            this.type = type;

        }

        public DBSColumn Column { get => column;  }
        public RelationType Type { get => type; }
    }
}
