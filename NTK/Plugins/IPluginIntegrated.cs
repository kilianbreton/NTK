using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NTK.Plugins
{

    public interface IPluginIntegrated : IBasePlugin
    {
        UserControl getStage();
    }
}
