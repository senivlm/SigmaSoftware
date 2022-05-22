using System;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pair pair1 = new Pair();
            //Pair pair2 = new Pair();

            //if (pair1.Equals(pair2))
            //{
            //    Console.WriteLine("Equals");
            //}
            //else
            //{
            //    Console.WriteLine("not Equals");
            //}

            //if (ReferenceEquals(pair2, pair1))
            //{
            //    Console.WriteLine("Referance Equals");
            //}
            //else
            //{
            //    Console.WriteLine("not Referance Equals");
            //}


            //Vector vector = new Vector(10);
            //vector.InitRandom(1, 2);
            //Console.WriteLine("Original  " + vector.ToString());

            //Pair[] pairs = vector.CalculateFreq();
            //foreach (Pair pair in pairs)
            //{
            //    Console.WriteLine(pair.ToString());
            //}

            //vector.ReversMyImpl();
            //Console.WriteLine("Revers MyImpl " + vector.ToString());

            //vector.ReversStandart();
            //Console.WriteLine("Revers Standart " + vector.ToString());

            //int[] arr = { 1, 3, 4, 1, 2, 3, 1, 2, 3, 4 };
            ////Console.WriteLine(Vector.IsPolindrom(arr));
            //int[] maxSequence = Vector.GetMaxSequence(arr);
            //Console.WriteLine("for " + Vector.GetStringFromArray(arr));
            //Console.WriteLine("Max sequence is " + Vector.GetStringFromArray(maxSequence));

            //Matrix.SortMatrixDiagonal(4, Direction.right);

            int [,] matrix = new int[15,15];
            Matrix.InitRandom(matrix, 1, 2);
            Console.WriteLine("for ");
            
            Matrix.PrintMatrix(matrix);

            Console.WriteLine("Maximum square = " + Matrix.GetMaxSquare(matrix));

            //Console.WriteLine("Original  " + vector.ToString());

        }
    }
}
