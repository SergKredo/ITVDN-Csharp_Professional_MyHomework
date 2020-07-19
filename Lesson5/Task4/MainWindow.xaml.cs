//#define RegistrySettings
#define ConfigFile

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.IO;


namespace Task4
{
    /*
     Создайте приложение WPF Application, в главном окне которого поместите любой текст. Также,
должно быть окно настроек (можно реализовать с помощью TabControl). Пользователь может
изменять настройки. При повторном запуске приложения настройки должны оставаться
прежними. Реализуйте два варианта (в одном приложении или двух разных): 1) сохранение
настроек в конфигурационном файле; 2) сохранение настроек в реестре.
    В окне настроек реализуйте следующие опции: цвет фона, цвет текста, размер шрифта, стиль
шрифта, а также кнопку «Сохранить». Для выбора цвета воспользуйтесь ColorPicker-ом по
примеру задания из Урока №3.

     Для выполнения этого задания необходимо наличие библиотеки Xceed.Wpf.Toolkit.dll. Ее
    можно получить через References -> Manage NuGet Packages… -> в поиске написать Extended
    WPF Toolkit (помимо интересующей нас библиотеки будут установлены и другие), или же
    скачать непосредственно на сайте http://wpftoolkit.codeplex.com/ и подключить в проект только
    интересующую нас бибилиотеку (References -> Add Reference …).
        Для этого необходимо в XAML коде в теге Window подключить пространство
    имен xmlns:xctk="http://schemas.xceed.com/wpf/xaml/toolkit" .
     */

    public partial class MainWindow : Window
    {
        public static bool Tag;
        public static object checkBox;
        public static RoutedEventArgs eCheckBox;
        ISetting setting;

        public MainWindow()
        {
            InitializeComponent();
            Tag = true;

        }

        private void Windows_Loading(object sender, RoutedEventArgs e)  // Метод-обработчик события Loaded. Метод позволяет при запуске программы считывать с текстовых файлов названия цветов
        {
            string text = File.ReadAllText(@"005_XML. Файлы конфигурации. Реестр_.txt");
            this.Text.Text = text;

            this.ComboBox_FontSize.ItemsSource = this.ComboBox_FontStyle.ItemsSource = Fonts.SystemFontFamilies.OrderBy(x => x.Source);
            this.ComboBox_FontSize.ItemsSource = new int[] { 1, 2, 4, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 18, 20, 22, 24, 26, 28, 30, 40, 50, 60 };

#if ConfigFile
            setting = new ConfigSettings();
#else
            setting = new RegistrySettings();
#endif
            SettingsFilling();

        }

        private void ChangeColorBackground(object sender, RoutedPropertyChangedEventArgs<Color?> e)   // Метод обработчик позволяет изменять цвет элементов интерфейса программы
        {
            string colorText = this.colorPicker.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.Label_BackgroundColor.Background = (Brush)converterColor.ConvertFromString(colorText);
            this.Text.Background = (Brush)converterColor.ConvertFromString(colorText);
            if (this.CheckBoxSave.IsChecked.Value)
            {
                SaveSettingsApp(checkBox, eCheckBox);
            }
        }

        private void ChangeColorText(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.colorPicker_TextColor.SelectedColorText;
            BrushConverter converterColor = new BrushConverter();
            this.Label_TextColor.Background = (Brush)converterColor.ConvertFromString(colorText);
            this.Text.Foreground = (Brush)converterColor.ConvertFromString(colorText);
            if (this.CheckBoxSave.IsChecked.Value)
            {
                SaveSettingsApp(checkBox, eCheckBox);
            }
        }

        private void ChangeToFontStyle(object sender, SelectionChangedEventArgs e)
        {
            this.Text.FontFamily = this.ComboBox_FontStyle.SelectedItem as FontFamily;
            if (this.CheckBoxSave.IsChecked.Value)
            {
                SaveSettingsApp(checkBox, eCheckBox);
            }
        }

        private void ChangeToSizeText(object sender, SelectionChangedEventArgs e)
        {
            this.Text.FontSize = Convert.ToInt32(this.ComboBox_FontSize.SelectedItem);
            if (this.CheckBoxSave.IsChecked.Value)
            {
                SaveSettingsApp(checkBox, eCheckBox);
            }
        }

        void SettingsFilling()
        {
            if (Tag)
            {
                this.Label_BackgroundColor.Background = this.Text.Background = setting.BackgroundColor;
            }
            else
            {
                this.Label_BackgroundColor.Background = (Brush)(new BrushConverter().ConvertFromString("#FFEEEEEE"));
                this.Text.Background = setting.BackgroundColor;
            }

            if (Tag)
            {
                this.Text.Foreground = this.Label_TextColor.Background = setting.TextColor;
            }
            else
            {
                this.Label_TextColor.Background = (Brush)(new BrushConverter().ConvertFromString("#FFEEEEEE"));
                this.Text.Foreground = setting.TextColor;
            }
            this.Text.FontFamily = setting.TextFontStyle;
            this.Text.FontSize = setting.TextSize;
        }

        private void SaveSettingsApp(object sender, RoutedEventArgs e)
        {
            if (this.CheckBoxSave.IsChecked.Value)
            {
                if (setting == null)
                {
#if ConfigFile
                    setting = new ConfigSettings();
#else
                    setting = new RegistrySettings();
#endif
                }
                else
                {
                    setting.BackgroundColor = this.Text.Background;
                    setting.TextColor = this.Text.Foreground;
                    setting.TextFontStyle = this.Text.FontFamily;
                    setting.TextSize = (int)this.Text.FontSize;
                }
                checkBox = sender;
                eCheckBox = e;
                setting.SaveSettings();
            }
        }
    }
}
