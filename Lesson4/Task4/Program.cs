using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;

namespace Task4
{
    /*Задание 4
Создайте текстовый файл-чек по типу «Наименование товара – 0.00 (цена) грн.» с
определенным количеством наименований товаров и датой совершения покупки. Выведите на
экран информацию из чека в формате текущей локали пользователя и в формате локали en-
US.*/
    class Check : IFormattable
    {
        DateTime dateTime;
        double number, currencyEUR, currencyRUB, currencyUSD;
        long date;
        string textUA, textUS, textRU, textEURO, textDate, text;
        public Check(string text, double currencyEUR, double currencyRUB, double currencyUSD)
        {
            this.textRU = text;
            this.textUA = text;
            this.textUS = text;
            this.textEURO = text;
            this.currencyEUR = currencyEUR;
            this.currencyRUB = currencyRUB;
            this.currencyUSD = currencyUSD;

            string pattern = @"[0-9]{2}/[0-9]{2}/[0-9]{4} [0-9]{2}:[0-9]{2}:[0-9]{2}";
            Regex regex = new Regex(pattern);
            textDate = regex.Match(text).Value;
            DateTime dateOne = DateTime.Parse(regex.Match(text).Value);
            this.date = dateOne.ToFileTimeUtc();
        }
        public string ToString(string format, IFormatProvider provider)
        {
            string textWithSign = null;
            switch (provider.ToString())
            {
                case "ru-RU":
                    {
                        this.text = this.textRU;
                        break;
                    }
                case "en-US":
                    {
                        this.text = this.textUS;
                        break;
                    }
                case "uk-UA":
                    {
                        this.text = this.textUA;
                        break;
                    }
                case "es-ES":
                    {
                        this.text = this.textEURO;
                        break;
                    }
            }


            string pattern = @"(?<numbers>\d+[\,*\.*]\d*)";
            Regex regex = new Regex(pattern);
            foreach (Match item in regex.Matches(this.text))
            {
                textWithSign = item.Groups["numbers"].Value.Replace('.', ',');
                this.number = Convert.ToDouble(textWithSign);
                text = text.Replace(item.ToString(), number.ToString(format, provider));
            }
            text = text.Replace("гр.", "");
            pattern = @"(?<gramm>\d+[.,]*\d*г)|(?<gramm>\d+[.,]*\d*кг)";
            regex = new Regex(pattern);
            foreach (Match items in regex.Matches(text))
            {
                switch (provider.ToString())
                {
                    case "ru-RU":
                    case "uk-UA":
                        {
                            string patter = @"\D+$";
                            Regex regexGKG = new Regex(patter);
                            switch (regexGKG.Match(items.Groups["gramm"].Value).Value)
                            {
                                case "г":
                                    {
                                        this.number = Convert.ToDouble((items.Groups["gramm"].Value.Replace('.', ',')).Replace("г", ""));
                                        string gramm = (number / 1000).ToString("G", provider);
                                        text = text.Replace(items.ToString(), gramm + " кг");
                                        break;
                                    }
                                case "кг":
                                    {
                                        this.number = Convert.ToDouble((items.Groups["gramm"].Value.Replace('.', ',')).Replace("кг", ""));
                                        string gramm = number.ToString("G", provider);
                                        text = text.Replace(items.ToString(), gramm + " кг");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "en-US":
                        {
                            string patter = @"\D+$";
                            Regex regexGKG = new Regex(patter);
                            switch (regexGKG.Match(items.Groups["gramm"].Value).Value)
                            {
                                case "г":
                                    {
                                        this.number = Convert.ToDouble((items.Groups["gramm"].Value.Replace('.', ',')).Replace("г", ""));
                                        string gramm = ((number / 1000) / 0.45359237).ToString("F3", provider);
                                        text = text.Replace(items.ToString(), gramm + " lb");
                                        break;
                                    }
                                case "кг":
                                    {
                                        this.number = Convert.ToDouble((items.Groups["gramm"].Value.Replace('.', ',')).Replace("кг", ""));
                                        string gramm = (number / 0.45359237).ToString("F3", provider);
                                        text = text.Replace(items.ToString(), gramm + " lb");
                                        break;
                                    }
                            }
                            break;
                        }
                    case "es-ES":
                        {
                            string patter = @"\D+$";
                            Regex regexGKG = new Regex(patter);
                            switch (regexGKG.Match(items.Groups["gramm"].Value).Value)
                            {
                                case "г":
                                    {
                                        this.number = Convert.ToDouble((items.Groups["gramm"].Value.Replace('.', ',')).Replace("г", ""));
                                        string gramm = (number / 1000).ToString("G", provider);
                                        text = text.Replace(items.ToString(), gramm + " kg");
                                        break;
                                    }
                                case "кг":
                                    {
                                        this.number = Convert.ToDouble((items.Groups["gramm"].Value.Replace('.', ',')).Replace("кг", ""));
                                        string gramm = number.ToString("G", provider);
                                        text = text.Replace(items.ToString(), gramm + " kg");
                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
            pattern = @"(?<money>\-\ \d+[\,*\.*]\d*)";
            regex = new Regex(pattern);
            foreach (Match items in regex.Matches(text))
            {
                switch (provider.ToString())
                {
                    case "ru-RU":
                        {
                            this.number = Convert.ToDouble((items.Groups["money"].Value.Replace('.', ',')).Replace("- ", ""));
                            text = text.Replace(items.ToString(), "- "+(number/currencyRUB).ToString("C", provider));
                            break;
                        }
                    case "en-US":
                        {
                            this.number = Convert.ToDouble((items.Groups["money"].Value.Replace('.', ',')).Replace("- ", ""));
                            text = text.Replace(items.ToString(), "- " + (number/currencyUSD).ToString("C", provider));
                            break;
                        }
                    case "uk-UA":
                        {
                            this.number = Convert.ToDouble((items.Groups["money"].Value.Replace('.', ',')).Replace("- ", ""));
                            text = text.Replace(items.ToString(), "- " + number.ToString("C", provider));
                            break;
                        }
                    case "es-ES":
                        {
                            this.number = Convert.ToDouble((items.Groups["money"].Value.Replace('.', ',')).Replace("- ", ""));
                            text = text.Replace(items.ToString(), "- " + (number/currencyEUR).ToString("C", provider));
                            break;
                        }
                }            
            }

            pattern = @"(?<percent>\d*\W*\d*%)";
            regex = new Regex(pattern);
            foreach (Match items in regex.Matches(text))
            {
                this.number = Convert.ToDouble((items.Groups["percent"].Value.Replace('.', ',')).Replace("%", ""));
                string percent = " " + (number * 0.01).ToString("P", provider);
                text = text.Replace(items.ToString(), percent);
            }

            dateTime = DateTime.FromFileTimeUtc(this.date);
            text = text.Replace(textDate, dateTime.ToString(provider));

            return text;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            WebClient client = new WebClient(); // Создание экземпляра класса WebClient для обмена данными с ресурсом, заданным URI
            client.Headers["User-Agent"] = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0"; // Автосвойство Headers возвращает или задает коллекцию пар "имя-значение" заголовков, связанных с запросом.
            string siteText = client.DownloadString(@"https://finance.i.ua/").Replace('"', "'"[0]);
            double currencyUSD = 0;
            double currencyRUB = 0;
            double currencyEUR = 0;
            string pattern = @"(?<currencyUSD>\'{1}USD\W{4}\w+\W+\d+\.*\d+)";
            Regex regex = new Regex(pattern);
            foreach (Match item in regex.Matches(siteText))
            {
                string patter = @"\d+\.*\d+";
                Regex regexCurrency = new Regex(patter);
                currencyUSD += Convert.ToDouble(regexCurrency.Match(item.Groups["currencyUSD"].Value).Value.Replace('.', ','));
            }
            currencyUSD /= regex.Matches(siteText).Count;
            
            pattern = @"(?<currencyEUR>\'{1}EUR\W{4}\w+\W+\d+\.*\d+)";
            regex = new Regex(pattern);
            foreach (Match item in regex.Matches(siteText))
            {
                string patter = @"\d+\.*\d+";
                Regex regexCurrency = new Regex(patter);
                currencyEUR += Convert.ToDouble(regexCurrency.Match(item.Groups["currencyEUR"].Value).Value.Replace('.', ','));
            }
            currencyEUR /= regex.Matches(siteText).Count;
            
            pattern = @"(?<currencyRUB>\'{1}RUB\W{4}\w+\W+\d+\.*\d+)";
            regex = new Regex(pattern);
            int countRUB = 0;
            foreach (Match item in regex.Matches(siteText))
            {
                string patter = @"[0]\.*\d+";
                Regex regexCurrency = new Regex(patter);
                if (regexCurrency.IsMatch(item.Groups["currencyRUB"].Value))
                {
                    currencyRUB += Convert.ToDouble(regexCurrency.Match(item.Groups["currencyRUB"].Value).Value.Replace('.', ','));
                    countRUB++;
                }
            }
            currencyRUB /= countRUB;
           
            CultureInfo[] cultureInfos = CultureInfo.GetCultures(CultureTypes.AllCultures);
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            //foreach (var item in cultureInfos)
            //{
            //    Console.WriteLine(item.EnglishName + " - " + item.Name + " - " + item.NumberFormat.CurrencySymbol + 
            //    " - " + (DateTimeFormatInfo.GetInstance(CultureInfo.CreateSpecificCulture(item.Name))).ShortDatePattern + 
            //    " - "+(DateTimeFormatInfo.GetInstance(CultureInfo.CreateSpecificCulture(item.Name))).LongTimePattern);
            //}
            string text = File.ReadAllText(@"The check.txt");
            Check check = new Check(text, currencyEUR, currencyRUB, currencyUSD);
            Console.WriteLine("File locale:\n\n{0}", text);
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Russian locale:\n\n{0}", check.ToString("G", CultureInfo.CreateSpecificCulture("ru-RU")));
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("USA locale:\n\n{0}", check.ToString("G", CultureInfo.CreateSpecificCulture("en-US")));
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Ukrainian locale:\n\n{0}", check.ToString("G", CultureInfo.CreateSpecificCulture("uk-UA")));
            Console.WriteLine(new string('-', 100));
            Console.WriteLine("Spanish locale:\n\n{0}", check.ToString("G", CultureInfo.CreateSpecificCulture("es-ES")));
            Console.WriteLine(new string('-', 100));
            Console.ReadKey();
        }
    }
}

/*
 Results:

    File locale:

Дата покупки: 29/06/2020 15:44:23

Печиво Буратіно з горіхами вагове Конті         0,604кг   - 36,67гр.
Стегно курчати вагове                           1,082кг   - 73,47гр.
Філе курчати вагове                             1,150кг   - 98,89гр.
Форель суповий набір охолоджений                0,402кг   - 2800,14гр.
Морозиво Ескімо пломбір в глазурі               2шт       - 192,18гр.
Плетінка з крихтою 300г в плівці Кулиничі       1шт       - 14,61гр.
Хлібці хрусткі Луганці Три злаки                1шт       - 10,69гр.
Кунжут ваговий Даринка                          0,162кг   - 20,53гр.
Банан свіжий                                    1,388кг   - 41,43гр.
Цибуля Марс вагова                              0,912кг   - 21,86гр.
Корінь селери ваговий                           0,418кг   - 7,28гр.
Морква вагова                                   0,884кг   - 14,73гр.
Картопля молода вагова                          2,148кг   - 32,20гр.
Макаронні вироби Спіральки 500г                 1шт       - 24,47гр.
Шоколад молочний 85г Корона                     1шт       - 16,49гр.
Яйце куряче С0 столове                          30шт      - 560,70гр.
Сметана 15% 400г Яготинська                     1шт       - 27,77гр.
Сир кисломолочний дитячий 4,5%                  2шт       - 24,90гр.
Молоко питне пастеризоване 2,5%                 3шт       - 56,07гр.
----------------------------------------------------------------------------------------------------
Russian locale:

Дата покупки: 29.06.2020 15:44:23

Печиво Буратіно з горіхами вагове Конті         0,604 кг   - 107,68 ₽
Стегно курчати вагове                           1,082 кг   - 215,74 ₽
Філе курчати вагове                             1,15 кг   - 290,38 ₽
Форель суповий набір охолоджений                0,402 кг   - 8 222,37 ₽
Морозиво Ескімо пломбір в глазурі               2шт       - 564,32 ₽
Плетінка з крихтою 0,3 кг в плівці Кулиничі     1шт       - 42,90 ₽
Хлібці хрусткі Луганці Три злаки                1шт       - 31,39 ₽
Кунжут ваговий Даринка                          0,162 кг   - 60,28 ₽
Банан свіжий                                    1,388 кг   - 121,66 ₽
Цибуля Марс вагова                              0,912 кг   - 64,19 ₽
Корінь селери ваговий                           0,418 кг   - 21,38 ₽
Морква вагова                                   0,884 кг   - 43,25 ₽
Картопля молода вагова                          2,148 кг   - 94,55 ₽
Макаронні вироби Спіральки 0,5 кг                 1шт       - 71,85 ₽
Шоколад молочний 0,085 кг Корона                     1шт       - 48,42 ₽
Яйце куряче С0 столове                          30шт      - 1 646,45 ₽
Сметана 15,00% 0,4 кг Яготинська                     1шт       - 81,54 ₽
Сир кисломолочний дитячий  4,50%                  2шт       - 73,12 ₽
Молоко питне пастеризоване  2,50%                 3шт       - 164,64 ₽
----------------------------------------------------------------------------------------------------
USA locale:

Дата покупки: 6/29/2020 3:44:23 PM

Печиво Буратіно з горіхами вагове Конті         1.332 lb   - $1.38
Стегно курчати вагове                           2.385 lb   - $2.77
Філе курчати вагове                             2.535 lb   - $3.72
Форель суповий набір охолоджений                0.886 lb   - $105.41
Морозиво Ескімо пломбір в глазурі               2шт       - $7.23
Плетінка з крихтою 0.661 lb в плівці Кулиничі   1шт       - $0.55
Хлібці хрусткі Луганці Три злаки                1шт       - $0.40
Кунжут ваговий Даринка                          0.357 lb   - $0.77
Банан свіжий                                    3.060 lb   - $1.56
Цибуля Марс вагова                              2.011 lb   - $0.82
Корінь селери ваговий                           0.922 lb   - $0.27
Морква вагова                                   1.949 lb   - $0.55
Картопля молода вагова                          4.736 lb   - $1.21
Макаронні вироби Спіральки 1.102 lb                 1шт       - $0.92
Шоколад молочний 0.187 lb Корона                     1шт       - $0.62
Яйце куряче С0 столове                          30шт      - $21.11
Сметана 15.00 % 0.882 lb Яготинська                     1шт       - $1.05
Сир кисломолочний дитячий  4.50 %                  2шт       - $0.94
Молоко питне пастеризоване  2.50 %                 3шт       - $2.11
----------------------------------------------------------------------------------------------------
Ukrainian locale:

Дата покупки: 29.06.2020 15:44:23

Печиво Буратіно з горіхами вагове Конті         0,604 кг   - 36,67 ₴
Стегно курчати вагове                           1,082 кг   - 73,47 ₴
Філе курчати вагове                             1,15 кг   - 98,89 ₴
Форель суповий набір охолоджений                0,402 кг   - 2 800,14 ₴
Морозиво Ескімо пломбір в глазурі               2шт       - 192,18 ₴
Плетінка з крихтою 0,3 кг в плівці Кулиничі     1шт       - 14,61 ₴
Хлібці хрусткі Луганці Три злаки                1шт       - 10,69 ₴
Кунжут ваговий Даринка                          0,162 кг   - 20,53 ₴
Банан свіжий                                    1,388 кг   - 41,43 ₴
Цибуля Марс вагова                              0,912 кг   - 21,86 ₴
Корінь селери ваговий                           0,418 кг   - 7,28 ₴
Морква вагова                                   0,884 кг   - 14,73 ₴
Картопля молода вагова                          2,148 кг   - 32,20 ₴
Макаронні вироби Спіральки 0,5 кг                 1шт       - 24,47 ₴
Шоколад молочний 0,085 кг Корона                     1шт       - 16,49 ₴
Яйце куряче С0 столове                          30шт      - 560,70 ₴
Сметана 15,00% 0,4 кг Яготинська                     1шт       - 27,77 ₴
Сир кисломолочний дитячий  4,50%                  2шт       - 24,90 ₴
Молоко питне пастеризоване  2,50%                 3шт       - 56,07 ₴
----------------------------------------------------------------------------------------------------
Spanish locale:

Дата покупки: 29/06/2020 15:44:23

Печиво Буратіно з горіхами вагове Конті         0,604 kg   - 1,24 €
Стегно курчати вагове                           1,082 kg   - 2,48 €
Філе курчати вагове                             1,15 kg   - 3,34 €
Форель суповий набір охолоджений                0,402 kg   - 94,53 €
Морозиво Ескімо пломбір в глазурі               2шт       - 6,49 €
Плетінка з крихтою 0,3 kg в плівці Кулиничі     1шт       - 0,49 €
Хлібці хрусткі Луганці Три злаки                1шт       - 0,36 €
Кунжут ваговий Даринка                          0,162 kg   - 0,69 €
Банан свіжий                                    1,388 kg   - 1,40 €
Цибуля Марс вагова                              0,912 kg   - 0,74 €
Корінь селери ваговий                           0,418 kg   - 0,25 €
Морква вагова                                   0,884 kg   - 0,50 €
Картопля молода вагова                          2,148 kg   - 1,09 €
Макаронні вироби Спіральки 0,5 kg                 1шт       - 0,83 €
Шоколад молочний 0,085 kg Корона                     1шт       - 0,56 €
Яйце куряче С0 столове                          30шт      - 18,93 €
Сметана 15,00 % 0,4 kg Яготинська                     1шт       - 0,94 €
Сир кисломолочний дитячий  4,50 %                  2шт       - 0,84 €
Молоко питне пастеризоване  2,50 %                 3шт       - 1,89 €
----------------------------------------------------------------------------------------------------

     */
