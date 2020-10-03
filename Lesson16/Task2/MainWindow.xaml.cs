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
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
