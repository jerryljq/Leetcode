/**
 * Q364. Nested List Weight Sum II
 * https://leetcode.com/problems/nested-list-weight-sum-ii/description/
 * // This is the interface that allows for creating nested lists.
 * // You should not implement it, or speculate about its implementation
 * interface NestedInteger {
 *
 *     // Constructor initializes an empty nested list.
 *     public NestedInteger();
 *
 *     // Constructor initializes a single integer.
 *     public NestedInteger(int value);
 *
 *     // @return true if this NestedInteger holds a single integer, rather than a nested list.
 *     bool IsInteger();
 *
 *     // @return the single integer that this NestedInteger holds, if it holds a single integer
 *     // Return null if this NestedInteger holds a nested list
 *     int GetInteger();
 *
 *     // Set this NestedInteger to hold a single integer.
 *     public void SetInteger(int value);
 *
 *     // Set this NestedInteger to hold a nested list and adds a nested integer to it.
 *     public void Add(NestedInteger ni);
 *
 *     // @return the nested list that this NestedInteger holds, if it holds a nested list
 *     // Return null if this NestedInteger holds a single integer
 *     IList<NestedInteger> GetList();
 * }
 */
public class Solution {
    public int DepthSumInverse(IList<NestedInteger> nestedList) {
        var listSum = 0;
        var queue = new Queue<NestedInteger>();
        var list = new List<(int, int)>();
        foreach (var listElement in nestedList) {
            queue.Enqueue(listElement);
        }

        int depth = 1;

        while (queue.Count > 0) {
            int queueCount = queue.Count;
            for (int i = 0; i < queueCount; ++i) {
                var nextInt = queue.Dequeue();
                if (nextInt.IsInteger()) {
                    list.Add((nextInt.GetInteger(), depth));
                } else {
                    var nextList = nextInt.GetList();
                    foreach (var next in nextList) {
                        queue.Enqueue(next);
                    }
                }
            }
            depth += 1;
        }

        foreach (var element in list) {
            int weight = depth-element.Item2;
            listSum += element.Item1*weight;
        }

        return listSum;
    }
}