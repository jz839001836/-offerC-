using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class Question33
    {
        /* 面试题33：二叉搜索树的后序遍历序列
         * 输入一个整数数组，判断该数组是不是某二叉搜索树的后序遍历结果。
         */
        public static bool VerifyPostorder(int[] postorder)
        {
            return Verify(postorder, 0, postorder.Length - 1);
        }
        private static bool Verify(int[] postorder, int lo, int hi)
        {
            if (postorder == null || postorder.Length <= 0)
                return false;
            if (lo >= hi)
                return true;
            int root = postorder[hi];
            //在二叉搜索树中左子树节点的值小于根节点的值
            int i = lo;
            while (postorder[i] < root)
                i++;
            //在二叉搜索树中右节点的值大于根节点
            int j = i;
            for (; j < hi; j++)
            {
                if (postorder[j] < root)
                    return false;
            }
            return Verify(postorder, lo, i - 1) && Verify(postorder, i, hi - 1);
        }

        private static void Main33(string[] argc)
        {
            int[] array = { 1, 2, 5, 10, 6, 9, 4, 3 };
            bool verify = VerifyPostorder(array);
            Console.WriteLine(verify);
        }
    }
}
