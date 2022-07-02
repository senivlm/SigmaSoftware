using System;
using System.Collections.Generic;

namespace task8ex2
{
    public class AccessLog
    {
        List<Access> log;
        public AccessLog()
        {
            log = new List<Access>();
        }

        public void add(Access access)
        {
            log.Add(access);
        }

        public void add(DayOfWeek dayOfWeek, TimeSpan time, String ip)
        {
            add(new Access(dayOfWeek, time, ip));
        }

        public List<Access> Log
        { get { return new List<Access>(log); } }


        public DayOfWeek Getpopulardayofweek()
        {
            if (log.Count > 0)
            {
                Dictionary<DayOfWeek, int> pairs = new Dictionary<DayOfWeek, int>();
                foreach (Access acc in log)
                {
                    if (!pairs.ContainsKey(acc.DayOfWeek))
                    {
                        pairs[acc.DayOfWeek] = 0;
                    }
                    pairs[acc.DayOfWeek]++;
                }
                int max = 0;
                DayOfWeek result = DayOfWeek.Monday;
                foreach (DayOfWeek key in pairs.Keys)
                {
                    if (pairs[key] > max)
                    {
                        max = pairs[key];
                        result = key;
                    }
                }
                return result;

            }
            else { throw new Exception("No logs"); }
        }

        public int GetpopularHour()
        {
            if (log.Count > 0)
            {
                Dictionary<int, int> pairs = new Dictionary<int, int>();
                foreach (Access acc in log)
                {
                    if (!pairs.ContainsKey(acc.Hour))
                    {
                        pairs[acc.Hour] = 0;
                    }
                    pairs[acc.Hour]++;
                }
                int max = 0;
                int result = 0;
                foreach (int key in pairs.Keys)
                {
                    if (pairs[key] > max)
                    {
                        max = pairs[key];
                        result = key;
                    }
                }
                return result;

            }
            else { throw new Exception("No logs"); }
        }

        public string GetMostActiveIpHour()
        {
            if (log.Count > 0)
            {
                Dictionary<string, int> pairs = new Dictionary<string, int>();
                foreach (Access acc in log)
                {
                    if (!pairs.ContainsKey(acc.Ip))
                    {
                        pairs[acc.Ip] = 0;
                    }
                    pairs[acc.Ip]++;
                }
                int max = 0;
                string result = "";
                foreach (string key in pairs.Keys)
                {
                    if (pairs[key] > max)
                    {
                        max = pairs[key];
                        result = key;
                    }
                }
                return result;

            }
            else { throw new Exception("No logs"); }
        }
    }
}
