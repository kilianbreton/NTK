using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTK.IO
{
   
    /// <summary>
    /// Ligne de log
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
        /// Type de log
        /// </summary>
        public string Type { get => type; set => type = value; }
        /// <summary>
        /// Texte
        /// </summary>
        public string Text { get => text; set => text = value; }
        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date { get => date; set => date = value; }
    }

    /// <summary>
    /// Gestion de log
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
