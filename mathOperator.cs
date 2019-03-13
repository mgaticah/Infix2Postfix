public class MathOperator{
        string symbol;
        int  priority;
        public MathOperator(string symbol, int priority)
        {
            this.symbol=symbol;
            this.priority=priority;
        }
        public string GetSymbol()
        {
            return symbol; 
        }
        public int GetPriority()
        {
            return priority;
        }
    }