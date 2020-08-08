using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Additional_Task
{
    /*    
         Создайте пользовательский атрибут AccessLevelAttribute, позволяющий определить
    уровень доступа пользователя к системе. Сформируйте состав сотрудников некоторой фирмы
    в виде набора классов, например, Manager, Programmer, Director. При помощи атрибута
    AccessLevelAttribute распределите уровни доступа персонала и отобразите на экране
    реакцию системы на попытку каждого сотрудника получить доступ в защищенную секцию.*/
    class Program
    {
        [STAThread]  //Атрибут STAThread указывает, что потоковой моделью COM для приложения является однопотоковое подразделение (STA). 
        //Применяется когда, Вы разрабатываете приложение Windows Forms. Windows Forms приложения должны быть однопотоковыми, если они взаимодействуют с компонентами системы Windows, 
        //такими как буфер обмена или общие диалоговые окна Windows, или если они используют системные функции, такие как функции перетаскивания. 
        static void Main(string[] args)
        {
            while (true)  // Бесконечный цикл
            {
                Human human;
                Console.WriteLine("Enter your details:".ToUpper());
                Console.Write("Access level: ");
                string accessLevel = Console.ReadLine();   // Ввод данных о позиции пользователя в компании

                Console.Write("Username: ");
                string userName = Console.ReadLine();   // Имя пользователя

                Console.Write("User surname: ");
                string userSurname = Console.ReadLine();  // Фамилия пользователя

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

/*
 Results:
----------------------------------------------------------------------------------------------------------------------------------------------
ENTER YOUR DETAILS:
Access level: Manager
Username: Yulia
User surname: Gricai
----------------------------------------------------------------------------------------------------
Unfortunately, you do not have access to the company's banking data, but you can use other data permitted for your access level!
----------------------------------------------------------------------------------------------------
ENTER YOUR DETAILS:
Access level: Director
Username: Oleg
User surname: Ivanov
----------------------------------------------------------------------------------------------------
You have gained access to banking operations in the company!
Bank data:
Here are the main banking operations performed by the company during 2010-2020!
Bank operation: ($)
3232323
2323232
87842
652323
565332
5323541
124546
622656
56324596523
5622656
4632326562
45623265
335653
4623265
6323232
46232356
30,2655
----------------------------------------------------------------------------------------------------
ENTER YOUR DETAILS:
Access level: Programmer
Username: Kostantin
User surname: Leonov
----------------------------------------------------------------------------------------------------
Unfortunately, you do not have access to the company's banking data, but you can use other data permitted for your access level!
----------------------------------------------------------------------------------------------------
ENTER YOUR DETAILS:
Access level: jfifjijf
Username: fjikm,fm,
User surname: fkkfjkf
----------------------------------------------------------------------------------------------------
Unfortunately, you are denied access to the company's banking data!
----------------------------------------------------------------------------------------------------
ENTER YOUR DETAILS:
Access level:


08.08.2020 12:17:02

An employee Yulia Gricai with the 'manager' access level tried to access the company's bank database.

08.08.2020 12:17:17

An employee Oleg Ivanov with the 'director' access level has successfully accessed the company's bank database.

08.08.2020 12:17:44

An employee Kostantin Leonov with the 'programmer' access level tried to access the company's bank database.

08.08.2020 12:17:56

Sided man with 'an unidentified user' access level tried to gain access to banking database company.


 */
