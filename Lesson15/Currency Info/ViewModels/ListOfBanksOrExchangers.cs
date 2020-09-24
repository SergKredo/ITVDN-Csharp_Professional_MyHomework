using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Info.Api.Model;


namespace Currency_Info.ViewModels
{
    class ListOfBanksOrExchangers : ViewModelBase
    {
        public Organization organization;

        public ListOfBanksOrExchangers(Organization organization, string currenciesID, string bankOrgTypesID, string cityID)
        {

            foreach (var item in organization.CurrenciesOrganization)
            {
                foreach (var items in item.COrganization)
                {
                    if (items.ID == currenciesID && organization.CityOrganization[0].ID == cityID && organization.Org_type == bankOrgTypesID)
                    {
                        this.organization = organization;
                    }
                }
            }
        }

        public string ListBanksOrExchangers
        {
            get
            {
                try
                {
                    if (organization == null)
                    {
                        throw new Exception();
                    }
                    return organization.TitleOrganization[0].Value;
                }
                catch
                {                   
                    return null;
                }

            }
            set
            {
                organization.TitleOrganization[0].Value = value;
                OnPropertyChanged();
            }
        }
    }
}
