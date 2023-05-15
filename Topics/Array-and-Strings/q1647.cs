/// https://leetcode.com/problems/minimum-deletions-to-make-character-frequencies-unique/
/// Maybe details can be optimized. But overall is fine.
public class Solution {
    public int MinDeletions(string s) {
        if (string.IsNullOrEmpty(s) || s.Length == 1) {
            return 0;
        }
        
        var letterFrequencyList = new Dictionary<char, int>();
        int result = 0;

        foreach (char c in s) {
            if (letterFrequencyList.ContainsKey(c)) {
                letterFrequencyList[c] += 1;
            }
            else {
                letterFrequencyList[c] = 1;
            }
        }
        
        var frequencyList = letterFrequencyList.Values.ToList();
        
        if (frequencyList.Count == 1) return 0;
        
        frequencyList.Sort();
        
        
        for (int i = frequencyList.Count-1; i > 0; --i) {
            if (frequencyList[i] > frequencyList[i-1]) {
                continue;
            }
            
            while (frequencyList[i] <= frequencyList[i-1] && frequencyList[i-1] > 0) {
                frequencyList[i-1] -= 1;
                result += 1;
            }
        }
        
        return result;
    }
}