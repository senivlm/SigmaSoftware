using System;

namespace task11
{
    public class LogRecord
    {
        DateTime date;
        string message;

        public LogRecord() : this("")
        { }

        public LogRecord(string message) : this(DateTime.Now, message)
        { }

        public LogRecord(DateTime date, string message)
        {
            this.date = date;
            this.message = message;
        }

        public DateTime Date { get { return date; } }

        public override string ToString()
        {
            return date.ToString("MM/dd/yyyy HH:mm:ss")+Logger.delimiter+message;
        }
    }
}
