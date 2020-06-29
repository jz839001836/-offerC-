using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class Question19
    {
        /* 面试题19：正则表达式匹配（没看懂）
         */

        //s:主串  p:正则表达式
        public bool Match(string s, string p)
        {
            int sLength = s.Length;
            int pLength = p.Length;
            bool[,] f = new bool[sLength + 1, pLength + 1];
            for (int i = 0; i <= sLength; i++)
            {
                for (int j = 0; j <= pLength; j++)
                {
                    /*分为空正则和非空正则
                     * 空正则-若串为空，则匹配；若串为非空，则必不匹配
                     */
                    if (j == 0)
                        f[i, j] = (i == 0);
                    else
                    {
                        //非空正则分为两种情况 * 和非*
                        if(p[j - 1] != '*')
                        {
                            if (i > 0 && (s[i - 1] == p[j - 1] || p[j - 1] == '.'))
                                f[i, j] = f[i - 1, j - 1];
                        }
                        else
                        {
                            if (j >= 2)
                                f[i, j] |= f[i, j - 2];
                            if (i >= 1 && j >= 2 && (s[i - 1] == p[j - 2] || p[j - 2] == '.'))
                                f[i, j] |= f[i - 1, j];
                        }
                    }
                }
            }
            return f[sLength, pLength];
        }
    }
}
