﻿using System;
using System.Collections.Generic;
using System.IO;

namespace task6
{
    public class Accounting
    {
        Flat[] flats;
        int cost;

        public Accounting() : this(0)
        {
        }

        public Accounting(int countFlats)
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
            if (!checkNumber(number))
            {
                throw new ArgumentException("Bad number of flat");
            }
            else
            {
                if (!flatExists(number))
                {
                    throw new ArgumentException("Information about flat not exists");
                }
                else
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

        public List<Flat> GetAllFlats()
        {
            List<Flat> flats = new List<Flat>();
            foreach (Flat flat in flats)
            {
                if (flat != null)
                {
                    flats.Add(flat);
                }

            }

            return flats;

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

        public int Cost
        {
            set {
                if (value > 0)
                { cost = value; }
                else
                { throw new ArgumentException("Cost mast be greather than zero"); }
            }
        }

        //public void ReadFromFile(String filename)
        //{
        //    StreamReader reader = new StreamReader(filename);
        //    string[] splited = reader.ReadLine().Split(',');
        //    if (splited.Length == 2)
        //    {
        //        flats = new Flat[int.Parse(splited[0])];
        //    }
        //    while (!reader.EndOfStream)
        //    {
        //        splited = reader.ReadLine().Split(',');
        //        if (splited.Length == 4)
        //        {
        //            int number = int.Parse(splited[0]);
        //            addFlat(number, splited[1]);
        //            DateTime date = DateTime.Parse(splited[2]);
        //            int value = int.Parse(splited[3]);

        //            addFlatMetric(number, date, value);

        //        }
        //    }
        //    reader.Close();
        //}

    }
}
