using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Collections;
using System.Text.RegularExpressions;

namespace Task3
{
    /*
     Из файла TelephoneBook.xml (файл должен был быть создан в процессе выполнения
дополнительного задания) выведите на экран только номера телефонов.
    */
    class Program
    {
        static void Main(string[] args)
        {
            FileStream stream = new FileStream(@"TelephoneBook.xml", FileMode.Open, FileAccess.Read);  // Открываем файловый поток текстового документа формата XML
            StreamReader text = new StreamReader(stream, Encoding.UTF8);
            Dictionary<string, string> keyValues = new Dictionary<string, string>();  // Создаем строго типизированную коллекцию dictionary<T, P>
            List<string> telephone = new List<string>();  // Создаем список
            XmlTextReader reader = new XmlTextReader(text);  // Создаем объект, который обеспечивает прямой доступ к данным XML
            StringBuilder builder = new StringBuilder();
            string wordsPerson = null;
            bool attrib = false;
            int count = 0;
            while (reader.Read())  // Считывание узла из потока
            {
                Console.InputEncoding = Encoding.Unicode;
                Console.OutputEncoding = Encoding.Unicode;

                // Вывод данных узлов xml дерева
                if (reader.NodeType == XmlNodeType.Element)
                {
                    while (reader.MoveToNextAttribute())
                    {
                        if (reader.Name == "Telephone")
                        {
                            telephone.Add(reader.Value);  // Добавление в список номера телефона личности
                            attrib = true;                // Активируем условие входа при входе в текстовый узел 
                        }
                    }
                }
                // Вывод данных текстового узла
                if (reader.NodeType == XmlNodeType.Text)
                {
                    if (attrib)  // Условная конструкция срабатывает, если у пользователя есть номер телефона
                    {
                        keyValues[reader.Value] = telephone[0];
                        telephone.Clear();
                        attrib = false;
                        foreach (KeyValuePair<string, string> item in keyValues)
                        {
                            string reg = @"\(\d+\)\s*\d*\W*\d*";
                            Regex regex = new Regex(reg);
                            wordsPerson = string.Format("{2}. {0, -15}, telephone: {1, -15}\r", item.Key, regex.Match(item.Value).Value, ++count);
                            builder.AppendFormat(wordsPerson+"\r\n");
                            Console.WriteLine(wordsPerson);
                        }
                        keyValues.Clear();
                    }
                    else   // Условная конструкция срабатывает, если у пользователя отсутствует номер телефона
                    {
                        keyValues[reader.Value] = "no number";
                        foreach (KeyValuePair<string, string> item in keyValues)
                        {
                            wordsPerson = string.Format("{2}. {0, -15}, telephone: {1, -15}\r", item.Key, item.Value, ++count);
                            builder.AppendFormat(wordsPerson + "\r\n");
                            Console.WriteLine(wordsPerson);
                        }
                        keyValues.Clear();
                    }

                }
            }
            File.WriteAllText(@"WriteXML.txt", builder.ToString());  // Записываем данные в текстовый файл
            Console.ReadKey();
        }
    }
}

/*
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
Results:
---------------------------------------------------------------------------------------------------------------------------------------------------------------------
1. Аніщенко Лілія Василівна, telephone: (044) 278-1924
2. Балагутрак Микола Петрович, telephone: (032) 297-0157
3. Білюба Анатолій Петрович, telephone: (044) 430-2346
4. Владімірова Тетяна Петрівна, telephone: (044) 422-9583
5. Головко Віктор Володимирович, telephone: (044) 205-2401
6. Грибовський Олександр Володимирович, telephone: (057) 720-3596
7. Данько Віктор Андрійович, telephone: (044) 525-3244
8. Дегтярьов Геннадій Сергійович, telephone: (057) 349-1090
9. Демиденко Лариса Юріївна, telephone: (0512) 58-7126
10. Деркач Лариса Григорівна, telephone: (048) 766-2392
11. Єрмаков Володимир Миколайович, telephone: (044) 522-3409
12. Захарова Наталія Борисівна, telephone: (044) 525-7490
13. Клим Богдан Петрович, telephone: (032) 229 -6351
14. Коротенко Григорій Михайлович, telephone: (0562) 47-2210
15. Кузнєцова Тамара Леонідівна, telephone: (044) 424-8286
16. Купінець Лариса Євгенівна, telephone: (048) 724-0860
17. Лавріненко Валерій Іванович, telephone: (044) 432-9515
18. Лавринович Олександр Антонович, telephone: (057) 720-3363
19. Луговський Юрій Федорович, telephone: no number
20. Мікляєва Ніна  Іванівна, telephone: (044) 526-5514
21. Моцовик Юрій Михайлович, telephone: (044) 424-9177
22. Надольний  Микола Іванович, telephone: (044) 297-2798
23. Налімов Юрій Степанович, telephone: (044) 281-6308
24. Одінцов Олексій Олексійович, telephone: (04593) 51772
25. Оноприч Володимир Петрович, telephone: (044) 454-2440
26. Горюк Максим Степанович, telephone: (044) 424-2050
27. Полякова Світлана Володимирівна, telephone: (044) 486-9123
28. Пономарьов Олександр Миколайович, telephone: (057) 335-6580
29. Редько Андрій Миколайович, telephone: no number
30. Рибалка Ірина Анатоліївна, telephone: (057) 341-0329
31. Селезньов Дмитро Георгійович, telephone: (057) 720-3596
32. Сердюк Анатолій Сергійович, telephone: (044) 234-6526
33. Середа Тетяна Миколаївна, telephone: (044) 254-1157
34. Столяров Віктор Михайлович, telephone: (044) 239-6766
35. Ткаченко Неоніла Єрмолаївна, telephone: (044) 454-7708
36. Трунова Олена Костянтинівна, telephone: (044) 424-2568
37. Улещенко Володимир Васильович, telephone: (044) 525-4464
38. Якубенко Людмила Миколаївна, telephone: (044) 424-1919
 */
