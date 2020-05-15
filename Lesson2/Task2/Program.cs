using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Additional_Task;

namespace Task2
{
    /*Задание 2
Создайте коллекцию, в которую можно добавлять покупателей и категорию приобретенной ими
продукции. Из коллекции можно получать категории товаров, которые купил покупатель или по
категории определить покупателей.*/

    public struct Customer
    {
        public string Name { get; }
        public string Surname { get; }
        public Customer(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }

        public override string ToString()
        {
            return string.Format(Name + " " + Surname);
        }
    }
    public class CustomerCollection : SortedList
    {
        Customer customer;
        public CustomerCollection()
        {

        }
        public CustomerCollection(CustomerCollection list, IComparer compare) : base(list, compare)
        {
            foreach (DictionaryEntry item in list)
            {
                this.Add(item.Key as string, ((Customer)item.Value).Name, ((Customer)item.Value).Surname);
            }
        }

        public void Add(string product, string name, string surname)
        {
            customer = new Customer(name, surname);
            this[product] = customer;
        }

        public string this[string name, string surname]
        {
            get
            {
                foreach (DictionaryEntry item in this)
                {
                    if (((Customer)item.Value).Name == name && ((Customer)item.Value).Surname == surname)
                    {
                        return item.Key as string;
                    }
                }
                return null;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CustomerCollection collection = new CustomerCollection()
            {
                {"smartphone", "Andrey", "Ivanov"}, {"laptop", "Elena","Lapina"}, {"dishwasher", "Inna", "Trofimova"}
            };
            collection.Add("drill", "Maksim", "Stoyanov");
            collection.Add("hoover", "Lesya", "Nazarova");
            collection.Add("iron", "Pavel", "Vorovtsev");
            collection["oven"] = new Customer("Sergey", "Drozd");
            collection["oven"] = new Customer("Sergey", "Drozdov");
            foreach (DictionaryEntry item in collection)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(collection["hoover"]);
            Console.WriteLine(collection["Pavel", "Vorovtsev"]);
            Console.WriteLine(new string('-', 20));
            CustomerCollection collectionTwo = new CustomerCollection(collection, new DescendingCompare());
            foreach (DictionaryEntry item in collectionTwo)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
            Console.ReadKey();
        }
    }
}
