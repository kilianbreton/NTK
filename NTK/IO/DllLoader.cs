/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * DllLoader Class                                                                   *
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
using Microsoft.CSharp.RuntimeBinder;
using NTK.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Binder = System.Reflection.Binder;

namespace NTK.IO
{
    /// <summary>
    /// Charge des instance de classe dans des librairies de manière dynamique
    /// </summary>
    public class DllLoader
    {
        private String path;
        private Assembly dll;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        public DllLoader() { }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public DllLoader(String path) {
            this.path = path;
            this.dll = Assembly.LoadFile(path);
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// Retourne l'instance de la classe de nom <c>name</c> implémentant la classe T
        /// </summary>
        /// <code>
        /// DllLoader dll = new DllLoader("path");
        /// </code>
        /// <exception cref="NTK.IO.InvalidTypeException">quand la classe obtenue n'implémente pas la classe attendu</exception>
        /// <typeparam name="T">Classe abstraite</typeparam>
        /// <param name="name">Nom de la classe concrête</param>
        /// <returns></returns>
        public T getClassInstance<T>(String name)
        {
            var classe = this.dll.CreateInstance(name, true);
            if (!classe.GetType().BaseType.Equals(typeof(T)) && !implements(classe.GetType(), typeof(T)))
            {
                throw new InvalidTypeException(typeof(T).Name, classe.GetType().Name);
            }
            else
            {
                return (T)classe;
            }
        }

        /// <summary>
        /// Obtient une liste d'instances de classes implémentant la classe T contenant la valeur like dans leur nom
        /// </summary>
        /// <code>
        /// DllLoader dll = new DllLoader("path");
        /// </code>
        /// <exception cref="NTK.IO.InvalidTypeException">quand la classe obtenue n'implémente pas la classe attendu</exception>
        /// <typeparam name="T">Classe abstraite</typeparam>
        /// <param name="like">Préfixe ou suffixe du nom de/des classe(s) concrête(s)</param>
        /// <returns></returns>
        public List<T> getClassInstancelike<T>(String like)
        {
            var ret = new List<T>();
            foreach (Type type in dll.GetExportedTypes())
            {
                if (type.Name.Contains(like))
                {
                    var classe = this.dll.CreateInstance(type.FullName, true);
                    if (!classe.GetType().BaseType.Equals(typeof(T)) && !implements(classe.GetType(),typeof(T)))
                    {
                        throw new InvalidTypeException(typeof(T).Name, classe.GetType().Name);
                    }
                    else
                    {
                        ret.Add((T)classe);
                    }
                }
            }

            return ret;
        }

        /// <summary>
        /// Obtient la liste des classes implémentant la classe T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> getAllInstances<T>(params Object[] args)
        {
            var ret = new List<T>();
            foreach (Type type in dll.GetExportedTypes())
            {
                try
                {
                    var classe = this.dll.CreateInstance(type.FullName, true);

                    if (classe.GetType().BaseType.Equals(typeof(T)) || implements(classe.GetType(), typeof(T)))
                    {
                        ret.Add((T)classe);
                    }
                }
                catch (Exception){}
               
            }
            return ret;
        }






        private bool implements(Type classe, Type baseCI)
        {
            bool ret = false;
            int cpt = 0;

            var types = classe.GetInterfaces();
            while(cpt<types.Length && !ret)
            {
                if (types[cpt].Equals(baseCI))
                {
                    ret = true;
                }
                else { cpt++; }
            }



            return ret;
        }

    }
}
