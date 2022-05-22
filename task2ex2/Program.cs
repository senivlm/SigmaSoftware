using System;

namespace task2ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Set Lenght of matrix");
            int n= int.Parse(Console.ReadLine());

            Console.WriteLine("Set Hight of matrix");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];

            MatrixFiller.FillLikeASnake(matrix);
            Console.WriteLine("Snake");
            PrintMatrix(matrix);

            matrix = new int[n, n];
            MatrixFiller.FillLikeADiagonalSnake(matrix);
            Console.WriteLine("Diagonal snake");
            PrintMatrix(matrix);

            matrix = new int[n, m];
            MatrixFiller.FillLikeASpiralSnake(matrix);
            Console.WriteLine("Spiral snake");
            PrintMatrix(matrix);

        }
        static void PrintMatrix(int[,] matrix)
        {
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);
            for (int i=0; i<n1; i++) {
                for (int j = 0; j < n2; j++)
                {
                    Console.Write(((String)(matrix[i, j].ToString() + "   ")).Substring(0, 3));
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
