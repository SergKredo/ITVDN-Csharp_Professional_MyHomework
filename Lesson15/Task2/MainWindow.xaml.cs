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
    Создайте WPF приложение, разместите в окне TextBox и две кнопки. При нажатии на первую
    кнопку в TextBox выводится сообщение «Подключен к базе данных» при этом в обработчике
    установите задержку в 3-5 сек для имитации подключения к БД, также данная кнопка запускает
    таймер, который с периодичностью в несколько секунд выводит в TextBox сообщение «Данные
    получены». При нажатии на вторую кнопку по аналогии с первой отключаемся от базы (с
    задержкой), выводим сообщение и останавливаем таймер.
     */


    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
