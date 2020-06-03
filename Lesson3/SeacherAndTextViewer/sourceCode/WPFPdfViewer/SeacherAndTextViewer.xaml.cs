using System.Windows.Controls;

namespace WPFPdfViewer
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class SeacherAndTextViewer : UserControl
    {
        public SeacherAndTextViewer()
        {
            InitializeComponent();
            _winFormPdfHost = pdfHost.Child as WinFormPdfHost;
        }


        public string PdfPath
        {
            get { return _pdfPath; }
            set
            {
                _pdfPath = value;
                LoadFile(_pdfPath);
            }
        }

        public bool ShowToolBar
        {
            get { return _showToolBar; }
            set
            {
                _showToolBar = value;
                _winFormPdfHost.SetShowToolBar(_showToolBar);
            }
        }


        public void LoadFile(string path)
        {
            _pdfPath = path;
            _winFormPdfHost.LoadFile(path);
        }

        private string _pdfPath;
        private bool _showToolBar;
        private readonly WinFormPdfHost _winFormPdfHost;
    }
}
