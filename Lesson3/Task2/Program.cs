using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
        /*Задание 2
    Создайте файл, запишите в него произвольные данные и закройте файл. Затем снова откройте
    этот файл, прочитайте из него данные и выведете их на консоль.*/
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the path to create or open the file file: ");
            string path = Console.ReadLine();         // Указание в консоли адресной строки к файлу

            FileStream file = File.OpenWrite(@path);  // Создание потока данных через объявление переменной типа FileStream. Предоставляет System.IO.Stream в файле, поддерживая синхронные и асинхронные
                                                      // операции чтения и записи.
                                                      // Класс File позволяет открывать, создавать, читать и записывать файлы целиком либо
                                                      //по частям.
            StreamWriter writer = new StreamWriter(file);  // Класс StreamWriter используется для записи строк в потоки

            Console.WriteLine("Writing data to a file".ToUpper());
            Console.WriteLine("Enter the data:");
            Console.WriteLine(new string('-', 100));
            string date = Console.ReadLine();        // Ввод в консоли заданного текста

            for (int i = 0; i < date.Length; i++)
            {
                writer.Write(date[i]);    // Последовательная запись в файл отдельных литералов
            }

            writer.Flush();
            writer.Close();  // Метод Close() закрывает текущий объект StreamWriter и базовый поток.

            Console.ReadKey();
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Open the file you created".ToUpper());
            Console.Write("Enter file path: ");
            string pathTwo = Console.ReadLine();    // Указание в консоли адресной строки к файлу

            Console.WriteLine(new string('-', 100));
            FileStream fileOpen = File.OpenRead(@pathTwo);     // Создание потока для чтения данных из файла
            StreamReader reader = new StreamReader(fileOpen);  // Класс StreamReader используется для чтения строк из потока

            Console.WriteLine("Data from file: ".ToUpper());
            Console.Write(reader.ReadToEnd());    // Вывод в консоли (чтение) данных из файла
            reader.Close();   // Метод Close() закрывает текущий объект StreamReader и базовый поток.



            Console.ReadKey();
        }
    }
}
/*
 Enter the path to create or open the file file: D:\Test\test.txt
WRITING DATA TO A FILE
Enter the data:
----------------------------------------------------------------------------------------------------
Hello World! C# forever!
----------------------------------------------------------------------------------------------------
OPEN THE FILE YOU CREATED
Enter file path: D:\Test\test.txt
----------------------------------------------------------------------------------------------------
DATA FROM FILE:
Hello World! C# forever!
*/
