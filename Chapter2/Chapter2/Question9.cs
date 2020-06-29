using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Question9
    {
        /* 面试题9：用两个栈实现队列
         * 队列声明如下：
         * 实现它的两个函数appendTail和deletHead
         * 分别完成在队列尾部插入节点和在队列头部删除节点的功能
         */
        private Stack<int> stack1;
        private Stack<int> stack2;
        public Question9()
        {
            stack1 = new Stack<int>();
            stack2 = new Stack<int>();
        }

        public void AppendTail(int value)
        {
            stack1.Push(value);
        }
        public int DeleteHead()
        {
            if (stack1.Count == 0 && stack2.Count == 0)
                throw new Exception("队列为空！");
            if(stack1.Count != 0 && stack2.Count == 0)
            {
                while(stack1.Count != 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
            return stack2.Pop();
        }
    }
}
