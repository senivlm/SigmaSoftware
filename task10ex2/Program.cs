using System;

namespace task10ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix= new Matrix(4);
            matrix.InitIncriment();
            Console.WriteLine(matrix.EnumDirection);
            Console.WriteLine(matrix.ToString());

            matrix = new Matrix(4, Direction.Down);
            matrix.InitIncriment();
            Console.WriteLine(matrix.EnumDirection);
            Console.WriteLine(matrix.ToString());


            matrix = new Matrix(4, Direction.Diagonal);
            matrix.InitIncriment();
            Console.WriteLine(matrix.EnumDirection);
            Console.WriteLine(matrix.ToString());

        }


    }
}
