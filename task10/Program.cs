using System;
using System.Collections.Generic;
using System.IO;

namespace task10
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dictionary;
            List<string> text;
            try
            {
                text = Reader.ReadText("../../../Text.txt");
                dictionary = Reader.ReadDictionary("../../../Dictionary.txt");
                Translator translator = new Translator();
                translator.AddDictionary(dictionary);
                foreach (string i in text)
                {
                    translator.AddText(i);
                }
                string changedText = translator.ChangeWords();
                Console.WriteLine(changedText);
                Reader.WriteNewLineToFile(changedText, "../../../Result.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("FileNotFoundException");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("ArgumentException");
            }
            catch (WordDoesntFound)
            {
                Console.WriteLine("WordDoesntFound");
            }

        }
    }
}
