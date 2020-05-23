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

            TimeSpan time;
            DateTime timeINStart, timeIN, timeOut;
            string fullName = null;
            DriveInfo[] drivers = DriveInfo.GetDrives();
            timeINStart = DateTime.Now;
            timeIN = DateTime.Now;

            foreach (var item in drivers)
            {
                DirectoryInfo searchFiels = new DirectoryInfo(@item.RootDirectory.FullName);
                FileInfo[] filesThour = searchFiels.GetFiles("Proton.txt", SearchOption.TopDirectoryOnly);
                if (filesThour.Length != 0)
                {
                    timeOut = DateTime.Now;
                    time = timeOut - timeIN;
                    timeIN = timeOut;
                    Console.WriteLine(filesThour[0].FullName + " " + "Time = {0} sec", time.Seconds);
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
                                        FileInfo[] files = itemFive.GetFiles("Proton.txt", SearchOption.AllDirectories);
                                        if (files.Length != 0)
                                        {
                                            timeOut = DateTime.Now;
                                            time = timeOut - timeIN;
                                            timeIN = timeOut;
                                            fullName = files[0].FullName;
                                            Console.WriteLine(files[0].FullName + " " + "Time = {0} sec", time.Seconds);
                                        }
                                    }
                                    catch (Exception) { }

                                    string nameDirectoryss = itemFive.FullName;
                                    DirectoryInfo searchOness = new DirectoryInfo(@nameDirectoryss);
                                    try
                                    {
                                        FileInfo[] filesTHreesss = searchOness.GetFiles("Proton.txt", SearchOption.TopDirectoryOnly);
                                        if (filesTHreesss.Length != 0)
                                        {
                                            if (fullName == filesTHreesss[0].FullName)
                                            {
                                                continue;
                                            }
                                            timeOut = DateTime.Now;
                                            time = timeOut - timeIN;
                                            timeIN = timeOut;
                                            Console.WriteLine(filesTHreesss[0].FullName + " " + "Time = {0} sec", time.Seconds);
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
                                FileInfo[] filesTHreessss = searchOnesss.GetFiles("Proton.txt", SearchOption.TopDirectoryOnly);
                                if (filesTHreessss.Length != 0)
                                {
                                    timeOut = DateTime.Now;
                                    time = timeOut - timeIN;
                                    timeIN = timeOut;
                                    Console.WriteLine(filesTHreessss[0].FullName + " " + "Time = {0} sec", time.Seconds);
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
                        FileInfo[] filesTHreesh = searchOnes.GetFiles("Proton.txt", SearchOption.TopDirectoryOnly);
                        if (filesTHreesh.Length != 0)
                        {
                            timeOut = DateTime.Now;
                            time = timeOut - timeIN;
                            timeIN = timeOut;
                            Console.WriteLine(filesTHreesh[0].FullName + " " + "Time = {0} sec", time.Seconds);
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

           
            timeOut = DateTime.Now;
            time = timeOut - timeINStart;
            Console.WriteLine("Total time = {0} sec", time.Seconds);
            Console.ReadKey();
        }
    }
}
