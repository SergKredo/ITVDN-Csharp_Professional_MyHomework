using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Info.Api.Model;


namespace Currency_Info.ViewModels
{
    class BankOrExchanger : ViewModelBase
    {
        public Org_Types orgTypes;

        public BankOrExchanger(Org_Types org_Types, XmlModel result, CurrencyViewModel currentCurrencies, ref MainViewModel.DictionaryRegion<string, string> iDBanksOrExchangers, ref MainViewModel.DictionaryRegion<string, string> dictionaryCash)
        {
            string IdOrg;
            string IdRegionOrganization;
          
            foreach (var item in result.Organization)
            {
                var items = item.CurrenciesOrganization;
                IdRegionOrganization = (item.RegionOrganization[0] as Organization.RegionOrg).ID;
                IdOrg = item.Org_type;
                foreach (var iten in items)
                {
                    var itep = iten.COrganization;
                    foreach (var iter in itep)
                    {
                        if (iter.ID == currentCurrencies.currencies.ID && org_Types.ID == IdOrg)
                        {
                            this.orgTypes = org_Types;
                            iDBanksOrExchangers.Add(IdOrg,IdRegionOrganization);

                        }
                    }
                }
            }
            foreach (var item in iDBanksOrExchangers)
            {
                foreach (var items in item.Value)
                {
                    dictionaryCash.Add(item.Key, items);
                }
            }
        }

        public string Org_Types
        {
            get
            {
                try
                {
                    if (orgTypes == null)
                    {
                        throw new Exception();
                    }
                    return orgTypes.Title;
                }
                catch
                {
                    return new Org_Types().Title = null;
                }
            }
            set
            {
                orgTypes.Title = value;
                OnPropertyChanged();
            }
        }
    }
}
