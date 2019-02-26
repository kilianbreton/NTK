/*********************************
* NTK - Netwotk Transport Kernel *
* Database Class (Singleton)     *
* 03/07/2018                     *
**********************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using NTK.IO.Xml;
using System.Data.Sql;
using System.Data.SqlClient;
using NTK.IO;


namespace NTK.Database
{
    public enum Format
    {
        NAME_SIMPLEDATE, NAME_FULLDATE,NAME,FULLDATE,DATE
    }

    public enum Encryption { 
        DES, TripleDES, AES, RSA, SimpleAxb
    }
    
    public abstract class NTKDatabase
    {
        protected Log logs;
        protected static NTKDatabase instance;



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// METHODES ABSTRAITES //////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public abstract IDataReader select(String query, String[,] param = null, String changebase = null);


        public abstract void closeConnection();


        public abstract void insert(String query, String[,] param = null, String changebase = null);


        /// <summary>
        /// Création de base de données. useit = selectionner la nouvelle base.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useit"></param>
        public abstract void createDb(String name, bool useit = true);

        /// <summary>
        /// Création de base de données. à partir d'un objet DBStruct.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useit"></param>
        public abstract void createDb(DBStruct db);

        /// <summary>
        /// requête select retournant un script XML
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useit"></param>
        public abstract String queryOverNTK(String query, Boolean withCol = false, String dataName = null);

        public abstract String backUp(String db, Format format, Encryption encryption);

        public abstract void backUp(String db, String path, Format format, Encryption encryption);

        public abstract void tryConnection();


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// METHODES ABSTRAITES ASYNCHRONES //////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        public abstract Task<IDataReader> selectAsync(String query, String[,] param = null, String changebase = null);


        public abstract Task closeConnectionAsync();


        public abstract Task insertAsync(String query, String[,] param = null, String changebase = null);


        /// <summary>
        /// Création de base de données. useit = selectionner la nouvelle base.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useit"></param>
        public abstract Task createDbAsync(String name, bool useit = true);

        /// <summary>
        /// Création de base de données. à partir d'un objet DBStruct.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useit"></param>
        public abstract Task createDbAsync(DBStruct db);

        /// <summary>
        /// requête select retournant un script XML
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useit"></param>
        public abstract Task<String> queryOverNTKAsync(String query, Boolean withCol = false, String dataName = null);

        public abstract Task<String> backUpAsync(String db, Format format, Encryption encryption);

        public abstract Task backUpAsync(String db, String path, Format format, Encryption encryption);

        public abstract Task tryConnectionAsync();





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// METHODES /////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static NTKDatabase getInstance()
        {
            return instance;
        }

        public Log Logs { get => logs; set => logs = value; }



    }
}
