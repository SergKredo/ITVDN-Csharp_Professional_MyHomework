using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Additional_Task
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            while (true)
            {
                Human human;
                Console.WriteLine("Enter your details:".ToUpper());
                Console.Write("Access level: ");
                string accessLevel = Console.ReadLine();

                Console.Write("Username: ");
                string userName = Console.ReadLine();

                Console.Write("User surname: ");
                string userSurname = Console.ReadLine();

                switch (accessLevel)
                {
                    case "Programmer":
                        {
                            human = new Programmer(userName, userSurname);
                            human.OpenToBaseBankDate(human);
                            break;
                        }
                    case "Director":
                        {
                            human = new Director(userName, userSurname);
                            human.OpenToBaseBankDate(human);
                            break;
                        }
                    case "Manager":
                        {
                            human = new Manager(userName, userSurname);
                            human.OpenToBaseBankDate(human);
                            break;
                        }
                    default:
                        {
                            human = new Other(userName, userSurname);
                            human.OpenToBaseBankDate(human);
                            break;
                        }
                }
            }
        }
    }
}
