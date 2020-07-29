using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class Question22
    {
        /* 面试题22：链表中倒数第K个节点
         * 输入一个链表，输出该链表中倒数第K个节点
         * 思路：利用双指针
         */
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public ListNode GetKthFromEnd(ListNode head, int k)
        {
            if (head == null || k == 0)
                return null;
            ListNode first = head;
            for (int i = 0; i < k - 1; i++)
            {
                if (first == null)
                    return null;
                first = first.next;
            }
            ListNode second = head;
            while (first.next != null)
            {
                first = first.next;
                second = second.next;
            }
            return second;
        }
    }
}
