using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Database;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration.Assemblies;

namespace NTK.IO
{
    /// <summary>
    /// 
    /// </summary>
    public class FileManager
    {
        private NTKDatabase db = null;
        private List<FMDirectory> dirs = new List<FMDirectory>();

     
       /// <summary>
       /// 
       /// </summary>
       /// <param name="path"></param>
       /// <param name="name"></param>
       /// <param name="size"></param>
       /// <param name="sourceName"></param>
       /// <param name="targetName"></param>
       /// <returns></returns>
        public bool upload(String path, String name, int size,String sourceName, String targetName)
        {
          
            bool ret = false;
            if (true)
            {
                try
                {
                    db.insert("INSERT INTO FileManager path,source,target,size,name) VALUES ('"+path+"',"+ "'"+sourceName+"', "+ "'" + targetName + "', " + "'" + size + "', " + "'" + name + "', " + ");");
                    ret = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public String getPath(String name)
        {
            var msr = (MySqlDataReader)db.select("SELECT path FROM FileManager WHERE name ='"+name+"';");
            msr.Read();
            return msr.GetString("path");
        }

        public static String octetConverter(long size)
        {
            String ret = "";
            int cpt = 0;
            double tmpsize = size;
            while (tmpsize >= 1024 && cpt <= 5)
            {
                tmpsize = tmpsize / 1024;
                cpt++;
            }
            ret = Math.Round(tmpsize, 2).ToString();

          

            switch (cpt)
            {
                case 0:
                    ret = ret + " octets";
                    break;
                case 1:
                    ret = ret + " Ko";
                    break;
                case 2:
                    ret = ret + " Mo";
                    break;
                case 3:
                    ret = ret + " Go";
                    break;
                case 4:
                    ret = ret + " To";
                    break;
                case 5:
                    ret = ret + " Po";
                    break;
            }
            return ret;
        }




        
      
        
        
        /// <summary>
        /// Size = octets
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static long DirSize(DirectoryInfo d)
        {
            long Size = 0;
            // Add file sizes. 
            FileInfo[] fis = d.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
            // Add subdirectory sizes. 
            DirectoryInfo[] dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += DirSize(di);
            }
            return (Size);
        }








        public List<FMDirectory> Dirs { get => dirs; set => dirs = value; }
    }
}

