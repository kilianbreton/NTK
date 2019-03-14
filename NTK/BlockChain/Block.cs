using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.BlockChain
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Block<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nonce"></param>
        /// <returns></returns>
        public abstract String compute(int nonce);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="regex"></param>
        /// <returns></returns>
        public abstract bool compute(String regex);
        public abstract void addData(T data);
        public abstract T getData();
        

    }
}
