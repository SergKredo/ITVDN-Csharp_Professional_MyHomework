using System;
using System.Text;

public class Example
{
    public static void Main()
    {

        int key = 0xACACAC; //ключ шифрования нужно выбирать большим за данные которые шифруются
        int password = 123456789; //важные данные которые необходимо зашифровать

        int encryptedPass = password ^ key;
        Console.WriteLine("Зашифрованный пароль: {0}", encryptedPass);

        int decryptedPass = encryptedPass ^ key;
        Console.WriteLine("Расшифрованный пароль: {0}", decryptedPass);


        string strings = "Декодер преобразует массив байтов, отражающий конкретную кодировку символов, в набор символов в массиве символов или в строке. Чтобы декодировать массив байтов в массив символов, вызовите метод Encoding.GetChars . Чтобы декодировать массив байтов в строку, вызовите метод GetString . Если перед декодированием нужно определить, сколько символов требуется для хранения раскодированных байтов, можно вызвать метод GetCharCount .";
        Encoding asciiEncoding = Encoding.Default;

        // Create array of adequate size.
        byte[] bytes = new byte[strings.Length];
        // Create index for current position of array.
        int index = 0;

        Console.WriteLine("Strings to encode:");

        Console.WriteLine("   {0}", strings);

        asciiEncoding.GetBytes(strings, 0, strings.Length, bytes, index);
        Console.WriteLine("\nEncoded bytes:");
        Console.WriteLine("{0}", ShowByteValues(bytes, bytes.Length));
        Console.WriteLine();

        // Decode Unicode byte array to a string.
        string newString = asciiEncoding.GetString(bytes, 0, bytes.Length);
        Console.WriteLine("Decoded: {0}", newString);
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
// The example displays the following output:
//       Strings to encode:
//          This is the first sentence.
//          This is the second sentence.
//
//       Encoded bytes:
//
//          54 68 69 73 20 69 73 20 74 68 65 20 66 69 72 73 74 20 73 65
//          6E 74 65 6E 63 65 2E 20 54 68 69 73 20 69 73 20 74 68 65 20
//          73 65 63 6F 6E 64 20 73 65 6E 74 65 6E 63 65 2E 20
//
//       Decoded: This is the first sentence. This is the second sentence.

