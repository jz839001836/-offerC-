using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Question10
    {
        /* 面试题10：斐波那契数列
         * 写一个函数，输入n,求斐波那契数列的第n项。
         * 斐波那契数列定义如下：
         *         0                n = 0 
         * f(n) =  1                n = 1
         *         f(n-1) + f(n-2)  n > 1
         */
        public static int Fibonacci(int n)
        {
            if (n < 0)
                return -1;
            int[] result = { 0, 1 };
            if (n < 2)
                return result[n];
            int fibN = 0;
            int fibNOne = 1;
            int fibNTwo = 0;
            for(int i = 2; i <= n; i++)
            {
                fibN = fibNOne + fibNTwo;
                fibNTwo = fibNOne;
                fibNOne = fibN;
            }
            return fibN % 1000000007;
        }
        private static void Main10(string[] argc)
        {
            int i = Fibonacci(5);
            Console.WriteLine(i);
        }
    }
}
