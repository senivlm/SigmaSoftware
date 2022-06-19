using System;
using System.Collections.Generic;

namespace task8ex2
{
    public class LogChecker
    {
        AccessLog log;
        public LogChecker() : this(new AccessLog())
        {

        }

        public LogChecker(AccessLog log)
        {
            this.log = log;
        }


        private List<Access> GetNewestLogs()
        {
            List<Access> logs = log.Log;
            if (logs.Count == 0)
            { throw new Exception("No logs"); }

            return logs;
        }


        public DayOfWeek Getpopulardayofweek()
        {
            Dictionary<DayOfWeek, int> pairs = new Dictionary<DayOfWeek, int>();
            foreach (Access acc in GetNewestLogs())
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

        public int GetpopularHour()
        {

            Dictionary<int, int> pairs = new Dictionary<int, int>();
            foreach (Access acc in GetNewestLogs())
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

        public string GetMostActiveIp()
        {
            Dictionary<string, int> pairs = new Dictionary<string, int>();
            foreach (Access acc in GetNewestLogs())
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
    }
}
