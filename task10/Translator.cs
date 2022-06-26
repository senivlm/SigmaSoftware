using System;
using System.Collections.Generic;

namespace task10
{
    public class Translator
    {
        Dictionary<string, string> vocabluary;
        string text;
        string pathToText;
        string pathToDictionary;


        public Translator() : this("../../../Text.txt", "../../../Dictionary.txt")
        {
        }
        public Translator(string pathToText, string pathToDictionary) : this(pathToText, pathToDictionary, new Dictionary<string, string>(), "")
        {
        }

        public Translator(string pathToText, string pathToDictionary, Dictionary<string, string> vocabluary, string text)
        {
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
            this.vocabluary = vocabluary;
            this.text = text;

        }

        public void AddText(string text)
        {
            this.text += text;
        }

        public void AddDictionary(Dictionary<string, string> vocabluary)
        {
            this.vocabluary = vocabluary;
        }

        string SetCase(string originalWord, string Exampleword)
        {
            //корректно проверять только 1 символ
            string result = originalWord;
            string firstCharInExample = Exampleword[0].ToString();
            if (firstCharInExample.Equals(firstCharInExample.ToUpper()))
            {
                result = originalWord[0].ToString().ToUpper() + originalWord[1..];
            }
            return result;
        }

        string ChangeWord(string word)
            {
            string result = "";
            string tempword = word;
            if (!word.Trim().Equals(""))
            {
                char lastChar = word[word.Length - 1];
                if (Char.IsPunctuation(lastChar))
                {
                    if (word.Length == 1)
                    {
                        tempword = ""+lastChar;
                    }
                    else
                    {
                        //рекурсивный вызов для ... и !? 
                        tempword = ChangeWord(word[0..^1])+ lastChar;
                    }
                }
                else
                {
                    string wordInLowerCase = word.ToLower();
                    if (!vocabluary.ContainsKey(wordInLowerCase))
                    {
                        AddToDictionary(wordInLowerCase);
                    }
                    tempword = SetCase(vocabluary[wordInLowerCase],word);

                }
            }
            result += tempword;

            return result;
            }



        public string ChangeWords()
        {
            string result = "";
            char delimiter = ' ';
            var words = text.Split(delimiter);
            foreach (string word in words)
            {
               result += ChangeWord(word)+delimiter;
            }
            result = result[0..^1];
            return result;
        }

        public void AddToDictionary(string word)
        {
            Console.WriteLine($"Enter translate of {word}");
            string translated = Console.ReadLine();
            vocabluary.Add(word, translated);
            Reader.WriteToDictionary(word, translated, "../../../Dictionary.txt");
        }
    }
}
