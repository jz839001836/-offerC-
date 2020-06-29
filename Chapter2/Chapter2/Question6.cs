using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Chapter2
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    class Question6
    {
        /* 面试题6：从尾到头打印链表
         */
        private static int[] ReversePrint(ListNode head)
        {
            if (head == null)
                return null;
            Stack<int> stacknode = new Stack<int>();
            ListNode insteadhead = head;
            while(insteadhead != null)
            {
                stacknode.Push(insteadhead.val);
                insteadhead = insteadhead.next;
            }
            int[] array = new int[stacknode.Count];
            for(int i = 0; stacknode.Count != 0; i++)
            {
                array[i] = stacknode.Pop();
            }
            return array;
        } 
        private static void Main6(string[] argc)
        {

        }
    }
}
