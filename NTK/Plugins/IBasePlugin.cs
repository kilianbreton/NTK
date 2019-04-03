using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTK.Plugins
{
    /// <summary>
    /// Interface de base d'un Plugin
    /// </summary>
    public interface IBasePlugin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexte"></param>
        void setContexte(Object contexte);
        
        /// <summary>
        /// Défini la fenêtre principale
        /// </summary>
        /// <param name="main"></param>
        void setMain(Form main);
        
        /// <summary>
        /// Retourne le nom du plugin
        /// </summary>
        /// <returns></returns>
        String getName();

        /// <summary>
        /// Retourne la section du menu principal ou doit se trouver le plugin
        /// </summary>
        /// <returns></returns>
        FieldMenu getField();

        /// <summary>
        /// Retourne le type de plugin (FORM || Intergrated)
        /// </summary>
        /// <returns></returns>
        PluginType getType();
    }
}
