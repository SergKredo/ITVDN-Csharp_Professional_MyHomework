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

    public class EqualityComparer : IEqualityComparer
    {
        bool System.Collections.IEqualityComparer.Equals(object oneKey, object twoKey)
        {
            return true;
        }
        int System.Collections.IEqualityComparer.GetHashCode(object obj)
        {
            return 0;
        }
    }
    public class MyCollection : OrderedDictionary
    {
        string Name { get; set; }
        int Age { get; set; }

        public MyCollection(EqualityComparer compare)
        {

        }
        public new void Add(object key, object value)
        {
            this.Name = (string)key;
            this.Age = (int)value;
            this[Name] = Age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyCollection collection = new MyCollection(new EqualityComparer());
            collection.Add("Piter", 18);
            collection.Add("piter", 22);
            foreach (DictionaryEntry item in collection)
            {
                Console.WriteLine(item.Key + ": "+ item.Value);
            }


        }
    }
}
