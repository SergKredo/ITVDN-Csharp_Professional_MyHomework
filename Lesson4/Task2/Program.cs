using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;


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
            Console.WriteLine("Information about the site page: links, phone numbers, emails\n".ToUpper());
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter the address of the page you are interested in: ".ToUpper());
                string pageSite = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                client.DownloadFile(@pageSite, @"http.txt");
                //Stream file = File.OpenRead(@"\http.txt");
                //StreamReader fileStreamReader = new StreamReader(file, Encoding.UTF8);
                Stream file = client.OpenRead(@pageSite);
                StreamReader fileStreamReader = new StreamReader(file);
                string text = fileStreamReader.ReadToEnd();
                text = text.Replace('\"', '\'');
                Console.InputEncoding = Encoding.Unicode;
                Console.OutputEncoding = Encoding.Unicode;
                //Console.WriteLine(text);
                Console.WriteLine(new string('-', 160));
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

                Console.WriteLine(new string('-', 160));
                pattern = @"(?<telephone>[+]{1}[\d+\s+\-]{10,})|(?<telephone>[38][0]{1}[\d]{9})";
                regex = new Regex(pattern);
                List<string> item = new List<string>();
                List<string> removeIT = new List<string>();
                Dictionary<string, int> inst = new Dictionary<string, int>();
                foreach (Match items in regex.Matches(text))
                {
                    removeIT.Add(items.Groups["telephone"].Value);
                    item.Add(items.Groups["telephone"].Value);
                }
                for (int j = 0; j < item.Count; j++)
                {
                    for (int i = 0; i < removeIT.Count; i++)
                    {
                        try
                        {
                            pattern = @"\d+";
                            regex = new Regex(pattern);
                            string word = removeIT[i].Replace("-", "").Replace(" ", "");
                            word = regex.Match(word).Value;
                            word = word.Substring(word.Length - 7);
                            string wordTwo = item[j].Replace("-", "").Replace(" ", "");
                            wordTwo = regex.Match(wordTwo).Value;
                            wordTwo = wordTwo.Substring(wordTwo.Length - 7);
                            if (wordTwo.Contains(word))
                            {
                                try
                                {
                                    inst.Add(word, i);
                                }
                                catch { }
                            }
                        }
                        catch { }
                    }
                }
                foreach (KeyValuePair<string, int> itom in inst)
                {
                    if (removeIT[itom.Value].StartsWith("+"))
                    {
                        Console.WriteLine("Telephone: {0}", removeIT[itom.Value]);
                    }
                    else if (removeIT[itom.Value].StartsWith("80"))
                    {
                        Console.WriteLine("Telephone: +3{0}", removeIT[itom.Value]);
                    }
                    else
                    {
                        Console.WriteLine("Telephone: {0}", removeIT[itom.Value]);
                    }
                }
                Console.WriteLine(new string('-', 160));

                pattern = @"(?<email>[\w]+@[\S]+\.[\w]+)'|(?<email>[\w]+@[\S]+\.[\w]+)<";
                regex = new Regex(pattern);
                item = new List<string>();
                removeIT = new List<string>();
                inst = new Dictionary<string, int>();

                foreach (Match iter in regex.Matches(text))
                {
                    removeIT.Add(iter.Groups["email"].Value);
                    item.Add(iter.Groups["email"].Value);
                }
                for (int j = 0; j < item.Count; j++)
                {
                    for (int i = 0; i < removeIT.Count; i++)
                    {
                        string word = removeIT[i];
                        string wordTwo = item[j];
                        if (wordTwo.Contains(word))
                        {
                            try
                            {
                                inst.Add(word, i);
                            }
                            catch { }
                        }
                    }
                }
                foreach (KeyValuePair<string, int> itom in inst)
                {
                    Console.WriteLine("Email: {0}", removeIT[itom.Value]);
                }

                Console.WriteLine(new string('-', 160));
                Console.WriteLine(new string('-', 160));

            }
        }
    }
}
