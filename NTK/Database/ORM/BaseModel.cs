using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace NTK.Database.ORM
{
    /// <summary>
    /// 
    /// </summary>
    public class PrimaryKey
    {
        public PrimaryKey() { }
        public PrimaryKey(params String[] names) {
           // Fields.AddRange(names);
        }
        public List<DBSColumn> Fields { get => Fields; set => Fields = value; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class ModelValues
    {
        public Dictionary<String,Object> Values { get => Values; set => Values = value; }





    }
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseModel
    {
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // ATTRIBUTS ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private static bool isInit = false;

        protected String table;
        protected PrimaryKey pk;
        protected List<Relation> relations;
        protected List<DBSColumn> fields;
        protected NTKDatabase db;


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>        
        public BaseModel()
        {
            if (!isInit)
            {
                init();
                isInit = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void init();


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Object select(int id)
        {
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<Object> select(String field, String value)
        {
            return null;
        }

        public List<Object> all()
        {
            return null;
        }

        public bool make()
        {
            return false;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// PRIVEES //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void getPKname()
        {
            this.pk = new PrimaryKey();
            bool end = false;
            int cpt = 0;
            while (!end)//todo : FOR
            {
                if (fields[cpt].PrimaryKey)
                {
                    this.pk.Fields.Add(fields[cpt]);
                   

                }
                else if (cpt > fields.Count) { end = true; }
                else { cpt++; }
            }
        }

        //TODO : Set PK
    }
}
