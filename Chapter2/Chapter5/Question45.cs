using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter5
{
    class Question45
    {
        /* 面试题45：把数组排成最小的数
         */
        public string MinNumber(int[] nums)
        {
            string[] str = new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
                str[i] = nums[i].ToString();
            FastSort(str, 0, str.Length - 1);
            StringBuilder res = new StringBuilder();
            foreach (string s in str)
                res.Append(s);
            return res.ToString();
        }
        private void FastSort(string[] strs, int l, int r)
        {
            if (l >= r)
                return;
            int i = l, j = r;
            string tmp = strs[i];
            while (i < j)
            {
                while ((strs[j] + strs[l]).CompareTo(strs[l] + strs[j]) >= 0 && i < j)
                    j--;
                while ((strs[i] + strs[l]).CompareTo(strs[l] + strs[i]) <= 0 && i < j)
                    i++;
                Exch(strs, i, j);
            }
            strs[i] = strs[l];
            strs[l] = tmp;
            FastSort(strs, l, i - 1);
            FastSort(strs, i + 1, r);
        }
        private void Exch(string[] strs, int i, int j)
        {
            string temp = strs[i];
            strs[i] = strs[j];
            strs[j] = temp;
        }
    }
}
