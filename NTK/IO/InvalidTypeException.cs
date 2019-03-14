using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO
{
    /// <summary>
    /// Erreur de chargement dynamique d'une classe
    /// </summary>
    public class InvalidTypeException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="abs">Classe abstraite</param>
        /// <param name="real">Classe obtenue</param>
        public InvalidTypeException(String abs, String real) : base("La classe attendu '"+abs+"' n'est pas conforme à celle obtenue '"+real+"'")
        {
            
        }

    }
}
