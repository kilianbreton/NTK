using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Security
{
    /// <summary>
    /// Interface de chiffrement symetrique
    /// </summary>
    public interface IEncryptor
    {
        /// <summary>
        /// Chiffre une chaine de caractères
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string encrypt(string text);

        /// <summary>
        /// Déchiffre une chaine de caractères
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        string decrypt(string text);
        
        /// <summary>
        /// Déchiffre des octets
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        byte[] decrypt(byte[] text);

        /// <summary>
        /// Chiffre des octets
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        byte[] encrypt(byte[] text);

        /// <summary>
        /// défini la clée de chiffrement
        /// </summary>
        /// <param name="key"></param>
        void setKey(string key);
        
        /// <summary>
        /// Retourne la clée
        /// </summary>
        /// <returns></returns>
        string getKey();

        /// <summary>
        /// Retourne le nom de l'olgorithme
        /// </summary>
        /// <returns></returns>
        string getName();

        /// <summary>
        /// Créé une nouvelle instance avec une nouvelle clée
        /// </summary>
        IEncryptor remakeKey();
    }
}
