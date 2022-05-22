using System;
namespace task3
{
    public class Matrix
    {
        private Matrix()
        {

        }
        public static void SortMatrixDiagonalMethodFromLesson(int n)
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





        public static void SortMatrixDiagonal(int n, Direction direction)
        {
            int number = 0;
            int[,] matrix = new int[n, n];
            int increment;
            for (int line = 0; line < n; line++)
            {
                int i1 = line;
                int j1 = line;

                if (((line % 2 == 0) & (direction == Direction.right))|
                    ((line % 2 != 0) & (direction != Direction.right)))
                {
                    
                        j1 = 0;
                        increment = 1;
                    }
                    else
                    {
                        i1 = 0;
                        increment = -1;
                    }
                
                for (int i = 0; i < line + 1; i++)
                {
                    matrix[i1, j1] = ++number;
                    if (line <= n / 2)
                    {
                        matrix[n - i1 - 1, n - j1 - 1] = n * n - (number) + 1;
                    }
                    i1 -= increment;
                    j1 += increment;
                }
            }
            PrintMatrix(matrix);
        }


        public static int GetMaxSquare2(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxSquare = 0;
            
            bool calc;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int i1;
                    int j1;
                    
                    for (i1 = i; i1 < n; i1++)
                    {
                        if (matrix[i, j] != matrix[i1, j])
                            {
                            break;
                            }
                     }
                    
                    for (j1 = j; j1 < m; j1++)
                    {
                        if (matrix[i, j] != matrix[i, j1])
                        {
                            break;
                        }
                    }
                    calc = true;
                    for (int i2 = i; i2 < i1; i2++)
                    { 
                        for (int j2 = j; j2 < j1; j2++)
                        {
                            if (matrix[i, j] != matrix[i2, j2])
                            {
                                calc = false;
                            }
                            if (calc)
                            {
                                if (maxSquare < ((i2 - i + 1) * (j2 - i + 1)))
                                {
                                    maxSquare = ((i2 - i + 1) * (j2 - i + 1));
                                }
                            }
                        }
                    }
                    
                }
            }
            return maxSquare;
        }

        public static int GetMaxSquare(int[,] matrix)
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxSquare = 0;

            bool calc = false;

            int i = 0;
            int j = 0;
            int i1 = 0;
            int j1 = 0;
            int i2 = 0;
            int j2 = 0;

            for ( i = 0; i < n; i++)
            {
                for ( j = 0; j < m; j++)
                {
                    for ( i1 = i; i1 < n; i1++)
                    {
                        for ( j1 = j; j1 < m; j1++)
                        {
                            if (i1 > i & j1 > j)
                            {
                                calc = false;
                                for (i2 = i; i2 < i1 + 1; i2++)
                                {
                                    for (j2 = j; j2 < j1 + 1; j2++)
                                    {
                                        calc = i2 > i | j2 > j;
                                        if (matrix[i, j] != matrix[i2, j2])
                                        {
                                            calc = false;
                                            i2 = i1 + 1;
                                            break;
                                        }

                                    }
                                }
                                if (calc)
                                {
                                    if (maxSquare < ((i1 - i + 1) * (j1 - j + 1)))
                                    {
                                        maxSquare = (i1 - i + 1) * (j1 - j + 1);
                                    }

                                    calc = false;
                                    
                                }

                            }
                        }

                    }

                }
            }
                
            return maxSquare;
        }


        public static void InitRandom(int[,] matrix, int a, int b)
        {
            int n1 = matrix.GetLength(0);
            int n2 = matrix.GetLength(1);
            Random generator = new Random();

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    matrix[i, j] = generator.Next(a, b + 1);
                }
            }
        }


        public static void PrintMatrix(int[,] matrix)
            {
                int n1 = matrix.GetLength(0);
                int n2 = matrix.GetLength(1);
                for (int i = 0; i < n1; i++)
                {
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

