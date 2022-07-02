using System;
using System.Collections.Generic;
using System.IO;

namespace task9
{
    public class MyIO
    {
        
        public static void Write(string message)
        {
            Console.WriteLine(message);
            addlog(message);

        }
        public static string Read()
        {
            string result = Console.ReadLine();
            addlog("[ENTERED] - \""+result+"\"");
            return result;
        }


        public static void WriteIEnumerable(IEnumerable<string> keys)
        {
            foreach (string key in keys)
            { Write("-"+key); }
        }

        static void addlog(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"../../../Result.txt", true))
                {
                    sw.WriteLineAsync(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


    }
}
