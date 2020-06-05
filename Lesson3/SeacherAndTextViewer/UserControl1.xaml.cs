using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace SeacherAndTextViewer
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml. Создаем новый UserControl1 элемент программы, который будет отвечать за создание, работу с PdfViewer
    /// </summary>
    /// 
    public static class InfoAboatBotton   // Объявляем статический класс, в котором будет хранится информация об объекте "sender", переменной типа RoutedEventArgs и UserControl1 объекте во время первой инициализации интерфейса PdfViewer и его загрузке
    {
        public static object sender;
        public static RoutedEventArgs e;
        public static UserControl1 userControl;
    } 
    public partial class UserControl1 : UserControl
    {

        public UserControl1()
        {
            InitializeComponent();
            InfoAboatBotton.userControl = this;   // Присваиваем полю UserControl1 userControl значение текущего экземпляра объекта UserControl1
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)  // Метод обработчик, который срабатывает когда происходит запуск элемента программы
        {
            InfoAboatBotton.sender = sender;
            InfoAboatBotton.e = e;
        }
        private void ButtonClick(object sender, RoutedEventArgs e)   // Метод обработчик срабатывает при нажатии кнопки поиска в окне PdfViewer 
        {
            var dlg = new OpenFileDialog { DefaultExt = ".pdf", Filter = "PDF documents (.pdf)|*.pdf" };
            dlg.ShowDialog();
            if (!string.IsNullOrEmpty(dlg.FileName))
            {
                txtFileLoaction.Text = dlg.FileName;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)  // Метод обработчик срабатывает при нажатии кнопки открыть в окне PdfViewer 
        {
            if (!string.IsNullOrEmpty(txtFileLoaction.Text))
            {
                pdfViewer.LoadFile(txtFileLoaction.Text);
            }
        }

        public void LookPdfFile(object sender, RoutedEventArgs e)  // Метод обработчик срабатывает при нажатии на кнопку LOOK в основном окне программы 
        {
            if (!string.IsNullOrEmpty(PathFile.pathFile))
            {
                pdfViewer.LoadFile(PathFile.pathFile);
            }
            txtFileLoaction.Text = null;
        }
    }
}
