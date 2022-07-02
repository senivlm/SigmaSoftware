using System;
using System.Collections.Generic;
using System.IO;

namespace task10
{
    class Reader
    {
        public static List<string> ReadText(string filePath)
        {
            List<string> result = new List<string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                    result.Add(reader.ReadLine());
           }
            return result;
        }

        public static Dictionary<string, string> ReadDictionary(string filePath)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    try
                    {
                        string temp = reader.ReadLine();
                        string[] strings = temp.Split('-');
                        if (strings.Length != 2) { throw new ArgumentException("Incorrect pair key-value"); }
                        result.Add(strings[0].Trim().ToLower(), strings[1].Trim().ToLower());
                    }
                    catch (ArgumentException) { throw; }
                } 
            }
            return result;
        }

        public static void WriteToDictionary(string key, string value, string filePath)
        {
            WriteNewLineToFile(key + "-" + value, filePath);
        }

        public static void WriteNewLineToFile(string message, string filePath)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.Write("\n");
                sw.Write(message);

            }
        }

    }
}
