using System;

namespace task11ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myListInt = new() { 1, 3, 4, 5, 6, 7, 8, 9 };
            myListInt.Insert(1,2);
            Console.WriteLine(myListInt);

            MyList<String> myListString = new() {"first", "second", "third",
                                                "fourth", "fifth", "sixth",
                                                "seventh","seventh",
                                                "eighth", "ninth","tenth"};
            myListString.Remove("seventh");
            Console.WriteLine(myListString);
        }

    }
}

