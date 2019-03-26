using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NTK.IO;

namespace NTK.Database
{
    /// <summary>
    /// LogLine pour base de données
    /// </summary>
    public class LogLine_Database : LogLine
    {
        private String place;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        /// <param name="place"></param>
        /// <param name="date"></param>
        public LogLine_Database(String type, String text, String place, DateTime date) : base(type, text, date) {
            this.place = place;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string toText()
        {
            return "[" + base.Type + "] " + base.Date.ToLongTimeString() + " [" + place + "] - " + base.Text;
        }
    }

    /// <summary>
    /// Log pour base de données
    /// </summary>
    public class Log_Database : Log
    {
        private static Log_Database instance;
        private String path;
       


        private Log_Database(String path)
        {
            this.path = path;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="overrideInstance"></param>
        /// <returns></returns>
        public static Log_Database getInstance(String path, bool overrideInstance = false)
        {
            if (instance == null || overrideInstance)
            {
                instance = new Log_Database(path);
            }
            return instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        public override void add(String type, String text)
        {
            lines.Add(new LogLine_Database(type, text, "none", DateTime.Now));
        }

      
        /// <summary>
        /// 
        /// </summary>
        public override void flush()
        {
            StreamWriter sw = new StreamWriter(path,true);
            try
            {
                foreach (LogLine elem in lines)
                {
                    sw.WriteLine(elem.toText());
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }
    }
}
