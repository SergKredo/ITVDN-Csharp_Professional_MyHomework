using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    [AccessLevel(AccessLevelControl.LowControlforProgrammer)]
    class Programmer : Human
    {
        public Programmer(string name, string lastName)
           : base(name, lastName)
        {

        }
    }
}
