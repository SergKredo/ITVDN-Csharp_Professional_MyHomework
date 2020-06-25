using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = File.OpenRead(@"Prepositions.txt");
            StreamReader streamReader = new StreamReader(stream);
            string prepositions = streamReader.ReadToEnd();
            Console.WriteLine(prepositions);
            Console.WriteLine(new string('-', 100));
            string pattern = @"\s?\(\S*\s?\S*\)\s";
            prepositions = Regex.Replace(prepositions, pattern, "");
            Console.WriteLine(prepositions);
            Console.WriteLine(new string('-', 100));
            Console.WriteLine(new string('-', 100));
            pattern = @"\,";
            prepositions = Regex.Replace(prepositions, pattern, "\n");
            Console.WriteLine(prepositions);
            Console.WriteLine(new string('-', 100));
            Console.WriteLine(new string('-', 100));

            prepositions = prepositions.ToLowerInvariant();
            pattern = @"\d";
            prepositions = Regex.Replace(prepositions, pattern, "");
            Console.WriteLine(prepositions);

            Console.WriteLine(new string('-', 100));
            Console.WriteLine(new string('-', 100));

            List<string> words = new List<string>();
            pattern = @"(?<words>\W?\S*\ *\S*\ *\S*\ *\S*)";
            Regex regex = new Regex(pattern);
            string newText = null;
            foreach (Match item in regex.Matches(prepositions))
            {
                words.Add((item.Groups["words"].Value).Replace("\n", ""));
                newText += "\"" + item.Groups["words"].Value + "\"" + ",";
            }
            words.RemoveAt(words.Count - 1);
            Console.WriteLine(newText);

            StreamWriter streamWriter = new StreamWriter(@"Prepositions_redact.txt");
            streamWriter.Write(newText);
            streamWriter.Close();

            string text = @"Поезд несется от Уральских гор мимо дремучих лесов,
                            мимо домен и школ, через величайшую реку Европы – Волгу, к
                            Москве с ее древним Кремлем, с ее молодостью века и дальше,
                            мимо воскресшей из пепла Варшавы, мимо двуликого Берлина,
                            через Рейн с его замками, к Парижу, похожему на каменную
                            рощу столетий, и еще дальше, до последнего мыса Европы, где
                            под суровыми океанскими ветрами бретонский рыбак сушит
                            свои сети(И.Эренбург). 2. К вечеру мы немного не дошли до
                            реки Черниговки и стали биваком на узком перешейке между
                            ней и небольшой протокой.Ширина реки здесь колеблется от
                            15 до 80 метров. При этом она отделяет от себя в сторону большие 
                            слепые рукава, от которых идут длинные, узкие и глубокие
                            канавы, сообщающиеся с озерами и болотами или с такими речками,
                            которые впадают в Лефу(В.Арсеньев). 3. Выйдя из сарая,
                            я увидел в небе борьбу света с темными облаками, и впечатление
                            оставалось такое, что солнце победит(М.Пришвин).
                            4. Из 1925 году появился ныне всемирно известный большой
                            проекционный аппарат – планетарий Цейси. Его изобретение
                            связано с именем инженера В.Бауерсфельда.Аппарат может
                            работать в зале с куполом от 18 до 30 метров в диаметре.";
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 100));
            string patter = null;
            foreach (string item in words)
            {
                patter += @"(?<prepositions>\W{1}" + item + @"\s)|";
            }
            patter = patter.Substring(0, patter.Length - 1);
            //Console.WriteLine(patter);
            Regex regext = new Regex(patter);
            foreach (Match items in regext.Matches(text))
            {
                Console.WriteLine("Preposition: {0}", items.Groups["prepositions"].Value);
            }
            //patter = @"(?<prepositions>\W{1}" + @"из" + @"\s)";
            text = Regex.Replace(text.ToLowerInvariant(), patter, " ГАВ ");
            Console.WriteLine(text);
            Console.ReadKey();

        }
    }
}
