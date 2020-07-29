using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter5
{
    class Question42
    {
        /* 面试题42：连续子数组的最大和
         */
        public int MaxSubArray(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return 0;
            int max = int.MinValue;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                if (sum < nums[i])
                    sum = nums[i];
                if (sum > max)
                    max = sum;
            }
            return max;
        }
    }
}
