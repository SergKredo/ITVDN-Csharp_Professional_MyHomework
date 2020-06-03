using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace SeacherAndTextViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.Combine(System.IO.Path.GetDirectoryName(location), "sample.pdf");
            pdfViewer.LoadFile(path);
        }

       
    }
}
