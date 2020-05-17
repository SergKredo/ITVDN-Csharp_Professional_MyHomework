using System;
using System.Text;

public class DateEncryption
{
    public static void Main()
    {
        Console.WriteLine("Шифрование информации:".ToUpper());
        int key = 0xACACAC; //ключ шифрования нужно выбирать большим за данные которые шифруются
        int password = 123456789; //важные данные которые необходимо зашифровать
        Console.WriteLine("Важные данные которые необходимо зашифровать: {0}", password);

        int encryptedPass = password ^ key;
        Console.WriteLine("Зашифрованные данные: {0}", encryptedPass);

        int decryptedPass = encryptedPass ^ key;
        Console.WriteLine("Расшифрованные данные: {0}", decryptedPass);
        Console.WriteLine(new string('-', 100)+"\n");

        Console.WriteLine("Часть вторая по кодировке:".ToUpper());

        string strings = "Декодер преобразует массив байтов, отражающий конкретную кодировку символов, в набор символов в массиве символов или в строке. Чтобы декодировать массив байтов в массив символов, вызовите метод Encoding.GetChars . Чтобы декодировать массив байтов в строку, вызовите метод GetString . Если перед декодированием нужно определить, сколько символов требуется для хранения раскодированных байтов, можно вызвать метод GetCharCount .";
        Encoding asciiEncoding = Encoding.Default;

        
        byte[] bytes = new byte[strings.Length];
        
        int index = 0;

        Console.WriteLine("Выражение, которое нужно закодировать:");

        Console.WriteLine("   {0}", strings);

        asciiEncoding.GetBytes(strings, 0, strings.Length, bytes, index);
        Console.WriteLine("\nЗакодированное выражение в байтах:");
        Console.WriteLine("{0}", ShowByteValues(bytes, bytes.Length));
        Console.WriteLine();

       
        string newString = asciiEncoding.GetString(bytes, 0, bytes.Length);
        Console.WriteLine("Раскодированное выражение: {0}", newString);
        Console.ReadKey();
    }

    private static string ShowByteValues(byte[] bytes, int last)
    {
        string returnString = "   ";
        for (int ctr = 0; ctr <= last - 1; ctr++)
        {
            if (ctr % 50 == 0)
                returnString += "\n   ";
            returnString += String.Format("{0:X} ", bytes[ctr]);
        }
        return returnString;
    }
}

/*
 ШИФРОВАНИЕ ИНФОРМАЦИИ:
Важные данные которые необходимо зашифровать: 123456789
Зашифрованные данные: 133652921
Расшифрованные данные: 123456789
----------------------------------------------------------------------------------------------------

ЧАСТЬ ВТОРАЯ ПО КОДИРОВКЕ:
Выражение, которое нужно закодировать:
   Декодер преобразует массив байтов, отражающий конкретную кодировку символов, в набор символов в массиве символов или в строке. Чтобы декодировать массив байтов в массив символов, вызовите метод Encoding.GetChars . Чтобы декодировать массив байтов в строку, вызовите метод GetString . Если перед декодированием нужно определить, сколько символов требуется для хранения раскодированных байтов, можно вызвать метод GetCharCount .

Закодированное выражение в байтах:

   C4 E5 EA EE E4 E5 F0 20 EF F0 E5 EE E1 F0 E0 E7 F3 E5 F2 20 EC E0 F1 F1 E8 E2 20 E1 E0 E9 F2 EE E2 2C 20 EE F2 F0 E0 E6 E0 FE F9 E8 E9 20 EA EE ED EA
   F0 E5 F2 ED F3 FE 20 EA EE E4 E8 F0 EE E2 EA F3 20 F1 E8 EC E2 EE EB EE E2 2C 20 E2 20 ED E0 E1 EE F0 20 F1 E8 EC E2 EE EB EE E2 20 E2 20 EC E0 F1 F1
   E8 E2 E5 20 F1 E8 EC E2 EE EB EE E2 20 E8 EB E8 20 E2 20 F1 F2 F0 EE EA E5 2E 20 D7 F2 EE E1 FB 20 E4 E5 EA EE E4 E8 F0 EE E2 E0 F2 FC 20 EC E0 F1 F1
   E8 E2 20 E1 E0 E9 F2 EE E2 20 E2 20 EC E0 F1 F1 E8 E2 20 F1 E8 EC E2 EE EB EE E2 2C 20 E2 FB E7 EE E2 E8 F2 E5 20 EC E5 F2 EE E4 20 45 6E 63 6F 64 69
   6E 67 2E 47 65 74 43 68 61 72 73 20 2E 20 D7 F2 EE E1 FB 20 E4 E5 EA EE E4 E8 F0 EE E2 E0 F2 FC 20 EC E0 F1 F1 E8 E2 20 E1 E0 E9 F2 EE E2 20 E2 20 F1
   F2 F0 EE EA F3 2C 20 E2 FB E7 EE E2 E8 F2 E5 20 EC E5 F2 EE E4 20 47 65 74 53 74 72 69 6E 67 20 2E 20 C5 F1 EB E8 20 EF E5 F0 E5 E4 20 E4 E5 EA EE E4
   E8 F0 EE E2 E0 ED E8 E5 EC 20 ED F3 E6 ED EE 20 EE EF F0 E5 E4 E5 EB E8 F2 FC 2C 20 F1 EA EE EB FC EA EE 20 F1 E8 EC E2 EE EB EE E2 20 F2 F0 E5 E1 F3
   E5 F2 F1 FF 20 E4 EB FF 20 F5 F0 E0 ED E5 ED E8 FF 20 F0 E0 F1 EA EE E4 E8 F0 EE E2 E0 ED ED FB F5 20 E1 E0 E9 F2 EE E2 2C 20 EC EE E6 ED EE 20 E2 FB
   E7 E2 E0 F2 FC 20 EC E5 F2 EE E4 20 47 65 74 43 68 61 72 43 6F 75 6E 74 20 2E

Decoded: Декодер преобразует массив байтов, отражающий конкретную кодировку символов, в набор символов в массиве символов или в строке. Чтобы декодировать массив байтов в массив символов, вызовите метод Encoding.GetChars . Чтобы декодировать массив байтов в строку, вызовите метод GetString . Если перед декодированием нужно определить, сколько символов требуется для хранения раскодированных байтов, можно вызвать метод GetCharCount .
*/

