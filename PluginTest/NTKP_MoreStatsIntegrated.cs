using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTK.Plugins;

namespace PluginTest
{
    public class NTKP_MoreStatsIntegrated : IPluginIntegrated
    {
        public FieldMenu getField()
        {
            return FieldMenu.TOOL;
        }

        public string getName()
        {
            return "MoreStatsIntegrated";
        }

        public Control getStage()
        {
            return new MoreStatsUC();
        }

        public PluginType getType()
        {
            return PluginType.TOOLBAR;
        }

        public void setContexte(object contexte)
        {
            throw new NotImplementedException();
        }

        public void setMain(Form main)
        {
            throw new NotImplementedException();
        }
    }
}
