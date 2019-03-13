using System;
using System.Collections.Generic;
public class GenericStackItem<T>{
    private T value;
    private GenericStackItem<T> next;    
    public GenericStackItem(T value)
    {
        this.value=value;
    }
    public void SetNext(GenericStackItem<T> nextItem)
    {
        next=nextItem;
    }
    public GenericStackItem<T> GetNext()
    {
        return next;
    }
    public T GetValue()
    {
        return value;
    }
}
public class GenericStack<T>{
    private GenericStackItem<T> top;

    public GenericStack()
    {
        top=null;
    }
    public bool IsEmpty()
    {
        return top==null;
    }
    public void Insert(T value)
    {
        var newItem= new GenericStackItem<T>(value);
        if (top != null)
            newItem.SetNext(top);
        top = newItem;
    }
    public T Pop()
    {
        if (top==null)
            return default(T);
        var value=top.GetValue();
        if(top.GetNext()!=null)
            top=top.GetNext();
        return value;
    } 
    public GenericStackItem<T> Top()
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