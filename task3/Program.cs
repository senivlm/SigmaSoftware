using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Pair pair1 = new Pair();
            Pair pair2 = new Pair();

            if (pair1.Equals(pair2))
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("not Equals");
            }

            if (ReferenceEquals(pair2, pair1))
            {
                Console.WriteLine("Referance Equals");
            }
            else
            {
                Console.WriteLine("not Referance Equals");
            }


            Vector vector = new Vector(5);
            Console.WriteLine(vector.ToString());

            Pair[] pairs = vector.CalculateFreq();
            foreach (Pair pair in pairs)
            {
                Console.WriteLine(pair.ToString());
            }

        }
    }
}
