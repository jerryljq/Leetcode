/*
Q347. Top K Frequent Elements
https://leetcode.com/problems/top-k-frequent-elements/description/

Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

Example 1:
Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]
Example 2:
Input: nums = [1], k = 1
Output: [1]
 
Constraints:
1 <= nums.length <= 105
-104 <= nums[i] <= 104
k is in the range [1, the number of unique elements in the array].
It is guaranteed that the answer is unique.

Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
*/
public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        var counter = new Dictionary<int, int>();
        var heap = new PriorityQueue<int, int>();

        foreach(int num in nums) {
            if (!counter.ContainsKey(num)){
                counter[num] = 0;
            }
            counter[num] += 1;
        }

        foreach(var pair in counter) {
            heap.Enqueue(pair.Key, pair.Value);
            if (heap.Count > k) {
                heap.Dequeue();
            }
        }

        var result = new List<int>();
        for (int i = 0; i < k; ++i) {
            result.Add(heap.Dequeue());
        }

        return result.ToArray();
    }
}