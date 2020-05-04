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
    public abstract class Citizen   // Абстрактный класс Гражданина. Абстрактный класс служит для абстрактного представления состояния человека в заданном списке (коллекции)
    {
        public bool checkInstance = false;   // Булевое поле определяет возможность переопределения базового метода GetHashCode(). Два объекта при (true), имеют одинаковое значение Id
        int iD;                              // Идентификатор равенства объектов
        public abstract string Passport { get; }   // Абстрактное автосвойство, определяющее номер паспорта человека
        protected abstract string Name { get; }    // Абстрактное автосвойство, определяющее имя человека
        protected abstract string Surname { get; }   // Абстрактное автосвойство, определяющее фамилию человека
        protected abstract string Nationality { get; }   // Абстрактное автосвойство, определяющее национальность человека
        public override bool Equals(object obj)         // Переопределение метода Equals(object obj) базового класса Object
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
        public override int GetHashCode()         // Переопределение метода GetHashCode() базового класса Object
        {
            if (this.checkInstance)
            {
                return this.iD;
            }
            return base.GetHashCode();
        }

        public override string ToString()        // Переопределение метода ToString() базового класса Object
        {
            return string.Format("Nationality: {0}; Passport: {1}; Name: {2}; Surname: {3}; Status: {4}", this.Nationality, this.Passport, this.Name, this.Surname, this.GetType().Name);
        }
    }
    public class Student : Citizen          // Класс определяющий состояние студента. Наследуются от базового класса Citizen
    {
        protected string passport, nationality, name, surname;
        public override string Passport     // Переопределение абстрактного автосвойства, определяющего номер паспорта человека
        {
            get
            {
                return passport;
            }
        }
        protected override string Nationality    // Переопределение абстрактного автосвойства, определяющего национальность человека
        {
            get
            {
                return nationality;
            }
        }

        protected override string Name        // Переопределение абстрактного автосвойства, определяющего имя человека
        {
            get
            {
                return name;
            }
        }

        protected override string Surname    // Переопределение абстрактного автосвойства, определяющего фамилию человека
        {
            get
            {
                return surname;
            }
        }

        public Student(string passport, string nationality, string name, string surname)   // Пользовательский конструктор для инициализации всех автосвойств класса
        {
            this.name = name;
            this.surname = surname;
            this.passport = passport;
            this.nationality = nationality;
        }
    }
    public class Pensioner : Citizen    // Класс определяющий состояние пенсионера. Наследуются от базового класса Citizen
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
    public class Worker : Citizen    // Класс определяющий состояние рабочего. Наследуются от базового класса Citizen
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

    public class List : IList     // Объявление класса, который формирует пользовательскую неуниверсальную коллекцию (список) объектов. Класс наследуется от интерфейса IList и реализует его сигнатуры методов
    {   // Интерфейс IList представляет неуниверсальную коллекцию объектов с индивидуальным доступом, осуществляемым при помощи индекса.
        Citizen[] collectionCitizen;    // Объявление одномерного массива типа Citizen
        int index = 0;     // Целочисленное поле, определяющее номер индекса, добавленного в список объекта
        bool isReadOnly = false;      // Булевое поле, определяющее возможность добавления нового объекта в список. При false - добавление возможно, true - отсутствует
        object syncRoot;              // Объект синхронизации доступа к заданной критической области для потоков при реализации многопоточности в данном приложении
        int indexRemoveValue = -1;    // Определяет индекс удаленного объекта из коллекции
        int indexLastObject = -1;     // Определяет индекс последнего объекта в коллекции
        public List()                  // Конструктор по умолчанию. Инициализирует коллекцию collectionCitizen и объект синхронизации доступа syncRoot
        {
            collectionCitizen = new Citizen[] { };
            syncRoot = new object();
        }


        /// <summary>
        /// Получает или задает элемент с указанным индексом.
        /// </summary>
        /// <param name="index">Отсчитываемый с нуля индекс получаемого или задаваемого элемента.</param>
        /// <returns>Элемент с заданным индексом.</returns>
        public object this[int index]
        {
            get    // Метод доступа для чтения объекта из коллекции
            {
                try
                {
                    if (index < 0 && index >= collectionCitizen.Length)  // Условная конструкция, проверяет находится ли индекс индексатора в заданном диапазоне.
                    {
                        throw new Exception("You entered an invalid index");  // Если индекс индексатора находится вне диапазона, оператор throw генерирует пользовательское исключение
                    }
                }
                catch (Exception e)   // Оператор catch реализует исключение
                {
                    return e.Message;
                }
                return collectionCitizen[index];
            }

            set    // Метод доступа для записи объекта в коллекцию
            {
                bool check = (value as Citizen != null) ? true : false;    // Тернарная конструкция для проверки входящего параметра value метода set на равенство типов
                try
                {
                    if (!check || index < 0 || index >= collectionCitizen.Length)  // Если тип value не равен типу Citizen или производным от него типам, то генерируется пользовательское исключение
                    {
                        throw new Exception("You entered an invalid index or maybe invalid data");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }

                collectionCitizen[index] = (Citizen)value;    // Unboxing объекта value к производному типу Citizen
            }
        }

        /// <summary>
        /// Реализация сигнатуры автосвойства Count интерфейса ICollection. Автойствойство получает число элементов, содержащихся в заданной коллекции
        /// </summary>
        public int Count
        {
            get
            {
                return collectionCitizen.Length;
            }
        }

        /// <summary>
        /// Получает значение, указывающее, имеет ли список фиксированный размер.
        /// </summary>
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        ///  Получает значение, указывающее, является ли коллекция доступной только для чтения.
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
        /// Получает значение, показывающее, является ли доступ к коллекции синхронизированным (потокобезопасным).
        /// </summary>
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Получает объект, с помощью которого можно синхронизировать доступ к коллекции.
        /// </summary>
        public object SyncRoot
        {
            get
            {
                return syncRoot;
            }
        }

        /// <summary>
        /// Метод возвращает последний объект в списке
        /// </summary>
        /// <returns>Возвращает объекта типа Citizen</returns>
        public Citizen ReturnLast()
        {
            Citizen lastObject = collectionCitizen[collectionCitizen.Length - 1];
            indexLastObject = collectionCitizen.Length - 1;
            return lastObject;
        }

        /// <summary>
        /// Метод добавляет объект типа Pensioner в список и сортирует все объекты типа Pensioner в порядке очереди и с начала коллекции
        /// </summary>
        /// <param name="value">Объект типа Pensioner</param>
        /// <param name="index"> Входящий параметр по ссылке. Возвращает измененное значение параметра</param>
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

        /// <summary>
        /// Добавляет элемент в заданный список.
        /// </summary>
        /// <param name="value">Объект, добавляемый в коллекцию</param>
        /// <returns>Позиция, в которую вставлен новый элемент, или -1 для обозначения, что элемент не был помещен в коллекцию.</returns>
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

        /// <summary>
        /// Удаляет все элементы из коллекции (списка).
        /// </summary>
        public void Clear()
        {
            collectionCitizen = new Citizen[] { };
        }


        /// <summary>
        /// Определяет, содержит ли экземпляр данной коллекции указанное значение.
        /// </summary>
        /// <param name="value">Объект для поиска типа T</param>
        /// <returns>Значение true, если параметр value найден в коллекции; в противном случае — значение false.</returns>
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

        /// <summary>
        /// Копирует элементы пользовательской коллекции в массив Array, начиная с указанного индекса массива Array.
        /// </summary>
        /// <param name="array">Одномерный базовый массив Array, в который копируются элементы из нашей коллекции.
        /// Массив Array должен иметь индексацию, начинающуюся с нуля.</param>
        /// <param name="index">Отсчитываемый от нуля индекс в массиве array, указывающий начало копирования.</param>
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
                col[i + index] = this.collectionCitizen[i];
            }
            collection = col;
            array = collection;
        }

        /// <summary>
        /// Метод реализует интерфейс IEnumerable. 
        /// Предоставляет перечислитель, который поддерживает простой перебор элементов неуниверсальной коллекции.
        /// </summary>
        /// <returns>Возвращает перечислитель, который осуществляет итерацию по коллекции.</returns>
        public IEnumerator GetEnumerator()
        {
            foreach (var item in collectionCitizen)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Определяет индекс заданного элемента в коллекции.
        /// </summary>
        /// <param name="value">Объект, который требуется найти в коллекции</param>
        /// <returns>Индекс value, если он найден в списке; в противном случае -1.</returns>
        public int IndexOf(object value)
        {
            Contains(value);
            return indexRemoveValue;
        }

        /// <summary>
        /// Вставляет элемент в коллекцию по указанному индексу.
        /// </summary>
        /// <param name="index">Отсчитываемый от нуля индекс, по которому следует вставить параметр value</param>
        /// <param name="value">Объект, вставляемый в коллекцию</param>
        public void Insert(int index, object value)
        {
            bool check = (value as Citizen != null) ? true : false;
            if (check)
            {
                collectionCitizen[index] = (Citizen)value;
            }
        }

        /// <summary>
        /// Удаляет первое вхождение указанного объекта из коллекции
        /// </summary>
        /// <param name="value">Объект, который необходимо удалить из коллекции</param>
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


        /// <summary>
        /// Удаляет элемент данной коллекции по указанному индексу.
        /// </summary>
        /// <param name="index">Отсчитываемый от нуля индекс удаляемого элемента.</param>
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
            List list = new List()   // Создание коллекции типа List
            {
                   // Добавление элементов коллекции через блок инициализатора
                    new Student("EH654118", "Ukrainian", "Sergey", "Petrov"), new Student("EH654122", "Ukrainian", "Sergey", "Rebrov"),
                    new Student("EH654133", "Ukrainian", "Sergey", "Petrov"), new Student("EH884228", "Ukrainian", "Egor", "Krilov"),
                    new Pensioner("EH654333", "Ukrainian", "Sergey", "Frolov"), new Pensioner("EH654883", "Ukrainian", "Vasilii", "Nazarenko"),
                    new Pensioner("EH789456", "Ukrainian", "Oksana", "Tkachuk"),new Pensioner("EH123653", "Ukrainian", "Maria", "Yashuk"),
                    new Worker("EH654563", "Ukrainian", "Sergey", "Serov"), new Worker("EH654567", "Ukrainian", "Vlad", "Yashuk"),
                    new Worker("EH112233", "Ukrainian", "Elena", "Yashuk"), new Worker("EH456456", "Ukrainian", "Margarita", "Kurochkina")
            };
            Citizen[] massive = new Citizen[15];  // Создание массива типа Citizen, в который мы будем из коллекции list, копировать все элементы
            Console.WriteLine(list.Contains(new Student("EH654118", "Ukrainian", "Sergey", "Petrov")));  // Проверка, на наличие данного объекта в коллекции
            list.Remove(new Student("EH654118", "Ukrainian", "Sergey", "Petrov"));   // Удаление данного экземпляра объекта из коллекции list
            list.Add(new Student("EH654119", "Ukrainian", "Henadii", "Kravtsov"));   // Добавление нового экземпляра объекта в коллекцию list
            list.Remove("hello");                                                    // Попытка удаления объекта не типа Citizen. Генерация пользовательского исключения.
            list.Add("jereme");                                                      // Попытка добавления объекта не типа Citizen. Генерация пользовательского исключения.
            list.Add(new Pensioner("EH456877", "Ukrainian", "Henadii", "Kravtsov"));  // При добавлении объекта типа Pensioner происходит упорядочение по порядку всех объекто типа Pensioner
            list.RemoveAt(15);                // Удаление объекта из коллекции по заданному индексу
            Console.WriteLine(list.ReturnLast());   // Возвращает данные последнего элемента в списке
            Console.WriteLine(list[8].ToString());  // Использование индексатора для вызова элемента коллекции по заданному индексу
            list[8] = new Student("EH654118", "Ukrainian", "Sergey", "Gryshin");  // Присвоение (запись) нового экземпляра в коллекцию по заданному индексу индексатора
            list[8] = "Hello";   // Ошибка в случае добавления нового объекта не типа Citizen через индексатор 
            foreach (var item in list)   // Перебор всех элементов коллекции используя оператор foreach и реализацию интерфейса IEnumerable
            {
                Console.WriteLine(item.ToString());
            }
            list.CopyTo(massive, 0);   // Копирование всех элементов списка в массив с именем massive, начиная с нулевого индекса коллекции list
            list.Insert(2, new Student("EH654118", "Ukrainian", "Sergey", "Gryshin"));  // Замена єлемента к списке list с индексом элемента под номером 2 на другой объект
            list.IndexOf(new Student("EH654118", "Ukrainian", "Sergey", "Gryshin"));  //Возвращает номер индекса коллекции list, в которой встречается данный экземпляр объекта

            Console.ReadKey();


        }
    }
}
