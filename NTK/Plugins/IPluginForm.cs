using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTK.Plugins
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPluginForm : IBasePlugin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Form getStage();
    }
}
