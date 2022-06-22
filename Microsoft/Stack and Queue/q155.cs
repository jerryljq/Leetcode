/// https://leetcode.com/problems/min-stack/
/// This question is not hard, just tricky.
/// Get in from the complexity requirements, and since no suitable data structure is possible, then we can only sacrifice space complexity.
public class MinStack {
    
    private Stack<(int, int)> stack;
    private int currentMin;

    public MinStack() {
        this.stack = new Stack<(int, int)>();
        this.currentMin = Int32.MaxValue;
    }
    
    public void Push(int val) {
      if (val < this.currentMin) {
          this.stack.Push((val, val));
          this.currentMin = val;
      }   
      else {
          this.stack.Push((val, this.currentMin));
      }
    }
    
    public void Pop() {
        var popped = this.stack.Pop();
        if (this.stack.Count == 0)
            this.currentMin = Int32.MaxValue;
        else
            this.currentMin = this.stack.Peek().Item2;
    }
    
    public int Top() {
        return this.stack.Peek().Item1;
    }
    
    public int GetMin() {
        return this.stack.Peek().Item2;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */