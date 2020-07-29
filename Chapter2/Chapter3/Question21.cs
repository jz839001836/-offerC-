using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class Question21
    {
        /* 调整数组顺序使奇数位于偶数前面
         */
        public int[] Exchange(int[] nums)
        {
            int i = 0;
            int j = nums.Length - 1;
            while (true)
            {
                while ((i < nums.Length - 1) && isOddNumber(nums[i]))
                    i++;
                while ((j > 0) && !isOddNumber(nums[j]))
                    j--;
                if (i >= j)
                    break;
                ExchangeNum(nums, i, j);
            }
            return nums;
        }
        private bool isOddNumber(int num)
        {
            return ((num & 0x1) != 0);
        }
        private void ExchangeNum(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
