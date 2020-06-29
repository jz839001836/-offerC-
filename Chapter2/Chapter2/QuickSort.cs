using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace Chapter2
{
    class QuickSort<Item>where Item:IComparable<Item>
    {
        public static void Sort(Item[] array)
        {
            if (array == null || array.Length == 0)
                return;
            RandomArray(array);
            Sort(array, 0, array.Length - 1);
        }
        private static void Sort(Item[] array, int lo, int hi)
        {
            if (lo >= hi)
                return;
            int j = Partition(array, lo, hi);
            Sort(array, lo, j - 1);
            Sort(array, j + 1, hi);
        }
        private static int Partition(Item[] array, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            Item v = array[lo];
            while(true)
            {
                while (Less(array[++i], v))
                    if (i == hi)
                        break;
                while (Less(v, array[--j]))
                    if (j == lo)
                        break;
                if (i >= j)
                    break;
                Exch(array, i, j);
            }
            Exch(array, lo, j);
            return j;
        }
        private static bool Less(Item a, Item b)
        { return a.CompareTo(b) < 0; }
        private static void Exch(Item[] array, int i, int j)
        {
            Item temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        private static void RandomArray(Item[] array)
        {
            int j = array.Length;
            Random random = new Random();
            for(int i = 0; i < j; i++)
            {
                int temp = random.Next(0, j - 1);
                Item v = array[i];
                array[i] = array[temp];
                array[temp] = v;
            }
        }
    }
}
