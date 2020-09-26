using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Additional_Task
{
        /*
             Переделайте дополнительное задание из урока №11 с использованием конструкции async
             await.
         */
    class Program
    {
        static int counterAllThread = 0;  // Счетчик всех итераций потоков
        static void MethodThreading()  // Метод, который обрабатывает поток
        {
                for (int counter = 0; counter < 10; counter++)
                {
                    Console.WriteLine("Counter: {0}, threadID: {1};", ++counterAllThread, Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(100);  // Приостанавливаем текущий поток на заданное время
                }
                Console.WriteLine();        
        }

        // async указывает, что метод является асинхронным.
        static async void MyAsyncMethod()
        {
            await Task.Factory.StartNew(MethodThreading);   // await - ожидание завершения работы асинхронной задачи.
        }
        static void Main(string[] args)
        {
            List<Task> list = new List<Task>() {new Task(MyAsyncMethod), new Task(MyAsyncMethod), new Task(MyAsyncMethod) };  // Создаем список задач, которые будут вызывать метод выполняющийся асинхронно во вторичном потоке
            foreach(var item in list) 
            {
                item.Start();  // Запускаем задачу Task, планируя ее выполнение в текущем планировщике TaskScheduler
                item.Wait(); // Приостанавливаем первичный поток, пока не завершится выполнение задачи вызванной асинхронно
            }
            Console.ReadKey();
        }
    }
}

/*
 Results:
------------------------------------------------------------------------------------------------------------------------------
Counter: 1, threadID: 3;
Counter: 2, threadID: 4;
Counter: 3, threadID: 5;
Counter: 4, threadID: 4;
Counter: 5, threadID: 3;
Counter: 6, threadID: 5;
Counter: 7, threadID: 4;
Counter: 8, threadID: 3;
Counter: 9, threadID: 5;
Counter: 10, threadID: 4;
Counter: 11, threadID: 3;
Counter: 12, threadID: 5;
Counter: 13, threadID: 4;
Counter: 14, threadID: 3;
Counter: 15, threadID: 5;
Counter: 16, threadID: 4;
Counter: 17, threadID: 3;
Counter: 18, threadID: 5;
Counter: 19, threadID: 4;
Counter: 20, threadID: 3;
Counter: 21, threadID: 5;
Counter: 22, threadID: 4;
Counter: 23, threadID: 3;
Counter: 24, threadID: 5;
Counter: 25, threadID: 4;
Counter: 26, threadID: 3;
Counter: 27, threadID: 5;
Counter: 28, threadID: 4;
Counter: 29, threadID: 3;
Counter: 30, threadID: 5;
 */
