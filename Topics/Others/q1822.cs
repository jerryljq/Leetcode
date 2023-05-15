/// https://leetcode.com/problems/sign-of-the-product-of-an-array/
public class Solution {
    public int ArraySign(int[] nums) {
        int result = 1;
        foreach (int num in nums) {
            if (num == 0) return 0;
            if (num < 0) result *= -1;
        }
        
        return result;
    }
}