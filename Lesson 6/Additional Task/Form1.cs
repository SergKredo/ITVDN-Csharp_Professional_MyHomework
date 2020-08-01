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
    public static class Main
    {

    }
    public partial class TextBox : Form
    {
        public TextBox()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                Assembly assembly = Assembly.LoadFrom(@path);
                Type[] types = assembly.GetTypes();
                string namespaces = null;

                foreach (Type item in types)
                {



                    this.textBox1.Text += (namespaces == null) ? "namespace " + item.Namespace + Environment.NewLine + "{" + Environment.NewLine : null;
                    namespaces = item.Namespace;
                    if (item.IsClass)
                    {
                        this.textBox1.Text += "class ";
                    }

                    if (item.IsValueType)
                    {
                        this.textBox1.Text += "struct ";
                    }

                    if (item.IsEnum)
                    {
                        this.textBox1.Text += "enum ";
                    }

                    if (item.IsInterface)
                    {
                        this.textBox1.Text += "interface ";
                    }
                    this.textBox1.Text += item.Name + Environment.NewLine + "{" + Environment.NewLine;


                    this.textBox1.Text += "Methods:".ToUpper() + Environment.NewLine;

                    foreach (MethodInfo items in item.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.IgnoreCase))
                    {
                        if (items.IsPublic)
                        {
                            this.textBox1.Text += "public ";
                        }

                        if (items.IsPrivate)
                        {
                            this.textBox1.Text += "private ";
                        }

                        if (items.IsStatic)
                        {
                            this.textBox1.Text += "static ";
                        }

                        if (items.IsAbstract)
                        {
                            this.textBox1.Text += "abstract ";
                        }

                        if (items.IsVirtual)
                        {
                            this.textBox1.Text += "virtual ";
                        }

                        this.textBox1.Text += items.ReturnType.Name + " " + items.Name + Environment.NewLine;
                    }

                    this.textBox1.Text += "}" + Environment.NewLine + "\r\n";

                }
                this.textBox1.Text += "}" + Environment.NewLine;
            }
        }

        private void TextBox_Load(object sender, EventArgs e)
        {

        }
    }
}
