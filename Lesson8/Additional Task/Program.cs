using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Additional_Task
{
    /*
    Создайте пользовательский тип (например, класс) и выполните сериализацию объекта этого
    типа, учитывая тот факт, что состояние объекта необходимо будет передать по сети.
     */

    [Serializable]   //Собственные классы можно будет сериализовать и десериализовать, если добавить к ним атрибут Serializable.
    public class MyClass   // Объявляем собственный класс с именем MyClass
    {
        static List<MyClass> classes;  // Объявляем статическое закрытое поле типа List. В качества указателя типа передаем тип собственного класса
        // Создаем открытые автосвойства для характеризации созданного нами объекта
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public MyClass()  // Конструктор по умолчанию
        {
        }
        public MyClass(string name, string surname, int age)  // Пользовательский конструктор для инициализации свойств класса
        {
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
        }

        // Объявляем открытый статический метод Collection. 
        //Метод принимает параметр, характеризующий количество объектов, которые пользователь хочет создать и возвращает коллекцию созданных объектов
        public static List<MyClass> Collection(int number)
        {
            classes = new List<MyClass>();   // Инстанцируем по умолчанию нашу коллекцию List
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
                classes.Add(new MyClass(name, surname, age));  // Добавляем в список новые объекты
            }
            return classes;  // Возврат списка из объектов типа MyClass
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            //СЕРИАЛИЗАЦИЯ
            Console.WriteLine("Serializable".ToUpper());
            FileStream file = File.Create("Serializing.txt");  // Создаем файловый поток байтов для записи данных в созданный нами файл с расширением txt
            BinaryFormatter xmlSerializer = new BinaryFormatter();  // Создаем BinaryFormatter сериализатор для преобразования объекта в линейную последовательность
                                                                                     //байтов, которую можно хранить и передавать.
            xmlSerializer.Serialize(file, MyClass.Collection(5)); // На экземпляре объекта созаднного сериализатора вызываем метод, 
            //который выполняет сериализацию заданного объекта и записует данные в файл, используя заданный файловый поток
            file.Close();  // Закрываем файловый поток


            //ДЕСЕРИАЛИЗАЦИЯ
            int count = 0;
            Console.WriteLine("Deserializable".ToUpper());
            FileStream fileDeserial = File.OpenRead("Serializing.txt");  // Создаем файловый поток байтов для чтения данных из файла созданного после сериализации данных типа с расширением txt
            foreach (MyClass item in xmlSerializer.Deserialize(fileDeserial) as List<MyClass>)  // В цикле foreach коллекцией итерации служит возвращаемое значение массива объектов типа MyClass после десериализации
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("MyClass object {0}: \nName: {1};", count++, item.Name);
                Console.WriteLine("Surname: {0};", item.Surname);
                Console.WriteLine("Age: {0};", item.Age);
                Console.WriteLine(new string('*', 20));
            }
            Console.ReadKey();
        }
    }
}

/*
 Results:
-----------------------------------------------------------------------------------------------------------------------------------------
SERIALIZABLE
--------------------
MyClass object 0:
Name: Piter
Surname: Ibanov
Age: 22
--------------------
--------------------
MyClass object 1:
Name: Ilia
Surname: Heroi
Age: 55
--------------------
--------------------
MyClass object 2:
Name: Lida
Surname: Urova
Age: 53
--------------------
--------------------
MyClass object 3:
Name: Jastin
Surname: Hutov
Age: 42
--------------------
--------------------
MyClass object 4:
Name: Petr
Surname: Egorov
Age: 12
--------------------


DESERIALIZABLE
********************
MyClass object 0:
Name: Piter;
Surname: Ibanov;
Age: 22;
********************
********************
MyClass object 1:
Name: Ilia;
Surname: Heroi;
Age: 55;
********************
********************
MyClass object 2:
Name: Lida;
Surname: Urova;
Age: 53;
********************
********************
MyClass object 3:
Name: Jastin;
Surname: Hutov;
Age: 42;
********************
********************
MyClass object 4:
Name: Petr;
Surname: Egorov;
Age: 12;
********************



txt File:
---------------------------------------------------------------------------------------------------------------------------------------
    яяяя          FAdditional Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null   „System.Collections.Generic.List`1[[Additional_Task.MyClass, Additional Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]   _items_size_version  Additional_Task.MyClass[]   	                   Additional_Task.MyClass   	   	   	   	   	   
   Additional_Task.MyClass   <Name>k__BackingField<Surname>k__BackingField<Age>k__BackingField    	   Piter
   Ibanov            Ilia   Heroi7         
   Lida   Urova5            Jastin   Hutov*            Petr   Egorov   
 */
