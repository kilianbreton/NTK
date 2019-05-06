using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace NTK.Database
{
    /// <summary>
    /// Encapsulation de l'interface IDataReader
    /// </summary>
    public class QueryResult
    {
        IDataReader reader;

        public QueryResult(IDataReader reader)
        {
            this.reader = reader;
        }

        public bool read()
        {
            return reader.Read();
        }

        public object getValue(int i)
        {
            return reader.GetValue(i);
        }

        public object getValue(string colName)
        {
            object ret = null;

            int cpt = 0;
            bool end = false;
            while (cpt < reader.FieldCount && !end)
            {
                if (reader.GetName(cpt).Equals(colName))
                {
                    ret = reader.GetValue(cpt);
                    end = true;
                }
                cpt++;
                
            }
            return ret;
        }

        public string getString(string colName)
        {
            return (string)getValue(colName);
        }

        public bool getBool(string colName)
        {
            return (bool)getValue(colName);
        }

        public int getInt(string colName)
        {
            return (int)getValue(colName);
        }

        public char getChar(string colName)
        {
            return (char)getValue(colName);
        }

        public long getLong(string colName)
        {
            return (long)getValue(colName);
        }

        public DateTime getDateTime(string colName)
        {
            return (DateTime)getValue(colName);
        }

        



    }
}
