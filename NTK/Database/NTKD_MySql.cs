/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * Mysql Class                                                                       *
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
using MySql.Data.MySqlClient;
using NTK.IO.Xml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database
{
    /// <summary>
    /// Classe de connexion à une base Mysql
    /// </summary>
    public class NTKD_MySql : NTKDatabase
    {
        private String host;
        private String user;
        private String pass;
        private String name;
        private MySqlConnection mysqlc;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS & SINGLETON /////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <param name="test"></param>
        private NTKD_MySql(String host, String user, String pass, String name, Boolean test = false)
        {
            this.host = host;
            this.user = user;
            this.pass = pass;
            this.name = name;
            InitMysqlConnexion();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        public static NTKDatabase getInstance(String host, String user, String pass, String name, Boolean test = false)
        {
            if (instance == null)
            {
                instance = new NTKD_MySql(host, user, pass, name, test);
            }
            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool isNull()
        {
            return (instance == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <param name="name"></param>
        /// <param name="test"></param>
        /// <returns></returns>
        public static NTKDatabase overrideInstance(String host, String user, String pass, String name, Boolean test = false)
        {
            instance = new NTKD_MySql(host, user, pass, name, test);
            return instance;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Requête mysql select 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="changebase"></param>
        /// <returns>MysqlDataReader</returns>
        public override IDataReader select(String query, String[,] param = null, String changebase = "none")
        {
            MySqlDataReader ret = null;

            try
            {
                if (mysqlc.State.Equals(ConnectionState.Open))
                {
                    this.mysqlc.Close();
                }
                this.mysqlc.Open();


                MySqlCommand cmd = this.mysqlc.CreateCommand();

                // INSERT INTO contact (id, name, tel) VALUES (@id, @name, @tel)
                cmd.CommandText = query;

                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(param[i, 0], param[i, 1]);
                    }
                }
                ret = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void closeConnection()
        {
            this.mysqlc.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="changebase"></param>
        public override void insert(String query, String[,] param = null, String changebase = null)
        {
            try
            {
                if (mysqlc.State.Equals(ConnectionState.Open))
                {
                    this.mysqlc.Close();
                }
                this.mysqlc.Open();
                MySqlCommand cmd = this.mysqlc.CreateCommand();

                // INSERT INTO contact (id, name, tel) VALUES (@id, @name, @tel)
                cmd.CommandText = query;

                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        //@param,value
                        cmd.Parameters.AddWithValue(param[i, 0], param[i, 1]);
                    }
                }
                cmd.ExecuteNonQuery();

                this.mysqlc.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }          

        /// <summary>
        /// Création de base de données. useit = selectionner la nouvelle base.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useit"></param>
        public override void createDb(String name, bool useit = true)
        {
            insert("CREATE DATABASE IF NOT EXISTS `" + name + "`");
            if (useit)
            {
                mysqlc.ChangeDatabase(name);
            }
        }
      
        /// <summary>
        /// Création de base de données. à partir d'un objet DBStruct.
        /// </summary>
        /// <param name="db"></param>
        public override void createDb(DBStruct db)
        {
            insert("CREATE DATABASE IF NOT EXISTS `" + db.Name + "`;\n");
            mysqlc.Open();
            // mysqlc.ChangeDatabase(db.Name);
            insert("USE " + db.Name + ";\n" + db.print());
            mysqlc.Close();
        }

        /// <summary>
        /// requête select retournant un script XML
        /// </summary>
        /// <param name="query"></param>
        /// <param name="withCol"></param>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public override String queryOverNTK(String query, Boolean withCol = false, String dataName = null)
        {
            String ret = "";
            MySqlDataReader msr = null;
            try
            {
                //Représentation XML
                XmlDocument xmlp = new XmlDocument();
                var root = xmlp.addNode("DATASQL");

                //Connexion MYSQL
                if (mysqlc.State.Equals(ConnectionState.Open))
                {
                    this.mysqlc.Close();
                }
                this.mysqlc.Open();
                MySqlCommand cmd = this.mysqlc.CreateCommand();
                cmd.CommandText = query;
                msr = cmd.ExecuteReader();
                var nbcol = msr.FieldCount;
                if (!withCol)
                {
                    //Création des balises (qui représente les colonnes)
                    for (int i = 0; i < nbcol; i++)
                    {
                        root.addChild(i.ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < nbcol; i++)
                    {
                        root.addChild(msr.GetName(i));
                    }
                }

                //Lecture des données
                var cpt = 0; //Compteur d'enregistrements
                var col = msr.FieldCount;
                while (msr.Read())
                {
                    for (int i = 0; i < col; i++)
                    {
                        var data = "null";
                        if (!msr.IsDBNull(i))
                        {
                            data = msr.GetString(i);
                        }

                        root.getChild(i).addChild(cpt.ToString()).setValue(data);

                    }
                    cpt++;
                }
                if (dataName != null)
                {
                    xmlp.getNode(0).setName(xmlp.getNode(0).getName() + "_" + dataName);
                }



                ret = xmlp.printWA();

                //    this.mysqlc.Close();
            }
            catch (Exception e)
            {
                ret = e.Message;
                var place = mysqlc.Database;
                addLogs("ERROR", ret, place);
                if (!Other.Log_NTK.isNull())
                {
                    var log = Other.Log_NTK.getInstance("");
                    log.add(new Other.LogLine_NTK(LogsTypes.CRITICAL, "QueryOverNTK Error : " + e.Message + "  " + e.StackTrace, DateTime.Now));
                }

                // throw new NTKErrors(17);
            }

            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        public override void tryConnection()
        {
            try
            {
                
                mysqlc.Open();

                if (mysqlc.State.Equals(ConnectionState.Closed) || mysqlc.State.Equals(ConnectionState.Broken))
                {
                    addLogs(LogsTypes.CRITICAL, mysqlc.State.ToString(), "Server");
                }
                else
                {
                    addLogs(LogsTypes.NOTICE, "Tryconnect : success", "Server");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("DB ERROR");
                addLogs(LogsTypes.CRITICAL, e.Message, "Server");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="format"></param>
        /// <param name="encryption"></param>
        /// <returns></returns>
        public override string backUp(string db, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="path"></param>
        /// <param name="format"></param>
        /// <param name="encryption"></param>
        public override void backUp(string db, string path, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ASYNCHRONES ////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="changebase"></param>
        /// <returns></returns>
        public override Task<IDataReader> selectAsync(string query, string[,] param = null, string changebase = null)
        {
            Task<IDataReader> ret = null;
            try
            {
                if (mysqlc.State.Equals(ConnectionState.Open))
                {
                    this.mysqlc.Close();
                }
                this.mysqlc.Open();


                MySqlCommand cmd = this.mysqlc.CreateCommand();

                // INSERT INTO contact (id, name, tel) VALUES (@id, @name, @tel)
                cmd.CommandText = query;

                if (param != null)
                {
                    for (int i = 0; i < param.Length; i++)
                    {
                        cmd.Parameters.AddWithValue(param[i, 0], param[i, 1]);
                    }
                }
                //Task from ....
                ret = Task.FromResult<IDataReader>(cmd.ExecuteReader());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Task closeConnectionAsync()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="param"></param>
        /// <param name="changebase"></param>
        /// <returns></returns>
        public override Task insertAsync(string query, string[,] param = null, string changebase = null)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="useit"></param>
        /// <returns></returns>
        public override Task createDbAsync(string name, bool useit = true)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public override Task createDbAsync(DBStruct db)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="withCol"></param>
        /// <param name="dataName"></param>
        /// <returns></returns>
        public override Task<string> queryOverNTKAsync(string query, bool withCol = false, string dataName = null)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="format"></param>
        /// <param name="encryption"></param>
        /// <returns></returns>
        public override Task<string> backUpAsync(string db, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="path"></param>
        /// <param name="format"></param>
        /// <param name="encryption"></param>
        /// <returns></returns>
        public override Task backUpAsync(string db, string path, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Task tryConnectionAsync()
        {
            throw new NotImplementedException();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PRIVEES //////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void addLogs(String type, String text, String place)
        {
            if (logs != null)
            {
                logs.add(new LogLine_Database(type, text, place, DateTime.Now));
                logs.flush();
            }
            else
            {
                Console.WriteLine("nolog");
            }
        }

        private void InitMysqlConnexion()
        {
            // Création de la chaîne de connexion 
            string connectionString = "SERVER=" + host + "; DATABASE=" + name + "; UID=" + user + "; PWD=" + pass + ";";
            this.mysqlc = new MySqlConnection(connectionString);
           
        }

        private void InitNewBase(String name)
        {
            string connectionString = "SERVER=" + this.host + "; DATABASE=" + name + "; UID=" + this.user + "; PWD=" + this.pass;
            this.mysqlc = new MySqlConnection(connectionString);
         
        }

    }
}