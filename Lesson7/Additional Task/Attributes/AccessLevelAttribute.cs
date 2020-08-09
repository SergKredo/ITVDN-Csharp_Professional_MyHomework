using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Additional_Task
{
    // Для создания атрибута необходимо создать класс производный от класса : System.Attribute.
    // Атрибут - [AttributeUsage] - задает свойства пользовательских атрибутов.
    // Позиционный параметр - AttributeTargets, определяет элементы программы, 
    // для которых атрибут может быть применен.
    // Параметр - AttributeTargets.All - позволяет использовать атрибут - MyAttribute, 
    // для любого элемента.
    // Именованный параметр - AllowMultiple = false, определяет сколько раз к одному элементу 
    // можно применять атрибут.
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    class AccessLevelAttribute : Attribute
    {
        // Именованные параметры задаются открытыми нестатическими полями или свойствами, класса атрибута.
        Human human;  // Объявление экземпляра базового абстрактного класса Human
        DateTime date;  // Время, когда пользователь выполняет запрос в системе
        StreamWriter writer;  // Объект реализует TextWriter для записи символов в поток в определенной кодировке
        AccessLevelControl accessLevel;

        // Позиционные параметры задаются формальными параметрами - public конструктора, класса атрибута.
        public AccessLevelAttribute(AccessLevelControl accessLevelControl)  // Инициализация полей в конструкторе
        {
            this.accessLevel = accessLevelControl;
            date = DateTime.Now;
            FileInfo file = new FileInfo("Accounting record.dat");  // Открываем файловый поток
            writer = file.AppendText();
        }

        public void Access(Human human)  // Метод проверяет доступ пользователя к банковской базе данных компании
        {
            switch (accessLevel)
            {
                case AccessLevelControl.MiddleControlforManager:
                    {
                        writer.WriteLine(date + "\r\n");
                        writer.WriteLine("An employee {0} {1} with the 'manager' access level tried to access the company's bank database.\r\n", human.name, human.lastName);
                        writer.Close();
                        break;
                    }
                case AccessLevelControl.LowControlforProgrammer:
                    {
                        writer.WriteLine(date + "\r\n");
                        writer.WriteLine("An employee {0} {1} with the 'programmer' access level tried to access the company's bank database.\r\n", human.name, human.lastName);
                        writer.Close();
                        break;
                    }
                case AccessLevelControl.FullControlforDirector:
                    {
                        writer.WriteLine(date + "\r\n");
                        writer.WriteLine("An employee {0} {1} with the 'director' access level has successfully accessed the company's bank database.\r\n", human.name, human.lastName);
                        writer.Close();
                        break;
                    }
                default:
                    {
                        writer.WriteLine(date + "\r\n");
                        writer.WriteLine("Sided man with 'an unidentified user' access level tried to gain access to banking database company.\r\n");
                        writer.Close();
                        break;
                    }
            }
        }
    }

    enum AccessLevelControl   // Перечисление, которое задает параметры доступа к базе данных компании
    {
        FullControlforDirector, MiddleControlforManager, LowControlforProgrammer, AccessIsDenied
    }
}
