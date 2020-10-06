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
using System.ServiceProcess;
using System.Configuration.Install;
using System.Reflection;
using Microsoft.Win32;
using System.IO;

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
        System.Windows.Forms.Timer timer; // Таймер для циклического повторения однотипных действий
        Microsoft.Win32.OpenFileDialog openFileDialog;  // Диалоговое окно для поиска на компьютере пользователя NT-службы
        Assembly assembly;  // Объект представляет возможность получить расширенный доступ к определенной сборке
        string serviceNameAssebbly;  // Имя для идентификации службы в системе
        ServiceController controller;  // Объект представляет службу Windows и позволяет подключаться к запущенной или остановленной службе, управлять работой службы и получать сведения о ней
        string filePath;  // Полный путь расположения NT-службы на компьютере

        public MainWindow()
        {
            InitializeComponent();
            openFileDialog = new Microsoft.Win32.OpenFileDialog();  // Инстранцирование класса
            timer = new Timer();  
            timer.Interval = 1000;  // Интервал повторного вызова события timer.Tick
            timer.Tick += Timer_Tick;  // Сообщаем метод обработчик Timer_Tick с событием timer.Tick
            timer.Start();  // Запуск таймера
        }

        private async void Timer_Tick(object sender, EventArgs e)  // Асинхронный метод-обработчик события timer.Tick
        {
            try
            {
                this.TextLog.Text += await TextAsyncResult();  // Асинхронное присваивание значения свойству Text объекта TextLog
                this.TextLog.ScrollToEnd();  // Автоматическое прокручивание представления элемента управления в конец содержимого
            }
            catch (Exception exp)
            {
                timer.Stop();  // Остановка таймера
            }
        }

        private void BrowseBotton_Click(object sender, RoutedEventArgs e)  // Метод обработчик события Click объекта BrowseBotton
        {
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath.Text = openFileDialog.SafeFileName;
                assembly = Assembly.LoadFrom(openFileDialog.FileName);  // Загружаем сборку
                Type[] types = assembly.GetTypes();  // Получаем массив типов определенных в этой сборке

                foreach (var item in types)  // Перебор типов из сборки
                {
                    try
                    {
                        dynamic instance = Activator.CreateInstance(item);  // Позднее связывание (динамическое инстанцирование объекта для данного типа)
                        try
                        {
                            filePath = instance.FilePath;  // Получаем доступ к свойству созданного нами экземпляра объекта типа item
                        }
                        catch { }
                        
                        foreach (var items in instance.Installers) // Перебор свойств 
                        {
                            try
                            {
                                bool flag = (items.ServiceName != null) ? true : false;
                                if (flag)
                                {
                                    serviceNameAssebbly = items.ServiceName;
                                    controller = new ServiceController { ServiceName = serviceNameAssebbly }; // Инстанцируем объект типа ServiceController с определенным именем для идентификации службы в системе
                                    timer.Start(); // Запускаем таймер
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
        }

        private async void InstallBotton_Click(object sender, RoutedEventArgs e)  // Метод обработчик события Click объекта InstallBotton
        {
            InstallBotton.IsEnabled = false;  // Отключаем в интерфейсе приложения доступ к кнопке
            await Task.Factory.StartNew(InstallService); // Асинхронный запуск задачи (Task) с последующим вызовом метода InstallService
            UninstallButton.IsEnabled = true;  // Делаем активной доступ к кнопке в интерфейсе приложения 
            StartButton.IsEnabled = true;
        }

        private async void UninstallButton_Click(object sender, RoutedEventArgs e)  // Метод обработчик события Click объекта UninstallButton
        {
            UninstallButton.IsEnabled = false;
            StartButton.IsEnabled = false;
            await Task.Run(() => UninstallService());  // Асинхронный запуск задачи (Task) с последующим вызовом метода UninstallService
            InstallBotton.IsEnabled = true;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)  // Метод обработчик события Click объекта StartButton
        {
            try
            {
                controller.Start();
                System.Windows.Forms.MessageBox.Show("Service started");  // Отображение окна-сообщения об успешном старте NT-службы
                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.ToString());
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)  // Метод обработчик события Click объекта StopButton
        {
            try
            {
                controller.Stop();
                System.Windows.Forms.MessageBox.Show("Service stopped");  // Отображение окна-сообщения об успешной остановке NT-службы
                StopButton.IsEnabled = true;
                StartButton.IsEnabled = true;
                UninstallButton.IsEnabled = true;
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.ToString());
            }
        }

        async Task<string> TextAsyncResult()  // Асинхронный метод
        {
            // С помощью параметра FileShare.Read разрешаем открытие файла для чтения из другого потока
            using (var stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite)) 
            {
                using (var streamReader = new StreamReader(stream))
                {
                    string text = await streamReader.ReadToEndAsync();
                    return text;
                }
            }
        }

        private void InstallService()  // Установка NT-службы
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new[] { openFileDialog.FileName });
                System.Windows.Forms.MessageBox.Show("Service installed");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        private void UninstallService()  // Удаление NT-службы
        {
            if (!IsServiceInstalled(serviceNameAssebbly)) return;

            try
            {
                ManagedInstallerClass.InstallHelper(new[] { @"/u", openFileDialog.FileName });
                System.Windows.Forms.MessageBox.Show("Service uninstalled");
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
            }
        }

        private bool IsServiceInstalled(string serviceName)  // Проверка на наличие данной службы в менеджере служб операционной системы
        {
            var controller = ServiceController.GetServices().FirstOrDefault<ServiceController>(s => s.ServiceName == serviceName);
            if (controller == null)
            {
                return false;
            }
            return true;
        }

        private void Window_Closed(object sender, EventArgs e)  // При закрытии приложения метод останавливает таймер и деинсталлирует NT-службу
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            UninstallService();
        }
    }
}
