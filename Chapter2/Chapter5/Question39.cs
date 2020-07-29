using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Chapter5
{
    class Question39
    {
        /* 面试题39：数组中出现次数超过一般的数字
         * 例如：输入一个长度为9的数组{1，2，3，2，2，2，5，4，2}
         * 因为2在数组中出现了5次，超过数组长度的一半，因此输出2
         */

        //通过数组切分完成功能
        bool inputInvalid = false;
        public int MajorityElement(int[] nums)
        {
            if (CheckInvalidArray(nums))
                return 0;
            int length = nums.Length;
            int middle = length >> 1;
            int start = 0;
            int end = length - 1;
            int index = Partition(nums, start, end);
            while (index != middle)
            {
                if (index  > middle)
                {
                    end = index - 1;
                    index = Partition(nums, start, end);
                }
                else
                {
                    start = index + 1;
                    index = Partition(nums, start, end);
                }
            }
            int result = nums[middle];
            if (!CheckMoreThanHalf(nums, result))
                result = 0;
            return result;
        }
        private int Partition(int[] nums, int start, int end)
        {
            int v = nums[start];
            int i = start, j = end + 1;
            while (true)
            {
                while (nums[++i] < v)
                    if (i == end)
                        break;
                while (nums[--j] > v)
                    if (i == start)
                        break;
                if (i >= j)
                    break;
                Exch(nums, i, j);
            }
            Exch(nums, start, j);
            return j;
        }
        private void Exch(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
        private bool CheckInvalidArray(int[] nums)
        {
            inputInvalid = false;
            if (nums == null || nums.Length == 0)
                inputInvalid = true;
            return inputInvalid;
        }
        private bool CheckMoreThanHalf(int[] nums, int number)
        {
            int times = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == number)
                    times++;
            }
            bool isMoreThanHalf = true;
            if (times * 2 <= nums.Length)
            {
                inputInvalid = true;
                isMoreThanHalf = false;
            }
            return isMoreThanHalf;
        }

        //根据数组的特点
        public int MajorityElement2(int[] nums)
        {
            if (CheckInvalidArray(nums))
                return 0;
            int x = 0, vote = 0;
            foreach(int num in nums)
            {
                if (vote == 0)
                    x = num;
                vote += num == x ? 1 : -1;
            }
            return x;
        }
    }
}
