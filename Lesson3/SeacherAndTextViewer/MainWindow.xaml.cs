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
using System.IO.IsolatedStorage;
using System.Windows.Xps.Packaging;
using System.Windows.Xps;
using Microsoft.Office.Interop.Word;
using System.IO.Packaging;


namespace SeacherAndTextViewer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public static class PathFile
    {
        public static string pathFile;
    }
    public partial class MainWindow : System.Windows.Window
    {
        string nameFile;   // Имя файла, который нужно найти на компьютере
        string word;       // Номер файла в окне ResulttextBox, который был найден на компьютере
        string newWord;    // Номер файла в окне ResulttextBox, который был найден на компьютере
        FileInfo delFileXps = null;
        bool DeleteTextINSearchBox = true;   // Поле определяет повторный доступ редактирования текста в окне SearchTextBox
        bool DeleteTextINFileNumberBox = true;   // Поле определяет повторный доступ редактирования текста в окне FileNumber
        List<string> listLookAt, listArchive;   // Объявление универсальной коллекции List<T>, в которой хранятся полные адреса найденных файлов

        IsolatedStorageFile isolateFile;
        FileStream file;
        StreamWriter writer;
        StreamReader reader;
        string saveColor;
        List<string> pathColor;

        public MainWindow()
        {
            InitializeComponent();   // Инициализация основных компонентов программы
            this.ResulttextBox.IsReadOnly = true;   // TextBox только для чтения
            this.LookTextBox.Visibility = Visibility.Visible;
            this.UserCont.Visibility = Visibility.Hidden;
            pathColor = new List<string>()
            {
                @"\ColorPickerSearcherApp\ColorMainWindowCP.txt",
                @"\ColorPickerSearcherApp\ColorSearchWindowCP.txt",
                @"\ColorPickerSearcherApp\ColorSearchResultWindowCP.txt",
                @"\ColorPickerSearcherApp\ColorButtonSEARCHCP.txt",
                @"\ColorPickerSearcherApp\ColorButtonLOOKCP.txt",
                @"\ColorPickerSearcherApp\ColorButtonARCHIVECP.txt",
                @"\ColorPickerSearcherApp\ColorFileNumberCP.txt",
                @"\ColorPickerSearcherApp\ColorButtonColorchangeCP.txt"
            };

            int countI = 0;
            isolateFile = IsolatedStorageFile.GetUserStoreForAssembly();
            foreach (var item in pathColor)
            {
                if (!(isolateFile.FileExists(@item)))
                {
                    if (countI++ == 0)
                    {
                        isolateFile.CreateDirectory(@"\ColorPickerSearcherApp");
                    }
                    file = isolateFile.CreateFile(@item);
                    writer = new StreamWriter(file);
                    switch (@item)
                    {
                        case @"\ColorPickerSearcherApp\ColorMainWindowCP.txt":
                            {
                                writer.WriteLine(this.MainWindowsMyApp.Background.ToString());
                            }
                            break;
                        case @"\ColorPickerSearcherApp\ColorSearchWindowCP.txt":
                            {
                                writer.WriteLine(this.SearchTextBox.Background.ToString());
                            }
                            break;
                        case @"\ColorPickerSearcherApp\ColorSearchResultWindowCP.txt":
                            {
                                writer.WriteLine(this.ResulttextBox.Background.ToString());
                            }
                            break;
                        case @"\ColorPickerSearcherApp\ColorButtonSEARCHCP.txt":
                            {
                                writer.WriteLine(this.SearchButton.Background.ToString());
                            }
                            break;
                        case @"\ColorPickerSearcherApp\ColorButtonLOOKCP.txt":
                            {
                                writer.WriteLine(this.LookButton.Background.ToString());
                            }
                            break;
                        case @"\ColorPickerSearcherApp\ColorButtonARCHIVECP.txt":
                            {
                                writer.WriteLine(this.ArchiveButton.Background.ToString());
                            }
                            break;
                        case @"\ColorPickerSearcherApp\ColorFileNumberCP.txt":
                            {
                                writer.WriteLine(this.FileNumber.Background.ToString());
                            }
                            break;
                        case @"\ColorPickerSearcherApp\ColorButtonColorchangeCP.txt":
                            {
                                writer.WriteLine(this.ColorChangeCP.Background.ToString());
                            }
                            break;
                        default:
                            {
                                break;
                            }
                    }
                    writer.Close();
                    file.Close();
                }
            }
        }

        private void DeleteText(object sender, MouseEventArgs e)  // Метод-обработчик события GotMouseCapture объекта SearchTextBox. Событие GotMouseCapture происходит при захвате мыши данным элементом.
        {
            if (DeleteTextINSearchBox)
            {
                this.SearchTextBox.Text = this.SearchTextBox.Text.Remove(0);   // При первом клике мыши по окну SearchTextBox происходит удаление информационного текста в окне
                DeleteTextINSearchBox = false;
            }
        }

        private void DeleteTextINFileNumber(object sender, MouseEventArgs e)   // Метод-обработчик события GotMouseCapture объекта FileNumber. Событие GotMouseCapture происходит при захвате мыши данным элементом.
        {
            if (DeleteTextINFileNumberBox)
            {
                this.FileNumber.Text = this.FileNumber.Text.Remove(0);   // При первом клике мыши по окну FileNumber происходит удаление информационного текста в окне
                DeleteTextINFileNumberBox = false;
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)   // Метод-обработчик события Click объекта SearchButton. Событие Click происходит при нажатии на кнопку.
        {
            if (this.delFileXps != null)
            {
                delFileXps.Delete();
            }
            nameFile = this.SearchTextBox.Text;
            SearchFiles();       // Вызывается метод, который реализует алгоритм поиска файлов на компьютере
        }

        private void LookButton_Click(object sender, RoutedEventArgs e)   // Метод-обработчик события Click объекта LookButton. Событие Click происходит при нажатии на кнопку.
        {
            if (this.delFileXps != null)
            {
                delFileXps.Delete();
            }
            word = this.FileNumber.Text;
            LookAtFile();    // Вызывается метод, который реализует алгоритм отображения информации выбранного файла в окне LookTextBox
        }

        private void ArchiveButton_Click(object sender, RoutedEventArgs e)   // Метод-обработчик события Click объекта ArchiveButton. Событие Click происходит при нажатии на кнопку.
        {
            if (this.delFileXps != null)
            {
                delFileXps.Delete();
            }
            newWord = this.FileNumber.Text;
            ArchiveFile();       // Вызывается метод, который реализует алгоритм компрессии (архивирования) информации выбранного файла
        }

        public void SearchFiles()    // Метод выполняет поиск файлов на дисках компьютера
        {
            List<string> list = new List<string>(); // Универсальный набор данных в виде списка объектов
            float timeSpan;
            long timeIN, timeOut;
            int countFiles = 0;
            string fullName = null;
            DriveInfo[] drivers = DriveInfo.GetDrives();   // Объявление массива объектов типа DriveInfo. Присоение переменной массива всех существующих логических дисков компьютера
            if (this.ResulttextBox.Text.Length != 0)
            {
                this.ResulttextBox.Text = this.ResulttextBox.Text.Remove(0);
            }
            timeIN = DateTime.Now.Ticks;   // Переменная хранит значение тактов времени в начальный момент поиска файлов на компьютере

            foreach (var item in drivers)   // Осуществляется перебор элементов коллекции логических дисков на компьютере
            {
                if (this.checkBox_AllDrives.IsChecked != true && this.checkBox_C_Drive.IsChecked != true && this.checkBox_D_Drive.IsChecked != true)   // Условная конструкция, которая срабатывает, когда checkBox c именем checkBox_AllDrives неактивный (false)
                {
                    break;   // Выход из цикла оператора foreach
                }
                if (item.Name == @"C:\" && this.checkBox_C_Drive.IsChecked != true && this.checkBox_AllDrives.IsChecked != true)  // Условная конструкция, которая срабатывает, когда checkBox c именем checkBox_C_Drive неактивный (false)
                {
                    continue;   //  Пропускаем поиск в текущем диске и переходим на следующий
                }
                if (item.Name == @"D:\" && this.checkBox_D_Drive.IsChecked != true && this.checkBox_AllDrives.IsChecked != true)   // Условная конструкция, которая срабатывает, когда checkBox c именем checkBox_D_Drive неактивный (false)
                {
                    continue;   //  Пропускаем поиск в текущем диске и переходим на следующий
                }
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
            listLookAt = list;
            listArchive = list;
            timeOut = DateTime.Now.Ticks;   // Переменная хранит значение тактов времени в момент завершения поиска файлов на компьютере
            timeSpan = timeOut - timeIN;   // Разница двух тактов времен в момент завершения поиска и его начала
            this.ResulttextBox.Text += string.Format("\r\nNumber of files: {0}\r\n", countFiles);
            this.ResulttextBox.Text += string.Format("Search time = {0} sec\r\n", timeSpan / 10000000);   // 1 сек равна 10000000 тактам времени.
        }


        public void LookAtFile()   // Метод отображает информацию выбранного файла в окне LookTextBox
        {
            try
            {
                int numberOfFile = Convert.ToInt32(this.word);
                PathFile.pathFile = listLookAt[--numberOfFile];
                string pathFileInsteadExtensXps, pathFileInsteadExtensPdf;

                if (System.IO.Path.GetExtension(PathFile.pathFile) != ".xps" && System.IO.Path.GetExtension(PathFile.pathFile) != ".pdf")
                {
                    try
                    {
                        Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application(); // создаём экземпляр приложения Word
                        Document file = word.Documents.Open(PathFile.pathFile); // создаём экземпляр документа и открываем word файл
                        //string pathFileInsteadExtensPdf = System.IO.Path.ChangeExtension(@pathFile, "pdf.pdf");
                        pathFileInsteadExtensXps = System.IO.Path.ChangeExtension(@PathFile.pathFile, "xps.xps");

                        //file.ExportAsFixedFormat(@pathFileInsteadExtensPdf, WdExportFormat.wdExportFormatPDF); // преобразование файла в PDF формат
                        file.ExportAsFixedFormat(@pathFileInsteadExtensXps, WdExportFormat.wdExportFormatXPS); // преобразование файла в XPS формат
                        word.Quit(); // закрываем Word
                        this.LookTextBox.Visibility = Visibility.Visible;
                        this.UserCont.Visibility = Visibility.Hidden;

                        XpsDocument docXps = new XpsDocument(pathFileInsteadExtensXps, FileAccess.Read);
                        LookTextBox.Document = docXps.GetFixedDocumentSequence();
                        docXps.Close();
                        delFileXps = new FileInfo(@pathFileInsteadExtensXps);
                        delFileXps.Attributes = FileAttributes.Hidden;
                    }
                    catch (Exception)
                    {
                        this.ResulttextBox.Text += "The program does not support the viewing mode of this file!";
                    }

                }
                else if (System.IO.Path.GetExtension(@PathFile.pathFile) == ".pdf")
                {
                    UserControl1 instance = InfoAboatBotton.userControl;
                    instance.LookPdfFile(InfoAboatBotton.sender, InfoAboatBotton.e);
                    this.UserCont.Visibility = Visibility.Visible;
                    this.LookTextBox.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.LookTextBox.Visibility = Visibility.Visible;
                    this.UserCont.Visibility = Visibility.Hidden;
                    XpsDocument doc = new XpsDocument(@PathFile.pathFile, FileAccess.Read);
                    LookTextBox.Document = doc.GetFixedDocumentSequence();
                    doc.Close();
                }

            }
            catch (Exception e)
            {
                this.ResulttextBox.Text += "The program does not support the viewing mode of this file!";
            }
        }

        private void Instance_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DeleteCreateFiles(object sender, EventArgs e)
        {
            if (this.delFileXps != null)
            {
                delFileXps.Delete();
            }
        }

        private void ChangeColorMainWindowsMyApp(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.MainWindowCP.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.MainWindowsMyApp.Background = (Brush)converterColor.ConvertFromString(colorText);

            FileStream file = isolateFile.OpenFile(@"\ColorPickerSearcherApp\ColorMainWindowCP.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(colorText);
            writer.Close();
            file.Close();
        }

        private void ChangeColorSearchWindowCP(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.SearchWindowCP.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.SearchTextBox.Background = (Brush)converterColor.ConvertFromString(colorText);

            FileStream file = isolateFile.OpenFile(@"\ColorPickerSearcherApp\ColorSearchWindowCP.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(colorText);
            writer.Close();
            file.Close();
        }

        private void ChangeColorSearchResultWindowCP(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.SearchResultWindowCP.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.ResulttextBox.Background = (Brush)converterColor.ConvertFromString(colorText);

            FileStream file = isolateFile.OpenFile(@"\ColorPickerSearcherApp\ColorSearchResultWindowCP.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(colorText);
            writer.Close();
            file.Close();
        }

        private void ChangeColorButtonSEARCHCP(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.ButtonSEARCHCP.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.SearchButton.Background = (Brush)converterColor.ConvertFromString(colorText);

            FileStream file = isolateFile.OpenFile(@"\ColorPickerSearcherApp\ColorButtonSEARCHCP.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(colorText);
            writer.Close();
            file.Close();
        }

        private void ChangeColorButtonLOOKCP(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.ButtonLOOKCP.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.LookButton.Background = (Brush)converterColor.ConvertFromString(colorText);

            FileStream file = isolateFile.OpenFile(@"\ColorPickerSearcherApp\ColorButtonLOOKCP.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(colorText);
            writer.Close();
            file.Close();
        }

        private void ChangeColorButtonARCHIVECP(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.ButtonARCHIVECP.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.ArchiveButton.Background = (Brush)converterColor.ConvertFromString(colorText);

            FileStream file = isolateFile.OpenFile(@"\ColorPickerSearcherApp\ColorButtonARCHIVECP.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(colorText);
            writer.Close();
            file.Close();
        }

        private void ChangeColorFileNumberCP(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.FileNumberCP.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.FileNumber.Background = (Brush)converterColor.ConvertFromString(colorText);

            FileStream file = isolateFile.OpenFile(@"\ColorPickerSearcherApp\ColorFileNumberCP.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(colorText);
            writer.Close();
            file.Close();
        }

        private void ChangeColorButtonColorchangeCP(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.ButtonColorchangeCP.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.ColorChangeCP.Background = (Brush)converterColor.ConvertFromString(colorText);
            
            FileStream file = isolateFile.OpenFile(@"\ColorPickerSearcherApp\ColorButtonColorchangeCP.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine(colorText);
            writer.Close();
            file.Close();
        }

        private void ChangeColorDefaultСolorCP(object sender, RoutedEventArgs e)
        {
            BrushConverter converterColor = new BrushConverter();

            this.MainWindowsMyApp.Background = (Brush)converterColor.ConvertFromString("#FF233232");
            this.SearchTextBox.Background = (Brush)converterColor.ConvertFromString("#FFF0F0F0");
            this.ResulttextBox.Background = (Brush)converterColor.ConvertFromString("#FFF0F0F0");
            this.SearchButton.Background = (Brush)converterColor.ConvertFromString("#FFDBEC39");
            this.LookButton.Background = (Brush)converterColor.ConvertFromString("#FFDBEC39");
            this.ArchiveButton.Background = (Brush)converterColor.ConvertFromString("#FFDBEC39");
            this.FileNumber.Background = (Brush)converterColor.ConvertFromString("#FFF0F0F0");
            this.ColorChangeCP.Background = (Brush)converterColor.ConvertFromString("#FFF0F0F0");
            
            foreach (var item in pathColor)
            {
                isolateFile.DeleteFile(@item);
            }
            isolateFile.Close();
        }

        public void ArchiveFile()   // Метод архивирует выбранный файл
        {
            try
            {
                int numberOfFileToArchive = Convert.ToInt32(newWord);
                string pathFileToArchive = listArchive[--numberOfFileToArchive];
                // 1-й метод архивирования файла. Архивировать можно только файлы по отдельности
                FileStream fileOpenToArchive = File.Open(@pathFileToArchive, FileMode.OpenOrCreate, FileAccess.ReadWrite);   // Создаем поток в файле с операциями чтения и записи по заданному пути
                string pathFileZipperOne = @pathFileToArchive.Substring(0, pathFileToArchive.LastIndexOf(@"\"[0]));
                string pathCompressFile = @System.IO.Path.ChangeExtension(pathFileZipperOne + @"\_1Method.txt", ".zip");
                FileStream fileArchive = File.Create(@pathCompressFile);   // Создаем новый файл типа архив с расширение zip и поток данного файла для записи и чтения. Используя класс Path пространства имен System.IO добавляем расширение zip к адресной строке файла

                StreamReader strNewFile = new StreamReader(fileOpenToArchive);  // Объект класса StreamReader позволяет считывать символы из потока файла
                string textArchiveNew = strNewFile.ReadToEnd();  // Присваиваем переменной строковое значение, которое считал объект типа StreamReader
                byte[] byteMassiveNew = new byte[textArchiveNew.Length];  // Создаем новый одномерный массив типа byte. Данный массив байтов будет хранить значения литералов, коотрые хранятся в переменной textArchiveNew

                for (int i = 0; i < textArchiveNew.Length; i++)
                {
                    byteMassiveNew[i] = (byte)textArchiveNew[i];
                }
                GZipStream compressor = new GZipStream(fileArchive, CompressionMode.Compress);  // Создаем экземпялр объекта типа GZipStream, который осуществляет сжатие и распаковку потока файла
                compressor.Write(byteMassiveNew, 0, textArchiveNew.Length);  //Записывает сжатые байты в основной поток из указанного массива байтов.
                compressor.Close();   // Закрываем текущий поток и отключаем все ресурсы занимаемые потоком в памяти
                fileOpenToArchive.Close();
                fileArchive.Close();
                strNewFile.Close();

                string pathFileZipper = @pathFileToArchive.Substring(0, pathFileToArchive.LastIndexOf(@"\"[0]));
                try
                {  // 2-й метод архивирования. Архивировать можно целую директорию с файлами и вложенными подкаталогами
                   // Для получения доступа к классу-объекту ZipFile в проект добавлена ссылка на сборку System.IO.Compression.FileSystem
                    ZipFile.CreateFromDirectory(@pathFileZipper, System.IO.Path.ChangeExtension(@pathFileZipper + @"\_2Method.txt", ".zip"));   // Создаем архив типа zip. Первый аргумент указывает на место расположения файлов, которые нужно архивировать. Второй - путь расположения архива и его название
                }
                catch (Exception) { }
                finally
                {
                    FileInfo zipExist = new FileInfo(@System.IO.Path.ChangeExtension(@pathFileZipper + @"\_2Method.txt", ".zip"));
                    if (zipExist.Exists)
                    {
                        this.ResulttextBox.Text += string.Format("\nFile [{0}] archived!\nArchive 1: {1};\nArchive 2: {2};\n", numberOfFileToArchive + 1, pathCompressFile, zipExist.FullName);
                    }
                    else
                    {
                        this.ResulttextBox.Text += string.Format("\nUnfortunately, the archive could not be created!\n");
                    }
                }
            }
            catch (Exception e)
            {
                this.ResulttextBox.Text += string.Format("\n" + e.Message + "\n");
            }
        }

    }
}
