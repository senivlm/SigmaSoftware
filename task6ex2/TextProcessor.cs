using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace task6ex2
{
    public class TextProcessor
    {
        List<Sentence> sentences;
        public TextProcessor()
        {
        }

        public TextProcessor(List<Sentence> sentences)
        {
            this.sentences = sentences;
        }

        public List<Sentence> Sentences
        {
            get{ return sentences; }
        }

        public static TextProcessor loadFromStream(StreamReader streamReader)
        {
            StringBuilder sb = new StringBuilder();
            char nextchar;
            bool inQoters = false;
            List<Sentence> sentences = new List<Sentence>();
            while ((nextchar = (char)streamReader.Read()) >= 0 && !streamReader.EndOfStream)
            {
                if (Sentence.IsEndofSentence(nextchar) && !inQoters)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(nextchar);
                        sentences.Add(new Sentence(sb.ToString()));
                    };
                    sb.Clear();
                }
                else
                {
                    if (!Sentence.IsIgnored(nextchar))
                    {
                        if(Sentence.IsQoters(nextchar))
                        {
                            inQoters = !inQoters;
                        }
                        sb.Append(nextchar);
                    }
                }
            }
            return new TextProcessor(sentences);

        }

        public void SaveToStream(StreamWriter streamWriter)
        {
            foreach (Sentence sentence in sentences)
            {
              streamWriter.WriteLineAsync(sentence.ToString());
            }
        }





        

    }
}
