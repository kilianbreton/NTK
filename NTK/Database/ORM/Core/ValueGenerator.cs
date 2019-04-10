using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database.ORM.Core
{
    public abstract class ValueGenerator<T>
    {
        private T lastIndex;

        public ValueGenerator(Entity entity)
        {
            var qb = new QueryBuilder<Entity>();
          //  qb.select().andWhere()

        }


        public abstract T generate();

    }
}
