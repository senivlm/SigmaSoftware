using System;

namespace task2ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Set Lenght of sqrt matrix");
            int n= int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            MatrixFiller.FillLikeASnake(matrix);
            Console.WriteLine("1");
            PrintMatrix(matrix);

            matrix = new int[n, n];
            MatrixFiller.FillLikeADiagonalSnake(matrix);
            Console.WriteLine("2");
            PrintMatrix(matrix);

            matrix = new int[n, n];
            MatrixFiller.FillLikeASpiralSnake(matrix);
           // Console.WriteLine("3");
           // PrintMatrix(matrix);

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
