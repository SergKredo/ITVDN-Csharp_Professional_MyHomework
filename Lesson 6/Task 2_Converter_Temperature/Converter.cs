using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2_Converter_Temperature
{
    public abstract class BaseConverter
    {
        protected char[] charMassive;
        protected static double degreeCelcia;
        protected static double degreeKelvin;
        protected static double degreeFarinhate;
        protected static string textCelcia;
        protected static string textKelvin;
        protected static string textFarinhate;
        protected bool kelvin;
        protected bool farinhate;
        protected bool celcia;
        protected TextBox textBox_Kelvine;
        protected TextBox textBox_Farinhate;
        protected TextBox textBox_Celcia;

        protected BaseConverter()
        {
            this.charMassive = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',' };
            degreeCelcia = degreeKelvin = degreeFarinhate = 0;
            textCelcia = textKelvin = textFarinhate = "";
            this.kelvin = farinhate = celcia = true;
        }

        protected BaseConverter(TextBox textBox_Kelvine, TextBox textBox_Farinhate, TextBox textBox_Celcia)
            : this()
        {
            this.textBox_Kelvine = textBox_Kelvine;
            this.textBox_Farinhate = textBox_Farinhate;
            this.textBox_Celcia = textBox_Celcia;
        }

        public abstract double ConvertCelciaToKelvine(double degree);

        public abstract double ConvertCelciaToFarinhate(double degree);

        public abstract double ConvertKelvineToCelcia(double degree);

        public abstract double ConvertKelvineToFarinhate(double degree);

        public abstract double ConvertFarinhateToCelcia(double degree);

        public abstract double ConvertFarinhateToKelvine(double degree);

        public abstract void textBox_Kelvine_TextChanged(object sender, EventArgs e);

        public abstract void textBox_Celcia_TextChanged(object sender, EventArgs e);

        public abstract void textBox_Farinhate_TextChanged(object sender, EventArgs e);
        
    }
}
