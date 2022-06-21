using System;
using System.Collections.Generic;
using System.Linq;

namespace task8ex3
{
    public class Show
    {
        public static void Run()
        {
            try
            {
                Storage stor1 = new Storage();
                Initializer.FillStorage(stor1, @"../../../Storage1.txt");

                Storage stor2 = new Storage();
                Initializer.FillStorage(stor2, @"../../../Storage2.txt");

                var v1 = new Storage(stor2.Except(stor1).ToList<Product>());
                Storage v2 = new Storage(stor1.Intersect(stor2).ToList<Product>());
                Storage v3 = new Storage(stor1.Intersect(stor2).Distinct().ToList<Product>());
                
                printStorage(stor1, "Strorage 1:");
                printStorage(stor1, "Strorage 2:");
                printStorage(v1, "Except:");
                printStorage(v2, "Intersect:");
                printStorage(v3, "Intersect + Distinct:");

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void printStorage(Storage stor, string header)
        {
            Console.WriteLine(header);
            printStorage(stor);
            Console.WriteLine("-------------------");
        }

        public static void printStorage(Storage stor)
        {
            foreach (Product product in stor)
            {
                Console.WriteLine(product);
            }
        }
    }
}
