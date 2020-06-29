using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Chapter2
{
    class Question4
    {
        /* 面试题4：二维数组中的查找
         * 在一个二维数组中，每一行都按照从左到右递增的顺序排序
         * 每一列都按照从上到下递增的顺序排序。
         * 完成一个函数：输入这样的二维数组和一个整数，判断数组中是否存在该整数
         */
        private static bool FindNumber(int[,] matrix, int number)
        {
            bool found = false;
            if (matrix == null)
                return found;
            int columns = matrix.GetLength(0);
            int rows = matrix.Length / columns;
            int row = 0;
            int column = columns - 1;
            while(row < rows && column >= 0)
            {
                //每次都比较查找范围右上角的值
                if (matrix[row, column] == number)
                {
                    found = true;
                    break;
                }
                else if (matrix[row, column] > number)
                    --column;
                else
                    ++row;
            }
            return found;
        }

        //要查找的数在数组中
        private static void Test1()
        {
            int[,] matrix =
            {  
                { 1, 2, 8, 9  },
                { 2, 4, 9, 12 },
                { 4, 7, 10,13 },
                { 6, 8, 11,15 }
            };
            bool found = FindNumber(matrix, 7);
            Console.WriteLine(found);
        }
        //要查找的数不在数组中
        private static void Test2()
        {
            int[,] matrix =
            {
                { 1, 2, 8, 9  },
                { 2, 4, 9, 12 },
                { 4, 7, 10,13 },
                { 6, 8, 11,15 }
            };
            bool found = FindNumber(matrix, 5);
            Console.WriteLine(found);
        }
        private static void Main4(string[] args)
        {
            Test2();
        }
    }
}
