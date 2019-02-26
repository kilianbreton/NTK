using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTK
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// DECLARATIONS ENUMS & STRUCTS //////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum Identification
    {
        Success, PasswordError, RegKeyError, SecKeyError
    }

    public enum USER_LVL
    {
        USER, ADMIN, SUPER_ADMIN, SUB_SERVER, BOT
    }

    public enum CTYPE
    {
        BASIC, AUTH_USER_O, AUTH_ADM, AUTH_ADM_SUBS,OTHER
    }

    


    public struct LogsTypes
    {
        public const String NOTICE = "NOTICE";
        public const String ERROR = "ERROR";
        public const String WARNING = "WARNING";
        public const String CRITICAL = "CRITICAL";
    }

    public struct Separators
    {
        public const Char PV = ';';
        public const Char V = ',';
        public const String PI = "|";
        public const String SPV = "{;}";
        public const String SV = "{,}";
        public const String SPI = "{|}";
    }

    public struct NTKCommands  //Commandes
    {
        public const String C_VERSION = "C_V_";                              //Informe le client de la version du serveur
        public const String C_TYPE = "C_TYPE_";                             //Informe au client le type de connexion
        public const String S_TYPE = "S_TYPE_";                            //Informe au client le service
        public const String C_RL = "C_RL;";                               //Demande l'authentification
        public const String C_E = "C_E_";                                //Erreur dans C (Connexion)
        public const String C_TLS = "C_TLS_";                           //Informe si TLS est actif
        public const String C_STOP = "C_STOP;";                        //Arrete la connection
        public const String A_SUPERADM = "A_SUPER_ADMIN>";            //Commande de connexion en superadmin
        public const String A_ADMIN = "A_ADMIN>";                    //Commande de connexion en admin
        public const String A_SUBS = "A_SUBS>";                      //Commande de connexion en sous-serveur   A_SUBS>#Login,#Pass;
        public const String A_REG = "A_REG>";                       //Commande d'inscription                   Voir doc
        public const String A_USER = "A_USER>";                    //Commande de connexion en utilisateur      Voir doc
        public const String A_TOKEN = "A_TOKEN>";                 //Commande de connexion en utilisateur      Voir doc
        public const String A_BOT = "A_BOT>";                    //Commande de connexion en utilisateur      Voir doc

        public const String A_OK = "A_OK;";                      //Authentification réussie
        public const String A_BAD = "A_BAD;";                   //Authentification échouée
        public const String ERROR = "E_";                      //Commande d'erreur     E_#Code;
        public const String S_MSG = "S_MSG>";                 //Commande de message (S pour service)  Voir doc
    }
}
