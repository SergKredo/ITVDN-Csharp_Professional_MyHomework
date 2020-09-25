using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Info.Api.Model;


namespace Currency_Info.ViewModels
{
    class OrganizationsData : ViewModelBase
    {
        public ListOfBanksOrExchangers exchangers;
        public CurrencyViewModel currentCurrencies;
        public OrganizationsData(ListOfBanksOrExchangers exchangers, CurrencyViewModel currentCurrencies)
        {
            this.exchangers = exchangers;
            this.currentCurrencies = currentCurrencies;
        }

        public string TitleOrganization
        {
            get
            {
                return this.exchangers.organization.TitleOrganization[0].Value;
            }
            set
            {
                this.exchangers.organization.TitleOrganization[0].Value = value;
                OnPropertyChanged();
            }
        }

        public string AdressOrganization
        {
            get
            {
                return this.exchangers.organization.AddressOrganization[0].Value;
            }
            set
            {
                this.exchangers.organization.AddressOrganization[0].Value = value;
                OnPropertyChanged();
            }
        }

        public string PhoneOrganization
        {
            get
            {
                return this.exchangers.organization.PhoneOrganization[0].Value;
            }
            set
            {
                this.exchangers.organization.PhoneOrganization[0].Value = value;
                OnPropertyChanged();
            }
        }

        public string IDCurrenciesOrganization
        {
            get
            {
                foreach (var item in this.exchangers.organization.CurrenciesOrganization[0].COrganization)
                {
                    if (item.ID == currentCurrencies.currencies.ID)
                    {
                        return item.ID;
                    }
                }
                return null;
            }
            set
            {
                foreach (var item in this.exchangers.organization.CurrenciesOrganization[0].COrganization)
                {
                    if (item.ID == currentCurrencies.currencies.ID)
                    {
                        item.ID = value;
                    }
                }
                OnPropertyChanged();
            }
        }

        public string BuyCurrenciesOrganization
        {
            get
            {
                foreach (var item in this.exchangers.organization.CurrenciesOrganization[0].COrganization)
                {
                    if (item.ID == currentCurrencies.currencies.ID)
                    {
                        return item.Br;
                    }
                }
                return null;
            }
            set
            {
                foreach (var item in this.exchangers.organization.CurrenciesOrganization[0].COrganization)
                {
                    if (item.ID == currentCurrencies.currencies.ID)
                    {
                        item.Br = value;
                    }
                }
                OnPropertyChanged();
            }
        }

        public string SellCurrenciesOrganization
        {
            get
            {
                foreach (var item in this.exchangers.organization.CurrenciesOrganization[0].COrganization)
                {
                    if (item.ID == currentCurrencies.currencies.ID)
                    {
                        return item.Ar;
                    }
                }
                return null;
            }
            set
            {
                foreach (var item in this.exchangers.organization.CurrenciesOrganization[0].COrganization)
                {
                    if (item.ID == currentCurrencies.currencies.ID)
                    {
                        item.Ar = value;
                    }
                }
                OnPropertyChanged();
            }
        }
    }
}
