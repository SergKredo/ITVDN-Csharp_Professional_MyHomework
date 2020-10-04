using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ServiceChangeLog
{
    public partial class Service1 : ServiceBase
    {
        DriveInfo[] drives;
        static readonly string filePath = @"D:\ChangeWithFilesonDisks.txt";
        FileSystemWatcher watcher;

        public Service1()
        {
            InitializeComponent();

            // Получаем массив жестких дисков (для фильтра массива необходимо подключить пространство имен System.Linq)
            drives = DriveInfo.GetDrives().Where<DriveInfo>(drive => drive.DriveType == DriveType.Fixed).ToArray<DriveInfo>();
            foreach (var item in drives)
            {
                watcher = new FileSystemWatcher(item.RootDirectory.ToString());
                watcher.IncludeSubdirectories = true; 
                watcher.Created += Watcher_Changed;
                watcher.Deleted += Watcher_Changed;
                watcher.Renamed += Watcher_Changed;
                watcher.Error += Watcher_Error;
                watcher.EnableRaisingEvents = true;
            }
        }

        protected override void OnStart(string[] args)
        {
            // Начать мониторинг.         
            watcher.EnableRaisingEvents = true;
        }


        private void Watcher_Error(object sender, ErrorEventArgs e)
        {
            if (this.CanPauseAndContinue == true)
            {
                this.OnStart(new string[0]);
            }
        }

        private async void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            using (var streamWriter = new StreamWriter(filePath, true))
            {
                await streamWriter.WriteLineAsync(DateTime.Now.ToLongTimeString() + " " + DateTime.Now.ToLongDateString() + "(" + e.ChangeType + "):" + e.FullPath);
            }
        }

        protected override void OnStop()
        {
            // Остановить мониторинг.
            watcher.EnableRaisingEvents = false;
        }
    }
}
