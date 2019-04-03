/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * Database Abstract Class                                                           *
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
    /// <summary>
    /// 
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// 
        /// </summary>
        NAME_SIMPLEDATE,
        /// <summary>
        /// 
        /// </summary>
        NAME_FULLDATE,
        /// <summary>
        /// 
        /// </summary>
        NAME,
        /// <summary>
        /// 
        /// </summary>
        FULLDATE,
        /// <summary>
        /// 
        /// </summary>
        DATE
    }
   
    /// <summary>
    /// Algorithmes de chiffrements
    /// </summary>
    public enum Encryption {
        /// <summary>
        /// 
        /// </summary>
        DES,
        /// <summary>
        /// 
        /// </summary>
        TripleDES,
        /// <summary>
        /// 
        /// </summary>
        AES,
        /// <summary>
        /// 
        /// </summary>
        RSA,
        /// <summary>
        /// 
        /// </summary>
        SimpleAxb
    }

    /// <summary>
    /// Classe abstraite de connexion à une base de données
    /// </summary>
    public abstract class NTKDatabase
    {
        /// <summary>
        /// 
        /// </summary>
        protected Log logs;
        /// <summary>
        /// 
        /// </summary>
        protected static NTKDatabase instance;



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES ABSTRAITES //////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="changebase"></param>
        /// <returns></returns>
        public abstract IDataReader select(String query, String[,] param = null, String changebase = null);

        /// <summary>
        /// 
        /// </summary>
        public abstract void closeConnection();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="changebase"></param>
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
        /// <param name="db"></param>
        public abstract void createDb(DBStruct db);

        /// <summary>
        /// requête select retournant un script XML
        /// </summary>
        /// <param name="query"></param>
        /// <param name="withCol"></param>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public abstract String queryOverNTK(String query, Boolean withCol = false, String dataName = null);
     
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="format"></param>
        /// <param name="encryption"></param>
        /// <returns></returns>
        public abstract String backUp(String db, Format format, Encryption encryption);
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="path"></param>
        /// <param name="format"></param>
        /// <param name="encryption"></param>
        public abstract void backUp(String db, String path, Format format, Encryption encryption);
      
        /// <summary>
        /// 
        /// </summary>
        public abstract void tryConnection();


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES ABSTRAITES ASYNCHRONES //////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="changebase"></param>
        /// <returns></returns>
        public abstract Task<IDataReader> selectAsync(String query, String[,] param = null, String changebase = null);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract Task closeConnectionAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="changebase"></param>
        /// <returns></returns>
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
        /// <param name="db"></param>
        public abstract Task createDbAsync(DBStruct db);

        /// <summary>
        /// requête select retournant un script XML
        /// </summary>
        /// <param name="query"></param>
        /// <param name="withCol"></param>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public abstract Task<String> queryOverNTKAsync(String query, Boolean withCol = false, String dataName = null);
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="format"></param>
        /// <param name="encryption"></param>
        /// <returns></returns>
        public abstract Task<String> backUpAsync(String db, Format format, Encryption encryption);
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="path"></param>
        /// <param name="format"></param>
        /// <param name="encryption"></param>
        /// <returns></returns>
        public abstract Task backUpAsync(String db, String path, Format format, Encryption encryption);
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract Task tryConnectionAsync();





        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES /////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static NTKDatabase getInstance()
        {
            return instance;
        }
       
        /// <summary>
        /// 
        /// </summary>
        public Log Logs { get => logs; set => logs = value; }



    }
}
