/**
80. Remove Duplicates from Sorted Array II

Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.

Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.

Return k after placing the final result in the first k slots of nums.

Do not allocate extra space for another array. You must do this by modifying the input array in-place with O(1) extra memory.
**/
public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int swapLocation = 1;
        int current = 1;
        int elementCounter = 1;

        if (nums.Count() <= 2) return nums.Count();

        while (current < nums.Count()) {
            if (nums[current] == nums[current-1]) {
                elementCounter += 1;
            } else {
                elementCounter = 1;
            }

            if (elementCounter < 3) {
                if (current != swapLocation) {
                    nums[swapLocation] = nums[current];
                }
                swapLocation += 1;
            }

            current += 1;
        }

        return swapLocation;
    }
}