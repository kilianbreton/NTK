using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database
{
    /// <summary>
    /// Table
    /// </summary>
    public class DBSTable
    {
        private String name;
        private List<DBSColumn> columns = new List<DBSColumn>();
        private DBSCollation collation;

        public DBSTable(String name,DBSCollation collation = DBSCollation.utf8_bin, DBSColumn firstcolumn = null) 
        {
            this.Name = name;
            this.Collation = collation;
            if(firstcolumn != null)
            {
                Columns.Add(firstcolumn);
            }

        }


        public String print()
        {
            String ret = "CREATE TABLE IF NOT EXISTS `" + name + "` (\n";
            bool pk1 = false;
            for(int i = 0;i< columns.Count; i++)
            {
              
                ret = ret + columns[i].print();
                if (i < columns.Count - 1)
                {
                    ret = ret + ",\n";
                }
            }
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i].PrimaryKey)
                {
                    if (pk1)
                    {
                        ret = ret + ",`" + columns[i].Name + "`";
                    }
                    else
                    {
                        ret = ret + ",\nPRIMARY KEY(`" + columns[i].Name + "`)\n";
                    }
                }
            }
            if (pk1)
            {
                ret = ret + ")\n";
            }

            ret = ret + ")";
            return ret;
        }






        public string Name { get => name; set => name = value; }
        public List<DBSColumn> Columns { get => columns; set => columns = value; }
        public DBSCollation Collation { get => collation; set => collation = value; }

       
    }
}
