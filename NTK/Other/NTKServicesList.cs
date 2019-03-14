using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NTK.IO;
using NTK.Service;


namespace NTK.Other
{
    public class NTKServicesList
    {
        List<NTKService> lst = new List<NTKService>();

        public NTKServicesList(String dirPath)
        {

        }

        public NTKServicesList(DllLoader loader)
        {
            
        }

        public NTKServicesList(params NTKService[] tab)
        {
            foreach(NTKService elem in tab)
            {
                lst.Add(elem);
            }
        }

        public NTKService getServiceByName(String name)
        {
            NTKService ret = null;
            bool end = false;
            int cpt = 0;
            while (!end)
            {
                if(cpt == lst.Count){ end = true; }
                else if (lst[cpt].Config.name.Equals(name))
                {
                    ret = lst[cpt];
                    end = true;
                }
                else { cpt++; }
            }
            return ret;
        }

    }
}
