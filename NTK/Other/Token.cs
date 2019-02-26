using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Other
{
    public class Token
    {
        private DateTime date;
        private String token;
        private String login;

        public Token(string token, string login)
        {
            this.token = token;
            this.login = login;
            this.date = DateTime.Now;
            date.AddMinutes(50);
        }

      
        public static double dateToTimeStamp(DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }


        public bool checkDate()
        {
            var dt = DateTime.Now;
            return (dateToTimeStamp(date) < dateToTimeStamp(dt));
        }

        public bool check(String token)
        {
            var dt = DateTime.Now;
            
            return (this.token == token && dateToTimeStamp(date) < dateToTimeStamp(dt));
        }





        public DateTime Date { get => date; set => date = value; }
        public string TokenStr { get => token; }
        public string Login { get => login; }

    }
}
