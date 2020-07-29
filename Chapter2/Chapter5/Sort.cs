using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter5
{
    /// <summary>
    /// 排序算法
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    class Sort<Item>where Item:IComparable<Item>
    {
        public void HeapSort(Item[] a)
        {
            int N = a.Length;
            for (int k = N / 2; k >= 1; k--)
                Sink(a, k, N);
            while (N >= 1)
            {
                Exch(a, 1, N--);
                Sink(a, 1, N);
            }
        }
        private void Sink(Item[] a, int k, int N)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Less(a, j, j + 1))
                    j++;
                if (!Less(a, k, j))
                    break;
                Exch(a, k, j);
                k = j;
            }
        }
        private bool Less(Item[] a, int i, int j)
        { return a[i - 1].CompareTo(a[j - 1]) < 0; }
        private void Exch(Item[] a, int i, int j)
        {
            Item temp = a[i - 1];
            a[i - 1] = a[j - 1];
            a[j - 1] = temp;
        }
    }
}
