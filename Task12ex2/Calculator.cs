using System;
using System.Collections.Generic;
using System.Text;

namespace Task12ex2
{
    public class Calculator
    {
        private  List<string> alowwedOperators;
        private char delimiter;
        private char finishChar;
        private char bracketBegin;
        private char bracketEnd;


        public Calculator()
        {
            alowwedOperators = new List<string>() { "+", "-", "/", ":", "*", "^", "(", ")", "sin", "cos", "log" };
            delimiter = ' ';
            finishChar = '=';
            bracketBegin = '(';
            bracketEnd = ')';
        }

        private bool IsDelimeter(char c)
        {
            if (delimiter.Equals(c) || finishChar.Equals(c))
                return true;
            return false;
        }


        public static double calc(string calcstring)
        {
           string[] members =calcstring.Split();
            return 0;
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

        public string getRPN(string calcstring)
        {
            string output = "";
            Stack<string> operStack = new Stack<string>();
            int stringLength = calcstring.Length;

            for (int i = 0; i < stringLength; i++) 
            {
                
                if (IsDelimeter(calcstring[i]))
                    continue;


               if (Char.IsDigit(calcstring[i]))
               { 
                while (i < stringLength && Char.IsDigit(calcstring[i]) )
                    {
                        output += calcstring[i]; 
                        i++; 
                    }

                   output += delimiter; 
                   i--;
                   continue;
                }

                if (!Char.IsDigit(calcstring[i]))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(calcstring[i]);
                    if (!alowwedOperators.Contains(sb.ToString()))
                    {
                        while (i < stringLength - 1
                        && !Char.IsDigit(calcstring[i + 1])
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

            return output; //Возвращаем выражение в постфиксной записи
        }
    }

    public double CalcRPN(string input)
    {
        double result = 0; 
        Stack<double> temp = new Stack<double>(); 

        for (int i = 0; i < input.Length; i++)
        {
            //Если символ - цифра, то читаем все число и записываем на вершину стека
            if (Char.IsDigit(input[i]))
            {
                string a = string.Empty;

                while (!IsDelimeter(input[i]) && !IsOperator(input[i])) //Пока не разделитель
                {
                    a += input[i]; //Добавляем
                    i++;
                    if (i == input.Length) break;
                }
                temp.Push(double.Parse(a)); //Записываем в стек
                i--;
            }
            else if (IsOperator(input[i])) //Если символ - оператор
            {
                //Берем два последних значения из стека
                double a = temp.Pop();
                double b = temp.Pop();

                switch (input[i]) //И производим над ними действие, согласно оператору
                {
                    case '+': result = b + a; break;
                    case '-': result = b - a; break;
                    case '*': result = b * a; break;
                    case '/': result = b / a; break;
                    case '^': result = double.Parse(Math.Pow(double.Parse(b.ToString()), double.Parse(a.ToString())).ToString()); break;
                }
                temp.Push(result); //Результат вычисления записываем обратно в стек
            }
        }
        return temp.Peek(); 
    }

}

