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
    public class Company
    {

        public double AmountInTheAccount { get; }
        public double AmountArrivals { get; set; }
        public double AmountOfExpenses { get; set; }

        public Company()
        {
            this.AmountInTheAccount = 50000;
        }
        public Company(double amount, double amountOfAccount)
        {
            if (amount < 0)
            {
                this.AmountInTheAccount = amountOfAccount;
                this.AmountOfExpenses = amount;
                this.AmountInTheAccount += this.AmountOfExpenses;
            }
            else
            {
                this.AmountInTheAccount = amountOfAccount;
                this.AmountArrivals = amount;
                this.AmountInTheAccount += this.AmountArrivals;
            }
        }
    }
    public class CompanyAccount<TKey, TValue> : Dictionary<TKey, TValue>
    {
        Company company;
        bool expenses = false;
        double amountInTheAccount, amountArrivals, amountOfExpenses;

        public CompanyAccount()
        {
            object abj = new object();
            company = new Company();
            this.amountInTheAccount = company.AmountInTheAccount;
            abj = this.amountArrivals;
            Add((TKey)abj);

        }
        public void Add(TKey money)
        {
            if (money.GetType().Name == "Double" || money.GetType().Name == "Int32")
            {
                expenses = (Convert.ToDouble(money) < 0) ? false : true;
                if (expenses)
                {
                    this.amountArrivals = Convert.ToDouble(money);
                    this[money, company] = this.amountInTheAccount + this.amountArrivals;
                }
                else
                {
                    this.amountOfExpenses = Convert.ToDouble(money);
                    this[money, company] = this.amountInTheAccount + this.amountOfExpenses;
                }
            }
        }
        public object this[TKey index, Company i]
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

    public class Hashtable : System.Collections.Hashtable
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
        protected override int GetHash(object key)
        {
            return 0;
        }

        public void Add(double money)
        {

            expenses = (money < 0) ? false : true;
            if (expenses)
            {
                this.amountArrivals = money;
                this[money, company] = this.amountInTheAccount + this.amountArrivals;
            }
            else
            {
                this.amountOfExpenses = money;
                this[money, company] = this.amountInTheAccount + this.amountOfExpenses;
            }

        }
        public double? this[double index, Company i]
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

    static class Override
    {
        public static void OverrideCollection(this Hashtable collection)
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
            CompanyAccount<double, double> accountBalance = new CompanyAccount<double, double>()
            {
                1500, 2100, 800
            };

            accountBalance.Add(500);
            accountBalance.Add(150);

            Console.WriteLine("Method1:");
            Console.WriteLine(new string('-', 40));
            foreach (var item in accountBalance)
            {
                Console.WriteLine(item.Key + "  \t   " + item.Value);
            }
            Console.WriteLine("\n\n");


            Console.WriteLine("Method2:");
            Console.WriteLine(new string('-', 40));

            Hashtable collection = new Hashtable()
            {
                235.8, 145.889, -23232.323, -798989.1232, 456565656.48565
            };
            collection.Add(-23232.56);
            collection.Add(78865562.2845);
            collection.Add(9565.2323);
            collection.Add(-56565.13232);
            collection.OverrideCollection();
            foreach (DictionaryEntry item in collection)
            {
                Console.WriteLine(item.Key + " \t     " + "\t" + item.Value);
            }
            Console.ReadKey();
        }
    }
}
