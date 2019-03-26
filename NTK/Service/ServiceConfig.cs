using NTK.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Service
{
    /// <summary>
    /// Configuration d'un service NTK
    /// </summary>
    public struct ServiceConfig
    {
        /// <summary>
        /// Nom complet du service
        /// </summary>
        public String name;
        /// <summary>
        /// Identifiant du service
        /// </summary>
        public String stype;
        /// <summary>
        /// Si le serveur doit utiliser l'authentification du service
        /// </summary>
        public bool authentification;
        /// <summary>
        /// utilise un boucle d'écoute simple à la place de s_listen
        /// </summary>
        public bool useBasicListen;
        /// <summary>
        /// Liste des tables
        /// </summary>
        public String[] table;
        /// <summary>
        /// Structure de base de données
        /// </summary>
        public DBStruct database;
        /// <summary>
        /// Connection à une base de données
        /// </summary>
        public NTKDatabase dbc;
    }
}
