using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class Queue32_3
    {
        /* 题目三：之字形打印二叉树
         */

        //双栈实现
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;
            Stack<TreeNode> stack1 = new Stack<TreeNode>();
            Stack<TreeNode> stack2 = new Stack<TreeNode>();
            IList<int> ins = new List<int>();
            TreeNode tmp;

            stack1.Push(root);
            while(stack1.Count !=0 || stack2.Count != 0)
            {
                if (stack1.Count != 0)
                {
                    while (stack1.Count != 0)
                    {
                        tmp = stack1.Pop();
                        ins.Add(tmp.val);
                        if (tmp.left != null)
                            stack2.Push(tmp.left);
                        if (tmp.right != null)
                            stack2.Push(tmp.right);
                    }
                }
                else
                {
                    while (stack2.Count != 0)
                    {
                        tmp = stack2.Pop();
                        ins.Add(tmp.val);
                        if (tmp.right != null)
                            stack1.Push(tmp.right);
                        if (tmp.left != null)
                            stack1.Push(tmp.left);
                    }
                }
                res.Add(ins);
                ins = new List<int>();
            }
            return res;
        }
        //双向链表实现
        public IList<IList<int>> LevelOrder1(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            LinkedList<int> tmp;
            IList<int> list;
            TreeNode ins;
            int size;

            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                size = queue.Count;
                tmp = new LinkedList<int>();
                list = new List<int>();
                for (int i = 0; i < size; i++)
                {
                    ins = queue.Dequeue();
                    if (res.Count % 2 == 0)
                        tmp.AddLast(ins.val);
                    else
                        tmp.AddFirst(ins.val);
                    if (ins.left != null)
                        queue.Enqueue(ins.left);
                    if (ins.right != null)
                        queue.Enqueue(ins.right);
                }
                foreach (int i in tmp)
                    list.Add(i);
                res.Add(list);
            }
            return res;
        }
    }
}
