using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /*Задание 3
Несколькими способами создайте коллекцию, в которой можно хранить только целочисленные и
вещественные значения, по типу «счет предприятия – доступная сумма» соответственно.*/
    public class Company  // Объявление класса Company. Класс содержит основную информацию о сумме денег на счете, доходах, расходах компании
    {

        public double AmountInTheAccount { get; }  // Сумма денег на счету компании
        public double AmountArrivals { get; set; }  // Сумма доходов (прирост суммы денег)
        public double AmountOfExpenses { get; set; }  // Сумма расходов (вычитание суммы денег)

        public Company()
        {
            this.AmountInTheAccount = 50000;   // Инициализация автосвойства AmountInTheAccount. Определение начальной суммы денег на счете компании
        }
        public Company(double amount, double amountOfAccount)  // Пользовательский конструктор
        {
            if (amount < 0)  // Вход в блок условной конструкции при расходах
            {
                this.AmountInTheAccount = amountOfAccount;
                this.AmountOfExpenses = amount;
                this.AmountInTheAccount += this.AmountOfExpenses;
            }
            else   // Вход в блок условной конструкции при доходах
            {
                this.AmountInTheAccount = amountOfAccount;
                this.AmountArrivals = amount;
                this.AmountInTheAccount += this.AmountArrivals;
            }
        }
    }

    //1-й способ реализации проекта
    public class CompanyAccount<TKey, TValue> : Dictionary<TKey, TValue>  // Объявление универсального набора данных пар (ключ-значение). Класс наследуется от системного класса Dictionary<TKey, TValue>
    {
        Company company;  // Объявление поля типа Company
        bool expenses = false;  // Булевое поле определяет арифметическую операцию для расходов и доходов компании
        double amountInTheAccount, amountArrivals, amountOfExpenses;  // Поля, которые содержат данные о состоянии в компании: сумма денег на счете, расходы и приходы

        public CompanyAccount()  
        {
            object abj = new object();
            company = new Company();
            this.amountInTheAccount = company.AmountInTheAccount;
            abj = this.amountArrivals;
            Add((TKey)abj);

        }
        public void Add(TKey money)   // Добавление нового элемента пар (ключ-значение) в коллекцию
        {
            if (money.GetType().Name == "Double" || money.GetType().Name == "Int32")
            {
                expenses = (Convert.ToDouble(money) < 0) ? false : true;
                if (expenses)  // Приращение суммы (доходы) к основной сумме на счете компании
                {
                    this.amountArrivals = Convert.ToDouble(money);
                    this[money, company] = this.amountInTheAccount + this.amountArrivals;
                }
                else   // Вычитание суммы (расходы) от основной суммы на счете компании
                {
                    this.amountOfExpenses = Convert.ToDouble(money);
                    this[money, company] = this.amountInTheAccount + this.amountOfExpenses;
                }
            }
        }
        public object this[TKey index, Company i]  // Блок индексатора. Добавление нового элемента пар (ключ-значение) в коллекцию
        {
            set
            {
                object obje = new object();
                Dictionary<double, double> instance = new Dictionary<double, double>();
                i = new Company(Convert.ToDouble(index), amountInTheAccount);
                amountInTheAccount = i.AmountInTheAccount;
                instance[Convert.ToDouble(index)] = (double)value;
                obje = instance[Convert.ToDouble(index)];
                this[index] = (TValue)obje;
            }
            get
            {
                return null;
            }
        }
    }


    //2-й способ реализации проекта
    public class Hashtable : System.Collections.Hashtable   // Объявление неуниверсального набора данных пар (ключ-значение). Класс наследуется от системного класса Hashtable
    {
        Company company;
        bool expenses = false;
        double amountInTheAccount, amountArrivals, amountOfExpenses;


        public Hashtable()
        {
            company = new Company();
            this.amountInTheAccount = company.AmountInTheAccount;
            Add(this.amountArrivals);

        }
        protected override int GetHash(object key)   // Переопределение метода GetHash() системного класса Hashtable. Метод отвечает за хеш данные элементов коллекции
        {
            return 0;   // Все хеш данные будут иметь одинаковые значения. Это нужно для того, чтобы избежать автосортировки в коллекции по хеш данным элементов
        }

        public void Add(double money)     // Добавление нового элемента пар (ключ-значение) в коллекцию
        {

            expenses = (money < 0) ? false : true;
            if (expenses)   // Приращение суммы (доходы) к основной сумме на счете компании
            {
                this.amountArrivals = money;
                this[money, company] = this.amountInTheAccount + this.amountArrivals;
            }
            else   // Вычитание суммы (расходы) от основной суммы на счете компании
            {
                this.amountOfExpenses = money;
                this[money, company] = this.amountInTheAccount + this.amountOfExpenses;
            }

        }
        public double? this[double index, Company i]   // Блок индексатора. Добавление нового элемента пар (ключ-значение) в коллекцию
        {
            set
            {
                Dictionary<double, double> instance = new Dictionary<double, double>();
                i = new Company(index, amountInTheAccount);
                amountInTheAccount = i.AmountInTheAccount;
                instance[index] = (double)value;
                this[index] = instance[index];
            }
            get
            {
                return null;
            }
        }
    }

    static class Override     // Объявление статического класса Override. Класс содержит статический расширяющий метод OverrideCollection(this Hashtable collection) 
    {
        public static void OverrideCollection(this Hashtable collection)  // Расширяющий метод. Метод сортирует элементы входящей колекции в обратном порядке
        {
            Hashtable overrideCollection = collection;

            int i = 1;
            double[,] massive = new double[collection.Count, 2];
            foreach (DictionaryEntry item in collection)
            {
                massive[collection.Count - i, 0] = (double)item.Key;
                massive[collection.Count - i++, 1] = (double)item.Value;
            }
            overrideCollection.Clear();
            for (int j = 0; j < massive.GetLength(0); j++)
            {
                overrideCollection[massive[massive.GetLength(0) - (j + 1), 0]] = massive[massive.GetLength(0) - (j + 1), 1];
            }
            collection = overrideCollection;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {

            // Реализация задачи 1-м способом: положительное число - приращение к сумме на счету; отрицательное число - вычитание от суммы на счету;
            CompanyAccount<double, double> accountBalance = new CompanyAccount<double, double>()
            {
                1500, 2100, 800
            };

            accountBalance.Add(500);
            accountBalance.Add(150);

            Console.WriteLine("Method1:");
            Console.WriteLine(new string('-', 40));
            foreach (var item in accountBalance)  // Перебор элементов коллекции. Элементы коллекции содержат информацию об операциях(приходы, расходы) в компании
            {
                Console.WriteLine(item.Key + "  \t   " + item.Value);
            }
            Console.WriteLine("\n\n");


            Console.WriteLine("Method2:");
            Console.WriteLine(new string('-', 40));

            // Реализация задачи 2-м способом: положительное число - приращение к сумме на счету; отрицательное число - вычитание от суммы на счету;
            Hashtable collection = new Hashtable()
            {
                235.8, 145.889, -23232.323, -798989.1232, 456565656.48565
            };
            collection.Add(-23232.56);
            collection.Add(78865562.2845);
            collection.Add(9565.2323);
            collection.Add(-56565.13232);
            collection.OverrideCollection();  // Вызов расширяющего метода для обратной сортировки элементов данной коллекции
            foreach (DictionaryEntry item in collection)
            {
                Console.WriteLine(item.Key + " \t     " + "\t" + item.Value);
            }
            Console.ReadKey();
        }
    }
}
