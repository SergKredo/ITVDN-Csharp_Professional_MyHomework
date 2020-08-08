using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Task_3_New_Reflector
{
    /*
         Расширьте возможности программы-рефлектора из предыдущего урока следующим образом:
    1. Добавьте возможность выбирать, какие именно члены типа должны быть показаны
    пользователю. При этом должна быть возможность выбирать сразу несколько членов
    типа, например, методы и свойства.
    2. Добавьте возможность вывода информации об атрибутах для типов и всех членов типа,
    которые могут быть декорированы атрибутами.
     */
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)   // Метод-обработчик события срабатывает при нажатии на кнопку "Save file..."
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)  // Диалоговое окно для сохранения текущей информации из приложения в текстовый файл
            {
                string path = openFileDialog.FileName;   // Путь сохранения
                File.WriteAllText(@path, this.textBox1.Text, Encoding.UTF8);  // Запись текущей информации из приложения в файл
            }
        }

        private void button_Search_Click(object sender, EventArgs e)  // Метод-обработчик события срабатывает при нажатии на кнопку "Open file..."
        {
            try
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)  // Проверка на условие нажатия пользователем кнопки "OK"в открывшемся диаголовом окне
                {
                    this.textBox1.Text = null;
                    string path = openFileDialog.FileName;  // Строка полного адресного пути загружаемой нами сборки (exe, dll).
                    this.browser.Text = @path;


                    // При помощи класса Assembly - можно динамически загружать сборки, 
                    // обращаться к членам класса в процессе выполнения (ПОЗДНЕЕ СВЯЗЫВАНИЕ),
                    // а так же получать информацию о самой сборке.

                    Assembly assembly = Assembly.LoadFrom(@path);
                    Type[] types = assembly.GetTypes();   // Вывод информации о всех типах в сборке с помощью абстрактного класса Type.
                    string namespaces = null;
                    string loadAssembly = new string(' ', 90) + "The assembly was loaded successfully!".ToUpper() + "\r\n\r\n";
                    this.textBox1.Text += loadAssembly;
                    foreach (Type item in types)    // Перебор всех типов
                    {
                        this.textBox1.Text += (namespaces == null) ? "namespace " + item.Namespace + Environment.NewLine + "{" + Environment.NewLine : null;
                        namespaces = item.Namespace;
                        string padding = new string(' ', 5);
                        if (item.IsClass)  // Проверка, является ли данный тип классом
                        {
                            this.textBox1.Text += padding + "class ";
                        }

                        if (item.IsValueType)  // Проверка, является ли данный тип структурой
                        {
                            this.textBox1.Text += padding + "struct ";
                        }

                        if (item.IsEnum)   // Проверка, является ли данный тип перечислением
                        {
                            padding = "";
                            this.textBox1.Text += padding + "enum ";
                            padding = new string(' ', 5);
                        }

                        if (item.IsInterface)  // Проверка, является ли данный тип интерфейсом
                        {
                            this.textBox1.Text += padding + "interface ";
                        }


                        this.textBox1.Text += item.Name + Environment.NewLine + padding + "{" + Environment.NewLine;

                        padding = new string(' ', 10);
                        this.textBox1.Text += padding + "Methods:".ToUpper() + Environment.NewLine;


                        /*Перечисление BindingFlags может принимать различные значения:
                            DeclaredOnly: получает только методы непосредственно данного класса, унаследованные методы не извлекаются
                            Instance: получает только методы экземпляра
                            NonPublic: извлекает не публичные методы
                            Public: получает только публичные методы
                            Static: получает только статические методы
                        */
                        foreach (MethodInfo items in item.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))  // Перебор всех методов
                        {
                            bool enter = true;
                            padding = new string(' ', 42);
                            if (items.IsPublic)   // Проверка, является ли данный метод открытым
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "public ";
                            }

                            if (items.IsPrivate)  // Проверка, является ли данный метод закрытым
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "private ";
                            }

                            if (items.IsStatic)  // Проверка, является ли данный метод статическим
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "static ";
                            }

                            if (items.IsAbstract)  // Проверка, является ли данный метод абстрактным
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "abstract ";
                            }

                            if (items.IsVirtual)  // Проверка, является ли данный метод виртуальным
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "virtual ";
                            }
                            if (enter)
                            {
                                this.textBox1.Text += padding;
                            }

                            this.textBox1.Text += items.ReturnType.Name + " " + items.Name + "(";


                            ParameterInfo[] parameters = items.GetParameters();  // Определение параметров заданного метода
                            string text = null;
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                this.textBox1.Text += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                                text += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                                if (i + 1 < parameters.Length)
                                {
                                    this.textBox1.Text += ", ";
                                    text += ", ";
                                }
                            }
                            this.textBox1.Text += ");" + Environment.NewLine;
                        }


                        padding = new string(' ', 10);
                        this.textBox1.Text += padding + "Fields:".ToUpper() + Environment.NewLine;

                        // Перебор всех полей типа
                        foreach (var field in item.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            bool enter = true;
                            padding = new string(' ', 42);
                            if (field.IsPublic)  // Проверка, является ли данное поле открытым
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "public ";
                            }

                            if (field.IsPrivate)  // Проверка, является ли данное поле закрытым
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "private ";
                            }

                            if (field.IsStatic)  // Проверка, является ли данное поле статическим
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "static ";
                            }
                            if (enter)
                            {
                                this.textBox1.Text += padding;
                            }
                            this.textBox1.Text += field.FieldType.Name + " " + field.Name + ";" + Environment.NewLine;
                        }

                        // Перебор всех свойств типа
                        padding = new string(' ', 10);
                        this.textBox1.Text += padding + "Properties:".ToUpper() + Environment.NewLine;
                        foreach (var field in item.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            bool enter = true;
                            padding = new string(' ', 42);
                            this.textBox1.Text += padding;

                            this.textBox1.Text += field.PropertyType.Name + " " + field.Name + ";" + Environment.NewLine;
                        }

                        // Перебор всех конструкторов типа
                        padding = new string(' ', 10);
                        this.textBox1.Text += padding + "Constructors:".ToUpper() + Environment.NewLine;
                        foreach (var field in item.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            bool enter = true;
                            padding = new string(' ', 42);
                            if (field.IsPublic)  // Проверка, является ли данный конструктор открытым
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "public ";
                            }

                            if (field.IsPrivate)  // Проверка, является ли данный конструктор закрытым
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "private ";
                            }

                            if (field.IsStatic)  // Проверка, является ли данный конструктор статическим
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "static ";
                            }

                            if (enter)
                            {
                                this.textBox1.Text += padding;
                            }

                            this.textBox1.Text += field.Name + "(";

                            // Определение параметров заданного конструктора
                            ParameterInfo[] parameters = field.GetParameters();
                            string text = null;
                            for (int i = 0; i < parameters.Length; i++)
                            {
                                this.textBox1.Text += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                                text += parameters[i].ParameterType.Name + " " + parameters[i].Name;
                                if (i + 1 < parameters.Length)
                                {
                                    this.textBox1.Text += ", ";
                                    text += ", ";
                                }
                            }
                            this.textBox1.Text += ");" + Environment.NewLine;
                        }


                        padding = new string(' ', 5);
                        this.textBox1.Text += padding + "}" + Environment.NewLine + "\r\n";

                    }
                    this.textBox1.Text += "}" + Environment.NewLine;
                }
            }
            catch (Exception)  // Исключение срабатывает в случае ошибки при открытии иной сборки, которая не потдерживается платформой .Net framework
            {
                string loadAssembly = new string(' ', 90) + "Failed assembly loading!".ToUpper();
                this.textBox1.Text = loadAssembly;
            }
        }
    }
}
