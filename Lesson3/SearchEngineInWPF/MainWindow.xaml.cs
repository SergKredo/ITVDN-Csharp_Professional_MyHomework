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
using System.IO;
using System.IO.Compression;

namespace SearchEngineInWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string nameFile;   // Имя файла, который нужно найти на компьютере
        bool DeleteTextINSearchBox = true;
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 200; i++)
            {
                this.LookTextBox.Text += "Hello!\n";
            }
            this.LookTextBox.IsReadOnly = true;
            this.ResulttextBox.IsReadOnly = true;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DeleteText(object sender, MouseEventArgs e)
        {
            if (DeleteTextINSearchBox)
            {
                this.SearchTextBox.Text = this.SearchTextBox.Text.Remove(0);
                DeleteTextINSearchBox = false;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            nameFile = this.SearchTextBox.Text;
            SearchFiles();
        }

        private void ResulttextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void SearchFiles()    // Метод выполняет поиск файлов на дисках компьютера
        {
            List<string> list = new List<string>(); ;   // Универсальный набор данных в виде списка объектов
            float timeSpan;
            long timeIN, timeOut;
            int countFiles = 0;
            string fullName = null;
            DriveInfo[] drivers = DriveInfo.GetDrives(); ;    // Объявление массива объектов типа DriveInfo. Присоение переменной массива всех существующих логических дисков компьютера
            if (this.ResulttextBox.Text.Length != 0)
            {
                this.ResulttextBox.Text = this.ResulttextBox.Text.Remove(0);
            }
            timeIN = DateTime.Now.Ticks;   // Переменная хранит значение тактов времени в начальный момент поиска файлов на компьютере

            foreach (var item in drivers)   // Осуществляется перебор элементов коллекции логических дисков на компьютере
            {
                try
                {
                    DirectoryInfo searchFiels = new DirectoryInfo(@item.RootDirectory.FullName);     // Первый уровень расположения каталогов на диске. Создание переменной типа DirectoryInfo. Переменная хранит в себе информацию о всех каталогах и подкаталогах логического корневого диска
                    FileInfo[] filesThour = searchFiels.GetFiles(@nameFile, SearchOption.TopDirectoryOnly); // Осуществляется поиск на совпадение имени введенного нами файла с именами файлов, которые расположены в каталогах диска
                    if (filesThour.Length != 0)   // Заходим в блок условной конструкции, если произошло совпадение имен файлов в директории диска
                    {
                        list.Add(filesThour[0].FullName);
                        this.ResulttextBox.Text = string.Format("[{0}] - " + filesThour[0].FullName + "\n", ++countFiles);   // Вывод в окне ResulttextBox полной информации о пути расположения файла на диске
                    }

                    DirectoryInfo[] filesOne = searchFiels.GetDirectories();  // Массив всех существующих каталогов в данном логическом диске

                    foreach (var items in filesOne)   // Перебор всех каталогов и подкаталогов на данном диске
                    {
                        try
                        {
                            // Второй уровень расположения каталогов на диске.  Все операции по аналогии с вышеперечисленными операциями поиска файлов на совпадение имен файлов.
                            string nameDirectory = items.FullName;
                            DirectoryInfo searchOne = new DirectoryInfo(@nameDirectory);
                            DirectoryInfo[] filesTwo = searchOne.GetDirectories();
                            foreach (var itemTwo in filesTwo)
                            {
                                try
                                {
                                    // Третий уровень расположения каталогов на диске.  
                                    string nameDirectoryh = itemTwo.FullName;
                                    DirectoryInfo searchOneh = new DirectoryInfo(nameDirectoryh);
                                    var filesFive = searchOneh.GetDirectories();
                                    foreach (var itemFive in filesFive)
                                    {
                                        try
                                        {
                                            // Четвертый уровень расположения каталогов на диске.  
                                            FileInfo[] files = itemFive.GetFiles(@nameFile, SearchOption.AllDirectories); // Далее поиск файлов осуществляется во всех остальных каталогах и подкаталогах
                                            if (files.Length != 0)
                                            {
                                                list.Add(files[0].FullName);
                                                fullName = files[0].FullName;
                                                this.ResulttextBox.Text += string.Format("[{0}] - " + files[0].FullName + "\n", ++countFiles);
                                            }
                                        }
                                        catch (Exception) { }

                                        string nameDirectoryss = itemFive.FullName;
                                        DirectoryInfo searchOness = new DirectoryInfo(@nameDirectoryss);
                                        try
                                        {
                                            FileInfo[] filesTHreesss = searchOness.GetFiles(@nameFile, SearchOption.TopDirectoryOnly);   // Поиск имени файла на совпадение с файлами в корневом директории данного уровня вхождения
                                            if (filesTHreesss.Length != 0)
                                            {
                                                if (fullName == filesTHreesss[0].FullName)
                                                {
                                                    continue;
                                                }
                                                list.Add(filesTHreesss[0].FullName);   // Если произошло совпадение имен файлов, то мы добавляем путь данного файла в список
                                                this.ResulttextBox.Text += string.Format("[{0}] - " + filesTHreesss[0].FullName + "\n", ++countFiles);
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            continue;
                                        }
                                    }
                                }
                                catch (Exception) { }

                                string nameDirectorysss = itemTwo.FullName;
                                DirectoryInfo searchOnesss = new DirectoryInfo(@nameDirectorysss);
                                try
                                {
                                    FileInfo[] filesTHreessss = searchOnesss.GetFiles(@nameFile, SearchOption.TopDirectoryOnly);
                                    if (filesTHreessss.Length != 0)
                                    {
                                        list.Add(filesTHreessss[0].FullName);
                                        this.ResulttextBox.Text += string.Format("[{0}] - " + filesTHreessss[0].FullName + "\n", ++countFiles);
                                    }
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }
                        }
                        catch (Exception) { }

                        string nameDirectorys = items.FullName;
                        DirectoryInfo searchOnes = new DirectoryInfo(@nameDirectorys);
                        try
                        {
                            FileInfo[] filesTHreesh = searchOnes.GetFiles(@nameFile, SearchOption.TopDirectoryOnly);
                            if (filesTHreesh.Length != 0)
                            {
                                list.Add(filesTHreesh[0].FullName);
                                this.ResulttextBox.Text += string.Format("[{0}] - " + filesTHreesh[0].FullName + "\n", ++countFiles);
                            }
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            if (list.Count == 0)
            {
                this.ResulttextBox.Text = string.Format("File not found!");
            }
            timeOut = DateTime.Now.Ticks;   // Переменная хранит значение тактов времени в момент завершения поиска файлов на компьютере
            timeSpan = timeOut - timeIN;   // Разница двух тактов времен в момент завершения поиска и его начала
            this.ResulttextBox.Text += string.Format("\r\nNumber of files: {0}\r\n", countFiles);
            this.ResulttextBox.Text += string.Format("Search time = {0} sec\r\n", timeSpan / 10000000);   // 1 сек равна 10000000 тактам времени.
        }
    }
}
