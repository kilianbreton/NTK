using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NTK.IO;

namespace NTK.Other
{

    public class LogLine_NTK : LogLine
    {
        private object sender;
        public LogLine_NTK(String type, String text, DateTime date): base(type, text, date){}
        public LogLine_NTK(object sender, String type, String text, DateTime date): base(type, text, date){
            this.sender = sender;
        }



        public override string toText()
        {
            String senderName = "null";
            if (sender != null)
            {
                senderName = sender.ToString();
            }
            return "<<(Source : "+senderName+")>> [" + base.Type + "] " + base.Date.ToShortDateString() + " " + base.Date.ToLongTimeString() + " - "+base.Text;
        }
    }

    public class Log_NTK : Log
    {
        private static Log_NTK instance;
        private String path;


        private Log_NTK(String path)
        {
            this.path = path;
        }

        public static Log_NTK getInstance(String path, bool overrideInstance = false)
        {
            if (instance == null || overrideInstance)
            {
                instance = new Log_NTK(path);
            }
            return instance;
        }

        public static bool isNull()
        {
            return instance == null;
        }

        public override void add(String type, String text)
        {
            lines.Add(new LogLine_NTK(type, text, DateTime.Now));
        }



        public override void flush()
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, true);
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
