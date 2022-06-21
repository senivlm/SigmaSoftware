using System;
using System.Collections.Generic;
using System.IO;

namespace task7
{
    class Program
    {//молодець.
        static void Main(string[] args)
        {
            DateTime programStart = DateTime.Now;
            Storage storage = new Storage();


            using (Logger log = new Logger())
            {
                using (StreamReader sr = new StreamReader("../../../Storage.txt"))
                {
                    while (sr.Peek() >= 0)
                    {
                        string s = sr.ReadLine();
                        try
                        {
                            storage.Add(Values.GetProductFromString(s));;
                        }
                        catch (Exception)
                        {
                            string message = "bad product string - "+s;
                            log.add(message);
                            
                        }
                    }
                }

                
                Console.WriteLine("Errors from programm starts are:");
                List<LogRecord> records = log.GetErrorsFrom(programStart);
                foreach (LogRecord record in records)
                {
                    Console.WriteLine(record);
                }


                Console.WriteLine("Errors readed from log.txt  are:");
                records = log.GetErrorsBefore(programStart);
                foreach (LogRecord record in records)
                {
                    Console.WriteLine(record);
                }
                


            }
             ////storage.Add(new Meat("BEEF", 100, Grade.XO, MeatType.Beef));
            ////storage.Add(new Product("PAPER", 100));
            ////storage.Add(new DailyProduct("MILK", 100, Term.Weak));
            ////storage.Add(new DailyProduct("BREAD", 100, Term.Day));
            ////storage.Add(new Meat("PORK", 100, Grade.VVSOP, MeatType.Pork));
            //storage.Add(Values.GetProductFromString("Gold_Beef 101 XO Beef"));
            //storage.Add(Values.GetProductFromString("Paper 110"));
            //storage.Add(Values.GetProductFromString("Milk 113 Weak"));
            //storage.Add(Values.GetProductFromString("Bread 111 Day"));
            //storage.Add(Values.GetProductFromString("gold_Pork 101 VVSOP Pork"));









            //Console.WriteLine("meat:");
            //foreach (Product meat in storage.GetMeat())
            //{
            //    Console.WriteLine(meat);
            //}

            //storage.IncrisePrice(10);

            //Console.WriteLine("all products:");
            //foreach (Product product in storage.Products)
            //{
            //    Console.WriteLine(product);
            //}


            Console.WriteLine("end");
        }
    }
}
