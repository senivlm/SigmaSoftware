using System;
using System.Collections.Generic;

namespace task6
{
    public class Flat
    {
        int number;
        string owner;
        List<Metric> account;


        public Flat():this(0,"")
        {

        }

        public Flat(int number, string owner)
        {
            this.number = number;
            this.owner = owner;
            account = new List<Metric>();
        }

        public void addMetric(DateTime date, int value)
        {
            Metric newMetric = new Metric(date, value);
            account.Add(newMetric);
        }


        public List<Metric> Account
        {
            get{ return account;}

        }

        public int getBalance()
        {
            int balance = 0;
            if (account.Count > 0)
            {

                int min = account[0].Value;
                int max = min;
                foreach (Metric metric in account)
                {
                    if (min > metric.Value)
                    {
                        min = metric.Value;
                    }
                    if (max < metric.Value)
                    {
                        max = metric.Value;
                    }
                }
                balance = max - min;
            }
            return balance;

        }

        public override string ToString()
        {
            return "#"+number.ToString()+"("+owner+")";
        }
    }
}
