using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class Question38
    {
        /* 字符串的排列
         * 输入一个字符串，打印出该字符串中字符的所有排列
         * 例如：  输入：abc
         *         输出：abc, acb, bac, cab, cba
         */
        char[] ch;
        List<string> res = new List<string>();
        public string[] Permutation(string s)
        {
            if (s == null)
                return null;
            ch = s.ToCharArray();
            Dfs(0);
            return res.ToArray();
        }
        private void Dfs(int x)
        {
            if (x == ch.Length - 1)
            {
                res.Add(new string(ch));
                return;
            }
            HashSet<char> set = new HashSet<char>();
            for (int i = x; i < ch.Length; i++)
            {
                if (set.Contains(ch[i]))
                    continue;
                set.Add(ch[i]);
                Swap(i, x);
                Dfs(x + 1);
                Swap(i, x);
            }
        }
        private void Swap(int a, int b)
        {
            char temp = ch[a];
            ch[a] = ch[b];
            ch[b] = temp;
        }
    }
}
