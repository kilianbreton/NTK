/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * Logs Class                                                                        *
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

namespace NTK.IO
{
   
    /// <summary>
    /// 
    /// </summary>
    public abstract class LogLine
    {
        private String type;
        private String text;
        private DateTime date;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        /// <param name="date"></param>
        protected LogLine(string type, string text, DateTime date)
        {
            this.type = type;
            this.text = text;
            this.date = date;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public abstract String toText();

        /// <summary>
        /// 
        /// </summary>
        public string Type { get => type; set => type = value; }
        /// <summary>
        /// 
        /// </summary>
        public string Text { get => text; set => text = value; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get => date; set => date = value; }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class Log
    {
        /// <summary>
        /// 
        /// </summary>
        protected List<LogLine> lines = new List<LogLine>();

        public abstract void add(String type, String text);

        public void add(LogLine line)
        {
            lines.Add(line);
        }

        public abstract void flush();

    }
}
