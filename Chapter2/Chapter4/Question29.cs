using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class Question29
    {
        /* 面试题29：顺时针打印矩阵
         * 输入一个矩阵，按照从外向里以顺时针的顺序依次打印出每一个数字
         */
        public int[] SpiralOrder(int[][] matrix)
        {
            if (matrix == null || matrix.Length == 0)
                return null;
            int l = 0, t = 0, b = matrix.Length - 1, r = matrix[0].Length - 1;
            List<int> res = new List<int>((r + 1) * (b + 1));
            while(true)
            {
                for (int i = l; i <= r; i++)
                    res.Add(matrix[t][i]);
                if (++t > b)
                    break;
                for (int i = t; i <= b; i++)
                    res.Add(matrix[i][r]);
                if (--r < l)
                    break;
                for (int i = r; i >= l; i--)
                    res.Add(matrix[b][i]);
                if (--b < t)
                    break;
                for (int i = b; i >= t; i--)
                    res.Add(matrix[i][l]);
                if (++l > r)
                    break;
            }
            return res.ToArray();
        }
    }
}
