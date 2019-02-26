using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Threading.Tasks;

namespace NTK.Database
{
    public class NTKD_Sqlite : NTKDatabase
    {
        private static NTKD_Sqlite instance;
        private SQLiteConnection con;
        private String path;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// CONSTRUCTEURS & SINGLETON ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        private NTKD_Sqlite(String path, bool isNew = false, bool compress = false)
        {
            this.path = path;
            con = new SQLiteConnection("Data Source="+path+";Version=3;New="+isNew.ToString()+";Compress="+compress.ToString()+";");

        }



        public static NTKD_Sqlite getInstance(String path, bool isNew = false, bool compress = false)
        {
            if (instance == null)
            {
                instance = new NTKD_Sqlite(path, isNew, compress);
            }
            return instance;
        }



        public static bool isNull()
        {
            return (instance == null);
        }

        public static NTKD_Sqlite overrideInstance(String path, bool isNew = false, bool compress = false)
        {
            instance = new NTKD_Sqlite(path,isNew,compress);
            return instance;
        }

        public override string backUp(string db, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }

        public override void backUp(string db, string path, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }

        public override Task<string> backUpAsync(string db, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }

        public override Task backUpAsync(string db, string path, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////









        public override void closeConnection()
        {
            con.Close();
        }

        public override Task closeConnectionAsync()
        {
            throw new NotImplementedException();
        }

        public override void createDb(string name, bool useit = true)
        {
            throw new NotImplementedException();
        }

        public override void createDb(DBStruct db)
        {
            throw new NotImplementedException();
        }

        public override Task createDbAsync(string name, bool useit = true)
        {
            throw new NotImplementedException();
        }

        public override Task createDbAsync(DBStruct db)
        {
            throw new NotImplementedException();
        }

        public override void insert(string query, string[,] param = null, string changebase = "none")
        {
            con.Open();
            if(changebase != "none")
            {
                con.ChangeDatabase(changebase);
            }
            var cmd = con.CreateCommand();
            cmd.CommandText = query;

            if(param != null)
            {
                for(int i = 0; i < param.GetLength(0); i++)
                {
                    cmd.Parameters.AddWithValue(param[i, 0], param[i, 1]);
                }
            }
            cmd.ExecuteNonQuery();

            
        }

        public override Task insertAsync(string query, string[,] param = null, string changebase = null)
        {
            throw new NotImplementedException();
        }

        public override string queryOverNTK(string query, bool withCol = false, string dataName = null)
        {
            throw new NotImplementedException();
        }

        public override Task<string> queryOverNTKAsync(string query, bool withCol = false, string dataName = null)
        {
            throw new NotImplementedException();
        }

        public override IDataReader select(string query, string[,] param = null, string changebase = "none")
        {
            con.Open();
            if (changebase != "none")
            {
                con.ChangeDatabase(changebase);
            }
            var cmd = con.CreateCommand();
            cmd.CommandText = query;

            if (param != null)
            {
                for (int i = 0; i < param.GetLength(0); i++)
                {
                    cmd.Parameters.AddWithValue(param[i, 0], param[i, 1]);
                }
            }
            return cmd.ExecuteReader();
        }

        public override Task<IDataReader> selectAsync(string query, string[,] param = null, string changebase = null)
        {
            throw new NotImplementedException();
        }

        public override void tryConnection()
        {
            try
            {

                con.Open();
                con.Close();
               

            }
            catch (Exception e)
            {
                Console.WriteLine("DB ERROR");
              
            }
        }

        public override Task tryConnectionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
