/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * BasePlugin Interface                                                              *
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
using System.Windows.Forms;

namespace NTK.Plugins
{
    /// <summary>
    /// Interface de base d'un Plugin
    /// </summary>
    public interface IBasePlugin
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexte"></param>
        void setContexte(Object contexte);
        
        /// <summary>
        /// Défini la fenêtre principale
        /// </summary>
        /// <param name="main"></param>
        void setMain(Form main);
        
        /// <summary>
        /// Retourne le nom du plugin
        /// </summary>
        /// <returns></returns>
        String getName();

        /// <summary>
        /// Retourne la section du menu principal ou doit se trouver le plugin
        /// </summary>
        /// <returns></returns>
        FieldMenu getField();

        /// <summary>
        /// Retourne le type de plugin (FORM || Intergrated)
        /// </summary>
        /// <returns></returns>
        PluginType getType();
    }
}
