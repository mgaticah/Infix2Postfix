using System;
using System.Collections.Generic;
using System.Linq;

namespace Infix2Postfix
{
    class Program
    {   
        static void Main(string[] args)
        {
            var expression = "a+b*c-d*e";
            var postFix= new Infix2PostfixConverter().Convert(expression);
            Console.WriteLine(expression + " = " + postFix);

        }
    }
}
