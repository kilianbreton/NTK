using NTK.Database.ORM.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database.ORM.Core
{
    /// <summary>
    /// Serialisation d'entité en xml ou DBS (Object)
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public class EntitySerializer<T>
    {
        private Type entity;

        /// <summary>
        /// Instanciation
        /// </summary>
        public EntitySerializer()
        {
            this.entity = typeof(T);
        }


        /// <summary>
        /// Retourne une entité convertie en DBStruct
        /// </summary>
        /// <returns></returns>
        public DBSTable getDBS()
        {
            var tableAn = entity.GetCustomAttribute<Table>();
            string tableName = tableAn.Name;
            DBSCollation charset = tableAn.Charset;
            


            DBSTable table = new DBSTable(tableName,charset);

            var fields = entity.GetMembers(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MemberInfo m in fields)
            {
                try
                {
                    //Annotation Colonne======================================================================
                    var colAn = m.GetCustomAttribute<Column>();
                    string colName = colAn.ColumnName;
                    DBSType colType = colAn.Type;
                    int colLength = colAn.Length;
                    bool colPrimary = colAn.PrimaryKey;

                    //Création de la colonne
                    var col = new DBSColumn(colName, colType, colLength, false, DBSIndex.NONE, colPrimary);

                    //Annotation Generated====================================================================
                    var genAn = m.GetCustomAttribute<Generated>();
                 
                    if (genAn != null)
                    {
                        col.AutoIncrement = true;
                        if (!genAn.Basic)
                        {
                            //TODO: Manage Generator
                        }

                    }
                  

                    //Anotation OneToOne==================================================================
                    var otoAn = m.GetCustomAttribute<OneToOne>();
                  
                    if (otoAn != null && m.GetType().Name.ToUpper().Equals(otoAn.TargetTable.ToUpper()))
                    {
                        col.Joined = m.GetType();
                        col.UniqueColJoin = true;
                    }
                    table.Columns.Add(col);
                  
                }
                catch (Exception)
                {

                }


            }//Foreach

            return table;
        }


    }
}
