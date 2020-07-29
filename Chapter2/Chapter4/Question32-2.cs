using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class Question32_2
    {
        /* 题目二：分行从上到下打印二叉树
         * 
         * 队列中元素的个数就是某一层节点的个数
         */
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (root == null)
                return res;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            IList<int> tmp;
            int size;
            TreeNode ins;


            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                tmp = new List<int>();
                size = queue.Count;
                for(int i = 0; i < size; i++)
                {
                    ins = queue.Dequeue();
                    tmp.Add(ins.val);
                    if (ins.left != null)
                        queue.Enqueue(ins.left);
                    if (ins.right != null)
                        queue.Enqueue(ins.right);
                }
                res.Add(tmp);
            }
            return res;
        }
    }
}
