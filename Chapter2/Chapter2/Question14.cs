using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Question14
    {
        /* 面试题14：剪绳子
         */
        public int CuttingRope(int n)
        {
            if (n < 2)
                return 0;
            if (n == 2)
                return 1;
            if (n == 3)
                return 2;
            int[] products = new int[n + 1];
            products[0] = 0;
            products[1] = 1;
            products[2] = 2;
            products[3] = 3;
            int max = 0;
            for(int i = 4; i <= n; i ++)
            {
                max = 0;
                for(int j = 1; j < i / 2; j++)
                {
                    int product = products[j] * products[i - j];
                    if (max < product)
                        max = product;
                }
                products[i] = max;
            }
            max = products[n];
            return max;
        }
        public static int CuttingRope_Solution2(int n)
        {
            if (n < 2)
                return 0;
            if (n == 2)
                return 1;
            if (n == 3)
                return 2;
            int timeOf3 = n / 3;
            if ((n - timeOf3 * 3) == 1)
                timeOf3 -= 1;
            int timeof2 = (n - timeOf3 * 3) / 2;
            long ret = 1;
            for(int i = 0; i < timeOf3; i++)
            {
                ret *= 3;
                ret = ret > 1000000007 ? ret %= 1000000007 : ret;
            }
            for(int i = 0; i < timeof2; i++)
            {
                ret *= 2;
                ret = ret > 1000000007 ? ret %= 1000000007 : ret;
            }
            return (int)ret;
        }
    }
}
