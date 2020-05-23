using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Task3_add
{
    /*Задание 3
Напишите приложение для поиска заданного файла на диске. Добавьте код, использующий
класс FileStream и позволяющий просматривать файл в текстовом окне. В заключение
добавьте возможность сжатия найденного файла.*/

    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter a file name to search: ".ToUpper());
            string nameFile = Console.ReadLine();
            Console.WriteLine(new string('-', 100));
            float timeSpan;
            long timeIN, timeOut;
            int countFiles = 0;
            string fullName = null;
            DriveInfo[] drivers = DriveInfo.GetDrives();
            timeIN = DateTime.Now.Ticks;

            foreach (var item in drivers)
            {
                DirectoryInfo searchFiels = new DirectoryInfo(@item.RootDirectory.FullName);
                DirectoryInfo[] filesOne = searchFiels.GetDirectories();
                foreach (var itemM in filesOne)
                {
                    FileInfo[] filesThour = itemM.GetFiles();
                    foreach (var itemI in filesThour)
                    {
                        if (itemI.Name == nameFile)
                        {
                            Console.WriteLine("[{0}] - " + filesThour[0].FullName, ++countFiles);
                        }
                    }
                }


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
                            Console.WriteLine("[{0}] - " + filesTHreesh[0].FullName, ++countFiles);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine(new string('-', 100));
            timeOut = DateTime.Now.Ticks;
            timeSpan = timeOut - timeIN;
            Console.WriteLine("Number of files: {0}", countFiles);
            Console.WriteLine("Search time = {0} sec", timeSpan / 10000000);
            Console.ReadKey();
        }
    }
}
