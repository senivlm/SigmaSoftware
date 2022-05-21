using System;

namespace task2Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write sqrt matrix lenght");
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            MatrixFiller.FillLikeASnake(matrix);
            PrintMatrix(matrix);

        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write((matrix[i, j] + "     ").Substring(0, 3));
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }


        }
    }

}