using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Plugins
{
    /// <summary>
    /// Type de plugin
    /// </summary>
    public enum PluginType
    {
        /// <summary>
        /// Formulaire
        /// </summary>
        FORM,
        /// <summary>
        /// Barre d'outils
        /// </summary>
        TOOLBAR,
        /// <summary>
        /// Onglet
        /// </summary>
        TAB,
        /// <summary>
        /// Service
        /// </summary>
        SERVICE,
        /// <summary>
        /// Algorithme de chiffrement
        /// </summary>
        ENCRYPTOR,
        /// <summary>
        /// Classe de connexion à une base de données
        /// </summary>
        DATABASE,
    }
}
