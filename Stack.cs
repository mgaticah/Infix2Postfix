using System;
public class StackItem{
    private double value;
    private StackItem next;    
    public StackItem(double value)
    {
        this.value=value;
    }
    public void SetNext(StackItem nextItem)
    {
        next=nextItem;
    }
    public StackItem GetNext()
    {
        return next;
    }
    public double GetValue()
    {
        return value;
    }
}
public class Stack{
    private StackItem top;

    public Stack()
    {
        top=null;
    }
    public bool IsEmpty()
    {
        return top==null;
    }
    public void Insert(double value)
    {
        var newItem= new StackItem(value);
        if (top != null)
            newItem.SetNext(top);
        top = newItem;
    }
    public double? Pop()
    {
        if (top==null)
            return null;
        var value=top.GetValue();
        if(top.GetNext()!=null)
            top=top.GetNext();
        return value;
    } 
    public StackItem Top()
    {
        return top;
    }
    
    public void Print()
    {
        Console.Write("STACK = {");
            if(!IsEmpty())
            {
                var temp=top;
                while(temp!=null)
                {
                    Console.Write(string.Format(" {0}",temp.GetValue()));
                    temp=temp.GetNext();
                }
            }
        Console.WriteLine("}");

    }
}