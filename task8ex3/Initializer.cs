using System;
using System.IO;

namespace task8ex3
{
    public class Initializer
    {
        public static void FillStorage(Storage stor, String path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string s = sr.ReadLine();
                        try
                        {
                            stor.Add(Values.GetProductFromString(s)); ;
                        }
                        catch (Exception)
                        {
                            string message = "bad product string - " + s;
                        }
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message);}
        }

    }
}


