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

    /*
    ***************** MODEL **********************************************************************
    Модель описывает используемые в приложении данные. Модели могут содержать логику, непосредственно связанную этими данными, например, 
    логику валидации свойств модели. В то же время модель не должна содержать никакой логики, связанной с отображением данных и 
    взаимодействием с визуальными элементами управления.  
    Нередко модель реализует интерфейсы INotifyPropertyChanged или INotifyCollectionChanged, которые позволяют уведомлять систему об 
    изменениях свойств модели. Благодаря этому облегчается привязка к представлению, хотя опять же прямое взаимодействие между моделью и представлением отсутствует.
     */
    public class CurrencyApi  // Класс реализует шаблон "MODEL"
    {
        public string ApiUrl { get; set; } = @"http://resources.finance.ua/ru/public/currency-cash.xml";  // База данных курса валют в виде XML документа

        public async Task<XmlModel> GetXMLModel() // Асинхронный метод реализует возврат задачи Task с возвращаемым типом XMLModel из базы XML
        {
            WebClient client = new WebClient();
            try
            {
                var stream = await client.OpenReadTaskAsync(ApiUrl);
                return await ConvertFromStreamAsync(stream);
            }
            catch
            {
                return await ConvertFromStreamAsync(null);
            }
        }

        private async Task<XmlModel> ConvertFromStreamAsync(Stream stream)  // Асинхронный метод реализует процесс десиреализации данных из базы данных в объект типа XmlModel
        {
            return await Task.Run(() =>
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlModel));
                try
                {
                    var model = serializer.Deserialize(stream) as XmlModel;

                    if (model != null)
                    {
                        return model;
                    }
                    Thread.Sleep(5000);
                }
                catch
                {
                    return null;
                };
                return null;
            });
        }
    }
}
