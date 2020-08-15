using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalTask
{
    /*
         Создайте свой класс, объекты которого будут занимать много места в памяти (например, в
    коде класса будет присутствовать большой массив) и реализуйте для этого класса,
    формализованный шаблон очистки.
     */
    public class DataBase   // Создаем пользовательский класс, который будет символизировать обвертку для нашей базы данных
    {
        byte[] largeObject;  // Объявляем одномерный массив типа byte
        public byte[] LargeObject  // Объявляем свойство для чтения и записи
        {
            get
            {
                return largeObject;
            }
            set
            {
                largeObject = value;
            }
        }


        public DataBase()  // Конструктор по умолчанию для инициализации полей и свойств класса
        {
            this.largeObject = new byte[1000000000];  // Создаем большой массив типа byte размером 953,6 МБайт
        }
    }


    public class MyClass : IDisposable  //Создаем пользовательский класс, который наследуется от интерфейса IDisposable и реализует его сигнатуры методов
    {
        // Интерфейс IDisposable предоставляет механиз для освобождения неуправляемых ресурсов памяти.
        DataBase dataBase;
        bool disposed;
        public MyClass()  // Инициализируем наши поля класса
        {
            dataBase = new DataBase();  // Создаем экземпляр класс базы данных
            double kByte = GC.GetTotalMemory(false) / Math.Pow(1024, 2);  // Находим предполагаемое количество выделенных системой кБайтов для базы данных
            Console.WriteLine("The amount of memory after connecting to the database {0} MByte", kByte);
            Console.WriteLine(new string('-', 100));
        }
        public void Dispose()  // Реализуем метод Dispose интерфейса. Представляет механиз формализованого шаблона очистки памяти.
        {
            Dispose(true);  // Вызываем метод Dispose и вкачестве аргумента передаем значение true
            GC.SuppressFinalize(this);  // Сообщаем виртуальной среде (CLR), что она не должна вызывать повторно деструктор для указанного объекта
        }

        protected void Dispose(bool disposing)  // Метод реализует возможность очистки памяти
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dataBase.LargeObject = null;  // Разрываем соединение с базой данных
                    Console.WriteLine("Disconnecting the database connection!");
                    GC.Collect(2);  // Вызываем принудительно сборку мусора, начиная с нулевого поколения до максимально возможного второго.
                    double kByte = GC.GetTotalMemory(false) / 1024d;  // Устанавливаем какое количество памяти занимает программа
                    Console.WriteLine("The amount of memory when the connection to the database is broken {0} kByte", kByte);
                    Console.WriteLine(new string('-', 100));
                }
            }
            disposed = true;  // Устанавливаем булевый маркер true для того, чтобы избежать повторный перевызов метода Dispose
        }

        ~MyClass()  // Деструктор класса
        {
            Dispose(false);
            Console.WriteLine("Detached database connection already implemented by garbage collector!");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            double kByte = GC.GetTotalMemory(false) / 1024d;  // Определяем количество памяти до установления соединения с базой данных нашего приложения
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("The amount of memory before connecting to the database {0} kByte", kByte);
            Console.WriteLine(new string('-', 100));

            /*Ключевое слово using было перегружено для поддержки шаблона Disposable. Оператор using 
            должен захватывать ресурсы внутри
            фигурных скобок, следующих за ключевым словом using, в то время как область
            видимости этих локальных переменных ограничена областью определения следующих
            далее фигурных скобок.
            Оператор using расширяется до конструкции try/finally.
            Оператор using требует, чтобы все ресурсы, захваченные в процессе, были неявно
            преобразуемыми к IDisposable.*/
            using (MyClass myClass = new MyClass())  
            {
                // Проверка на приведение пользовательского класса к интерфейсу IDisposable. Если объект приводится, то вызывается метод Dispose интерефейса.
            }
            Console.ReadKey();
        }
    }
}
/*
 Results:
------------------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------
The amount of memory before connecting to the database 29,30859375 kByte
----------------------------------------------------------------------------------------------------
The amount of memory after connecting to the database 953,710781097412 MByte
----------------------------------------------------------------------------------------------------
Disconnecting the database connection!
The amount of memory when the connection to the database is broken 30,63671875 kByte
----------------------------------------------------------------------------------------------------

 */
