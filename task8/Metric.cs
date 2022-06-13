using System;
namespace task8
{
    public class Metric
    {
        DateTime date;
        DateTime period;
        int value;

        public Metric() : this(DateTime.Now, 0)
        { }

        public Metric(DateTime date, int value)
        {
            this.date = date;
            this.value = value;
            SetPeriod();
        }

        public int Value
        {
            get { return this.value; }
            set { if (value > 0)
                {
                    this.value = value;
                }
                else
                {
                    throw new ArgumentException("Value mast be greater then Zero");
                }
            }
        }

        public DateTime Period
        {
            get { return this.Period; }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { if (value!=null)
                {
                    this.date = value;
                    SetPeriod();
                }
                else
                {
                    throw new ArgumentException("Null date not allowed!");
                }
            }
        }

        void SetPeriod()
        {
            if(value != null)
                {
                this.period = new DateTime(date.Year, date.Month, 1);
            }

            
        }

        public override string ToString()
        {
            return "period - "+period.ToString("MM/yyyy")+ ", date "+ date.ToString("MM/dd/yy") +" - "+ value;

        }
    }
}
