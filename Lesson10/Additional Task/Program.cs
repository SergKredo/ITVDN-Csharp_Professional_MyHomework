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
    class MyClass1 : BaseClassOld
    {
        protected override void ShowDate(DateTime date)
        {
            base.ShowDate(DateTime.Parse("13.05.2020"));
        }

        protected override void PlaceInTheWorld(string nameCountry)
        {
            base.PlaceInTheWorld("Ukraine");
        }

        protected override void CityInCountry(string nameCity)
        {
            base.CityInCountry("Kyiv");
        }
    }

    class MyClass2 : BaseClassNew
    {
        protected override void ShowDate(DateTime date)
        {
            base.ShowDate(DateTime.Parse("22.08.1998"));
        }

        protected override void PlaceInTheWorld(string nameCountry)
        {
            base.PlaceInTheWorld("Moscow");
        }

        protected override void CityInCountry(string nameCity)
        {
            base.CityInCountry("Piter");
        }
    }
}
