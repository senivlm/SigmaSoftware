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
            int m = matrix.GetLength(0);
            int value = 0;
       
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (j % 2 == 0)
                    {
                        value = j * n + i + 1; ;
                    }
                    else
                    {
                        value = (j + 1) * n - i;
                    }

                    matrix[i, j] = value;
                }
                
                
            }


        }
        public static void FillLikeADiagonalSnake(int[,] matrix)
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

        public static void FillLikeASpiralSnake(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            int i = 0;
            int j = 0;

            int nexti = 0;
            int nextj = 0;


            bool turni = true;
            bool changeturn = false;
            int increment = 1;

            matrix[0, 0] = 1;
            for (int value = 1; value < n * m+1; value++)
            {
                if (turni) {
                    i += increment;
                    nexti = i + increment; }
                else {
                    j += increment;
                    nextj = j + increment;
                }

                if ((nexti == n) | (nextj == m) | (nexti < 0) | (nextj < 0))
                {
                    changeturn = true;
                }
                else
                 {
                    if (matrix[nexti,nextj]>0) {
                        changeturn = true;
                    }
                }

                if (changeturn) {
                    changeturn = false;
                    turni = !turni;
                    if ((nextj>j)|(nexti<i))
                    {
                        increment = -increment;
                    }
                }
                matrix[i, j] = value + 1;
                

            }


        }

    }
}
