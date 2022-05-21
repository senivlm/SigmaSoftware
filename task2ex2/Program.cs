using System;

namespace task2Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

        }

        static void Main2(string[] args)
        {
            int n = 7;
            int[,] arr = new int[n, n];

            int i = 0;
            int j = 0;
            arr[0, 0] = 1;
            arr[n - 1, n - 1] = n * n;
            bool up = true;
            int increment = 1;
            for (int value = 1; value < n * n; value++)
            {
                if (up)
                    if (i > 0) { i--; j++; }
                    else { j++; up = false; }
                else
                    if (j > 0) { i++; j--; }
                else { i++; up = true; }
                if (n % 2 == 0 & i == n | n % 2 != 0 & j == n) break;

                arr[i, j] = value + 1;
                arr[n - i - 1, n - j - 1] = n * n - value;
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write((arr[i, j] + "     ").Substring(0, 3));
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
    }

}