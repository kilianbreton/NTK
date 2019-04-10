using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using NTK.Database.ORM.Attribute;
using System.IO;
using static NTK.Database.DBSType;

namespace NTK.Database.ORM
{
    [Serializable()]
    [Table("visiteur")]
    public class MVisiteur : Entity
    {
        [Column("VIS_MATRICULE", VARCHAR,10,true)]
        [Generated]
        private string vismatricule;

        [Column("VIS_LOGIN", VARCHAR, 51)]
        private string visLogin;

        [Column("VIS_NOM", VARCHAR, 50)]
        private string visNom;

        [Column("VIS_PRENOM", VARCHAR, 50)]
        private string visPrenom;

        [Column("VIS_VILLE", VARCHAR, 50)]
        private string visVille;

        [Column("LAB_CODE", VARCHAR, 10)]
        [OneToOne("labo", "LAB_CODE")]
        private Labo labcode;

        public MVisiteur(string vismatricule, string visLogin, string visNom, string visPrenom, string visVille, Labo labcode)
        {
            this.vismatricule = vismatricule;
            this.visLogin = visLogin;
            this.visNom = visNom;
            this.visPrenom = visPrenom;
            this.visVille = visVille;
            this.labcode = labcode;
        }


        public MVisiteur() { }


        public string Vismatricule { get => vismatricule; set => vismatricule = value; }
        public string VisLogin { get => visLogin; set => visLogin = value; }
        public string VisNom { get => visNom; set => visNom = value; }
        public string VisPrenom { get => visPrenom; set => visPrenom = value; }
        public string VisVille { get => visVille; set => visVille = value; }
        public Labo Labcode { get => labcode; set => labcode = value; }
    }


    public class Labo : Entity
    {
        [Column("LAB_CODE",DBSType.VARCHAR,10,true)]
        private string code;
        [Column("LAB_LIBELLE", DBSType.VARCHAR, 50)]
        private string libelle;

        public Labo() { }

        public Labo(String code,String libelle)
        {
            this.code = code;
            this.libelle = libelle;
        }


        public string Code { get => code; set => code = value; }
        public string Libelle { get => libelle; set => libelle = value; }
    }
    

}
