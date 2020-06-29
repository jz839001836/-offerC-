using System;

namespace Chapter2
{
    class Question3
    {
        /* 面试题三：题目1
         * 在一个长度为n的数组里的所有数字都在0 - n-1的范围内
         * 数组中某些数字是重复的，但不知道有几个数字重复
         * 也不知道重复了几次，找出数组中任意一个重复的数字
         * 例：{2，3，1，0，2，5，3}
         * 输出：2或3
         */
        public static int FindRepeatNumber1(int[] nums)
        {
            if (nums == null)
                return -1;
            int length = nums.Length;
            for (int i = 0; i < length; i++)
            {
                if (nums[i] < 0 || nums[i] > length - 1)
                    return -1;
            }
            for (int i = 0; i < length; i++)
            {
                int m = nums[i];
                int temp;
                if (i != m)
                {
                    if (m == nums[m])
                        return m;
                    temp = nums[i];
                    nums[i] = nums[m];
                    nums[m] = temp;
                    i--;
                }
            }
            return -1;
        }
        /* 面试题三：题目2
         * 在一个长度为n+1的数组里的所有数字都在1-n的范围内
         * 所以数组中至少有一个数字是重复的
         * 例：{2，3，5，4，3，2，6，7}
         * 输出：2或3
         */
        public static int FindRepeatNumber2(int[] numbers)
        {
            if (numbers == null)
                return -1;
            int length = numbers.Length;
            for (int i = 0; i < length; i++)
            {
                if (numbers[i] <= 0 || numbers[i] > length - 1)
                    return -1;
            }
            int start = 1;
            int end = length - 1;
            while(end >= start)
            {
                int middle = ((end - start) >> 1) + start;
                int count = CountRange(numbers, length, start, middle);
                if(end == start)
                {
                    if (count > 1)
                        return start;
                    else
                        break;
                }
                if (count > (middle - start + 1))
                    end = middle;
                else
                    start = middle + 1;
            }
            return -1;
        }
        //统计在start和end之间值的数量
        private static int CountRange(int[] numbers, int length, int start, int end)
        {
            if (numbers == null)
                return 0;
            int count = 0;
            for (int i = 0; i < length; i++)
                if (numbers[i] >= start && numbers[i] <= end)
                    count++;
            return count;
        }
        private static void Test1()
        {
            int[] nums = { 6, 4, 1, 0, 2, 5, 1 };
            int dup = FindRepeatNumber1(nums);
            Console.WriteLine(dup);
        }
        private static void Test2()
        {
            int[] numbers = { 2, 3, 5, 4, 3, 2, 6, 7 };
            int num = FindRepeatNumber2(numbers);
            Console.WriteLine(num);
        }
        private static void Main3(string[] args)
        {
            Test2();
        }
    }
}
