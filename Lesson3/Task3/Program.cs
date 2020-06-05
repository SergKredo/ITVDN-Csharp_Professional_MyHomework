using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO.Compression;

namespace Task3
{
    /*Задание 3
Напишите приложение в консоли для поиска заданного файла на диске. Добавьте код, использующий
класс FileStream и позволяющий просматривать файл в текстовом окне. В заключение
добавьте возможность сжатия найденного файла.*/


    class Program
    {

        static void Main(string[] args)
        {

            Console.SetWindowSize(149, 35);   // Размер консоли в робочем окне Winsows
            Console.SetBufferSize(149, 9001);  // Размер буферной области

        Again:   // Метка возврата
            Console.InputEncoding = Encoding.Unicode;  // Изменение кодировки в консоли при чтении ввода данных
            Console.OutputEncoding = Encoding.Unicode;   // Изменение кодировки в консоли при записи вывода данных
            List<string> list = new List<string>();   // Универсальный набор данных в виде списка объектов

            Console.Write("Enter a file name to search: ".ToUpper());
            Console.ForegroundColor = ConsoleColor.Yellow;   // Изменение цвета текста в консоли
            string nameFile = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;   // Восстановление цвета текста в консоли по умолчанию
            Console.WriteLine(new string('-', 148));
            float timeSpan;
            long timeIN, timeOut;
            int countFiles = 0;
            string fullName = null;
            DriveInfo[] drivers = DriveInfo.GetDrives();    // Объявление массива объектов типа DriveInfo. Присоение переменной массива всех существующих логических дисков компьютера
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
                        Console.WriteLine("[{0}] - " + filesThour[0].FullName, ++countFiles);   // Вывод в консоли полной информации о пути расположения файла на диске
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
                                                Console.WriteLine("[{0}] - " + files[0].FullName, ++countFiles);
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
                                                Console.WriteLine("[{0}] - " + filesTHreesss[0].FullName, ++countFiles);
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
                                        Console.WriteLine("[{0}] - " + filesTHreessss[0].FullName, ++countFiles);
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
                                Console.WriteLine("[{0}] - " + filesTHreesh[0].FullName, ++countFiles);
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

            Console.WriteLine(new string('-', 148));
            timeOut = DateTime.Now.Ticks;   // Переменная хранит значение тактов времени в момент завершения поиска файлов на компьютере
            timeSpan = timeOut - timeIN;   // Разница двух тактов времен в момент завершения поиска и его начала
            Console.WriteLine("Number of files: {0}", countFiles);
            Console.WriteLine("Search time = {0} sec\n", timeSpan / 10000000);   // 1 сек равна 10000000 тактам времени.
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('*', 148));
            Console.WriteLine(new string('*', 148));
            Console.ForegroundColor = ConsoleColor.Gray;

