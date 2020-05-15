using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Customer(string name, string surname): this()
        {
            this.Name = name;
            this.Surname = surname;
        }
        
        public override string ToString()
        {
            return string.Format(Name + " " + Surname);
        }
    }
    public class CustomerCollection: SortedList
    {
        DescendingCompare compare = new DescendingCompare();
        Customer customer;
        public CustomerCollection(DescendingCompare compare)
        {

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
    public class DescendingCompare: IComparer  // Открытый класс, реализует возможность обратной сортировки набора данных о людях
    {
        CaseInsensitiveComparer comparer = new CaseInsensitiveComparer(); // Создаем экземпляр класса, который проверяет равенство двух объектов без учета регистра строк.

        /// <summary>
        /// Сравнивает два объекта и возвращает значение, показывающее, что один объект меньше или больше другого или равен ему.
        /// </summary>
        /// <param name="x">Первый сравниваемый объект.</param>
        /// <param name="y">Второй сравниваемый объект.</param>
        /// <returns>Знаковое целое число, которое определяет относительные значения x и y, как показано в следующей таблице.Значение Значение Меньше нуля Значение параметра x меньше значения параметра y. Zero Значение параметра x равно значению параметра y. Больше нуля. Значение x больше значения y.</returns>
        public int Compare(object x, object y)
        {
            int result = comparer.Compare(x, y); // Порядок расположения аргументов в методе Compare: y,x - сортировка по убыванию; x,y - сортировка по возрастанию
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CustomerCollection collection = new CustomerCollection(new DescendingCompare())
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
            Console.ReadKey();
        }
    }
}
