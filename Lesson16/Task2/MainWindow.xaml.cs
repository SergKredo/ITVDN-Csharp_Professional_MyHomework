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
using System.Windows.Forms;

namespace Task2
{
    /*
         Создайте службу Windows, которая будет мониторить жесткие диски и при удалении из этих
    дисков файла записывать информацию (полный путь) в текстовый файл.
    Создайте WPF приложение. Разместите в нем TextBox, в который с определенной
    периодичностью будет считываться информация из текстового файла (в который пишет
    сервис). Также разместите четыре кнопки, которые будут отвечать за установку, деинсталяцию,
    старт и остановку сервиса.
     */
    public partial class MainWindow : Window
    {
        System.Windows.Forms.Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            this.TextLog.Text += await TextAsyncResult();
        }

        private void BrowseBotton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InstallBotton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UninstallButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {

        }

        async Task<string> TextAsyncResult()
        {
            return await Task<string>.Run(() => 
            {
                return "Hello";
            });
        }
    }
}
