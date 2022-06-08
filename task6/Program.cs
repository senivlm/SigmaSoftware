using System;
using System.Collections.Generic;
using System.IO;

namespace task6
{
    class Program
    {
        static void Main(string[] args)
        {
            Accounting acc = new Accounting();
            bool run = true;
            while (run)
            {
                printMainMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        acc = LoadDefault(acc);
                        break;
                    case "2":
                        acc = InputPathAndLoad(acc);
                        break;
                    case "3":
                        SetCost(acc);
                        break;
                    case "4":
                        FindFlatWhoNotUseElectic(acc);
                        break;
                    case "5":
                        PrintFlatBalance(acc);
                        break;
                    case "6":
                        PrintAllBalance(acc);
                        break;
                    case "q":
                        run = false;
                        break;
                    default:
                        DefaultAction();
                        break;
                }

            }

            static Accounting LoadDefault(Accounting acc)
            {
                return LoadByPath(acc, @"../../../textAccounting.txt");
            }

            static Accounting InputPathAndLoad(Accounting acc)
            {
                Console.WriteLine("input path:");
                string path = Console.ReadLine();
                return LoadByPath(acc, path);
            }

            static Accounting LoadByPath(Accounting acc, string path)
            {
                Accounting result = acc;
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
                            Console.WriteLine("processed "+lineiterator+" lines");
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

            static void SetCost(Accounting acc)
            {
                Console.WriteLine("Input cost of electric");
                try
                {
                    acc.Cost = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad format of cost");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            static void FindFlatWhoNotUseElectic(Accounting acc)
            {
                List<Flat> flatsWhoNotUseEletric = acc.GetFlatsWhoNotUseEletric();
                if (flatsWhoNotUseEletric.Count == 0)
                {
                    Console.WriteLine("No flats found");
                }
                else
                {
                    foreach (Flat flat in flatsWhoNotUseEletric)
                    {
                        Console.WriteLine(flat);
                    }
                }
            }

            static void PrintFlatBalance(Accounting acc)
            {
                Console.WriteLine("Input number of flat");
                try
                {
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine("Balance = " + acc.getFlatBalance(number));
                }
                catch (FormatException)
                {
                    Console.WriteLine("Bad format of flat number");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

            static void PrintAllBalance(Accounting acc)
            {

                List<Flat> flats = acc.GetAllFlats();
                if (flats.Count == 0)
                {
                    Console.WriteLine("No flats found");
                }
                else
                {
                    foreach (Flat flat in flats)
                    {
                        Console.WriteLine(flat +" "+ flat.getBalance());
                    }
                }


            }
            
            

            static void DefaultAction()
            {
                Console.WriteLine("Please, choose variant!");
            }


            static void printMainMenu()
            {
                Console.WriteLine("1 - load default");
                Console.WriteLine("2 - load by path");
                Console.WriteLine("3 - set cost");
                Console.WriteLine("4 - find flat who not use electic");
                Console.WriteLine("5 - print flat balance");
                Console.WriteLine("6 - print all balances");
                Console.WriteLine("q - exit");
            }
        }
    }
}
