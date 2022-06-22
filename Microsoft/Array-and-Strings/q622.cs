/// https://leetcode.com/problems/design-circular-queue/
/// This is a very simple question, but be careful of the indexes!
public class MyCircularQueue {

    private int[] queueValues;
    private int maxValue;
    private int begin;
    private int end;
    
    public MyCircularQueue(int k) {
        this.queueValues = new int[k];
        this.begin = 0;
        this.end = -1;
        this.maxValue = k;
    }
    
    public bool EnQueue(int value) {
        if (this.IsFull()) {
            return false;
        }
        
        if (this.end == -1) 
            this.end = this.begin;
        else {
            this.end += 1;
            if (this.end == maxValue) {
                this.end = 0;
            }
        }
        this.queueValues[this.end] = value;        
        
        return true;
    }
    
    public bool DeQueue() {
        if (this.IsEmpty()) return false;
        if (this.end < this.begin) {
            this.begin += 1;
        }
        else {
            this.begin += 1;
            if (this.end < this.begin)
                this.end = -1;
        }
        if (this.begin == this.maxValue)
                this.begin = 0;
        return true;
    }
    
    public int Front() {
        if (this.end == -1) return -1;
        return this.queueValues[this.begin];
    }
    
    public int Rear() {
        if (this.end == -1) return -1;
        return this.queueValues[this.end];
    }
    
    public bool IsEmpty() {
        return this.end == -1;
    }
    
    public bool IsFull() {
        return this.end - this.begin == this.maxValue-1 || (this.end - this.begin == -1 && this.end != -1);
    }
}

/**
 * Your MyCircularQueue object will be instantiated and called as such:
 * MyCircularQueue obj = new MyCircularQueue(k);
 * bool param_1 = obj.EnQueue(value);
 * bool param_2 = obj.DeQueue();
 * int param_3 = obj.Front();
 * int param_4 = obj.Rear();
 * bool param_5 = obj.IsEmpty();
 * bool param_6 = obj.IsFull();
 */