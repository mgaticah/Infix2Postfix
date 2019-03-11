using Xunit;
public class StackTests{

    [Fact]
    public void ValidateEmptyStack()
    {
        var stack=new Stack();
        Assert.True(stack.IsEmpty());
    }
    [Fact]
    public void InsertStackItem()
    {
        var stack=new Stack();
        stack.Insert(2);
        Assert.Equal(2,stack.Top().GetValue());
    }
    [Fact]
    public void InsertStackItemAndValidateNotEmptystack()
    {
        var stack=new Stack();
        stack.Insert(2);
        Assert.Equal(2,stack.Top().GetValue());
        Assert.False(stack.IsEmpty());
    }

}