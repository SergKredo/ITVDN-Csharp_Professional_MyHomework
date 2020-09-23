using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Info.Api.Model;

namespace Currency_Info.ViewModels
{
    class CurrencyViewModel : ViewModelBase
    {
        public C currencies;
        public CurrencyViewModel(C currencies)
        {
            this.currencies = currencies;
        }

        public string CurrentCurrencies
        {
            get { return currencies.Title; }
            set
            {
                currencies.Title = value;
                OnPropertyChanged();
            }
        }
    }
}
