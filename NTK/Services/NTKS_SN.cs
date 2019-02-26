using System;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using NTK.Other;
using NTK.Database;
using NTK.EventsArgs;
using NTK.IO.Xml;
using static NTK.Other.NTKF;
using static NTK.Separators;
using NTK.IO;

namespace NTK.Service
{
 
    public enum SNCmd
    {
        //GET
        GUSER,
        GACTU,GACTUFROM,
        GETGROUPS,GETGRP,
        GETLIKEFROM,GETCOMFROM,GETPIC,GETMSGFROM,
        //SET
        POSTACTU,EDITACTU,DELACTU,
        LIKE,UNLIKE,
        POSTCOM,DELCOM,EDITCOM,
        MSG
    }

    

    public class SNUser : NTKUser
    {
        private int grpId;
        private NTKDatabase db;
        public SNUser(String login, TcpClient client) : base(login, client) {
            


        }

        public int GrpId { get => grpId; set => grpId = value; }
        public NTKDatabase Db { get => db; set => db = value; }
    }

    public class NTKS_SN : NTKService
    {
        private FileManager fmanager;
        private NTKDatabase db;
        private const int GET_LIMIT = 60;

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public NTKS_SN(NTKServer serv) : base(serv) {
            base.Config = basicConfig();
            this.db = serv.Database;
        }
       
