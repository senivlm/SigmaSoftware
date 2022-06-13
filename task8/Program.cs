using System;
using System.Collections.Generic;
using System.IO;

namespace task8
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounting ac1 = LoadByPath(@"../../../textAccounting1.txt");
            ac1.Cost = 2;
            Accounting ac2 = LoadByPath(@"../../../textAccounting2.txt");
            Accounting ac3 = ac1 + ac2;
            Accounting ac4 = ac1 - ac2;
            PrintAllFlats(ac1);
            PrintAllFlats(ac2);
            PrintAllFlats(ac3);
            PrintAllFlats(ac4);

        }

        static Accounting LoadByPath(string path)
        {
            Accounting result = new Accounting();
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    int lineiterator = 1;
                    string[] splited = reader.ReadLine().Split(',');
                    if (splited.Length != 2)
                    {
                        throw new Exception("Bad format of count and qaurtal in file. line -" + lineiterator);
                    }
                    else
                    {
                        Accounting newacc = new Accounting(int.Parse(splited[0]));

                        while (!reader.EndOfStream)
                        {
                            lineiterator++;
                            splited = reader.ReadLine().Split(',');
                            if (splited.Length != 4)
                            {
                                throw new Exception("Bad format of flat information. line -" + lineiterator);
                            }
                            else
                            {
                                int number = int.Parse(splited[0]);
                                newacc.addFlat(number, splited[1]);
                                DateTime date = DateTime.Parse(splited[2]);
                                int value = int.Parse(splited[3]);

                                newacc.addFlatMetric(number, date, value);

                            }
                        }
                        result = newacc;
                        Console.WriteLine("processed " + lineiterator + " lines");
                    }
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Cant find such file");
            }
            catch (FormatException)
            {
                Console.WriteLine("Bad format of data in file");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;


        }

        static void PrintAllFlats(Accounting acc)
        {
            Console.WriteLine("-----------");
            List<Flat> flats = acc.GetAllFlats();
            if (flats.Count == 0)
            {
                Console.WriteLine("No flats found");
            }
            else
            {
                foreach (Flat flat in flats)
                {
                    Console.WriteLine(flat);
                }
            }


        }

    }
}
