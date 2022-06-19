/// This problem may not be a common one during Microsoft interviews, but a pretty classic one to demonstrate the Trie solution.
/// https://leetcode.com/problems/map-sum-pairs/
public class MapSum {

    private TrieNode rootNode;
    
    public MapSum() {
        this.rootNode = new TrieNode();
    }
    
    public void Insert(string key, int val) {
        var currentNode = this.rootNode;
        
        foreach (char c in key) {
            if (!currentNode.nodeList.ContainsKey(c)) {
                currentNode.nodeList[c] = new TrieNode();
            }
            currentNode = currentNode.nodeList[c];
        }
        
        currentNode.SetWord(val);
    }
    
    public int Sum(string prefix) {
        var currentNode = this.rootNode;
        int sum = 0;
        
        foreach (char c in prefix) {
            if (!currentNode.nodeList.ContainsKey(c)) {
                return sum;
            }
            currentNode = currentNode.nodeList[c];
        }
                
        var queueList = new Queue<TrieNode>();
        queueList.Enqueue(currentNode);
        
        while(queueList.Count > 0) {
            var nextNode = queueList.Dequeue();
            sum += nextNode.IsWord? nextNode.Value : 0;
            
            var childrenNodes = nextNode.nodeList.Values.ToList();
            foreach (var node in childrenNodes) {
                queueList.Enqueue(node);
            }
        }
        
        return sum;
    }
}

public class TrieNode {
    public Dictionary<char, TrieNode> nodeList = new Dictionary<char, TrieNode>();
    public bool IsWord {get; set;}
    public int Value {get; set;}
    
    public void SetWord(int value) {
        this.IsWord = true;
        this.Value = value;
    }
}

/**
 * Your MapSum object will be instantiated and called as such:
 * MapSum obj = new MapSum();
 * obj.Insert(key,val);
 * int param_2 = obj.Sum(prefix);
 */