        public NTKS_SN(NTKClient cli) : base(cli)
        {
            base.Config = basicConfig();
            
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES SERVER /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// /!\ Not Implemented /!\
        /// </summary>
        /// <param name="user"></param>
        public override void s_authentification(NTKUser user, List<NTKUser> userlist = null, ServicelistenFunction listen = null)
        {
            throw new NotImplementedException();
        }

        public void basicCommands(SNUser user, String cmd)
        {
            /////////////////////////////////////////////////////
            //// COMMANDS GET //////////////////////////////////
            ///////////////////////////////////////////////////
            if (cmd.Contains("GET USERS;"))
            {
                String query = "SELECT Login,Name,GrpID,OnLine,AvatarID FROM sn_users ";
                user.writeMsg("/GU_" + db.queryOverNTK(query, true) + SPV);
            }
            else if (cmd.Contains("GET ACTUS;"))
            {
                String query = "SELECT sn_actus.ID,WriterGrp,WriterUser,title,MSG,picid,Date,sn_groups.name AS 'grpName', sn_users.Name As 'usrName'" +
                    " FROM sn_actus " +
                    "INNER JOIN sn_users ON sn_users.id = WriterUser " +
                    "INNER JOIN sn_groups ON sn_groups.id = WriterGrp " +
                    "WHERE sn_actus.ID >= (SELECT COUNT(*) FROM sn_actus) - " + GET_LIMIT + ";";
                user.writeMsg("/GA_" + db.queryOverNTK(query, true) + SPV);

            }       //GET ACTUS FROM 'KilianBt';
            else if (cmd.Contains("GET ACTUS FROM '"))
            {
                String login = NTKF.subsep(cmd, " '", "';");
                String query = "SELECT * FROM sn_actus " +
                    " INNER JOIN sn_users ON sn_users.id = WriterUser" +
                    " INNER JOIN sn_groups ON sn_groups.id = WriterGrp" +
                    " WHERE Login = '" + login + "'" +
                    " AND sn_actus.id >= (SELECT COUNT(*) FROM sn_actus) - " + GET_LIMIT + ";";
                user.writeMsg("/GAF_" + db.queryOverNTK(query, true) + SPV);
            }
            else if (cmd.Contains("GET GROUPS;"))
            {
                String query = "SELECT * FROM sn_groups " +
                    "WHERE id >= (SELECT COUNT(*) FROM sn_groups) - " + GET_LIMIT + ";";
                user.writeMsg("/GG" + db.queryOverNTK(query, true) + SPV);
            }       //GET GROUP 'Decib29';
            else if (cmd.Contains("GET GROUP '"))
            {
                int id = int.Parse(subsep(cmd, "GET GROUP '", "';"));
                String query = "SELECT * FROM sn_groups WHERE ID = " + id + ";";
                user.writeMsg("/GGF" + db.queryOverNTK(query) + SPV);

            }       //GET LIKES FROM '#ActuID';
            else if (cmd.Contains("GET LIKES FROM '"))
            {
                int actuid = int.Parse(subsep(cmd, "GET LIKES FROM '", "';"));
                String query = "SELECT * FROM sn_likes WHERE ActuID = "+actuid+";";
                user.writeMsg("/GLF" + db.queryOverNTK(query) + SPV);


            }       //GET COMMENTS FROM '#ActuID';
            else if (cmd.Contains("GET COMMENTS FROM '"))
            {
                int actuid = int.Parse(subsep(cmd, "GET COMMENTS FROM '", "';"));
                String query = "SELECT * FROM sn_comments WHERE ActuID = " + actuid + ";";
                user.writeMsg("/GLF" + db.queryOverNTK(query) + SPV);

            }       //GET PIC(213);
            else if (cmd.Contains("GET PIC("))
            {

            }       //GET MSG FROM G(#GrpId);    ||  GET MSG FROM U(#UserID);
            else if (cmd.Contains("GET MSG FROM "))
            {
                String query = "";
                if (subsep(cmd, "GET MSG FROM ", "(").Equals("U"))
                {
                    int uid = int.Parse(subsep(cmd, "(", ")"));
                    query = "SELECT * FROM sn_messages " +
                    "WHERE TargetUser = " + uid;
                }
                else
                {
                    int grpid = int.Parse(subsep(cmd, "(", ")"));
                    query = "SELECT * FROM sn_messages " +
                    "WHERE TargetGrp = " + grpid+
                    " AND Target = (SELECT GrpID FROM sn_usergrp WHERE userid = "+ user.Id+" AND grpId = "+grpid+")";
                }
                user.writeMsg("/GMF" + db.queryOverNTK(query) + SPV);

            }
            //// COMMANDS SET ///
            else if (cmd.Contains("/POST ACTU "))   //POST ACTU G <data_xml>#Content</data_xml>  
            {
                //Récupération des données de la commande (xml)
                String type = NTKF.subsep(cmd, "ACTU ", " <xml>");
                XmlDocument xmlp = new XmlDocument(NTKF.subsep(cmd, "<data_xml>", "</data_xml>"), false);
                XmlNode root = xmlp.getNode(0);

                String title = root.getChildV("title");
                String content = root.getChildV("content");
                String tmpPicId = root.getChildV("picid");
                int picid = 0;
                if (tmpPicId != "N/A")
                {
                    picid = int.Parse(tmpPicId);
                    //TODO : Upload file
                }

                //Construction de la requête----------------------------
                String query = "INSERT INTO sn_actus(WriterGrp, WriterUser,title,MSG,picid) VALUES (";
                //Gestion idUser et Idgrp
                if (type.ToUpper().Equals("G"))
                {
                    query += "'" + user.GrpId + "', '0',";
                }
                else
                {
                    query += "'0', '" + user.Id + "',";
                }
                query += " '" + title + "', '" + content + "', '" + picid + "');";
                db.insert(query);


            }       //EDIT ACTU(#ActuId,#Title,#ContentTxt,#Picid);
            else if (cmd.Contains("/EDIT ACTU"))
            {

            }       //DEL ACTU(#ID)
            else if (cmd.Contains("/DEL ACTU("))
            {
                int tmpid = int.Parse(subsep(cmd, "(", ")"));
                db.insert(" DELETE FROM sn_actus WHERE id = " + tmpid + "AND WriterUser = " + user.Id + ";");

            }       //LIKE A(#ID); || LIKE C(#ID);
            else if (cmd.Contains("/LIKE "))
            {
                int tmpid = int.Parse(subsep(cmd, "(", ")"));
                if (cmd.Contains("A("))
                {
                    db.insert("INSERT INTO sn_likes (WriterUser,WriterGrp,ActuID,ComID) VALUES ("+user.Id+",1,"+tmpid+",1);");
               
                }
                else
                {
                    db.insert("INSERT INTO sn_likes (WriterUser,WriterGrp,ActuID,ComID) VALUES (" + user.Id + ",1," + tmpid + ",1);");
                }
            }        //UNLIKE(#ID);
            else if (cmd.Contains("/UNLIKE("))
            {
                int tmpid = int.Parse(subsep(cmd, "(", ")"));
             
                db.insert(" DELETE FROM sn_likes WHERE id = " + tmpid + "AND WriterUser = " + user.Id +";");

            }       //POST COMMENT A(#ID,#contentTxt,#Picid); || POST COMMENT C(#ID,#contentTxt,#Picid);
            else if (cmd.Contains("/POST COMMENT "))
            {

            }       //EDIT COMMENT(#id,#txt,#picid);
            else if (cmd.Contains("/EDIT COMMENT("))
            {

            }       //DEL COMMENT(#id);
            else if (cmd.Contains("/DEL COMMENT("))
            {
                int id = int.Parse(subsep(cmd, "(", ")"));
                String query = "DELETE FROM sn_comment WHERE id = " + id + " AND WriterUser = " + user.Id+";";
                db.insert(query);
            }       //MSG U(#id,#txt,#picid(n/a)); || MSG G(#id,#txt,#picid(n/a));
            else if (cmd.Contains("/MSG "))
            {

            }       // .. U(#ID); || .. G(#ID);
            else if (cmd.Contains("/SEND FILE "))
            {

            }
            else if (cmd.Contains("/DISCONNECT;"))
            {
                base.serv.Userlist.Remove(user);
                user = null;
                
            }
            else if (cmd.Contains(""))
            {

            }
            else if (cmd.Contains(""))
            {

            }
            else if (cmd.Contains(""))
            {

            }
            else if (cmd.Contains(""))
            {

            }
            else
            {

            }


        }

        public override void s_listen(NTKUser user)
        {
            SNUser snu = setUser(user, 1);
            bool stop = false;
            while (!stop)
            {
                String tmp = snu.readMsg();
                basicCommands(snu, tmp);
                if (!snu.Client.Connected)
                {
                    snu = null;
                    stop = true;
                    base.serv.Userlist.Remove(user);
                }
                else
                {


                    switch (snu.Lvl)
                    {
                        case USER_LVL.SUPER_ADMIN:
                            if (tmp.Contains(""))
                            {

                            }
                            else if (tmp.Contains(""))
                            {

                            }

                            else
                            {

                            }
                            break;
                        case USER_LVL.ADMIN:
                            break;
                        case USER_LVL.USER:
                            break;
                        case USER_LVL.BOT:
                            break;
                        case USER_LVL.SUB_SERVER:
                            break;
                    }
                }
            }
        }


        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES CLIENT /////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public override void c_authentification(NTKUser user)
        {
            throw new NotImplementedException();
        }

        public override void c_listen(NTKUser user,String cmd)
        {
     //       String cmd = user.readMsg();
            String tempDataSql = "";
            if (cmd.Contains("/GA_") && cmd.Contains(SPV))
            {
                tempDataSql = waitEndCommand(cmd, SPV, user);

                String dataSql = subsep(tempDataSql, "/GA_", SPV);
                OnGetActu(new GetActuEventArgs(dataSql));
            }
            else if (cmd.Contains("/GU_"))
            {
                tempDataSql = waitEndCommand(cmd, SPV, user);

                String dataSql = subsep(tempDataSql, "/GU_", SPV);
                OnGetUser(new GetUserEventArgs(dataSql));
            }
            else if (cmd.Contains("/GAF_"))
            {
                tempDataSql = waitEndCommand(cmd, SPV, user);

                String dataSql = subsep(tempDataSql, "/GAF_", SPV);
                OnGetActu(new GetActuEventArgs(dataSql));
            }
            else if (cmd.Contains("/GU_"))
            {
                tempDataSql = waitEndCommand(cmd, SPV, user);

                String dataSql = subsep(tempDataSql, "/GU_", SPV);
                OnGetUser(new GetUserEventArgs(dataSql));
            }
            else
            {

            }

        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PUBLIQUES GLOBALES ///////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



        public static SNUser setUser(NTKUser user, int grpId)
        {
            SNUser ret = new SNUser(user.Login, user.Client);
            ret.Tls = user.Tls;
            ret.GrpId = grpId;
            ret.Cipher = user.Cipher;
            return ret;
        }

        public static ServiceConfig basicConfig(NTKDatabase db = null)
        {
            var c = new ServiceConfig
            {
                authentification = false,
                stype = "SN",
                tables_prefix = "sn_",
                database = new DBStruct("SN", "myisam"),
                dbq = db,
                useBasicListen = false
                
            };

            ////////////////////////////////////////////////////////////////////////////////////////////////
            //// Tables ///////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////


            //Table Utilisateurs
            DBSTable users = new DBSTable("users");
            users.Columns.Add(new DBSColumn("id", DBSType.INT, 255, true, true, DBSCollation.utf8_bin, null, DBSIndex.PRIMARY, true));
            users.Columns.Add(new DBSColumn("login", DBSType.VARCHAR, 255, false));
            users.Columns.Add(new DBSColumn("name", DBSType.VARCHAR, 255, false));
            users.Columns.Add(new DBSColumn("password", DBSType.VARCHAR, 255, false));
            users.Columns.Add(new DBSColumn("mail", DBSType.VARCHAR, 255, false));
            users.Columns.Add(new DBSColumn("lvl", DBSType.INT, 255, false));
            users.Columns.Add(new DBSColumn("grpId", DBSType.INT, 255, false));
            users.Columns.Add(new DBSColumn("online", DBSType.INT, 255, false));
            users.Columns.Add(new DBSColumn("avatarid", DBSType.INT, 255, false));
            users.Columns.Add(new DBSColumn("regkey", DBSType.VARCHAR, 255, false));
            users.Columns.Add(new DBSColumn("salt", DBSType.INT, 255, false));
            c.database.Tables.Add(users);

            //Table actus 
            DBSTable actu = new DBSTable("actus");
            actu.Columns.Add(new DBSColumn("id", DBSType.INT, 255, true, true, DBSCollation.utf8_bin, null, DBSIndex.PRIMARY, true));
            actu.Columns.Add(new DBSColumn("writerGrp", DBSType.INT, 255, false));
            actu.Columns.Add(new DBSColumn("WriterUser", DBSType.INT, 255, false));
            actu.Columns.Add(new DBSColumn("msg", DBSType.VARCHAR, 255, false));
            actu.Columns.Add(new DBSColumn("picid", DBSType.INT, 255, false));
            actu.Columns.Add(new DBSColumn("date", DBSType.DATE, 255, false));
            c.database.Tables.Add(actu);

            //Table comments
            DBSTable comments = new DBSTable("comments");
            comments.Columns.Add(new DBSColumn("id", DBSType.INT, 255, true, true, DBSCollation.utf8_bin, null, DBSIndex.PRIMARY, true));
            comments.Columns.Add(new DBSColumn("writerGrp", DBSType.INT, 255, false));
            comments.Columns.Add(new DBSColumn("WriterUser", DBSType.INT, 255, false));
            comments.Columns.Add(new DBSColumn("msg", DBSType.VARCHAR, 255, false));
            comments.Columns.Add(new DBSColumn("actuid", DBSType.INT, 255, false));
            comments.Columns.Add(new DBSColumn("date", DBSType.DATE, 255, false));
            c.database.Tables.Add(comments);

    



            return c;
        }

        public override void initialize(params object[] args)
        {
            
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES PRIVEES //////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private bool checkSyntax(SNCmd type,String cmd)
        {
            bool ret = false;
            switch (type)
            {
                case SNCmd.GACTUFROM: //GET ACTU FROM 'Login';
                    ret = (
                        cmd.Contains(" '") 
                        && nbChar("","'".ToCharArray()[0]).Equals(2) 
                        && cmd.Contains(";") 
                        && verifArgs(subsep(cmd, " '", "';")) //verif separateurs
                        );
                    
                    break;

                case SNCmd.EDITACTU:
                    break;

                case SNCmd.DELACTU:
                    break;

                case SNCmd.POSTACTU:
                    break;

                case SNCmd.GUSER:
                    break;

                case SNCmd.GETGROUPS:
                    break;

                case SNCmd.GETGRP:
                    break;

                case SNCmd.GETLIKEFROM:
                    break;
                case SNCmd.GETCOMFROM:
                    break;
                case SNCmd.GETPIC:
                    break;
                case SNCmd.GETMSGFROM:
                    break;
                case SNCmd.LIKE:
                    break;
                case SNCmd.UNLIKE:
                    break;
                case SNCmd.POSTCOM:
                    break;
                case SNCmd.DELCOM:
                    break;
                case SNCmd.EDITCOM:
                    break;
                case SNCmd.MSG:
                    break;
            }

            return false;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------
        public NTKDatabase Db { get => db; set => db = value; }

    }
}
