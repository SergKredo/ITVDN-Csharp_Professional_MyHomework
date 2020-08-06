using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Additional_Task
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    class AccessLevelAttribute : Attribute
    {
        Human human;
        DateTime date;
        StreamWriter writer;
        AccessLevelControl accessLevel;
        public AccessLevelAttribute(AccessLevelControl accessLevelControl)
        {
            this.accessLevel = accessLevelControl;
            date = DateTime.Now;
            FileInfo file = new FileInfo("Bank data.dat");
            writer = file.AppendText();
        }

        public void Access(Human human)
        {
            switch (accessLevel)
            {
                case AccessLevelControl.MiddleControlforManager:
                    {
                        writer.WriteLine(date + "\r\n");
                        writer.WriteLine("An employee {0} {1} with the 'manager' access level tried to access the company's bank database.\r\n", human.name, human.lastName);
                        writer.Close();
                        Console.WriteLine("Unfortunately, access to the bank database for employees with the 'manager' access level is prohibited!");
                        break;
                    }
                case AccessLevelControl.LowControlforProgrammer:
                    {
                        writer.WriteLine(date + "\r\n");
                        writer.WriteLine("An employee {0} {1} with the 'programmer' access level tried to access the company's bank database.\r\n", human.name, human.lastName);
                        writer.Close();
                        Console.WriteLine("Unfortunately, access to the bank database for employees with the 'programmer' access level is prohibited!");
                        break;
                    }
                case AccessLevelControl.FullControlforDirector:
                    {
                        writer.WriteLine(date + "\r\n");
                        writer.WriteLine("An employee {0} {1} with the 'director' access level has successfully accessed the company's bank database.\r\n", human.name, human.lastName);
                        writer.Close();
                        Console.WriteLine("Access to the bank database for employees with 'director' access level is open!");
                        break;
                    }
                default:
                    {
                        writer.WriteLine(date + "\r\n");
                        writer.WriteLine("Sided man with 'an unidentified user' access level tried to gain access to banking database company.\r\n");
                        writer.Close();
                        Console.WriteLine("Access to the bank database for other categories of persons with the 'unidentified person' access level is prohibited!");
                        break;
                    }
            }
        }
    }

    enum AccessLevelControl
    {
        FullControlforDirector, MiddleControlforManager, LowControlforProgrammer
    }
}
