using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Security
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAsymEncryptor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] encryptPublic(byte[] data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] decryptPublic(byte[] data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string encryptPublic(string data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string decryptPublic(string data);


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] encryptPrivate(byte[] data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] decryptPrivate(byte[] data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string encryptPrivate(string data);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string decryptPrivate(string data);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string genKey();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        void setKey(string key);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string getKey();

    }
}
