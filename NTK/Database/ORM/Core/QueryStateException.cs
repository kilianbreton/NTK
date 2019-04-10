using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database.ORM.Core
{
    /// <summary>
    /// Exception lors d'un mauvais changement d'état de requete
    /// </summary>
    public class QueryStateException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="tryedState"></param>
        public QueryStateException(QueryState origin, QueryState tryedState) : base("Impossible de passer la requête de " + origin.ToString() + " à " + tryedState.ToString()) {}
    }
}
