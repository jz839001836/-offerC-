using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Chapter5
{
    class Question44
    {
        /* 面试题44：数字序列中某一位的数字
         */
        public int FindNthDigit(int n)
        {
            if (n < 0)
                return -1;
            int digits = 1;
            while (true)
            {
                int numbers = CountOfIntegers(digits);
                if (n < numbers * digits)
                    return DigitAtIndex(n, digits);
                n -= digits * numbers;
                digits++;
            }
        }
        private int CountOfIntegers(int digits)
        {
            if (digits == 1)
                return 10;
            int count = (int)Math.Pow(10, digits - 1);
            return 9 * count;
        }
        private int DigitAtIndex(int index, int digits)
        {
            int indexNumber = index / digits;
            int numbers = BeginNumber(digits) + indexNumber;
            int indexFromRight = digits - index % digits;
            for (int i = 1; i < indexFromRight; i++)
                numbers /= 10;
            return numbers % 10;
        }
        private int BeginNumber(int digits)
        {
            if (digits == 1)
                return 0;
            return (int)Math.Pow(10, digits - 1);
        }
        public int FindDigit(int n)
        {
            if (n < 0)
                return -1;
            int digit = 1;
            int start = 1;
            int count = 9;
            while (n > count)
            {
                n -= count;
                digit++;
                start *= 10;
                count = digit * start * 9;
            }
            long num = start + (n - 1) / digit;
            return num.ToString().ToCharArray()[(n - 1) % digit] - '0';
        }
    }
}
