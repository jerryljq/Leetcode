/**
* Q1570. Dot Product of Two Sparse Vectors
* https://leetcode.com/problems/dot-product-of-two-sparse-vectors/description/
* Given two sparse vectors, compute their dot product.

Implement class SparseVector:

SparseVector(nums) Initializes the object with the vector nums
dotProduct(vec) Compute the dot product between the instance of SparseVector and vec
A sparse vector is a vector that has mostly zero values, you should store the sparse vector efficiently and compute the dot product between two SparseVector.

Follow up: What if only one of the vectors is sparse?

 

Example 1:

Input: nums1 = [1,0,0,2,3], nums2 = [0,3,0,4,0]
Output: 8
Explanation: v1 = SparseVector(nums1) , v2 = SparseVector(nums2)
v1.dotProduct(v2) = 1*0 + 0*3 + 0*0 + 2*4 + 3*0 = 8
Example 2:

Input: nums1 = [0,1,0,0,0], nums2 = [0,0,0,0,2]
Output: 0
Explanation: v1 = SparseVector(nums1) , v2 = SparseVector(nums2)
v1.dotProduct(v2) = 0*0 + 1*0 + 0*0 + 0*0 + 0*2 = 0
Example 3:

Input: nums1 = [0,1,0,0,2,0,0], nums2 = [1,0,0,0,3,0,4]
Output: 6
 

Constraints:

n == nums1.length == nums2.length
1 <= n <= 10^5
0 <= nums1[i], nums2[i] <= 100
*/
public class SparseVector {

    public List<(int, int)> nonZeroElements { get; private set; }
    
    public SparseVector(int[] nums) {
        this.nonZeroElements = new List<(int, int)>();
        int count = nums.Count();
        for (int i = 0; i < count; ++i) {
            if (nums[i] != 0) {
                this.nonZeroElements.Add((i, nums[i]));
            }
        }
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) {
        int result = 0;
        int p = 0;
        int q = 0;

        while (p < this.nonZeroElements.Count && q < vec.nonZeroElements.Count) {
            if (this.nonZeroElements[p].Item1 == vec.nonZeroElements[q].Item1) {
                result += this.nonZeroElements[p].Item2*vec.nonZeroElements[q].Item2;
                p += 1;
                q += 1;
            } else if (this.nonZeroElements[p].Item1 < vec.nonZeroElements[q].Item1) {
                var nextP = this.FindNextIndex(p, vec.nonZeroElements[q].Item1);
                // Console.WriteLine($"Next P is {nextP}");
                if (nextP == -1) {
                    p += 1;
                    q += 1;
                } else {
                    p = nextP;
                }
            } else {
                var nextQ = vec.FindNextIndex(q, this.nonZeroElements[p].Item1);
                // Console.WriteLine($"Next Q is {nextQ}");
                if (nextQ == -1) {
                    p += 1;
                    q += 1;
                } else {
                    q = nextQ;
                }
            }
        }

        return result;
    }

    public int FindNextIndex(int begin, int target) {
        // Console.WriteLine($"begin is {begin}, target is {target}");
        int left = begin;
        int right = this.nonZeroElements.Count-1;
        int median = (left+right)/2;
        while (left <= right) {
            if (this.nonZeroElements[median].Item1 == target) {
                return median;
            } else if (this.nonZeroElements[median].Item1 < target) {
                left = median+1;
                median = (left+right)/2;
                // Console.WriteLine($"Updated median is {median}");
            } else {
                right = median-1;
                median = (left+right)/2;
                // Console.WriteLine($"Updated median is {median}");
            }
        }

        return -1;
    }
}

// Your SparseVector object will be instantiated and called as such:
// SparseVector v1 = new SparseVector(nums1);
// SparseVector v2 = new SparseVector(nums2);
// int ans = v1.DotProduct(v2);