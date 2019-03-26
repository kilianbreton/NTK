using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO
{
    /// <summary>
    /// Racine FileManager
    /// </summary>
    public class FMRoot
    {
        private String name;
        private String realPath;
        private List<FMRule> rules = new List<FMRule>();

        public FMRoot(String name, String path, bool readChilds)
        {
            this.name = name;
            this.realPath = path;
            if (readChilds)
            {
                var di = new DirectoryInfo(path);
                
            }
        }



    }
}
