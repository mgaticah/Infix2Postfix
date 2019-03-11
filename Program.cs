using System;

namespace Infix2Postfix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack implementation");
            var stack= new Stack();
            stack.Insert(2);
            stack.Insert(4);
            stack.Insert(5);
            stack.Insert(-3);
            stack.Insert(2.9);
            stack.Print();
        }
    }
}
