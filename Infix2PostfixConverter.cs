using System.Collections.Generic;
using System.Linq;

public class Infix2PostfixConverter
{
    private List<MathOperator> operators;
    public Infix2PostfixConverter()
    {
        CreateOperators();
    }
    public string Convert(string expression)
    {
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
            postFix += operand + " ";
        while (!operatorsStack.IsEmpty())
            postFix += operatorsStack.Pop().GetSymbol() + " ";
        return postFix;
    }
    private void CreateOperators()
    {
        operators = new List<MathOperator>();
        operators.Add(new MathOperator("+", 1));
        operators.Add(new MathOperator("-", 1));
        operators.Add(new MathOperator("*", 2));
        operators.Add(new MathOperator("/", 2));
    }
    private bool IsOperator(char letter)
    {
        return operators.Any(x => x.GetSymbol() == letter.ToString());
    }
    private MathOperator GetOperator(char letter)
    {
        return operators.FirstOrDefault(x => x.GetSymbol() == letter.ToString());
    }
    private bool OperatorHasPriorityInStack(MathOperator mathOperator, GenericStack<MathOperator> operatorsStack)
    {
        return operatorsStack.IsEmpty() || mathOperator.GetPriority() > operatorsStack.Top().GetValue().GetPriority();
    }
}