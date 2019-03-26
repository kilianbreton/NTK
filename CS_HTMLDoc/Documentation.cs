using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NTK.IO.Xml;
using NTK.IO.Ini;

namespace CS_HTMLDoc
{
    public struct IdTree
    {
        private List<int> ids;

        public IdTree(params int[] id)
        {
            ids = new List<int>(id);
        }


        public IdTree(List<int> id)
        {
            ids = id;
        }

        public void increment(int pos)
        {
            ids[pos]++;
        }

        public void add()
        {
            ids.Add(0);
        }



        public override String ToString()
        {
            String ret = ""+ids[0];
            for (int i =1;i<ids.Count;i++)
            {
                ret += "-" + ids[i];
            }
            
            return ret;
        }

    }


    public class Documentation
    {
        //Constantes :
        private const String TV_DIV = "<div class=\"css-treeview\">";
        private const String BASE_HTML = "<html>\n <head>\n " +
            "<link rel='stylesheet' href='css/treeview.css'>\n" +
            "<link rel='stylesheet' href='css/style.css'>\n" +
            " </head>\n<body>";
        private const String END_HTML = "</body>\n</html>";

        //Propriétés : 
        private Lang lang;
        private String assemblyName;
        private XmlDocument xmld;
        private List<Member> members = new List<Member>();  //temporaire (pour parser)
        private NameSpace root;
                        //name,Content
        private Dictionary<String, String> files = new Dictionary<string, string>();

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        // CONSTRUCTEURS ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public Documentation(String path)
        {
            commonBuilder(path);
            this.lang = new Lang()
            {
                members = "Members",
                members_name = "Name",
                members_type = "Type",
                type_type = "Type",
                type_member = "Members",
                type_property = "Property",
                members_params = "Paramètres",
                members_params_name = "Name",
                members_params_description = "Description"
            };
        }
      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <param name="language"></param>
        /// <param name="template"></param>
        public Documentation (String path,String language,String template = null)
        {
            commonBuilder(path);
            IniDocument inid = new IniDocument(AppDomain.CurrentDomain.BaseDirectory + "\\chd.ini");
            var l = inid.getGroup(language);
            this.lang = new Lang()
            {
                
                members = l.getValue("members"),
                members_name = l.getValue("members_name"),
                members_type = l.getValue("members_type"),
                type_type = l.getValue("type_type"),
                type_member = l.getValue("type_member"),
                type_property = l.getValue("type_property"),
                members_params = l.getValue("members_params"),
                members_params_name = l.getValue("members_params_name"),
                members_params_description = l.getValue("members_params_description")
            };

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////
        // METHODES /////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        
      



        public void makeHtml(String destPath)
        {
            Console.WriteLine("generate : TreeView");
            //Make treeView----------------------------
            String text = TV_DIV + "\n   <ul>";
            var id = new IdTree(0);
            text += root.makeHtmlTree(id,0);
            text += "</ul>";
            files.Add("treeview.html", text);

            //Make Index-------------------------------
            text = BASE_HTML;
            text += "<h1>" + this.assemblyName + "</h1>";
            text += "<h2>" + "" + "</h2><br>";
            text += "<h3>NameSpaces</h3>";
            text += "<table class='paleBlueRows'>\n" +
                "<thead> <tr>\n" +
                " <th>"+lang.members_name+ "</th>\n" +
                "</tr></thead>\n" +
                "<tbody>";
            foreach(NameSpace ns in root.Childs)
            {
                text += "<tr>\n";
                text += "<td><a href='"+ns.Name + "-" + ns.Mpid + ".html'>" + ns.Name + "</a></td>";
                text += "</tr>";
            }
            text += "</tbody></table>";

            text += "<h3>" + lang.members + "</h3>";
            text += "<table class='paleBlueRows'>\n" +
                "<thead> <tr>\n" +
                " <th>"+lang.members_name+ "</th>\n" +
                "</tr></thead>\n" +
                "<tbody>";
            foreach(Member ns in root.Members)
            {
                text += "<tr>\n";
                text += "<td><a href='"+ns.Name + "-" + ns.Mpid + ".html'>" + ns.Name + "</a></td>";
                text += "</tr>";
            }
            text += "</tbody></table>";

            text += "<div id='MenuvCategorie'>";
            text += files["treeview.html"];
            text += "</div>";
            text += END_HTML;
            try
            {
                files.Add("index.html", text);
            }
            catch (Exception e) { }

            //Make members--------------------------------------------------------------------------
            foreach (Member m in members)
            {
                Console.WriteLine("generate : "+m.Name+"-"+m.Mpid+".html");
                if (m.Type.Equals(MemberType.Type))
                {
                    text = BASE_HTML;
                    text += "<h1>" + m.Name + "</h1>\n";
                    text += "<h2>" + m.Summary + "</h2>\n<br>\n";
                    text += "<h3>" + lang.members + "</h3>\n";
                    text += "<table class='paleBlueRows'>\n" +
                        "<thead> <tr>\n" +
                        " <th>" + lang.members_name + "</th>\n<th>" + lang.members_type + "</th>\n" +
                        "</tr></thead>\n";
                    foreach(Member childm in m.Members)
                    {
                        if (childm.Name.Equals("#ctor")) { childm.Name = "Constructor"; }
                        text += "<tr><td><a href='"+m.Name  +"_"+ childm.Name+"-"+childm.Mpid + ".html'><strong>"+childm.Name +"</strong>"+ "" + "</a></td><td>"+childm.Type.ToString()+"</td></tr>\n";
                        
                    }
                    if (m.Remarks != null)
                    {
                        text += "<h4>" + m.Remarks + "</h4>\n";
                    }
                    makeChilds(m);
                    text += "</table>\n";
                    text += "<div id='MenuvCategorie'>\n";
                    text += files["treeview.html"] + "\n";
                    text += "</div>\n";
                    text += END_HTML;
                    try
                    {
                        files.Add(m.Name + "-" + m.Mpid + ".html", text);
                    }
                    catch (Exception e) {}
                }
              
            }

            //Make namespaces files
            root.makeHtml(files);

            Directory.CreateDirectory(destPath);
            //WriteFiles------------------------------------
            foreach (KeyValuePair<string,string> pair in files)
            {
                try
                {
                    var strm = File.Create(destPath + "\\" + pair.Key);
                    Console.WriteLine(strm.Name);
                    var sw = new StreamWriter(strm);
                    sw.WriteLine(pair.Value);
                    sw.Flush();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

     
        }

        public void makeChilds(Member m)
        {
            foreach(Member mb in m.Members)
            {
                String text = BASE_HTML;
                text += "<h2><a href='"+m.Name+"-"+m.Mpid+".html'>"+m.Name+"</a><strong>." + mb.Name +"</strong>"+ mb.Signature +"</h2>";
                text += "<h2>" + mb.Summary + "</h2><br>";
                if(mb.Paramlst.Count > 0)
                {
                    text += "<table class='paleBlueRows'>\n" +
                     "<thead> <tr>\n" +
                     " <th>" + lang.members_params_name + "</th>\n<th>" + lang.members_params_description + "</th>\n" +
                     "</tr></thead>\n";
                    foreach (KeyValuePair<string,string> pair in mb.Paramlst)
                    {

                        text += "<tr><td>" + pair.Key + "</td><td>" + pair.Value + "</td></tr>";
                    }
                    
                    text += "</table>";
                }
                if (mb.Remarks != null)
                {
                    text += "<h4>" + mb.Remarks + "</h4>\n";
                }
                text += "<div id='MenuvCategorie'>";
                text += files["treeview.html"];
                text += "</div>";
                text += END_HTML;
                try
                {
                    files.Add(m.Name + "_"+mb.Name+"-"+mb.Mpid+".html", text);
                }
                catch (Exception e) { }
            }

        }

        public String toString()
        {
            return root.toString();
        }





        private void commonBuilder(String path)
        {
            this.xmld = new XmlDocument(path, true);
            var doc = xmld.getNode("doc");
            this.assemblyName = doc.getChild("assembly").getChildV("name");

            foreach (XmlNode node in doc.getChild("members").getChildList())
            {
                Console.WriteLine("parse member : " + node.getAttibuteV("name"));

                members.Add(new Member(node, this));
            }
        }






        public NameSpace Root { get => root; set => root = value; }
        public string AssemblyName { get => assemblyName; set => assemblyName = value; }
        public XmlDocument Xmld { get => xmld; set => xmld = value; }
        public List<Member> Members { get => members; set => members = value; }
    }
}