using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


namespace Task2
{
    /*Напишите программу, которая бы позволила вам по указанному адресу web-страницы
выбирать все ссылки на другие страницы, номера телефонов, почтовые адреса и сохраняла
полученный результат в файл.*/
    
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            client.Headers["User-Agent"] = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";
            //client.DownloadFile(@"view-source:https://www.linkedin.com/in/sergey-kredentser-05369811b/", @"D:\Test\http.txt");
            Stream file = client.OpenRead(@"https://programm.top");
            StreamReader fileStreamReader = new StreamReader(file);
            string text = fileStreamReader.ReadToEnd();
            text = text.Replace('\"', '\'');
            Console.WriteLine(text);
            string pattern = @"href='(?<link>\S+)'|src='(?<link>\S+)'";
            Regex regex = new Regex(pattern);
            foreach (Match m in regex.Matches(text))
            {
                Regex regexTwo = new Regex(@"^http|www|//");
                if (regexTwo.IsMatch(m.Groups["link"].Value))
                {
                    if ((m.Groups["link"].Value).StartsWith("//"))
                    {
                        Console.WriteLine("Link: {0}", (m.Groups["link"].Value).Substring(2));
                        continue;
                    }
                    Console.WriteLine("Link: {0}", m.Groups["link"]);
                }
            }

            //pattern = @"src='(?<link>\S+)'";
            //regex = new Regex(pattern);
            //foreach (Match m in regex.Matches(text))
            //{
            //    Console.WriteLine("Link: {0}", m.Groups["link"]);
            //}


        }
    }
}
