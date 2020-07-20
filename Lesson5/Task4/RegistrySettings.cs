using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;
using System.Configuration;
using System.Reflection;
using System.IO;
using Microsoft.Win32;

namespace Task4
{
    class RegistrySettings : ISetting
    {
        public Brush TextColor { get; set; }
        public Brush BackgroundColor { get; set; }
        public int TextSize { get; set; }
        public FontFamily TextFontStyle { get; set; }

        RegistryKey file;

        public RegistrySettings()
        {
            file = LoadConfigFile();
            ReadFromXMLorSetDefault();
        }
        public void SaveSettings()
        {
            // Инициализируем объект RegistryKey для работы с веткой реестра CurrentUser.
            // Открываем ключ "Software\MyApp\Task4", в котором содержится перечень настроек.
            RegistryKey subKeySubKey;
            RegistryKey file = Registry.CurrentUser;
            RegistryKey subKey = file.OpenSubKey("Software", true);
            RegistryKey subKeySub = subKey.OpenSubKey("MyApp", true);

            if (subKeySub == null) // Если такого ключа Software\MyApp\Task4 не существует
            {
                // Создаем новый ключ в реестре
                subKeySub = subKey.CreateSubKey("MyApp", true); // Второй аргумент (true) говорит о том, что будет совершаться запись.
                subKeySubKey = subKeySub.CreateSubKey("Task4");
            }
            subKeySubKey = subKeySub.OpenSubKey("Task4", true);

            // Массив ключей (создан для упрощения обращения к ключам реестра).
            string[] keys = new string[]
            {
                                          "BackgroundColor",
                                          "TextColor",
                                          "TextSize",
                                          "TextFontStyle"
            };

            object[] values = new object[]
                {
                    BackgroundColor,
                    TextColor,
                    TextSize,
                    TextFontStyle
                };

            // Совершаем запись в реестр.
            for (int i = 0; i < keys.Length; i++)
            {

                if (subKeySubKey != null)
                {
                    // Запись значений в реестр. SetValue(имя ключа, значение).
                    subKeySubKey.SetValue(keys[i], values[i]);
                }
                else
                {
                    // Запись значений в реестр по умолчанию.
                    subKeySubKey.SetValue(keys[i], values[i]);
                }
            }
        }

        private void ReadFromXMLorSetDefault()
        {
            // Восстановление состояния из реестра:
            BrushConverter color = new BrushConverter();

            try
            {
                this.BackgroundColor = (Brush)color.ConvertFromString(file.GetValue("BackgroundColor") as string);
                MainWindow.Tag = true;
            }
            catch (Exception)
            {
                this.BackgroundColor = (Brush)color.ConvertFromString("#FFFFFFFF");
                MainWindow.Tag = false;
            }

            try
            {
                this.TextColor = (Brush)color.ConvertFromString(file.GetValue("TextColor") as string);
                MainWindow.Tag = true;
            }
            catch (Exception)
            {
                this.TextColor = (Brush)color.ConvertFromString("#FF000000");
                MainWindow.Tag = false;
            }

            try
            {
                this.TextFontStyle = new FontFamily(file.GetValue("TextFontStyle") as string);
            }
            catch (Exception)
            {
                this.TextFontStyle = new FontFamily("Segoe UI");
            }

            try
            {
                object number = file.GetValue("TextSize");
                this.TextSize = (int)number;
            }
            catch (Exception)
            {
                this.TextSize = 12;
            }


        }

        RegistryKey LoadConfigFile()
        {
            RegistryKey file = Registry.CurrentUser;
            try
            {
                file = file.OpenSubKey(@"Software\MyApp\Task4", true);
                return file = file ?? throw new Exception();
            }
            catch (Exception)
            {
                SaveSettings();
                return LoadConfigFile();
            }
        }
    }
}
