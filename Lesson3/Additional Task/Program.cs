using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Additional_Task
{
    /*Создайте на диске 100 директорий с именами от Folder_0 до Folder_99, затем удалите их.*/
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo catalogDirectiories = new DirectoryInfo(@"D:\Test\"); // Создаем экземпляр класса DirectoryInfo. Данный экземпляр предоставляет методы экземпляра класса для создания, перемещения и перечисления
                                                                                // в каталогах и подкаталогах.
            string[] nameDirectiry = new string[100];   // Создаем одномерный строковой массив с 100 элементами.
            Console.WriteLine("Creating a list of directories:".ToUpper());
            Console.WriteLine(new string('-', 30));
            for (int i = 0; i < 100; i++)   // Циклическая конструкция оператора for со счетчиком. Формируется подкаталог папок с именами Folder_0 до Folder_99
            {
                nameDirectiry[i] = @"Folder_" + i;   // Конкатенируем два значения вместе.
                Console.WriteLine("Create directory: {0}", catalogDirectiories.CreateSubdirectory(nameDirectiry[i]).FullName);  // Вызываем на экземпляре объекта catalogDirectiories метод для создания подкаталога. Выводим результат в консоли
            }
            Console.WriteLine(new string('-', 30));
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Press any key on the keyboard to delete the directories catalog:".ToUpper());
            Console.ReadKey();
            foreach (var item in nameDirectiry)   // Перебор массива с именами подкаталогов. Удаление каталога ранее созданых папок.
            {
                Directory.Delete(@"D:\Test\" + item);  // На классе-объекте Directory вызываем метод Delete. Метод позволяет удалить папку с заданным именем.
                Console.WriteLine("Delete directory: {0}", catalogDirectiories.FullName + item);  // Вызываем на экземпляре объекта catalogDirectiories свойство с полным названием пути основной папки. Выводим результат в консоли
            }
            //Задержка
            Console.ReadKey();
        }
    }
}

