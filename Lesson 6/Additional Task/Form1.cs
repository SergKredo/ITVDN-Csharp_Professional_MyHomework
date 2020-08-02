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



/*
 Создайте программу-рефлектор, которая позволит получить информацию о сборке и входящих
 в ее состав типах.
 */
namespace Additional_Task
{
    public partial class TextBox : Form
    {
        public TextBox()
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

/*
 Results:
---------------------------------------------------------------------------------------------------------------------------------------
                                                                                          THE ASSEMBLY WAS LOADED SUCCESSFULLY!

namespace Sample
{
     interface IMe
     {
          METHODS:
                                          public abstract virtual String Hello(String a, Byte d);
                                          public abstract virtual Void Proter();
          FIELDS:
          PROPERTIES:
          CONSTRUCTORS:
     }

     class Sample
     {
          METHODS:
                                          private Double[] get_Count();
                                          private Void set_Count(Double[] value);
                                          public virtual Void Save();
                                          public abstract virtual String MyMethod();
                                          public virtual String Hello(String a, Byte b);
                                          public virtual Void Proter();
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
                                          private Double[] <Count>k__BackingField;
          PROPERTIES:
                                          Double[] Count;
          CONSTRUCTORS:
                                          .ctor();
     }

     struct enum Enum
     {
          METHODS:
                                          Object GetValue();
                                          public virtual Int32 GetHashCode();
                                          public virtual String ToString();
                                          public virtual String ToString(String format, IFormatProvider provider);
                                          public virtual Int32 CompareTo(Object target);
                                          public virtual String ToString(IFormatProvider provider);
                                          public Boolean HasFlag(Enum flag);
                                          public virtual TypeCode GetTypeCode();
                                          private virtual Boolean System.IConvertible.ToBoolean(IFormatProvider provider);
                                          private virtual Char System.IConvertible.ToChar(IFormatProvider provider);
                                          private virtual SByte System.IConvertible.ToSByte(IFormatProvider provider);
                                          private virtual Byte System.IConvertible.ToByte(IFormatProvider provider);
                                          private virtual Int16 System.IConvertible.ToInt16(IFormatProvider provider);
                                          private virtual UInt16 System.IConvertible.ToUInt16(IFormatProvider provider);
                                          private virtual Int32 System.IConvertible.ToInt32(IFormatProvider provider);
                                          private virtual UInt32 System.IConvertible.ToUInt32(IFormatProvider provider);
                                          private virtual Int64 System.IConvertible.ToInt64(IFormatProvider provider);
                                          private virtual UInt64 System.IConvertible.ToUInt64(IFormatProvider provider);
                                          private virtual Single System.IConvertible.ToSingle(IFormatProvider provider);
                                          private virtual Double System.IConvertible.ToDouble(IFormatProvider provider);
                                          private virtual Decimal System.IConvertible.ToDecimal(IFormatProvider provider);
                                          private virtual DateTime System.IConvertible.ToDateTime(IFormatProvider provider);
                                          private virtual Object System.IConvertible.ToType(Type type, IFormatProvider provider);
                                          public virtual Boolean Equals(Object obj);
                                          public String ToString(String format);
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
          FIELDS:
                                          public Int32 value__;
                                          public static Enum First;
                                          public static Enum Second;
          PROPERTIES:
          CONSTRUCTORS:
     }

     struct Metro
     {
          METHODS:
                                          public Int32 get_Age();
                                          private Void Mehhh();
                                          public virtual Boolean Equals(Object obj);
                                          public virtual String ToString();
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
          FIELDS:
                                          private Int32 <Age>k__BackingField;
                                          private String Name;
          PROPERTIES:
                                          Int32 Age;
          CONSTRUCTORS:
     }

     class Metrohod
     {
          METHODS:
                                          private static Byte[] Loops();
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
          PROPERTIES:
          CONSTRUCTORS:
                                          private static .cctor();
     }

     class MyClass`2
     {
          METHODS:
                                          private Void Krot(T a, P b);
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
          PROPERTIES:
          CONSTRUCTORS:
                                          public .ctor();
     }

     class MyDelegate
     {
          METHODS:
                                          public virtual Void Invoke();
                                          public virtual IAsyncResult BeginInvoke(AsyncCallback callback, Object object);
                                          public virtual Void EndInvoke(IAsyncResult result);
                                          Boolean IsUnmanagedFunctionPtr();
                                          Boolean InvocationListLogicallyNull();
                                          public virtual Void GetObjectData(SerializationInfo info, StreamingContext context);
                                          public virtual Boolean Equals(Object obj);
                                          MulticastDelegate NewMulticastDelegate(Object[] invocationList, Int32 invocationCount);
                                          Void StoreDynamicMethod(MethodInfo dynamicMethod);
                                          virtual Delegate CombineImpl(Delegate follow);
                                          virtual Delegate RemoveImpl(Delegate value);
                                          public virtual Delegate[] GetInvocationList();
                                          public virtual Int32 GetHashCode();
                                          virtual Object GetTarget();
                                          virtual MethodInfo GetMethodImpl();
                                          public Object DynamicInvoke(Object[] args);
                                          virtual Object DynamicInvokeImpl(Object[] args);
                                          public MethodInfo get_Method();
                                          public Object get_Target();
                                          public virtual Object Clone();
                                          IntPtr GetCallStub(IntPtr methodPtr);
                                          IntPtr GetMulticastInvoke();
                                          IntPtr GetInvokeMethod();
                                          IRuntimeMethodInfo FindMethodHandle();
                                          IntPtr AdjustTarget(Object target, IntPtr methodPtr);
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
                                          Object _target;
                                          Object _methodBase;
                                          IntPtr _methodPtr;
                                          IntPtr _methodPtrAux;
          PROPERTIES:
                                          MethodInfo Method;
                                          Object Target;
          CONSTRUCTORS:
                                          public .ctor(Object object, IntPtr method);
     }

     class Sample2
     {
          METHODS:
                                          public virtual Void Save();
                                          public virtual String MyMethod();
                                          public Void add_EventName(MyDelegate value);
                                          public Void remove_EventName(MyDelegate value);
                                          public virtual String Hello(String a, Byte b);
                                          public virtual Void Proter();
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
                                          private MyDelegate EventName;
          PROPERTIES:
          CONSTRUCTORS:
                                          public .ctor(Int32 a, Double b);
     }

     class Program
     {
          METHODS:
                                          private static Void Main(String[] args);
                                          public virtual Boolean Equals(Object obj);
                                          public virtual Int32 GetHashCode();
                                          virtual Void Finalize();
                                          public Type GetType();
                                          Object MemberwiseClone();
                                          public virtual String ToString();
          FIELDS:
          PROPERTIES:
          CONSTRUCTORS:
                                          public .ctor();
     }

}


 */
