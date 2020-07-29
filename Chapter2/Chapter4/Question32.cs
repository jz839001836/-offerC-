using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class Question32
    {
        /* 面试题32：从上到下打印二叉树
         */
        public int[] LevelOrder(TreeNode root)
        {
            if (root == null)
                return null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<int> array = new List<int>();
            TreeNode ins;

            queue.Enqueue(root);
            while(queue.Count != 0)
            {
                ins = queue.Dequeue();
                if (ins.left != null)
                    queue.Enqueue(root.left);
                if (ins.right != null)
                    queue.Enqueue(root.right);
                array.Add(ins.val);
            }
            return array.ToArray();
        }
    }
}
