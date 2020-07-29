using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class Question27
    {
        /* 面试题27：二叉树的镜像
         * 输入一颗二叉树，输出它的镜像
         */

        //递归版
        public TreeNode MirroTree(TreeNode root)
        {
            if (root == null)
                return null;
            if (root.left == null && root.right == null)
                return root;
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
            if (root.left != null)
                MirroTree(root.left);
            if (root.right != null)
                MirroTree(root.right);
            return root;
        }
        //迭代版
        public TreeNode MirrorTree(TreeNode root)
        {
            if (root == null)
                return null;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode node = null;
            while(stack.Count != 0)
            {
                node = stack.Pop();
                Exchange(ref node.left, ref node.right);
                if(node.left != null)
                    stack.Push(node.left);
                if(node.right != null)
                    stack.Push(node.right);
            }
            return root;
        }
        private void Exchange(ref TreeNode tree1, ref TreeNode tree2)
        {
            TreeNode temp = tree1;
            tree1 = tree2;
            tree2 = temp;
        }
    }
}
