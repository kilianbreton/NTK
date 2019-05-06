using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO
{
    /// <summary>
    /// Chemin non défini
    /// </summary>
    public class UnknowPathException : Exception
    {
        private const String MSG = "Le chemin n'est pas défini";

        /// <summary>
        /// Création
        /// </summary>
        public UnknowPathException() : base(MSG) { }
    }
}
