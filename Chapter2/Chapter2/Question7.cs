using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Chapter2
{
    class Question7
    {
         public class TreeNode
         {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
         }
        /* 面试题7：重建二叉树
         * 输入某二叉树的前序遍历和中序遍历的结果，请重建该二叉树
         * 假设输入的前序遍历和中序遍历的结果中都不包含重复的数字。
         * 
         * 前序遍历：先访问根节点，再访问左子节点，最后访问右子节点
         * 中序遍历：先访问左子节点，再访问根节点，最后访问右子节点
         * 后序遍历：先访问左子节点，再访问右子节点，最后访问根节点
         * 
         * 例：前序遍历序列{1，2，4，7，3，5，6，8}
         *     中序遍历序列{4，7，2，1，5，3，8，6}
         */

        //书本解法--preorder：前序遍历  inorder:中序遍历
        public static TreeNode BuildTree1(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null || preorder.Length == 0 || inorder.Length == 0)
                return null;
            return BuildTreeCore1(preorder, inorder, 0, preorder.Length - 1, 0, inorder.Length - 1);
        }
        private static TreeNode BuildTreeCore1(  int[] preorder, int[] inorder, 
                                                int   startPreorder, int   endPreorder,
                                                int   startInorder,  int   endInorder )
        {
            int rootValue = preorder[startPreorder];
            TreeNode root = new TreeNode(rootValue);
            root.left = root.right = null;
            if(startPreorder == endPreorder)
            {
                if (startInorder == endInorder &&
                    preorder[startPreorder] == inorder[startInorder])
                    return root;
                else
                    throw new Exception("Invalid input");
            }
            //在中序遍历中找到根节点的值
            int rootInorder = startInorder;
            while (rootInorder <= endInorder && inorder[rootInorder] != rootValue)
                ++rootInorder;

            if (rootInorder == endInorder && inorder[rootInorder] != rootValue)
                throw new Exception("Invalid input");

            int leftLength = rootInorder - startInorder;
            int leftPreorderEnd = startPreorder + leftLength;

            if(leftLength > 0)
            {
                //构建左子树
                root.left = BuildTreeCore1(preorder, inorder,
                                          startPreorder + 1, leftPreorderEnd,
                                          startInorder, rootInorder - 1);
            }
            if(leftLength < endPreorder - startPreorder)
            {
                //构建右子树
                root.right = BuildTreeCore1(preorder, inorder,
                                           leftPreorderEnd + 1, endPreorder,
                                           rootInorder + 1, endInorder);
            }
            return root;
        }


        //另一种解法
        private static Hashtable dic = new Hashtable();
        //po:二叉树前序遍历的序列
        private static int[] po;
        public static TreeNode BuildTree2(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0 || inorder.Length == 0)
                return null;
            po = preorder;
            //将中序遍历的值加入哈希表中，提高搜索效率
            for (int i = 0; i < inorder.Length; i++)
                dic.Add(inorder[i], i);

            return Recur(0, 0, inorder.Length - 1);
        }
        private static TreeNode Recur(int pre_root, int in_left, int in_right)
        {
            if (in_left > in_right)
                return null;
            TreeNode root = new TreeNode(po[pre_root]);

            //获得根节点pre_root在中序遍历中的位置
            int i = (int)dic[po[pre_root]];
            
            root.left = Recur(pre_root + 1, in_left, i - 1);
            root.right = Recur(pre_root + 1 + i - in_left, i + 1, in_right);
            return root;
        }
    }
}
