using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.Data;
using Microsoft;
using static NTK.Other.NTKF;

namespace NTK.IO.IS
{
    /// <summary>
    /// 
    /// </summary>
    public class ISParser
    {


        public struct Var
        {
            public String name;
            public String value;
        }

        private String name;
        private String version;
        private String path;
        private String localdir;

        private List<String> instructions = new List<String>();
        private List<String> directives = new List<String>();
        private List<Var> vars = new List<Var>();
        private List<Function> functions = new List<Function>();

        public ISParser(String path, bool install = false)
        {
            this.path = path;
            this.localdir = Path.GetDirectoryName(path);
            if (install) { this.install(); }
        }

        public void install()
        {
            List<String> lst = new List<String>();
            lst.AddRange(File.ReadLines(path));
            var txt = File.ReadAllText(path);
            
          
            //Lecture de l'entête + directives + variables globales + fonctions
            for(int i = 0; i < lst.Count; i++)
            {
                if (lst[i].Contains("IS-") && lst[i].Contains("||") && lst[i].Contains("-IS"))
                {
                    this.name = subsep(lst[i], "IS-\"", "\"||");
                    this.version = subsep(lst[i], "||\"", "\"-IS");
                    lst.RemoveAt(i--);
                }
                else if (lst[i].Contains("function "))
                {
                    var fname = subsep(lst[i], "function ", "(");
                    var args = subsep(lst[i], "(", ")");
                    var type = "void";
                    if (lst[i].Contains(":"))
                    {
                        type = subsep(lst[i], ":");
                    }
                    lst.RemoveAt(i);
                    var flst = new List<String>();
                    while (!lst[i].Contains("endf"))
                    {
                        flst.Add(lst[i]);
                        lst.RemoveAt(i--);
                        i++;
                    }
                    functions.Add(new Function(fname, type, args, flst));
                    lst.RemoveAt(i--);
                }
                else if (lst[i].Contains("var "))
                {
                    String vname = subsep(lst[i], "*", "=");
                    String vvalue = "";
                    if (nbChar(lst[i], '"')==1)
                    {
                        while (!lst[i].Contains("\";"))
                        {
                            vvalue += lst[i];
                            lst.RemoveAt(i--);
                            i++;
                        }
                        vvalue += subsep(lst[i], 0, "\";");
                    }
                    lst.RemoveAt(i--);
                }
                else if (lst[i].Length >0 && lst[i][0].Equals('$'))
                {
                    directives.Add(lst[i]);
                    lst.RemoveAt(i--);
                }//Directives
                
            }
            Console.ReadLine();

            if (directives.Contains("$NO_STRUCT"))
            {
                //Lecture des instructions
                for (int i = 0; i < lst.Count; i++)
                {
                    var cmd = lst[i];
                    if (cmd.Contains("mkdir "))
                    {
                        var mkpath = subsep(cmd, "mkdir \"", "\";");
                        //Make dir
                    }
                    else if (cmd.Contains("deld"))
                    {
                        var deldpath = subsep(cmd, "deld \"", "\";");
                    }
                    else if (cmd.Contains("delf"))
                    {
                        var delfpath = subsep(cmd, "delf \"", "\";");
                    }
                    else if (cmd.Contains("movef"))
                    {

                    }
                    else if (cmd.Contains("moved"))
                    {

                    }
                    else if (cmd.Contains("mksc"))
                    {

                    }
                    else if (cmd.Contains("set"))
                    {

                    }
                    else if (cmd.Contains("exit"))
                    {

                    }//Structures
                    else if (cmd.Contains("switch"))
                    {

                    }
                    else if (cmd.Contains("try"))
                    {

                    }
                    else if (cmd.Contains("catch"))
                    {

                    }
                    else if (cmd.Contains("if"))
                    {

                    }
                    else if (cmd.Contains("call "))
                    {

                    }
                }
            }
            else
            {
                getFunction("init").execute();
                getFunction("install").execute();
                getFunction("finalize").execute();
                
            }
        }


        Var getVar(String name)
        {
            Var ret = new Var
            {
                name = null,
                value = null
            };
            int cpt = 0;
            while(cpt<vars.Count && !name.Equals(vars[cpt]))
            {
                cpt++;
                if (vars[cpt].Equals(name)) { ret = vars[cpt]; }
            }

            return ret;
        }


        Function getFunction(String name)
        {
            Function ret = null;
            int cpt = 0;
            while (cpt < functions.Count && !name.Equals(functions[cpt]))
            {
                cpt++;
                if (functions[cpt].Equals(name)) { ret = functions[cpt]; }
            }
            return ret;
        }












    }
}
