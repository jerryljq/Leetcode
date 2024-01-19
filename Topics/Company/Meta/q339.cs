/**
 * Q339. Nested List Weight Sum
 * https://leetcode.com/problems/nested-list-weight-sum/description/
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
    public int DepthSum(IList<NestedInteger> nestedList) {
        var listSum = 0;
        foreach (var listElement in nestedList) {
            listSum += this.GetWeightSum(listElement, 1);
        }

        return listSum;
    }

    private int GetWeightSum(NestedInteger nestedInt, int depth) {
        if (nestedInt.IsInteger()) {
            return nestedInt.GetInteger()*depth;
        }

        var listSum = 0;
        foreach (var listElement in nestedInt.GetList()) {
            listSum += this.GetWeightSum(listElement, depth+1);
        }

        return listSum;
    }
}