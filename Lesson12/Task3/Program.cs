using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Task3
{
    /*
         Задание 3
    Создайте приложение, которое может быть запущено только в одном экземпляре (используя
    именованный Mutex).
     */
    class MatrixTwo
    {
        public static object key = new object();  //Объект синхронизации доступа к разделяемому ресурсу (объект блокировки)
        string literals = "QWERTYUIOPASDFGHJKLZXCVBNM123456789";
        Random random = new Random();    // Генератор псевдослучайных чисел
        string[] matrix;       // Объявление одномерной матрицы, отвечающей за количество ячеек-литералов в определенном столбце
        int numberColomn;      // Положение колонки
        int upColomn = 0;      // Позиция курсора по вертикали консоли
        static int countTimer = 0;
        public MatrixTwo(int par)   // Пользовательский конструктор класса Matrix
        {
            Console.CursorTop = upColomn;  // Положение курсора в консоли (происходит перемещение сверху-вниз)
            numberColomn = par;  // Присвоение числового значения, отвечающего за положение колоноки в консоли
        }
        public void MyMethod()   // Метод, который формирует одну цепочку литералов в столбце
        {
            int length = 0;  // Длина цепочки в столбце
            while (countTimer++ < 50)     // Бесконечный цикл
            {
                Thread.Sleep(random.Next(1, 10000));   // Поток останавливается на заданное время (в миллисекундах)
                matrix = new string[random.Next(3, 6)];            // Массив в потоке каждый раз формируется разного размера (в пределах от 3 до 6 элементов)

                for (int k = 0; k <= 42; k++)  // Циклическое повторение итераций в пределах высоты консоли (происходит полный проход одной цепочки сверху вниз)
                {
                    lock (key)  //Блокирует блок кода, предназначен для контроля доступа к критической секции
                    {
                        for (int j = 0; j < (upColomn + 1) - matrix.Length; j++)  // Циклическая конструкция, которая затирает ячейки столбца в черный цвет. Затирание происходить пошагово сверху вниз после появления в консли полного выражения из литералов.
                        {
                            if (upColomn != 0 && upColomn >= matrix.Length)
                            {
                                Console.CursorLeft = numberColomn;
                                Console.CursorTop = j;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("█");
                            }
                            if (j + 1 >= (upColomn + 1) - matrix.Length)
                            {
                                upColomn = j + 1;
                            }
                        }
                        length = 0;
                        if (upColomn >= 39)    // Условная конструкция, которая выполняется когда цепочка подходит к нижней границе консоли
                        {
                            if (matrix.Length - 1 == 0)
                            {
                                upColomn = 0;
                                break;
                            }
                            matrix = new string[matrix.Length - 1];
                            for (int h = 0; h < matrix.Length; h++)            // Инициализация елементов одномерного массива строкового типа
                            {
                                matrix[h] = literals[random.Next(35)].ToString();
                            }
                        }
                        // Циклическая конструкция, которая выводит в консоли в столбце пошагово литералы (сверху вниз).
                        for (int i = 0; i < matrix.Length; i++)
                        {
                            Console.CursorLeft = numberColomn;
                            Console.CursorTop = upColomn++;

                            // Условная конструкция, отвечающая за разное цветовое отображение в консоли литералов. Первый литерал - белого цвета, второй - светло-зеленый, третий и далее - темно-зеленые.
                            if (length == matrix.Length - 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (length == matrix.Length - 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }
                            matrix[i] = literals[random.Next(35)].ToString();
                            Console.Write(matrix[i]);
                            length++;

                        }
                        Thread.Sleep(5);
                    }
                }
            }
        }
    }
    class Program
    {
        // Использование Mutex для синхронизации доступа к защищенным ресурсам.

        // Mutex - Примитив синхронизации, который также может использоваться 
        // в межпроцессной и междоменной синхронизации.
        // MutEx - Mutual Exclusion (Взаимное Исключение).

        private static Mutex mutexApp = new Mutex(false, "kgjgkjgkkjglkglgklgk");

        // Mutex - Примитив синхронизации, который также может использоваться в межпроцессорной синхронизации.
        // функционирует аналогично AutoResetEvent но снабжен дополнительной логикой:
        // 1. Запоминает какой поток им владеет. ReleaseMutex не может вызвать поток, который не владеет мьютексом.
        // 2. Управляет рекурсивным счетчиком, указывающим, сколько раз поток-владелец уже владел объектом.
        static void Main()
        {
            mutexApp.WaitOne(); // Блокирует текущий поток до получения сигнала
            MatrixTwo matrixTwo;
            Console.SetWindowSize(100, 42);
            for (int i = 0; i < 33; i++)
            {
                matrixTwo = new MatrixTwo(i * 3);
                Thread.Sleep(80);
                new Thread(matrixTwo.MyMethod).Start();
                Thread.Sleep(200);

            }
            Console.ReadKey();
            mutexApp.ReleaseMutex();  // Освобождает объект Mutex один раз
        }
    }
}
