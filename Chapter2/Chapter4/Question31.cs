using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Chapter4
{
    class Question31
    {
        /* 面试题31：栈的压入、弹出序列
         */
        public static bool ValidateStackSeqequences(int[] pushed, int[] poped)
        {
            int pushIndex = 0;
            int popIndex = 0;
            Stack<int> stack = new Stack<int>();
            while (pushIndex < pushed.Length)
            {
                while (pushed[pushIndex] != poped[popIndex])
                {
                    stack.Push(pushed[pushIndex]);
                    pushIndex++;
                    if (pushIndex == pushed.Length)
                        break;
                }
                if (pushIndex < pushed.Length)
                    stack.Push(pushed[pushIndex++]);
                while (stack.Peek() == poped[popIndex])
                {
                    stack.Pop();
                    popIndex++;
                    if (popIndex == poped.Length || stack.Count == 0)
                        break;
                }
            }
            if (stack.Count == 0)
                return true;
            else
                return false;
        }
        public static bool ValidateStackSeqequences1(int[] pushed, int[] popped)
        {
            if (pushed == null && popped == null)
                return true;
            if (pushed == null || popped == null || pushed.Length != popped.Length)
                return false;
            Stack<int> stack = new Stack<int>();
            int index = 0;
            foreach(int i in pushed)
            {
                stack.Push(i);
                while(stack.Count != 0 && stack.Peek() == popped[index])
                {
                    stack.Pop();
                    index++;
                }
            }
            return stack.Count == 0;
        }
        private static void Main31(String[] argc)
        {

        }
    }
}
