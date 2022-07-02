using System;
using System.Collections.Generic;
using System.IO;

namespace task9
{
    public class Initializer
    {
        public static void FillMenuFromFile(Menu menu, String path)
        {
            bool dishBegin = true;
            string dishName = "";
            char delimiter = ',';
            int line = 0;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string s = sr.ReadLine();
                        line++;
                        if (s.Trim().Equals(""))
                        {
                            dishBegin = true;
                            dishName = "";
                        }
                        else
                        {
                            if (dishBegin)
                            {
                                if (s.Split(delimiter).Length == 1)
                                {
                                    dishName = s.Trim();
                                    menu.add(dishName, new Dish());
                                    dishBegin = false;
                                }
                                else throw new FormatException();
                            }
                            else
                            {
                                string[] splitedstring = s.Split(delimiter);
                                if (splitedstring.Length == 2)
                                {
                                    //возможен FormatException
                                    menu[dishName].add(splitedstring[0].Trim(), int.Parse(splitedstring[1]));
                                }
                                else throw new FormatException();

                            }
                        }
                    }

                }
            }
            catch (FormatException e) { MyIO.Write("menu structure in file is broken, line - " + line); }
            catch (Exception e) { MyIO.Write(e.Message); }
        }

        public static void FillPrice(Price price, String path)
        {
            int line = 0;
            char delimiter = '-';
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string s = sr.ReadLine();
                        line++;
                        if (!s.Trim().Equals(""))
                        {
                            string[] splitedstring = s.Split(delimiter);
                            if (splitedstring.Length == 2)
                            {
                                //возможен FormatException
                                price.add(splitedstring[0].Trim(), double.Parse(splitedstring[1]));
                            }
                            else throw new FormatException();
                        }
                    }
                }

            }
            catch (FormatException e) { MyIO.Write("price structure in file is broken, line - " + line); }
            catch (Exception e) { MyIO.Write(e.Message); }
        }

        public static void FillCurrency(CurrencyRate currencyRate, String path)
        {
            int line = 0;
            char delimiter = '-';
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.Peek() >= 0)
                    {
                        string s = sr.ReadLine();
                        line++;
                        if (!s.Trim().Equals(""))
                        {
                            string[] splitedstring = s.Split(delimiter);
                            if (splitedstring.Length == 2)
                            {
                                //возможен FormatException
                                currencyRate.add(splitedstring[0].Trim(), double.Parse(splitedstring[1]));
                            }
                            else throw new FormatException();
                        }
                    }
                }

            }
            catch (FormatException e) { MyIO.Write("price structure in file is broken, line - " + line); }
            catch (Exception e) { MyIO.Write(e.Message); }
        }

        public static Order MakeOrder(Menu menu)
        {
            Order order = new Order();

            bool run = true;

            while (run)
            {
                MyIO.Write("type name of dish:");
                MyIO.WriteIEnumerable(menu.keys);
                string maybeKey = MyIO.Read();
                if (menu.HasDish(maybeKey))
                {
                    MyIO.Write("type count of " + maybeKey + ":");
                    string maybyCount = MyIO.Read();
                    int count = 0;
                    if (int.TryParse(maybyCount, out count))
                    {
                        order.add(maybeKey, count);
                    }
                    else { run = false; }
                }
                else { run = false; }

            }
            MyIO.Write("order stopped");
            return order;
        }
        public static double GetNewPrice(string ingr)
        {
            int tryCount = 2;
            while (tryCount > 0)
            {
                MyIO.Write("type price for \"" + ingr + "\"(have trys =" + tryCount + "):");
                string maybyPrice = MyIO.Read();
                double price = 0;
                if (double.TryParse(maybyPrice, out price))
                {
                    return price;
                }
                else { tryCount--; }
            }
            throw new ArgumentException("Can't proceess price for -\"" + ingr + "\"");
        }

        public static double getInAnOtherCurrency(double costUAH, CurrencyRate currencyRate)
        {
            MyIO.Write("type currency you wish to convert:");
            MyIO.WriteIEnumerable(currencyRate.keys);
            string maybeKey = MyIO.Read();
            if (currencyRate.HasRate(maybeKey))
            {
                return currencyRate.GetIn(maybeKey, costUAH);
            }
            throw new ArgumentException("Can't process price conversion");

        }

    }
}


