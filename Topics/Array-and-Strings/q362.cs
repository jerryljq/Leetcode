/// This question seems like a loop structure, which might go in a way like Queue or Circled Linked List.
/// However, don't over complicate the problem since you don't really care the details of each hit.
/// Just each hit counts. That's it.
/// A simple queue would solve the problem.
/// https://leetcode.com/problems/design-hit-counter/
public class HitCounter_Easy {

    private Queue<int> counterList;
    
    public HitCounter() {
        this.counterList = new Queue<int>();
    }
    
    public void Hit(int timestamp) {
        counterList.Enqueue(timestamp);
    }
    
    public int GetHits(int timestamp) {
        // Make sure before Peek, check the count, or the Queue would throw exception. 
        while (counterList.Count() > 0 && timestamp - counterList.Peek() >= 300) {
            counterList.Dequeue();
        }
        
        return counterList.Count();
    }
}

/// However, when the number of hits at the same timestamp is high, the cost of the previous solution is going to be high too.
/// The cost is mainly at counting the items in the queue.
/// So for the entries with the same timestamp, we can group them together and figure out the count in once.
/// To do this easily we can introduce the Deque data structure (2-way Queue).
///
/// In C#, there is no out-of-the-box Deque class, so to achieve the 2 way operation,
/// we could simply create a node class and maintain the latest insertion separately.
/// 
public class HitCounter_Dequeue {

    private Queue<CounterNode> counterList;
    private CounterNode lastEntry = null;
    private int totalCount = 0;
    
    public HitCounter() {
        this.counterList = new Queue<CounterNode>();
    }
    
    public void Hit(int timestamp) {
        if (lastEntry == null || lastEntry.Timestamp != timestamp) {
            lastEntry = new CounterNode(timestamp);
            counterList.Enqueue(lastEntry);
        }
        else {
            lastEntry.AddCount();
        }
        totalCount += 1;
    }
    
    public int GetHits(int timestamp) {
        while (counterList.Count() > 0 && timestamp - counterList.Peek().Timestamp >= 300) {
            var earlyHit = counterList.Dequeue();
            this.totalCount -= earlyHit.Count;
        }
        
        return this.totalCount;
    }
}

public class CounterNode {
    public int Timestamp {get; set;}
    public int Count {get; set;}
    
    public CounterNode(int timestamp) {
        this.Timestamp = timestamp;
        this.Count = 1;
    }
    
    public void AddCount() {
        this.Count += 1;
    }
}

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter obj = new HitCounter();
 * obj.Hit(timestamp);
 * int param_2 = obj.GetHits(timestamp);
 */