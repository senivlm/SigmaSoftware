using System;
using System.Collections.Generic;

namespace task9
{
    public class CurrencyRate
    {
        Dictionary<string, double> rates;

        public CurrencyRate()
        {
            rates = new Dictionary<string, double>();
        }

        public IEnumerable<string> keys => rates.Keys;

        public double this[String key]
        {
            get => rates[key];
        }

        public void add(String currency, double value)
        {
            rates.Add(currency, value);
        }

        public bool HasRate(string currency)
        {
            return rates.ContainsKey(currency);
        }

        public double GetIn(string currency, double ammount)
        {
            if (!HasRate(currency))
            {
                throw new ArgumentException("No rate for currency -\"" + currency + "\"");
            }
            else
            {
                if (rates[currency] <= 0)
                {
                    throw new ArgumentException("Rate for currency -\"" + currency + "\" = " + rates[currency] + "! This is wrong!");
                }
            }
            return ammount / rates[currency];

        }
    }
}
