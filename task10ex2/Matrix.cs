using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace task10ex2
{
    public class Matrix : IEnumerable
    {
        int[,] matrix;
        Direction enumDirection;


        public Matrix(int lenght) : this(lenght, Direction.Right)
        {
        }

        public Matrix(int lenght, Direction enumDirection)
        {
            matrix = new int[lenght, lenght];
            this.enumDirection = enumDirection;
        }

        public Direction EnumDirection
        {
            get { return enumDirection; }
        }

        public void InitIncriment()
        {
            InitIncriment(this.matrix);
        }

        public IEnumerator GetEnumerator()
        {
            if (enumDirection == Direction.Right)
            {
                return GetEnumeratorRight();
            }
            if (enumDirection == Direction.Down)
            {
                return GetEnumeratorDown();
            }
            return GetEnumeratorDiagonl();
        }

        

        public IEnumerator GetEnumeratorRight()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        yield return matrix[row, column];
                    }
                }
                else
                {
                    for (int column = matrix.GetLength(1); column > 0; column--)
                    {
                        yield return matrix[row, column - 1];
                    }
                }
            }
        }

        public IEnumerator GetEnumeratorDown()
        {
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                if (column % 2 == 0)
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        yield return matrix[row, column];
                    }
                }
                else
                {
                    for (int row = matrix.GetLength(0); row > 0; row--)
                    {
                        yield return matrix[row - 1, column];
                    }
                }
            }
        }



        public IEnumerator GetEnumeratorDiagonl()
        {
            int n = matrix.GetLength(1);
            for (int diagonal = 0; diagonal < n; diagonal++)
            {
                if (diagonal % 2 == 0)
                {
                    for (int i = 0; i <= diagonal; i++)
                    {
                        yield return matrix[i, diagonal - i];
                    }
                }
                else
                {
                    for (int i = diagonal; i >= 0; i--)
                    {
                        yield return matrix[i, diagonal - i];
                    }
                }
            }

            for (int diagonal = n; diagonal < n * 2 - 1; diagonal++)
            {
                if (diagonal % 2 == 0)
                {
                    for (int i = diagonal - n + 1; i < n; i++)
                    {
                        yield return matrix[i, diagonal - i];
                    }
                }
                else
                {
                    for (int i = n - 1; i >= diagonal - n + 1; i--)
                    {
                        yield return matrix[i, n - i + 1];
                    }
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int elm in this)
             { sb.Append(elm + " "); }
            return sb.ToString();
        }

        public string ToString(Direction direction)
        {
            
            foreach (int element in this)
            { }
            return ToString(Direction.Right);
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

                if (((line % 2 == 0) & (direction == Direction.Right)) |
                    ((line % 2 != 0) & (direction != Direction.Right)))
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

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    for (i1 = i; i1 < n; i1++)
                    {
                        for (j1 = j; j1 < m; j1++)
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

        public static void InitIncriment(int[,] matrix)
        {
            int number = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = ++number;
                }
            }
        }




    }
}

