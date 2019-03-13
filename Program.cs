using System;
using System.Collections.Generic;
using System.Linq;

namespace Infix2Postfix
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var expression="a+b*c";
            var operators=new List<MathOperator>();
            operators.Add(new MathOperator("+",1));
            operators.Add(new MathOperator("-",1));
            operators.Add(new MathOperator("*",2));
            operators.Add(new MathOperator("/",2));
            var operatorsStack=new GenericStack<string>();
            var operandsStack=new GenericStack<string>();
            var operand="";
            foreach(var letter in expression)
                if(operators.Any( v=>v.GetSymbol()==letter.ToString()))
                {
                    operandsStack.Insert(operand.ToString());
                    operatorsStack.Insert(letter.ToString());
                    operand="";
                }
                else
                    operand+=letter.ToString();
            if(!string.IsNullOrEmpty(operand))
            {
               operandsStack.Insert(operand.ToString());
                operand="";
            }
            operandsStack.Print();
            operatorsStack.Print();
            
        }
    }
}
