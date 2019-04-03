/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * Enumerations & Structs                                                            *
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
using System.Text;

namespace NTK
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // DECLARATIONS ENUMS & STRUCTS //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    /// <summary>
    /// Statut d'identification
    /// </summary>
    public enum Identification
    {
        /// <summary>
        /// 
        /// </summary>
        Success,
        /// <summary>
        /// 
        /// </summary>
        PasswordError,
        /// <summary>
        /// 
        /// </summary>
        RegKeyError,
        /// <summary>
        /// 
        /// </summary>
        SecKeyError
    }
  
    /// <summary>
    /// Niveau d'un utilisateur (droits)
    /// </summary>
    public enum USER_LVL
    {
        /// <summary>
        /// 
        /// </summary>
        USER,
        /// <summary>
        /// 
        /// </summary>
        ADMIN,
        /// <summary>
        /// 
        /// </summary>
        SUPER_ADMIN,
        /// <summary>
        /// 
        /// </summary>
        SUB_SERVER,
        /// <summary>
        /// 
        /// </summary>
        BOT
    }
   
    /// <summary>
    /// Type d'authentification
    /// </summary>
    public enum CTYPE
    {
        /// <summary>
        /// Authentification basique : login uniquement
        /// </summary>
        BASIC,
        /// <summary>
        /// Authentification login, password avec un seul niveau utilisateur
        /// </summary>
        AUTH_USER_O,
        /// <summary>
        /// Authentification login, password User || Admin
        /// </summary>
        AUTH_ADM,
        /// <summary>
        /// Authentification Utilisateur Admin, Sous-serveurs
        /// </summary>
        AUTH_ADM_SUBS,
        /// <summary>
        /// Authentification du service
        /// </summary>
        OTHER
    }


    /// <summary>
    /// Types de logs
    /// </summary>
    public struct LogsTypes
    {
        /// <summary>
        /// Information
        /// </summary>
        public const String NOTICE = "NOTICE";
        /// <summary>
        /// Erreur
        /// </summary>
        public const String ERROR = "ERROR";
        /// <summary>
        /// Avertissement
        /// </summary>
        public const String WARNING = "WARNING";
        /// <summary>
        /// Erreur critique
        /// </summary>
        public const String CRITICAL = "CRITICAL";
    }
   
    /// <summary>
    /// Séparateurs de commande
    /// </summary>
    public struct Separators
    {
        /// <summary>
        /// ;
        /// </summary>
        public const Char PV = ';';
        /// <summary>
        /// ,
        /// </summary>
        public const Char V = ',';
        /// <summary>
        /// |
        /// </summary>
        public const String PI = "|";
        /// <summary>
        /// 
        /// </summary>
        public const String CD = ">";
        /// <summary>
        /// 
        /// </summary>
        public const String SCD = "{>}";
        /// <summary>
        /// {;}
        /// </summary>
        public const String SPV = "{;}";
        /// <summary>
        /// {,}
        /// </summary>
        public const String SV = "{,}";
        /// <summary>
        /// {|}
        /// </summary>
        public const String SPI = "{|}";
    }

    /// <summary>
    /// Commandes de base de NTK
    /// </summary>
    public struct NTKCommands 
    {
        /// <summary>
        /// Informe le client de la version du serveur
        /// </summary>
        public const String C_VERSION = "C_V_";
        /// <summary>
        /// Informe au client le type de connexion
        /// </summary>
        public const String C_TYPE = "C_TYPE_";
        /// <summary>
        /// Informe au client le service
        /// </summary>
        public const String S_TYPE = "S_TYPE_";
        /// <summary>
        /// Demande l'authentification
        /// </summary>
        public const String C_RL = "C_RL;";
        /// <summary>
        /// Erreur dans C (Connexion)
        /// </summary>
        public const String C_E = "C_E_";
        /// <summary>
        /// Informe si TLS est actifs
        /// </summary>
        public const String C_TLS = "C_TLS_";
        /// <summary>
        /// Arrete la connection
        /// </summary>
        public const String C_STOP = "C_STOP;";
        /// <summary>
        /// Commande de connexion en superadmin
        /// </summary>
        public const String A_SUPERADM = "A_SUPER_ADMIN>";
        /// <summary>
        /// Commande de connexion en admin
        /// </summary>
        public const String A_ADMIN = "A_ADMIN>";                 
        /// <summary>
        /// Commande de connexion en sous-serveur   A_SUBS>#Login,#Pass;
        /// </summary>
        public const String A_SUBS = "A_SUBS>";
        /// <summary>
        /// Commande d'inscription   
        /// </summary>
        public const String A_REG = "A_REG>";
        /// <summary>
        /// Commande de connexion en utilisateur
        /// </summary>
        public const String A_USER = "A_USER>";
        /// <summary>
        /// Commande de connexion en utilisateur    
        /// </summary>
        public const String A_TOKEN = "A_TOKEN>";
        /// <summary>
        /// Commande de connexion en utilisateur 
        /// </summary>
        public const String A_BOT = "A_BOT>";
        /// <summary>
        /// Authentification réussie
        /// </summary>
        public const String A_OK = "A_OK;";
        /// <summary>
        /// Authentification échouée
        /// </summary>
        public const String A_BAD = "A_BAD;";
        /// <summary>
        /// Commande d'erreur     E_#Code;
        /// </summary>
        public const String ERROR = "E_";
        /// <summary>
        /// Commande de message (S pour service)
        /// </summary>
        public const String S_MSG = "S_MSG>";
        /// <summary>
        /// Erreur de syntaxe dans une commande
        /// </summary>
        public const String E_SYNTAX = "BAD_SYNTAX;";
    }
}
