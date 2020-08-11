using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Task2
{
    [Serializable]   //Собственные классы можно будет сериализовать и десериализовать, если добавить к ним атрибут Serializable.
    public class MyClass2   // Объявляем собственный класс с именем MyClass
    {
        static List<MyClass2> classes;  // Объявляем статическое закрытое поле типа List. В качества указателя типа передаем тип собственного класса
        // Создаем открытые автосвойства для характеризации созданного нами объекта

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public MyClass2()  // Конструктор по умолчанию
        {
        }
        public MyClass2(string name, string surname, int age)  // Пользовательский конструктор для инициализации свойств класса
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }

        // Объявляем открытый статический метод Collection. 
        //Метод принимает параметр, характеризующий количество объектов, которые пользователь хочет создать и возвращает коллекцию созданных объектов
        public static List<MyClass2> Collection(int number)
        {
            classes = new List<MyClass2>();   // Инстанцируем по умолчанию нашу коллекцию List
            for (int i = 0; i < number; i++)   // Циклическая конструкция
            {
                Console.WriteLine(new string('-', 20));
                Console.Write("MyClass object {0}: \nName: ", i);
                string name = Console.ReadLine();
                Console.Write("Surname: ");
                string surname = Console.ReadLine();
                Console.Write("Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(new string('-', 20));
                classes.Add(new MyClass2(name, surname, age));  // Добавляем в список новые объекты
            }
            return classes;  // Возврат списка из объектов типа MyClass
        }
    }
}
