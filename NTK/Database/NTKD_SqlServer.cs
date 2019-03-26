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
    /// Classe de connection à SqlServer
    /// </summary>
    public class NTKD_SqlServer : NTKDatabase
    {
        private static NTKD_SqlServer instance;

        private SqlConnection connection;
        private String host;
        private String user;
        private String pass;
        private String name;



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS & SINGLETON ////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        private NTKD_SqlServer(String host, String user, String pass, String name, Boolean test = false)
        {

            this.host = host;
            this.user = user;
            this.pass = pass;
            this.name = name;
            this.connection = new SqlConnection("Data Source="+host+";Initial Catalog = "+name+"; User ID = "+user+"; Password = "+pass);
            this.connection.Open();
        }



        public static NTKD_SqlServer getInstance(String host, String user, String pass, String name, Boolean test = false)
        {
            if (instance == null)
            {
                instance = new NTKD_SqlServer(host, user, pass, name, test);
            }
            return instance;
        }



        public static bool isNull()
        {
            return (instance == null);
        }

        public static NTKD_SqlServer overrideInstance(String host, String user, String pass, String name, Boolean test = false)
        {
            instance = new NTKD_SqlServer(host, user, pass, name, test);
            return instance;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public override void closeConnection()
        {
            connection.Close();
        }

        public override void createDb(string name, bool useit = true)
        {
            
        }

        public override void createDb(DBStruct db)
        {
            throw new NotImplementedException();
        }

        public override void insert(string query, string[,] param = null, string changebase = "none")
        {
            throw new NotImplementedException();
        }

        public override string queryOverNTK(string query, bool withCol = false, string dataName = null)
        {
            XmlDocument xmlp = new XmlDocument();
            var root = xmlp.addNode("DATASQL");

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            var sdr = cmd.ExecuteReader();
            var nbcol = sdr.FieldCount;
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
                    root.addChild(sdr.GetName(i));
                }
            }

            var cpt = 0; //Compteur d'enregistrements
            var col = sdr.FieldCount;
            while (sdr.Read())
            {
                for (int i = 0; i < col; i++)
                {
                    var data = "null";
                    if (!sdr.IsDBNull(i))
                    {
                        data = sdr.GetString(i);
                    }

                    root.getChild(i).addChild(cpt.ToString()).setValue(data);

                }
                cpt++;
            }
            if (dataName != null)
            {
                root.setName(xmlp.getNode(0).getName() + "_" + dataName);
            }

            return xmlp.print();
        }

        public override IDataReader select(string query, string[,] param = null, string changebase = "none")
        {
            if(changebase != "none")
            {
                connection.ChangeDatabase(changebase);

            }
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = query;
            if(param != null)
            {
                for(int i = 0; i < param.Length; i++)
                {
                    cmd.Parameters.Add(new SqlParameter(param[i,0], param[i,1]));
                }
            }
           return cmd.ExecuteReader();
        }

        public override void tryConnection()
        {
            throw new NotImplementedException();
        }

    

        public override string backUp(string db, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }

        public override void backUp(string db, string path, Format format, Encryption encryption)
        {
            throw new NotImplementedException();
        }

        public override Task<IDataReader> selectAsync(string query, string[,] param = null, string changebase = null)
        {
            throw new NotImplementedException();
        }

        public override Task closeConnectionAsync()
        {
            throw new NotImplementedException();
        }

        public override Task insertAsync(string query, string[,] param = null, string changebase = null)
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

        public override Task<string> queryOverNTKAsync(string query, bool withCol = false, string dataName = null)
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

        public override Task tryConnectionAsync()
        {
            throw new NotImplementedException();
        }
    }
}
