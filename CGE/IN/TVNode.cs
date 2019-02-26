using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CGE.NTKF;

namespace CGE.IN
{
    public class TVNode
    {
        private String name;
        private List<TVNode> nodelist = new List<TVNode>();
        private bool isValue;
        private bool isSelected = false;


        public TVNode(String name, bool isValue = false, bool isSelected = false)
        {
            this.Name = name;
            this.isValue = isValue;
            this.isSelected = isSelected;
        }

        public TVNode add(String name, bool isValue = false)
        {
            TVNode node = new TVNode(name, isValue);
            nodelist.Add(node);
            return node;
        }
        public TVNode get(int id)
        {
            return nodelist[id];
        }


        public bool haveChild()
        {
            return (nodelist.Count >= 1);
        }


        public void print(TreeView tv,TVNode parent, int indentLvl, bool lastNode = false,ConsoleKey key = ConsoleKey.LeftArrow)
        {
            var str = generStr(indentLvl, "┃  ");
            if (lastNode && !haveChild())
            {
                str += "┖";
            }
            else
            {
                str += "┣";
            }

            Console.BackgroundColor = tv.DefaultBackColor;
            Console.ForegroundColor = tv.DefaultForeColor;
            Console.Write(str);
            if (isSelected)
            {
                Console.BackgroundColor = tv.SelectBackColor;
                Console.ForegroundColor = tv.SelectForeColor;
            }
            Console.Write(this.name + "\n");

            if (!isValue)
            {
                for (int i = 0; i < nodelist.Count; i++)
                {
                    if (i != nodelist.Count -1 )
                    {
                        nodelist[i].print(tv, this,indentLvl + 1, false,key);
                    }
                    else
                    {
                        nodelist[i].print(tv, this,indentLvl + 1, true,key);
                    }
                }
            }
            int cpt = searchSelected();
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    if (cpt != -1)
                    {
                        if (cpt < nodelist.Count - 1)
                        {
                            nodelist[cpt].IsSelected = false;
                            nodelist[cpt + 1].IsSelected = true;

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
                            nodelist[nodelist.Count - 1].IsSelected = true;
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
                case ConsoleKey.LeftArrow:
                    if (cpt != -1 && nodelist[cpt].haveChild())
                    {
                        nodelist[cpt].IsSelected = false;
                        nodelist[cpt].get(0).IsSelected = true;
                    }
                    break;
            }

        }
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
        public string Name { get => name; set => name = value; }
        public List<TVNode> Nodelist { get => nodelist; set => nodelist = value; }
        public bool IsValue { get => isValue; }
        public bool IsSelected { get => isSelected; set => isSelected = value; }
    }
}
