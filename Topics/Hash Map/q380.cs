/// For this kind of question, the requirements look weird.
/// Find the best solution that solves each requirement first.
/// Then see how to combine them together.
/// https://leetcode.com/problems/insert-delete-getrandom-o1/
public class RandomizedSet {
    
    private Dictionary<int, int> valueIndexMap = new Dictionary<int, int>();
    private List<int> valueList = new List<int>();
    
    public RandomizedSet() {
        
    }
    
    public bool Insert(int val) {
        if (!valueIndexMap.ContainsKey(val)) {
            valueList.Add(val);
            valueIndexMap[val] = valueList.Count-1;
            return true;
        }
        return false;
    }
    
    public bool Remove(int val) {
        if (valueIndexMap.ContainsKey(val)) {
            
            var valueIndex = valueIndexMap[val];
            var replaceValue = valueList[valueList.Count-1];
            valueList[valueIndex] = replaceValue;
            valueIndexMap[replaceValue] = valueIndex;
            valueList.RemoveAt(valueList.Count-1);
            valueIndexMap.Remove(val);
            
            return true;
        }
        
        return false;
    }
    
    public int GetRandom() {
        var random = new Random();
        return valueList[random.Next(valueList.Count)];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */