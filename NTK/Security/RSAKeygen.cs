﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;

namespace NTK.Security
{
    public class RSAKeygen
    {
        public BigInteger result, d;
        public BigInteger f;

        public RSAKeygen() { }

        public void randomGenerator()                            //create random number
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] randomNumber = new byte[64];
            rng.GetBytes(randomNumber);
            result = new BigInteger(randomNumber);
            result = BigInteger.Abs(result);
        }

        public bool MillerRabinTest(int k)               //primality test
        {
            if (result == 2 || result == 3)
                return true;
            if (result < 2 || result % 2 == 0)
                return false;

            BigInteger d = result - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;

            }

            for (int i = 0; i < k; i++)
            {
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] _a = new byte[result.ToByteArray().LongLength];
                BigInteger a;

                do
                {
                    rng.GetBytes(_a);
                    a = new BigInteger(_a);
                }
                while (a < 2 || a >= result - 2);

                BigInteger x = BigInteger.ModPow(a, d, result);

                if (x == 1 || x == result - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, result);

                    if (x == 1)
                        return false;
                    if (x == result - 1)
                        break;
                }

                if (x != result - 1)
                    return false;
            }
            return true;
        }

        public BigInteger GetNearestPrime()                  //get the next prime
        {
            while (MillerRabinTest(10) == false)
            {
                result++;
            }
            return result;
        }

        public void EulerFunction(BigInteger p, BigInteger q)          //euler function: f(n) = (p-1)(q-1)
        {
            BigInteger m = p - 1;
            BigInteger n = q - 1;
            f = m * n;
        }

        public BigInteger GeneratePublicKey(BigInteger e, BigInteger n)        // public key
        {
            BigInteger ef = BigInteger.One + BigInteger.One;
            while (ef > 1)
            {
                ef = BigInteger.Pow(e, (int)f);
                ef = 1 % n;
                
            }
            return ef;
        }

        public void GeneratePrivateKey(BigInteger e)                  //private key
        {
            d = (1 / e) % f;
        }

    }
}
