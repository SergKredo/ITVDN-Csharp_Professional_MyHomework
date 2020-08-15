using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task2
{
    /*
         Создайте класс, который позволит выполнять мониторинг ресурсов, используемых программой.
    Используйте его в целях наблюдения за работой программы, а именно: пользователь может
    указать приемлемые уровни потребления ресурсов (памяти), а методы класса позволят выдать
    предупреждение, когда количество реально используемых ресурсов приблизиться к
    максимально допустимому уровню.
     */
    public class MemoryLimitCheck
    {



    }

    public class LargeObject
    {
        long[] largeObject = new long[100000]; // long - 64 bit = 8 byte; 100000*8 byte = 800000 byte = 800000/1024 = 781,25 kByte

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Timer timer = new Timer()

            for (int i = 1; i < 1000; i++)
            {
                LargeObject largeObject = new LargeObject();
                double numberObjects = Math.Round(((GC.GetTotalMemory(false) / Math.Pow(1024, 2)) / 0.791591644287109), 0, MidpointRounding.ToEven);
                Console.WriteLine("Total memory {0}: \t{1} MByte;      \t Number of objects in memory:\t{2}", i, GC.GetTotalMemory(false) / Math.Pow(1024, 2), numberObjects);
            }
        }
    }
}
