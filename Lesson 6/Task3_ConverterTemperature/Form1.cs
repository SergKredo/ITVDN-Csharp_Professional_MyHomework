using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3_ConverterTemperature
{
    public partial class Form1 : Form
    {

        bool kelvin = true;
        bool farinhate = true;
        bool celcia = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Kelvine_TextChanged(object sender, EventArgs e)
        {
            var text = sender as TextBox;
            if (text.Text != "" && kelvin)
            {
                if (text.Text != "-")
                {
                    farinhate = celcia = false;
                    double celciaDegree;
                    try
                    {
                        celciaDegree = Convert.ToDouble(text.Text.Replace('.', ','));
                    }
                    catch (Exception)
                    {
                        celciaDegree = Convert.ToDouble(text.Text.Replace(',', '.'));
                    }
                    this.textBox_Farinhate.Text = ConvertKelvineToFarinhate(celciaDegree).ToString();
                    this.textBox_Celcia.Text = ConvertKelvineToCelcia(celciaDegree).ToString();
                    farinhate = celcia = true;
                }
            }
        }

        private void textBox_Celcia_TextChanged(object sender, EventArgs e)
        {
            var text = sender as TextBox;
            if (text.Text != "" && celcia)
            {
                if (text.Text != "-")
                {
                    farinhate = kelvin = false;
                    double celciaDegree;
                    try
                    {
                        celciaDegree = Convert.ToDouble(text.Text.Replace('.', ','));
                    }
                    catch (Exception)
                    {
                        celciaDegree = Convert.ToDouble(text.Text.Replace(',', '.'));
                    }
                    this.textBox_Farinhate.Text = ConvertCelciaToFarinhate(celciaDegree).ToString();
                    this.textBox_Kelvine.Text = ConvertCelciaToKelvine(celciaDegree).ToString();
                    farinhate = kelvin = true;
                }
            }
        }

        private void textBox_Farinhate_TextChanged(object sender, EventArgs e)
        {
            var text = sender as TextBox;
            if (text.Text != "" && farinhate)
            {
                if (text.Text != "-")
                {
                    celcia = kelvin = false;
                    double celciaDegree;
                    try
                    {
                        celciaDegree = Convert.ToDouble(text.Text.Replace('.', ','));
                    }
                    catch (Exception)
                    {
                        celciaDegree = Convert.ToDouble(text.Text.Replace(',', '.'));
                    }
                    this.textBox_Kelvine.Text = ConvertFarinhateToKelvine(celciaDegree).ToString();
                    this.textBox_Celcia.Text = ConvertFarinhateToCelcia(celciaDegree).ToString();
                    celcia = kelvin = true;
                }
            }
        }


        public double ConvertCelciaToKelvine(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return Convert.ToDouble(grad) + 273.15;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return Convert.ToDouble(grad) + 273.15;
            }
        }
        public double ConvertCelciaToFarinhate(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return (Convert.ToDouble(grad) * (9 / 5d)) + 32;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return (Convert.ToDouble(grad) * (9 / 5d)) + 32;
            }

        }

        public double ConvertKelvineToCelcia(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return Convert.ToDouble(grad) - 273.15;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return Convert.ToDouble(grad) - 273.15;
            }

        }
        public double ConvertKelvineToFarinhate(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return (Convert.ToDouble(grad) - 273.15) * (9 / 5d) + 32;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return (Convert.ToDouble(grad) - 273.15) * (9 / 5d) + 32;
            }
        }

        public double ConvertFarinhateToCelcia(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return (Convert.ToDouble(grad) - 32) * (5 / 9d);
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return (Convert.ToDouble(grad) - 32) * (5 / 9d);
            }
        }
        public double ConvertFarinhateToKelvine(double degree)
        {
            try
            {
                string grad = degree.ToString().Replace('.', ',');
                return (Convert.ToDouble(grad) - 32) * (5 / 9d) + 273.15;
            }
            catch (Exception)
            {
                string grad = degree.ToString().Replace(',', '.');
                return (Convert.ToDouble(grad) - 32) * (5 / 9d) + 273.15;
            }
        }
    }
}
