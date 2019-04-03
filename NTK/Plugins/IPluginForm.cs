using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTK.Plugins
{
    /// <summary>
    /// Plugin Formulaire
    /// </summary>
    public interface IPluginForm : IBasePlugin
    {
        /// <summary>
        /// Retourne la fen^tre principale du plugin
        /// </summary>
        /// <returns></returns>
        Form getStage();
    }
}
