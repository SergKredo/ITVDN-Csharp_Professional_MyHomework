using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Currency_Info.Api.Model;
using System.Threading;
using Currency_Info.ViewModels;

namespace Currency_Info.Api
{
    public class CurrencyApi
    {
        public string ApiUrl { get; set; } = @"http://resources.finance.ua/ru/public/currency-cash.xml";

        public async Task<XmlModel> GetXMLModel()
        {
            WebClient client = new WebClient();
            var stream = await client.OpenReadTaskAsync(ApiUrl);
            return await ConvertFromStreamAsync(stream);
        }

        private async Task<XmlModel> ConvertFromStreamAsync(Stream stream)
        {
            return await Task.Run(() =>
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlModel));
                var model = serializer.Deserialize(stream) as XmlModel;

                Thread.Sleep(5000);

                if (model != null)
                {
                    return model;
                }

                return null;
            });
        }
    }
}
