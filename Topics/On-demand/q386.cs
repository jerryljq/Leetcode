/*
Q386. Lexicographical Numbers
https://leetcode.com/problems/lexicographical-numbers/description/

Given an integer n, return all the numbers in the range [1, n] sorted in lexicographical order.
You must write an algorithm that runs in O(n) time and uses O(1) extra space. 

Example 1:
Input: n = 13
Output: [1,10,11,12,13,2,3,4,5,6,7,8,9]
Example 2:
Input: n = 2
Output: [1,2]

Constraints:
1 <= n <= 5 * 104
*/
public class Solution {
    public IList<int> LexicalOrder(int n) {
        var result = new List<int>();
        
        for (int i = 1; i < 10 && i <= n; ++i) {
            result.Add(i);
            this.FindSubset(i*10, n, ref result);
        }

        return result;
    }

    private void FindSubset(int baseNum, int max, ref List<int> result) {
        if (baseNum > max) {
            return;
        }

        for (int i = 0; i < 10; ++i) {
            int newNum = baseNum + i;
            if (newNum <= max) {
                result.Add(newNum);
                this.FindSubset(newNum*10, max, ref result);
            } else {
                break;
            }
        }

        return;
    }
}