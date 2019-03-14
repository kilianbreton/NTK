using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CGE.NTKF;

namespace CGE.IN
{

    /// <summary>
    /// 
    /// </summary>
    public class TreeView : CGEObject
    {
        private List<TVNode> nodelist;
        private ConsoleColor defaultBackColor = ConsoleColor.Black;
        private ConsoleColor defaultForeColor = ConsoleColor.Green;
        private ConsoleColor selectBackColor = ConsoleColor.DarkRed;
        private ConsoleColor selectForeColor = ConsoleColor.White;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        public TreeView(TVNode node)
        {
            this.Nodelist = new List<TVNode>();
            this.Nodelist.Add(node);
            Console.OutputEncoding = Encoding.Unicode;
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        public TreeView(List<TVNode> list)
        {
            this.Nodelist = list;
            Console.OutputEncoding = Encoding.Unicode;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        public override void draw(int i = 0)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string show()
        {
            var end = false;
            var key = ConsoleKey.A;
            while (!end)
            {
                Console.Clear();
               
                for (int i = 0; i < Nodelist.Count; i++)
                {
                    if (i != Nodelist.Count - 1)
                    {
                        Nodelist[i].print(this,null, 0, false,key);
                    }
                    else
                    {
                        Nodelist[i].print(this,null, 0, true,key);
                    }
                }
                key = Console.ReadKey().Key;
                int cpt = searchSelected();
                switch (key)
                {
                    case ConsoleKey.Escape:
                        end = true;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cpt != -1)
                        {
                            if(cpt < nodelist.Count-1)
                            {
                                nodelist[cpt].IsSelected = false;
                                nodelist[cpt+1].IsSelected = true;

                            }
                            else
                            {
                                nodelist[cpt].IsSelected = false;
                                nodelist[0].IsSelected = true;
                            }
                        }

                        break;
                    case ConsoleKey.UpArrow:
                        if (cpt != -1)
                        {
                            if (cpt > 0)
                            {
                                nodelist[cpt].IsSelected = false;
                                nodelist[cpt - 1].IsSelected = true;

                            }
                            else
                            {
                                nodelist[cpt].IsSelected = false;
                                nodelist[nodelist.Count-1].IsSelected = true;
                            }
                        }

                        break;

                    case ConsoleKey.RightArrow:
                        if (cpt != -1 && nodelist[cpt].haveChild())
                        {
                            nodelist[cpt].IsSelected = false;
                            nodelist[cpt].get(0).IsSelected = true;
                        }
                        break;
                }

            }


            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int searchSelected()
        {
            int cpt = 0;
            bool end = false;
            bool find = false;
            while (!end)
            {
                if (cpt == nodelist.Count)
                {
                    end = true;
                }
                else if (nodelist[cpt].IsSelected)
                {
                    end = true;
                    find = true;
                }
                else
                {
                    cpt++;
                }
            }//Boucle de recherche

            if (!find)
            {
                cpt = -1;
            }
            return cpt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bad"></param>
        public override void stop(bool bad = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor DefaultBackColor { get => defaultBackColor; set => defaultBackColor = value; }
        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor DefaultForeColor { get => defaultForeColor; set => defaultForeColor = value; }
        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor SelectBackColor { get => selectBackColor; set => selectBackColor = value; }
        /// <summary>
        /// 
        /// </summary>
        public ConsoleColor SelectForeColor { get => selectForeColor; set => selectForeColor = value; }
        /// <summary>
        /// 
        /// </summary>
        public List<TVNode> Nodelist { get => nodelist; set => nodelist = value; }
    }
}
