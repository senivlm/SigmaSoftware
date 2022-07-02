using System;
using System.Collections.Generic;
using System.IO;

namespace task7
{
    public class Logger : IDisposable
    {
        List<LogRecord> logRecords = new List<LogRecord>();
        List<LogRecord> unSavedlogRecords = new List<LogRecord>();
        StreamWriter sw;
        public static string delimiter = ";";

        public Logger() : this(defaultPath())
        {
        }


        public Logger(string pathtoFile)
        {

            if (File.Exists(pathtoFile))
            {
                readFromfile(pathtoFile);
            }
            sw = new StreamWriter(pathtoFile, true);

        }

        void readFromfile(string pathtoFile)
        {
            using (StreamReader sr = new StreamReader(pathtoFile))
            {
                while (sr.Peek() >= 0)
                {
                    try
                    {
                        string[] strings = sr.ReadLine().Split(delimiter);
                        logRecords.Add(new LogRecord(DateTime.Parse(strings[0]), strings[1]));
                    }
                    catch (Exception)
                    {
                        string message = "bad line in log";
                        add(message);
                        Console.WriteLine(message);
                    }
                }
            }
        }

        public void add(string message)
        { unSavedlogRecords.Add(new LogRecord(message)); }

        public void save()
        {
            while (unSavedlogRecords.Count > 0)
            {
                try
                {
                    sw.WriteLine(unSavedlogRecords[0]);
                    logRecords.Add(unSavedlogRecords[0]);
                    unSavedlogRecords.RemoveAt(0);
                }
                catch (Exception e)
                { Console.WriteLine(e.Message);
                    add(e.Message);
                    break;
                }
            }
        }

        public List<LogRecord> GetErrorsFrom(DateTime from)
        {
            return GetErrors(from, DateTime.MaxValue);
        }


        public List<LogRecord> GetErrorsBefore(DateTime to)
        {
            return GetErrors(DateTime.MinValue, to);
        }

        private List<LogRecord> GetErrors(DateTime from, DateTime to)
        {
            List<LogRecord> result = new List<LogRecord>();
            foreach (LogRecord record in logRecords)
            {
                if (record.Date >= from && record.Date < to)
                {
                    result.Add(record);
                }
                
            }

            foreach (LogRecord record in unSavedlogRecords)
            {
                if (record.Date >= from && record.Date < to)
                {
                    result.Add(record);
                }
               
            }

            return result;

        }



        public void Dispose()
        {

            save();
            sw.Dispose();
        }

        public static string defaultPath()
        {
            return "../../../log.txt";
        }
    }
}
