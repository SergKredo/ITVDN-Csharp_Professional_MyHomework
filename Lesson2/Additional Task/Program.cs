using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    /*Используя класс SortedList, создайте небольшую коллекцию и выведите на экран значения пар
«ключ- значение» сначала в алфавитном порядке, а затем в обратном.*/
    struct Human                // Объявление класса Human
    {
        public string Name { get; }    // Открытое автосвойство только для чтения, определяющее имя человека
        public string Surname { get; }  // Открытое автосвойство только для чтения, определяющее фамилию человека
        public Human(string name, string surname)  // Пользовательский конструктор для инициализации полей автосвойств класса Human
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
    public class DescendingCompare : IComparer   // Открытый класс, реализует возможность обратной сортировки набора данных о людях
    {
        CaseInsensitiveComparer comparer = new CaseInsensitiveComparer(); // Создаем экземпляр класса, который проверяет равенство двух объектов без учета регистра строк.

        /// <summary>
        /// Сравнивает два объекта и возвращает значение, показывающее, что один объект меньше или больше другого или равен ему.
        /// </summary>
        /// <param name="x">Первый сравниваемый объект.</param>
        /// <param name="y">Второй сравниваемый объект.</param>
        /// <returns>Знаковое целое число, которое определяет относительные значения x и y, как показано в следующей таблице.Значение Значение Меньше нуля Значение параметра x меньше значения параметра y. Zero Значение параметра x равно значению параметра y. Больше нуля. Значение x больше значения y.</returns>
        public int Compare(object x, object y)  
        {
            int result = comparer.Compare(y, x); // Порядок расположения аргументов в методе Compare: y,x - сортировка по убыванию; x,y - сортировка по возрастанию
            return result;
        }
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            SortedList sortedList = new SortedList() // Создаем экземпляр класса SortedList. Предоставляет коллекцию пар "ключ-значение", упорядоченных по ключам. Доступ
                                                     //     к парам можно получить по ключу и по индексу.
            {
                { new Human("Sergey", "Grigoriev").Surname, new Human("Sergey", "Grigoriev").Name },  // Добавление элементов типа Human в блок инициализатора конструктора класса
                { new Human("Dmitro", "Vasilev").Surname, new Human("Dmitro", "Vasilev").Name },
                { new Human("Elena", "Yashuk").Surname, new Human("Elena", "Yashuk").Name },
                { new Human("Oleg", "Hluhov").Surname, new Human("Oleg", "Hluhov").Name },
                { new Human("Andrey", "Ilin").Surname, new Human("Andrey", "Ilin").Name },
                { new Human("Roman", "Trunov").Surname, new Human("Roman", "Trunov").Name },
            };
            sortedList.Add(new Human("Piter", "Vasnetsov").Surname, new Human("Piter", "Vasnetsov").Name);  // Добавление элемента в коллекцию, используя метод Add
            sortedList[new Human("Piter", "Vasnetsov").Surname] = "Igor";  // Изменение значения по ключу коллекции, используя индексатор
            foreach (DictionaryEntry item in sortedList)  // Перебор коллекции пар (ключ-значение) используя оператор foreach. Поочередно извлекая из коллекции sortedList элементы и присваивает значение переменной итерации item типа DictionatyEntry
            {    // Структура DictionaryEntry - определяет пару ключ/значение словаря, которая может быть задана или получена.
                Console.WriteLine(item.Key+ "    \t   "+ item.Value);
            }
            Console.WriteLine(new string('-', 30));

            // Создаем новый экземпляр коллекции типа SortedList, вызов конструктора которого реализует возможность обратной сортировки элементов по ключу ранее созданной нами коллекции
            SortedList descendingSortedList = new SortedList(sortedList, new DescendingCompare());
            foreach (DictionaryEntry item in descendingSortedList) // Перебор всех элементов коллекции и вывод в консоли
            {
                Console.WriteLine(item.Key + "    \t   " + item.Value);
            }
            Console.WriteLine(new string('-', 30));
            Console.ReadKey();
        }
    }
}
