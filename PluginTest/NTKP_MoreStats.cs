using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTK.Plugins;

namespace PluginTest
{
    public class NTKP_MoreStats : IPluginForm
    {
        private Form main;

        public NTKP_MoreStats() { }

        public FieldMenu getField()
        {
            return FieldMenu.WINDOW;
        }

        public string getName()
        {
            return "MoreStats";
        }

        public Form getStage()
        {
            return new Test();
        }

        public PluginType getType()
        {
            return PluginType.FORM;
        }

        public void setContexte(object contexte)
        {
            throw new NotImplementedException();
        }

        public void setMain(Form main)
        {
            this.main = main;
        }

        
    }
}
