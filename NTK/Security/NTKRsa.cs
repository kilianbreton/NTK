using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;

namespace NTK.Security
{
    public class NTKRsa
    {
        private RSACryptoServiceProvider csp;
        
    
        private UTF8Encoding encoder = new UTF8Encoding();

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

        public String encrypt(String text)
        {
            var bytes = encoder.GetBytes(text);
            var encText = csp.Encrypt(bytes, false);
            return Convert.ToBase64String(encText);
        }
  
        public String decrypt(String text)
        {
            var bytes = Convert.FromBase64String(text);
            return encoder.GetString(csp.Decrypt(bytes, false));
        }

        public String signHash(byte[] text,String algoOID)
        {
            //var bytes = Encoding.UTF8.GetBytes(text);
            return encoder.GetString(csp.SignHash(text,algoOID));
        }

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

        public void generateCert(String path,String name,bool priv)
        {
            System.IO.File.WriteAllText(path, this.generateCert(name, priv));
        }

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
