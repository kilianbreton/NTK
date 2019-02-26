using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.BlockChain
{
    public abstract class Block<T>
    {
        public abstract String compute(int nonce);
        public abstract bool compute(String regex);
        public abstract void addData(T data);
        public abstract T getData();
        

    }
}
