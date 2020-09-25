using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Info.Api.Model;


namespace Currency_Info.ViewModels
{
    class DateSource : ViewModelBase
    {
        public XmlModel xmlModel;

        public DateSource(XmlModel xmlModel)
        {
            this.xmlModel = xmlModel;
        }

        public string Date
        {
            get
            {
                DateTime date = DateTime.Parse(xmlModel.DateSource);
                return date.ToLongTimeString()+" , "+ date.Date.ToLongDateString();
            }
            set
            {
                xmlModel.DateSource = value;
                OnPropertyChanged();
            }
        }
    }
}
