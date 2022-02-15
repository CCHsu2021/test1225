public class Solution {
    public int MaxArea(int[] height) {
        int high=height.Length-1;
        int low =0;
        int area=0;
        while(low < high)
        {
            int temp=0;
            if(height[low]>height[high])
            {
                temp = (high-low)*height[high];
                if(temp>area)
                    area = temp;
                --high;
            }else if(height[low]<height[high])
            {
                temp = (high-low)*height[low];
                if(temp>area)
                    area = temp;
                ++low;
            }else
            {
                temp = (high-low)*height[low];
                if(temp>area)
                    area = temp;
                ++low;
                --high;
            }
        }
        return area;
    }
}