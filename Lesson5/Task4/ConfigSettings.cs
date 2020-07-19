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
using System.Collections.Specialized;


namespace Task4
{
    class ConfigSettings : ISetting
    {
        public Brush TextColor { get; set; }
        public Brush BackgroundColor { get; set; }
        public int TextSize { get; set; }
        public FontFamily TextFontStyle { get; set; }

        XmlDocument file;

        public ConfigSettings()
        {
            ReadFromXMLorSetDefault();
            file = LoadConfigFile();
        }
        public void SaveSettings()
        {
            // Открываем узел appSettings, в котором содержится перечень настроек.
            XmlNode node = file.SelectSingleNode("//appSettings");
            if (node == null)
            {
                node = file.CreateNode(XmlNodeType.Element, "appSettings", "");
                XmlElement root = file.DocumentElement;
                root.AppendChild(node);
            }

                // Массив ключей (создан для упрощения обращения к файлу конфигурации).
                string[] keys = new string[]
                {
                                          "BackgroundColor",
                                          "TextColor",
                                          "TextSize",
                                          "TextFontStyle"
                };

                // Массив значений (создан для упрощения обращения к файлу конфигурации).
                string[] values = new string[]
                {
                                             BackgroundColor.ToString(),
                                             TextColor.ToString(),
                                             TextSize.ToString(),
                                             TextFontStyle.ToString()
                };

                // Цикл модификации файла конфигурации.
                for (int i = 0; i < keys.Length; i++)
                {
                    // Обращаемся к конкретной строке по ключу.
                    XmlElement element = node.SelectSingleNode(string.Format("//add[@key='{0}']", keys[i])) as XmlElement;

                    // Если строка с таким ключем существует - записываем значение.
                    if (element != null)
                    {
                        element.SetAttribute("value", values[i]);
                    }
                    else
                    {
                        // Иначе: создаем строку и формируем в ней пару [ключ]-[значение].
                        element = file.CreateElement("add");
                        element.SetAttribute("key", keys[i]);
                        element.SetAttribute("value", values[i]);
                        node.AppendChild(element);
                    }
                }
                // Сохраняем результат модификации.
                file.Save(Assembly.GetExecutingAssembly().Location + ".config");


        }

        private void ReadFromXMLorSetDefault()
        {
            // Загрузка настроек по парам [ключ]-[значение].
            NameValueCollection allAppSettings = ConfigurationManager.AppSettings;

            // Восстановление состояния:
            BrushConverter color = new BrushConverter();

            try
            {
                this.BackgroundColor = (Brush)color.ConvertFromString(allAppSettings["BackgroundColor"]);
                MainWindow.Tag = true;
            }
            catch (Exception)
            {
                this.BackgroundColor = (Brush)color.ConvertFromString("#FFFFFFFF");
                MainWindow.Tag = false;
            }

            try
            {
                this.TextColor = (Brush)color.ConvertFromString(allAppSettings["TextColor"]);
                MainWindow.Tag = true;
            }
            catch (Exception)
            {
                this.TextColor = (Brush)color.ConvertFromString("#FF000000");
                MainWindow.Tag = false;
            }

            try
            {
                this.TextFontStyle = new FontFamily(allAppSettings["TextFontStyle"]);
            }
            catch (Exception)
            {
                this.TextFontStyle = new FontFamily("Segoe UI");
            }

            try
            {
                this.TextSize = int.Parse(allAppSettings["TextSize"]);
            }
            catch (Exception)
            {
                this.TextSize = 12;
            }


        }

        XmlDocument LoadConfigFile()
        {
            XmlDocument file = null;
            try
            {
                file = new XmlDocument();
                file.Load(Assembly.GetExecutingAssembly().Location + ".config");
                return file;
            }
            catch (Exception)
            {
                SaveSettings();
                return LoadConfigFile();
            }
        }
    }
}
