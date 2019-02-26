using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.IO
{
    public class FMDirectory
    {
        private String path;
        private int size;
        private int sizeLimit;
        private int sizeMaxFile;
        private DirectoryInfo di;

        private List<FMRule> rules = new List<FMRule>();

        public FMDirectory(string path, int sizeLimit)
        {
            this.path = path;
            this.sizeLimit = sizeLimit;
            di = new DirectoryInfo(path);
        }

        


        public string Path { get => path; set => path = value; }
        public int Size { get => size;}
        public int SizeLimit { get => sizeLimit; set => sizeLimit = value; }
        public List<FMRule> Rules { get => rules; set => rules = value; }
    }
}
