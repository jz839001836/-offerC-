using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class Question26
    {
        /* 面试题26：树的子结构
         * 输入两颗二叉树A和B，判断B是不是A的子结构
         */
        public bool IsSubStructure(TreeNode A, TreeNode B)
        {
            bool result = false;
            if (A != null && B != null)
            {
                if (Equal(A.val, B.val))
                    result = DoesTree1HaveTree2(A, B);
                if (!result)
                    result = IsSubStructure(A.left, B);
                if (!result)
                    result = IsSubStructure(A.right, B);
            }
            return result;
        }
        private bool DoesTree1HaveTree2(TreeNode A, TreeNode B)
        {
            if (B == null)
                return true;
            if (A == null)
                return false;
            if (!Equal(A.val, B.val))
                return false;
            return DoesTree1HaveTree2(A.left, B.left) && DoesTree1HaveTree2(A.right, B.right);
        }
        private bool Equal(int num1, int num2)
        {
            if (num1 - num2 > -0.0000001 && num1 - num2 < 0.0000001)
                return true;
            else
                return false;
        }
    }
}
