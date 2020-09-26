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
using System.Threading;

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
        System.Windows.Forms.Timer timer; // Добавляем ссылку на сборку System.Windows.Forms и объявляем объект класса Timer
        public MainWindow()
        {
            InitializeComponent();
            this.timer = new System.Windows.Forms.Timer(); // Создаем экземпляр класса Timer
            this.timer.Interval = 5000;  // Задаем интервал между последним и настоящим вызовом события Tick экземпляра класса Timer
            this.timer.Tick += Timer_Tick;  // Сообщаем метод обработчик с событием Tick
            this.BottonDisconnect.IsEnabled = false;  // Делаем неактивной кнопку Disconnect
        }

        private void Timer_Tick(object sender, EventArgs e)  // Метод обработчик события Tick
        {
            this.TextData.Text += "Data received" + Environment.NewLine;
        }

        private async void BottonConnect_Click(object sender, RoutedEventArgs e) // Асинхронный вызов метода обработчика при нажатии на кнопку Connect
        {
            this.TextData.Text += await ConnectToBaseData(); // Присваиваем возвращаемое значение типа string при асинхронном вызове метода ConnectToBaseData()
            this.BottonConnect.IsEnabled = false;
            this.BottonDisconnect.IsEnabled = true;
            this.timer.Start();  // Запускаем таймер c последовательностью повторяющихся периодичных событий Tick
        }

        private async void BottonDisconnect_Click(object sender, RoutedEventArgs e)  // Асинхронный вызов метода обработчика при нажатии на кнопку Disconnect
        {
            this.TextData.Text += await DisconnectToBaseData(); // Присваиваем возвращаемое значение типа string при асинхронном вызове метода DisconnectToBaseData()
            this.BottonConnect.IsEnabled = true;  // Делаем активной кнопку
            this.timer.Stop();  // Останавливаем таймер
            this.BottonDisconnect.IsEnabled = false;
        }

        async Task<string> ConnectToBaseData()  // Асинхронный метод, который возвращает задачу generics Task типа string
        {
            return await Task.Run(() => // Класс-объект Task ставит в очередь заданную работу для запуска в пуле потоков и возвращает объект типа Task<TResult>
            {
                Thread.Sleep(5000);  // Приостанавливаем работу ьекущего потока на 5 миллисекунд
                return "Connected to database" + Environment.NewLine;
            }
            );
        }

        async Task<string> DisconnectToBaseData()  // Асинхронный метод, который возвращает задачу generics Task типа string
        {
            return await Task.Run(() =>  // Класс-объект Task ставит в очередь заданную работу для запуска в пуле потоков и возвращает объект типа Task<TResult>
            {
                Thread.Sleep(5000);
                return "Disconnected to database" + Environment.NewLine;
            }
            );
        }
    }
}
