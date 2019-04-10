using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database.ORM.Core
{

    /// <summary>
    /// Etat de requête pour QueryBuilder
    /// </summary>
    public enum QueryState
    {
        /// <summary>
        /// Aucun (Etat de base)
        /// </summary>
        NONE,
        /// <summary>
        /// Mode SELECT (non remplaçable)
        /// </summary>
        SELECT,
        /// <summary>
        /// Mode INSERT (non remplaçable)
        /// </summary>
        INSERT,
        /// <summary>
        /// Mode UPDATE (non remplaçable)
        /// </summary>
        UPDATE
    }

    /// <summary>
    /// Constructeur de requête par entitée
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class QueryBuilder<T>
    {
        private Entity entity;
        private String query;
        private QueryState state = QueryState.NONE;
        private bool haveWhere = false;

        /// <summary>
        /// Instanciation (mise zéro)
        /// </summary>
        public QueryBuilder()
        {
            this.entity = (Entity) Activator.CreateInstance(typeof(T));
        }
        
        //BUILDER=====================================================================================

        /// <summary>
        /// Création d'une requête SELECT
        /// </summary>
        /// <returns>this</returns>
        public QueryBuilder<T> select()
        {
            setState(QueryState.SELECT);
            this.query = "SELECT * FROM " + entity.getTableName() + " ";

            return this;
        }
        /// <summary>
        /// Création d'une requête INSERT
        /// </summary>
        /// <returns>this</returns>
        public QueryBuilder<T> insert()
        {
            setState(QueryState.INSERT);
            this.query = "INSERT INTO " + entity.getTableName() + " ";
            return this;
        }
        /// <summary>
        /// Création d'une requête UPDATE
        /// </summary>
        /// <returns>this</returns>
        public QueryBuilder<T> update()
        {
            setState(QueryState.UPDATE);
            this.query = "UPDATE INTO " + entity.getTableName() + " ";
            return this;
        }

        /// <summary>
        /// Ajout d'une condition Where avec opérateur AND
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public QueryBuilder<T> andWhere(String column, String value)
        {
            query += manageWhere("AND");

            query += column + " = '" + value + "' ";
            return this;
        }
        /// <summary>
        /// Ajout d'une condition Where avec opérateur AND
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public QueryBuilder<T> andWhere(String column, int value)
        {
            query += manageWhere("AND");

            query += column + " = " + value + " ";
            return this;
        }
        /// <summary>
        /// Ajout d'une condition Where avec opérateur OR
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public QueryBuilder<T> orWhere(String column, String value)
        {
            query += manageWhere("OR");

            query += column + " = '" + value + "' ";
            return this;
        }
        /// <summary>
        /// Ajout d'une condition Where avec opérateur OR
        /// </summary>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public QueryBuilder<T> orWhere(String column, int value)
        {
            query += manageWhere("OR");

            query += column + " = " + value + " ";
            return this;
        }

        public QueryBuilder<T> groupBy(params String[] columns)
        {


            return this;
        }

        
        //EXECUTION========================================================================================

        /// <summary>
        /// Récupération de la requête
        /// </summary>
        /// <returns></returns>
        public string getQuery()
        {
            return query;
        }

        /// <summary>
        /// Obtient un objet du résultat
        /// </summary>
        /// <returns></returns>
        public T getOne()
        {
            return default(T);
        }

        /// <summary>
        /// Obtient la liste des objets concernés par le résultat
        /// </summary>
        /// <returns></returns>
        public List<T> getResults()
        {
            return null;
        }

        /// <summary>
        /// Execute une requête sans résultat
        /// </summary>
        public void executeNonQuery()
        {

        }


      

        //Private================================================================================================
        private void setState(QueryState state)
        {
            if(this.state == QueryState.NONE)
            {
                this.state = state;
            }
            else
            {
                throw new QueryStateException(this.state, state);
            }
        }
        
        private string manageWhere(string condOp)
        {
            string ret;
            if (!haveWhere)
            {
                ret = "WHERE ";
                haveWhere = true;
            }
            else
            {
                ret = condOp + " ";
            }
            return ret;
        }

    }
}
