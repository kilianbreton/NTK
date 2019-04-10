using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database.ORM.Attribute
{
    public class OneToMany : OneToOne
    {
        public OneToMany(string targetTable,string targetColumn) : 
               base(targetTable, targetColumn) { }
    }
}
