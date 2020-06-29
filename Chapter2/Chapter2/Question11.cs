using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Question11
    {
        /* 面试题11：旋转数组的最小数字
         * 输入一个递增排序的数组的一个旋转，输出旋转数组的最小元素
         * 例：[3,4,5,1,2] 输出：1
         * 例：[2,2,2,0,1] 输出：0
         */
        public static int Min(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return -1;
            int lo = 0, hi = numbers.Length - 1;
            int mid = lo;
            while (numbers[lo] >= numbers[hi])
            {
                if (hi - lo == 1)
                {
                    mid = hi;
                    break;
                }
                mid = (lo + hi) / 2;
                if (numbers[lo] == numbers[mid] && numbers[hi] == numbers[mid])
                    return MinInOrder(numbers, lo, hi);
                if (numbers[lo] <= numbers[mid])
                    lo = mid;
                else if (numbers[hi] >= numbers[mid])
                    hi = mid;
            }
            return numbers[mid];
        }
        private static int MinInOrder(int[] numbers, int lo, int hi)
        {
            int result = numbers[lo];
            for (int i = lo + 1; i <= hi; i++)
            {
                if (result > numbers[i])
                    result = numbers[i];
            }
            return result;
        }
    }
}
