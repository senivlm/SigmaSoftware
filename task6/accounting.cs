using System;
using System.Collections.Generic;

namespace task6
{
    public class accounting
    {
        Flat[] flats;
        int electricCost;

        public accounting() : this(0)
        {
        }

        public accounting(int countFlats)
        {
            flats = new Flat[countFlats];
        }

        public void addFlat(int number, string owner)
        {
            if (checkNumber(number))
            {
                if (!flatExists(number))
                {
                    flats[number - 1] = new Flat(number, owner);
                }
            }
        }

        public void addFlatMetric(int number, DateTime date, int value)
        {
            if (checkNumber(number))
            {
                if (flatExists(number))
                {
                    getFlat(number).addMetric(date, value);
                }
            }
        }

        public int getFlatBalance(int number)
        {
            if (checkNumber(number))
            {
                if (flatExists(number))
                {
                    return getFlat(number).getBalance();
                }
            }
            return 0;
        }

        public List<Flat> GetFlatsWhoNotUseEletric()
        {
               List<Flat> flatsWhoNotUseEletric = new List<Flat>();
                foreach (Flat flat in flats)
                {
                    if (flat.getBalance() == 0)
                    {
                        flatsWhoNotUseEletric.Add(flat);
                    }
                }

                return flatsWhoNotUseEletric;
            
        }


        private bool checkNumber(int number)
        {
            return number > 0 && number <= flats.Length;
        }

        private bool flatExists(int number)
        {
            return flats[number - 1] != null;
        }

        private Flat getFlat(int number)
        {
            return flats[number - 1];
        }



    }
}
