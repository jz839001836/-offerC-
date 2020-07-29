using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Chapter4
{
    class Question34
    {
        /* 面试题34：二叉树中和为某一值的路径
         * 输入一棵二叉树和一个整数，打印出二叉树中节点值的和为输入整数的所有路径。
         */
        IList<IList<int>> res = new List<IList<int>>();
        IList<int> path = new List<int>();
        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            Recur(root, sum);
            return res;
        }
        private void Recur(TreeNode root, int tar)
        {
            if (root == null)
                return;
            path.Add(root.val);
            tar -= root.val;
            if (tar == 0 && root.left == null && root.right == null)
                res.Add(new List<int>(path));
            Recur(root.left, tar);
            Recur(root.right, tar);
            path.RemoveAt(path.Count - 1);
        }
        private List<int> Conver(LinkedList<int> path)
        {
            List<int> list = new List<int>();
            foreach(int i in path)
                list.Add(i);
            return list;
        }
    }
}
