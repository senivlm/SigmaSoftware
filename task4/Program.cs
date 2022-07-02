using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector = new Vector(50);
            vector.InitRandom(1, 200);
            Console.WriteLine("Original  " + vector.ToString());
            vector.QuickSort();
            Console.WriteLine("Sorted  " + vector.ToString());
        }
    }
}
