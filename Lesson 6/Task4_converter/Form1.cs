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

namespace Task4_converter
{
    public partial class Form1 : Form
    {
        dynamic converterTemperature;
        Assembly assemblyConverter = null;
        public Form1()
        {
            InitializeComponent();
            assemblyConverter = Assembly.Load("Task 2_Converter_Temperature");
            Type type = assemblyConverter.GetType("Task_2_Converter_Temperature.ConverterTemperature");
            object[] parameters = { this.textBox_Kelvine, this.textBox_Farinhate, this.textBox_Celcia };
            converterTemperature = Activator.CreateInstance(type, parameters);  
        }


        private void textBox_Kelvine_TextChanged(object sender, EventArgs e)
        {
            converterTemperature.textBox_Kelvine_TextChanged(sender, e);
        }

        private void textBox_Celcia_TextChanged(object sender, EventArgs e)
        {
            converterTemperature.textBox_Celcia_TextChanged(sender, e);
        }

        private void textBox_Farinhate_TextChanged(object sender, EventArgs e)
        {
            converterTemperature.textBox_Farinhate_TextChanged(sender, e);
        }

    }
}
