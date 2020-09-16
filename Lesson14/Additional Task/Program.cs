using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Additional_Task
{
    /*Создайте массив чисел размерностью в 1 000 000 или более. Используя генератор случайных
чисел, проинициализируйте этот массив значениями. Создайте PLINQ запрос, который
позволит получить все нечетные числа из исходного массива.*/
    class Program
    {
        static void Main(string[] args)
        {
            float time1, time2, time3, time4, time5, time6; // Переменные в которых хранятся значения времен в тактах
            Random random = new Random();  // Создание объекта типа Random для генерации псевдослучайных чисел

            #region Алгоритм для проверки производительности вычислений последовательным и параллельным методами
            //int count = 1;
            //string dimensionMassiveChar = "5";
            //string dimensionMassiveAddOrder = null;
            //int dimensionMassive = 5;
            //while (count++ < 10)
            //{
            //    Stopwatch stopwatch = new Stopwatch();
            //    Console.ForegroundColor = ConsoleColor.Yellow;
            //    Console.WriteLine(new string(' ', 3) + "Размерность массива: int[{0}]", dimensionMassive + dimensionMassiveAddOrder);
            //    Console.ForegroundColor = ConsoleColor.White;
            //    int[] massive = new int[Convert.ToInt32((dimensionMassive + dimensionMassiveAddOrder))];
            //    stopwatch.Start();
            //    for (int i = 0; i < massive.Length; i++)
            //    {
            //        massive[i] = i * i * i / 123;
            //    }
            //    stopwatch.Stop();
            //    time1 = stopwatch.ElapsedTicks;
            //    stopwatch.Reset();
            //    stopwatch.Start();
            //    Parallel.For(0, massive.Length, i => { massive[i] = i * i * i / 123; });
            //    stopwatch.Stop();
            //    time2 = stopwatch.ElapsedTicks;
            //    stopwatch.Reset();

            //    //stopwatch.Start();
            //    //var queryConsist = from item in massive
            //    //                   where item % 2 != 0
            //    //                   //where item == 10
            //    //                   select item;
            //    //stopwatch.Stop();
            //    //time3 = stopwatch.ElapsedTicks;
            //    //stopwatch.Reset();

            //    //stopwatch.Start();
            //    //ParallelQuery<int> queryTPL = from item in massive.AsParallel()
            //    //                              where item % 2 != 0
            //    //                              //where item == 10
            //    //                              select item;
            //    //stopwatch.Stop();
            //    //time4 = stopwatch.ElapsedTicks;
            //    //stopwatch.Reset();
            //    Console.WriteLine(new string(' ', 3) + "Последовательная инициализация значений массива: {0} ticks;", time1);
            //    Console.WriteLine(new string(' ', 3) + "Параллельная инициализация значений массива: {0} ticks;", time2);
            //    //Console.WriteLine("\nПоследовательная сортировка всех четных значений массива: {0} ticks;", time3);
            //    //Console.WriteLine("\nПараллельная сортировка всех четных значений массива: {0} ticks;", time4);
            //    dimensionMassiveAddOrder += '0';
            //    Console.WriteLine(new string(' ', 3) + new string('*', 100) + "\n");

            //}

            #endregion

            #region Алгоритм для проверки производительности вычислений последовательным и параллельным методами с ипользованием инициализации чисел массива псевдослучайными числами
            Stopwatch stopwatch = new Stopwatch();  // Создание таймера
            int[] massive = new int[5000000];  // Создание одномерного массива с размерностью в 6 порядков
            stopwatch.Start();  // Запуск таймера

            // Инициализация данных в обычном цикле for. 
            for (int i = 0; i < massive.Length; i++)
            {
                massive[i] = random.Next(0, 100);
            }
            stopwatch.Stop();  // Остановка таймера
            time1 = stopwatch.ElapsedTicks;  // Присвоение переменной результата счета таймера в тактах
            stopwatch.Reset();  // Сброс таймера
            stopwatch.Start();

            // Инициализация данных в параллельном цикле for. Использование ламда-выражений.
            Parallel.For(0, massive.Length, i => { massive[i] = random.Next(0, 100); });
            stopwatch.Stop();
            time2 = stopwatch.ElapsedTicks;
            stopwatch.Reset();

            stopwatch.Start();

            // Запрос LINQ для поиска всех нечетных значений.
            var queryConsist = from item in massive
                               where item % 2 != 0
                               select item;
            stopwatch.Stop();
            time3 = stopwatch.ElapsedTicks;
            stopwatch.Reset();

            stopwatch.Start();

            // Запрос PLINQ для поиска всех нечетных значений.
            ParallelQuery<int> queryTPL = from item in massive.AsParallel()
                                          where item % 2 != 0
                                          select item;
            stopwatch.Stop();
            time4 = stopwatch.ElapsedTicks;
            stopwatch.Reset();

            Console.WriteLine("Последовательный вывод значений: ");
            stopwatch.Start();

            // Использование простого цикла foreach, для отображения данных на экране.
            foreach (int item in queryConsist)
            {
                Console.Write(item + "; ");
            }
            Console.WriteLine();
            stopwatch.Stop();
            time5 = stopwatch.ElapsedMilliseconds;
            stopwatch.Reset();

            Console.WriteLine("Параллельный вывод значений: ");
            stopwatch.Start();

            // Использование цикла, параллельно выполняемого методом ForeEach, для отображения данных на экране.
            Parallel.ForEach(queryTPL, item => { Console.Write(item + "; "); });
            stopwatch.Stop();
            time6 = stopwatch.ElapsedMilliseconds;

            // Результаты вывода в консоли
            Console.WriteLine("\nПоследовательная инициализация значений массива: {0} ticks;", time1);
            Console.WriteLine("\nПараллельная инициализация значений массива: {0} ticks;", time2);
            Console.WriteLine("\nПоследовательная сортировка всех четных значений массива: {0} ticks;", time3);
            Console.WriteLine("\nПараллельная сортировка всех четных значений массива: {0} ticks;", time4);
            Console.WriteLine("\nПоследовательный вывод всех четных значений массива через цикл foreach: {0} msec;", time5);
            Console.WriteLine("\nПараллельный вывод всех четных значений массива через цикл Parallel.ForEach(): {0} msec;", time6);

            #endregion

            Console.ReadKey();
        }
    }
}
/*
 Results:
----------------------------------------------------------------------------------------------------------------
   Размерность массива: int[5]
   Последовательная инициализация значений массива: 5 ticks;
   Параллельная инициализация значений массива: 31552 ticks;
   ****************************************************************************************************

   Размерность массива: int[50]
   Последовательная инициализация значений массива: 2 ticks;
   Параллельная инициализация значений массива: 6018 ticks;
   ****************************************************************************************************

   Размерность массива: int[500]
   Последовательная инициализация значений массива: 6 ticks;
   Параллельная инициализация значений массива: 9025 ticks;
   ****************************************************************************************************

   Размерность массива: int[5000]
   Последовательная инициализация значений массива: 58 ticks;
   Параллельная инициализация значений массива: 4165 ticks;
   ****************************************************************************************************

   Размерность массива: int[50000]
   Последовательная инициализация значений массива: 691 ticks;
   Параллельная инициализация значений массива: 918 ticks;
   ****************************************************************************************************

   Размерность массива: int[500000]
   Последовательная инициализация значений массива: 7084 ticks;
   Параллельная инициализация значений массива: 9914 ticks;
   ****************************************************************************************************

   Размерность массива: int[5000000]
   Последовательная инициализация значений массива: 104646 ticks;
   Параллельная инициализация значений массива: 49284 ticks;
   ****************************************************************************************************

   Размерность массива: int[50000000]
   Последовательная инициализация значений массива: 951304 ticks;
   Параллельная инициализация значений массива: 352020 ticks;
   ****************************************************************************************************

   Размерность массива: int[500000000]
   Последовательная инициализация значений массива: 1.027277E+07 ticks;
   Параллельная инициализация значений массива: 3696346 ticks;
   ****************************************************************************************************


 */