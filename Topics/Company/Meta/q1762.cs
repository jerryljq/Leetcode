/**
* Q1762. Buildings With an Ocean View
* https://leetcode.com/problems/buildings-with-an-ocean-view/description/

There are n buildings in a line. You are given an integer array heights of size n that represents the heights of the buildings in the line.

The ocean is to the right of the buildings. A building has an ocean view if the building can see the ocean without obstructions. Formally, a building has an ocean view if all the buildings to its right have a smaller height.

Return a list of indices (0-indexed) of buildings that have an ocean view, sorted in increasing order.

Example 1:

Input: heights = [4,2,3,1]
Output: [0,2,3]
Explanation: Building 1 (0-indexed) does not have an ocean view because building 2 is taller.
Example 2:

Input: heights = [4,3,2,1]
Output: [0,1,2,3]
Explanation: All the buildings have an ocean view.
Example 3:

Input: heights = [1,3,2,4]
Output: [3]
Explanation: Only building 3 has an ocean view.

Constraints:

1 <= heights.length <= 105
1 <= heights[i] <= 109
*/
public class Solution {
    // If we can go from the last element.
    public int[] FindBuildings(int[] heights) {
        var stack = new Stack<int>();

        int index = heights.Count()-1;
        int maxHeight = -1;

        while (index >= 0) {
            if (heights[index] > maxHeight) {
                stack.Push(index);
                maxHeight = heights[index];
            }

            index -= 1;
        }

        return stack.ToArray();
    }

    // In case we cannot go from the last
    public int[] FindBuildingsFromBeginning(int[] heights) {
        var stack = new Stack<int>();

        for (int i = 0; i < heights.Count(); ++i) {
            if (stack.Count == 0 || heights[i] < heights[stack.Peek()]) {
                stack.Push(i);
                continue;
            }

            // int prev = i-1;
            while (stack.Count > 0) {
                var prev = stack.Peek();
                if (heights[i] >= heights[prev]) {
                    stack.Pop();
                } else break;
            }
            stack.Push(i);
        }

        var result = stack.ToList();
        result.Reverse();
        return result.ToArray();
    }
}