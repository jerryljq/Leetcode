/// https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/
/// This is when numbers array is sorted.
/// We don't need to use hash map with O(N) extra space.
/// Just two pointer will handle.
public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int begin = 0;
        int end = numbers.Count()-1;
        
        while (begin < end) {
            if (numbers[begin] + numbers[end] > target) {
                end -= 1;
            }
            else if (numbers[begin] + numbers[end] < target) {
                begin += 1;
            }
            else {
                return new int[] {begin+1, end+1};
            }
        }
        
        return new int[] {-1, -1};
    }
}