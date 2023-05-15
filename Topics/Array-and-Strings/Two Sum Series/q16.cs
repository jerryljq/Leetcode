/// https://leetcode.com/problems/3sum-closest/
/// Another variant of 3sum.
/// Don't be trapped into the logic of 3sum.
/// They may be really different.
public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        var minAbsDiff = Int32.MaxValue;
        var result = 0;
        
        var numList = new List<int>(nums);
        numList.Sort();
        
        for (int i = 0; i < numList.Count(); ++i) {
            int begin = i + 1;
                int end = numList.Count()-1;
                
                while (begin < end) {
                    var sum = numList[begin]+numList[end]+numList[i];
                    if (Math.Abs(sum-target) < minAbsDiff) {
                        result = sum;
                        minAbsDiff = Math.Abs(sum-target);
                    }
                    
                    if(sum < target){
                        begin += 1;
                    }
                    else {
                        end -= 1;
                    }
                }
        }
        
        return result;
    }
}