public class Solution {
    public bool IsPalindrome(string s) {
        int i = 0;
        int j = s.Length-1;
        
        while (i < j) {
            if (ShouldSkip(s[i])) {
                i++;
                continue;
            }
            
            if (ShouldSkip(s[j])) {
                j--;
                continue;
            }
            
            if (!AreEqual(s[i], s[j])) {
                return false;
            }
            
            i++;
            j--;
        }
        
        return true;
    }
    
    private bool AreEqual(char a, char b) {
        if (a == b) {
            return true;
        }
        else if (a >= 'A' && a <= 'Z') {
            if (a - 'A' + 'a' == b) {
                return true;
            }
            return false;
        }
        else if (a >= 'a' && a <= 'z') {
            if (a - 'a' + 'A' == b) {
                return true;
            }
            return false;
        }
        
        return false;
    }
    
    private bool ShouldSkip (char a) {
        return !((a >= 'a' && a <= 'z') || (a >= 'A' && a <= 'Z') || (a >= '0' && a <= '9'));
    }
}