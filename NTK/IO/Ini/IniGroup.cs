/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * IniGroup Class                                                                    *
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


namespace NTK.IO.Ini
{
    /// <summary>
    /// Groupe de valeurs d'un fichier Ini
    /// </summary>
    public class IniGroup
    {
        private int index = -1;
        private String name;
        private List<IniValue> values = new List<IniValue>();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        /// <summary>
        /// Création d'un groupe
        /// </summary>
        /// <param name="name"></param>
        public IniGroup(String name)
        {
            this.name = name;
        }
       
        /// <summary>
        /// Création d'un groupe
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vals"></param>
        public IniGroup(String name, params IniValue[] vals)
        {
            this.name = name;
            this.values.AddRange(vals);
        }
        
        /// <summary>
        /// Création d'un groupe
        /// </summary>
        /// <param name="name"></param>
        /// <param name="vals"></param>
        public IniGroup(String name, List<IniValue> vals)
        {
            this.name = name;
            this.values = vals;
        }
        
        /// <summary>
        /// Constructeur vide
        /// </summary>
        public IniGroup() { }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES ////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
   
        /// <summary>
        /// Incrémente l'index pour la méthode get
        /// </summary>
        /// <returns>True si il y a une valeur</returns>
        public bool next()
        {
            return (++index < values.Count);
        }
        /// <summary>
        /// retourne l'object IniValue correspondant à la valeur de l'index (méthode next)
        /// </summary>
        /// <returns></returns>
        public IniValue get()
        {
            if (index < 0)
                return null;

            return values[index];
        }

        /// <summary>
        /// retourne l'objet <c>IniValue</c> de nom #name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IniValue getValueLine(String name)
        {
            IniValue ret = null;
            int cpt = 0;

            while (cpt < values.Count && !values[cpt].Name.Equals(name)) { cpt++; }

            if (values[cpt].Name.Equals(name))
                ret = values[cpt];

            return ret;
        }
        /// <summary>
        /// retourne la valeur de la variable <c>name</c>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public String getValue(String name)
        {
            String ret = null;
            int cpt = 0;

            while (cpt < values.Count && !values[cpt].Name.Equals(name)) { cpt++; }

            if (values[cpt].Name.Equals(name))
                ret = values[cpt].Value;

            return ret;
        }

        /// <summary>
        /// Génère un fichier ini
        /// </summary>
        /// <returns></returns>
        public String print()
        {
            String ret = "[" + name + "]\n";
            foreach(IniValue val in values)
            {
                ret += val.print() + "\n";
            }

            return ret;
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GETTERS & SETTERS /////////////////////////////////////////////////////////////////////////////////////////////////   
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
  
        /// <summary>
        /// 
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 
        /// </summary>
        public List<IniValue> Values { get => values; set => values = value; }


    }
}
