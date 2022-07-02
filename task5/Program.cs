using System;
using System.IO;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Vector vector = new Vector(0);
            vector.ReadFromFile(@"../../../textvector.txt");
            Console.WriteLine("Original  " + vector.ToString());
            vector.SplitMargeSort();
            Console.WriteLine("SplitMarge Sorted  " + vector.ToString());

            vector.ReadFromFile(@"../../../textvector.txt");
            Console.WriteLine("Original  " + vector.ToString());
            vector.PiramidSort();
            Console.WriteLine("Piramid sorted  " + vector.ToString());

        }
    }
}
