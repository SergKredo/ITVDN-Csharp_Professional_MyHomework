using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    /*Задание 3
Создайте абстрактный класс Гражданин. Создайте классы Студент, Пенсионер, Рабочий
унаследованные от Гражданина. Создайте непараметризированную коллекцию со следующим
функционалом:
1. Добавление элемента в коллекцию.
1) Можно добавлять только Гражданина.
2) При добавлении, элемент добавляется в конец коллекции. Если Пенсионер, – то в
начало с учетом ранее стоящих Пенсионеров. Возвращается номер в очереди.
3) При добавлении одного и того же человека (проверка на равенство по номеру
паспорта, необходимо переопределить метод Equals и/или операторы равенства для
сравнения объектов по номеру паспорта) элемент не добавляется, выдается
сообщение.
2. Удаление
1) Удаление – с начала коллекции.
2) Возможно удаление с передачей экземпляра Гражданина.
3. Метод Contains возвращает true/false при налчичии/отсутствии элемента в коллекции и
номер в очереди.
4. Метод ReturnLast возвращsает последнего чеолвека в очереди и его номер в очереди.
5. Метод Clear очищает коллекцию.
6. С коллекцией можно работать опертаором foreach.
 */
    public abstract class Citizen
    {
        public bool checkInstance = false;
        int iD;
        public abstract string Passport { get; }
        protected abstract string Name { get; }
        protected abstract string Surname { get; }
        protected abstract string Nationality { get; }
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                iD = obj.GetHashCode();
            }
            else
            {
                return false;
            }
            bool check = (this.Passport == (obj as Citizen).Passport) ? true : false;
            if ((this.Nationality == (obj as Citizen).Nationality) && (this.Passport == (obj as Citizen).Passport) && (this.Name == (obj as Citizen).Name) && (this.Surname == (obj as Citizen).Surname))
            {
                object oneInstance = this as Object;
                obj = oneInstance;
                checkInstance = true;
            }
            return check;
        }
        public override int GetHashCode()
        {
            if (this.checkInstance)
            {
                return this.iD;
            }
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Nationality: {0}; Passport: {1}; Name: {2}; Surname: {3}; Status: {4}", this.Nationality, this.Passport, this.Name, this.Surname, this.GetType().Name);
        }
    }
    public class Student : Citizen
    {
        protected string passport, nationality, name, surname;
        public override string Passport
        {
            get
            {
                return passport;
            }
        }
        protected override string Nationality
        {
            get
            {
                return nationality;
            }
        }

        protected override string Name
        {
            get
            {
                return name;
            }
        }

        protected override string Surname
        {
            get
            {
                return surname;
            }
        }

        public Student(string passport, string nationality, string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            this.passport = passport;
            this.nationality = nationality;
        }
    }
    public class Pensioner : Citizen
    {
        protected string passport, nationality, name, surname;
        public override string Passport
        {
            get
            {
                return passport;
            }
        }
        protected override string Nationality
        {
            get
            {
                return nationality;
            }
        }

        protected override string Name
        {
            get
            {
                return name;
            }
        }

        protected override string Surname
        {
            get
            {
                return surname;
            }
        }

        public Pensioner(string passport, string nationality, string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            this.passport = passport;
            this.nationality = nationality;
        }
    }
    public class Worker : Citizen
    {
        protected string passport, nationality, name, surname;
        public override string Passport
        {
            get
            {
                return passport;
            }
        }
        protected override string Nationality
        {
            get
            {
                return nationality;
            }
        }

        protected override string Name
        {
            get
            {
                return name;
            }
        }

        protected override string Surname
        {
            get
            {
                return surname;
            }
        }

        public Worker(string passport, string nationality, string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            this.passport = passport;
            this.nationality = nationality;
        }
    }

    public class List : IList
    {
        Citizen[] collectionCitizen;
        int index = 0;
        bool isReadOnly = false;
        object syncRoot;
        int indexRemoveValue = -1;
        int indexLastObject = -1;
        public List()
        {
            collectionCitizen = new Citizen[] { };
            syncRoot = new object();

        }
        public object this[int index]
        {
            get
            {
                try
                {
                    if (index < 0 && index >= collectionCitizen.Length)
                    {
                        throw new Exception("You entered an invalid index");
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
                return collectionCitizen[index];
            }

            set
            {
                bool check = (value as Citizen != null) ? true : false;
                try
                {
                    if (!check || index < 0 || index >= collectionCitizen.Length)
                    {
                        throw new Exception("You entered an invalid index or maybe invalid data");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                collectionCitizen[index] = (Citizen)value;
            }
        }

        public int Count
        {
            get
            {
                return collectionCitizen.Length;
            }
        }

        public bool IsFixedSize
        {
            get
            {
                throw new NotImplementedException();
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

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public object SyncRoot
        {
            get
            {
                return syncRoot;
            }
        }

        public Citizen ReturnLast()
        {
            Citizen lastObject = collectionCitizen[collectionCitizen.Length - 1];
            indexLastObject = collectionCitizen.Length - 1;
            return lastObject;
        }

        void AddPensioner(object value, ref int index)
        {
            int count = 0;
            index = -1;
            Citizen[] addElementToCollection = new Citizen[collectionCitizen.Length + 1];
            for (int j = 0; j < collectionCitizen.Length; j++)
            {
                bool counter = (collectionCitizen[j] as Pensioner != null) ? true : false;
                if (counter)
                {
                    ++count;
                    index = j;
                }
            }
            if (count == 0)
            {
                addElementToCollection[0] = (Citizen)value;
                for (int i = 1; i < addElementToCollection.Length; i++)
                {
                    addElementToCollection[i] = collectionCitizen[i - 1];
                }
            }
            else
            {
                for (int i = 0; i < addElementToCollection.Length; i++)
                {
                    if (i <= index)
                    {
                        addElementToCollection[i] = collectionCitizen[i];
                    }
                    else if (i > index + 1)
                    {
                        addElementToCollection[i] = collectionCitizen[i - 1];
                    }
                    else
                    {
                        addElementToCollection[i] = (Citizen)value;
                    }
                }
            }
            collectionCitizen = addElementToCollection;
            this.index = ++index;
        }
        public int Add(object value)
        {
            if (!IsReadOnly)   // Если IsReadOnly = true, запись новых элементов в коллекцию невозможна
            {
                int index = -1;
                Citizen[] addElementToCollection = new Citizen[collectionCitizen.Length + 1];
                bool check = (value as Citizen != null) ? true : false;
                if (check)
                {
                    for (int j = 0; j < collectionCitizen.Length; j++)
                    {
                        bool matchCheck = (value.Equals(collectionCitizen[j] as Object)) ? true : false;
                        if (!matchCheck)
                        {
                            continue;
                        }
                        else
                        {
                            try
                            {
                                if ((value as Citizen).GetHashCode() == collectionCitizen[j].GetHashCode())
                                {
                                    this.collectionCitizen[j].checkInstance = false;
                                    throw new Exception("Such a person is already on the list.");
                                }
                                else
                                {
                                    throw new Exception("A person with this passport number is already on the list.");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                return index;
                            }
                        }
                    }
                    if ((value as Pensioner != null))
                    {
                        AddPensioner(value, ref index);
                        return index;
                    }
                    else
                    {
                        for (int i = 0; i < collectionCitizen.Length; i++)
                        {
                            addElementToCollection[i] = collectionCitizen[i];
                        }
                        addElementToCollection[addElementToCollection.Length - 1] = (Citizen)value;
                        collectionCitizen = addElementToCollection;
                        index = addElementToCollection.Length - 1;
                        return index;
                    }
                }
                try
                {
                    throw new Exception("You tried to add invalid data to the collection.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return -1;
                }
            }
            return -1;
        }

        public void Clear()
        {
            collectionCitizen = new Citizen[] { };
        }

        public bool Contains(object value)
        {
            object item = value;
            object[] massiveObject = new object[collectionCitizen.Length];
            for (int i = 0; i < massiveObject.Length; i++)
            {
                massiveObject[i] = collectionCitizen[i];
                if ((collectionCitizen[i] != null) && (massiveObject[i].Equals(item)))
                {
                    indexRemoveValue = i;
                    collectionCitizen[i].checkInstance = false;
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Array array, int index)
        {
            Array collection = new Citizen[collectionCitizen.Length];
            collection = array;
            Citizen[] col = (Citizen[])collection;
            for (int i = 0; i < array.Length; i++)
            {
                if (this.collectionCitizen.Length == 0 || this.collectionCitizen.Length == i)
                {
                    return;
                }
                col[i+index] = this.collectionCitizen[i];
            }
            collection = col;
            array = collection;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in collectionCitizen)
            {
                yield return item;
            }
        }

        public int IndexOf(object value)
        {
            Contains(value);
            return indexRemoveValue;
        }

        public void Insert(int index, object value)
        {
            bool check = (value as Citizen != null) ? true : false;
            if (check)
            {
                collectionCitizen[index] = (Citizen)value;
            }
        }

        public void Remove(object value)
        {
            int j = 0;
            Citizen[] massiveRemove = new Citizen[collectionCitizen.Length - 1];
            bool check = (value as Citizen != null) ? true : false;
            if (check && Contains(value))
            {
                for (int i = 0; i < massiveRemove.Length; i++)
                {
                    if (i == indexRemoveValue)
                    {
                        j = i + 1;
                        massiveRemove[i] = collectionCitizen[j++];
                        continue;
                    }
                    massiveRemove[i] = collectionCitizen[j++];
                    collectionCitizen[i].checkInstance = false;
                }
                collectionCitizen = massiveRemove;
                indexRemoveValue = -1;
            }
            else
            {
                try
                {
                    throw new Exception("You tried to remove invalid data to the collection.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void RemoveAt(int index)
        {
            try
            {
                if (index < 0 && index >= collectionCitizen.Length)
                {
                    throw new Exception("You entered an invalid index");
                }
                object value = collectionCitizen[index];
                Remove(value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List()
            {
                    new Student("EH654118", "Ukrainian", "Sergey", "Petrov"), new Student("EH654122", "Ukrainian", "Sergey", "Rebrov"),
                    new Student("EH654133", "Ukrainian", "Sergey", "Petrov"), new Student("EH884228", "Ukrainian", "Egor", "Krilov"),
                    new Pensioner("EH654333", "Ukrainian", "Sergey", "Frolov"), new Pensioner("EH654883", "Ukrainian", "Vasilii", "Nazarenko"),
                    new Pensioner("EH789456", "Ukrainian", "Oksana", "Tkachuk"),new Pensioner("EH123653", "Ukrainian", "Maria", "Yashuk"),
                    new Worker("EH654563", "Ukrainian", "Sergey", "Serov"), new Worker("EH654567", "Ukrainian", "Vlad", "Yashuk"),
                    new Worker("EH112233", "Ukrainian", "Elena", "Yashuk"), new Worker("EH456456", "Ukrainian", "Margarita", "Kurochkina")
            };
            Citizen[] massive = new Citizen[15];
            Console.WriteLine(list.Contains(new Student("EH654118", "Ukrainian", "Sergey", "Petrov")));
            list.Remove(new Student("EH654118", "Ukrainian", "Sergey", "Petrov"));
            list.Add(new Student("EH654119", "Ukrainian", "Henadii", "Kravtsov"));
            list.Remove("hello");
            list.Add("jereme");
            list.Add(new Pensioner("EH456877", "Ukrainian", "Henadii", "Kravtsov"));
            list.RemoveAt(15);
            Console.WriteLine(list.ReturnLast().Passport);
            Console.WriteLine(list[8].ToString());
            list[8] = new Student("EH654118", "Ukrainian", "Sergey", "Gryshin");
            list[8] = "Hello";
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
            list.CopyTo(massive, 0);
            list.Insert(2, new Student("EH654118", "Ukrainian", "Sergey", "Gryshin"));
            list.IndexOf(new Student("EH654118", "Ukrainian", "Sergey", "Gryshin"));

            Console.ReadKey();


        }
    }
}
