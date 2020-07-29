using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter4
{
    class MinStack
    {
        /* 包含Min函数的栈
         * 利用辅助栈存储栈中的最小值
         */
        Stack<int> dataStack;
        Stack<int> minStack;
        public MinStack()
        {
            dataStack = new Stack<int>();
            minStack = new Stack<int>();
        }
        public void Push(int x)
        {
            dataStack.Push(x);
            if (minStack.Count == 0 || x < minStack.Peek())
                minStack.Push(x);
            else
                minStack.Push(minStack.Peek());
        }
        public void Pop()
        {
            dataStack.Pop();
            minStack.Pop();
        }
        public int Top()
        {
            return dataStack.Peek();
        }
        public int Min()
        {
            return minStack.Peek();
        }
    }
}
