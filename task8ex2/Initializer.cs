using System;
using System.IO;

namespace task8ex2
{
    public class Initializer
    {
        public static void FillLAccessLogFromFile(AccessLog log, String path)
        {
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    int lineiterator = 0;
                    TimeSpan time;
                    DayOfWeek dayofWeek;
                    while (!reader.EndOfStream)
                    {
                        string[] splited = reader.ReadLine().Split();
                        if (splited.Length == 3)
                        {
                            try
                            {
                                if (TimeSpan.TryParse(splited[1], out time) && DayOfWeek.TryParse(GetUperredFirst(splited[2]), out dayofWeek))
                                {
                                    log.add(new Access(dayofWeek, time, splited[0]));
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public static string GetUperredFirst(string s)
        {
            string result = s;
            if (result.Length > 1)
            {
                result = result.Substring(0, 1).ToUpper() + result.Substring(1).ToLower();
            }
            else
            {
                if (result.Length == 1)
                { result = result.ToUpper(); }
            }
            return result;
        }
    }
}


