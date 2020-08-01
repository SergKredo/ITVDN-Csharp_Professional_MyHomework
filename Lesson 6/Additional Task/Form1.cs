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


namespace Additional_Task
{
    public partial class TextBox : Form
    {
        public TextBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string path = openFileDialog.FileName;
                File.WriteAllText(@path, this.textBox1.Text, Encoding.UTF8);
            }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.textBox1.Text = null;
                    string path = openFileDialog.FileName;
                    this.browser.Text = @path;

                    Assembly assembly = Assembly.LoadFrom(@path);
                    Type[] types = assembly.GetTypes();
                    string namespaces = null;
                    string loadAssembly = new string(' ', 90)+"The assembly was loaded successfully!".ToUpper()+"\r\n\r\n";
                    this.textBox1.Text += loadAssembly;
                    foreach (Type item in types)
                    {
                        this.textBox1.Text += (namespaces == null) ? "namespace " + item.Namespace + Environment.NewLine + "{" + Environment.NewLine : null;
                        namespaces = item.Namespace;
                        string padding = new string(' ', 5);
                        if (item.IsClass)
                        {
                            this.textBox1.Text += padding + "class ";
                        }

                        if (item.IsValueType)
                        {
                            this.textBox1.Text += padding + "struct ";
                        }

                        if (item.IsEnum)
                        {
                            padding = "";
                            this.textBox1.Text += padding + "enum ";
                            padding = new string(' ', 5);
                        }

                        if (item.IsInterface)
                        {
                            this.textBox1.Text += padding + "interface ";
                        }


                        this.textBox1.Text += item.Name + Environment.NewLine + padding + "{" + Environment.NewLine;

                        padding = new string(' ', 10);
                        this.textBox1.Text += padding + "Methods:".ToUpper() + Environment.NewLine;

                        foreach (MethodInfo items in item.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            bool enter = true;
                            padding = new string(' ', 42);
                            if (items.IsPublic)
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "public ";
                            }

                            if (items.IsPrivate)
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "private ";
                            }

                            if (items.IsStatic)
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "static ";
                            }

                            if (items.IsAbstract)
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "abstract ";
                            }

                            if (items.IsVirtual)
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
                            ParameterInfo[] parameters = items.GetParameters();
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
                        foreach (var field in item.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            bool enter = true;
                            padding = new string(' ', 42);
                            if (field.IsPublic)
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "public ";
                            }

                            if (field.IsPrivate)
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "private ";
                            }

                            if (field.IsStatic)
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


                        padding = new string(' ', 10);
                        this.textBox1.Text += padding + "Properties:".ToUpper() + Environment.NewLine;
                        foreach (var field in item.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            bool enter = true;
                            padding = new string(' ', 42);
                            this.textBox1.Text += padding;

                            this.textBox1.Text += field.PropertyType.Name + " " + field.Name + ";" + Environment.NewLine;
                        }


                        padding = new string(' ', 10);
                        this.textBox1.Text += padding + "Constructors:".ToUpper() + Environment.NewLine;
                        foreach (var field in item.GetConstructors(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                        {
                            bool enter = true;
                            padding = new string(' ', 42);
                            if (field.IsPublic)
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "public ";
                            }

                            if (field.IsPrivate)
                            {
                                padding = enter ? padding : "";
                                enter = false;
                                this.textBox1.Text += padding + "private ";
                            }

                            if (field.IsStatic)
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
            catch (Exception)
            {
                string loadAssembly = new string(' ', 90) + "Failed assembly loading!".ToUpper();
                this.textBox1.Text = loadAssembly;
            }
        }
    }
}
