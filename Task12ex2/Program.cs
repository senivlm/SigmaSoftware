using System;

namespace Task12ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            string calcstring = "log(cos(1+2)+sin(6/2))=";

            string stringRPN = calc.getRPN(calcstring);

            Console.WriteLine(stringRPN);
        }
    }
}

