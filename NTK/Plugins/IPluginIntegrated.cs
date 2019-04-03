using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTK.Plugins
{
    /// <summary>
    /// Plugin Intégré (Control)
    /// </summary>
    public interface IPluginIntegrated : IBasePlugin
    {
        /// <summary>
        /// retourne le Control plugin
        /// </summary>
        /// <returns></returns>
        Control getStage();
    }
}
