using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Chapter3
{
    class Question16
    {
        /* 面试题16：数值的整数次方
         * 实现函数double Power(double base, int exponent)
         * 求base的exponent次方。不得使用库函数， 不需要考虑大数问题
         */

        static bool G_InvalidInput = false;
        public static double MyPow(double x, int n)
        {
            if (Math.Abs(x - 0.0) < 0.0001 && n < 0)
            {
                G_InvalidInput = true;
                return 0;
            }
            long b = n;
            double ret = 1d;
            if (b < 0)
            {
                x = 1 / x;
                b = -b;
            }
            while (b > 0)
            {
                if ((b & 1) == 1)
                    ret *= x;
                x *= x;
                b >>= 1;
            }
            return ret;
        }
        private static void Main16(string[] args)
        {
            double x = MyPow(-1, -2147483648);
            Console.WriteLine(x);
        }
    }
}
