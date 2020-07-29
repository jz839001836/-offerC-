using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class Question23
    {
        /* 面试题23：链表中环的入口节点
         * 如果一个链表中包含环，如何找出环的入口节点
         */
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        //通过快慢指针确定链表是否有闭环
        public ListNode MeetingNode(ListNode head)
        {
            if (head == null)
                return null;
            ListNode pSlow = head.next;
            if (pSlow == null)
                return null;
            ListNode pFast = pSlow.next;
            while (pSlow != null && pFast !=null)
            {
                if (pSlow == pFast)
                    return pFast;
                pSlow = pSlow.next;
                pFast = pFast.next;
                if (pFast != null)
                    pFast = pFast.next;
            }
            return null;
        }
        public ListNode EntryNodeOfLoop(ListNode head)
        {
            ListNode meetingNode = MeetingNode(head);
            if (meetingNode == null)
                return null;
            int nodesOfLoop = 1;
            ListNode pNode = meetingNode.next;
            //计算闭环中节点的个数
            while (pNode != meetingNode)
            {
                pNode = pNode.next;
                ++nodesOfLoop;
            }
            ListNode first = head;
            for (int i = 0; i <= nodesOfLoop; i++)
                first = first.next;
            ListNode second = head;
            while (second != first)
            {
                second = second.next;
                first = first.next;
            }
            return second;
        }
    }
}
