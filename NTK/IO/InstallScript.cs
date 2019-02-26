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

namespace NTK.IO
{
    public class InstallScript
    {
 
        public struct Var
        {
            public String name;
            public String value;
        }
        
        private String path;
        private String localdir;
        private List<String> lasInstructions = new List<String>();
        private List<String> directives = new List<String>();
        private List<Var> vars = new List<Var>();

        public InstallScript(String path,bool install =false)
        {
            this.path = path;
            this.localdir = Path.GetDirectoryName(path);
            if (install){ this.install(); }
        }

        //Fichier de script d'installation
        //--------------------------------
        //mkdir #directory#;
        //move #file#>#directory#;

        //set #regkey#>#value#;
        //set HKEY_CURRENT_CONFIG\#path#\-\key>#value#;
        //set HKEY_USERS
        //set HKEY_LOCAL_MACHINE
        //set HKEY_CURRENT_USER
        //set HKEY_CLASSES_ROOT
        //
        //mksc  #shortcut#sourcefile#>#;
        public void install()
        {
            bool comment = false;
            foreach (string line in File.ReadLines(path))
            {
                String tmp = line;
                Console.WriteLine(tmp);
                parser(tmp);
                

            }
        }

        public void parser(String tmp)
        {
            bool comment = false;
            if (tmp.Contains("//-"))
            {
                if (tmp.Contains(@"-\\"))
                {
                    tmp = delseps(tmp, "//-", @"-\\");
                }
                else
                {
                    comment = true;
                }
            }

            if (!comment)
            {
                //Instructions
                if (tmp.Contains("CLOSED") & tmp.Contains(";") & tmp.Contains(","))
                {
                    lasInstructions.Add(subsep(tmp, 0, ",") + ";");
                }
                else if (tmp.Contains("mkdir ") & tmp.Contains(";"))
                {
                    try
                    {
                        Directory.CreateDirectory(parsePath(subsep(tmp, "mkdir ", ";")));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (tmp.Contains("movef") & tmp.Contains(";"))
                {
                    try
                    {
                        File.Move(localdir + "" + subsep(tmp, "movef ", ">"), parsePath(subsep(tmp, ">", ";")));
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }       
                }
                else if (tmp.Contains("moved") & tmp.Contains(";"))
                {
                    String basePath = parsePath(subsep(tmp, "moved ", ">"));
                    String lastPath = parsePath(subsep(tmp, ">", ";"));
                    DoCopyFolder(basePath, lastPath);


                }
                else if (tmp.Contains("set") & tmp.Contains(";"))
                {
                    parseReg(tmp);

                }
                else if (tmp.Contains("var") & tmp.Contains(";"))
                {
                    if (tmp.Contains("*") && tmp.Contains("=") && tmp.Contains(";"))
                    {
                        Var tmpv;
                        tmpv.name = subsep(tmp, "*", "=").Trim();
                        tmpv.value = parsePath(subsep(tmp, "=", ";").Trim());
                        vars.Add(tmpv);
                    }
                    else
                    {
                        //throw exception
                    }
                }
                else if (tmp.Contains("mksc") & tmp.Contains(";"))
                {

                }
                else if (tmp.Contains("IS-") & tmp.Contains("-IS"))
                {

                }
                else if (tmp.Contains("deld") & tmp.Contains(";"))
                {
                    try
                    {
                        Directory.Delete(parsePath(subsep(tmp, "deld ", ";")));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (tmp.Contains("delf") & tmp.Contains(";"))
                {
                    try
                    {
                        File.Delete(parsePath(subsep(tmp, "delf ", ";")));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (tmp.Contains("delr") & tmp.Contains(";"))
                {
                    parseReg(tmp, true);
                }//Directives-----------------------------------------------------------------------------------------------
                else if (tmp.ElementAt(0).Equals('$'))
                {
                    if (tmp.Contains("$N_"))
                    {

                    }
                    else
                    {
                        directives.Add(tmp);
                    }

                }


            }
            if (tmp.Contains("-\\"))
            {
                comment = false;
            }
        }

        private void DoCopyFolder(string source, string destination)
        {
            string[] theDirectories = Directory.GetDirectories(source);
            foreach (string curDir in theDirectories)
            {

                if (!Directory.Exists(destination.Substring(0, destination.IndexOf("\\")) + curDir.Substring(curDir.IndexOf("\\"))))
                {
                    Directory.CreateDirectory(destination.Substring(0, destination.IndexOf("\\")) + curDir.Substring(curDir.IndexOf("\\")));
                }

                this.DoCopyFolder(curDir, destination.Substring(0, destination.IndexOf("\\")) + curDir.Substring(curDir.IndexOf("\\")));
            }

            string[] theFilesInCurrentDir = Directory.GetFiles(source);
            foreach (string currentFile in theFilesInCurrentDir)
            {
                this.DoCopyFile(currentFile, destination);
            }
        }

        private void DoCopyFile(string source, string destination)
        {
            File.Copy(source, destination + "\\" + Path.GetFileName(source));
        }

        public void parseReg(String path, bool rm = false)
        {
            String root = null;
            if (rm)
            {
                root = subsep(path, "delr ", "\\");
            }
            else
            {
                root = subsep(path, "set ", "\\");
            }
         
            String endpath = subsep(path, "\\", "\\-\\");
            String key = subsep(path, "\\-\\", ">");
            String value = subsep(path, ">", ";");
            RegistryKey basekey = null;
            switch (root)
            {
                case "HKEY_CURRENT_USER":
                    basekey = Registry.CurrentUser;
                    break;
                case "HKEY_LOCAL_MACHINE":
                    basekey = Registry.LocalMachine;
                    break;
                case "HKEY_CURRENT_CONFIG":
                    basekey = Registry.CurrentConfig;
                    break;
                case "HKEY_USERS":
                    basekey = Registry.Users;
                    break;
                case "HKEY_CLASSES_ROOT":
                    basekey = Registry.ClassesRoot;
                    break;
                default:
                    basekey = Registry.LocalMachine;
                    break;
            }
           
            if (rm)
            {
                RegistryKey endkey = basekey.OpenSubKey(endpath);
                endkey.DeleteSubKey(key);
            }
            else
            {
                RegistryKey endkey = basekey.OpenSubKey(endpath);
                endkey.SetValue(key,value);
            }
            
        }

        public static String delseps(String text, String sep1, String sep2)
        {
            return subsep(text, 0, sep1) + subsep(text, sep2);
        }

        public String parsePath(String path)
        {
            //HERE
            //THIS
            //PROGRAMS
            //PROGRAMS_FILES
            //DOCUMENTS
            //DESKTOP
            
            String ret = null;
            if (path.Contains("#HERE#"))
            {
                ret = path.Replace("#HERE#", this.localdir);
            }
            else if (path.Contains("#THIS#"))
            {
                ret = path.Replace("#THIS#", this.path);
            }
            else if (path.Contains("#PROGRAMS#"))
            {
                ret = path.Replace("#PROGRAMS#", Environment.GetFolderPath(Environment.SpecialFolder.Programs));
            }
            else if (path.Contains("#PROGRAM_FILES#"))
            {
                ret = path.Replace("#PROGRAM_FILES#", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles));
            }
            else if (path.Contains("#DOCUMENTS#"))
            {
                ret = path.Replace("#DOCUMENTS#", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
            }
            else if (path.Contains("#DESKTOP#"))
            {
                ret = path.Replace("#DESKTOP#", Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            }
            else if (path.Contains("#SOFT_PATH#"))
            {
                ret = path.Replace("#DESKTOP#", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            }

            return ret;
        }
       
    }
}
