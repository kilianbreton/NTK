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
    public interface IEncryptor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string encrypt(string text);
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string decrypt(string text);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        byte[] decrypt(byte[] text);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        byte[] encrypt(byte[] text);

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
