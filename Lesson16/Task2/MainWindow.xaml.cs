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
        System.Windows.Forms.Timer timer;
        Microsoft.Win32.OpenFileDialog openFileDialog;
        Assembly assembly;
        string serviceNameAssebbly;
        ServiceController controller;
        string filePath;

        public MainWindow()
        {
            InitializeComponent();
            openFileDialog = new Microsoft.Win32.OpenFileDialog();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                this.TextLog.Text += await TextAsyncResult();
                this.TextLog.ScrollToEnd();
            }
            catch (Exception exp)
            {
                timer.Stop();
            }
        }

        private void BrowseBotton_Click(object sender, RoutedEventArgs e)
        {
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath.Text = openFileDialog.SafeFileName;
                assembly = Assembly.LoadFrom(openFileDialog.FileName);
                Type[] types = assembly.GetTypes();

                foreach (var item in types)
                {
                    try
                    {
                        dynamic instance = Activator.CreateInstance(item);
                        try
                        {
                            filePath = instance.FilePath;
                        }
                        catch { }
                        
                        foreach (var items in instance.Installers)
                        {
                            try
                            {
                                bool flag = (items.ServiceName != null) ? true : false;
                                if (flag)
                                {
                                    serviceNameAssebbly = items.ServiceName;
                                    controller = new ServiceController { ServiceName = serviceNameAssebbly };
                                    timer.Start();
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

        private async void InstallBotton_Click(object sender, RoutedEventArgs e)
        {
            InstallBotton.IsEnabled = false;
            await Task.Factory.StartNew(InstallService);
            UninstallButton.IsEnabled = true;
            StartButton.IsEnabled = true;
        }

        private async void UninstallButton_Click(object sender, RoutedEventArgs e)
        {
            UninstallButton.IsEnabled = false;
            StartButton.IsEnabled = false;
            await Task.Run(() => UninstallService());
            InstallBotton.IsEnabled = true;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.Start();
                System.Windows.Forms.MessageBox.Show("Service started");
                StartButton.IsEnabled = false;
                StopButton.IsEnabled = true;
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.ToString());
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                controller.Stop();
                System.Windows.Forms.MessageBox.Show("Service stopped");
                StopButton.IsEnabled = true;
                StartButton.IsEnabled = true;
                UninstallButton.IsEnabled = true;
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.ToString());
            }
        }

        async Task<string> TextAsyncResult()
        {

            using (var stream = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    string text = await streamReader.ReadToEndAsync();
                    return text;
                }
            }
        }

        private void InstallService()
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

        private void UninstallService()
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

        private bool IsServiceInstalled(string serviceName)
        {
            var controller = ServiceController.GetServices().FirstOrDefault<ServiceController>(s => s.ServiceName == serviceName);
            if (controller == null)
            {
                return false;
            }
            return true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
            UninstallService();
        }
    }
}
