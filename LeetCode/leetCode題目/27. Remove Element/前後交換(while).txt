public class Solution {
    public int RemoveElement(int[] nums, int val) {
        if(nums.Count() == 0) return 0;
        int j = 0;
        int i = nums.Count();
        while(j<i)
        {
            if(nums[j] == val)
            {
                nums[j] = nums[i-1];
                i--;
            }else
            {
                j++;
            }
        }
        return i;
    }
}