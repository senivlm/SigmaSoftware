using System;
using System.Collections.Generic;

namespace task9
{
    public class Price
    {
        Dictionary<string, double> price;
        private static int perGrams = 1000;  
        public Price()
        {
            price = new Dictionary<string, double>();
        }

        public IEnumerable<string> keys => price.Keys;

        public double this[String key]
        {
            get => price[key];
        }

        public void add(String nom, double cost)
        {
            price.Add(nom, cost);
        }

        public bool HasPrice(string key)
        {
            return price.ContainsKey(key);
        }

        public double calc(Dictionary<string, int> calcing)
        {
            double result = 0;
            foreach (string ingr in calcing.Keys)
            {
                if (!HasPrice(ingr))
                { throw new ArgumentException("No price for -\"" + ingr + "\""); }
                result += calcing[ingr] * this[ingr] / perGrams;
            }
            return result;
        }

        
    }
}
