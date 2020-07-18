using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Task4
{
    interface ISetting
    {
        Brush TextColor { get; set; }
        Brush BackgroundColor { get; set; }
        int TextSize { get; set; }
        FontFamily TextFontStyle { get; set; }

        void SaveSettings();
    }
}
