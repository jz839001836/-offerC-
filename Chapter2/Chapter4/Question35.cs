using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace Chapter4
{
    class Question35
    {
        /* 面试题35：复杂链表的复制
         * 复制一个复杂链表，在复杂链表中，每个节点除了一个next指针指向下一个节点
         * 还有一个random指针指向链表中任意节点或者Null
         */

        public class Node
        {
            /* 复杂链表节点
             */
            public int val;
            public Node next;
            public Node random;
            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }
        public Node CopyRandomList(Node head)
        {
            if (head == null)
                return null;
            CloneNodes(head);
            ConnectSiblingNodes(head);
            return ReconnectNodes(head);
        }
        private void CloneNodes(Node head)
        {
            Node pNode = head;
            while (pNode != null)
            {
                Node pClone = new Node(pNode.val);
                pClone.next = pNode.next;
                pClone.random = pNode.random;

                pNode.next = pClone;
                pNode = pClone.next;
            }
        }
        private void ConnectSiblingNodes(Node head)
        {
            Node pNode = head;
            while (pNode != null)
            {
                Node pClone = pNode.next;
                if (pNode.random != null)
                    pClone.random = pNode.random.next;
                pNode = pClone.next;
            }
        }
        private Node ReconnectNodes(Node head)
        {
            Node pNode = head;
            Node pCloneHead = null;
            Node pCloneNode = null;
            
            if (pNode != null)
            {
                pCloneHead = pCloneNode = pNode.next;
                pNode.next = pCloneNode.next;
                pNode = pNode.next;
            }
            while (pNode != null)
            {
                pCloneNode.next = pNode.next;
                pCloneNode = pCloneNode.next;
                pNode.next = pCloneNode.next;
                pNode = pNode.next;
            }
            return pCloneHead;
        }
    }
}
