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
    public static class Trig  // Триггер для доступа к элементам класса XmlModel и вывод сообщения  при Triger = true (база данных не обновляется!)
    {
        public static bool Triger = false;
    }
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
            WebClient client = new WebClient();  // Ипользование объекта WebClient для онлайн соединения с базой данных на сервере
            try
            {
                Trig.Triger = false;  
                var stream = await client.OpenReadTaskAsync(ApiUrl);
                return await ConvertFromStreamAsync(stream);
            }
            catch
            {
                Trig.Triger = true;
                ApiUrl = "TestCurrencyInfo.xml";
                var stream = await StreamFileOpenAsync(ApiUrl);
                return await ConvertFromStreamAsync(stream);
            }
        }

        private async Task<FileStream> StreamFileOpenAsync(string ApiUrl)  // Асинхронный вызов в файловый поток из Offline базы данных для курса валют банков Украины в формате xml
        {
            return await Task.Run(() =>
            {
                return File.OpenRead(ApiUrl);
            }
            );
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
