using System;
using System.Collections.Generic;
using System.Text;

namespace task6ex2
{
    public class Sentence
    {// молодець, що зберіг розділюючий знак в кінці речення!
        private string sentence;
        static List<char> endOfSentance = new List<char> { '!', '.', '?' };
        static List<char> ignored = new List<char> { '\n', '\r'};
        static List<char> qoters = new List<char> { '\'', '"' , '“', '”' };


        public Sentence()
        {
            sentence = "";
        }
        public Sentence(string sentence)
        {
            string trimedSentence = sentence.Trim();
            if (trimedSentence.Length > 1)
            {
                char lastChar = trimedSentence.Substring(trimedSentence.Length-1, 1)[0];
                if (Sentence.IsEndofSentence(lastChar))
                {
                    this.sentence = trimedSentence;
                }
                else
                {
                    throw new ArgumentException("End of sentens is incorrect!");
                }

            }
            else { throw new ArgumentException("Sentens whith out words"); }
        }

        public string MinWord()
        {
            string result = sentence;

            List<string> words = GetWords();
            if (words.Count > 0)
            {
                result = words[0];
                foreach (string word in words)
                {
                    if (word.Length < result.Length)
                    {
                        result = word;
                    }
                }
            }

            return result;
        }

        public string MaxWord()
        {
            string result = sentence;

            List<string> words = GetWords();
            if (words.Count > 0)
            {
                result = words[0];
                foreach (string word in words)
                {
                    if (word.Length > result.Length)
                    {
                        result = word;
                    }
                }
            }

            return result;
        }

        private List<string> GetWords()
        {
            List<string> words = new List<string>();
            string[] spliterwords = sentence.Split();
            StringBuilder sb = new StringBuilder();
            foreach (string word in spliterwords)
            {
                if (word.Trim().Length > 0)
                {
                    sb.Clear();
                    foreach (char c in word.Trim())
                    {
                        if (char.IsLetterOrDigit(c))
                        {
                            sb.Append(c);
                        }
                    }
                    if (sb.Length > 0)
                    {
                        words.Add(sb.ToString());
                    }
                }
            }
            return words;
        }

        public static bool IsEndofSentence(char c)
        {
            return endOfSentance.Contains(c);
        }

        public static bool IsQoters(char c)
        {
            return qoters.Contains(c);
        }

        public static bool IsIgnored(char c)
        {
            return ignored.Contains(c);
        }

        public override string ToString()
        {
            return sentence;
        }
    }
}
