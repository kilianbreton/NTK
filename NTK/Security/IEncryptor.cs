using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Security
{
    public interface IEncryptor
    {
        string encrypt(string text);
        string decrypt(string text);

        byte[] decrypt(byte[] text);
        byte[] encrypt(byte[] text);

        void setKey(string key);
        string getKey();
    }
}
