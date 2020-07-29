using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Chapter5
{
    /// <summary>
    /// 最小值优先的优先队列
    /// </summary>
    class MinPQ<Item>where Item:IComparable<Item>
    {
        private Item[] pq;
        private int N = 0;
        public MinPQ(int maxN)
        {
            pq = new Item[maxN + 1];
        }
        public int Size()
        {
            return N;
        }
        public bool IsEmpty()
        {
            return N == 0;
        }
        public void Insert(Item v)
        {
            if (N == pq.Length - 1)
                Resize(2 * pq.Length);
            pq[++N] = v;
            Swim(N);
        }
        public Item DelMin()
        {
            Item min = pq[1];
            Exch(1, N--);
            pq[N + 1] = default;
            Sink(1);
            if (N > 0 && N < pq.Length / 4)
                Resize(pq.Length / 2);
            return min;
        }
        public Item MinPeek()
        {
            return pq[1];
        }
        private void Swim(int k)
        {
            while (k > 1 && Less(k, k / 2))
            {
                Exch(k, k / 2);
                k = k / 2;
            }
        }
        private void Sink(int k)
        {
            while (2 * k <= N)
            {
                int j = 2 * k;
                if (j < N && Less(j + 1, j))
                    j++;
                if (!Less(j, k))
                    break;
                Exch(j, k);
                k = j;
            }
        }
        private bool Less(int i, int j)
        { return pq[i].CompareTo(pq[j]) < 0; }
        private void Exch(int i, int j)
        {
            Item item = pq[i];
            pq[i] = pq[j];
            pq[j] = item;
        }
        private void Resize(int max)
        {
            Item[] temp = new Item[max];
            for (int i = 1; i <= N; i++)
            {
                temp[i] = pq[i];
            }
            pq = temp;
        }
    }
}
