using Currency_Info.ViewModels.Commands;
using Currency_Info.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Currency_Info.Api.Model;

namespace Currency_Info.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        static public XmlModel result;
        static public DictionaryRegion<string, string> iDBanksOrExchangers;
        static public DictionaryRegion<string, string> dictionaryCash;
        static public List<Region> regions;
        static public List<Region> regionsCash;
        bool isLoading;
        List<CurrencyViewModel> currencies;
        CurrencyViewModel currentCurrencies;

        List<BankOrExchanger> bankOrExchangers;
        BankOrExchanger bankOr;

        List<RegionCurrencies> regionCurrencies;
        RegionCurrencies region;


        List<CityCurrencies> cityCurrencies;
        CityCurrencies city;


        List<ListOfBanksOrExchangers> listOfBanksOrExchangers;
        ListOfBanksOrExchangers exchangers;

        public List<ListOfBanksOrExchangers> ListOfBanksOrExchangers
        {
            get
            {
                List<ListOfBanksOrExchangers> listOfBanksOrNew = new List<ListOfBanksOrExchangers>();
                if (listOfBanksOrExchangers != null)
                {
                    for (int i = 0; i < listOfBanksOrExchangers.Count; i++)
                    {
                        listOfBanksOrNew.Add(listOfBanksOrExchangers[i]);
                    }
                    foreach (var item in listOfBanksOrExchangers)
                    {
                        if (item.ListBanksOrExchangers == null)
                        {
                            listOfBanksOrNew.Remove(item);
                        }
                    }
                    listOfBanksOrExchangers = listOfBanksOrNew;
                }
                return listOfBanksOrExchangers;
            }
            set
            {
                listOfBanksOrExchangers = value;
                OnPropertyChanged();
            }
        }

        public ListOfBanksOrExchangers ListOfBanksOr
        {
            get { return exchangers; }
            set
            {
                exchangers = value;
                OnPropertyChanged();
            }
        }


        public List<CityCurrencies> CityCurrencies
        {
            get
            {
                List<CityCurrencies> cityCurrenciesNew = new List<CityCurrencies>();
                if (cityCurrencies != null)
                {
                    for (int i = 0; i < cityCurrencies.Count; i++)
                    {
                        cityCurrenciesNew.Add(cityCurrencies[i]);
                    }
                    foreach (var item in cityCurrencies)
                    {
                        if (item.City == null)
                        {
                            cityCurrenciesNew.Remove(item);
                        }
                    }
                    cityCurrencies = cityCurrenciesNew;
                }

                return cityCurrencies;
            }
            set
            {
                cityCurrencies = value;
                OnPropertyChanged();
            }
        }

        public CityCurrencies City
        {
            get { return city; }
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }


        public List<RegionCurrencies> RegionCurrencies
        {
            get
            {
                List<RegionCurrencies> regionCurrenciesNew = new List<RegionCurrencies>();
                if (regionCurrencies != null)
                {
                    for (int i = 0; i < regionCurrencies.Count; i++)
                    {
                        regionCurrenciesNew.Add(regionCurrencies[i]);
                    }
                    foreach (var item in regionCurrencies)
                    {
                        if (item.Region == null)
                        {
                            regionCurrenciesNew.Remove(item);
                        }
                    }
                    return regionCurrencies = regionCurrenciesNew;
                }
                return regionCurrencies;
            }
            set
            {
                regionCurrencies = value;
                OnPropertyChanged();
            }
        }

        public RegionCurrencies Region
        {
            get
            {
                if (regionCurrencies != null)
                {
                    CityCurrencies = new List<CityCurrencies>(result.CitySource.Select(o => new CityCurrencies(o, region.region.Title)));
                    ListOfBanksOrExchangers = new List<ListOfBanksOrExchangers>(result.Organization.Select(o => new ListOfBanksOrExchangers(o, currentCurrencies.currencies.ID, bankOr.orgTypes.ID, city.city.ID)));
                }
                return region;
            }
            set
            {
                region = value;
                OnPropertyChanged();
            }
        }

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
                iDBanksOrExchangers = new DictionaryRegion<string, string>();
                dictionaryCash = new DictionaryRegion<string, string>();
                regions = new List<Region>();
                regionsCash = new List<Region>();
                regionsCash = result.RegionSource;
                BankOrExchangers = new List<BankOrExchanger>(result.Org_Types.Select(o => new BankOrExchanger(o, result, currentCurrencies, ref iDBanksOrExchangers, ref dictionaryCash)));
                RegionCurrencies = new List<RegionCurrencies>(result.RegionSource.Select(o => new RegionCurrencies(o, iDBanksOrExchangers)));

                OnPropertyChanged();
            }
        }

        public List<BankOrExchanger> BankOrExchangers
        {
            get
            {
                if (bankOrExchangers != null && bankOrExchangers[0].orgTypes == null)
                {
                    bankOrExchangers.RemoveAt(0);
                }
                return bankOrExchangers;
            }
            set
            {
                bankOrExchangers = value;
                OnPropertyChanged();
            }
        }
        public BankOrExchanger BankOr
        {
            get
            {
                if (bankOr != null)
                {
                    switch (bankOr.orgTypes.ID)
                    {
                        case "1":
                            {
                                DictionaryRegion<string, string> dictionaryForOne = new DictionaryRegion<string, string>();
                                foreach (var item in dictionaryCash)
                                {
                                    foreach (var items in item.Value)
                                    {
                                        dictionaryForOne.Add(item.Key, items);
                                    }
                                }
                                iDBanksOrExchangers = dictionaryForOne;
                                iDBanksOrExchangers.Remove("2");
                                RegionCurrencies = new List<RegionCurrencies>(result.RegionSource.Select(o => new RegionCurrencies(o, iDBanksOrExchangers)));
                                return bankOr;
                            }

                        case "2":
                            {
                                DictionaryRegion<string, string> dictionaryForTwo = new DictionaryRegion<string, string>();
                                foreach (var item in dictionaryCash)
                                {
                                    foreach (var items in item.Value)
                                    {
                                        dictionaryForTwo.Add(item.Key, items);
                                    }
                                }
                                iDBanksOrExchangers = dictionaryForTwo;
                                iDBanksOrExchangers.Remove("1");
                                RegionCurrencies = new List<RegionCurrencies>(result.RegionSource.Select(o => new RegionCurrencies(o, iDBanksOrExchangers)));
                                return bankOr;
                            }
                        default:
                            return bankOr;
                    }
                }
                return bankOr;
            }
            set
            {
                bankOr = value;
                if (bankOr.Org_Types == null)
                {
                    return;
                }
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

        public class DictionaryRegion<TKey, TValue> : Dictionary<TKey, List<TValue>>
        {
            public void Add(TKey key, TValue value)
            {
                if (ContainsKey(key))
                {
                    this[key].Add(value);
                }
                else
                {
                    Add(key, new List<TValue> { value });
                }
            }
        }


        public async Task GetCurrencies()
        {
            IsLoading = true;
            var api = new CurrencyApi();
            result = await api.GetXMLModel();
            Currencies = new List<CurrencyViewModel>(result.C.Select(o => new CurrencyViewModel(o)));
            IsLoading = false;
        }
    }
}
