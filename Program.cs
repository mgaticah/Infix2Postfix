using System;
using System.Collections.Generic;
using System.Linq;

namespace Infix2Postfix
{
    class Program
    {
        static List<MathOperator> CreateOperators()
        {
            var operators = new List<MathOperator>();
            operators.Add(new MathOperator("+", 1));
            operators.Add(new MathOperator("-", 1));
            operators.Add(new MathOperator("*", 2));
            operators.Add(new MathOperator("/", 2));
            return operators;
        }
        private static bool IsOperator(char letter)
        {
            var operators = CreateOperators();
            return operators.Any(x => x.GetSymbol() == letter.ToString());
        }
        private static MathOperator GetOperator(char letter)
        {
            var operators = CreateOperators();
            return operators.FirstOrDefault(x => x.GetSymbol() == letter.ToString());
        }
        private static bool OperatorHasPriorityInStack(MathOperator mathOperator, GenericStack<MathOperator> operatorsStack)
        {
            return operatorsStack.IsEmpty() || mathOperator.GetPriority() > operatorsStack.Top().GetValue().GetPriority();
        }
        static void Main(string[] args)
        {
            var expression = "a+b*c-d";
            var postFix = "";
            var operatorsStack = new GenericStack<MathOperator>();
            var operandsStack = new GenericStack<string>();
            var operand = "";
            foreach (var letter in expression)
            {
                if (IsOperator(letter))
                {
                    operandsStack.Insert(operand);
                    postFix += operand + " ";
                    operand = string.Empty;
                    var mathOperator = GetOperator(letter);
                    if (!OperatorHasPriorityInStack(mathOperator, operatorsStack))
                        while (!operatorsStack.IsEmpty())
                            postFix += operatorsStack.Pop().GetSymbol() + " ";
                    operatorsStack.Insert(mathOperator);
                }
                else
                {
                    operand += letter.ToString();
                }
            }
            if (!string.IsNullOrEmpty(operand))
                postFix += operand+" ";
            while (!operatorsStack.IsEmpty())
                postFix += operatorsStack.Pop().GetSymbol() + " ";

            Console.WriteLine(expression + "=" + postFix);

        }
    }
}
