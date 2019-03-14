using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Security
{
    /// <summary>
    /// Interface pour algorithme de hashage
    /// </summary>
    public interface IHash
    {
        /// <summary>
        /// Retourne le nom de l'algorithme
        /// </summary>
        /// <returns></returns>
        string getName();
        
        /// <summary>
        /// Obtient le hash de data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string getHash(string data);

        /// <summary>
        /// Obtient le hash de data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] getHash(byte[] data);
    }
}
