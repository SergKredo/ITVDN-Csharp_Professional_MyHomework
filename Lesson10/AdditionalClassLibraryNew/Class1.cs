using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalClassLibraryNew
{
    // Создаем dll библиотеку с базовым классом (новая версия dll библиотеки)
    public class BaseClassNew  // Объявляем базовый класс
    {
        DateTime date;
        string nameCountry;
        string nameCity;

        public BaseClassNew()  // Конструктор по умолчанию
        { }
        public BaseClassNew(DateTime date, string nameCountry, string nameCity)  // Пользовательский конструктор
        {
            this.date = date;
            this.nameCountry = nameCountry;
            this.nameCity = nameCity;
        }
        public void ShowMessage()  // Используем NVI шаблон
        {
            Greeting();                  // Добавляем новый функционал в dll библиотеку
            ShowDate(date);
            PlaceInTheWorld(nameCountry);
            CityInCountry(nameCity);
        }
        protected virtual void ShowDate(DateTime date)  // Объявляем виртуальный метод
        {
            this.date = date;
            Console.WriteLine("Date time: {0}", date);
        }
        protected virtual void PlaceInTheWorld(string nameCountry)  // Объявляем виртуальный метод
        {
            this.nameCountry = nameCountry;
            Console.WriteLine("Name of the Country: {0}", nameCountry);  
        }
        protected virtual void CityInCountry(string nameCity)  // Объявляем виртуальный метод
        {
            this.nameCity = nameCity;
            Console.WriteLine("Name of the City: {0}", nameCity);
        }

        void Greeting()  // Новый функционал
        {
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("You're velcome, dear friend!");
            Console.WriteLine(new string('-', 100));
        }
    }
}
