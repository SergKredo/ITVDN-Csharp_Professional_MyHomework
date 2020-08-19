using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AdditionalClassLibraryOld;
using AdditionalClassLibraryNew;

namespace Additional_Task
{
    /*Реализуйте шаблон NVI в собственной иерархии наследования.*/

    class Program
    {
        protected static Type baseClass;
        static void Main(string[] args)
        {
            Assembly assembly = null;
            assembly = Assembly.Load("AdditionalClassLibraryOld"); // Загрузка сборки (сборка в виде библиотеки dll помещена в корень папки debug приложения)
            Type type = assembly.GetType("AdditionalClassLibraryOld.BaseClassOld");  // Возврат объекта Type для конкретного типа данной загруженной сборки
            object[] parameters = { DateTime.Now, "Germany", "Berlin" };  // Массив параметров для метода, который создает экземпляр данного типа сборки
            dynamic instance = Activator.CreateInstance(type, parameters);  // Создание экземпляра объекта путем позднего связывания
            Console.WriteLine("Late binding:".ToUpper());
            instance.ShowMessage();
            Console.WriteLine(new string('-', 100));
            Console.WriteLine(new string('-', 100));

            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("Old version app:".ToUpper());
            BaseClassOld oldVersion = new MyClass1();
            oldVersion.ShowMessage();
            Console.WriteLine(new string('-', 100));
            Console.WriteLine(new string('-', 100));
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("New version app:".ToUpper());
            BaseClassNew newVersion = new MyClass2();
            newVersion.ShowMessage();
            Console.ReadKey();
        }
    }

    // Объявляем пользовательский класс. Класс наследуется от базового класса с именем BaseClassOld (старая версия dll библиотеки)
    class MyClass1 : BaseClassOld
    {
        protected override void ShowDate(DateTime date)  // Переопределяем базовый виртуальный метод
        {
            base.ShowDate(DateTime.Parse("13.05.2020"));
        }

        protected override void PlaceInTheWorld(string nameCountry)  // Переопределяем базовый виртуальный метод
        {
            base.PlaceInTheWorld("Ukraine");
        }

        protected override void CityInCountry(string nameCity)  // Переопределяем базовый виртуальный метод
        {
            base.CityInCountry("Kyiv");
        }
    }

    class MyClass2 : BaseClassNew  // Объявляем пользовательский класс. Класс наследуется от базового класса с именем BaseClassNew (новая версия dll библиотеки)
    {
        protected override void ShowDate(DateTime date)  // Переопределяем базовый виртуальный метод
        {
            base.ShowDate(DateTime.Parse("22.08.1998"));
        }

        protected override void PlaceInTheWorld(string nameCountry)  // Переопределяем базовый виртуальный метод
        {
            base.PlaceInTheWorld("Moscow");
        }

        protected override void CityInCountry(string nameCity)  // Переопределяем базовый виртуальный метод
        {
            base.CityInCountry("Piter");
        }
    }
}

/*
 Results:
---------------------------------------------------------------------------------------------------------------------------
LATE BINDING:
Date time: 19.08.2020 21:09:50
Name of the Country: Germany
Name of the City: Berlin
----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------
OLD VERSION APP:
Date time: 13.05.2020 00:00:00
Name of the Country: Ukraine
Name of the City: Kyiv
----------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------
NEW VERSION APP:
----------------------------------------------------------------------------------------------------
You're velcome, dear friend!
----------------------------------------------------------------------------------------------------
Date time: 22.08.1998 00:00:00
Name of the Country: Moscow
Name of the City: Piter

 */
