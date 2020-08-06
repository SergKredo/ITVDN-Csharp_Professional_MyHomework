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
        static void Main(string[] args)
        {
            Human human = new Programmer("Piter", "Ivanov");
            human.OpenToBaseBankDate(human);

            human = new Director("Sergey", "Petrov");
            human.OpenToBaseBankDate(human);

            human = new Manager("Elena", "Hurova");
            human.OpenToBaseBankDate(human);

            Console.ReadKey();
        }
    }
}
