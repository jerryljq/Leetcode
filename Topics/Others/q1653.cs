/// https://leetcode.com/problems/minimum-deletions-to-make-string-balanced/
public class Solution {
    public int MinimumDeletions(string s) {
        var charCalTable = new int[s.Length, 2];
        
        int bBeforeCurrent = 0;
        int aAfterCurrent = 0;
        for (int i = 0; i < s.Length-1; ++i) {
            if (s[i] == 'b') {
                bBeforeCurrent += 1;
            }
            if (s[s.Length-1-i] == 'a') {
                aAfterCurrent += 1;
            }
            charCalTable[i+1, 0] = bBeforeCurrent;
            charCalTable[s.Length-2-i, 1] = aAfterCurrent;
        }
        
        var result = charCalTable[0,0]+charCalTable[0,1];

        for (int i = 0; i < s.Length; ++i) {
            if (charCalTable[i, 0] + charCalTable[i, 1] < result) {
                result = charCalTable[i, 0] + charCalTable[i, 1];
            } 
        }        
        
        return result;
    }
}