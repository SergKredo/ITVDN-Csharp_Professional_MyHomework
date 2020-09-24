using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency_Info.Api.Model;


namespace Currency_Info.ViewModels
{
    class CityCurrencies : ViewModelBase
    {
        public City city;

        public CityCurrencies(City city, string regions)
        {

            if (regions.StartsWith(city.Title))
            {
                this.city = city;
            }
            else if (regions == "Закарпатская область" & city.Title == "Ужгород")
            {
                this.city = city;
            }         
        }

        public string City
        {
            get
            {
                try
                {
                    if (city == null)
                    {
                        throw new Exception();
                    }
                    return city.Title;
                }
                catch
                {
                    return new City().Title = null;
                }

            }
            set
            {
                city.Title = value;
                OnPropertyChanged();
            }
        }
    }
}
