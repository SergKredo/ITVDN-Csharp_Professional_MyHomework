using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Additional_Task
{
    /*Создайте .xml файл, который соответствовал бы следующим требованиям:
- имя файла: TelephoneBook.xml
- корневой элемент: “MyContacts”
- тег “Contact”, и в нем должно быть записано имя контакта и атрибут “TelephoneNumber”
со значением номера телефона.*/
    class Program
    {
        static void Main(string[] args)
        {

            WebClient client = new WebClient(); // Создание экземпляра класса WebClient для обмена данными с ресурсом, заданным URI
            client.Headers["User-Agent"] = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0"; // Автосвойство Headers возвращает или задает коллекцию пар "имя-значение" заголовков, связанных с запросом.

            Console.WriteLine("Information about the site page: links, phone numbers, emails\n".ToUpper());
            Stream fileFromData = File.Create(@"data_from_the_site.txt"); // Создание файлового потока, в который будут записываться байтовые данные из страницы c адресом URI
            StreamWriter streamWriter = new StreamWriter(fileFromData);  // Объект StreamWriter реализует возможность записи символов в файловый поток посредством объекта TextWriter
            streamWriter.WriteLine("Information about the site page: links, phone numbers, emails\n".ToUpper());
            streamWriter.Close();  // Закрываем поток
            fileFromData.Close();  // Закрываем поток
            streamWriter = File.AppendText(@"data_from_the_site.txt");  // Создание объекта типа System.IO.StreamWriter, который добавляет текст с кодировкой UTF-8 в существующий файл, или в новый файл, если указанный файл не существует.
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"union site page of NAS of Ukraine: http://www.nas.gov.ua/tradeunion/CentralCommittee/Pages/CompositionCentralCommittee.aspx".ToUpper());
            Console.ForegroundColor = ConsoleColor.Gray;
            client.DownloadFile(@"http://www.nas.gov.ua/tradeunion/CentralCommittee/Pages/CompositionCentralCommittee.aspx", @"site_data.txt"); // Вызов на экземпляре объекта типа WebClient метода DownloadFile. Метод загружает в локальный файл ресурс с указанным URI.
                                                                                                                                                //Stream file = File.OpenRead(@"\http.txt");
                                                                                                                                                //StreamReader fileStreamReader = new StreamReader(file, Encoding.UTF8);
            Stream file = client.OpenRead(@"http://www.nas.gov.ua/tradeunion/CentralCommittee/Pages/CompositionCentralCommittee.aspx"); // Объект, открывает для чтения поток данных из файла
            StreamReader fileStreamReader = new StreamReader(file);  // Объект StreamReader реализует возможность чтения символов из файлового потока посредством объекта TextReader
            string text = fileStreamReader.ReadToEnd();  // Считывание всех символов, начиная с текущей позиции до конца потока
            fileStreamReader.Close();
            file.Close();
            streamWriter.WriteLine("Enter the address of the page you are interested in: {0}".ToUpper(), @"http://www.nas.gov.ua/tradeunion/CentralCommittee/Pages/CompositionCentralCommittee.aspx");
            streamWriter.WriteLine("\n" + new string('-', 100));
            text = text.Replace('\"', '\'');
            Console.InputEncoding = Encoding.Unicode;  // Задание кодировки, используемую при чтении входных данных
            Console.OutputEncoding = Encoding.Unicode;  // Задание кодировки, используемую при записи входных данных
                                                        //Console.WriteLine(text);
            Console.WriteLine("\n" + new string('-', 100));

            // Создаем xml документ, в котором будет храниться освновная информация о членах профсоюза
            FileStream fileStream = new FileStream("TelephoneBook.xml", FileMode.OpenOrCreate);
            XmlTextWriter textWriter = new XmlTextWriter(fileStream, Encoding.UTF8);  // Создаем объект типа XmlTextWriter, который будет записывать в файловый поток документа данные в формате xml
                                                                                      // Устанавливаем форматирование строк языка xml
            textWriter.Formatting = Formatting.Indented;  // Устанавливаем форматирование выбрав перечисление Indented
            textWriter.Indentation = 1;  // Задаем количество знаков отступа тега в xml
            textWriter.IndentChar = '\t';  // Задаем символ отступа
            textWriter.WriteStartDocument(); //Записывает объявление XML с номером версии "1.0".
           textWriter.WriteStartElement("MyContacts");  // Открываем корневой узел-элемент (записываем открывающий тег с локальным именем). Создаем xml дерево c элементами


            // Регулярные выражения. Поиск всех встречающихся в тексте данных членов профсоюза НАН Украины
            string pattern = @"link-item.*whitespace";  // Задаем шаблон регулярного выражения для сопоставления с анализируемым массивом данных литералов.
            Regex regex = new Regex(pattern);  // Экземпляр объекта типа Regex позволяет осуществить поиск определенного выражения из массива символов текста по заданному шаблону регулярного выражения
            foreach (Match m in regex.Matches(text))  // Осуществляем перебор всех вхождений регулярного выражения из указанной входной строки
            {
                textWriter.WriteStartElement("Contact");  // Открываем дочерний узел (записываем открывающий тег с локальным именем)

                List<string> informationAboutRerson = new List<string>(); // Создаем строго типизированную коллекцию, в которой будут храниться данные все основные данные о личности
                //Console.WriteLine(m.Value);
                string words = m.Value.Insert(m.Value.IndexOf('<') + 1, "ghtrjjtjuht");   // Вставляем ключевое слово "ghtrjjtjuht", для того чтобы использовать поочередную выборку выражений в тексте
            Again:
                // Поиск регулярных выражений с использованием ключевого слова "ghtrjjtjuht" после символа <
                pattern = @">.*<ghtrjjtjuht";    
                Regex regexSplit = new Regex(pattern);
                foreach (Match item in regexSplit.Matches(words))
                {
                    if (item.Value == "><ghtrjjtjuht")
                    {
                        words = words.Replace(item.Value, "");
                        words = words.Insert(words.IndexOf('<') + 1, "ghtrjjtjuht");
                        goto Again;
                    }
                    words = words.Replace(item.Value, "");
                    informationAboutRerson.Add(item.Value.Replace(">", "").Replace("<ghtrjjtjuht", ""));
                    //Console.WriteLine(item.Value.Replace(">", "").Replace("<ghtrjjtjuht", ""));
                    words = words.Insert(words.IndexOf('<') + 1, "ghtrjjtjuht");  // Вставляем ключевое слово "ghtrjjtjuht" в области нахождения в тексте следующего символа <
                    goto Again;
                }

                StringBuilder buildWords = new StringBuilder();
                foreach (var it in informationAboutRerson)
                {
                    buildWords.AppendFormat(it + "; ");
                }
                string word = buildWords.ToString();
                //Console.WriteLine(word);

                string patternet = @"(\d+)";
                Regex regexNumber = new Regex(patternet);
                if (regexNumber.IsMatch(word))
                {
                    StringBuilder buildWordsAboutPerson = new StringBuilder();
                    textWriter.WriteStartAttribute("Place of employment, academic degree, title");   // Создаем открывающийся атрибут в дочернем элементе
                    foreach (var ite in informationAboutRerson.GetRange(1, informationAboutRerson.Count - 3))
                    {
                        buildWordsAboutPerson.AppendFormat(ite + "; ");
                    }
                    textWriter.WriteString(buildWordsAboutPerson.ToString());   // Присваиваем атрибуту значение
                    textWriter.WriteEndAttribute();  // Закрываем атрибут
                    textWriter.WriteStartAttribute("Telephone");
                    textWriter.WriteString(informationAboutRerson[informationAboutRerson.Count - 2]);
                    textWriter.WriteEndAttribute();
                    textWriter.WriteStartAttribute("Email");
                    textWriter.WriteString(informationAboutRerson[informationAboutRerson.Count - 1]);
                    textWriter.WriteEndAttribute();
                }
                else
                {
                    StringBuilder buildWordsAboutPerson = new StringBuilder();
                    textWriter.WriteStartAttribute("Place of employment, academic degree, title");
                    foreach (var ite in informationAboutRerson.GetRange(1, informationAboutRerson.Count - 2))
                    {
                        buildWordsAboutPerson.AppendFormat(ite + "; ");
                    }
                    textWriter.WriteString(buildWordsAboutPerson.ToString());
                    textWriter.WriteEndAttribute();
                    textWriter.WriteStartAttribute("Email");
                    textWriter.WriteString(informationAboutRerson[informationAboutRerson.Count - 1]);
                    textWriter.WriteEndAttribute();
                }
                textWriter.WriteString(informationAboutRerson[0]);
                textWriter.WriteEndElement();   // Закрываем дочерний узел
            }
            streamWriter.WriteLine(new string('-', 160));

            textWriter.WriteEndElement(); // Закрываем корневой узел
            textWriter.Close();
            fileStream.Close();

            string reader = File.ReadAllText(@"TelephoneBook.xml", Encoding.UTF8);   // Метод ReadAllText открываем файл, считывает все строки файла с заданной кодировкой и затем закрывает файл
            Console.WriteLine(reader);  // Выводим в консоли данные xml файла
        }
    }
}

