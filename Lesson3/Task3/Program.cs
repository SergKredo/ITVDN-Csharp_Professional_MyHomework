using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Task3
{
    /*Задание 3
Напишите приложение для поиска заданного файла на диске. Добавьте код, использующий
класс FileStream и позволяющий просматривать файл в текстовом окне. В заключение
добавьте возможность сжатия найденного файла.*/

    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            List<string> list = new List<string>();

            Console.Write("Enter a file name to search: ".ToUpper());
            Console.ForegroundColor = ConsoleColor.Yellow;
            string nameFile = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(new string('-', 148));
            float timeSpan;
            long timeIN, timeOut;
            int countFiles = 0;
            string fullName = null;
            DriveInfo[] drivers = DriveInfo.GetDrives();
            timeIN = DateTime.Now.Ticks;

            foreach (var item in drivers)
            {
                DirectoryInfo searchFiels = new DirectoryInfo(@item.RootDirectory.FullName);
                FileInfo[] filesThour = searchFiels.GetFiles(@nameFile, SearchOption.TopDirectoryOnly);
                if (filesThour.Length != 0)
                {
                    list.Add(filesThour[0].FullName);
                    Console.WriteLine("[{0}] - " + filesThour[0].FullName, ++countFiles);
                }

                DirectoryInfo[] filesOne = searchFiels.GetDirectories();

                foreach (var items in filesOne)
                {
                    try
                    {
                        string nameDirectory = items.FullName;
                        DirectoryInfo searchOne = new DirectoryInfo(@nameDirectory);
                        DirectoryInfo[] filesTwo = searchOne.GetDirectories();
                        foreach (var itemTwo in filesTwo)
                        {
                            try
                            {
                                string nameDirectoryh = itemTwo.FullName;
                                DirectoryInfo searchOneh = new DirectoryInfo(nameDirectoryh);
                                var filesFive = searchOneh.GetDirectories();
                                foreach (var itemFive in filesFive)
                                {
                                    try
                                    {
                                        FileInfo[] files = itemFive.GetFiles(@nameFile, SearchOption.AllDirectories);
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
                                        FileInfo[] filesTHreesss = searchOness.GetFiles(@nameFile, SearchOption.TopDirectoryOnly);
                                        if (filesTHreesss.Length != 0)
                                        {
                                            if (fullName == filesTHreesss[0].FullName)
                                            {
                                                continue;
                                            }
                                            list.Add(filesTHreesss[0].FullName);
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

            Console.WriteLine(new string('-', 148));
            timeOut = DateTime.Now.Ticks;
            timeSpan = timeOut - timeIN;
            Console.WriteLine("Number of files: {0}", countFiles);
            Console.WriteLine("Search time = {0} sec\n", timeSpan / 10000000);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('*', 148));
            Console.WriteLine(new string('*', 148));
            Console.ForegroundColor = ConsoleColor.Gray;


            while (true)
            {
                Console.Write("Select the file number you would like to read: ");
                int numberOfFile = Convert.ToInt32(Console.ReadLine());    // Указание в консоли адресной строки к файлу
                string pathFile = list[--numberOfFile];

                FileStream fileOpen = File.OpenRead(@pathFile);     // Создание потока для чтения данных из файла
                StreamReader reader = new StreamReader(fileOpen, Encoding.Default);  // Класс StreamReader используется для чтения строк из потока
                int numberLiterals = reader.ReadToEnd().Length;
                fileOpen.Position = 0;
                string text = reader.ReadToEnd();
                List<char> literals = new List<char>();
                for (int i = 0; i < numberLiterals; i++)
                {
                    literals.Add(text[i]);
                }

                int numberLines = 1;
                if (numberLiterals > 140)
                {
                    numberLines += numberLiterals / 140;
                }

                Encoding code = Encoding.Default;
                byte[] sym = new byte[256];
                for (int i = 0; i < 256; i++)
                {
                    sym[i] = (byte)i;
                }
                char[] chart = new char[256];
                chart = code.GetChars(sym);

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
                    for (int k = j; k < length; k++)
                    {

                        if (literals.Count - 1 < k)
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

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(new string('*', 148));
                Console.WriteLine(new string('*', 148));
                Console.ForegroundColor = ConsoleColor.Gray;
            }


            Console.ReadKey();

        }
    }
}
