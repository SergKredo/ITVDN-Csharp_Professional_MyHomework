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

namespace ColorPicker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Windows_Loading(object sender, RoutedEventArgs e)
        {
            this.label.Background = this.colorPicker.Background;          
        }

        private void ChangeColor(object sender, RoutedPropertyChangedEventArgs<Color?> e)
        {
            string colorText = this.colorPicker.SelectedColorText;
            this.label.Content = colorText;
            BrushConverter converterColor = new BrushConverter();
            this.label.Background = (Brush)converterColor.ConvertFromString(colorText);
        }
    }
}
