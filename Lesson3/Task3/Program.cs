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

            DriveInfo[] drivers = DriveInfo.GetDrives();
            foreach (var item in drivers)
            {
                DirectoryInfo searchFiels = new DirectoryInfo(@item.RootDirectory.FullName);
                FileSystemInfo[] filesOne = searchFiels.GetDirectories();

                foreach (var items in filesOne)
                {
                    try
                    {
                        string nameDirectory = items.FullName;
                        DirectoryInfo searchOne = new DirectoryInfo(@nameDirectory);
                        FileInfo[] files = searchOne.GetFiles("Proton.txt", SearchOption.AllDirectories);
                        if (files.Length != 0)
                        {
                            Console.WriteLine(files[0].FullName);
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
                filesOne = searchFiels.GetFiles("Proton.txt", SearchOption.TopDirectoryOnly);
                if (filesOne.Length != 0)
                {
                    Console.WriteLine(filesOne[0].FullName);
                }
            }
            Console.ReadKey();
        }
    }
}
