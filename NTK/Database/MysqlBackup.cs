using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTK.Security;

namespace NTK.Database
{
    public class MysqlBackup
    {
        private String backupDir;
        private String mysqlDir;
        private String BackupDir;
        private bool backupNameDate;
        private bool backupNameDatabase;

        private bool useEncryption;
        private AesKey key;
        private NTKAes cipher;

        private String targetTable;
        private bool backupAll;
        private String backupDB;

        private String user;
        private String pass;
        private String adrs;


        public MysqlBackup() { }

        public void makeBackup(String path = null)
        {
            if(path == null)
            {
                if(this.backupDir == null)
                {
                    throw new Exception("Le dossier de destination n'est pas défini");
                }
                else
                {
                    //Backup ALGO : ------------------------------------------------

                }
            }

        }


        public string BackupDir1 { get => backupDir; set => backupDir = value; }
        public string MysqlDir { get => mysqlDir; set => mysqlDir = value; }
        public string BackupDir2 { get => BackupDir; set => BackupDir = value; }
        public bool BackupNameDate { get => backupNameDate; set => backupNameDate = value; }
        public bool BackupNameDatabase { get => backupNameDatabase; set => backupNameDatabase = value; }
        public bool UseEncryption { get => useEncryption; set => useEncryption = value; }
        public AesKey Key { get => key; set => key = value; }
        public NTKAes Cipher { get => cipher; set => cipher = value; }
        public string TargetTable { get => targetTable; set => targetTable = value; }
        public bool BackupAll { get => backupAll; set => backupAll = value; }
        public string BackupDB { get => backupDB; set => backupDB = value; }
        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Adrs { get => adrs; set => adrs = value; }
    }
}
