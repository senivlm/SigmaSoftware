using System;
using System.IO;

namespace task6ex2
{
    class Program
    {
        static void Main(string[] args)
        {

            TextProcessor tp = new TextProcessor();
            using (StreamReader sr = new StreamReader("../../../text.txt"))
            {
                tp =  TextProcessor.loadFromStream(sr);
               
            }

            foreach (Sentence sentece in tp.Sentences)
            {
                Console.WriteLine(sentece.ToString());
                Console.WriteLine("Min word = "+sentece.MinWord());
                Console.WriteLine("Max word = " + sentece.MaxWord());

            }

            using (StreamWriter sw = new StreamWriter("../../../Result.txt"))
            {
                tp.SaveToStream(sw);
            }    
        }
    }
}


