public class Solution {
    public void Merge(int[] nums1, int m, int[] nums2, int n) {
        if (nums2.Length == 0) { return; }
        int j = 0;
        for (int i = m + n - 1; i >= m; i--) {
            nums1[i] = nums2[j];
            j++;
        }
        
        Array.Sort(nums1);
    }
}