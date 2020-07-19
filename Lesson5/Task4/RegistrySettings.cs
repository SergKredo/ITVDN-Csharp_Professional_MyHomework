using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;
using System.Configuration;
using System.Reflection;
using System.IO;

namespace Task4
{
    class RegistrySettings:ISetting
    {
        public Brush TextColor { get; set; }
        public Brush BackgroundColor { get; set; }
        public int TextSize { get; set; }
        public FontFamily TextFontStyle { get; set; }

        public void SaveSettings()
        {

        }
    }
}
