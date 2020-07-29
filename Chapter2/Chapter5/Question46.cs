using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Chapter5
{
    class Question46
    {
        /* 面试题46：把数字翻译成字符串
         * 给定一个数字，按照如下规则把它翻译成字符串：0翻译成‘a',1翻译成“b",...,25翻译成“z”。
         * 一个数字可能有多个翻译。
         * 如12258有五种不同的翻译：“bccfi”，“bwfi”，“bczi”，“mcfi”，“mzi”。
         */
        public int TranslateNum(int num)
        {
            if (num < 0)
                return 0;
            string numberInString = num.ToString();
            return GetTranslationCount(numberInString);
        }
        private int GetTranslationCount(string number)
        {
            int[] dp = new int[number.Length + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= number.Length; i++)
            {
                string tmp = number.Substring(i - 2, 2);
                if (tmp.CompareTo("10") >= 0 && tmp.CompareTo("25") <= 0)
                    dp[i] = dp[i - 1] + dp[i - 2];
                else
                    dp[i] = dp[i - 1];
            }
            return dp[number.Length];
        }
    }
}
