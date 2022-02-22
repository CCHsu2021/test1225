using System;

namespace _136._Single_Number
{

    //    Given a non-empty array of integers nums, every element appears twice except for one.Find that single one.
    //    You must implement a solution with a linear runtime complexity and use only constant extra space.

    //    Input: nums = [2,2,1]
    //    Output: 1

    //    Input: nums = [4,1,2,1,2]
    //    Output: 4

    //    Input: nums = [1]
    //    Output: 1

    //https://leetcode.com/problems/single-number/
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 4, 1, 2, 1, 2 };
            Console.WriteLine(SingleNumber1(a));





            int SingleNumber1(int[] nums)
            {
                int a = 0;
                foreach(var i in nums)
                    a = a ^ nums[i]; // XOR 
                return a;
            }










            int SingleNumber2(int[] nums)
            {
                Array.Sort(nums);
                int output = nums[0];
                if (nums.Length == 1)
                {
                    return output;
                }
                for (int i = 1; i < nums.Length - 1; i++)
                {
                    if (i == 1 && output != nums[i])
                    {
                        return output;
                    }
                    if (output == nums[i])
                    {
                        output = nums[i + 1];
                        i++;
                    }
                    else if (output != nums[i])
                    {
                        return output;
                    }
                }
                return output;
            }



              








            int SingleNumber3(int[] nums)
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    int firstin = Array.IndexOf(nums,  nums[i]);
                    int lastin = Array.LastIndexOf(nums,  nums[i]);
                    if(firstin == lastin)
                    {
                        return nums[i];
                    }
                }

                return 0;
            }















        }
    }
}
