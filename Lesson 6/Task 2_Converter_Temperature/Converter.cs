using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Converter_Temperature
{
    public abstract class Converter
    {
        protected decimal TemperatureCelcia;
        protected decimal TempetaruteFarinhate;
        protected decimal TemperatureKelvine;

        protected Converter()
        {

        }

        protected decimal ConverterToCelcia()
        {
            return 12;
        }

        protected decimal ConverterToFarinhate()
        {
            return 12;
        }

        protected decimal ConverterToKelvine()
        {
            return 12;
        }
    }
}
