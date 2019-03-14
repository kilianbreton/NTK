using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;
namespace NTK.Security
{
    /// <summary>
    /// Rsa class deprecated
    /// </summary>
    [Obsolete("Rsa class is deprecated, use NTKRsa")]
    public class Rsa
    {


        private RSAKeygen p = new RSAKeygen();
        private RSAKeygen q = new RSAKeygen();
        private RSAKeygen e = new RSAKeygen();
        private RSAKeygen f = new RSAKeygen();
        private RSAKeygen pub_key = new RSAKeygen();
        private RSAKeygen priv_key = new RSAKeygen();
        private BigInteger n;

        /// <summary>
        /// Constructor make random keys
        /// </summary>
        public Rsa()
        {
            p.randomGenerator();
            q.randomGenerator();
            e.randomGenerator();

            
            if (p.MillerRabinTest(10) == true && q.MillerRabinTest(10) == true)
            {
                n = p.result * q.result;
            }
            else
            {
                p.GetNearestPrime();
                q.GetNearestPrime();
                n = p.result * q.result;
            }

            f.EulerFunction(p.result, q.result);
            pub_key.GeneratePublicKey(e.result, n);
            priv_key.GeneratePrivateKey(e.result);
        }



        public BigInteger Encrypt(BigInteger m)          //encryption
        {
            return BigInteger.ModPow(m, e.result, n);
        }

        public BigInteger Decrypt(BigInteger cResult)    //decryption
        {
            return BigInteger.ModPow(cResult, priv_key.d, n);
        }
        public String Encrypt(String m)          //encryption
        {
 
            return BigInteger.ModPow(BigInteger.Parse(m), e.result, n).ToString();
        }

        public String Decrypt(String cResult)    //decryption
        {
            return BigInteger.ModPow(BigInteger.Parse(cResult), priv_key.d, n).ToString();
        }









    }






}
