/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * XmlAttribute Class                                                                *
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

namespace NTK.IO.Xml
{
    /// <summary>
    /// Attribut XML
    /// </summary>
    public class XmlAttribute
    {
        private String name;
        private String value;
        
        /// <summary>
        /// Création d'un attribut
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public XmlAttribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
        /// <summary>
        /// Nom
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Valeur
        /// </summary>
        public string Value { get => value; set => this.value = value; }
    }
}
