using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace SeacherAndTextViewer
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    /// 
    public static class InfoAboatBotton
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
            InfoAboatBotton.userControl = this;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            InfoAboatBotton.sender = sender;
            InfoAboatBotton.e = e;
        }
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog { DefaultExt = ".pdf", Filter = "PDF documents (.pdf)|*.pdf" };
            dlg.ShowDialog();
            if (!string.IsNullOrEmpty(dlg.FileName))
            {
                txtFileLoaction.Text = dlg.FileName;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFileLoaction.Text))
            {
                pdfViewer.LoadFile(txtFileLoaction.Text);
            }
        }

        public void LookPdfFile(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PathFile.pathFile))
            {
                pdfViewer.LoadFile(PathFile.pathFile);
            }
            txtFileLoaction.Text = null;
        }
    }
}
