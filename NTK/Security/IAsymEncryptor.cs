using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Security
{
    public interface IAsymEncryptor
    {
        byte[] encryptPublic(byte[] data);
        byte[] decryptPublic(byte[] data);
        string encryptPublic(string data);
        string decryptPublic(string data);

        byte[] encryptPrivate(byte[] data);
        byte[] decryptPrivate(byte[] data);
        string encryptPrivate(string data);
        string decryptPrivate(string data);

        string genKey();

        void setKey(string key);
        string getKey();

    }
}
