using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Question15
    {
        /* 面试题15：二进制中1的个数
         * 把一个整数减去1之后再和原来的整数做位与运算
         * 得到的结果相当于把整数的二进制表示中最右边的1变成0
         * 很多二进制的问题都可以用这种思路解决
         */
        public static int HammingWeight(uint n)
        {
            int count = 0;
            while(n > 0)
            {
                ++count;
                n = (n - 1) & n;
            }
            return count;
        }
        private static void Main(string[] args)
        {
            Console.WriteLine(HammingWeight(3));
        }
    }
}
