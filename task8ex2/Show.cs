using System;
namespace task8ex2
{
    public class Show
    {
        public static void Run()
        {
            try
            {
                AccessLog log = new AccessLog();
                Initializer.FillLAccessLogFromFile(log, @"../../../iplog.txt");
                LogChecker logChecker = new LogChecker(log);
                Console.WriteLine("Most popular day of week is " + logChecker.Getpopulardayofweek());
                Console.WriteLine("Most popular hour is " + logChecker.GetpopularHour());
                Console.WriteLine("Most active ip is " + logChecker.GetMostActiveIp());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
