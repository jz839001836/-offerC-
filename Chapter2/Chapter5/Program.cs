using System;

namespace Chapter5
{
    class Program
    {
        static void Main1(string[] args)
        {
            int[] a = { 7, 4, 2, 8, 3, 5, 1, 9 };
            Sort<int> sort = new Sort<int>();
            sort.HeapSort(a);
            foreach (int i in a)
                Console.Write(i + " ");
        }
    }
}
