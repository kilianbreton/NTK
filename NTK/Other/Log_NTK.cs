using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NTK.IO;

namespace NTK.Other
{
    /// <summary>
    /// 
    /// </summary>
    public class LogLine_NTK : LogLine
    {
        private object sender;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        /// <param name="date"></param>
        public LogLine_NTK(String type, String text, DateTime date): base(type, text, date){}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        /// <param name="text"></param>
        /// <param name="date"></param>
        public LogLine_NTK(object sender, String type, String text, DateTime date): base(type, text, date){
            this.sender = sender;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
    /// <summary>
    /// 
    /// </summary>
    public class Log_NTK : Log
    {
        private static Log_NTK instance;
        private String path;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private Log_NTK(String path)
        {
            this.path = path;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="overrideInstance"></param>
        /// <returns></returns>
        public static Log_NTK getInstance(String path, bool overrideInstance = false)
        {
            if (instance == null || overrideInstance)
            {
                instance = new Log_NTK(path);
            }
            return instance;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool isNull()
        {
            return instance == null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="text"></param>
        public override void add(String type, String text)
        {
            lines.Add(new LogLine_NTK(type, text, DateTime.Now));
        }


        /// <summary>
        /// 
        /// </summary>
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
