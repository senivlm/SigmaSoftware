using System;
using System.Collections.Generic;
using System.Linq;

namespace task9
{
    public class Show
    {
        public static void Run()
        {
            try
            {
                Menu menu = new Menu();
                Initializer.FillMenuFromFile(menu, @"../../../Menu.txt");
                Price price = new Price();
                Initializer.FillPrice(price, @"../../../Prices.txt");
                CurrencyRate currencyRate = new CurrencyRate();
                Initializer.FillCurrency(currencyRate, @"../../../Course.txt");

                Order order = Initializer.MakeOrder(menu);

                IEnumerable<string> ingredientsForOrder = menu.GetIngredientsForOrder(order);

                foreach (string ingr in ingredientsForOrder)
                {
                    if (!price.HasPrice(ingr))
                    {
                        price.add(ingr,Initializer.GetNewPrice(ingr));
                    }
                }

                double costUAH = price.calc(menu.GetCalcultionForOrder(order));
                MyIO.Write("Cost in UAH = " + costUAH);
                if (costUAH>0)
                {
                    MyIO.Write("Conseting cost = " + Math.Round(Initializer.getInAnOtherCurrency(costUAH, currencyRate),2));
                }


            }

            catch (Exception e)
            {
                MyIO.Write(e.Message);
            }
        }

       
    }
}
