using System;
using System.Collections.Generic;
using System.IO;

namespace task6
{
    public class Accounting
    {
        Flat[] flats;
        int electricCost;

        public Accounting() : this(0)
        {
        }

        public Accounting(int countFlats)
        {
            flats = new Flat[countFlats];
        }

        public Accounting(String filename)
        {
            ReadFromFile(filename);
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
                    if (flat != null && flat.getBalance() == 0)
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

        private void ReadFromFile(String filename)
        {
            StreamReader reader = new StreamReader(filename);
            string[] splited = reader.ReadLine().Split(',');
            if (splited.Length == 2)
            {
                flats = new Flat[int.Parse(splited[0])];
            }
            while (!reader.EndOfStream)
            {
                splited = reader.ReadLine().Split(',');
                if (splited.Length == 4)
                {
                    int number = int.Parse(splited[0]);
                    addFlat(number, splited[1]);
                    DateTime date = DateTime.Parse(splited[2]);
                    int value = int.Parse(splited[3]);

                    addFlatMetric(number, date, value);

                }
            }
            reader.Close();
        }

    }
}
