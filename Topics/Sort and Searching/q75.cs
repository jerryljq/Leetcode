public class Solution {
    public void SortColors(int[] nums) {
        int i = 0;
        int j = nums.Count()-1;
        int current = 0;
        
        while (current <= j) {
            if (nums[current] == 0)
            {
                this.swap(ref nums, i, current);
                i++;
                current++;
            }
            else if (nums[current] == 1)
            {
                current++;
            }
            else {
                this.swap(ref nums, current, j);
                j--;
            }
        }
    } 
    
    private void swap(ref int[] nums, int i, int j) {
        if (i == j) {
            return;
        }
        else {
            int a = nums[i];
            nums[i] = nums[j];
            nums[j] = a;
        }
    }
}