        Read:
            while (true)   // Бесконечный цикл для повторения заданного алгоритма действий в коде программы
            {
                try
                {
                    Console.Write("Select the file number you would like to read: ".ToUpper());   // После отображения в консоли ссылок найденных на компьютере файлов, нам дается возможность ввести номер данного файла по списку и прочитать информацию, хранящуюся на файле
                    string word = Console.ReadLine();
                    if (word.ToLowerInvariant() == "back")    // Введенное слово "back" позволяет перейти на начальный уровень поиска файлов 
                    {
                        goto Again;
                    }
                    if (word.ToLowerInvariant() == "next")   // Введенное слово "next" позволяет выйти из состояния просмотра файлов и начать компрессию данного файла в формате архива zip
                    {
                        goto Next;
                    }
                    int numberOfFile = Convert.ToInt32(word);
                    string pathFile = list[--numberOfFile];

                    FileStream fileOpen = File.OpenRead(@pathFile);     // Создание потока для чтения данных из файла
                    StreamReader reader = new StreamReader(fileOpen, Encoding.Default);  // Класс StreamReader используется для чтения строк из потока. Кодировка по умолчанию.
                    int numberLiterals = reader.ReadToEnd().Length;
                    fileOpen.Position = 0;    // Задаем начальное положение в потоке
                    string text = reader.ReadToEnd();
                    List<char> literals = new List<char>();   // Создаем список литералов, которые мы прочитали из файла
                    for (int i = 0; i < numberLiterals; i++)
                    {
                        literals.Add(text[i]);   // Инициализация элементов и добавление значений литералов в список
                    }

                    int numberLines = 1;
                    if (numberLiterals > 140)
                    {
                        numberLines += numberLiterals / 140;   // Каждая строка в окне отображения текста в консоли содержит не более 140 литералов
                    }

                    Encoding code = Encoding.Default;   // Кодировка по умолчанию.
                    byte[] sym = new byte[256];
                    for (int i = 0; i < 256; i++)
                    {
                        sym[i] = (byte)i;
                    }
                    char[] chart = new char[256];
                    chart = code.GetChars(sym);


                    // Создаем окно отображения информации из файла. Выводим построчно выделенные границы окна, изменяем цвет фона консоли на белый, последовательно текст из файла
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(new string('#', 148));
                    Console.BackgroundColor = ConsoleColor.Black;
                    int j = 0;
                    int length = 140;
                    for (int i = 0; i < numberLines; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(new string('#', 1));
                        Console.Write(new string(" "[0], 3));
                        int count = 0;
                        for (int k = j; k < length; k++)
                        {
                            count = k;
                            try
                            {
                                if ((literals.Count - 1 < k) && k > 0 && (literals[k - 1] == '\r' || literals[k - 1] == '\n'))
                                {
                                    j = ++length;
                                    length += 140;
                                    break;
                                }
                                else if (literals.Count - 1 < k)
                                {
                                    Console.Write(" ");
                                }
                                else
                                {
                                    if (literals[k] == '\r' || literals[k] == '\n')
                                    {
                                        if (literals[k - 1] == '\r' && literals[k] == '\n')
                                        {
                                            Console.BackgroundColor = ConsoleColor.White;
                                            Console.Write(new string('#', 1));
                                            Console.Write(new string(" "[0], 3));
                                            for (int l = 0; l < 140; l++)
                                            {
                                                Console.Write(" ");
                                            }
                                        }
                                        else if (literals[k - 1] == '\n' && literals[k] == '\r')
                                        {
                                            Console.BackgroundColor = ConsoleColor.White;
                                            Console.Write(new string('#', 1));
                                            Console.Write(new string(" "[0], 3));
                                            for (int l = 0; l < 140; l++)
                                            {
                                                Console.Write(" ");
                                            }
                                        }
                                        else
                                        {
                                            for (int l = k; l < length; l++)
                                            {
                                                Console.Write(" ");
                                            }
                                        }
                                        Console.Write(new string(" "[0], 3));
                                        Console.Write(new string('#', 1) + "\n");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        continue;
                                    }
                                    else if (k > 0 && literals[k - 1] == '\n')
                                    {
                                        Console.BackgroundColor = ConsoleColor.White;
                                        Console.Write(new string('#', 1));
                                        Console.Write(new string(" "[0], 3));
                                        int coeff = length - k;
                                        int addCoeff = 140 - coeff;
                                        length += addCoeff;
                                    }

                                    Console.Write(literals[k]);
                                }
                            }
                            catch (Exception)
                            {
                                if (literals.Count - 1 < k)
                                {
                                    Console.Write(" ");
                                }
                                continue;
                            }
                        }
                        try
                        {
                            if (count < length && literals[count] == '\n')
                            {
                                j = ++length;
                                length += 140;
                                continue;
                            }
                        }
                        catch (Exception)
                        {
                            break;
                        }


                        j = length;
                        length += 140;
                        Console.Write(new string(" "[0], 3));
                        Console.Write(new string('#', 1) + "\n");
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine(new string('#', 148) + "\n");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(" ");


                    reader.Close();   // Метод Close() закрывает текущий объект StreamReader и базовый поток.
                    fileOpen.Close();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(new string('*', 148));
                    Console.WriteLine(new string('*', 148));
                    Console.ForegroundColor = ConsoleColor.Gray;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }



        // Алгоритм позволяет делать компрессию данного файла в виде архива ZIP. Архивация осуществляется двумя способами. 
        Next:
            try
            {
                while (true)
                {
                    Console.Write("Select the file number you would like to archive: ".ToUpper());
                    string newWord = Console.ReadLine();
                    if (newWord.ToLowerInvariant() == "back")
                    {
                        goto Again;
                    }
                    if (newWord.ToLowerInvariant() == "read")
                    {
                        goto Read;
                    }
                    int numberOfFileToArchive = Convert.ToInt32(newWord);
                    string pathFileToArchive = list[--numberOfFileToArchive];


                    // 1-й метод архивирования файла. Архивировать можно только файлы по отдельности
                    FileStream fileOpenToArchive = File.Open(@pathFileToArchive, FileMode.OpenOrCreate, FileAccess.ReadWrite);   // Создаем поток в файле с операциями чтения и записи по заданному пути
                    string pathFileZipperOne = @pathFileToArchive.Substring(0, pathFileToArchive.LastIndexOf(@"\"[0]));
                    string pathCompressFile = @Path.ChangeExtension(pathFileZipperOne + @"\_1Method.txt", ".zip");
                    FileStream fileArchive = File.Create(@pathCompressFile);   // Создаем новый файл типа архив с расширение zip и поток данного файла для записи и чтения. Используя класс Path добавляем расширение zip к адресной строке файла

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
                        ZipFile.CreateFromDirectory(@pathFileZipper, Path.ChangeExtension(@pathFileZipper + @"\_2Method.txt", ".zip"));   // Создаем архив типа zip. Первый аргумент указывает на место расположения файлов, которые нужно архивировать. Второй - путь расположения архива и его название
                    }
                    catch (Exception) { }
                    finally
                    {
                        FileInfo zipExist = new FileInfo(@Path.ChangeExtension(@pathFileZipper + @"\_2Method.txt", ".zip"));
                        if (zipExist.Exists)
                        {
                            Console.WriteLine(new string('-', 148));
                            Console.WriteLine("[1] - {0}", zipExist.FullName);
                            Console.WriteLine(new string('-', 148));
                        }
                        else
                        {
                            Console.WriteLine(new string('-', 148));
                            Console.WriteLine("Unfortunately, the archive could not be created!");
                            Console.WriteLine(new string('-', 148));
                        }
                        FileInfo deleteFile = new FileInfo(@pathCompressFile);   // Создаем объект, который будет содержать всю основную информацию о файле
                        deleteFile.Delete(); // Удаляем из каталога созданный 1-м путем архив
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto Next;
            }
        }
    }
}

/*RESULT:*/
/*
 ENTER A FILE NAME TO SEARCH: test.txt
----------------------------------------------------------------------------------------------------------------------------------------------------
[1] - D:\Android\android-sdk\platform-tools\systrace\catapult\telemetry\third_party\modulegraph\modulegraph_tests\testdata\test.txt
[2] - D:\Dropbox\Программирование на С#_ITVDN\csharp-for-professional\HomeWorkAnswers\Lesson 003\Task_1\bin\Debug\test.txt
[3] - D:\Test\test.txt
----------------------------------------------------------------------------------------------------------------------------------------------------
Number of files: 3
Search time = 64,05241 sec

****************************************************************************************************************************************************
****************************************************************************************************************************************************
SELECT THE FILE NUMBER YOU WOULD LIKE TO READ: 2
####################################################################################################################################################
#   Hello world!!!                                                                                                                                 #
#                                                                                                                                                  #
####################################################################################################################################################


****************************************************************************************************************************************************
****************************************************************************************************************************************************
SELECT THE FILE NUMBER YOU WOULD LIKE TO READ: next
SELECT THE FILE NUMBER YOU WOULD LIKE TO ARCHIVE: 2
----------------------------------------------------------------------------------------------------------------------------------------------------
[1] - D:\Dropbox\Программирование на С#_ITVDN\csharp-for-professional\HomeWorkAnswers\Lesson 003\Task_1\bin\Debug\_2Method.zip
----------------------------------------------------------------------------------------------------------------------------------------------------
SELECT THE FILE NUMBER YOU WOULD LIKE TO ARCHIVE: read
SELECT THE FILE NUMBER YOU WOULD LIKE TO READ: 3
####################################################################################################################################################
#   Hi! Sergey! You're welcome! Привет. Сергей!                                                                                                    #                                                                                                                                                                    
####################################################################################################################################################


****************************************************************************************************************************************************
****************************************************************************************************************************************************
SELECT THE FILE NUMBER YOU WOULD LIKE TO READ: next
SELECT THE FILE NUMBER YOU WOULD LIKE TO ARCHIVE: 3
----------------------------------------------------------------------------------------------------------------------------------------------------
[1] - D:\Test\_2Method.zip
----------------------------------------------------------------------------------------------------------------------------------------------------
SELECT THE FILE NUMBER YOU WOULD LIKE TO ARCHIVE: back
ENTER A FILE NAME TO SEARCH: Proton.txt
----------------------------------------------------------------------------------------------------------------------------------------------------
[1] - C:\Proton.txt
[2] - C:\Program Files\Proton.txt
[3] - C:\Users\Serg\Downloads\Documents\Proton.txt
[4] - C:\Users\Serg\Proton.txt
[5] - C:\Users\Proton.txt
[6] - D:\Android\android-sdk\system-images\android-27\google_apis\x86\Proton.txt
[7] - D:\Dropbox\Программирование на С#_ITVDN\csharp-for-professional\Proton.txt
[8] - D:\Jiayu\Proton.txt
[9] - D:\Данные с компьютера и старого ноутбука\программы\Proton.txt
[10] - D:\Данные с компьютера и старого ноутбука\Фото и видео со смартфона\huawei\DCIM\Camera\Proton.txt
[11] - D:\Данные с компьютера и старого ноутбука\Proton.txt
----------------------------------------------------------------------------------------------------------------------------------------------------
Number of files: 11
Search time = 63,07287 sec

****************************************************************************************************************************************************
****************************************************************************************************************************************************
SELECT THE FILE NUMBER YOU WOULD LIKE TO READ: 4
####################################################################################################################################################
#   Резюме:                                                                                                                                        #
#                                                                                                                                                  #
#   - Для перечисления объектов файловой системы и получения подробной информации об                                                               #
#                                                                                                                                                  #
#   их свойствах можно использовать классы FileInfo, DirectoryInfo и DriveInfo.                                                                    #
#                                                                                                                                                  #
#   - Класс Path позволяет получать подробную информацию о путях файловой системы,                                                                 #
#                                                                                                                                                  #
#   его следует использовать вместо ручного разбора путей.                                                                                         #
#                                                                                                                                                  #
#   - Для отслеживания изменений файловой системы, таких как добавление, удаление и                                                                #
#                                                                                                                                                  #
#   переименование файлов и папок, можно использовать класс FileSystemWatсher.                                                                     #
#                                                                                                                                                  #
#   - Класс File позволяет открывать, создавать, читать и записывать файлы целиком либо                                                            #
#                                                                                                                                                  #
#   по частям.                                                                                                                                     #
#                                                                                                                                                  #
#   - Класс FileStream представляет файл и позволяет выполнять чтение и запись.                                                                    #
#                                                                                                                                                  #
#   - Чтобы упростить чтение-запись строк в потоки, используются классы StreamReader и                                                             #
#                                                                                                                                                  #
#   StreamWriter.                                                                                                                                  #
#                                                                                                                                                  #
#   - Класс MemoryStream – специализированный поток, поддерживающий создание в памяти                                                              #
#                                                                                                                                                  #
#   буфера чтения-записи и запись данных буферизированного потока в другие потоки.                                                                 #
#                                                                                                                                                  #
#   - Классы потоков сжатия (GZipStream и DeflateStream) поддерживают сжатие-                                                                      #
#                                                                                                                                                  #
#   декомпрессию данных объемом до 4-х Гб.                                                                                                         #
#                                                                                                                                                  #
#   - Классы потоков сжатия служат оболочками потоков, хранящих сжатые данные.                                                                     #                                                                
####################################################################################################################################################


****************************************************************************************************************************************************
****************************************************************************************************************************************************
SELECT THE FILE NUMBER YOU WOULD LIKE TO READ: next
SELECT THE FILE NUMBER YOU WOULD LIKE TO ARCHIVE: 4
----------------------------------------------------------------------------------------------------------------------------------------------------
[1] - C:\Users\Serg\_2Method.zip
----------------------------------------------------------------------------------------------------------------------------------------------------
SELECT THE FILE NUMBER YOU WOULD LIKE TO ARCHIVE: read
SELECT THE FILE NUMBER YOU WOULD LIKE TO READ: 8
####################################################################################################################################################
#   kflk;l;lg;gl;glg;s                                                                                                                             #                                                                                                               
####################################################################################################################################################


****************************************************************************************************************************************************
****************************************************************************************************************************************************
SELECT THE FILE NUMBER YOU WOULD LIKE TO READ: next
SELECT THE FILE NUMBER YOU WOULD LIKE TO ARCHIVE: 8
----------------------------------------------------------------------------------------------------------------------------------------------------
[1] - D:\Jiayu\_2Method.zip
----------------------------------------------------------------------------------------------------------------------------------------------------
SELECT THE FILE NUMBER YOU WOULD LIKE TO ARCHIVE:
*/
