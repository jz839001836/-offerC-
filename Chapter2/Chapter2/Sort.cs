using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Sort<T> where T : IComparable<T>
    {
        /* 面试题：实现一个O(n)的排序
         * 通过一个长度为100的辅助数组，换来了O(n)的时间效率
         */
        public static void SortAges(int[] ages)
        {
            if (ages == null || ages.Length == 0)
                return;
            const int OldestAges = 99;
            int[] timesOfAges = new int[OldestAges + 1];
            for (int i = 0; i <= OldestAges; i++)
                timesOfAges[i] = 0;
            for(int i = 0; i < ages.Length; i++)
            {
                if (ages[i] < 0 || ages[i] > OldestAges)
                    throw new Exception("ages out of range");
                ++timesOfAges[ages[i]];
            }
            int index = 0;
            for(int i = 0; i <= OldestAges; i++)
            {
                for(int j = 0; j < timesOfAges[i]; j++)
                {
                    ages[index] = i;
                    index++;
                }
            }
        }
        public static int MethodSort(T[] array, T value)
        {
            int low = 0;
            int high = array.Length - 1;
            while (low <= high)
            {
                int middle = (high + low) / 2;
                if (value.CompareTo(array[middle]) == 0)
                    return middle;
                else if (value.CompareTo(array[middle]) > 0)
                    low = middle + 1;
                else
                    high = middle - 1;
            }
            return -1;
        }
        //public static void QuickSort(T[] array)
        //{
        //    RandomArray(array);
        //    QSort(array, 0, array.Length - 1);
        //}
        private static void RandomArray(T[] array)
        {
            Random r = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int index = r.Next(0, array.Length - 1);
                T temp = array[i];
                array[i] = array[index];
                array[index] = temp;
            }
        }
        //private static void QSort(T[] array, int lo, int hi)
        //{
        //    if (lo >= hi)
        //        return;
        //    int j = Partition(array, lo, hi);
        //    QSort(array, lo, j - 1);
        //    QSort(array, j + 1, hi);
        //}
        //private static int Partition(T[] array, int lo, int hi)
        //{
        //    int i = lo, j = hi + 1;
        //    T v = array[lo]; //切分元素
        //    while(true)
        //    {//扫描左右，检查扫描是否结束并交换元素
        //        while (Less(array[++i], v))
        //            if (i == hi)
        //                break;
        //        while (Less(v, array[--j]))
        //            if (j == lo)
        //                break;
        //        if (i >= j)
        //            break;
        //        Exch(array, i, j);
        //    }
        //    Exch(array, lo, j);
        //    return j;
        //}
        //private static bool Less(T v, T w)
        //{ return v.CompareTo(w) < 0; }
        //private static void Exch(T[] array, int i, int j)
        //{
        //    T temp = array[i];
        //    array[i] = array[j];
        //    array[j] = temp;
        //}
        public static void QuickSort(T[] array)
        {
            RandomArray(array);
            QSort(array, 0, array.Length - 1);
        }
        private static void QSort(T[] array, int lo, int hi)
        {
            if (lo >= hi)
                return;
            int j = Partition(array, lo, hi);
            QSort(array, lo, j - 1);
            QSort(array, j + 1, hi);
        }
        private static int Partition(T[] array, int lo, int hi)
        {
            int i = lo, j = hi + 1;
            T v = array[lo];
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
        private static bool Less(T i, T j)
        { return i.CompareTo(j) < 0; }
        private static void Exch(T[] array , int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
