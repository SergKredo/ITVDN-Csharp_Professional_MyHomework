using Currency_Info.ViewModels.Commands;
using Currency_Info.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Currency_Info.Api.Model;
using System.Windows;
using System.Threading;

namespace Currency_Info.ViewModels
{
    /*
     ********************VIEWMODEL*********************************************
ViewModel или модель представления связывает модель и представление через механизм привязки данных. 
Если в модели изменяются значения свойств, при реализации моделью интерфейса INotifyPropertyChanged автоматически идет изменение 
отображаемых данных в представлении, хотя напрямую модель и представление не связаны.
ViewModel также содержит логику по получению данных из модели, которые потом передаются в представление. И также VewModel определяет логику 
по обновлению данных в модели.
Поскольку элементы представления, то есть визуальные компоненты типа кнопок, не используют события, то представление взаимодействует с ViewModel посредством команд.
Например, пользователь хочет сохранить введенные в текстовое поле данные. Он нажимает на кнопку и тем самым отправляет команду во ViewModel. А ViewModel уже получает
переданные данные и в соответствии с ними обновляет модель.
Итогом применения паттерна MVVM является функциональное разделение приложения на три компонента, которые проще разрабатывать и тестировать, а также в
дальнейшем модифицировать и поддерживать.
     */

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


        List<OrganizationsData> listOfOrganizations;
        OrganizationsData organizations;

        List<DateSource> listDateXml;
        DateSource xmlModelDate;

        ErrorServer errorServer;

        public ErrorServer ErrorServer
        {
            get { return errorServer; }
            set
            {
                errorServer = value;
                OnPropertyChanged();
            }
        }

        public DateSource DateSourceXml
        {
            get { return xmlModelDate; }
            set
            {
                xmlModelDate = value;
                OnPropertyChanged();
            }
        }

        public OrganizationsData Organizations
        {
            get { return organizations; }
            set
            {
                organizations = value;
                OnPropertyChanged();
            }
        }

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
            get
            {
                if (exchangers != null)
                {
                    Organizations = new OrganizationsData(exchangers, currentCurrencies);
                }
                return exchangers;
            }
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


        public ICommand GetCurrenciesCommand  // Использование команд для реализации шаблона MVVM
        {
            get
            {
                return new AsyncCommand(GetCurrencies);
            }
        }

        public class DictionaryRegion<TKey, TValue> : Dictionary<TKey, List<TValue>>  // Пользовательский класс типа Dictionary<TKey, TValue>. Класс позволяет хранить несколько значений одинаковых ключей
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
            DateSourceXml = new DateSource(result);
            try
            {
                if (!Trig.Triger)
                {
                    Currencies = new List<CurrencyViewModel>(result.C.Select(o => new CurrencyViewModel(o)));
                    ErrorServer = new ErrorServer();
                    ErrorServer.ErrorServ = null;
                }
                else
                {
                    Currencies = new List<CurrencyViewModel>(result.C.Select(o => new CurrencyViewModel(o)));
                    ErrorServer = new ErrorServer();
                }
            }
            catch
            {
                Currencies = null;
                ErrorServer = new ErrorServer();
            }
            IsLoading = false;
        }
    }
}
