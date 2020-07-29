using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace Chapter5
{
    class Question40
    {
        /* 面试题40：最小的k个数
         * 输入n个整数，找出其中最小的k个数
         * 例如：输入4、5、1、6、2、7、3、8这8个数字，
         * 最小的4个数字是1，2，3，4
         */

        //基于切分算法，复杂度O(n)，但会改变数组的结构，且不能用于海量的数组
        public int[] GetLeastNumbers(int[] arr, int k)
        {
            if (arr == null || arr.Length == 0 || k <= 0 || k > arr.Length)
                return null;
            int start = 0;
            int end = arr.Length - 1;
            int index = Partition(arr, start, end);
            while (index != k - 1)
            {
                if (index < k - 1)
                {
                    start = index + 1;
                    Partition(arr, start, end);
                }
                else
                {
                    end = index - 1;
                    Partition(arr, start, end);
                }
            }
            int[] ret = new int[k];
            for (int i = 0; i < k; i++)
                ret[i] = arr[i];
            return ret;
        }
        private int Partition(int[] arr, int lo, int hi)
        {
            if (lo == hi)
                return lo;
            int i = lo, j = hi + 1;
            int v = arr[lo];
            while (true)
            {
                while (arr[++i] < v)
                    if (i == hi)
                        break;
                while (arr[--j] > v)
                    if (j == lo)
                        break;
                if (i >= j)
                    break;
                Exch(arr, i, j);
            }
            Exch(arr, lo, j);
            return j;
        }
        private void Exch(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        //利用额外的容器，时间复杂度O(nlogk)，能用于海量数据
    }
}
