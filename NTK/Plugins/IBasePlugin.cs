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
    public interface IBasePlugin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexte"></param>
        void setContexte(Object contexte);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="main"></param>
        void setMain(Form main);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        String getName();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        FieldMenu getField();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        PluginType getType();
    }
}
