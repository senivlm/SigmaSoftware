using System;
namespace task8ex2
{
    public class Access
    {
        string ip;
        DayOfWeek dayOfWeek;
        int hour;
        int minute;
        int secund;
        TimeSpan time;

        public Access() : this(DayOfWeek.Sunday, new TimeSpan(0, 0, 0), "0.0.0.0")
        {
            
        }

        public DayOfWeek DayOfWeek
        { get; }

        public int Hour
        { get { return hour; } }

        public string Ip
        { get { return ip; } }

        public Access(DayOfWeek dayOfWeek, TimeSpan time, string ip)
        {
            if (dayOfWeek == null)
            { throw new ArgumentException("bad day of week"); }

            if (time == null)
            { throw new ArgumentException("bad time"); }

            if (ip == null)
            { throw new ArgumentException("bad ip"); }
            else
            { if (ip.Split('.').Length!=4)
                    throw new ArgumentException("bad format of ip");
            }

            this.time = time;
            this.dayOfWeek = dayOfWeek;
            this.ip = ip;
            Fillints();
        }

        private void Fillints()
        {
            if (time == null)
            {
                hour = 0;
                minute = 0;
                secund = 0;
            }
            else
            {
                hour = time.Hours;
                minute = time.Minutes;
                secund = time.Seconds;
            }
        }

    }
}
