using System;


namespace NTK.Exceptions
{
    /// <summary>
    /// Erreur de sélection de la méthode d'authentification
    /// </summary>
    public class AuthentificationUndefinedException : Exception
    {
        private const string MSG = "La méthode d'authentification du service : '";
        private const string MSG2 = "' n'est pas autorisée ou implémentée";

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="serviceName"></param>
        public AuthentificationUndefinedException(string serviceName) : base(MSG + serviceName + MSG2) { }

    }
}
