/// https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one/
public class Solution {
    public int NumSteps(string s) {
        int index = s.Length-1;
        int count = 0;
        var sArray = s.ToCharArray();
        
        while (index > 0) {
            if (sArray[index] == '1') {
                // Plus 1
                // The carry over will influence all previous digits until another 0
                count += 1;
                
                while (index >= 0 && sArray[index] != '0') {
                    sArray[index] = '0';
                    count += 1;
                    index -= 1;
                }
                
                if (index > 0) {
                    sArray[index] = '1';
                }
            }
            else {
                // s[i] == '0' then divide by 2
                index -= 1;
                count += 1;
            }
        }
        
        return count;
    }
}