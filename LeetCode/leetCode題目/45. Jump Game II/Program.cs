using System;
using System.Collections.Generic;

namespace Jump_Game_II
{
//    Given an array of non-negative integers nums, you are initially positioned at the first index of the array.

//    Each element in the array represents your maximum jump length at that position.

//    Your goal is to reach the last index in the minimum number of jumps.

//    You can assume that you can always reach the last index.

//   Input: nums = [2,3,1,1,4]
//   Output: 2
//   Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.

    //https://leetcode.com/problems/jump-game-ii/

    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 1, 1, 1, 1 };
            Console.WriteLine(Jump1(a));


                int Jump1(int[] nums)
                {
                    if (nums.Length <= 1)
                    {
                        return 0;
                    }
                    int a = 0;
                    int count = 0;
                    while (a + nums[a] <= nums.Length)
                    {
                        if (a + nums[a] >= nums.Length - 1)
                            return count++;
                        int temp = a + nums[a];
                        for (int i = a + nums[a]; i >= a + 1; i--)
                        {
                            if (i + nums[i] > temp + nums[temp])
                            {
                                temp = i;
                            }
                        }
                        a = temp;
                        count++;
                    }
                    return count++;
                }









            //------------------------------------思穎  放棄

            int Jump2(int[] nums)
            {
                // 1.用最少的數累加到目標值（陣列長度）
                // 2.要選取的數在陣列中的位置位於當前值的可取範圍內
                // 3.選擇權重 相對於當前值的索引位置及被選數的總和更大為先

                int total = nums.Length;
                int count = 1;
                int curStep = 0;
                int maxValue = 0;
                if (total == 1)
                {
                    return 0;
                }
                for(int i = 0; i < nums.Length - 1; )
                {
                    maxValue = SearchMaxStep(nums,i);
					if (total - maxValue - i - 1 <= 0)
                    {
                        return count;
					}
                    count++;
                    if(maxValue < 1)
                    {
                        i++;
					}
					else
                    {
                        i += maxValue;
                    }
                }
                return count;

                int SearchMaxStep(int[] nums,int curStep)
                {
                    List<int> tempList = new List<int>();
                    Dictionary<int,  int> maxValue = new Dictionary<int, int>();
                    if(nums[curStep] < 1)
                    {
                        return 0;
                    }

                    for (int k = 0; k < nums[curStep]; k++)
                    {
                        //tempList.Add(nums[curStep + k] + k);
                        if(maxValue.ContainsKey(nums[curStep + k] + k))
                        {
                            continue;
                        }
                        maxValue.Add(nums[curStep + k] + k,  nums[curStep + k]);
                    }
                    tempList.Sort();
                    return tempList[0];
                }











            }








            //------------------茗棟

            int Jump3(int[] nums)
            {
                int index = 0;
                int goal = nums.Length;
                int step = 0;
                if (goal == 1)
                {
                    return 0;
                }
                if (goal == 2)
                {
                    return 1;
                }
                while (index < goal)
                {
                    if (nums[index] >= goal - (index + 1) && index != goal - 1)
                    {
                        step++;
                        return step;
                    }
                    if (nums[index] >= goal - (index + 1) && index == goal - 1)
                    {
                        return step;
                    }
                    int[] subarr = new int[nums[index]];
                    for (int i = 0; i < subarr.Length; i++)
                    {
                        subarr[i] = nums[index + 1 + i];
                    }
                    index = LongDistance(nums, index, subarr);
                    step++;
                }
                return 1234;
            }

            int LongDistance(int[] nums, int index, int[] subarr)
            {
                int maxdis = nums[index];
                int maxindex = index - 1;
                for (int i = 0; i < subarr.Length; i++)
                {
                    int tempdis = subarr[i] + (i + 1);
                    if (tempdis > maxdis)
                    {
                        maxdis = tempdis;
                        maxindex = i;
                    }
                }
                return index + maxindex + 1;
            }



        }
    }
}
