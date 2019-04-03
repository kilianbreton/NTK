/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * NTKFunctions Class                                                                *
 * ----------------------------------------------------------------------------------*
 *                                                                                   *
 * LICENSE: This program is free software: you can redistribute it and/or modify     *
 * it under the terms of the GNU General Public License as published by              *
 * the Free Software Foundation, either version 3 of the License, or                 *
 * (at your option) any later version.                                               *
 *                                                                                   *
 * This program is distributed in the hope that it will be useful,                   *
 * but WITHOUT ANY WARRANTY; without even the implied warranty of                    *
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                     *
 * GNU General Public License for more details.                                      *
 *                                                                                   *
 * You should have received a copy of the GNU General Public License                 *
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.             *
 *                                                                                   *
 * ----------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NTK.Database.ORM;


namespace NTK.Other
{
    /// <summary>
    /// Static functions class
    /// </summary>
    public sealed class NTKF
    {
        public static int seed = 48521;
        private static Dictionary<int, String> stopCodes;

        /////////////////////////////////////////////////////////////////////////////

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
        /// Retourne le contenu entre les séparateurs sep1 et sep2 de la chaine text
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
        /// Vérifie si les arguments contiennent des chaines interdites (séparateurs)
        /// </summary>
        /// <param name="text"></param>
        /// <param name="special"></param>
        /// <returns></returns>
        public static bool verifArgs(String text, bool special = false)
        {
            
            bool ret = true;
            if (!special)
            {
                if (text.Contains(Separators.PI) || text.Contains( Separators.V.ToString()) || text.Contains( Separators.PV.ToString()))
                {
                    ret = false;
                }
            }
            else
            {
                if (text.Contains( Separators.SPI) || text.Contains( Separators.SV) || text.Contains(Separators.SPV))
                {
                    ret = false;
                }
            }

            return ret;
        }
        
        /// <summary>
        /// String -> enum
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static CTYPE setCtype(String text)
        {
            CTYPE ret = CTYPE.AUTH_ADM;
            
            if (text.Equals("AUTH_ADM"))
            {
                ret = CTYPE.AUTH_ADM;
            }
            else if (text.Equals("AUTH_ADM_SUBS"))
            {
                ret = CTYPE.AUTH_ADM_SUBS;
            }
            else if (text.Equals("AUTH_USER_O"))
            {
                ret = CTYPE.AUTH_USER_O;
            }
            else if (text.Equals("BASIC"))
            {
                ret = CTYPE.BASIC;
            }
            return ret;
        }

        /// <summary>
        /// String -> Enum
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static USER_LVL setULVL(String text)
        {
            USER_LVL ret = USER_LVL.USER;
            if (text.Equals("ADMIN"))
            {
                ret = USER_LVL.ADMIN;
            }
            else if (text.Equals("BOT"))
            {
                ret = USER_LVL.BOT;
            }
            else if (text.Equals("SUB_SERVER"))
            {
                ret = USER_LVL.SUB_SERVER;
            }
            else if (text.Equals("USER"))
            {
                ret = USER_LVL.USER;
            }
            else if (text.Equals("SUPER_ADMIN"))
            {
                ret = USER_LVL.SUPER_ADMIN;
            }
            return ret;
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
                chars[i] = (char)rnd.Next((int)startRnd, (int)'z' + 1);
            }

            return new string(chars);
        }

        /// <summary>
        /// Retourne l'id d'un utilisateur dans une liste grâce à son login
        /// </summary>
        /// <param name="login"></param>
        /// <param name="lst"></param>
        /// <returns></returns>
        public static int getUserid(String login, List<NTKUser> lst)
        {
            int cpt = 0;
            bool stop = false;

            while (!stop)
            {
                if(cpt < lst.Count && lst[cpt].Login.Equals(login))
                {
                    stop = true;
                }
                else
                {
                    if(cpt == lst.Count) {
                        stop = true;
                        cpt = -1;
                    }
                    else
                    { 
                        cpt++;
                    }
                }
            }
            return cpt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="userlist"></param>
        /// <returns></returns>
        public static bool alreadyConnected(String login, List<NTKUser> userlist)
        {
            bool ret = false;
            int cpt = 0;
            if (userlist != null)
            {
                while ((!ret) && cpt < userlist.Count)
                {
                    if (login.Equals(userlist[cpt].Login))
                    {
                        ret = true;
                    }
                    else
                    {
                        cpt++;
                    }
                }
            }
            return ret;
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

        public static Boolean checkTokens(List<Token> lst,String token,ref String login)
        {
            bool ret = false;
            bool end = false;
            int cpt = 0;
            while (!end)
            {
                if(cpt == lst.Count)
                {
                    end = true;
                }
                else if (lst[cpt].check(token))
                {
                    login = lst[cpt].Login;
                    ret = true;
                    end = true;
                }
                else
                {
                    cpt++;
                }
            }
            return ret;
        }

        public static void initModels()
        {
          
        }

        public static String getStopInfo(int code)
        {
            if(stopCodes == null)
            {
                stopCodes = new Dictionary<int, String>
                {
                    { 0, "UNDEFINED" },
                    { 1, "MANUAL STOP" },
                    { 2, "FORCED STOP (Critical error)" },
                    { 3, "FORCED STOP" },
                    { 4, "UPDATE" },
                    { 5, "NEW EXTENSION" },
                    { 6, "BACKUP" },
                    { 7, "SYSTEM UPDATE" }
                };
            }


            if (code < stopCodes.Count)
            {
                return stopCodes[code];
            }
            else
            {
                return "UNKNOW CODE";
            }
        }
    }
}