public class Solution {
    public int[] PlusOne(int[] digits) {
        int carryOver = 0;
        
        int newDigit = (digits[digits.Count()-1] + 1);
        digits[digits.Count()-1] = newDigit % 10;
        carryOver = newDigit / 10;
        
        for(int i = digits.Count()-2; i >= 0 && carryOver == 1; --i) {
            int newDigit2 = (digits[i] + carryOver);
            digits[i] = newDigit2 % 10;
            carryOver = newDigit2 / 10;
        }
        
        if (carryOver == 1) {
            int[] newArray = new int[digits.Count() + 1];
            newArray[0] = 1;
            Array.Copy(digits, 0, newArray, 1, digits.Count());
            return newArray;
        }
        else {
            return digits;
        }
    }
}