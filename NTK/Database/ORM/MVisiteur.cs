using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;



namespace NTK.Database.ORM
{
   
    public class MVisiteur : BaseModel
    {
        
        public override void init()
        {
            db = NTKD_MySql.getInstance("127.0.0.1", "root", "", "swiss");
            fields.Add(new DBSColumn("id", DBSType.INT, 255, true, DBSIndex.PRIMARY, true));       
            fields.Add(new DBSColumn("name", DBSType.INT, 255, true));       
            fields.Add(new DBSColumn("lastname", DBSType.INT, 255, true));  

        }


    }



  


}
