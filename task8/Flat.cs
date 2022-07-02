using System;
using System.Collections.Generic;

namespace task8
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
        public DateTime getLastMetric()
        {
            if (account.Count > 0)
            {
                DateTime minDateTime = account[0].Date;
                foreach (Metric metric in account)
                {
                    if (minDateTime > metric.Date)
                    {
                        minDateTime = metric.Date;
                    }
                }
                return minDateTime;
            }
           
            throw new ArgumentException("No metrics in this flat!");
         }


        public override string ToString()
        {
            return "#"+number.ToString()+"("+owner+")";
        }

        public override bool Equals(object obj)
        {
            bool result = false;
            if (obj is Flat)
            { result = this.number == (obj as Flat).number
                    && this.owner == (obj as Flat).owner;
            }
            return result;
        }

        public static bool operator ==(Flat flat1, Flat flat2)
        {
            return (flat1 is Flat)&& flat1.Equals(flat2);
        }

        public static bool operator !=(Flat flat1, Flat flat2)
        {
            return (flat1 is Flat)&& !flat1.Equals(flat2);
        }


    }
}
