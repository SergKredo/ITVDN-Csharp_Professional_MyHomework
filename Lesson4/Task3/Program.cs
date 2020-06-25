using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Task3
{
        /*Задание 3
    Напишите шуточную программу «Дешифратор», которая бы в текстовом файле могла бы
    заменить все предлоги на слово «ГАВ!».*/
    class Program
    {
        static void Main(string[] args)
        {
            Stream stream = File.OpenRead(@"Prepositions.txt");
            StreamReader streamReader = new StreamReader(stream);
            string prepositions = streamReader.ReadToEnd();
            string pattern = @"\s?\(\S*\s?\S*\)\s";
            prepositions = Regex.Replace(prepositions, pattern, "");
            
            pattern = @"\,";
            prepositions = Regex.Replace(prepositions, pattern, "\n");
            
            prepositions = prepositions.ToLowerInvariant();
            pattern = @"\d";
            prepositions = Regex.Replace(prepositions, pattern, "");
            
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
            
            StreamWriter streamWriter = new StreamWriter(@"Prepositions_redact.txt");
            streamWriter.Write(newText);
            streamWriter.Close();

            stream = File.OpenRead(@"Tolstoyi_L._Detstvootroche3._Yunost.txt");
            streamReader = new StreamReader(stream);
            string text = streamReader.ReadToEnd();
            stream.Close();
            streamReader.Close();
            

            Console.WriteLine(text);
            Console.WriteLine(new string('-', 100));
            Console.WriteLine(new string('-', 100));

            string patter = null;
            foreach (string item in words)
            {
                patter += @"(?<prepositions>\W{1}" + item + @"\s)|";
            }
            patter = patter.Substring(0, patter.Length - 1);

            List<string> prepor = new List<string>();
            Regex regext = new Regex(patter);
            foreach (Match items in regext.Matches(text))
            {
                prepor.Add(items.Groups["prepositions"].Value);
            }
            text = Regex.Replace(text, patter, " <Квитонька> ");

            words = new List<string>();
            foreach (Match item in regex.Matches(prepositions))
            {
                string word = ((item.Groups["words"].Value).Replace("\n", "") == "")? " ": (item.Groups["words"].Value).Replace("\n", "");
                words.Add(word.Replace(word[0].ToString(), word[0].ToString().ToUpper()));
            }
            words.RemoveAt(words.Count - 1);
            patter = null;
            foreach (string item in words)
            {
                patter += @"(?<prepositions>\W{1}" + item + @"\s)|";
            }
            patter = patter.Substring(0, patter.Length - 1);
            regext = new Regex(patter);
            foreach (Match items in regext.Matches(text))
            {
                prepor.Add(items.Groups["prepositions"].Value);
            }
            text = Regex.Replace(text, patter, " <Квитонька> ");
            Console.WriteLine(text);
            Console.WriteLine(new string('-', 100));
            Console.WriteLine(new string('-', 100));

            foreach (string ite in prepor)
            {
                Console.Write(ite+", ");
            }

            streamWriter = new StreamWriter(@"Tolstoyi_L._Detstvootroche3._Yunost_redact.txt");
            streamWriter.Write(text);
            streamWriter.Close();
            Console.ReadKey();

        }
    }
}
