using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    /*Создайте метод, который в качестве аргумента принимает массив целых чисел и возвращает
коллекцию квадратов всех нечетных чисел массива. Для формирования коллекции
используйте оператор yield.*/
    public class MyCollection<T> : ICollection<T> // Интерфейс ICollection<T> определяет методы для управления универсальными коллекциями.
    {
        private T[] massive;   // Объявление закрытого массива, в котором будут храниться все элементы коллекции. Где T - указатель места заполнения типа элементов коллекции
        private object[] massiveTwo;     // Массив типа Object служит буфером для элементов коллекции при вызове метода ConvertToAnotherOperation(T[] massive)
        int indexRemoveValue = -1;      // Метка-перечислитель для определения индекса элемента коллекции, срабатывает когда методы Contains(T value) и Remove(T value) возвращают true.
        bool isReadOnly = false;        // Булевое поле, отвечает за возможность записать в пользовательскую коллекцию новые элементы

        public MyCollection()           // Конструктор по умолчанию. Создает экземпяр массива типа T.
        {
            massive = new T[0] { };
        }

        /// <summary>
        /// Добавляет элемент в коллекцию
        /// </summary>
        /// <param name="value"> Объект, добавляемый в коллекцию </param>
        public void Add(T value)
        {
            if (!IsReadOnly)   // Если IsReadOnly = true, запись новых элементов в коллекцию невозможна
            {
                T[] massiveNew = new T[massive.Length + 1];
                for (int i = 0; i < massive.Length; i++)
                {
                    massiveNew[i] = massive[i];
                }
                massiveNew[massiveNew.Length - 1] = value;
                massive = massiveNew;
            }
        }

        /// <summary>
        /// Получает значение, указывающее, является ли коллекция доступной только для чтения.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return isReadOnly;
            }
            set
            {
                isReadOnly = value;
            }
        }

        /// <summary>
        /// Копирует элементы пользовательской коллекции в массив T[] massive, начиная с указанного индекса массива T[] massive.
        /// </summary>
        /// <param name="massive">Одномерный массив T[] massive, в который копируются элементы из нашей коллекции.
        /// Массив T[] massive должен иметь индексацию, начинающуюся с нуля.</param>
        /// <param name="per">Отсчитываемый от нуля индекс в массиве T[] massive, указывающий начало копирования.</param>
        public void CopyTo(T[] massive, int per)
        {
            for (int i = 0; i < massive.Length; i++)
            {
                if (this.massive.Length == 0 || this.massive.Length == i)
                {
                    return;
                }
                massive[i + per] = this.massive[i];
            }
        }

        /// <summary>
        /// Удаляет все элементы из коллекции
        /// </summary>
        public void Clear()
        {
            massive = new T[] { };
        }


        /// <summary>
        /// Получает число элементов, содержащихся в коллекции
        /// </summary>
        public int Count
        {
            get
            {
                return massive.Length;
            }
        }

        /// <summary>
        /// Определяет, содержит ли экземпляр данной коллекции указанное значение.
        /// </summary>
        /// <param name="value">Объект для поиска типа T</param>
        /// <returns>Значение true, если параметр value найден в коллекции; в противном случае — значение false.</returns>
        public bool Contains(T value)
        {
            object item = value;
            object[] massiveObject = new object[massive.Length];
            for (int i = 0; i < massive.Length; i++)
            {
                massiveObject[i] = massive[i];
                if ((massive[i] != null) && (massiveObject[i].Equals(item)))
                {
                    indexRemoveValue = i;
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// Удаляет первое вхождение указанного объекта из коллекции
        /// </summary>
        /// <param name="value">Объект, который необходимо удалить из коллекции</param>
        /// <returns>Значение true, если объект value успешно удален из коллекции; в противном случае — значение false. 
        /// Этот метод также возвращает значение false, если значение value не найдено в исходной коллекции</returns>
        public bool Remove(T value)
        {
            int j = 0;
            T[] massiveRemove = new T[massive.Length - 1];
            if (Contains(value))
            {
                for (int i = 0; i < massiveRemove.Length; i++)
                {
                    if (i == indexRemoveValue)
                    {
                        j = i + 1;
                        massiveRemove[i] = massive[massiveRemove.Length - j++];
                        continue;
                    }
                    massiveRemove[i] = massive[j++];
                }
                massive = massiveRemove;
                indexRemoveValue = -1;
                return true;
            }
            return false;
        }


        /// <summary>
        /// Метод реализует интерфейс IEnumerable T. 
        /// Предоставляет перечислитель, который поддерживает простой перебор элементов в указанной коллекции.
        /// </summary>
        /// <returns>Возвращает перечислитель, выполняющий перебор элементов в коллекции.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in massive)
            {
                yield return item;   // Оператор yield генерирует блок итератора (вложенный класс)
            }
        }


        /// <summary>
        /// Метод реализует интерфейс IEnumerable. 
        /// Предоставляет перечислитель, который поддерживает простой перебор элементов неуниверсальной коллекции.
        /// </summary>
        /// <returns>Возвращает перечислитель, который осуществляет итерацию по коллекции.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T item in massive)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Метод, который в качестве аргумента принимает массив целых чисел (T[] massive) 
        /// и возвращает коллекцию квадратов всех нечетных чисел массива.
        /// Для формирования коллекции используется оператор yield.
        /// </summary>
        /// <param name="massive">Массив целых чисел</param>
        /// <returns>возвращает коллекцию квадратов всех нечетных чисел массива.</returns>
        public IEnumerable ConvertToAnotherOperation(T[] massive)
        {
            int j = 0;
            object[] myObject = new object[massive.Length];
            object[] myMassiv = new object[massive.Length];
            for (int i = 0; i < massive.Length; i++)
            {
                myObject[i] = massive[i];
                if ((int)myObject[i] % 2 != 0)
                {
                    myMassiv[j] = Math.Pow((int)myObject[i], 2);
                }
                else
                {
                    j++;
                    continue;
                }
            }
            massiveTwo = myMassiv;
            foreach (var item in massiveTwo)
            {
                if (item == null)
                {
                    continue;
                }
                yield return item;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyCollection<int> mycollection = new MyCollection<int>    // Создаем экземпляр универсальной коллекции типа MyCollection<T>, закрывая указатель места заполнения T целочисленным типом Int32
            {   // Добавление новых элементов коллекции через блок инициализатора
                6,
                2,
                3,
                4,
                51,
                6,
                7,
                8,
                9,
                10
            };
            mycollection.IsReadOnly = false;   // Запись новых элементов в коллекцию возможна
            mycollection.Add(15);              // Добавление нового элемента в коллекцию через вызов метода Add()
            int count = mycollection.Count;    // Определение количества элементов коллекции
            bool contain = mycollection.Contains(6);   // Определяем содержится ли данное число в коллекции
            //mycollection.Clear();                     // Полностью очищаем коллекцию
            bool remove = mycollection.Remove(144);     // Удаляем данное число из коллекции
            foreach (int item in mycollection)          // Оператор foreach осуществляет перебор всех элементов коллекции. Поочередно извлекая из коллекции mycollection элементы и присваивает значение переменной итерации item
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 20));

            int index = 0;
            int[] massive = new int[mycollection.Count + index];
            mycollection.CopyTo(massive, index);           // Копируем все элементы коллекции в массив c заданным индексом положения начала копирования в массив

            foreach (var item in mycollection.ConvertToAnotherOperation(massive))   // Формирование новой коллекции через вызов метода ConvertToAnotherOperation(massive)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
