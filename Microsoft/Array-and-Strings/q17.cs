public class Solution {
    private Dictionary<char, IList<string>> digitMap = 
        new Dictionary<char, IList<string>>() {
            { '2', new List<string> {"a", "b", "c"}},
            { '3', new List<string> {"d", "e", "f"}},
            { '4', new List<string> {"g", "h", "i"}},
            { '5', new List<string> {"j", "k", "l"}},
            { '6', new List<string> {"m", "n", "o"}},
            { '7', new List<string> {"p", "q", "r", "s"}},
            { '8', new List<string> {"t", "u", "v"}},
            { '9', new List<string> {"w", "x", "y", "z"}},
        };
    
    public IList<string> LetterCombinations(string digits) {
        return FindCombination(digits);
    }
    
    public IList<string> FindCombination(string digits) {
        if (digits.Length == 0) return new List<string>();
        if (digits.Length == 1) return this.digitMap[digits[0]];
        
        var nextDigitGroup = digits.Substring(1, digits.Length-1);
        var nextPossibleStr = FindCombination(nextDigitGroup);
        var currentDigitPossibleValues = this.digitMap[digits[0]];
        var result = new List<string>();
        
        foreach (string x in currentDigitPossibleValues) {
            foreach (string y in nextPossibleStr) {
                result.Add($"{x}{y}");
            }
        }
        
        return result;
    }
}