///https://leetcode.com/problems/longest-happy-string/
/// Priority Queue
/// Greedy
public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        var priorityQueue = new PriorityQueue<char, int>();
        if (a > 0) priorityQueue.Enqueue('a', -a);
        if (b > 0) priorityQueue.Enqueue('b', -b);
        if (c > 0) priorityQueue.Enqueue('c', -c);
        
        var stringBuilder = new StringBuilder();
        
        while(priorityQueue.Count > 0) {
            char nextChar;
            int priorityValue;
            priorityQueue.TryDequeue(out nextChar, out priorityValue);
            
            if (stringBuilder.Length >= 2 && nextChar == stringBuilder[stringBuilder.Length-1] && nextChar == stringBuilder[stringBuilder.Length-2]) {
                char replacementChar;
                int repPriorityVal;
                var succ = priorityQueue.TryDequeue(out replacementChar, out repPriorityVal);
                if (succ)
                    stringBuilder.Append(replacementChar);
                else 
                    break;
                
                if (repPriorityVal+1 < 0)
                    priorityQueue.Enqueue(replacementChar, repPriorityVal+1);
                priorityQueue.Enqueue(nextChar, priorityValue);
            }
            else {
                stringBuilder.Append(nextChar);
                if (priorityValue+1 < 0)
                    priorityQueue.Enqueue(nextChar, priorityValue+1);
            }
        }
        
        return stringBuilder.ToString();
    }
}