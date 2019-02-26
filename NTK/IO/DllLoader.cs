using Microsoft.CSharp.RuntimeBinder;
using NTK.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Binder = System.Reflection.Binder;

namespace NTK.IO
{
    public class DllLoader
    {
        private String path;
        private Assembly dll;


        public DllLoader() { }

        public DllLoader(String path) {
            this.path = path;
            this.dll = Assembly.LoadFile(path);
        }

        public T getClassInstance<T>(String name)
        {
            return (T)this.dll.CreateInstance(name, true);
        }

        public List<T> getClassInstancelike<T>(String like)
        {
            var ret = new List<T>();
            foreach (Type type in dll.GetExportedTypes())
            {
                if (type.Name.Contains(like))
                {
                    Console.WriteLine(" - " + type.Name);
                    ret.Add((T)this.dll.CreateInstance(type.FullName, true));
                }
            }

            return ret;
        }
    }
}
