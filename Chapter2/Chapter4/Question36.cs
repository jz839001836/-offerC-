using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class Question36
    {
        /* 面试题36：二叉搜索树与双向链表
         * 输入一棵二叉搜索树，将该二叉搜索树转换成一个排序的双向链表。
         * 要求不能创建任何新的节点，只能调整书中节点指针的指向。
         */
        public class Node
        {
            public int val;
            public Node left;
            public Node right;

            public Node(int _val)
            {
                val = _val;
                left = null;
                right = null;
            }
            public Node(int _val, Node _left, Node _right)
            {
                val = _val;
                left = _left;
                right = _right;
            }
        }

        Node head, pre;
        public Node TreeToDoublyList(Node root)
        {
            if (root == null)
                return null;
            Dfs(root);
            pre.right = head;
            head.left = pre;
            return head;
        }
        private void Dfs(Node cur)
        {
            if (cur == null)
                return;
            Dfs(cur.left);
            if (pre == null)
                head = cur;
            else
                pre.right = cur;
            cur.left = pre;
            pre = cur;
            Dfs(cur.right);
        }
    }
}
