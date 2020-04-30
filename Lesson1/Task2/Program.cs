using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    /*Задание 2
Создайте коллекцию, в которой бы хранились наименования 12 месяцев, порядковый номер и
количество дней в соответствующем месяце. Реализуйте возможность выбора месяцев, как по
порядковому номеру, так и количеству дней в месяце, при этом результатом может быть не
только один месяц.*/

    public class MyListMonth : IEnumerable
    {
        int daysOfFebruary;
        public Dictionary<int, string> listMonth;
        object[,] daysOfMonths;
        string[] informationDays;
        DateTime timeYear;
        TimeSpan differenceTime;
        public IEnumerator GetEnumerator()
        {
            foreach (var item in listMonth)
            {
                yield return item;
            }
        }

        public MyListMonth(int year)
        {
            timeYear = new DateTime(year, 01, 01);
            differenceTime = timeYear.AddYears(1) - timeYear;
            listMonth = new Dictionary<int, string>()
            {
                {1, "January"}, {2, "February"}, {3, "March"}, {4, "April"}, {5, "May"}, {6, "June"},
                {7, "July"}, {8, "August"}, {9, "September"}, {10, "October"}, {11, "November"}, {12, "December"}
            };
            switch (differenceTime.Days)
            {
                case 365:
                    daysOfFebruary = 28;
                    break;
                case 366:
                    daysOfFebruary = 29;
                    break;
                default:
                    daysOfFebruary = 28;
                    break;
            }
            daysOfMonths = new object[,]
            {
                {31, "January"}, {daysOfFebruary, "February"}, {31, "March"}, {30, "April"}, {31, "May"}, {30, "June"},
                {31, "July"}, {31, "August"}, {30, "September"}, {31, "October"}, {30, "November"}, {31, "December"}
            };
            informationDays = new string[12];
        }
        public IEnumerable DaysOfMonth()
        {
            for (int i = 0; i < informationDays.Length; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    informationDays[i] = daysOfMonths[i, j] + " ";
                }
                yield return informationDays[i];
            }
        }

        public object this[int index]
        {
            get
            {
                if (index <= 12 && index >= 0)
                {
                    return "    " + (index).ToString() + "\t     " + listMonth[index].ToString() + "\t    " + informationDays[index - 1].ToString() + "\n";
                }
                else if (index >= 28 && index <= 31)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        if (informationDays[i].Contains(index.ToString()))
                        {
                            Console.WriteLine("    " + (i + 1).ToString() + "\t     " + listMonth[i + 1].ToString() + "\t    " + informationDays[i].ToString());
                        }
                    }
                    return null;
                }
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сalendar program".PadLeft(30).ToUpper());
            Console.Write("Enter the year you are interested in: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            int year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(new string('-', 42));
            Console.WriteLine(" | Number " + "|" + "   Month   " + "|" + " Days of month |");
            Console.WriteLine(new string('-', 42));
            MyListMonth list = new MyListMonth(year);

            foreach (var item in list.listMonth)
            {
                Console.WriteLine("    " + item.Key + "\t    " + item.Value + " \t ");
            }
            Console.CursorTop = 5;

            foreach (var item in list.DaysOfMonth())
            {
                Console.CursorLeft = 28;
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('-', 42));

            while (true)
            {
                Console.WriteLine(new string('-', 42));

                Console.Write("Find the month you are interested in by consecutive number\nor number of days in the month: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                int index = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(new string('-', 42));
                Console.Write(list[index]);
                Console.WriteLine(new string('-', 42));
            }
        }
    }
}
