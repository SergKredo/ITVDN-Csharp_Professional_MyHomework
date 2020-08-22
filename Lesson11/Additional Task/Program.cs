using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Additional_Task
{
    /*
         Используя конструкции блокировки, создайте метод, который будет в цикле for (допустим, на 10
    итераций) увеличивать счетчик на единицу и выводить на экран счетчик и текущий поток.
    Метод запускается в трех потоках. Каждый поток должен выполниться поочередно, т.е. в
    результате на экран должны выводиться числа (значения счетчика) с 1 до 30 по порядку, а не в
    произвольном порядке.
     */
    class Program
    {
        static int counterAllThread = 0;  // Счетчик всех итераций потоков
        static void MethodThreading()  // Метод, который обрабатывает поток
        {
            object syncObject = new object();  // Объект синхронизации доступа для доступа к общему ресурсу

            /* Оператор lock определяет блок кода, внутри которого весь код блокируется 
               и становится недоступным для других потоков до завершения работы текущего потока.*/
            lock (syncObject)
            {
                for (int counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine("Counter: {0}, threadID: {1};", ++counterAllThread, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(100);  // Приостанавливаем текущий поток на заданное время
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)  // Создаем три потока
            {
                Thread firstThread = new Thread(MethodThreading);  // Инстанцируем класс Thread
                firstThread.Start();  // Запускаем поток
                firstThread.Join();  //Вызов метода Join() позволяет приостановить выполнение основного потока до момента завершения вторичных потоков,
                                     //для которых метод Join() был использован.
            }
            Console.ReadKey();
        }
    }
}

/*
 Results:
--------------------------------------
Counter: 1, threadID: 3;
Counter: 2, threadID: 3;
Counter: 3, threadID: 3;
Counter: 4, threadID: 3;
Counter: 5, threadID: 3;
Counter: 6, threadID: 3;
Counter: 7, threadID: 3;
Counter: 8, threadID: 3;
Counter: 9, threadID: 3;
Counter: 10, threadID: 3;

Counter: 11, threadID: 4;
Counter: 12, threadID: 4;
Counter: 13, threadID: 4;
Counter: 14, threadID: 4;
Counter: 15, threadID: 4;
Counter: 16, threadID: 4;
Counter: 17, threadID: 4;
Counter: 18, threadID: 4;
Counter: 19, threadID: 4;
Counter: 20, threadID: 4;

Counter: 21, threadID: 5;
Counter: 22, threadID: 5;
Counter: 23, threadID: 5;
Counter: 24, threadID: 5;
Counter: 25, threadID: 5;
Counter: 26, threadID: 5;
Counter: 27, threadID: 5;
Counter: 28, threadID: 5;
Counter: 29, threadID: 5;
Counter: 30, threadID: 5;

 */
