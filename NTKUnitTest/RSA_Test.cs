using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTK;
using NTK.Security;

namespace NTKUnitTest
{
    /// <summary>
    /// Description résumée pour RSA_Test
    /// </summary>
    [TestClass]
    public class RSA_Test
    {
        private NTKRsa rsa1;
        private NTKRsa rsa2;
        public RSA_Test()
        {
            rsa1 = new NTKRsa();
            rsa2 = new NTKRsa(rsa1.getKey(),false);
            
        }

        [TestMethod]
        public void TestEncryptDecrypt() //test si la transmission de la clé d'une instance à l'autre fonctionne
        {
            String plaintext = "MESSAGE A CHIFFRER";
            String encrypt1 = rsa2.encrypt(plaintext);
         //   String encrypt2 = rsa2.encrypt(plaintext);

            Assert.AreEqual(plaintext, rsa1.decrypt(encrypt1));
          //  Assert.AreEqual(plaintext, rsa2.decrypt(encrypt2));

            //Assert.AreEqual(plaintext, rsa2.decrypt(encrypt1));
          //  Assert.AreEqual(plaintext, rsa1.decrypt(encrypt2));

        }
    }


    
}
