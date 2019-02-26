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
        private BaseModel target;
        public Relation(DBSColumn col,RelationType type,BaseModel target)
        {
            this.column = col;
            this.type = type;
            this.target = target;
        }

        public DBSColumn Column { get => column;  }
        public RelationType Type { get => type; }
    }
}
