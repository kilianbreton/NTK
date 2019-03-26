/**********************************
 * NTK - Netwotk Transport Kernel *
 * AES Class                      *
 * by KilianBT                    *
 **********************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using static NTK.Other.NTKF;


namespace NTK.Security
{
    /// <summary>
    /// Clée AES
    /// </summary>
    public struct AesKey
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] key;
        /// <summary>
        /// 
        /// </summary>
        public byte[] iv;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string makeXml()
        {
            return "<key>" + Convert.ToBase64String(key) + "</key><iv>" + Convert.ToBase64String(iv) + "</iv>";
        }

    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CLASSE ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    /// <summary>
    /// Classe de chiffrement AES
    /// </summary>
    public sealed class NTKAes : IEncryptor
    {

        private ICryptoTransform aesEncryptor;
        private RijndaelManaged rijndael;
        private ICryptoTransform decryptor;
        private AesKey aesKey;
        private const String NAME = "AES";

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="strIv"></param>
        public NTKAes(String strKey, String strIv)
        {
            AesKey = new AesKey
            {
                key = Convert.FromBase64String(strKey),
                iv = Convert.FromBase64String(strIv)
            };
            commonBuilder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="iv"></param>
        public NTKAes(byte[] key, byte[] iv)
        {
            AesKey = new AesKey
            {
                key = key,
                iv = iv
            };
            commonBuilder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public NTKAes(AesKey key)
        {
            AesKey = key;
            commonBuilder();
        }

        /// <summary>
        /// Instanciation automatique de la clé et de la classe de chiffrement
        /// </summary>
        public NTKAes()
        {
            aesKey = NTKAes.CreateKey(741);
            commonBuilder();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Retourne le nom de l'algorithme
        /// </summary>
        /// <returns></returns>
        public string getName()
        {
            return NAME;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public byte[] decrypt(byte[] text)
        {
            MemoryStream ms = new MemoryStream(text);
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);

            // Place les données déchiffrées dans un tableau d'octet
            byte[] plainTextData = new byte[text.Length];

            int decryptedByteCount = cs.Read(plainTextData, 0, plainTextData.Length);

            ms.Close();
            cs.Close();

            return plainTextData;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public byte[] encrypt(byte[] text)
        {
            // Place le texte à chiffrer dans un tableau d'octets

            MemoryStream ms = new MemoryStream();

            // Ecris les données chiffrées dans le MemoryStream
            CryptoStream cs = new CryptoStream(ms, aesEncryptor, CryptoStreamMode.Write);


            cs.Write(text, 0, text.Length);
            cs.FlushFinalBlock();


            // Place les données chiffrées dans un tableau d'octet
            byte[] CipherBytes = ms.ToArray();


            ms.Close();
            cs.Close();

            // Place les données chiffrées dans une chaine encodée en Base64
            return CipherBytes;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void setKey(AesKey key)
        {
            this.aesKey = key;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public AesKey getKey()
        {
            return aesKey;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void setKey(string key)
        {
            this.aesKey.key = Encoding.UTF8.GetBytes(subsep(key, "<key>", "</key>"));
            this.aesKey.iv = Encoding.UTF8.GetBytes(subsep(key, "<iv>", "</iv>"));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string IEncryptor.getKey()
        {
            return this.aesKey.makeXml();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clearText"></param>
        /// <returns></returns>
        public string encrypt(string clearText)
        {
            // Place le texte à chiffrer dans un tableau d'octets
            byte[] plainText = Encoding.UTF8.GetBytes(clearText);

            MemoryStream ms = new MemoryStream();

            // Ecris les données chiffrées dans le MemoryStream
            CryptoStream cs = new CryptoStream(ms, aesEncryptor, CryptoStreamMode.Write);


            cs.Write(plainText, 0, plainText.Length);
            cs.FlushFinalBlock();

          
            // Place les données chiffrées dans un tableau d'octet
            byte[] CipherBytes = ms.ToArray();


            ms.Close();
            cs.Close();

         
            //return Encoding.UTF8.GetString(CipherBytes);
            return Convert.ToBase64String(CipherBytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string decrypt(string cipherText)
        {
            byte[] cipheredData = Convert.FromBase64String(cipherText);
            //byte[] cipheredData = Encoding.UTF8.GetBytes(cipherText);

        
            MemoryStream ms = new MemoryStream(cipheredData);
            CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);

            // Place les données déchiffrées dans un tableau d'octet
            byte[] plainTextData = new byte[cipheredData.Length];

            int decryptedByteCount = cs.Read(plainTextData, 0, plainTextData.Length);

            ms.Close();
            try
            {
                cs.Close();
            }
            catch (Exception e)
            {
                cs = null;
            }
            return Encoding.UTF8.GetString(plainTextData, 0, decryptedByteCount);

        }

        /// <summary>
        /// 
        /// </summary>
        public AesKey AesKey { get => aesKey; set => aesKey = value; }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES STATIQUES //////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="salt"></param>
        /// <param name="keyBytes"></param>
        /// <returns></returns>
        public static AesKey CreateKey(int salt, int keyBytes = 32)
        {
            const int Iterations = 300;
            var rnd = new Random();
            
            var keyGenerator = new Rfc2898DeriveBytes(generateString(2048), salt, Iterations);
            var saltGenerator = new Rfc2898DeriveBytes(generateString(32), salt + rnd.Next(999), Iterations);
            AesKey ret = new AesKey
            {
                key = keyGenerator.GetBytes(keyBytes),
                iv = saltGenerator.GetBytes(16)
            };
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static String generateString(int length)
        {
            Random rnd = new Random();
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = (char)rnd.Next((int)'-', (int)'z' + 1);
            }
            return new String(chars);
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PRIVEES //////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void commonBuilder()
        {
            rijndael = new RijndaelManaged();
            
            // Définit le mode utilisé
            rijndael.Mode = CipherMode.CBC;

            // Crée le chiffreur AES - Rijndael
            aesEncryptor = rijndael.CreateEncryptor(AesKey.key, AesKey.iv);

            decryptor = rijndael.CreateDecryptor(AesKey.key, AesKey.iv);
        }
       
        /// <summary>
        /// 
        /// </summary>
        public IEncryptor remakeKey()
        {
            return new NTKAes();
        }
    }
}
