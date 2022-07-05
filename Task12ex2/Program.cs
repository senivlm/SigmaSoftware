using System;

namespace Task12ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();

            Console.WriteLine("Original");
            string calcstring = "log(cos(2-2)*40+10+50*sin(60+30))=";
            Console.WriteLine(calcstring);
            string stringRPN = calc.GetRPN(calcstring);
            Console.WriteLine("transformed to RPN");
            Console.WriteLine(stringRPN);

            double result = calc.CalcRPN(stringRPN);
            Console.Write("Result = ");
            Console.WriteLine(result.ToString());

            
        }
    }
}

