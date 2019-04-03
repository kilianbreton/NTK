using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.Security
{
    /// <summary>
    /// Classe de chiffrement RSA
    /// </summary>
    public class NTKRsa 
    {
        private RSACryptoServiceProvider csp;
        private UTF8Encoding encoder = new UTF8Encoding();
     
        /// <summary>
        /// Instanciation avec clé
        /// </summary>
        /// <param name="key"></param>
        /// <param name="priv"></param>
        public NTKRsa(String key, Boolean priv = true)
        {
            csp = new RSACryptoServiceProvider();
            csp.FromXmlString(key);
            
           
        }
      
        /// <summary>
        /// Create new Rsa cypher auto-generated Keys
        /// </summary>
        public NTKRsa()
        {
            csp = new RSACryptoServiceProvider();
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public String encrypt(String text)
        {
            var bytes = encoder.GetBytes(text);
            var encText = csp.Encrypt(bytes,false);
            return Convert.ToBase64String(encText);
        }
  
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public String decrypt(String text)
        {
            var bytes = Convert.FromBase64String(text);
            return encoder.GetString(csp.Decrypt(bytes, false));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="algoOID"></param>
        /// <returns></returns>
        public String signHash(byte[] text,String algoOID)
        {
            //var bytes = Encoding.UTF8.GetBytes(text);
            return encoder.GetString(csp.SignHash(text,algoOID));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="priv"></param>
        /// <returns></returns>
        public String generateCert(String name,bool priv)
        {
            String pubkey = this.getKey();
            XmlDocument xmlp = new XmlDocument();
            xmlp.addNode("name", name);
            xmlp.addNode("authority", "auto-signed");
            xmlp.addNode("publicKey", pubkey);
            if (priv)
            {
                xmlp.addNode("privateKey", this.getKey(true));
            }

            xmlp.addNode("signature",this.signHash(sha256(pubkey,false),"SHA256"));
            xmlp.addNode("date", DateTime.Now.ToString());


            return xmlp.print();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="name"></param>
        /// <param name="priv"></param>
        public void generateCert(String path,String name,bool priv)
        {
            System.IO.File.WriteAllText(path, this.generateCert(name, priv));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="priv"></param>
        /// <returns></returns>
        public String getKey(Boolean priv = false)
        {
            return csp.ToXmlString(priv);
        }


        private string sha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();

            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
        private byte[] sha256(string text,bool a)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();

            byte[] hash = hashstring.ComputeHash(bytes);
            
            return hash;
        }

    
    }
}
