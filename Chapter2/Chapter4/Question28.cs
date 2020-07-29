using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class Question28
    {
        /* 对称的二叉树
         * 实现一个函数，判断一个二叉树是否对称
         */
        public bool IsSymmetric(TreeNode root)
        {
            return IsSymmetric(root, root);
        }
        private bool IsSymmetric(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return true;
            if (root1 == null || root2 == null)
                return false;
            if (root1.val != root2.val)
                return false;
            return IsSymmetric(root1.left, root2.right) && IsSymmetric(root1.right, root2.left);
        }
    }
}
