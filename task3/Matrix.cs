using System;
namespace task3
{
    public class Matrix
    {
        private Matrix()
        {

        }
        public static void SortMatrixDiagonal(int n)
        {
            int number = 0;
            int[,] arr = new int[n, n];
            for (int line = 0; line < n; line++)
            {
                if (line % 2 == 0)
                {
                    int i1 = line;
                    int j1 = 0;
                    for (int i = 0; i < line + 1; i++)
                    {
                        arr[i1, j1] = ++number;
                        i1--;
                        j1++;
                    }
                }
                else
                {
                    int i1 = 0;
                    int j1 = line;
                    for (int i = 0; i < line + 1; i++)
                    {
                        arr[i1, j1] = ++number;
                        i1++;
                        j1--;
                    }
                }
            }
        }
    }
}
