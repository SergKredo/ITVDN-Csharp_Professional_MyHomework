using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Task4
{
    class ConfigSettings: ISetting
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
