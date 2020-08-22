using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Task2
{
    /*
         Создайте консольное приложение, которое в различных потоках сможет получить доступ к 2-м
    файлам. Считайте из этих файлов содержимое и попытайтесь записать полученную
    информацию в третий файл. Чтение/запись должны осуществляться одновременно в каждом
    из дочерних потоков. Используйте блокировку потоков для того, чтобы добиться корректной
    записи в конечный файл.*/

    class Program
    {
        static string[] allText = new string[10];  // Массив строк
        static StreamWriter writer = File.CreateText("All Task2.txt");  // Создаем StreamWriter для записи символов в файловый поток
        static object syncObject = new object();  // Объект синхронизации доступа к ресурсу
        static void ReadFromFiles(object iteration)  // Метод с одним входящим параметром типа Object
        {
            lock (syncObject)  // Конструкция блокировки доступа потоков к русурсу. В данном случае ее можно не обязательно использовать.
            {
                string path = String.Format("Part{0}.txt",(int)iteration); 
                allText[(int)iteration-1] = File.ReadAllText(path);  // Запись данных из файла в массив строк
                Console.WriteLine("Text from {0}: "+allText[(int)iteration - 1], path);
            }
        }


        static void Main(string[] args)
        {
            Thread thread = null;  // Объявляем потом
            ParameterizedThreadStart parameterized = new ParameterizedThreadStart(ReadFromFiles);  // Создаем  ParameterizedThreadStart, метод которого сообщается с данным делегатом
            Console.WriteLine(new string('-', 100));                                                                                       // и принимает один параметр типа Object
            for (int i = 0; i < 10; i++)  // Создаем 10-ь вторичных потоков
            {
                thread = new Thread(parameterized); // Создаем экземпляр потока
                thread.Start(i + 1); // Запускаем поток и передаем в поток объект с данными
            }
            thread.Join(); //Вызов метода Join() позволяет приостановить выполнение основного потока до момента завершения вторичных потоков,
                           //для которых метод Join() был использован.
            Console.WriteLine(new string('-', 100));
            string text = null;
            foreach (var item in allText)  // Перебираем коллекцию строк
            {
                writer.Write(item);  // Записываем значения строк из коллекции в файловый поток
                text += item;
            }
            Console.WriteLine("Text from all files:\n{0}".ToUpper(), text);
            writer.Close();  // Закрываем файловый поток
            Console.ReadKey();
        }
    }
}

/*
 Results:
----------------------------------------------------------------------------------------------------
Text from Part1.txt: Создайте консольное приложение,
Text from Part3.txt:  сможет получить доступ к 2-м
файлам.
Text from Part4.txt: Считайте из этих файлов содержимое
Text from Part2.txt:  которое в различных потоках
Text from Part5.txt:  и попытайтесь записать полученную
информацию в третий файл.
Text from Part7.txt: осуществляться одновременно в каждом
Text from Part6.txt:  Чтение/запись должны
Text from Part8.txt:  из дочерних потоков.
Используйте блокировку
Text from Part9.txt: для того, чтобы добиться
Text from Part10.txt: записи в конечный файл.
----------------------------------------------------------------------------------------------------
TEXT FROM ALL FILES:
Создайте консольное приложение, которое в различных потоках сможет получить доступ к 2-м
файлам. Считайте из этих файлов содержимое и попытайтесь записать полученную
информацию в третий файл. Чтение/запись должны осуществляться одновременно в каждом из дочерних потоков.
Используйте блокировку для того, чтобы добиться записи в конечный файл.
 */
