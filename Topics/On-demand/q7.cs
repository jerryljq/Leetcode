/**
Q7. Reverse Integer
https://leetcode.com/problems/reverse-integer/description/

Given a signed 32-bit integer x, return x with its digits reversed. If reversing x causes the value to go outside the signed 32-bit integer range [-231, 231 - 1], then return 0.

Assume the environment does not allow you to store 64-bit integers (signed or unsigned).

Example 1:

Input: x = 123
Output: 321
Example 2:

Input: x = -123
Output: -321
Example 3:

Input: x = 120
Output: 21
 

Constraints:

-231 <= x <= 231 - 1
**/
public class Solution {
    public int Reverse(int x) {
        int sign = x < 0? -1 : 1;
        int temp = x;
        int result = 0;

        if (x == 0) return 0;
        while (temp != 0) {
            int digit = temp%10*sign;
            temp = temp/10;

            if (result > Int32.MaxValue/10) {
                return 0;
            }

            if (result == Int32.MaxValue/10 && digit > Int32.MaxValue%10) {
                return 0;
            }
            
            result = result * 10 + digit;
        }

        return result*sign;
    }
}