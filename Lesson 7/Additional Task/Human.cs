using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Additional_Task
{
    abstract class Human
    {
        public readonly string name;
        public readonly string lastName;
 
        protected Human(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
        }

        public void OpenToBaseBankDate(Human human)
        {
            InvokeAttribute(human);
        }
        static void InvokeAttribute(Human human)
        {
            Type person = human.GetType();
            object[] attribute = person.GetCustomAttributes(typeof(AccessLevelAttribute), false);
            foreach (AccessLevelAttribute item in attribute)
            {
                item.Access(human);
            }
        }
    }
}
