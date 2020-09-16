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
            float time1, time2, time3, time4, time5, time6;
            Random random = new Random();
            int count = 1;
            string dimensionMassiveChar = "5";
            string dimensionMassiveAddOrder = null;
            int dimensionMassive = 5;
            while (count++ < 10)
            {
                Stopwatch stopwatch = new Stopwatch();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(new string(' ', 3)+"Размерность массива: int[{0}]", dimensionMassive + dimensionMassiveAddOrder);
                Console.ForegroundColor = ConsoleColor.White;
                int[] massive = new int[Convert.ToInt32((dimensionMassive + dimensionMassiveAddOrder))];
                stopwatch.Start();
                for (int i = 0; i < massive.Length; i++)
                {
                    massive[i] = i * i * i / 123;
                }
                stopwatch.Stop();
                time1 = stopwatch.ElapsedTicks;
                stopwatch.Reset();
                stopwatch.Start();
                Parallel.For(0, massive.Length, i => { massive[i] = i * i * i / 123; });
                stopwatch.Stop();
                time2 = stopwatch.ElapsedTicks;
                stopwatch.Reset();

                //stopwatch.Start();
                //var queryConsist = from item in massive
                //                   where item % 2 != 0
                //                   //where item == 10
                //                   select item;
                //stopwatch.Stop();
                //time3 = stopwatch.ElapsedTicks;
                //stopwatch.Reset();

                //stopwatch.Start();
                //ParallelQuery<int> queryTPL = from item in massive.AsParallel()
                //                              where item % 2 != 0
                //                              //where item == 10
                //                              select item;
                //stopwatch.Stop();
                //time4 = stopwatch.ElapsedTicks;
                //stopwatch.Reset();
                Console.WriteLine(new string(' ', 3)+"Последовательная инициализация значений массива: {0} ticks;", time1);
                Console.WriteLine(new string(' ', 3)+"Параллельная инициализация значений массива: {0} ticks;", time2);
                //Console.WriteLine("\nПоследовательная сортировка всех четных значений массива: {0} ticks;", time3);
                //Console.WriteLine("\nПараллельная сортировка всех четных значений массива: {0} ticks;", time4);
                dimensionMassiveAddOrder += '0';
                Console.WriteLine(new string(' ', 3)+new string('*', 100)+"\n");
                
            }
            //Console.WriteLine("Последовательный вывод значений: ");
            //stopwatch.Start();
            //foreach (int item in queryConsist)
            //{
            //    Console.Write(item + "; ");
            //}
            //Console.WriteLine();
            //stopwatch.Stop();
            //time5 = stopwatch.ElapsedMilliseconds;
            //stopwatch.Reset();

            //Console.WriteLine("Параллельный вывод значений: ");
            //stopwatch.Start();
            //Parallel.ForEach(queryConsist, item => { Console.Write(item + "; "); });
            //stopwatch.Stop();
            //time6 = stopwatch.ElapsedMilliseconds;


            //Console.WriteLine("\nПоследовательный вывод всех четных значений массива через цикл foreach: {0} msec;", time5);
            //Console.WriteLine("\nПараллельный вывод всех четных значений массива через цикл Parallel.ForEach(): {0} msec;", time6);

            Console.ReadKey();
        }
    }
}