/*
CREATING A LIST OF DIRECTORIES:
------------------------------
Create directory: D:\Test\Folder_0
Create directory: D:\Test\Folder_1
Create directory: D:\Test\Folder_2
Create directory: D:\Test\Folder_3
Create directory: D:\Test\Folder_4
Create directory: D:\Test\Folder_5
Create directory: D:\Test\Folder_6
Create directory: D:\Test\Folder_7
Create directory: D:\Test\Folder_8
Create directory: D:\Test\Folder_9
Create directory: D:\Test\Folder_10
Create directory: D:\Test\Folder_11
Create directory: D:\Test\Folder_12
Create directory: D:\Test\Folder_13
Create directory: D:\Test\Folder_14
Create directory: D:\Test\Folder_15
Create directory: D:\Test\Folder_16
Create directory: D:\Test\Folder_17
Create directory: D:\Test\Folder_18
Create directory: D:\Test\Folder_19
Create directory: D:\Test\Folder_20
Create directory: D:\Test\Folder_21
Create directory: D:\Test\Folder_22
Create directory: D:\Test\Folder_23
Create directory: D:\Test\Folder_24
Create directory: D:\Test\Folder_25
Create directory: D:\Test\Folder_26
Create directory: D:\Test\Folder_27
Create directory: D:\Test\Folder_28
Create directory: D:\Test\Folder_29
Create directory: D:\Test\Folder_30
Create directory: D:\Test\Folder_31
Create directory: D:\Test\Folder_32
Create directory: D:\Test\Folder_33
Create directory: D:\Test\Folder_34
Create directory: D:\Test\Folder_35
Create directory: D:\Test\Folder_36
Create directory: D:\Test\Folder_37
Create directory: D:\Test\Folder_38
Create directory: D:\Test\Folder_39
Create directory: D:\Test\Folder_40
Create directory: D:\Test\Folder_41
Create directory: D:\Test\Folder_42
Create directory: D:\Test\Folder_43
Create directory: D:\Test\Folder_44
Create directory: D:\Test\Folder_45
Create directory: D:\Test\Folder_46
Create directory: D:\Test\Folder_47
Create directory: D:\Test\Folder_48
Create directory: D:\Test\Folder_49
Create directory: D:\Test\Folder_50
Create directory: D:\Test\Folder_51
Create directory: D:\Test\Folder_52
Create directory: D:\Test\Folder_53
Create directory: D:\Test\Folder_54
Create directory: D:\Test\Folder_55
Create directory: D:\Test\Folder_56
Create directory: D:\Test\Folder_57
Create directory: D:\Test\Folder_58
Create directory: D:\Test\Folder_59
Create directory: D:\Test\Folder_60
Create directory: D:\Test\Folder_61
Create directory: D:\Test\Folder_62
Create directory: D:\Test\Folder_63
Create directory: D:\Test\Folder_64
Create directory: D:\Test\Folder_65
Create directory: D:\Test\Folder_66
Create directory: D:\Test\Folder_67
Create directory: D:\Test\Folder_68
Create directory: D:\Test\Folder_69
Create directory: D:\Test\Folder_70
Create directory: D:\Test\Folder_71
Create directory: D:\Test\Folder_72
Create directory: D:\Test\Folder_73
Create directory: D:\Test\Folder_74
Create directory: D:\Test\Folder_75
Create directory: D:\Test\Folder_76
Create directory: D:\Test\Folder_77
Create directory: D:\Test\Folder_78
Create directory: D:\Test\Folder_79
Create directory: D:\Test\Folder_80
Create directory: D:\Test\Folder_81
Create directory: D:\Test\Folder_82
Create directory: D:\Test\Folder_83
Create directory: D:\Test\Folder_84
Create directory: D:\Test\Folder_85
Create directory: D:\Test\Folder_86
Create directory: D:\Test\Folder_87
Create directory: D:\Test\Folder_88
Create directory: D:\Test\Folder_89
Create directory: D:\Test\Folder_90
Create directory: D:\Test\Folder_91
Create directory: D:\Test\Folder_92
Create directory: D:\Test\Folder_93
Create directory: D:\Test\Folder_94
Create directory: D:\Test\Folder_95
Create directory: D:\Test\Folder_96
Create directory: D:\Test\Folder_97
Create directory: D:\Test\Folder_98
Create directory: D:\Test\Folder_99
------------------------------
------------------------------
PRESS ANY KEY ON THE KEYBOARD TO DELETE THE DIRECTORIES CATALOG:
Delete directory: D:\Test\Folder_0
Delete directory: D:\Test\Folder_1
Delete directory: D:\Test\Folder_2
Delete directory: D:\Test\Folder_3
Delete directory: D:\Test\Folder_4
Delete directory: D:\Test\Folder_5
Delete directory: D:\Test\Folder_6
Delete directory: D:\Test\Folder_7
Delete directory: D:\Test\Folder_8
Delete directory: D:\Test\Folder_9
Delete directory: D:\Test\Folder_10
Delete directory: D:\Test\Folder_11
Delete directory: D:\Test\Folder_12
Delete directory: D:\Test\Folder_13
Delete directory: D:\Test\Folder_14
Delete directory: D:\Test\Folder_15
Delete directory: D:\Test\Folder_16
Delete directory: D:\Test\Folder_17
Delete directory: D:\Test\Folder_18
Delete directory: D:\Test\Folder_19
Delete directory: D:\Test\Folder_20
Delete directory: D:\Test\Folder_21
Delete directory: D:\Test\Folder_22
Delete directory: D:\Test\Folder_23
Delete directory: D:\Test\Folder_24
Delete directory: D:\Test\Folder_25
Delete directory: D:\Test\Folder_26
Delete directory: D:\Test\Folder_27
Delete directory: D:\Test\Folder_28
Delete directory: D:\Test\Folder_29
Delete directory: D:\Test\Folder_30
Delete directory: D:\Test\Folder_31
Delete directory: D:\Test\Folder_32
Delete directory: D:\Test\Folder_33
Delete directory: D:\Test\Folder_34
Delete directory: D:\Test\Folder_35
Delete directory: D:\Test\Folder_36
Delete directory: D:\Test\Folder_37
Delete directory: D:\Test\Folder_38
Delete directory: D:\Test\Folder_39
Delete directory: D:\Test\Folder_40
Delete directory: D:\Test\Folder_41
Delete directory: D:\Test\Folder_42
Delete directory: D:\Test\Folder_43
Delete directory: D:\Test\Folder_44
Delete directory: D:\Test\Folder_45
Delete directory: D:\Test\Folder_46
Delete directory: D:\Test\Folder_47
Delete directory: D:\Test\Folder_48
Delete directory: D:\Test\Folder_49
Delete directory: D:\Test\Folder_50
Delete directory: D:\Test\Folder_51
Delete directory: D:\Test\Folder_52
Delete directory: D:\Test\Folder_53
Delete directory: D:\Test\Folder_54
Delete directory: D:\Test\Folder_55
Delete directory: D:\Test\Folder_56
Delete directory: D:\Test\Folder_57
Delete directory: D:\Test\Folder_58
Delete directory: D:\Test\Folder_59
Delete directory: D:\Test\Folder_60
Delete directory: D:\Test\Folder_61
Delete directory: D:\Test\Folder_62
Delete directory: D:\Test\Folder_63
Delete directory: D:\Test\Folder_64
Delete directory: D:\Test\Folder_65
Delete directory: D:\Test\Folder_66
Delete directory: D:\Test\Folder_67
Delete directory: D:\Test\Folder_68
Delete directory: D:\Test\Folder_69
Delete directory: D:\Test\Folder_70
Delete directory: D:\Test\Folder_71
Delete directory: D:\Test\Folder_72
Delete directory: D:\Test\Folder_73
Delete directory: D:\Test\Folder_74
Delete directory: D:\Test\Folder_75
Delete directory: D:\Test\Folder_76
Delete directory: D:\Test\Folder_77
Delete directory: D:\Test\Folder_78
Delete directory: D:\Test\Folder_79
Delete directory: D:\Test\Folder_80
Delete directory: D:\Test\Folder_81
Delete directory: D:\Test\Folder_82
Delete directory: D:\Test\Folder_83
Delete directory: D:\Test\Folder_84
Delete directory: D:\Test\Folder_85
Delete directory: D:\Test\Folder_86
Delete directory: D:\Test\Folder_87
Delete directory: D:\Test\Folder_88
Delete directory: D:\Test\Folder_89
Delete directory: D:\Test\Folder_90
Delete directory: D:\Test\Folder_91
Delete directory: D:\Test\Folder_92
Delete directory: D:\Test\Folder_93
Delete directory: D:\Test\Folder_94
Delete directory: D:\Test\Folder_95
Delete directory: D:\Test\Folder_96
Delete directory: D:\Test\Folder_97
Delete directory: D:\Test\Folder_98
Delete directory: D:\Test\Folder_99
 
*/
