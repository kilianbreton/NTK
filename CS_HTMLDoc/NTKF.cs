using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace CS_HTMLDoc
{
    public sealed class NTKF
    {
        public static int seed = 48521;
        private static Dictionary<int, String> stopCodes;

        public NTKF() {}



        public static String replaceNs(String text)
        {
            text = text.Replace("System.", "");
            text = text.Replace("Collections.Generic.", "");
            text = text.Replace("Collections.", "");

            return text;
        }


        /// <summary>
        /// retourne la chaine text sans sep1, sep2 et le contenu entre les 2
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sep1"></param>
        /// <param name="sep2"></param>
        /// <returns></returns>
        public static String delseps(String text, String sep1, String sep2)
        {
            return NTKF.subsep(text, 0, sep1) + NTKF.subsep(text, sep2);
        }

   

        /// <summary>
        /// Retourne le contenu entre les séparateurs sep1 & sep2 de la chaine text
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sep1"></param>
        /// <param name="sep2"></param>
        /// <returns></returns>
        public static String subsep(String text, String sep1, String sep2)
        {
            int startCut = text.IndexOf(sep1) + sep1.Length;
            int lengthCut = text.IndexOf(sep2) - startCut;
            return text.Substring(startCut, lengthCut);
        }


        /// <summary>
        /// Coupe la chaine text du caractère n° sep1 au sep2(String)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sep1"></param>
        /// <param name="sep2"></param>
        /// <returns></returns>
        public static String subsep(String text, int sep1, String sep2)
        {

            int lengthCut = text.IndexOf(sep2) - sep1;
            return text.Substring(sep1, lengthCut);
        }


        /// <summary>
        /// Coupe la chaine text du sep1 juqu'à la fin
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sep1"></param>
        /// <returns></returns>
        public static String subsep(String text, String sep1)
        {
            int startCut = text.IndexOf(sep1) + sep1.Length;

            int lengthCut = text.Length - startCut;

            return text.Substring(startCut, lengthCut);
        }

        /// <summary>
        /// retourne le nombre de charactères lettre dans une chaine
        /// </summary>
        /// <param name="chaine"></param>
        /// <param name="lettre"></param>
        /// <returns></returns>
        public static int nbChar(string chaine, char lettre)
        {
            int nb = 0;
            foreach (char c in chaine)
            {
                if (c == lettre) nb++;
            }
            return nb;
        }
  
      
     
        /// <summary>
        /// Retourne le Hash sha256 de text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string sha256(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString.ToUpper();
        }


        /// <summary>
        /// Génère une chaine aléatoire de longueur length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static String generateToken(int length, bool noSpecial = false)
        {
            char startRnd = '-';
            if (noSpecial){startRnd = 'a'; }

            Random rnd = new Random();
            seed = seed * 2 + (rnd.Next(66666)/4);
            rnd = new Random(seed);
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = (char)rnd.Next((int)'-', (int)'z' + 1);
            }

            return new string(chars);
        }

   

        
        /// <summary>
        /// Retourne une chaine de longueur nb uniquement composé de str
        /// </summary>
        /// <param name="nb"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static String generStr(int nb, Char str)
        {
            var ret = "";
            for (int i = 0; i < nb; i++)
            {
                ret += str;
            }
            return ret;
        }


    }
}