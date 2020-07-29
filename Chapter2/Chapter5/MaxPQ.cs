using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter5
{
    /// <summary>
    /// 最大值优先的优先队列
    /// </summary>
    /// <typeparam name="Item"></typeparam>
    class MaxPQ<Item>where Item:IComparable<Item>
    {
        private Item[] pq;
        private int N = 0;

        public MaxPQ(int maxN)
        {
            pq = new Item[maxN + 1];
        }
        public int Size()
        { return N; }
        public bool IsEmpty()
        { return N == 0; }
        public void Insert(Item v)
        {
            if (N == pq.Length - 1)
                Resize(2 * pq.Length);
            pq[++N] = v;
            Swim(N);
        }
        public Item DelMax()
        {
            Item max = pq[1];
            Exch(1, N--);
            pq[N + 1] = default;
            Sink(1);
            if (N > 0 && N == pq.Length / 4)
                Resize(pq.Length / 2);
            return max;
        }
        public Item MaxPeek()
        {
            return pq[1];
        }
        private bool Less(int i, int j)
        { return pq[i].CompareTo(pq[j]) < 0; }
        private void Exch(int i, int j)
        {
            Item t = pq[i];
            pq[i] = pq[j];
            pq[j] = t;
        }
        //上浮
        private void Swim(int k)
        {
            while (k > 1 && Less(k/2, k))
            {
                Exch(k / 2, k);
                k = k / 2;
            }
        }
        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Less(j, j + 1))
                    j++;
                if (!Less(k, j))
                    break;
                Exch(k, j);
                k = j;
            }
        }
        //调整数组的大小
        private void Resize(int max)
        {
            Item[] temp = new Item[max];
            for (int i = 1; i <= N; i++)
                temp[i] = pq[i];
            pq = temp;
        }
    }
}
