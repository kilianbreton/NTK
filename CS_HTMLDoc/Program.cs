using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NTK.IO.Ini;

namespace CS_HTMLDoc
{
    class Program
    {
        static void Main(string[] args)
        {
            args = new string[6];
            args[0] = "-i";
            args[1] = @"D:\Programmation\NTK\ServerAdmin\Kernel\NTK.xml";
            args[2] = "-o";
            args[3] = @"D:\partage\test";
            args[4] = "--lang";
            args[5] = "FR";
            if (args.Length == 0)
            {
                Console.WriteLine("CHD - Need arguments");
                Console.WriteLine("Basic use : chd -i xmlFile -o outputFolder");
                var test = new Documentation(@"D:\Programmation\NTK\ServerAdmin\Kernel\NTK.xml");
                test.makeHtml(@"D:\Programmation\NTK\XML_HTML\test");

                Console.ReadLine();
            }
            else
            {
                if(args.Length == 4 
                    && (args[0].Equals("-i") || args[0].Equals("--in")) 
                    && (args[2].Equals("-o") || args[0].Equals("--out")))
                {

                    var test = new Documentation(args[1]);
                    test.makeHtml(args[3]);
                }
                else if (args.Length >= 6
                   && (args[0].Equals("-i") || args[0].Equals("--in"))
                   && (args[2].Equals("-o") || args[2].Equals("--out"))
                   && (args[4].Equals("-l") || args[4].Equals("--lang")))
                {
                    var test = new Documentation(args[1],args[5]);
                    test.makeHtml(args[3]);
                }
                else if(args.Length ==1 && args[0].Equals("--add_lang") )
                {
                    IniDocument inid = new IniDocument("chd.ini");
                   

                    Console.Write("Language Name : ");
                    var inig = inid.addGroup(Console.ReadLine());

                    Console.Write("original [Members] : ");
                    inig.Values.Add(new IniValue("members",Console.ReadLine()));

                    Console.Write("original [Name] : ");
                    inig.Values.Add(new IniValue("members_name", Console.ReadLine()));

                    Console.Write("original [Type] : ");
                    inig.Values.Add(new IniValue("members_type", Console.ReadLine()));

                    Console.Write("original type.[Type] : ");
                    inig.Values.Add(new IniValue("type_type", Console.ReadLine()));

                    Console.Write("original type.[Member] : ");
                    inig.Values.Add(new IniValue("type_member", Console.ReadLine()));

                    Console.Write("original type.[Property] : ");
                    inig.Values.Add(new IniValue("type_property", Console.ReadLine()));

                    Console.Write("original type.[Field] : ");
                    var members_type_Field = Console.ReadLine();

                    Console.Write("original members.[Params] : ");
                    inig.Values.Add(new IniValue("members_params", Console.ReadLine()));

                    Console.Write("original members.params.[Name] : ");
                    inig.Values.Add(new IniValue("members_params_name", Console.ReadLine()));

                    Console.Write("original members.params.[description] : ");
                    inig.Values.Add(new IniValue("members_params_description", Console.ReadLine()));

                    inid.save();


                }
                else if(args.Length == 2 && args[0].Equals("--add_template"))
                {
                    
                }
                else if (args.Length == 1 && (args[0].Equals("--help") || args[0].Equals("-h")))
                {
                    Console.WriteLine("Make documentation :     (-i || --in) xmlFile (-o || --out) Destination [(-l || --lang) Lang]");
                    Console.WriteLine("Make language :          --add_lang");
                    Console.WriteLine("Set default language :   --def_lang name");
                   // Console.WriteLine("Make template :          --add_template name");
                    //Console.WriteLine("Set default template :   --def_lang name");
                }
                else if (args.Length == 1 && (args[0].Equals("--config") || args[0].Equals("-c")))
                {
                    IniDocument inid = new IniDocument("chd.ini");
                    Console.WriteLine("Default Language :   " + inid.getGroup("BASE").getValue("lang"));
                    Console.WriteLine("Default Template :   " + inid.getGroup("BASE").getValue("template"));
                }
                else
                {

                    Console.WriteLine("CHD - Bad arguments");
                    Console.WriteLine("Basic use : chd -i xmlFile -o outputFolder");
                    Console.WriteLine("use -h or --help");
                }
            }
          
        }
    }
}
