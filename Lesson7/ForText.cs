using System;
using System.Collections.Generic;

namespace Lesson7
{
    public class ForText
    {
        HashSet<char> letters;

        public ForText()
        {
            letters = new HashSet<char>();
        }

        public ForText(string text)
        {
            letters = new HashSet<char>();
            addtext(text);
        }

        public void addtext(string text)
        {
            foreach (char c in text)
            {
                letters.Add(c);
            
            }
        }

        public static List<ForText> GetListfromWords(string text)
        {
            List <ForText> list= new List<ForText>();
            string[] strings = text.Split(" ");
            foreach (string s in strings)
            {
                list.Add(new ForText(s));
            }
            return list;
        }

        public bool Consist(HashSet<char> refer)
        {
            
            return letters.IntersectWith(refer);
        }
    }
}
