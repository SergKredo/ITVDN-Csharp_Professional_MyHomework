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
                for (int j = 0; j < 2; j++)
                {
                    informationDays[i] += daysOfMonths[i, j] + " ";
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
                    return informationDays[index - 1].ToString()+"\n";
                }
                else if (index >= 28 && index <= 31)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        if (informationDays[i].Contains(index.ToString()))
                        {
                            Console.WriteLine(informationDays[i]);
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

            MyListMonth list = new MyListMonth(2020);
            foreach (var item in list.listMonth)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }

            Console.WriteLine(new string('-', 20));

            foreach (var item in list.DaysOfMonth())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 20));

            Console.Write(list[9]);

            Console.WriteLine(new string('-', 20));

            Console.Write(list[31]);

            Console.WriteLine(new string('-', 20));


            Console.ReadKey();
        }
    }
}
