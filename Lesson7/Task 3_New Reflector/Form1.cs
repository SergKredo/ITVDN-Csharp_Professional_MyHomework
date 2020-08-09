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
        Assembly assembly;
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

                    this.assembly = Assembly.LoadFrom(@path);
                }
            }
            catch (Exception)  // Исключение срабатывает в случае ошибки при открытии иной сборки, которая не потдерживается платформой .Net framework
            {
                string loadAssembly = new string(' ', 90) + "Failed assembly loading!".ToUpper();
                this.textBox1.Text = loadAssembly;
            }
        }

        private void button_Display_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = null;
            int a = 1; int b = 1; int c = 1; int d = 1; int f = 0;
            try
            {
                Type[] types = assembly.GetTypes();   // Вывод информации о всех типах в сборке с помощью абстрактного класса Type.
                string namespaces = null;
                string loadAssembly = new string(' ', 90) + "The assembly was loaded successfully!".ToUpper() + "\r\n\r\n";
                this.textBox1.Text += loadAssembly;
                foreach (Type item in types)    // Перебор всех типов
                {
                    f += 1;
                    bool Next = true;
                    this.textBox1.Text += (namespaces == null) ? "namespace " + item.Namespace + Environment.NewLine + "{" + Environment.NewLine : null;
                    namespaces = item.Namespace;
                    string padding = new string(' ', 5);

                    if (this.checkedListBox.CheckedIndices.Contains(14))   // Вывод информации об атрибутах типов
                    {
                        try
                        {
                            foreach (Attribute att in item.GetCustomAttributes(false))
                            {
                                this.textBox1.Text += padding + "[" + att + "]" + Environment.NewLine;
                            }
                        }
                        catch (Exception) { }

                    }
                    if (item.IsAbstract && this.checkedListBox.CheckedIndices.Contains(0) && Next)  // Проверка, является ли данный тип абстрактным классом
                    {
                        this.textBox1.Text += padding + "abstract class ";
                        Next = false;
                    }


                    if (item.IsValueType && this.checkedListBox.CheckedIndices.Contains(6))  // Проверка, является ли данный тип структурой
                    {
                        this.textBox1.Text += padding + "struct ";
                    }

                    if (item.IsEnum && this.checkedListBox.CheckedIndices.Contains(7))   // Проверка, является ли данный тип перечислением
                    {
                        padding = "";
                        this.textBox1.Text += padding + "enum ";
                        padding = new string(' ', 5);
                    }

                    if (item.IsInterface && this.checkedListBox.CheckedIndices.Contains(1))  // Проверка, является ли данный тип интерфейсом
                    {
                        this.textBox1.Text += padding + "interface ";
                    }

                    if (item.IsGenericType && this.checkedListBox.CheckedIndices.Contains(5) && Next)  // Проверка, является ли данный тип универсальным типом (generic)
                    {
                        this.textBox1.Text += padding + "generic class ";
                        Next = false;
                    }

                    if (item.IsNested && this.checkedListBox.CheckedIndices.Contains(4) && Next)  // Проверка, является ли данный тип вложенным класом
                    {
                        this.textBox1.Text += padding + "nested class ";
                        Next = false;
                    }

                    if (item.IsClass && this.checkedListBox.CheckedIndices.Contains(2) && Next)  // Проверка, является ли данный тип классом
                    {
                        this.textBox1.Text += padding + "(class/static class/delegate/event) ";
                        Next = false;
                    }

                    else if (item.IsClass && !this.checkedListBox.CheckedIndices.Contains(2) && this.checkedListBox.CheckedIndices.Contains(3) && Next)
                    {
                        this.textBox1.Text += padding + "(class/static class/delegate/event) ";
                        Next = false;
                    }
                    else if (item.IsClass && !this.checkedListBox.CheckedIndices.Contains(2) && this.checkedListBox.CheckedIndices.Contains(8) && Next)
                    {
                        this.textBox1.Text += padding + "(class/static class/delegate/event) ";
                        Next = false;
                    }
                    else if (item.IsClass && !this.checkedListBox.CheckedIndices.Contains(2) && this.checkedListBox.CheckedIndices.Contains(9) && Next)
                    {
                        this.textBox1.Text += padding + "(class/static class/delegate/event) ";
                        Next = false;
                    }

                    else if (this.checkedListBox.SelectedIndices.Count == 0)                                // Проверка, является ли данный тип статическим классом, делегатом, событием и т.д.
                    {
                        break;
                    }


                    this.textBox1.Text += item.Name + Environment.NewLine + padding + "{" + Environment.NewLine;

                    if (this.checkedListBox.CheckedIndices.Contains(12))
                    {
                        /*Перечисление BindingFlags может принимать различные значения:
                            DeclaredOnly: получает только методы непосредственно данного класса, унаследованные методы не извлекаются
                            Instance: получает только методы экземпляра
                            NonPublic: извлекает не публичные методы
                            Public: получает только публичные методы
                            Static: получает только статические методы
                        */
                        foreach (MethodInfo items in item.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))  // Перебор всех методов
                        {
                            if (a++ == 1)
                            {
                                padding = new string(' ', 10);
                                this.textBox1.Text += padding + "Methods:".ToUpper() + Environment.NewLine;
                            }
                            bool enter = true;
                            padding = new string(' ', 42);

                            if (this.checkedListBox.CheckedIndices.Contains(15))  // Вывод информации об атрибутах методов
                            {
                                try
                                {
                                    foreach (Attribute att in items.GetCustomAttributes(false))
                                    {
                                        padding = new string(' ', 42);
                                        this.textBox1.Text += padding + "[" + att + "]" + Environment.NewLine;
                                    }
                                }
                                catch (Exception) { }
                            }
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
                            this.textBox1.Text += ");" + Environment.NewLine + "\r\n";
                        }
                    }

                    if (this.checkedListBox.CheckedIndices.Contains(10))
                    {

                        // Перебор всех полей типа
                        foreach (var field in item.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            if (b++ == 1)
                            {
                                padding = new string(' ', 10);
                                this.textBox1.Text += padding + "Fields:".ToUpper() + Environment.NewLine;
                            }
                            bool enter = true;
                            padding = new string(' ', 42);

                            if (this.checkedListBox.CheckedIndices.Contains(15))  // Вывод информации об атрибутах полей
                            {
                                try
                                {
                                    foreach (Attribute att in field.GetCustomAttributes(false))
                                    {
                                        padding = new string(' ', 42);
                                        this.textBox1.Text += padding + "[" + att + "]" + Environment.NewLine;
                                    }
                                }
                                catch (Exception) { }
                            }
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
                            this.textBox1.Text += field.FieldType.Name + " " + field.Name + ";" + Environment.NewLine + "\r\n";
                        }
                    }

                    if (this.checkedListBox.CheckedIndices.Contains(11))
                    {
                        // Перебор всех свойств типа
                        foreach (var field in item.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            if (c++ == 1)
                            {
                                padding = new string(' ', 10);
                                this.textBox1.Text += padding + "Properties:".ToUpper() + Environment.NewLine;
                            }
                            bool enter = true;
                            padding = new string(' ', 42);

                            if (this.checkedListBox.CheckedIndices.Contains(15))  // Вывод информации об атрибутах свойств
                            {
                                try
                                {
                                    foreach (Attribute att in field.GetCustomAttributes(false))
                                    {
                                        padding = new string(' ', 42);
                                        this.textBox1.Text += padding + "[" + att + "]" + Environment.NewLine;
                                    }
                                }
                                catch (Exception) { }

                            }
                            this.textBox1.Text += padding + field.PropertyType.Name + " " + field.Name + ";" + Environment.NewLine + "\r\n";
                        }
                    }

                    if (this.checkedListBox.CheckedIndices.Contains(13))
                    {
                        // Перебор всех конструкторов типа
                        foreach (var field in item.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            if (d++ == 1)
                            {
                                padding = new string(' ', 10);
                                this.textBox1.Text += padding + "Constructors:".ToUpper() + Environment.NewLine;
                            }
                            bool enter = true;
                            padding = new string(' ', 42);

                            if (this.checkedListBox.CheckedIndices.Contains(15))   // Вывод информации об атрибутах конструкторов
                            {
                                try
                                {
                                    foreach (Attribute att in field.GetCustomAttributes(false))
                                    {
                                        padding = new string(' ', 42);
                                        this.textBox1.Text += padding + "[" + att + "]" + Environment.NewLine;
                                    }
                                }
                                catch (Exception) { }
                            }
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
                            this.textBox1.Text += ");" + Environment.NewLine + "\r\n";
                        }
                    }

                    a = b = c = d = 1;
                    if (this.checkedListBox.CheckedItems.Count != 0 && f != types.Length)
                    {
                        padding = new string(' ', 5);
                        this.textBox1.Text += padding + "}" + Environment.NewLine + "\r\n";
                    }
                    else if (this.checkedListBox.CheckedItems.Count == 0 && f != types.Length)
                    {
                        this.textBox1.Text += padding + "}" + Environment.NewLine + "\r\n";
                    }
                    else if (this.checkedListBox.CheckedItems.Count == 0 && f == types.Length)
                    {
                        this.textBox1.Text += padding + "}" + Environment.NewLine;
                    }
                    else
                    {
                        padding = new string(' ', 5);
                        this.textBox1.Text += padding + "}" + Environment.NewLine;
                    }
                }
                this.textBox1.Text += "}" + Environment.NewLine;
            }
            catch (Exception) { }
        }

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.checkedListBox.CheckedIndices.Contains(3) || this.checkedListBox.CheckedIndices.Contains(8) || this.checkedListBox.CheckedIndices.Contains(9))
            {
                this.checkedListBox.SetItemCheckState(2, CheckState.Indeterminate);
            }
            else if (!this.checkedListBox.CheckedIndices.Contains(3) && !this.checkedListBox.CheckedIndices.Contains(8) && !this.checkedListBox.CheckedIndices.Contains(9) && ((CheckedListBox)sender).SelectedItem == "Class")
            {
                if (!((CheckedListBox)sender).CheckedIndices.Contains(2))
                {
                    this.checkedListBox.SetItemCheckState(2, CheckState.Unchecked);
                }
                else
                {
                    this.checkedListBox.SetItemCheckState(2, CheckState.Checked);
                }
            }
            else if (this.checkedListBox.CheckedIndices.Contains(2) && (!((CheckedListBox)sender).CheckedIndices.Contains(3) || !((CheckedListBox)sender).CheckedIndices.Contains(8) || !((CheckedListBox)sender).CheckedIndices.Contains(9)))
            {
                switch (((CheckedListBox)sender).SelectedItem)
                {
                    case "Abstract Class":
                    case "Interface":
                    case "Nested Class":
                    case "Generics":
                    case "Struct":
                    case "Enum":
                    case "Field":
                    case "Property":
                    case "Method":
                    case "Constructor":
                    case "Type attribute information":
                    case "Type member attribute information":
                        {
                            this.checkedListBox.SetItemCheckState(2, CheckState.Checked);
                            break;
                        }
                    default:
                        {
                            this.checkedListBox.SetItemCheckState(2, CheckState.Unchecked);
                            break;
                        }

                }
            }
            else if (this.checkedListBox.CheckedIndices.Contains(2))
            {
                this.checkedListBox.SetItemCheckState(2, CheckState.Checked);
            }
            else
            {
                this.checkedListBox.SetItemCheckState(2, CheckState.Unchecked);
                this.checkedListBox.ClearSelected();
            }
            int count = this.checkedListBox.SelectedIndices.Count;
        }
    }
}
/*
 Results:
-----------------------------------------------------------------------------------------------------------------------------------
                                                   THE ASSEMBLY WAS LOADED SUCCESSFULLY!

namespace Additional_Task
{
     [System.AttributeUsageAttribute]
     (class/static class/delegate/event) AccessLevelAttribute
     {
          METHODS:
                                          public Void Access(Human human);

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          public virtual Int32 GetHashCode();

                                          public virtual Object get_TypeId();

                                          public virtual Boolean Match(Object obj);

                                          public virtual Boolean IsDefaultAttribute();

                                          private virtual Void System.Runtime.InteropServices._Attribute.GetTypeInfoCount(UInt32& pcTInfo);

                                          private virtual Void System.Runtime.InteropServices._Attribute.GetTypeInfo(UInt32 iTInfo, UInt32 lcid, IntPtr ppTInfo);

                                          private virtual Void System.Runtime.InteropServices._Attribute.GetIDsOfNames(Guid& riid, IntPtr rgszNames, UInt32 cNames, UInt32 lcid, IntPtr rgDispId);

                                          private virtual Void System.Runtime.InteropServices._Attribute.Invoke(UInt32 dispIdMember, Guid& riid, UInt32 lcid, Int16 wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          private Human human;

                                          private DateTime date;

                                          private StreamWriter writer;

                                          private AccessLevelControl accessLevel;

          PROPERTIES:
                                          Object TypeId;

          CONSTRUCTORS:
                                          public .ctor(AccessLevelControl accessLevelControl);

     }

     struct enum AccessLevelControl
     {
          METHODS:
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object GetValue();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

                                          [System.ObsoleteAttribute]
                                          public virtual String ToString(String format, IFormatProvider provider);

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 CompareTo(Object target);

                                          [System.ObsoleteAttribute]
                                          public virtual String ToString(IFormatProvider provider);

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Boolean HasFlag(Enum flag);

                                          public virtual TypeCode GetTypeCode();

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Boolean System.IConvertible.ToBoolean(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Char System.IConvertible.ToChar(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual SByte System.IConvertible.ToSByte(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Byte System.IConvertible.ToByte(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Int16 System.IConvertible.ToInt16(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual UInt16 System.IConvertible.ToUInt16(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Int32 System.IConvertible.ToInt32(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual UInt32 System.IConvertible.ToUInt32(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Int64 System.IConvertible.ToInt64(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual UInt64 System.IConvertible.ToUInt64(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Single System.IConvertible.ToSingle(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Double System.IConvertible.ToDouble(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Decimal System.IConvertible.ToDecimal(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual DateTime System.IConvertible.ToDateTime(IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          private virtual Object System.IConvertible.ToType(Type type, IFormatProvider provider);

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public String ToString(String format);

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

          FIELDS:
                                          public Int32 value__;

                                          public static AccessLevelControl FullControlforDirector;

                                          public static AccessLevelControl MiddleControlforManager;

                                          public static AccessLevelControl LowControlforProgrammer;

                                          public static AccessLevelControl AccessIsDenied;

     }

     [Additional_Task.AccessLevelAttribute]
     (class/static class/delegate/event) Director
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          public .ctor(String name, String lastName);

     }

     abstract class Human
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          private static Void InvokeAttribute(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          private OpenFileDialog openFileDialog;

                                          private Form TextBox;

                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          .ctor(String name, String lastName);

     }

     (class/static class/delegate/event) Manager
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          public .ctor(String name, String lastName);

     }

     (class/static class/delegate/event) Other
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          public .ctor(String name, String lastName);

     }

     (class/static class/delegate/event) Program
     {
          METHODS:
                                          [System.STAThreadAttribute]
                                          private static Void Main(String[] args);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          CONSTRUCTORS:
                                          public .ctor();

     }

     (class/static class/delegate/event) Programmer
     {
          METHODS:
                                          public Void OpenToBaseBankDate(Human human);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Boolean Equals(Object obj);

                                          [__DynamicallyInvokableAttribute]
                                          public virtual Int32 GetHashCode();

                                          [System.Runtime.ConstrainedExecution.ReliabilityContractAttribute]
                                          [System.Runtime.Versioning.NonVersionableAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          virtual Void Finalize();

                                          [System.Security.SecuritySafeCriticalAttribute]
                                          [__DynamicallyInvokableAttribute]
                                          public Type GetType();

                                          [__DynamicallyInvokableAttribute]
                                          [System.Security.SecuritySafeCriticalAttribute]
                                          Object MemberwiseClone();

                                          [__DynamicallyInvokableAttribute]
                                          public virtual String ToString();

          FIELDS:
                                          public String name;

                                          public String lastName;

          CONSTRUCTORS:
                                          public .ctor(String name, String lastName);

     }
}

 */
