using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Task2
{
    /*
         Создайте класс, поддерживающий сериализацию. Выполните сериализацию объекта этого
    класса в формате XML. Сначала используйте формат по умолчанию, а затем измените его
    таким образом, чтобы значения полей сохранились в виде атрибутов элементов XML.
     */

    class Program
    {
        static void Main(string[] args)
        {

            //1. СЕРИАЛИЗАЦИЯ - сохранение полей объекта в виде атрибутов элементов XML
            Console.WriteLine("Serializable1".ToUpper());
            FileStream file1 = File.Create("Serializing1.xml");  // Создаем файловый поток байтов для записи данных в созданный нами файл с расширением xml
            XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(List<MyClass1>));  // Создаем XML сериализатор для преобразования объекта в линейную последовательность
                                                                                     //байтов, которую можно хранить и передавать.
            xmlSerializer1.Serialize(file1, MyClass1.Collection(5)); // На экземпляре объекта созаднного сериализатора вызываем метод, 
            //который выполняет сериализацию заданного объекта и записует XML документ в файл, используя заданный файловый поток
            file1.Close();  // Закрываем файловый поток

            //2. СЕРИАЛИЗАЦИЯ - сохранение полей объекта в виде элементов XML
            Console.WriteLine("Serializable2".ToUpper());
            FileStream file2 = File.Create("Serializing2.xml");  // Создаем файловый поток байтов для записи данных в созданный нами файл с расширением xml
            XmlSerializer xmlSerializer2 = new XmlSerializer(typeof(List<MyClass2>));  // Создаем XML сериализатор для преобразования объекта в линейную последовательность
                                                                                      //байтов, которую можно хранить и передавать.
            xmlSerializer2.Serialize(file2, MyClass2.Collection(5)); // На экземпляре объекта созаднного сериализатора вызываем метод, 
            //который выполняет сериализацию заданного объекта и записует XML документ в файл, используя заданный файловый поток
            file2.Close();  // Закрываем файловый поток



            //1. ДЕСЕРИАЛИЗАЦИЯ - восстановление состояния объектов из атрибутов в XML файле
            Console.WriteLine("Deserializable1:");
            int count1 = 0;
            Console.WriteLine("Deserializable".ToUpper());
            FileStream fileDeserial1 = File.OpenRead("Serializing1.xml");  // Создаем файловый поток байтов для чтения данных из файла созданного после сериализации данных типа с расширением xml
            foreach (MyClass1 item in xmlSerializer1.Deserialize(fileDeserial1) as List<MyClass1>)  // В цикле foreach коллекцией итерации служит возвращаемое значение массива объектов типа MyClass после десериализации
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("MyClass object {0}: \nName: {1};", count1++, item.Name);
                Console.WriteLine("Surname: {0};", item.Surname);
                Console.WriteLine("Age: {0};", item.Age);
                Console.WriteLine(new string('*', 20));
            }

            Console.WriteLine(new string('-', 150));
            Console.WriteLine(new string('-', 150));
            //2. ДЕСЕРИАЛИЗАЦИЯ - восстановление состояния объектов из элементов в XML файле
            Console.WriteLine("Deserializable2:");
            int count2 = 0;
            Console.WriteLine("Deserializable".ToUpper());
            FileStream fileDeserial2= File.OpenRead("Serializing2.xml");  // Создаем файловый поток байтов для чтения данных из файла созданного после сериализации данных типа с расширением xml
            foreach (MyClass2 item in xmlSerializer2.Deserialize(fileDeserial2) as List<MyClass2>)  // В цикле foreach коллекцией итерации служит возвращаемое значение массива объектов типа MyClass после десериализации
            {
                Console.WriteLine(new string('*', 20));
                Console.WriteLine("MyClass object {0}: \nName: {1};", count2++, item.Name);
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
Serializing1.
<?xml version="1.0"?>
<ArrayOfMyClass1 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <MyClass1 Name="Igor" Surname="Petrov" Age="45" />
  <MyClass1 Name="Ilia" Surname="Ivanov" Age="48" />
  <MyClass1 Name="Kostantin" Surname="Romanov" Age="12" />
  <MyClass1 Name="Uliayana" Surname="Tubikova" Age="33" />
  <MyClass1 Name="Nina" Surname="Pogrebnaya" Age="40" />
</ArrayOfMyClass1>

****************************************************************************************************************************************
Serializing2.
--------------------------------------------------------------------------------------------------------------------------------------
<?xml version="1.0"?>
<ArrayOfMyClass2 xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <MyClass2>
    <Name>Zina</Name>
    <Surname>Zubova</Surname>
    <Age>65</Age>
  </MyClass2>
  <MyClass2>
    <Name>Yurii</Name>
    <Surname>Lipskiy</Surname>
    <Age>30</Age>
  </MyClass2>
  <MyClass2>
    <Name>Ruslan</Name>
    <Surname>Reznikov</Surname>
    <Age>12</Age>
  </MyClass2>
  <MyClass2>
    <Name>Sergey</Name>
    <Surname>Frolov</Surname>
    <Age>72</Age>
  </MyClass2>
  <MyClass2>
    <Name>Konstantin</Name>
    <Surname>Poltko</Surname>
    <Age>66</Age>
  </MyClass2>
</ArrayOfMyClass2>
 */
