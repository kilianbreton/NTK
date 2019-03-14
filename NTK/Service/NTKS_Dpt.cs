using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.Database;
using NTK.IO.Xml;
using NTK.Other;
using NTK.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace NTK.Service
{
    public class NTKS_DPT : NTKService
    {
        private bool stop = false;
        private NTKDatabase db;
        private FileManager fm;


        public NTKS_DPT(ServiceConfig config, NTKDatabase db) : base(config) {
            this.db = db;
            fm = new FileManager();

        }

        public override void s_authentification(NTKUser user, List<NTKUser> userlist = null, ServicelistenFunction listen = null)
        {
            var tmp = user.readMsg();
            if (tmp.Contains(NTKCommands.A_USER))  //Pas d'authentification pour les utilisateurs
            {
                
            }
            else if (tmp.Contains(NTKCommands.A_SUPERADM))
            {

            }
            else
            {
                user.writeMsg(NTKCommands.A_BAD);
            }
        }

        public override void s_listen(NTKUser user)
        {
            //format :      NGET INSTALL daemontool                 Installation d'un logiciel
            //              NGET UPDATE daemontool #version         Mise à jour d'un logiciel
            //              NGET UPDATE ME #version                 Mise a jour de NGET
            //              NGET LIST                               Liste des fichiers disponibles
            //              NGET SINFO                              Informations serveur
            //              NGET REPAIR daemontool                  "Réparation" d'un logiciel (fichiers manquants etc)
            //              NGET FILE daemontool>daemontool.exe     téléchargement d'un fichier précis d'un programme

            //Admin ou communautaire
            //              NGET UPLOAD #FILES.ZIP,#NAME,#DEVS      Ajout de logiciel
            //              NGET DELETE #NAME                       Suppression de logiciel
            //              NGET DEPRECATED #NAME                   Logiciel déprécié
            //              NGET UPDATE SERVER                      Mise à jour du serveur

           

            var tmp = "";
            while (!stop)
            {
                tmp = user.readMsg();
                if (tmp.ToUpper().Contains( "INSTALL "))
                {
                    var progname = NTKF.subsep(tmp.ToUpper(), "INSTALL ");
                    String path = null;
                    var msr = (MySqlDataReader) db.select("SELECT * FROM softwares WHERE name='"+progname+"';");


                    if(msr != null)
                    {
                        msr.Read();
                        path = msr.GetString("path");
                        user.writeMsg("FIND");
                        user.sendFile(path, "CURRENT");
                    }
                    else
                    {
                        user.writeMsg("NOT FOUND");
                    }
                   

                }
                else if (tmp.ToUpper().Contains( "UPLOAD "))
                {
                    var progname = NTKF.subsep(tmp.ToUpper(), "UPLOAD ",">");
                    var version = NTKF.subsep(tmp.ToUpper(), ">","<");
                    var size = int.Parse(NTKF.subsep(tmp.ToUpper(), "<", ";"));
                    String path = null;
                    
                    var msr = (MySqlDataReader) db.select(
                        "SELECT * FROM softwares WHERE name='" + progname + "' AND version>'"+version+"'" +
                        "INNER JOIN devs ON devs.id = softwares.devs;"
                        );

                    if (true) //Todo : canUpload
                    {
                        if (msr == null)
                        {
                            msr.Read();
                            path = "fm.Directory" + msr.GetString("pathdir")+"\\"+progname+"."+version+".zip";
                            user.writeMsg("OK");
                            user.reciveFile(path);
                            db.insert("INSERT INTO softwares (name,devs,version,path) VALUES (" + progname + "," + user.Login+","+version+","+path+");");
                            user.writeMsg("OK");
                        }
                        else
                        {
                            user.writeMsg("ALREADY EXIST");
                        }
                    }
                  
                }
                else if (tmp.ToUpper().Contains( "REPAIR "))
                {

                }
                else if (tmp.ToUpper().Contains( "FILE "))
                {

                }
                else if (tmp.ToUpper().Contains( "UPDATE "))
                {
                  
                        var progname = NTKF.subsep(tmp.ToUpper(), "UPDATE ", ">");
                        var version = NTKF.subsep(tmp.ToUpper(), ">");
                        String path = null;

                        var msr = (MySqlDataReader)db.select("SELECT * FROM softwares WHERE name='" + progname + "' AND version>'" + version + "' ORDER BY version DESC;");


                        if (msr != null)
                        {
                            msr.Read();
                            user.writeMsg("FIND");
                            path = msr.GetString("path");
                            user.sendFile(path, "CURRENT");
                           
                        }
                        else
                        {
                            user.writeMsg("NOT FOUND");
                        }
                 
                }
                else if (tmp.ToUpper().Contains("DELETE "))
                {

                }
                else if (tmp.ToUpper().Contains( "DEPRECATED "))
                {

                }
                else if (tmp.ToUpper().Contains( "LIST "))
                {

                }
                else if (tmp.ToUpper().Contains( "SINFO "))
                {

                }
                
            }

        }

        public static ServiceConfig basicConfig()
        {
            var c = new ServiceConfig
            {
                authentification = false,
                stype = "DPT",
              
            };
         

            //c.tables.Add();


            return c;
        }

      
        public override void c_authentification(NTKUser user)
        {
            throw new NotImplementedException();
        }

        public override void c_listen(NTKUser user,string cmd)
        {
            throw new NotImplementedException();
        }

        public override void initialize(params object[] args)
        {
            
        }
    }
}
