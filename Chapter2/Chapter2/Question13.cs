using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Question13
    {
        /* 面试题13：机器人的运动范围
         */
        public int MovingCount(int m, int n, int k)
        {
            if (m < 0 || n < 0 || k < 0)
                return 0;
            bool[,] visited = new bool[m,n];
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    visited[i, j] = false;
            int count = MovingCountCore(visited, m, n, k, 0, 0);

            return count;
        }
        private int MovingCountCore(bool[,] visited, int m, int n, int k, int i, int j)
        {
            int count = 0;
            if(Check(visited, m, n, k, i, j))
            {
                visited[i, j] = true;
                count = 1 + MovingCountCore(visited, m, n, k, i + 1, j)
                          + MovingCountCore(visited, m, n, k, i - 1, j)
                          + MovingCountCore(visited, m, n, k, i, j + 1)
                          + MovingCountCore(visited, m, n, k, i, j - 1);
            }
            return count;
        }
        private bool Check(bool[,] visited, int m, int n, int k, int i, int j)
        {
            if (i < m && i >= 0 && j < n && j >= 0 && !visited[i, j] &&
               (GetDigitSum(i) + GetDigitSum(j)) <= k)
                return true;
            return false;
        }
        //获得数位之和
        private int GetDigitSum(int number)
        {
            if (number <= 0)
                return 0;
            int sum = 0;
            while(number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
    }
}
