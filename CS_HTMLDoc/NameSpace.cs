using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CS_HTMLDoc.NTKF;

namespace CS_HTMLDoc
{
    public class NameSpace
    {
        private const String TV_DIV = "<div class=\"css-treeview\">";
        private const String BASE_HTML = "<html>\n <head>\n " +
          "<link rel='stylesheet' href='css/treeview.css'>\n" +
          "<link rel='stylesheet' href='css/style.css'>\n" +
          " </head>\n<body>";
        private const String END_HTML = "</body>\n</html>";

        private String name;
        private List<Member> members = new List<Member>();
        private List<NameSpace> childs = new List<NameSpace>();
        private int mpid;
   

        public NameSpace(String name)
        {
            this.mpid = Member.Mid++;
            this.name = name;
        }

        public NameSpace getChild(String name)
        {
            NameSpace ret = null;
            if (childs.Count> 0)
            {
                int cpt = 0;
                while (cpt < childs.Count - 1 && !childs[cpt].Name.Equals(name)) { cpt++; }
                if (childs[cpt].Name.Equals(name))
                    ret = childs[cpt];

            }
            return ret;
        }

        public NameSpace getNameSpace(String path)
        {
            NameSpace ret = null;
            if (path.Contains("."))
            {
                string[] lst = path.Split('.');
                var preChild = getChild(lst[1]);
                if (lst[0].Equals(this.name))
                {
                    if (preChild != null)
                    {
                        ret = preChild.getNameSpace(subsep(path, lst[0] + "."));
                    }
                    else
                    {
                        preChild = addChild(lst[1]);
                        ret = preChild.getNameSpace(subsep(path, lst[0] + "."));
                    }
                }
                else
                {
                    throw new Exception("Invalid Path");
                }
            }
            else
            {
                ret = this;
            }
            return ret;
        }

        public NameSpace addChild(String name)
        {
            NameSpace ret = new NameSpace(name);
            childs.Add(ret);
            return ret;
        }

        public void makeHtml(Dictionary<string,string> files)
        {
            String text = BASE_HTML;
            text += "<h1>" + this.name + "</h1>";
     //       text += "<h2>" + m.Summary + "</h2><br>";
            text += "<h3>Classes :</h3>";
            text += "<table class='paleBlueRows'>\n" +
                "<thead> <tr>\n" +
                " <th>Name</th>\n<th>Type</th>\n" +
                "</tr></thead>\n";
            foreach (Member childm in members)
            {
                if (childm.Name.Equals("#ctor")) { childm.Name = "Constructor"; }
                text += "<tr><td><a href='" + childm.Name + "-" + childm.Mpid + ".html'><strong>" + childm.Name + "</strong>" + childm.Signature + "</a></td><td>" + childm.Type.ToString() + "</td></tr>";
            }
            text += "</table>";
            text += "<div id='MenuvCategorie'>";
            text += files["treeview.html"];
            text += "</div>";
            text += END_HTML;
            try
            {
                files.Add(this.name + "-" + this.mpid + ".html", text);

            }
            catch (Exception e) { }
            foreach(NameSpace ns in childs)
            {
                ns.makeHtml(files);
            }
        }

        public String makeHtmlTree(IdTree id, int pos)
        {
           // String text = " <li><a href='"+name+".html'>"+name+"</a>\n";
            String text = " <li><input type='checkbox' id='item-"+id+"' /><label for='item-"+id+"'>" + name+"</label>\n";
            id.add();
            if (childs.Count > 0 || members.Count >0)
            {
                text += "   <ul>\n";
                if (childs.Count > 0)
                {
                    pos++;
                    
                    foreach (NameSpace ns in childs)
                    {
                        text += ns.makeHtmlTree(id,pos);
                        id.increment(pos);
                    }
                }
                if (members.Count > 0)
                {
                    foreach (Member mb in members)
                    {
                        text += mb.makeHtmlTree();
                    }
                }
                text += "   </ul>\n";
            }
            return text;
        }

        public String toString()
        {
            String ret = "\n" + name + ":";
            foreach(NameSpace ns in childs)
            {
                ret += " - " + ns.toString();
            }
            //ret += name + ":\n- Members :\n";
            foreach (Member mb in members)
            {
                ret += " - " + mb.toString();
            }
            return ret;
        }

        public string Name { get => name; set => name = value; }
        public List<Member> Members { get => members; set => members = value; }
        public List<NameSpace> Childs { get => childs; set => childs = value; }
        public int Mpid { get => mpid; set => mpid = value; }
    }
}
