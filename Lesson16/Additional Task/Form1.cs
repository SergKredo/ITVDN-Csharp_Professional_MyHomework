using System;
using System.IO;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Additional_Task
{
    /*
         Создайте приложение WindowsForms, которое позволит безопасно запускать сборки. В
    интерфейсе предусмотрите возможность выбора ограничения привилегий для запускаемой
    сборки.
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)  // Запуск диалогового окна и выбор файла сборки исполняемого файла
            {
                this.textBox1.Text = openFileDialog1.SafeFileName; // Имя файла не включает полный путь
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var setup = new AppDomainSetup { ApplicationBase = Path.GetFullPath(Application.ExecutablePath) };  // Создаем объект типа AppDomainSetup и формируем имя каталога содержащего приложение

            // Настраиваем права для  AppDomain. Даем разрешение на выполнение кода.
            // Список прав : http://msdn.microsoft.com/ru-ru/library/24ed02w7.aspx
            var permiss = new PermissionSet(PermissionState.None);  // Разрешение к доступу ресурса, запрещен
            permiss.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));  // Устанавливаем разрешение на запуск кода. Без разрешения Execution не может быть выполнен запуск кода
            permiss.AddPermission(new FileIOPermission(FileIOPermissionAccess.AllAccess, "c:\\"));  // Устанавливаем уровень доступа к файловой системе
            permiss.AddPermission(new UIPermission(UIPermissionWindow.AllWindows, UIPermissionClipboard.AllClipboard));  // Устанавливаем уровень доступа к окнам и событиям пользовательского ввода, буферу обмена 

            var trustAssembly = typeof(Form1).Assembly.Evidence.GetHostEvidence<StrongName>();

            // Создание второго домена приложения.
            var myDomain = AppDomain.CreateDomain("MyDomainApp", null, setup, permiss, trustAssembly); //Новый домен приложения с использованием заданного имени, свидетельства,
           //     сведений об установке домена приложения, используемого по умолчанию набора разрешений
           //     и массива сборок с полным доверием.
           myDomain.ExecuteAssembly(openFileDialog1.FileName);     // Выполнение заданной сборки в домене. В качестве возвращаего значения служит значение возвращаемое точкой входа сборки.    
        }
    }
}
