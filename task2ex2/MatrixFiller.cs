using System;
namespace task2ex2
{
    public class MatrixFiller
    {
        private MatrixFiller()
        {
        }

        public static void FillLikeASnake(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int i = 0;
            int j = 0;
            matrix[0, 0] = 1;
            matrix[n - 1, n - 1] = n * n;
            bool up = true;

            for (int value = 1; value < n * n; value++)
            {
                if (up)
                    if (i > 0) { i--; j++; }
                    else { j++; up = false; }
                else
                    if (j > 0) { i++; j--; }
                else { i++; up = true; }
                if (n % 2 == 0 & i == n | n % 2 != 0 & j == n) break;

                matrix[i, j] = value + 1;
                matrix[n - i - 1, n - j - 1] = n * n - value;

            }

           
        }
    }
}
