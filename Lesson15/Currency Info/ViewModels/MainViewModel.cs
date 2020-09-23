using Currency_Info.ViewModels.Commands;
using Currency_Info.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Currency_Info.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        bool isLoading;
        List<CurrencyViewModel> currencies;
        CurrencyViewModel currentCurrencies;

        public List<CurrencyViewModel> Currencies
        {
            get { return currencies; }
            set
            {
                currencies = value;
                OnPropertyChanged();
            }
        }

        public CurrencyViewModel CurrentCurrencies
        {
            get { return currentCurrencies; }
            set
            {
                currentCurrencies = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }


        public ICommand GetCurrenciesCommand
        {
            get
            {
                return new AsyncCommand(GetCurrencies);
            }
        }

        public async Task GetCurrencies()
        {
            IsLoading = true;
            var api = new CurrencyApi();
            var result = await api.GetXMLModel();
            Currencies = new List<CurrencyViewModel>(result.C.Select(o => new CurrencyViewModel(o)));
            IsLoading = false;
        }
    }
}
