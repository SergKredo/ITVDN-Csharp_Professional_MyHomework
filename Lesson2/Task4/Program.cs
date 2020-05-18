using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /*Задание 4
Создайте коллекцию типа OrderedDictionary и реализуйте в ней возможность сравнения значений
ключей.*/

    public class EqualityComparer : IEqualityComparer  // Интерфейс IEqualityComparer определяет методы для поддержки операций сравнения объектов в отношении равенства.
    {
        CaseInsensitiveComparer instance = new CaseInsensitiveComparer(); // Создаем экземпляр класса CaseInsensitiveComparer. Проверяет равенство двух объектов без учета регистра строк.
        public new bool Equals(object oneKey, object twoKey)  //Метод, который определяет, равны ли два указанных объекта. True, если указанные объекты равны; в противном случае — false.
        {
            bool i = instance.Compare(oneKey, twoKey) == 0;
            return i;
        }
        public int GetHashCode(object obj)   // Метод, который возвращает хэш-код указанного объекта.
        {
            int i = obj.ToString().ToLowerInvariant().GetHashCode();  // Хеш-код для копии данного объекта переведенного в нижний регистр
            return i;
        }
    }
    public class MyCollection : OrderedDictionary  // Создаем пользовательскую коллекцию, которая наследуется от системного класса OrderedDictionary
    {
        EqualityComparer compare;
        string Name { get; set; }
        int Age { get; set; }

        public MyCollection(EqualityComparer compare)
        {
            this.compare = compare;
        }
        public new void Add(object key, object value)   // Метод Add, который позволяет добавить новый элемент пары(ключ-значение) в коллекцию.
        {
            this.Name = (string)key;
            this.Age = (int)value;
            foreach (DictionaryEntry item in this)   // Проверка на равество элементов с данным ключем и значением в коллекции
            {
                if (item.Key.ToString().ToLowerInvariant().GetHashCode() == this.compare.GetHashCode(Name) && (int)item.Value == this.Age)
                {
                    return;  // Если такой ключ и значение уже есть в коллекции, то выходим из метода
                }
            }
            this[Name] = Age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyCollection collection = new MyCollection(new EqualityComparer())
            {
                {"Ivan", 16}, {"Egor", 36}, {"Maria", 19}, {"Tatiana", 22}
            };
            collection.Add("Piter", 18);
            collection.Add("piter", 34);
            collection.Add("Piter", 18);
            collection.Add("Piter", 34);
            collection.Add("PitEr", 42);
            collection["Piter"] = 18;
            foreach (DictionaryEntry item in collection)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }   
        }
    }
}

/* 
Result:
***********************************************************************
Ivan: 16
Egor: 36
Maria: 19
Tatiana: 22
Piter: 18
piter: 34
PitEr: 42
***********************************************************************
*/
