/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * DBStruct Class & Enumerations                                                     *
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
using static NTK.Other.NTKF;

namespace NTK.Database
{

    public enum DBStorage
    {
        MyISAM,InnoDB,MRG_MYISAM,MEMORY,BLACKHOLE,CSV,ARCHIVE
    }



    public class DBStruct
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ATTRIBUTS ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private String name;
        private String storageEngine;
        private String defaultCharset;
        private List<DBSTable> tables = new List<DBSTable>();
        private String sqlMode;
        private int autocommit;
        private String time_zone;

        public string Name { get => name; set => name = value; }
        public string StorageEngine { get => storageEngine; set => storageEngine = value; }
        public List<DBSTable> Tables { get => tables; set => tables = value; }
        public string SqlMode { get => sqlMode; set => sqlMode = value; }
        public int Autocommit { get => autocommit; set => autocommit = value; }
        public string Time_zone { get => time_zone; set => time_zone = value; }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public DBStruct(String name,String storageEngine,String defaultCharset="utf8")
        {
            this.Name = name;
            this.StorageEngine = storageEngine;
            this.defaultCharset = defaultCharset;
        }

        public DBStruct(String sql)
        {
            //TODO: Parser
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   

        public DBSTable addTable(String name, DBSCollation collation = DBSCollation.utf8_bin, DBSColumn firstcolumn = null)
        {
            var ret = new DBSTable(name, collation, firstcolumn);
            return ret;
        }

        public DBSTable getTable(int id)
        {
            return Tables[id];
        }

        public DBSTable getTable(String name)
        {
            int cpt = 0;
            bool stop = false;
            while (!stop)
            {
                if (cpt==Tables.Count || name.Equals(Tables[cpt]))
                {
                    stop = true;
                }
                else
                {
                    cpt++;

                } 
            }
            return Tables[cpt];
        }

        public bool deleteTable(int id)
        {
            var ret = false;
            if (id < Tables.Count)
            {
                Tables.RemoveAt(id);
                ret = true;
            }
            return ret;
        }

        public bool deleteTable(String name)
        {
            bool ret = false;
            int cpt = 0;
            bool stop = false;

            while (!stop)
            {
                if (cpt == Tables.Count)
                {
                    stop = true;
                }
                else if (name.Equals(Tables[cpt]))
                {
                    stop = true;
                    ret = true;
                }
                else
                {
                    cpt++;

                }
            }
            if (ret)
            {
                Tables.RemoveAt(cpt);
            }
            return ret;

        }

        public String print()
        {
            String ret = "-- SQL Code auto-generated by DBN\n";
           
            ret = ret + "-- Date : " + DateTime.Today.ToLongDateString() + "\n";

            for (int i = 0; i < Tables.Count; i++)
            {
                ret=ret+Tables[i].print() + "ENGINE="+storageEngine+" DEFAULT CHARSET="+defaultCharset+";\n\n";
            }

            return ret;
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PRIVEES //////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void parser(String sql)
        {

            String engine;
            String charset;
            if (sql.Contains("SET SQL_MODE"))
            {
                SqlMode = subsep(sql, "SET SQL_MODE =", ";");
                delseps(sql, "SET SQL_MODE =", ";");
            }
            else if (sql.Contains("SET AUTOCOMMIT"))
            {
                SqlMode = subsep(sql, "SET AUTOCOMMIT =", ";");
                delseps(sql, "SET AUTOCOMMIT =", ";");
            }
            else if (sql.Contains("SET time_zone"))
            {
                SqlMode = subsep(sql,"SET time_zone =", ";");
                delseps(sql, "SET time_zone =", ";");
            }
            else if (sql.Contains("ENGINE="))
            {
                engine = subsep(sql, "ENGINE=", "DEFAULT");
                charset = subsep(sql,"DEFAULT CHARSET= ", ";");
                delseps(sql,"ENGINE=", ";");
            }

            //Parser de tables---------------------------------------------------------------------------------------
            while (sql.Contains("CREATE TABLE"))
            {
                 String name;
                if (sql.Contains("IF NOT EXIST"))
                {
                    name = subsep(sql,"CREATE TABLE IF NOT EXIST '", "' (");
                    delseps(sql,"CREATE TABLE IF NOT EXIST '", "' (");
                }
                else
                {
                    name = subsep(sql,"CREATE TABLE '", "' (");
                    delseps(sql,"CREATE TABLE '", "' (");
                }

                var table = new DBSTable(name);
                //Parser de colonnes------------------------------------------------------------------------------------------------------
                while (sql.Contains("'") && sql.IndexOf(",")>=sql.IndexOf("CREATE TABLE"))
                {





                }



            }
        }

    }
}
