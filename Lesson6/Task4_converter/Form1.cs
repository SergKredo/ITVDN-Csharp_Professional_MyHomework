using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Task4_converter
{
    /*
     2-й способ создания приложения конвертера температуры: Цельсии, Кельвин, Фарингейты путем позднего связывания на этапе выполнения программы
     */

    /*
         Задание 3
    Создайте программу, в которой предоставьте пользователю доступ к сборке из Задания 2.
    Реализуйте использование метода конвертации значения температуры из шкалы Цельсия в
    шкалу Фаренгейта. Выполняя задание используйте только рефлексию.
     */
    public partial class Form1 : Form
    {
        dynamic converterTemperature;  // Объявление динамического поля
        Assembly assemblyConverter = null;  // Объявление сборки
        public Form1()
        {
            InitializeComponent();
            assemblyConverter = Assembly.Load("Task 2_Converter_Temperature");  // Загрузка сборки (сборка в виде библиотеки dll помещена в корень папки debug приложения)
            Type type = assemblyConverter.GetType("Task_2_Converter_Temperature.ConverterTemperature");  // Возврат объекта Type для конкретного типа данной загруженной сборки
            object[] parameters = { this.textBox_Kelvine, this.textBox_Farinhate, this.textBox_Celcia };  // Массив параметров для метода, который создает экземпляр данного типа сборки
            converterTemperature = Activator.CreateInstance(type, parameters);    // Создание экземпляра объекта путем позднего связывания
        }


        private void textBox_Kelvine_TextChanged(object sender, EventArgs e)  // Метод-обработчик события, которое определяет момент написания текста в окне textBox для Кельвин
        {
            converterTemperature.textBox_Kelvine_TextChanged(sender, e);  // На экземпляре созданного объекта вызываем метод и передаем параметры
        }

        private void textBox_Celcia_TextChanged(object sender, EventArgs e)  // Метод-обработчик события, которое определяет момент написания текста в окне textBox для Цельсий
        {
            converterTemperature.textBox_Celcia_TextChanged(sender, e);  // На экземпляре созданного объекта вызываем метод и передаем параметры
        }

        private void textBox_Farinhate_TextChanged(object sender, EventArgs e)  // Метод-обработчик события, которое определяет момент написания текста в окне textBox для Фарингейт
        {
            converterTemperature.textBox_Farinhate_TextChanged(sender, e);  // На экземпляре созданного объекта вызываем метод и передаем параметры
        }
    }
}
