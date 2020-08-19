using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionalClassLibraryOld
{
    public class BaseClassOld
    {
        DateTime date;
        string nameCountry;
        string nameCity;

        public BaseClassOld()
        { }
        public BaseClassOld(DateTime date, string nameCountry, string nameCity)
        {
            this.date = date;
            this.nameCountry = nameCountry;
            this.nameCity = nameCity;
        }
        public void ShowMessage()
        {
            ShowDate(date);
            PlaceInTheWorld(nameCountry);
            CityInCountry(nameCity);     
        }
        protected virtual void ShowDate(DateTime date)
        {
            this.date = date;
            Console.WriteLine("Date time: {0}", date);
        }
        protected virtual void PlaceInTheWorld(string nameCountry)
        {
            this.nameCountry = nameCountry;
            Console.WriteLine("Name of the Country: {0}", nameCountry);
        }
        protected virtual void CityInCountry(string nameCity)
        {
            this.nameCity = nameCity;
            Console.WriteLine("Name of the City: {0}", nameCity);
        }
    }
}