/*
 ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 Results:
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
<?xml version="1.0" encoding="utf-8"?>
<MyContacts>
	<Contact Place of employment, academic degree, title="Інститут мовознавства ім. О.О.Потебні; наук.співр.; " Telephone="тел.: (044) 278-1924 с." Email="ALV_0511@ukr.net">Аніщенко Лілія Василівна</Contact>
	<Contact Place of employment, academic degree, title="Голова Львівської регіональної організації; Інститут народознавства; кандидат історичних наук; ст.наук.співр.; " Telephone="тел.: (032) 297-0157 с." Email="balahutrak@ukr.net">Балагутрак Микола Петрович</Contact>
	<Contact Place of employment, academic degree, title="Голова Комісії з соціальних питань та охорони праці; Науково-технологічний алмазний концерн „Алкон”; " Telephone="тел.: (044) 430-2346 с." Email="shana52@ukr.net">Білюба Анатолій Петрович</Contact>
	<Contact Place of employment, academic degree, title="Інститут метлофізики; кандидат фізико-математичних наук; ст.наук.співр.; " Telephone="тел.: (044) 422-9583 с." Email="tvlad@imp.kiev.ua">Владімірова Тетяна Петрівна</Contact>
	<Contact Place of employment, academic degree, title="Член Президії; Інститут електрозварювання ім. Є.О.Патона; доктор технічних наук; завідувач відділом; " Telephone="тел.: (044) 205-2401 с." Email="vholovko@ukr.net">Головко Віктор Володимирович</Contact>
	<Contact Place of employment, academic degree, title="Радіоастрономічний Інститут; доктор фізико-математичних наук; пров.наук.співр.; " Telephone="тел.: (057) 720-3596 с." Email="grib@rian.kharkov.ua">Грибовський Олександр Володимирович</Contact>
	<Contact Place of employment, academic degree, title="Член Президії; Інститут фізики напівпровідників ім. В.Є.Лашкарьова; кандидат фізико-математичних наук; в.о.завідувача відділу; " Telephone="тел.: (044) 525-3244 с." Email="danko-va@ukr.net">Данько Віктор Андрійович</Contact>
	<Contact Place of employment, academic degree, title="Член Президії; ННЦ „Харківський фізико-технічний інститут”; голова профспілкового комітету; " Telephone="тел.: (057) 349-1090 с." Email="degtyarev@kipt.kharkov.ua">Дегтярьов Геннадій Сергійович</Contact>
	<Contact Place of employment, academic degree, title="Голова Миколаївської регіональної організації; Інститут імпульсних процесів і технологій; наук.співр.; " Telephone="тел.:(0512) 58-7126 с." Email="demidl@ukr.net">Демиденко Лариса Юріївна</Contact>
	<Contact Place of employment, academic degree, title="Голова  Одеської регіональної організації; Фізико-хімічний Інститут ім. О.В.Богатського; кандидат хімічних наук; ст.наук.співр.; " Telephone="тел.:(048) 766-2392 с." Email="dierkach.larisa@gmail.com">Деркач Лариса Григорівна</Contact>
	<Contact Place of employment, academic degree, title="Інститут теоретичної фізики; доктор технічних наук; пров.наук.співр.; " Telephone="тел.: (044) 522-3409 с." Email="vlerm@bitp.kiev.ua">Єрмаков Володимир Миколайович</Contact>
	<Contact Place of employment, academic degree, title="Голова Комісії з організаційної роботи; Національна бібліотека України ім. В.І.Вернадського; кандидат історичних наук; ст.наук.співр.; " Telephone="тел..: (044) 525-7490 с." Email="natazachar@bigmir.net">Захарова Наталія Борисівна</Contact>
	<Contact Place of employment, academic degree, title="Фізико-механічний інститут ім. Г.В.Карпенка; кандидат технічних наук.; ст.наук.співр.; " Telephone="тел.:(032) 229 -6351 с." Email="klym@ipm.lviv.ua">Клим Богдан Петрович</Contact>
	<Contact Place of employment, academic degree, title="Голова Дніпропетровської регіональної організації; доктор технічних наук; професор; " Telephone="тел.: (0562) 47-2210" Email="gkorotenko@gmail.com">Коротенко Григорій Михайлович</Contact>
	<Contact Place of employment, academic degree, title="Інститут проблем матеріалознавства; кандидат технічних наук; ст.наук.співр.; " Telephone="тел.:(044) 424-8286 с." Email="pisar@materials.kiev.ua">Кузнєцова Тамара Леонідівна</Contact>
	<Contact Place of employment, academic degree, title="І-т проблем ринку та економіко-екологічних досліджень; доктор економічних наук; завідувач відділом; " Telephone="тел.:(048) 724-0860 с." Email="lek_larisa@ukr.net">Купінець Лариса Євгенівна</Contact>
	<Contact Place of employment, academic degree, title="Інститут надтвердих матеріалів; доктор технічних наук; завідувач відділом; " Telephone="тел.: (044) 432-9515 с." Email="lavrinenko@ism.kiev.ua">Лавріненко Валерій Іванович</Contact>
	<Contact Place of employment, academic degree, title="Інститут радіофізики і електроніки ім.О.Я.Усікова; кандидат фізико-математичних наук; ст.наук.співр.; " Telephone="тел.: (057) 720-3363 с." Email="lavr@ire.kharkov.ua">Лавринович Олександр Антонович</Contact>
	<Contact Place of employment, academic degree, title="Інститут проблем матеріалознавства; доктор технічних наук; ст.наук.співр.; " Email="lugovskoi_u@ukr.net">Луговський Юрій Федорович</Contact>
	<Contact Place of employment, academic degree, title="Інститут проблем математичних машин та систем; голова профспілкового комітету; " Telephone="тел.: (044) 526-5514 с." Email="profcom@immsp.kiev.ua">Мікляєва Ніна  Іванівна</Contact>
	<Contact Place of employment, academic degree, title="Інститут проблем моделювання в енергетиці ім.Г.Є.Пухова; інженер І кат.; " Telephone="тел.: (044) 424-9177 с." Email="ipme@ipme.kiev.ua">Моцовик Юрій Михайлович</Contact>
	<Contact Place of employment, academic degree, title="Інститут філософії; кандидат філософських наук; ст.наук.співр.; " Telephone="тел.: (044) 297-2798 с." Email="nikolokin62@gmail.com">Надольний  Микола Іванович</Contact>
	<Contact Place of employment, academic degree, title="Інститут проблем міцності ім. Г.С.Писаренка; кандидат технічних наук; ст.наук.співр.; " Telephone="тел.: (044) 281-6308 с." Email="ppo@ipp.kiev.ua">Налімов Юрій Степанович</Contact>
	<Contact Place of employment, academic degree, title="Інститут проблем безпеки АЕС; кандидат технічних наук; ст.наук.співр.; " Telephone="тел.: (04593) 51772" Email="ooodin@ukr.net">Одінцов Олексій Олексійович</Contact>
	<Contact Place of employment, academic degree, title="Інститут електродинаміки; кандидат технічних наук; ст.наук.співр.; " Telephone="тел.: (044) 454-2440 с." Email="ied1@ied.org.ua">Оноприч Володимир Петрович</Contact>
	<Contact Place of employment, academic degree, title="Фізико-технічний інститут металів і сплавів; кандидат технічних наук; " Telephone="тел.: (044) 424-2050с." Email="gormak72@gmail.com">Горюк Максим Степанович</Contact>
	<Contact Place of employment, academic degree, title="Голова Комісії з фінансово-економічних питань та трудових відносин; Інститут демографії та соціальних досліджень ім.М.В.Птухи; кандидат економічних наук; ст.наук.співр.; " Telephone="тел.:(044) 486-9123 с." Email="polyakova_@ukr.net">Полякова Світлана Володимирівна</Contact>
	<Contact Place of employment, academic degree, title="ННЦ „Харківський фізико-технічний інститут”; мол.наук.співр.; " Telephone="тел.: (057) 335-6580 с." Email="alex_ponoparyov@meta.ua">Пономарьов Олександр Миколайович</Contact>
	<Contact Place of employment, academic degree, title="Інститут фізико-органічної хімії і вуглехімії ім. Л.М.Литвиненка; кандидат хімічних наук; ст.наук.співр.; " Email="redko_an@ukr.net">Редько Андрій Миколайович</Contact>
	<Contact Place of employment, academic degree, title="Інститут сцинтиляційних матеріалів; кандидат технічних наук; ст.наук.співр.; " Telephone="тел.: (057) 341-0329" Email="iren@isma.kharkov.ua">Рибалка Ірина Анатоліївна</Contact>
	<Contact Place of employment, academic degree, title="Голова Харківської регіональної організації; кандидат фізико-математичних наук; ст.наук.співр.; " Telephone="тел.:(057) 720-3596 с." Email="sad@rian.kharkov.ua">Селезньов Дмитро Георгійович</Contact>
	<Contact Place of employment, academic degree, title="Інститут математики; доктор фізико-математичних наук; пров.наук.співр.; " Telephone="тел.: (044) 234-6526 с." Email="sanatolii@ukr.net">Сердюк Анатолій Сергійович</Contact>
	<Contact Place of employment, academic degree, title="Інститут гідробіології; кандидат біологічних наук; ст.наук.співр.; " Telephone="тел.: (044) 254-1157 с." Email="seredatm@ukr.net">Середа Тетяна Миколаївна</Contact>
	<Contact Place of employment, academic degree, title="Заступник голови Профспілки, голова Київської регіональної організації; " Telephone="тел.: (044) 239-6766 с." Email="Stoliarov@nas.gov.ua">Столяров Віктор Михайлович</Contact>
	<Contact Place of employment, academic degree, title="Інститут механіки; кандидат фізико-математичних наук; ст.наук.співр.; " Telephone="тел.: (044) 454-7708 с." Email="tk.ne@ukr.net">Ткаченко Неоніла Єрмолаївна</Contact>
	<Contact Place of employment, academic degree, title="Інститут загальної та неорганічної хімії; доктор хімічних наук; завідувач відділом; " Telephone="тел.: (044) 424-2568 с." Email="trelkon@gmail.com">Трунова Олена Костянтинівна</Contact>
	<Contact Place of employment, academic degree, title="Інститут ядерних досліджень; кандидат фізико-математичних наук; ст.науков. співр.; " Telephone="тел.: (044) 525-4464 с." Email="vuleshch@kinr.kiev.ua">Улещенко Володимир Васильович</Contact>
	<Contact Place of employment, academic degree, title="Інститут біоколоїдної хімії; кандидат хімічних наук; ст.наук.співр.; " Telephone="тел.: (044) 424-1919 с." Email="050yln@gmail.com">Якубенко Людмила Миколаївна</Contact>
</MyContacts>
 */
