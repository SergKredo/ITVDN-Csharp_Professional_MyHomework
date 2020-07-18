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
using System.Windows.Xps.Packaging;
using System.Windows.Xps;


namespace ColorPicker
{
        /*Задание 4
    Создайте приложение WPF Application, позволяющее пользователям сохранять данные в
    изолированное хранилище.
    Для выполнения этого задания необходимо наличие библиотеки Xceed.Wpf.Toolkit.dll. Ее
    можно получить через References -> Manage NuGet Packages… -> в поиске написать Extended
    WPF Toolkit (помимо интересующей нас библиотеки будут установлены и другие), или же
    скачать непосредственно на сайте http://wpftoolkit.codeplex.com/ и подключить в проект только
    интересующую нас бибилиотеку (References -> Add Reference …).
    1. Разместите в окне Label и Button.
    2. Разместите в окне ColorPicker (данный инструмент предоставляется вышеуказанной
    библиотекой). Для этого необходимо в XAML коде в теге Window подключить пространство
    имен xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit" . Также, нам понадобиться событие
    Loaded окна.
    3. Реализуйте, чтобы при выборе цвета из ColorPicker в Label выводилось название
    выбранного цвета и в этот цвет закрашивался фон Label. По нажатию на кнопку, данные о
    цвете сохраняются в изолированное хранилище. При запуске приложения заново, цвет фона
    Label остается таким, каким был сохранен при предыдущих запусках приложения.*/

    public partial class MainWindow : Window
    {
        IsolatedStorageFile isolateFile;   // Область изолированного хранилища, в которой находятся изолированные файлы и папки программы
        FileStream file;   // Файловый поток для записи и чтения данных в файл и из файла
        StreamWriter writer;   // Объект реализует TextWriter для записи в файловый поток символов в определенной кодировке  
        StreamReader reader;  // Объект реализует TextReader для чтения символов из файлового потока в определенной кодировке
        string saveColor;   // Поле, определяющее название цвета элемента в программе
        public MainWindow()
        {
            InitializeComponent();
            isolateFile = IsolatedStorageFile.GetUserStoreForAssembly();  // Создание на компьютере пользовательской области для изолированного хранения файлов. Путь к изолированному пространству "C:\Users\Serg\AppData\Local\IsolatedStorage\"
            if (!(isolateFile.DirectoryExists(@"\ColorPicker") && isolateFile.FileExists(@"\ColorPicker\DateAboatColorApp.txt")))   // Проверка на существование файла с таким адресом в "песочнице"
            {
                isolateFile.CreateDirectory(@"\ColorPicker");  // Создаем пользовательский каталог в "песочнице" для хранения всех текстовых файлов с названием цветов
                file = isolateFile.CreateFile(@"\ColorPicker\DateAboatColorApp.txt");  //Создаем файловый поток с конкретным текстовым файлом
                writer = new StreamWriter(file);  //  Создаем поток для записи названий цветов элементов в файлы
                writer.WriteLine(this.label.Background.ToString());
                writer.Close();  // Закрываем поток
                file.Close();  // Зкрываем поток
            }

        }

        private void Windows_Loading(object sender, RoutedEventArgs e)  // Метод-обработчик события Loaded. Метод позволяет при запуске программы считывать с текстовых файлов названия цветов
        {
            file = isolateFile.OpenFile(@"\ColorPicker\DateAboatColorApp.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(file);
            saveColor = reader.ReadToEnd();
            this.label.Content = string.Format("\r"+saveColor);
            BrushConverter converterColor = new BrushConverter();
            this.label.Background = (Brush)converterColor.ConvertFromString(saveColor);
            reader.Close();
            file.Close();
        }

        private void ChangeColor(object sender, RoutedPropertyChangedEventArgs<Color?> e)  // Метод обработчик позволяет изменять цвет элементов интерфейса программы
        {
            string colorText = this.colorPicker.SelectedColorText;
            this.label.Content = colorText;
            BrushConverter converterColor = new BrushConverter();
            this.label.Background = (Brush)converterColor.ConvertFromString(colorText);
        }

        private void button_Click(object sender, RoutedEventArgs e)  // Метод обработчик позволяет при нажатии на кнопку Save программы сохранять данные о цвете в текстовы файл в "песочнице"
        {
            file = isolateFile.OpenFile(@"\ColorPicker\DateAboatColorApp.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            writer = new StreamWriter(file);
            writer.WriteLine(this.label.Background.ToString());
            writer.Close();
            file.Close();
            this.label.Content = string.Format(new string(" "[0], 14)+"Color {0}\n is stored in isolated storage.".ToUpper(), this.label.Background.ToString());         
        }
    }
}
