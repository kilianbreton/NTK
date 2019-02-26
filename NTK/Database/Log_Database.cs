using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NTK.IO;

namespace NTK.Database
{

    public class LogLine_Database : LogLine
    {
        private String place;

        public LogLine_Database(String type, String text, String place, DateTime date) : base(type, text, date) {
            this.place = place;
        }

        public override string toText()
        {
            return "[" + base.Type + "] " + base.Date.ToLongTimeString() + " [" + place + "] - " + base.Text;
        }
    }


    public class Log_Database : Log
    {
        private static Log_Database instance;
        private String path;
       


        private Log_Database(String path)
        {
            this.path = path;
        }

        public static Log_Database getInstance(String path, bool overrideInstance = false)
        {
            if (instance == null || overrideInstance)
            {
                instance = new Log_Database(path);
            }
            return instance;
        }

        public override void add(String type, String text)
        {
            lines.Add(new LogLine_Database(type, text, "none", DateTime.Now));
        }

      

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
