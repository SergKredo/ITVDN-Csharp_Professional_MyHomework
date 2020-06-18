using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Additional_Task
{
    /*Напишите консольное приложение, позволяющие пользователю зарегистрироваться под
«Логином», состоящем только из символов латинского алфавита, и пароля, состоящего из
цифр и символов.*/

    class UserAccount    // Класс определяет шаблон создания нового аккаунта пользователя
    {
        public string Login { set; get; }  // Автосвойство, определяет логин пользователя

        public string Password { set; get; } // Автосвойство, определяет пароль пользователя


        public UserAccount(string login, string password)  // Пользовательский конструктор с двумя параметрами
        {
            this.Login = login;  // Инициализация свойства - логина
            this.Password = password;  // Инициализация свойства - пароль
            bool log = CreateLogin(this.Login);
            bool pas = CreatePassword(this.Password);
            if (log && pas)  // Вход в условную конструкцию, в результате успешного заполнения логина и пароля пользователя
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Congratulations! You have successfully created your account!");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        bool CreateLogin(string login)
        {
            string template = @"^[a-zA-Z]+$";  // Шаблон поиска регулярных выражений. Данный шаблон определяет символы по которым будет происходить проверка в строке.
            Regex regex = new Regex(template);  // Создаем экземпляр объекта типа Regexи передаем в качестве аргумента конструктора наш шаблон поиска
            bool log = regex.IsMatch(login);   // Проверка соответствия строки шаблону. 

            // Метод IsMatch - сравнивает принимаемую в первом параметре строку с шаблоном. 
            // IsMatch - метод возвращающий bool. True - в случае, если шаблон соответсвует строке, false - в противном случае. 
            if (!log)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered the wrong login format!\nYour login should consist only of Latin characters!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Beep();
            }
            return log;
        }
        bool CreatePassword(string password)
        {
            /* 
                \d    Определяет символы цифр. 
                \D 	Определяет любой символ, который не является цифрой. 
                \w 	Определяет любой символ цифры, буквы или подчеркивания. 
                \W    Определяет любой символ, который не является цифрой, буквой или подчеркиванием. 
                \s 	Определяет любой непечатный символ, включая пробел. 
                \S 	Определяет любой символ, кроме символов табуляции, новой строки и возврата каретки.
                .    Определяет любой символ кроме символа новой строки. 
                \.    Определяет символ точки.

               КВАНТИФИКАТОРЫ - это символы которые определяют, где и сколько раз необходимое вхождение символов может встречаться.
               ^ - c начала строки. 
               $ - с конца строки. 
               + - одно и более вхождений подшаблона в строке. 
            */
            string template = @"^\S+$";
            Regex regex = new Regex(template);
            bool log = regex.IsMatch(password);
            if (!log)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have entered the wrong password format!\nYour password should consist only of numbers and symbols!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Beep();
            }
            return log;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            while (true)  // Создаем бесконечный цикл
            {
                StringBuilder builder = new StringBuilder();   // Создаем экземпляр класса StringBuilder. Данный класс предоставляет изменяемую строку символов.
                builder.AppendFormat("User Account:\n".ToUpper());  // Добавляет к данному экземпляру строку, возвращаемую в результате обработки строки
                                                                    //     составного формата, содержащей ноль или более элементов формата. Каждый элемент
                                                                    //     формата заменяется строковым представлением одного аргумента.
                builder.Append(new string('-', 60) + "\n");
                builder.Append("Login: ");
                Console.Write(builder);
                string login = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();
                UserAccount userAccount = new UserAccount(login, password); // Создаем экземпляр класса UserAccount. Передаем в конструктор класса два аргумента с введенными пользователем значений логина и пароля
                Console.WriteLine(new string('-', 60));
                Console.WriteLine(new string('-', 60));
            }
        }
    }
}
/*
 Result:

    USER ACCOUNT:
------------------------------------------------------------
Login: SergeyKredentser
Password: HelloITVDN2020
Congratulations! You have successfully created your account!
------------------------------------------------------------
------------------------------------------------------------
USER ACCOUNT:
------------------------------------------------------------
Login: 2020Serg
Password: 1245ITVDN++
You have entered the wrong login format!
Your login should consist only of Latin characters!
------------------------------------------------------------
------------------------------------------------------------
USER ACCOUNT:
------------------------------------------------------------
Login: SergioKredentser
Password: 123jh jkjfkf-==
You have entered the wrong password format!
Your password should consist only of numbers and symbols!
------------------------------------------------------------
------------------------------------------------------------
USER ACCOUNT:
------------------------------------------------------------
Login: Sergio90
Password: lkfjkjk       jkfjkfjf
You have entered the wrong login format!
Your login should consist only of Latin characters!
You have entered the wrong password format!
Your password should consist only of numbers and symbols!
------------------------------------------------------------
------------------------------------------------------------
USER ACCOUNT:
------------------------------------------------------------
Login:
     */
