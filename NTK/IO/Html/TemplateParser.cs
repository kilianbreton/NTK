using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NTK.Other.NTKF;

namespace NTK.IO.Html
{
    /// <summary>
    /// 
    /// </summary>
    public class TemplateParser
    {
        private String[] text;
        private Dictionary<string, string> vars = new Dictionary<string, string>();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathOrText">code Html ou chemin vers fichier html</param>
        /// <param name="isPath">true si c'est un chemin</param>
        public TemplateParser(string pathOrText, bool isPath = true)
        {
            if (isPath)
            {
                text = System.IO.File.ReadAllLines(pathOrText);
            }
            else
            {
                text = pathOrText.Split('\n','\r');
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string parse()
        {
            String ret = "";
            for (int i = 0; i < text.Length; i++)
            {
                var line = text[i];
                if(line.Contains("{{") && line.Contains("}}"))
                {
                    var varname = subsep(line, "{{", "}}");
                    line.Replace("{{" + varname + "}}", vars[varname.Trim(' ')]);
                    ret += line;
                }
                else if(line.Contains("{%") && line.Contains("%}"))
                {
                    var instruction = subsep(line, "{{", "}}");

                    if (instruction.Contains("for") && instruction.Contains("in"))
                    {

                    }



                }
                else
                {
                    ret += line;
                }
            }
            return ret;
        }



        private string parseForEach(int index)
        {
            String ret = "";
            while (text[index].Contains("{{") && text[index].Contains("}}") && text[index].Contains("endfor"))
            {



            }


            return ret;
        }

        



        public Dictionary<string, string> Vars { get => vars; set => vars = value; }


    }
}
