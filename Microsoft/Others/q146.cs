/// https://leetcode.com/problems/lru-cache/
/// Double Linked List
public class LRUCache {

    private DoubleLinkedList accessOrderList = null;
    private Dictionary<int, CustomListNode> valueList = null;
    private int capacity = -1;
    private int elementCount = 0;
    
    public LRUCache(int capacity) {
        this.accessOrderList = new DoubleLinkedList();
        this.valueList = new Dictionary<int, CustomListNode>();
        this.capacity = capacity;
    }
    
    public int Get(int key) {
        if (!this.valueList.ContainsKey(key)) {
            return -1;
        }
        
        var valueNode = valueList[key];
        this.accessOrderList.MoveNodeToBack(valueNode);
        return valueNode.Value;
    }
    
    public void Put(int key, int value) {
        if (!this.valueList.ContainsKey(key)) {
           if (elementCount == capacity) {
            // Remove the LRU key
                var keyRemoved = this.accessOrderList.RemoveFirst();

                if (keyRemoved != -1) {
                    elementCount -= 1;
                    this.valueList.Remove(keyRemoved);
                } else {
                    return;
                }
            }
            if (elementCount == capacity) {
                // Remove the LRU key
                var keyRemoved = this.accessOrderList.RemoveFirst();
                    
                if (keyRemoved != -1) {
                    elementCount -= 1;
                    this.valueList.Remove(keyRemoved);
                } else {
                    return;
                }
            }
            var newNode = new CustomListNode(key, value);
            elementCount += 1;
            this.valueList[key] = newNode;
            this.accessOrderList.AddNodeToBack(newNode);
        }
        else {
            var oldNode = this.valueList[key];
            oldNode.Value = value;
            this.accessOrderList.MoveNodeToBack(oldNode);
        }
    }
}

public class CustomListNode {
    public int Key { get; set; }
    public int Value { get; set; }
    
    public CustomListNode Next { get; set; } = null;
    public CustomListNode Previous { get; set; } = null;
    
    public CustomListNode(int key, int value) {
        this.Key = key;
        this.Value = value;
    }
}

public class DoubleLinkedList {
    private CustomListNode head = null;
    private CustomListNode tail = null;
    
    public DoubleLinkedList() {
        head = new CustomListNode(-1, -1);
        tail = new CustomListNode(-1, -1);
        
        head.Next = tail;
        tail.Previous = head;
    }
    
    public void AddNodeToBack(CustomListNode newNode) {
        newNode.Previous = this.tail.Previous;
        this.tail.Previous.Next = newNode;
        this.tail.Previous = newNode;
        newNode.Next = this.tail;
    }
    
    public void MoveNodeToBack(CustomListNode node) {
        var nodePrevious = node.Previous;
        var nodeNext = node.Next;
        nodePrevious.Next = nodeNext;
        nodeNext.Previous = nodePrevious;
        AddNodeToBack(node);
    }
    
    public int RemoveFirst() {
        var nodeToRemove = this.head.Next;
        if (nodeToRemove == this.tail) return -1;
        
        this.head.Next = nodeToRemove.Next;
        this.head.Next.Previous = this.head;
        
        return nodeToRemove.Key;
    }
}
 
/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */