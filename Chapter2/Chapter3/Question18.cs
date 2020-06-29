using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class Question18
    {
        /* 面试题18：删除链表的节点
         * 题目一：给定单向链表的头指针和一个节点指针，在O(1)时间内删除链表节点
         */


        /*
         * 题目二：删除链表中重复的节点
         */
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        public void DeleteDuplication(ListNode head)
        {
            if (head == null)
                return;
            ListNode preNode = null;
            ListNode pNode = head;
            while(pNode != null)
            {
                ListNode pNext = pNode.next;
                bool needDelete = false;
                if (pNext != null && pNext.val == pNode.val)
                    needDelete = true;

                if(!needDelete)
                {
                    preNode = pNode;
                    pNode = pNode.next;
                }
                else
                {
                    int value = pNode.val;
                    ListNode pToBeDel = pNode;
                    while(pToBeDel != null && pToBeDel.val == value)
                    {
                        pNext = pToBeDel.next;
                        pToBeDel = pNext;
                    }
                    if (preNode == null)
                        head = pNext;
                    else
                        preNode.next = pNext;
                    pNode = pNext;
                }
            }
        }
    }
}
