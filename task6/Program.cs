using System;
using System.Collections.Generic;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {

            Accounting acc= new Accounting(@"../../../textAccounting.txt");
            Console.WriteLine(acc.getFlatBalance(1));
            List<Flat> flatsWhoNotUseEletric = acc.GetFlatsWhoNotUseEletric();
            foreach(Flat flat in flatsWhoNotUseEletric)
            {
                Console.WriteLine("Not use electric - "flat.ToString());
            }

        }
    }
}
