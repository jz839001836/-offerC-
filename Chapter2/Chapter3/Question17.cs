using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class Question17
    {
        /* 面试题17：打印从1到最大的n位数
         * 考虑大数问题
         */
        public void PrintNumbers(int n)
        {
            if (n <= 0)
                return;
            char[] number = new char[n];
            for (int i = 0; i < n; i++)
                number[i] = '0';
            while (!Increment(number))
                PrintNumber(number);
            return;
        }
        private bool Increment(char[] number)
        {
            bool isOverflow = false;
            int nTakeOver = 0;
            int nLength = number.Length;
            for(int i = nLength - 1; i >= 0; i--)
            {
                int nSum = number[i] - '0' + nTakeOver;
                if (i == nLength - 1)
                    nSum++;
                if(nSum >= 10)
                {
                    if (i == 0)
                        isOverflow = true;
                    else
                    {
                        nSum -= 10;
                        nTakeOver = 1;
                        number[i] = (char)('0' + nSum);
                    }
                }
                else
                {
                    number[i] = (char)('0' + nSum);
                    break;
                }
            }
            return isOverflow;
        }
        private void PrintNumber(char[] number)
        {
            bool isBeginning0 = true;
            int nLength = number.Length;
            for(int i = 0; i < nLength; i++)
            {
                if (isBeginning0 && number[i] != '0') //用于跳过前面的0
                    isBeginning0 = false;
                if (!isBeginning0)
                    Console.Write("{0}", number[i]);
            }
            Console.WriteLine();
        }

        public void Print1ToMaxOfNDigits(int n)
        {
            if (n <= 0)
                return;
            char[] number = new char[n];

            for(int i = 0; i < 10; i++)
            {
                number[0] = (char)(i + '0'); //最高位
                Print1ToMaxOfNDigitsRecursively(number, n, 0);
            }
            return;
        }
        private void Print1ToMaxOfNDigitsRecursively(char[] number, int length, int index)
        {
            if (index == length - 1)
            {
                PrintNumber(number);
                return;
            }
            for(int i = 0; i < 10; i++)
            {
                number[index + 1] = (char)(i + '0');
                Print1ToMaxOfNDigitsRecursively(number, length, index + 1);
            }
        }







        StringBuilder res;
        int nine = 0, count = 0, start, n;
        char[] num, loop = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public String PrintNumbers2(int n)
        {
            this.n = n;
            res = new StringBuilder();
            num = new char[n];
            start = n - 1;
            Dfs(0);
            res.Remove(res.Length - 1, 1);
            return res.ToString(0,res.Length);
        }
        private void Dfs(int x)
        {
            if(x == n)
            {
                String s = string.Join("", num).Substring(start);
                if (!s.Equals("0"))
                    res.Append(s + ",");
                if (n - start == nine) //用于判断是否进位
                    start--;
                return;
            }
            foreach(char i in loop)
            {
                if (i == '9')
                    nine++;
                num[x] = i;
                Dfs(x + 1);
            }
            nine--;
        }
    }
}
