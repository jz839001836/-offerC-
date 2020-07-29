using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter5
{
    class Question41
    {
        MinPQ<int> minHeap;
        MaxPQ<int> maxHeap;
        public Question41()
        {
            minHeap = new MinPQ<int>(4);
            maxHeap = new MaxPQ<int>(4);
        }

        public void AddNum(int num)
        {
            if (minHeap.Size() == maxHeap.Size())
            {
                minHeap.Insert(num);
                maxHeap.Insert(minHeap.DelMin());
            }
            else
            {
                maxHeap.Insert(num);
                minHeap.Insert(maxHeap.DelMax());
            }
        }

        public double FindMedian()
        {
            double ret;
            if (minHeap.Size() == maxHeap.Size())
            {
                double i = minHeap.MinPeek();
                double j = maxHeap.MaxPeek();
                ret = (i + j) / 2;
            }
            else
                ret = maxHeap.MaxPeek();
            return ret;
        }
    }
}
