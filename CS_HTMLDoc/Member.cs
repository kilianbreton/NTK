using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NTK.IO.Xml;
using static CS_HTMLDoc.NTKF;

namespace CS_HTMLDoc
{
    public enum MemberType {
        Member,Type,Field,Property,Event
    }


    public class Member
    {
        private static int mid = 0;
        private int mpid;
        private MemberType type;
        private String name;
        private String summary;
        private Dictionary<String, String> paramlst = new Dictionary<String, String>();
        private String returns;
        private String signature;
        private String remarks = null;
        private List<Member> members = new List<Member>();



        public Member() { }

        public Member(XmlNode node, Documentation doc)
        {
            mpid= Mid++;
            while (node.read())
            {
                var n = node.getNode();
                switch (n.getName())
                {
                    case "summary":
                        this.Summary = n.getValue();
                        break;
                    case "param":
                        this.paramlst.Add(n.getAttribute(0).Value, n.getValue());
                        break;
                    case "remarks":
                        this.remarks = n.getValue();
                        break;
                }
            }

           
            
            //Parseur nom -------------------------------------------------------------------------------------
            String att_name = node.getAttibuteV("name");
            this.name = subsep(att_name, ":");
            

            String tmp = this.name;
   
            if (tmp.Contains("("))
            {
                this.signature = "(" + subsep(name, "(", ")") + ")";
                tmp = subsep(tmp, 0, signature);
                this.signature = replaceNs(this.signature);
            }

            var lst = tmp.Split('.');
            this.name = lst[lst.Length- 1];
      

            //Parseur Type---------------------------------------------------------------------------------
            att_name = subsep(att_name, 0, ":");
            switch (att_name)
            {
                case "M":
                    this.type = MemberType.Member;
                    break;
                case "T":
                    this.type = MemberType.Type;
                    break;
                case "F":
                    this.type = MemberType.Field;
                    break;
                case "P":
                    this.type = MemberType.Property;
                    break;
                case "E":
                    this.type = MemberType.Event;
                    break;
            }
            
            //Gestion arboressance NameSpace-------------------------------------------------------------------
            if (doc.Root == null)
            {
                doc.Root = new NameSpace(subsep(tmp, ":", "."));
            }

            //Récupération du reste du chemin à parser, enfants de root
            tmp = subsep(tmp, 0, "." + name);
            if (this.type.Equals(MemberType.Type))
            {

                var namesp = doc.Root.getNameSpace(tmp);
                namesp.Members.Add(this);
            }
            else
            {

                String parent;
                if (tmp.Contains("."))
                {
                    lst = tmp.Split('.');
                    parent = lst[lst.Length - 1];
                }
                else
                {
                    parent = tmp;
                }
                if (doc.Members.Count > 0)
                {
                    int cpt = 0;
                    while (cpt < doc.Members.Count - 1 && !doc.Members[cpt].Name.Equals(parent)) { cpt++; }
                    if (doc.Members[cpt].Name.Equals(parent))
                    {
                        doc.Members[cpt].Members.Add(this);
                    }
                }
            }
           
            

        
         
            
        }

    



        public String makeHtmlTree()
        {
            // String text = " <li><a href='"+name+".html'>"+name+"</a>\n";
        
            String text = " <li><a href='"+name+"-"+mpid+".html'>"+ name + "</a>\n";
            return text;
        }

        public String toString()
        {
            String ret = type.ToString() + " : " + this.name;

            return ret;
        }




        public MemberType Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public string Summary { get => summary; set => summary = value; }
        public Dictionary<string, string> Paramlst { get => paramlst; set => paramlst = value; }
        public string Returns { get => returns; set => returns = value; }
        public string Signature { get => signature; set => signature = value; }
        public List<Member> Members { get => members; set => members = value; }
        public int Mpid { get => mpid; set => mpid = value; }
        public static int Mid { get => mid; set => mid = value; }
        public string Remarks { get => remarks; set => remarks = value; }
    }
}
