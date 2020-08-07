using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    [AccessLevel(AccessLevelControl.AccessIsDenied)]
    class Other : Human
    {
        public Other(string name, string lastName)
           : base(name, lastName)
        {

        }
    }
}
