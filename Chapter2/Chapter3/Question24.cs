using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class Question24
    {
        /* 面试题24：反转链表
         * 定义一个函数，输入一个链表的头节点，反转该链表并输出反转后链表的头节点
         */
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public ListNode ReverseList(ListNode head)
        {
            if (head == null)
                return null;
            ListNode previousNode = null;
            ListNode node = head;
            ListNode nextNode = node.next;
            while(nextNode != null)
            {
                node.next = previousNode;
                previousNode = node;
                node = nextNode;
                nextNode = nextNode.next;
            }
            node.next = previousNode;
            return node;
        }
    }
}
