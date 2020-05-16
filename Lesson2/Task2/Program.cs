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

    public struct Customer          // Объявление класса Customer. Класс содержит основную информацию о покупателе(имя и фамилия)
    {
        public string Name { get; }      // Открытое строковое автосвойство только для чтения. Хранит в себе имя покупателя
        public string Surname { get; }   // Открытое строковое автосвойство только для чтения. Хранит в себе фамилию покупателя
        public Customer(string name, string surname)   // Пользовательский конструктор для инициализации автосвойств класса
        {
            this.Name = name;
            this.Surname = surname;
        }

        public override string ToString()   // Переопределение  метода базового класса Object
        {
            return string.Format(Name + " " + Surname);
        }
    }
    public class CustomerCollection : SortedList    // Объявление класса набора данных о покупателях и приобретенных ими товаров. Класс наследуется от базового системного класса SortedList
    {
        Customer customer;   // Объявление поля типа Customer. Поле содержит основную информацию об покупателе (имя и фамилия)
        public CustomerCollection()  // Конструктор по умолчанию
        {

        }
        public CustomerCollection(CustomerCollection list, IComparer compare) : base(list, compare)  // Пользовательский конструктор, который принимает два аргумента. Первый - это коллекция, элементы которой мы хотим отсортировать. Второй - переменная или класс производный от базового интерфейса IComparer
        {
            foreach (DictionaryEntry item in list)  // Перебор всех элементов коллекции
            {
                this.Add(item.Key as string, ((Customer)item.Value).Name, ((Customer)item.Value).Surname);  // Вызов метода Add() с последующим добавлением элементов коллекции list к коллекции текущего экземпляра
            }
        }

        public void Add(string product, string name, string surname) // Добавление элементов в коллекцию текущего экземпляра CustomerCollection()
        {
            customer = new Customer(name, surname);  // Создание экземпляра типа Customer. Экземпляр данного типа содержит всю основную информацию о покупателе (имя и фамилия)
            this[product] = customer;   // Добавление элементов в коллекцию путем вызова индексатора и его инициализации типом Customer
        }

        public string this[string name, string surname]  // Пользовательский индексатор, который принимает два параметра типа string. Служит для возврата ключа по значению элемента экземпляра коллекции.
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
            CustomerCollection collection = new CustomerCollection()  // Создание экземпляра коллекции CustomerCollection. Предоставляет коллекцию пар "ключ-значение", упорядоченных по ключам. Коллекция сортирует элементы для ключей в алфавитном порядке 
            {
                {"smartphone", "Andrey", "Ivanov"}, {"laptop", "Elena","Lapina"}, {"dishwasher", "Inna", "Trofimova"}  // Упрощенный механизм добавления данных о покупателе и приобретенном им товаре через блок инициализатора
            };
            collection.Add("drill", "Maksim", "Stoyanov");  // Добавление элемента в коллекцию, путем вызова метода Add
            collection.Add("hoover", "Lesya", "Nazarova");
            collection.Add("iron", "Pavel", "Vorovtsev");
            collection["oven"] = new Customer("Sergey", "Drozd");  // Добавление элементов к коллекцию, путем вызова индексатора
            collection["oven"] = new Customer("Sergey", "Drozdov");
            foreach (DictionaryEntry item in collection)    // Перебор элементов коллекции. В качестве переменной итерации служит переменная типа DictionaryEntry - определяет пару ключ/значение словаря, которая может быть задана или получена.
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(collection["hoover"]);
            Console.WriteLine(collection["Pavel", "Vorovtsev"]);
            Console.WriteLine(new string('-', 20));

            // Создаем новый экземпляр коллекции типа CustomerCollection, вызов конструктора которого реализует возможность сортировки элементов (обратный алфавитный порядок) по ключу ранее созданной нами коллекции
            CustomerCollection collectionTwo = new CustomerCollection(collection, new DescendingCompare());
            foreach (DictionaryEntry item in collectionTwo)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
            Console.ReadKey();
        }
    }
}
