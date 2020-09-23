using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Currency_Info.Api.Model
{
    [XmlRoot("source")]
    public class XmlModel
    {
        [XmlAttribute("id")]
        public string IdSource { get; set; }

        [XmlAttribute("date")]
        public string DateSource { get; set; }


        [XmlArray("organizations")]
        [XmlArrayItem("organization")]
        public List<Organization> Organization { get; set; }


        [XmlArray("org_types")]
        [XmlArrayItem("org_type")]
        public List<Org_Types> Org_Types { get; set; }


        [XmlArray("currencies")]
        [XmlArrayItem("c")]
        public List<C> C { get; set; }

        [XmlArray("regions")]
        [XmlArrayItem("region")]
        public List<Region> RegionSource { get; set; }

        [XmlArray("cities")]
        [XmlArrayItem("city")]
        public List<City> CitySource { get; set; }

    }

    public class Organization
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlAttribute("oldid")]
        public string Oldid { get; set; }

        [XmlAttribute("org_type")]
        public string Org_type { get; set; }

        [XmlElement("title")]
        public List<Title> TitleOrganization { get; set; }

        public class Title
        {
            [XmlAttribute("value")]
            public string Value { get; set; }
        }

        [XmlElement("branch")]
        public List<Branch> BranchOrganization { get; set; }

        public class Branch
        {
            [XmlAttribute("value")]
            public string Value { get; set; }
        }

        [XmlElement("region")]
        public List<RegionOrg> RegionOrganization { get; set; }

        public class RegionOrg
        {
            [XmlAttribute("id")]
            public string ID { get; set; }
        }

        [XmlElement("city")]
        public List<CityOrg> CityOrganization { get; set; }

        public class CityOrg
        {
            [XmlAttribute("id")]
            public string ID { get; set; }
        }

        [XmlElement("phone")]
        public List<Phone> PhoneOrganization { get; set; }

        public class Phone
        {
            [XmlAttribute("value")]
            public string Value { get; set; }
        }

        [XmlElement("address")]
        public List<Address> AddressOrganization { get; set; }

        public class Address
        {
            [XmlAttribute("value")]
            public string Value { get; set; }
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

        [XmlElement("currencies")]
        public List<Currencies> CurrenciesOrganization { get; set; }

        public class Currencies
        {
            [XmlElement("c")]
            public List<COrg> COrganization { get; set; }
            public class COrg
            {
                [XmlAttribute("id")]
                public string ID { get; set; }

                [XmlAttribute("br")]
                public string Br { get; set; }

                [XmlAttribute("ar")]
                public string Ar { get; set; }
            }
        }
    }

    public class Org_Types
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }

    public class C
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }

    public class Region
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }

    public class City
    {
        [XmlAttribute("id")]
        public string ID { get; set; }

        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}
