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
    public class MyCollection<T> : ICollection<T>
    {
        private T[] massive;
        private object[] massiveTwo;
        int indexRemoveValue = -1;
        bool isReadOnly = false;

        public MyCollection()
        {
            massive = new T[0] { };
        }
        public void Add(T value)
        {
            if (!IsReadOnly)
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
        public void Clear()
        {
            massive = new T[] { };
        }

        public int Count
        {
            get
            {
                return massive.Length;
            }
        }


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

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in massive)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (T item in massive)
            {
                yield return item;
            }
        }


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
            MyCollection<int> mycollection = new MyCollection<int>
            {
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
            mycollection.IsReadOnly = false;
            mycollection.Add(15);
            int count = mycollection.Count;
            bool contain = mycollection.Contains(6);
            //mycollection.Clear();
            bool remove = mycollection.Remove(144);
            foreach (int item in mycollection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 20));

            int index = 0;
            int[] massive = new int[mycollection.Count + index];
            mycollection.CopyTo(massive, index);

            foreach (var item in mycollection.ConvertToAnotherOperation(massive))
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
