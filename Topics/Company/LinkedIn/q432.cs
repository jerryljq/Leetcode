/*
Q432. All O`one Data Structure
https://leetcode.com/problems/all-oone-data-structure/description/

Design a data structure to store the strings' count with the ability to return the strings with minimum and maximum counts.

Implement the AllOne class:

AllOne() Initializes the object of the data structure.
inc(String key) Increments the count of the string key by 1. If key does not exist in the data structure, insert it with count 1.
dec(String key) Decrements the count of the string key by 1. If the count of key is 0 after the decrement, remove it from the data structure. It is guaranteed that key exists in the data structure before the decrement.
getMaxKey() Returns one of the keys with the maximal count. If no element exists, return an empty string "".
getMinKey() Returns one of the keys with the minimum count. If no element exists, return an empty string "".
Note that each function must run in O(1) average time complexity.

Example 1:

Input
["AllOne", "inc", "inc", "getMaxKey", "getMinKey", "inc", "getMaxKey", "getMinKey"]
[[], ["hello"], ["hello"], [], [], ["leet"], [], []]
Output
[null, null, null, "hello", "hello", null, "hello", "leet"]

Explanation
AllOne allOne = new AllOne();
allOne.inc("hello");
allOne.inc("hello");
allOne.getMaxKey(); // return "hello"
allOne.getMinKey(); // return "hello"
allOne.inc("leet");
allOne.getMaxKey(); // return "hello"
allOne.getMinKey(); // return "leet"

Constraints:

1 <= key.length <= 10
key consists of lowercase English letters.
It is guaranteed that for each call to dec, key is existing in the data structure.
At most 5 * 104 calls will be made to inc, dec, getMaxKey, and getMinKey.
*/
public class AllOne {

    private Dictionary<string, ListNode> keyNodeMap;
    private ListNode head;
    private ListNode tail;

    public AllOne() {
        this.keyNodeMap = new Dictionary<string, ListNode>();
        this.head = new ListNode { Count = -1 };
        this.tail = new ListNode { Count = -1 };
        this.head.Next = this.tail;
        this.tail.Prev = this.head;
    }

    private void AddNewNode(ListNode newKeyNode) {
        var tempNext = this.head.Next;
        this.head.Next = newKeyNode;
        newKeyNode.Next = tempNext;
        tempNext.Prev = newKeyNode;
        newKeyNode.Prev = this.head;
    }

    private void CheckAndSwapNext(ListNode node) {
        while (node.Next.Count != -1 && node.Count > node.Next.Count) {
            var currPrev = node.Prev;
            currPrev.Next = node.Next;
            node.Next.Prev = currPrev;
            node.Next = node.Next.Next;
            node.Next.Prev = node;
            currPrev.Next.Next = node;
            node.Prev = currPrev.Next;
        }
    }

    private void CheckAndSwapPrev(ListNode node) {
        while (node.Prev.Count != -1 && node.Count < node.Prev.Count) {
            var currNext = node.Next;
            currNext.Prev = node.Prev;
            node.Prev.Next = currNext;
            node.Prev = node.Prev.Prev;
            node.Prev.Next = node;
            currNext.Prev.Prev = node;
            node.Next = currNext.Prev;
        }
    }

    private void RemoveNode(ListNode node) {
        node.Prev.Next = node.Next;
        node.Next.Prev = node.Prev;
    }
    
    public void Inc(string key) {
        if (!this.keyNodeMap.ContainsKey(key)) {
            var newKeyNode = new ListNode { Key = key, Count = 1 };
            this.keyNodeMap.Add(key, newKeyNode);
            // Add to list and swap
            this.AddNewNode(newKeyNode);
        } else {
            this.keyNodeMap[key].Count += 1;
            this.CheckAndSwapNext(this.keyNodeMap[key]);
        }
    }
    
    public void Dec(string key) {
        this.keyNodeMap[key].Count -= 1;
        if (this.keyNodeMap[key].Count > 0) {
            this.CheckAndSwapPrev(this.keyNodeMap[key]);
        } else {
            this.RemoveNode(this.keyNodeMap[key]);
        }
    }
    
    public string GetMaxKey() {
        if (this.tail.Prev.Count == -1) {
            return String.Empty;
        } else {
            return this.tail.Prev.Key;
        }
    }
    
    public string GetMinKey() {
        if (this.head.Next.Count == -1) {
            return String.Empty;
        } else {
            return this.head.Next.Key;
        }
    }
}

public class ListNode {
    public string Key { get; set; }
    public int Count { get; set; }
    public ListNode Next { get; set; }
    public ListNode Prev { get; set; }
}

/**
 * Your AllOne object will be instantiated and called as such:
 * AllOne obj = new AllOne();
 * obj.Inc(key);
 * obj.Dec(key);
 * string param_3 = obj.GetMaxKey();
 * string param_4 = obj.GetMinKey();
 */