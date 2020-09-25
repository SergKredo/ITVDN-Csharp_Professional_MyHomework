using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Info.Api.Model;


namespace Currency_Info.ViewModels
{
    class Organizations : ViewModelBase
    {
        public Organization organization;

        public Organizations(Organization organization, XmlModel result, CurrencyViewModel currentCurrencies, ref MainViewModel.DictionaryRegion<string, string> iDBanksOrExchangers, ref MainViewModel.DictionaryRegion<string, string> dictionaryCash)
        {
            this.organization = organization;
        }

        public string Date
        {
            get
            {
                return null;
            }
            set
            {
                organization.ID = value;
                OnPropertyChanged();
            }
        }
    }
}
