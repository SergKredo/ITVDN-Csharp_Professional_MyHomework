using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    /*
    Создайте класс и примените к его методам атрибут Obsolete сначала в форме, просто
    выводящей предупреждение, а затем в форме, препятствующей компиляции.
    Продемонстрируйте работу атрибута на примере вызова данных методов.
     */


    class MyClass   // Пользовательский класс, в котором будут применены атрибуты к методам
    {
        [Obsolete("This method is deprecated!")]  // Декорируем методы атрибутом Obsolete. Атрибут отмечает элементы программы, 
                                                  //которые больше не используются. Выводит заданное пользователем предупреждение.
        public void ToPrint()   // Устаревший метод. Можно использовать, но не желательно!
        {
            Console.WriteLine(new string('-', 50)+ToDo()+ new string('-', 50));
        }

        string ToDo()
        {
            return "Hello All!";
        }

        [Obsolete("This method is not functioning properly!", true)] //Атрибут отмечает элементы программы, которые больше не используются. 
        //Если в параметрах атрибута второй параметр имеет знаение true, то происходит ошибка компиляции вызова данного метода.
        public void ToPrintOld()
        {
            Console.WriteLine(new string('*', 50) + ToDo() + new string('*', 50));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyClass instance = new MyClass();
            instance.ToPrint();
            //instance.ToPrintOld();
        }
    }
}
