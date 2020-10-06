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
    /*
      Создайте службу Windows, которая будет мониторить жесткие диски и при изменениях в файловой системе этих
    дисков файла будет записывать информацию, время изменения (полный путь) в текстовый файл.
     */
    public partial class Service1 : ServiceBase
    {
        DriveInfo[] drives;  // Массив дисков или томов диска
        static readonly string filePath = @"C:\Users\Work\Dropbox\Программирование на С#_ITVDN\csharp-professional-materials_homeworks\ITVDN-Csharp_Professional_MyHomework\Lesson16\Task2\ChangeWithFilesonDisks.txt";
        FileSystemWatcher watcher;  // Объект ожидает уведомления файловой системы об изменениях в каталогах или файлах каталогов
        public string FilePath { get; }  // Путь к файлу логирования информаци об изменениях в системе
        public Service1()
        {
            InitializeComponent();
            FilePath = filePath;
            // Получаем массив жестких дисков (для фильтра массива необходимо подключить пространство имен System.Linq)
            drives = DriveInfo.GetDrives().Where<DriveInfo>(drive => drive.DriveType == DriveType.Fixed).ToArray<DriveInfo>();
            
        }

        protected override void OnStart(string[] args)  // Переопределение базового метода OnStart(). Метод отвечает за запуск NT-службы и отслеживании событиями изменений с файлами и каталогами
        {
            // Начать мониторинг.         
            foreach (var item in drives)  // Перебор всех дисков
            {
                watcher = new FileSystemWatcher(item.RootDirectory.ToString());  // Инстанцирование объекта-отслеживания по заданному диску
                watcher.IncludeSubdirectories = true;  // Активируем контроль изменений во вложенных каталогах по указанному пути
                watcher.Created += Watcher_Changed;  // Метод-обработчик вызывается, когда происходит событие (создания файла или каталога по указанному пути)
                watcher.Deleted += Watcher_Changed;  // Метод-обработчик вызывается, когда происходит событие (удаление файла или каталога по указанному пути)
                watcher.Renamed += Watcher_Changed;  // Метод-обработчик вызывается, когда происходит событие (переименование файла или каталога по указанному пути)
                watcher.Error += Watcher_Error;  // Метод-обработчик вызывается, когда происходит событие (экземпляру FileSystemWatcher не удается отследить изменения по указанному пути)
                watcher.EnableRaisingEvents = true;
            }
            watcher.EnableRaisingEvents = true; // Активация true отсеживания изменений в системе
        }


        private void Watcher_Error(object sender, ErrorEventArgs e)  // Метод-обработчик возникает при ошибке отслеживания изменений в системе
        {
            if (this.CanPauseAndContinue == true)
            {
                this.OnStart(new string[0]);
            }
        }

        private async void Watcher_Changed(object sender, FileSystemEventArgs e)  // Асинхронный метод-обработчик. Метод асинхронно в отдельном потоке записывает в текстовый файл изменения, которые отвечают данному событию, которое его вызвало
        {
            using (var stream = File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    await streamWriter.WriteLineAsync(DateTime.Now.ToLongTimeString() +"  "+ DateTime.Now.ToLongDateString() + "\r" + "(" + e.ChangeType + "): " + e.FullPath +Environment.NewLine);
                }
            }
        }

        protected override void OnStop()  // Переопределение базового метода OnStop(). Метод останавливает отслеживание изменений файлов в системе.
        {
            // Остановить мониторинг.
            watcher.EnableRaisingEvents = false;
        }
    }
}
