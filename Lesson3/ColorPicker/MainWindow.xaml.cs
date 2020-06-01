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

namespace ColorPicker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IsolatedStorageFile isolateFile;
        FileStream file;
        StreamWriter writer;
        StreamReader reader;
        string saveColor;
        public MainWindow()
        {
            InitializeComponent();
            isolateFile = IsolatedStorageFile.GetUserStoreForAssembly();
            if (!(isolateFile.DirectoryExists(@"\ColorPicker") && isolateFile.FileExists(@"\ColorPicker\DateAboatColorApp.txt")))
            {
                isolateFile.CreateDirectory(@"\ColorPicker");
                file = isolateFile.CreateFile(@"\ColorPicker\DateAboatColorApp.txt");
                writer = new StreamWriter(file);
                writer.WriteLine(this.label.Background.ToString());
                writer.Close();
                file.Close();
            }

        }

        private void Windows_Loading(object sender, RoutedEventArgs e)
        {
            file = isolateFile.OpenFile(@"\ColorPicker\DateAboatColorApp.txt", FileMode.Open, FileAccess.Read);
            reader = new StreamReader(file);
            saveColor = reader.ReadToEnd();
            this.label.Content = string.Format("\r"+saveColor);
            BrushConverter converterColor = new BrushConverter();
            this.label.Background = (Brush)converterColor.ConvertFromString(saveColor);
            reader.Close();
            file.Close();
        }

        private void ChangeColor(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.colorPicker.SelectedColorText;
            this.label.Content = colorText;
            BrushConverter converterColor = new BrushConverter();
            this.label.Background = (Brush)converterColor.ConvertFromString(colorText);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            file = isolateFile.OpenFile(@"\ColorPicker\DateAboatColorApp.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            writer = new StreamWriter(file);
            writer.WriteLine(this.label.Background.ToString());
            writer.Close();
            file.Close();
            this.label.Content = string.Format(new string(" "[0], 14)+"Color {0}\n is stored in isolated storage.".ToUpper(), this.label.Background.ToString());
        }
    }
}
