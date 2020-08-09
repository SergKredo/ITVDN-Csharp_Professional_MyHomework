using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2_Converter_Temperature
{
    public abstract class BaseConverter
    {
        protected char[] charMassive;  // Создание массива данных разрешенных знаков, которые пользователь может ввести с клавиатуры
        // Поля, которые используются в методах обработчиках событий 
        protected static double degreeCelcia;
        protected static double degreeKelvin;
        protected static double degreeFarinhate;
        protected static string textCelcia;
        protected static string textKelvin;
        protected static string textFarinhate;
        protected bool kelvin;
        protected bool farinhate;
        protected bool celcia;
        protected TextBox textBox_Kelvine;
        protected TextBox textBox_Farinhate;
        protected TextBox textBox_Celcia;

        protected BaseConverter()  // Инициализация полей класса
        {
            this.charMassive = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',' };
            degreeCelcia = degreeKelvin = degreeFarinhate = 0;
            textCelcia = textKelvin = textFarinhate = "";
            this.kelvin = farinhate = celcia = true;
        }

        protected BaseConverter(TextBox textBox_Kelvine, TextBox textBox_Farinhate, TextBox textBox_Celcia)  // Пользовательский конструктор
            : this()
        {
            // Присвоение полям класса значений объектов textBox (параметров экземпляра класса), которые пользователь ранее сформировал в своем приложении ConverterTemperature
            this.textBox_Kelvine = textBox_Kelvine;
            this.textBox_Farinhate = textBox_Farinhate;
            this.textBox_Celcia = textBox_Celcia;
        }

        public abstract double ConvertCelciaToKelvine(double degree);  // Абстрактный метод для конвертации температуры из градусов Цельсия в Кельвины

        public abstract double ConvertCelciaToFarinhate(double degree);  // Абстрактный метод для конвертации температуры из градусов Цельсия в Фарингейты

        public abstract double ConvertKelvineToCelcia(double degree);  // Абстрактный метод для конвертации температуры из Кельвинов в градусы Цельсия

        public abstract double ConvertKelvineToFarinhate(double degree);  // Абстрактный метод для конвертации температуры из Кельвинов в Фарингейты

        public abstract double ConvertFarinhateToCelcia(double degree);  // Абстрактный метод для конвертации температуры из градусов Фарингейта в градусы Цельсия

        public abstract double ConvertFarinhateToKelvine(double degree);  // Абстрактный метод для конвертации температуры из градусов Фарингейта в Кельвины

        // Абстрактный метод (аналог метода-обработчика событий) выводит введенное пользователем значение в окне textBox Кельвины 
        // и пересчитует значения температуры в двух других окнах: для Цельсия и Фарингейта
        public abstract void textBox_Kelvine_TextChanged(object sender, EventArgs e);


        // Абстрактный метод (аналог метода-обработчика событий) выводит введенное пользователем значение в окне textBox Цельсия
        // и пересчитует значения температуры в двух других окнах: для Кельвины и Фарингейты
        public abstract void textBox_Celcia_TextChanged(object sender, EventArgs e);


        // Абстрактный метод (аналог метода-обработчика событий) выводит введенное пользователем значение в окне textBox Фарингейты
        // и пересчитует значения температуры в двух других окнах: для Цельсия и Фарингейты
        public abstract void textBox_Farinhate_TextChanged(object sender, EventArgs e);
        
    }
}
