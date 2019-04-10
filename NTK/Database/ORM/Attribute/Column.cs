using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Database;

namespace NTK.Database.ORM.Attribute
{
    [Serializable()]
    public class Column : System.Attribute
    {
        private string columnName;
        private DBSType type;
        private int length;
        private bool primaryKey;
        private bool autoIncrement;

        public Column(string columnName, DBSType type, int length = 255, bool primaryKey = false)
        {
            this.columnName = columnName;
            this.type = type;
            this.length = length;
            this.primaryKey = primaryKey;
            this.autoIncrement = autoIncrement;
        }

        public string ColumnName { get => columnName; set => columnName = value; }
        public DBSType Type { get => type; set => type = value; }
        public int Length { get => length; set => length = value; }
        public bool PrimaryKey { get => primaryKey; set => primaryKey = value; }
        public bool AutoIncrement { get => autoIncrement; set => autoIncrement = value; }
       
    }
}
