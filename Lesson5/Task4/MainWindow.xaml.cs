using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.IO;


namespace Task4
{
    /*
     Создайте приложение WPF Application, в главном окне которого поместите любой текст. Также,
должно быть окно настроек (можно реализовать с помощью TabControl). Пользователь может
изменять настройки. При повторном запуске приложения настройки должны оставаться
прежними. Реализуйте два варианта (в одном приложении или двух разных): 1) сохранение
настроек в конфигурационном файле; 2) сохранение настроек в реестре.
    В окне настроек реализуйте следующие опции: цвет фона, цвет текста, размер шрифта, стиль
шрифта, а также кнопку «Сохранить». Для выбора цвета воспользуйтесь ColorPicker-ом по
примеру задания из Урока №3.

     Для выполнения этого задания необходимо наличие библиотеки Xceed.Wpf.Toolkit.dll. Ее
    можно получить через References -> Manage NuGet Packages… -> в поиске написать Extended
    WPF Toolkit (помимо интересующей нас библиотеки будут установлены и другие), или же
    скачать непосредственно на сайте http://wpftoolkit.codeplex.com/ и подключить в проект только
    интересующую нас бибилиотеку (References -> Add Reference …).
        Для этого необходимо в XAML коде в теге Window подключить пространство
    имен xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit" .
     */

    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();


        }

        private void Windows_Loading(object sender, RoutedEventArgs e)  // Метод-обработчик события Loaded. Метод позволяет при запуске программы считывать с текстовых файлов названия цветов
        {
            string text = File.ReadAllText(@"005_XML. Файлы конфигурации. Реестр_.txt");
            this.Text.Text = text;
        }

        private void LookPanel(object sender, MouseButtonEventArgs e)
        {
        }

       
    }
}
