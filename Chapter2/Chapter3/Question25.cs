using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;

namespace Chapter3
{
    class Question25
    {
        /* 面试题25：合并两个排序的链表
         * 输入两个递增排序的链表，合并这两个链表并使新链表中的节点仍然使递增排序的。
         */
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        //迭代版
        public static ListNode MergeTwoLists(ListNode l1,ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            ListNode mergeList = new ListNode(0);
            ListNode head = mergeList;
            while (l1 != null && l2 != null)
            {
                if (l1.val <= l2.val)
                {
                    mergeList.next = l1;
                    l1 = l1.next;
                    mergeList = mergeList.next;
                }
                else
                {
                    mergeList.next = l2;
                    l2 = l2.next;
                    mergeList = mergeList.next;
                }
            }
            mergeList.next = (l1 == null ? l2 : l1);
            return head.next;
        }

        //递归版
        public ListNode MergeTwoLists2(ListNode l1, ListNode l2)
        {
            if (l1 == null)
                return l2;
            if (l2 == null)
                return l1;
            ListNode mergeList = null;
            if (l1.val <= l2.val)
            {
                mergeList = l1;
                mergeList.next = MergeTwoLists(l1.next, l2);
            }
            else
            {
                mergeList = l2;
                mergeList.next = MergeTwoLists(l1, l2.next);
            }
            return mergeList;
        }

        private static void Main(string[] argc)
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            ListNode head = MergeTwoLists(l1, l2);
        }
    }
}
