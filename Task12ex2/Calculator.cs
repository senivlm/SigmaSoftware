using System;
using System.Collections.Generic;
using System.Text;

namespace Task12ex2
{
    public class Calculator
    {
        private List<string> alowwedOperators;
        private char delimiter;
        private char doubleSeparator;
        private char finishChar;
        private char bracketBegin;
        private char bracketEnd;


        public Calculator()
        {
            alowwedOperators = new List<string>() { "+", "-", "/", ":", "*", "^", "(", ")", "sin", "cos", "log" };
            delimiter = ' ';
            finishChar = '=';
            doubleSeparator = '.';
            bracketBegin = '(';
            bracketEnd = ')';
        }

        private bool IsDelimeter(char c)
        {
            return delimiter.Equals(c) || finishChar.Equals(c);
        }

        private bool IsCharOfDouble(char c)
        {
            return Char.IsDigit(c) || doubleSeparator.Equals(c);
        }

        private int GetPriority(string s)
        {
            switch (s)
            {
                case "(": return 0;
                case ")": return 1;
                case "+": return 2;
                case "-": return 3;
                case "*": return 4;
                case "/": return 5;
                case "^": return 6;
                case "cos": return 7;
                case "sin": return 8;
                case "log": return 9;
                default: return 9;
            }
        }

        public string GetRPN(string calcstring)
        {
            string output = "";
            Stack<string> operStack = new Stack<string>();
            int stringLength = calcstring.Length;

            for (int i = 0; i < stringLength; i++)
            {

                if (IsDelimeter(calcstring[i]))
                    continue;


                if (IsCharOfDouble(calcstring[i]))
                {
                    while (i < stringLength && IsCharOfDouble(calcstring[i]))
                    {
                        output += calcstring[i];
                        i++;
                    }

                    output += delimiter;
                    i--;
                    continue;
                }

                if (!IsCharOfDouble(calcstring[i]))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(calcstring[i]);
                    if (!alowwedOperators.Contains(sb.ToString()))
                    {
                        while (i < stringLength - 1
                        && !IsCharOfDouble(calcstring[i + 1])
                        && !IsDelimeter(calcstring[i + 1]))
                        {
                            if (alowwedOperators.Contains(calcstring[i + 1].ToString()))
                            {
                                break;
                            }
                            sb.Append(calcstring[i + 1]);
                            i++;
                        }
                    }
                    string oper = sb.ToString();


                    if (alowwedOperators.Contains(oper))
                    {
                        if (oper.Equals(bracketBegin.ToString()))
                            operStack.Push(oper);
                        else if (oper.Equals(bracketEnd.ToString()))
                        {
                            string s = operStack.Pop();
                            while (!s.Equals(bracketBegin.ToString()))
                            {
                                output += s + delimiter;
                                if (operStack.Count == 0)
                                    break;

                                s = operStack.Pop();

                            }
                        }
                        else
                        {
                            if (operStack.Count > 0)
                                if (GetPriority(oper) <= GetPriority(operStack.Peek()))
                                    output += operStack.Pop() + delimiter;

                            operStack.Push(oper);

                        }
                    }
                }
            }


            while (operStack.Count > 0)
                output += operStack.Pop() + delimiter;

            return output;
        }

        public double CalcRPN(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();
            int stringLength = input.Length;
            for (int i = 0; i < stringLength; i++)
            {

                StringBuilder sb = new StringBuilder();
                if (IsDelimeter(input[i]))
                {
                    sb.Append(input[i]);
                }
                else
                {
                    if (IsCharOfDouble(input[i]))
                    {
                        while (i < stringLength && IsCharOfDouble(input[i]))
                        {
                            sb.Append(input[i]);
                            i++;
                        }

                        i--;
                    }
                    else
                    {
                        sb.Append(input[i]);
                        if (!alowwedOperators.Contains(sb.ToString()))
                        {
                            while (i < stringLength - 1
                            && !IsCharOfDouble(input[i + 1])
                            && !IsDelimeter(input[i + 1]))
                            {
                                if (alowwedOperators.Contains(input[i + 1].ToString()))
                                {
                                    break;
                                }
                                sb.Append(input[i + 1]);
                                i++;
                            }
                        }

                    }
                }
                string oper = sb.ToString();
                double d = 0;
                if (Double.TryParse(sb.ToString(), out d))
                {
                    temp.Push(d);
                }
                else if (alowwedOperators.Contains(sb.ToString()))
                {

                    switch (sb.ToString())
                    {
                        case "+":
                            {
                                double a = temp.Count > 0 ? temp.Pop() : 0;
                                double b = temp.Count > 0 ? temp.Pop() : 0;
                                result = b + a; break;
                            }
                        case "-":
                            {
                                double a = temp.Count > 0 ? temp.Pop() : 0;
                                double b = temp.Count > 0 ? temp.Pop() : 0;
                                result = b - a; break;
                            }
                        case "*":
                            {
                                double a = temp.Count > 0 ? temp.Pop() : 0;
                                double b = temp.Count > 0 ? temp.Pop() : 0;
                                result = b * a;
                                break;
                            }
                        case "/":
                            {
                                double a = temp.Count > 0 ? temp.Pop() : 0;
                                double b = temp.Count > 0 ? temp.Pop() : 0;
                                result = b / a;
                                break;
                            }
                        case "^":
                            {
                                double a = temp.Count > 0 ? temp.Pop() : 0;
                                double b = temp.Count > 0 ? temp.Pop() : 0;
                                result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString());
                                break;
                            }

                        case "cos":
                            {
                                double a = temp.Count > 0 ? temp.Pop() : 0;
                                result = Math.Cos(Math.PI * a / 180.0);
                                break;
                            }

                        case "sin":
                            {
                                double a = temp.Count > 0 ? temp.Pop() : 0;
                                result = Math.Sin(Math.PI * a / 180.0);
                                break;
                            };
                        case "log":
                            {
                                {
                                    double a = temp.Count > 0 ? temp.Pop() : 0;
                                    result = Math.Log10(a);
                                    break;
                                }
                            }

                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }

    }
}


