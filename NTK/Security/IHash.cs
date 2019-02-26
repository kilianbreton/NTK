using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Security
{
    public interface IHash
    {
        string getName();
        string getHash(string data);
        byte[] getHash(byte[] data);
    }
}
