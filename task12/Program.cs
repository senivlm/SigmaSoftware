using System;
using System.Collections.Generic;
using System.IO;

namespace task12
{
    class Program
    {
        static void Main(string[] args)
        {
            Storage storage = new Storage();
            storage.OnAddDailyProduc += CheckAndPrintMessageIfDayliProductIsCriticalTerm;
            storage.OnAddDailyProduc += AddDailyProductToUtilizationListIfCriticalTerm;
// Зробивши зчитування тут, а не в сервісі Ви значно спростили задачу. Хотілося б сервіс залишити...
            using (StreamReader sr = new StreamReader("../../../Storage.txt"))
                {
                    while (sr.Peek() >= 0)
                    {
                        string s = sr.ReadLine();
                        try
                        {
                            storage.Add(Values.GetProductFromString(s));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("bad product string - "+s);
                            
                        }
                    }
                }

            
            List<Product> productsWithLongTerm = storage.SelectSome(x => x is DailyProduct && ((DailyProduct)x).Term > Storage.CriticalTermOfStorage);
            List<Product> meatAtStorage = storage.SelectSome(x => x is Meat);


        }

        public static void CheckAndPrintMessageIfDayliProductIsCriticalTerm(Product product)
        {
            if (product is DailyProduct)
            {
                if ((product as DailyProduct).Term <= Storage.CriticalTermOfStorage)
                {
                    Console.WriteLine($"Term {(product as DailyProduct).Term} of {product} are Critical!!!");
                }
            }
        }

        public static void AddDailyProductToUtilizationListIfCriticalTerm(Product product)
        {
            if (product is DailyProduct)
            {
                if ((product as DailyProduct).Term <= Storage.CriticalTermOfStorage)
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter("../../../Utilization.txt", true))
                        {
                            sw.WriteLine(product as DailyProduct);
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
}
