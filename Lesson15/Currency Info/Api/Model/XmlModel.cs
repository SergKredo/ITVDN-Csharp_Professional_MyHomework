using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Currency_Info.Api.Model
{
    [XmlRoot("source")]  // Атрибут указывает на объект как корень сериализации XML файла
    public class XmlModel  // Класс используемый для сериализации объектов из XML файла с данными об организациях и курсе валют
    {
        [XmlAttribute("id")] // Атрибут указывает на XML атрибут при сериализации объекта, который задает ID данного XML документа
        public string IdSource { get; set; }   // ID базы данных XML документа

        [XmlAttribute("date")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает время последнего обновления данного XML документа
        public string DateSource { get; set; }  // Время обновления базы данных XML документа


        [XmlArray("organizations")]  // Атрибут указывает на XML атрибут как массив XML элементов при сериализации объекта, который задает массив фин. организаций из данного XML документа
        [XmlArrayItem("organization")] // Атрибут представляет производный атрибут "Организации" XML документа, которая находится в массиве XML элементов
        public List<Organization> Organization { get; set; }  // Свойство характеризует список фин.организаций из базы данных XML документа


        [XmlArray("org_types")]  // Атрибут указывает на XML атрибут как массив XML элементов при сериализации объекта, который задает массив типов фин.организаций из данного XML документа
        [XmlArrayItem("org_type")]  // Атрибут представляет производный атрибут "Тип организации" XML документа, которая находится в массиве XML элементов
        public List<Org_Types> Org_Types { get; set; }  // Свойство характеризует список типов фин.организаций из базы данных XML документа


        [XmlArray("currencies")]  // Атрибут указывает на XML атрибут как массив XML элементов при сериализации объекта, который задает массив всех валют из данного XML документа
        [XmlArrayItem("c")]  // Атрибут представляет производный атрибут "Валюта" XML документа, которая находится в массиве XML элементов
        public List<C> C { get; set; }  // Свойство характеризует список валют из базы данных XML документа

        [XmlArray("regions")]  // Атрибут указывает на XML атрибут как массив XML элементов при сериализации объекта, который задает массив всех областей Украины из данного XML документа
        [XmlArrayItem("region")] // Атрибут представляет производный атрибут "Область Украины" XML документа, которая находится в массиве XML элементов
        public List<Region> RegionSource { get; set; }  // Свойство характеризует список областей Украины из базы данных XML документа

        [XmlArray("cities")] // Атрибут указывает на XML атрибут как массив XML элементов при сериализации объекта, который задает массив всех городов Украины из данного XML документа
        [XmlArrayItem("city")]  // Атрибут представляет производный атрибут "Город Украины" XML документа, которая находится в массиве XML элементов
        public List<City> CitySource { get; set; }  // Свойство характеризует список городов Украины из базы данных XML документа

    }

    public class Organization  // Класс содержит основную информацию о данном фин.учреждении на рынке валют Украины
    {
        [XmlAttribute("id")]      // Атрибут указывает на XML атрибут при сериализации объекта, который задает ID данного XML документа
        public string ID { get; set; }  // ID фин.учреждения из базы данных XML документа

        [XmlAttribute("oldid")]   
        public string Oldid { get; set; }

        [XmlAttribute("org_type")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает тип фин.учреждения из базы данных XML документа
        public string Org_type { get; set; }  // Тип фин.учреждения из базы данных XML документа

        [XmlElement("title")]  // Атрибут указывает на XML элемент при сериализации объекта, который задает название фин.учреждения из базы данных XML документа
        public List<Title> TitleOrganization { get; set; }  // Список названий фин.учреждений из базы данных XML документа

        public class Title   // Класс содержит основную информацию о названии фин.учреждении на рынке валют Украины
        {
            [XmlAttribute("value")]  // Атрибут указывает на XML элемент при сериализации объекта, который задает значение названия фин.учреждения из базы данных XML документа
            public string Value { get; set; } // Название фин.учреждения из базы данных XML документа
        }

        [XmlElement("branch")]
        public List<Branch> BranchOrganization { get; set; }

        public class Branch
        {
            [XmlAttribute("value")]
            public string Value { get; set; }
        }

        [XmlElement("region")]  // Атрибут указывает на XML элемент при сериализации объекта, который задает область фин.учреждения из базы данных XML документа
        public List<RegionOrg> RegionOrganization { get; set; }  // Список реальных областей в которых находятся фин.учреждения из базы данных XML документа

        public class RegionOrg  // Класс содержит основную информацию об области в которой находится данное фин.учреждение на рынке валют Украины
        {
            [XmlAttribute("id")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает ID области фин.учреждения из базы данных XML документа
            public string ID { get; set; }  // ID области фин.учреждения из базы данных XML документа
        }

        [XmlElement("city")]  // Атрибут указывает на XML элемент при сериализации объекта, который задает город фин.учреждения из базы данных XML документа
        public List<CityOrg> CityOrganization { get; set; }  // Список городов в которых находятся фин.учреждения из базы данных XML документа

        public class CityOrg  // Класс содержит основную информацию об городе в котором находится данное фин.учреждение на рынке валют Украины
        {
            [XmlAttribute("id")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает ID города фин.учреждения из базы данных XML документа
            public string ID { get; set; }  // ID города фин.учреждения из базы данных XML документа
        }

        [XmlElement("phone")]  // Атрибут указывает на XML элемент при сериализации объекта, который задает номер телефона фин.учреждения из базы данных XML документа
        public List<Phone> PhoneOrganization { get; set; }  // Список номеров телефонов фин.учреждений из базы данных XML документа

        public class Phone  // Класс содержит основную информацию о номере телефоне фин.учреждения на рынке валют Украины
        {
            [XmlAttribute("value")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает значение номера телефона фин.учреждения из базы данных XML документа
            public string Value { get; set; }  // Название номера телефона фин.учреждения из базы данных XML документа
        }

        [XmlElement("address")]  // Атрибут указывает на XML элемент при сериализации объекта, который задает адрес фин.учреждения из базы данных XML документа
        public List<Address> AddressOrganization { get; set; }  // Список адресов фин.учреждений из базы данных XML документа

        public class Address  // Класс содержит основную информацию об адресе фин.учреждения на рынке валют Украины
        {
            [XmlAttribute("value")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает значение адреса фин.учреждения из базы данных XML документа
            public string Value { get; set; }  // Адрес фин.учреждения из базы данных XML документа
        }

        [XmlElement("link")]
        public List<Link> LinkOrganization { get; set; }

        public class Link
        {
            [XmlAttribute("type")]
            public string Type { get; set; }

            [XmlAttribute("href")]
            public string Href { get; set; }
        }

        [XmlElement("currencies")]  // Атрибут указывает на XML элемент при сериализации объекта, который задает значения набора валют фин.учреждения из базы данных XML документа
        public List<Currencies> CurrenciesOrganization { get; set; }  // Список набора валют, которые реализует данное фин.учреждение из базы данных XML документа

        public class Currencies  // Класс содержит основную информацию о валютах фин.учреждения на рынке валют Украины
        {
            [XmlElement("c")]  // Атрибут указывает на XML элемент при сериализации объекта, который задает значения валют фин.учреждения из базы данных XML документа
            public List<COrg> COrganization { get; set; }  // Список валют, которые реализует данное фин.учреждение из базы данных XML документа
            public class COrg  // Класс содержит основную информацию о конкретной валюте фин.учреждения на рынке валют Украины
            {
                [XmlAttribute("id")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает ID валюты фин.учреждения из базы данных XML документа
                public string ID { get; set; }  // ID валюты, которые реализует данное фин.учреждение из базы данных XML документа

                [XmlAttribute("br")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает покупку валюты фин.учреждением из базы данных XML документа
                public string Br { get; set; }  // Денежный эквивалент покупки валюты, которые реализует данное фин.учреждение из базы данных XML документа

                [XmlAttribute("ar")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает продажу валюты фин.учреждением из базы данных XML документа
                public string Ar { get; set; }  // Денежный эквивалент продажи валюты, которые реализует данное фин.учреждение из базы данных XML документа
            }
        }
    }

    public class Org_Types  // Класс содержит основную информацию о типе фин.учреждения на рынке валют Украины
    {
        [XmlAttribute("id")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает ID типа фин.учреждения из базы данных XML документа
        public string ID { get; set; }  // Значение ID фин.учреждения из базы данных XML документа

        [XmlAttribute("title")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает название типа фин.учреждения из базы данных XML документа
        public string Title { get; set; }  // Название типа фин.учреждения из базы данных XML документа
    }


    public class C  // Класс содержит основную информацию о валютах, которые есть рынке валют Украины
    {
        [XmlAttribute("id")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает ID валюты из базы данных XML документа
        public string ID { get; set; }  // Значение ID валюты из базы данных XML документа

        [XmlAttribute("title")]   // Атрибут указывает на XML атрибут при сериализации объекта, который задает название валюты из базы данных XML документа
        public string Title { get; set; }  // Название валюты из базы данных XML документа
    }

    public class Region  // Класс содержит основную информацию об областях, которые есть в базе данных валют Украины
    {
        [XmlAttribute("id")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает ID области из базы данных XML документа
        public string ID { get; set; }  // Значение ID области из базы данных XML документа

        [XmlAttribute("title")]   // Атрибут указывает на XML атрибут при сериализации объекта, который задает название области из базы данных XML документа
        public string Title { get; set; }  // Название области из базы данных XML документа
    }

    public class City   // Класс содержит основную информацию об городах, которые есть в базе данных валют Украины
    {
        [XmlAttribute("id")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает ID города из базы данных XML документа
        public string ID { get; set; }  // Значение ID города из базы данных XML документа

        [XmlAttribute("title")]  // Атрибут указывает на XML атрибут при сериализации объекта, который задает название города из базы данных XML документа
        public string Title { get; set; }   // Название города из базы данных XML документа
    }


    /*
     База данных курса валют в виде XML документа:
    -------------------------------------------------------------------------------------------------------------------------------------------------------------------
<source id="currency-cash" date="2020-09-27T16:10:19+03:00">
<organizations>
<organization id="7oiylpmiow8iy1smaze" oldid="1233" org_type="1">
<title value="А-Банк"/>
<branch value="false"/>
<region id="ua,7oiylpmiow8iy1smaci"/>
<city id="7oiylpmiow8iy1smadm"/>
<phone value="0567220555"/>
<address value="ул. Батумская, 11"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1smaze/cash"/>
<currencies>
<c id="EUR" br="32.5000" ar="33.2000"/>
<c id="USD" br="28.1000" ar="28.4000"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1smau3" oldid="1034" org_type="2">
<title value="Артада"/>
<branch value="false"/>
<region id="ua,0,7oiylpmiow8iy1smadi"/>
<city id="7oiylpmiow8iy1smadi"/>
<phone value="0442372726"/>
<address value="ул.Крещатик, 21, магазин "Золотой век" - 50.4461984, 30.5222477"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1smau3/cash"/>
<currencies>
<c id="AED" br="7.0032" ar="7.0870"/>
<c id="AMD" br="0.0404" ar="0.0540"/>
<c id="AUD" br="19.3200" ar="19.7900"/>
<c id="AZN" br="12.0120" ar="14.0000"/>
<c id="BGN" br="13.5506" ar="15.4995"/>
<c id="BRL" br="5.0106" ar="7.2000"/>
<c id="BYN" br="10.0020" ar="10.2800"/>
<c id="CAD" br="20.7052" ar="20.7900"/>
<c id="CHF" br="30.2000" ar="30.4900"/>
<c id="CLP" br="0.0203" ar="0.0486"/>
<c id="CNY" br="3.5102" ar="3.7450"/>
<c id="CZK" br="1.1823" ar="1.2150"/>
<c id="DKK" br="4.2650" ar="4.3900"/>
<c id="EGP" br="1.4006" ar="1.7000"/>
<c id="EUR" br="32.8000" ar="32.8400"/>
<c id="GBP" br="35.7000" ar="35.8850"/>
<c id="GEL" br="8.0055" ar="9.2400"/>
<c id="HKD" br="2.5113" ar="3.1960"/>
<c id="HRK" br="3.7106" ar="4.3000"/>
<c id="HUF" br="0.0870" ar="0.0920"/>
<c id="ILS" br="7.4606" ar="7.7200"/>
<c id="INR" br="0.2275" ar="0.2956"/>
<c id="JPY" br="0.2560" ar="0.2561"/>
<c id="KRW" br="0.0195" ar="0.0197"/>
<c id="KWD" br="50.0085" ar="87.9995"/>
<c id="KZT" br="0.0649" ar="0.0650"/>
<c id="LBP" br="0.0125" ar="0.0180"/>
<c id="MDL" br="1.4055" ar="1.5970"/>
<c id="MXN" br="1.0079" ar="1.4000"/>
<c id="NOK" br="2.8800" ar="2.9500"/>
<c id="NZD" br="15.5040" ar="17.8500"/>
<c id="PLN" br="7.2205" ar="7.3450"/>
<c id="RON" br="6.0040" ar="6.4900"/>
<c id="RUB" br="0.3620" ar="0.3660"/>
<c id="SAR" br="4.5009" ar="6.9000"/>
<c id="SEK" br="2.9508" ar="3.0800"/>
<c id="SGD" br="16.5107" ar="18.7400"/>
<c id="THB" br="0.5130" ar="0.8460"/>
<c id="TRY" br="3.6060" ar="3.9700"/>
<c id="TWD" br="0.5110" ar="0.8940"/>
<c id="USD" br="28.2500" ar="28.2800"/>
<c id="VND" br="0.0009" ar="0.0011"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1sma7d" oldid="111" org_type="1">
<title value="Креди Агриколь Банк"/>
<branch value="false"/>
<region id="ua,0,7oiylpmiow8iy1smadi"/>
<city id="7oiylpmiow8iy1smadi"/>
<phone value="0442308352"/>
<address value="ул. Пушкинская, 42/4"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1sma7d/cash"/>
<currencies>
<c id="EUR" br="32.8000" ar="33.1500"/>
<c id="RUB" br="0.3450" ar="0.3720"/>
<c id="USD" br="28.1700" ar="28.3700"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1sma6l" oldid="71" org_type="1">
<title value="Кредобанк"/>
<branch value="false"/>
<region id="ua,7oiylpmiow8iy1smac0"/>
<city id="7oiylpmiow8iy1smadr"/>
<phone value="0322659907"/>
<address value="ул. Сахарова, 78"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1sma6l/cash"/>
<currencies>
<c id="EUR" br="32.3500" ar="33.2000"/>
<c id="USD" br="28.1000" ar="28.4000"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1smaar" oldid="261" org_type="1">
<title value="МТБ Банк (Марфин Банк)"/>
<branch value="false"/>
<region id="ua,7oiylpmiow8iy1smacc"/>
<city id="7oiylpmiow8iy1smadk"/>
<phone value="0486824845"/>
<address value="Польский спуск, 11"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1smaar/cash"/>
<currencies>
<c id="EUR" br="32.6000" ar="33.1000"/>
<c id="RUB" br="0.3200" ar="0.3800"/>
<c id="USD" br="28.1500" ar="28.3500"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1smaww" oldid="1143" org_type="2">
<title value="Маржа"/>
<branch value="false"/>
<region id="ua,0,7oiylpmiow8iy1smadi"/>
<city id="7oiylpmiow8iy1smadi"/>
<phone value="0444666699"/>
<address value="ул. Б.Хмельницького 3-Б"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1smaww/cash"/>
<currencies>
<c id="AUD" br="17.9000" ar="19.8000"/>
<c id="BYN" br="8.0000" ar="10.3000"/>
<c id="CAD" br="20.1000" ar="21.0000"/>
<c id="CHF" br="30.0000" ar="30.5000"/>
<c id="CNY" br="3.2000" ar="3.9000"/>
<c id="CZK" br="1.1000" ar="1.2200"/>
<c id="DKK" br="3.5000" ar="4.4000"/>
<c id="EGP" br="1.3000" ar="1.7000"/>
<c id="EUR" br="32.6000" ar="32.9000"/>
<c id="GBP" br="35.3000" ar="36.0000"/>
<c id="HUF" br="0.0720" ar="0.0910"/>
<c id="ILS" br="6.4000" ar="8.1000"/>
<c id="JPY" br="0.2250" ar="0.2670"/>
<c id="KZT" br="0.0480" ar="0.0650"/>
<c id="MDL" br="1.2500" ar="1.6000"/>
<c id="NOK" br="2.4000" ar="2.9500"/>
<c id="PLN" br="7.1000" ar="7.3500"/>
<c id="RON" br="5.6000" ar="6.7000"/>
<c id="RUB" br="0.3550" ar="0.3670"/>
<c id="SEK" br="2.3500" ar="3.1000"/>
<c id="TRY" br="3.4000" ar="4.1000"/>
<c id="USD" br="28.1000" ar="28.2900"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1smopz" oldid="20824" org_type="2">
<title value="ПОВ №112"/>
<branch value="false"/>
<region id="ua,0,7oiylpmiow8iy1smadi"/>
<city id="7oiylpmiow8iy1smadi"/>
<phone value="0443616995"/>
<address value="ул.Большая Васильковская, 112, Аптека «АНЦ» - 50.4235373, 30.5186157"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1smopz/cash"/>
<currencies>
<c id="AED" br="7.0033" ar="7.0870"/>
<c id="AMD" br="0.0405" ar="0.0540"/>
<c id="AUD" br="19.3205" ar="19.7900"/>
<c id="AZN" br="12.0122" ar="13.9800"/>
<c id="BGN" br="13.5507" ar="16.0000"/>
<c id="BRL" br="5.0106" ar="7.1500"/>
<c id="BYN" br="10.0020" ar="10.2800"/>
<c id="CAD" br="20.7053" ar="20.7900"/>
<c id="CHF" br="30.2000" ar="30.4900"/>
<c id="CLP" br="0.0203" ar="0.0486"/>
<c id="CNY" br="3.5103" ar="3.7440"/>
<c id="CZK" br="1.1824" ar="1.2150"/>
<c id="DKK" br="4.2655" ar="4.3900"/>
<c id="EGP" br="1.4007" ar="1.6900"/>
<c id="EUR" br="32.8000" ar="32.8400"/>
<c id="GBP" br="35.7000" ar="35.8800"/>
<c id="GEL" br="8.0056" ar="9.2300"/>
<c id="HKD" br="2.5114" ar="3.1960"/>
<c id="HRK" br="3.7107" ar="4.3000"/>
<c id="HUF" br="0.0900" ar="0.0907"/>
<c id="ILS" br="7.4607" ar="7.7100"/>
<c id="INR" br="0.2275" ar="0.2956"/>
<c id="JPY" br="0.2562" ar="0.2570"/>
<c id="KRW" br="0.0195" ar="0.0197"/>
<c id="KWD" br="50.0085" ar="87.9900"/>
<c id="KZT" br="0.0649" ar="0.0650"/>
<c id="MDL" br="1.4056" ar="1.5970"/>
<c id="MXN" br="1.0079" ar="1.3970"/>
<c id="NOK" br="2.9350" ar="2.9400"/>
<c id="NZD" br="15.5042" ar="17.8500"/>
<c id="PLN" br="7.2205" ar="7.3400"/>
<c id="RON" br="6.0042" ar="6.4900"/>
<c id="RUB" br="0.3620" ar="0.3660"/>
<c id="SAR" br="4.5009" ar="6.8600"/>
<c id="SEK" br="2.9520" ar="3.0790"/>
<c id="SGD" br="16.5108" ar="18.7270"/>
<c id="THB" br="0.5132" ar="0.8460"/>
<c id="TRY" br="3.6062" ar="3.7700"/>
<c id="TWD" br="0.5112" ar="0.8935"/>
<c id="USD" br="28.2500" ar="28.2800"/>
<c id="VND" br="0.0009" ar="0.0011"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1smbwq" oldid="1579" org_type="2">
<title value="ПОВ №24"/>
<branch value="false"/>
<region id="ua,0,7oiylpmiow8iy1smadi"/>
<city id="7oiylpmiow8iy1smadi"/>
<phone value="0997348255"/>
<address value="ул. Антоновича, 131-А"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1smbwq/cash"/>
<currencies>
<c id="AED" br="7.0030" ar="7.0880"/>
<c id="AMD" br="0.0400" ar="0.0540"/>
<c id="AUD" br="19.3100" ar="19.8900"/>
<c id="AZN" br="12.0100" ar="13.9800"/>
<c id="BGN" br="13.5505" ar="15.4995"/>
<c id="BRL" br="5.0103" ar="7.1500"/>
<c id="BYN" br="10.0000" ar="10.2800"/>
<c id="CAD" br="20.7050" ar="20.8700"/>
<c id="CHF" br="30.2000" ar="30.8500"/>
<c id="CNY" br="3.5100" ar="3.7450"/>
<c id="CZK" br="1.1820" ar="1.2300"/>
<c id="DKK" br="4.2100" ar="4.3900"/>
<c id="EGP" br="1.4005" ar="1.4989"/>
<c id="EUR" br="32.8000" ar="32.8490"/>
<c id="GBP" br="35.7000" ar="35.8850"/>
<c id="GEL" br="8.0054" ar="9.2600"/>
<c id="HKD" br="2.5112" ar="3.1960"/>
<c id="HRK" br="3.7105" ar="3.8989"/>
<c id="HUF" br="0.0910" ar="0.0950"/>
<c id="ILS" br="7.4605" ar="7.7500"/>
<c id="INR" br="0.2274" ar="0.2956"/>
<c id="JPY" br="0.2556" ar="0.2560"/>
<c id="KRW" br="0.0195" ar="0.0197"/>
<c id="KZT" br="0.0649" ar="0.0650"/>
<c id="MDL" br="1.4054" ar="1.5980"/>
<c id="MXN" br="1.0078" ar="1.3970"/>
<c id="NOK" br="2.9308" ar="2.9900"/>
<c id="NZD" br="15.5033" ar="17.8500"/>
<c id="PLN" br="7.2200" ar="7.3450"/>
<c id="RON" br="6.0036" ar="6.4900"/>
<c id="RUB" br="0.3620" ar="0.3668"/>
<c id="SAR" br="4.5005" ar="6.8600"/>
<c id="SEK" br="2.9507" ar="3.0800"/>
<c id="SGD" br="16.5105" ar="18.7280"/>
<c id="THB" br="0.5125" ar="0.8460"/>
<c id="TRY" br="3.6050" ar="3.7800"/>
<c id="TWD" br="0.5105" ar="0.8935"/>
<c id="USD" br="28.2500" ar="28.2900"/>
<c id="VND" br="0.0009" ar="0.0011"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1smb0l" oldid="1276" org_type="2">
<title value="ПОВ №8"/>
<branch value="false"/>
<region id="ua,0,7oiylpmiow8iy1smadi"/>
<city id="7oiylpmiow8iy1smadi"/>
<phone value="0671334734"/>
<address value="ул. В. Гетьмана, 12"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1smb0l/cash"/>
<currencies>
<c id="EUR" br="32.7000" ar="32.8400"/>
<c id="GBP" br="35.5002" ar="35.8900"/>
<c id="PLN" br="7.2200" ar="7.4000"/>
<c id="RUB" br="0.3610" ar="0.3670"/>
<c id="USD" br="28.2500" ar="28.2800"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1sma8p" oldid="166" org_type="1">
<title value="Укргазбанк"/>
<branch value="false"/>
<region id="ua,0,7oiylpmiow8iy1smadi"/>
<city id="7oiylpmiow8iy1smadi"/>
<phone value="0442392842"/>
<address value="ул. Богдана Хмельницкого, 16-22"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1sma8p/cash"/>
<currencies>
<c id="EUR" br="32.6000" ar="33.0000"/>
<c id="RUB" br="0.3000" ar="0.3900"/>
<c id="USD" br="28.1500" ar="28.3500"/>
</currencies>
</organization>
<organization id="7oiylpmiow8iy1smnwi" oldid="19794" org_type="2">
<title value="ФК «Премиум Финанс»"/>
<branch value="false"/>
<region id="ua,0,7oiylpmiow8iy1smadi"/>
<city id="7oiylpmiow8iy1smadi"/>
<phone value="0981552274"/>
<address value="бул. Леси Украинки, 24 , магазин "АЛЛО"" - 50.428138, 30.537715"/>
<link type="reference-info" href="http://organizations.finance.ua/ru/info/currency/-/7oiylpmiow8iy1smnwi/cash"/>
<currencies>
<c id="AED" br="7.0032" ar="7.2000"/>
<c id="AMD" br="0.0404" ar="0.0540"/>
<c id="AUD" br="19.3200" ar="19.7900"/>
<c id="AZN" br="12.0120" ar="15.0000"/>
<c id="BGN" br="13.5506" ar="15.4995"/>
<c id="BRL" br="5.0106" ar="7.2000"/>
<c id="BYN" br="10.0020" ar="10.2800"/>
<c id="CAD" br="20.7052" ar="20.7900"/>
<c id="CHF" br="30.2000" ar="30.4900"/>
<c id="CLP" br="0.0203" ar="0.0500"/>
<c id="CNY" br="3.5102" ar="3.7450"/>
<c id="CZK" br="1.1823" ar="1.2200"/>
<c id="DKK" br="4.2650" ar="4.3900"/>
<c id="EGP" br="1.4006" ar="1.7000"/>
<c id="EUR" br="32.8000" ar="32.8400"/>
<c id="GBP" br="35.7000" ar="35.8850"/>
<c id="GEL" br="8.0055" ar="9.2400"/>
<c id="HKD" br="2.5113" ar="3.1960"/>
<c id="HRK" br="3.7106" ar="4.3000"/>
<c id="HUF" br="0.0856" ar="0.0920"/>
<c id="ILS" br="7.4606" ar="7.7200"/>
<c id="INR" br="0.2275" ar="0.2956"/>
<c id="JPY" br="0.2560" ar="0.2561"/>
<c id="KRW" br="0.0195" ar="0.0197"/>
<c id="KWD" br="50.0085" ar="88.0000"/>
<c id="KZT" br="0.0649" ar="0.0650"/>
<c id="LBP" br="0.0125" ar="0.0180"/>
<c id="MDL" br="1.4055" ar="1.5970"/>
<c id="MXN" br="1.0079" ar="1.4000"/>
<c id="NOK" br="2.8800" ar="2.9700"/>
<c id="NZD" br="15.5040" ar="17.9000"/>
<c id="PLN" br="7.2205" ar="7.3450"/>
<c id="RON" br="6.0040" ar="6.4900"/>
<c id="RUB" br="0.3620" ar="0.3660"/>
<c id="SAR" br="4.5009" ar="6.9000"/>
<c id="SEK" br="2.9508" ar="3.0800"/>
<c id="SGD" br="16.5107" ar="18.9500"/>
<c id="THB" br="0.5130" ar="0.8460"/>
<c id="TRY" br="3.6060" ar="3.9700"/>
<c id="TWD" br="0.5110" ar="0.9000"/>
<c id="USD" br="28.2500" ar="28.2800"/>
<c id="VND" br="0.0009" ar="0.0013"/>
</currencies>
</organization>
</organizations>
<org_types>
<org_type id="1" title="Банки"/>
<org_type id="2" title="Обменники"/>
</org_types>
<currencies>
<c id="AED" title="дирхамы ОАЭ"/>
<c id="AMD" title="армянские драмы"/>
<c id="AUD" title="австралийские доллары"/>
<c id="AZN" title="азербайджанские манаты"/>
<c id="BGN" title="болгарские левы"/>
<c id="BRL" title="бразильские реалы"/>
<c id="BYN" title="беларуские рубли"/>
<c id="CAD" title="канадские доллары"/>
<c id="CHF" title="швейцарские франки"/>
<c id="CLP" title="чилийские песо"/>
<c id="CNY" title="юани Женьминьби (Китай)"/>
<c id="CZK" title="чешские кроны"/>
<c id="DKK" title="датские кроны"/>
<c id="EGP" title="египетские фунты"/>
<c id="EUR" title="ЕВРО"/>
<c id="GBP" title="английские фунты стерлингов"/>
<c id="GEL" title="грузинские лари"/>
<c id="HKD" title="гонконгские доллары"/>
<c id="HRK" title="хорватские куны"/>
<c id="HUF" title="венгерские форинты"/>
<c id="ILS" title="израильские шекели"/>
<c id="INR" title="индийские рупии"/>
<c id="JPY" title="японские иены"/>
<c id="KRW" title="воны Республики Корея"/>
<c id="KWD" title="кувейтские динары"/>
<c id="KZT" title="казахские теньге"/>
<c id="LBP" title="ливанские фунты"/>
<c id="MDL" title="молдавские леи"/>
<c id="MXN" title="мексиканские новые песо"/>
<c id="NOK" title="норвежские кроны"/>
<c id="NZD" title="новозеландские доллары"/>
<c id="PLN" title="польские злотые"/>
<c id="RON" title="новые румынские леи"/>
<c id="RUB" title="российские рубли"/>
<c id="SAR" title="риалы Саудовской Аравии"/>
<c id="SEK" title="шведские кроны"/>
<c id="SGD" title="сингапурские доллары"/>
<c id="THB" title="таиландские баты"/>
<c id="TRY" title="новые турецкие лиры"/>
<c id="TWD" title="новые тайванские доллары"/>
<c id="USD" title="доллары США"/>
<c id="VND" title="вьетнамские донги"/>
</currencies>
<regions>
<region id="ua,7oiylpmiow8iy1smaci" title="Днепропетровская область"/>
<region id="ua,0,7oiylpmiow8iy1smadi" title="Киев"/>
<region id="ua,7oiylpmiow8iy1smac0" title="Львовская область"/>
<region id="ua,7oiylpmiow8iy1smacc" title="Одесская область"/>
</regions>
<cities>
<city id="7oiylpmiow8iy1smadm" title="Днепр"/>
<city id="7oiylpmiow8iy1smadi" title="Киев"/>
<city id="7oiylpmiow8iy1smadr" title="Львов"/>
<city id="7oiylpmiow8iy1smadk" title="Одесса"/>
</cities>
</source>
     */
}
