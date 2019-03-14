using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.EventsArgs
{
    /// <summary>
    /// Evènement itérable
    /// </summary>
    public interface IEventEnum
    {
        /// <summary>
        /// Passe à l'enregistrement suivant
        /// </summary>
        /// <returns></returns>
        bool next();
        /// <summary>
        /// obtient le champ de nom <c>name</c>
        /// </summary>
        /// <param name="name">champ</param>
        /// <returns></returns>
        string get(string name);
    }
}
