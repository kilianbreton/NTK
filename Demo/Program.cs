using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK;
using NTK.Database;
using NTK.Other;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            NTKServer server = new NTKServer(1141, CTYPE.OTHER, false, null, 
                NTKD_MySql.getInstance("127.0.0.1", "root", "", "swiss"));

            server.Stype = "MONSERVICE";
            server.ExtServices.Add(new NTKS_Game());
            server.Logs = Log_NTK.getInstance("NTK.log", true);
            server.Database.Logs = Log_Database.getInstance("DB.log", true);
            server.Database.tryConnection();

            server.start();

        }
    }
}
