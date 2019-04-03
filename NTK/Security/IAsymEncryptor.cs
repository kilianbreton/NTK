using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Security
{
    /// <summary>
    /// Interface de chiffrement asymétrique
    /// </summary>
    public interface IAsymEncryptor
    {
        /// <summary>
        /// Chiffrement avec clée publique
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] encryptPublic(byte[] data);

        /// <summary>
        /// Déchiffrement avec clée publique
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] decryptPublic(byte[] data);

        /// <summary>
        /// Chiffrement avec clée publique
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string encryptPublic(string data);

        /// <summary>
        /// Déchiffrement avec clée publique
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string decryptPublic(string data);

        /// <summary>
        /// Chiffrement avec clée privée
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] encryptPrivate(byte[] data);

        /// <summary>
        /// Déchiffrement avec clée privée
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] decryptPrivate(byte[] data);

        /// <summary>
        /// Chiffrement avec clée privée
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string encryptPrivate(string data);

        /// <summary>
        /// Déchiffrement avec clée privée
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string decryptPrivate(string data);

        /// <summary>
        /// Génération de clée
        /// </summary>
        /// <returns></returns>
        string genKey();

        /// <summary>
        /// définition de la clée
        /// </summary>
        /// <param name="key"></param>
        /// <param name="priv"></param>
        void setKey(string key, bool priv = false);

        /// <summary>
        /// Obtient la clée publique ou privée
        /// </summary>
        /// <param name="priv">privée ou publique</param>
        /// <returns></returns>
        string getKey(bool priv = false);

    }
}
