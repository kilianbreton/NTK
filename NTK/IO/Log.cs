using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTK.IO
{
   

    public abstract class LogLine
    {
        private String type;
        private String text;
        private DateTime date;

        protected LogLine(string type, string text, DateTime date)
        {
            this.type = type;
            this.text = text;
            this.date = date;
        }


        public abstract String toText();


        public string Type { get => type; set => type = value; }
        public string Text { get => text; set => text = value; }
        public DateTime Date { get => date; set => date = value; }
    }


    public abstract class Log
    {
        protected List<LogLine> lines = new List<LogLine>();

        public abstract void add(String type, String text);

        public void add(LogLine line)
        {
            lines.Add(line);
        }

        public abstract void flush();

    }
}
