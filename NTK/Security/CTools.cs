using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace NTK.Security
{
    public enum Hashs
    {
        MD5,SHA1,SHA256
    }

 
    public static class CTools
    {

        public static String dictionary(String[] dictionary, String hash, Hashs hashtype, int nbcombine = 0)
        {
            String ret = "";
            String tmp = "";
            String[] finaldic = dictionary;
            //Préparation du dcitionaire
            for(int i = 0; i < nbcombine; i++)
            {
                finaldic = combine(finaldic, dictionary);
            }


            //bruteforce

            bool end = false;
            int cpt = 0;

            while(!end)
            {
                //Hashage
                switch (hashtype)
                {
                    case Hashs.MD5:

                        break;
                    case Hashs.SHA1:
                    
                        break;
                    case Hashs.SHA256:
                        tmp = sha256(finaldic[cpt]);
                        break;
                }

                //Affichage
                Console.WriteLine("Generated string : "+finaldic[cpt]);
                Console.WriteLine(tmp +" ?== "+hash+"   :   "+cpt);
                Console.WriteLine(generStr(Console.WindowLeft-1,"-"));
                //comparaison
                if (tmp.Equals(hash))
                {
                    ret = finaldic[cpt];
                    end = true;
                    Console.WriteLine("--- Fouded : " + finaldic[cpt]);
                }

                //Vérification OutOfRange
                if (cpt == finaldic.Length - 1)
                {
                    ret = "--Not found--";
                    end = true;
                }


                cpt++;
            }




            return ret;
        }

        private static String[] combine(String[] tab1, String[] tab2)
        {
            int cpt = 0;
            String[] ret = new String[(tab1.Length*tab2.Length)+tab1.Length];

            for (int i = 0; i < tab1.Length; i++)
            {
                ret[i] = tab1[i];
            }

            for (int i = tab1.Length; i < tab1.Length; i++)
            {
                for(int x = 0; x < tab2.Length; x++)
                {
                    ret[cpt] = tab1[i] + tab2[x];
                    cpt++;
                }
            }


            return ret;
        }

        public static void generateDic(String path)
        {

        }






        public static String generStr(int nb, String str)
        {
            var ret = "";
            for (int i = 0; i < nb; i++)
            {
                ret += str;
            }
            return ret;
        }



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
            return hashString;
        }


    }
}
   