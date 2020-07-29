using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter5
{
    class Question43
    {
        /* 面试题43：1-n整数中1出现的次数
         * 输入一个整数n,求1-n这n个整数的十进制表示中1出现的次数
         */
        public int CountDigitOne(int n)
        {
            int digit = 1, res = 0;
            int high = n / 10, cur = n % 10, low = 0;
            while (high != 0 || cur != 0)
            {
                if (cur == 0)
                    res += high * digit;
                else if (cur == 1)
                    res += high * digit + low + 1;
                else
                    res += (high + 1) * digit;
                digit *= 10;
                cur = high % 10;
                high /= 10;
                low = n % digit;
            }
            return res;
        }
    }
}
