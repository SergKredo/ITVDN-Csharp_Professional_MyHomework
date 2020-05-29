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

namespace SearchEngineInWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 200; i++)
            {
                this.LookTextBox.Text += "Hello!\n";
            }
            this.LookTextBox.IsReadOnly = true;
            this.ResulttextBox.IsReadOnly = true;

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void DeleteText(object sender, MouseEventArgs e)
        {
            this.SearchTextBox.Text = this.SearchTextBox.Text.Remove(0);
        }
    }
}
