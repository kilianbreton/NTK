using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.EventsArgs
{
    public interface IEventEnum
    {
        bool next();
        string get(string name);
    }
}
