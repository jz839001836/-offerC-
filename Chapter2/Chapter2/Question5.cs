using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter2
{
    class Question5
    {
        internal static void ValueOrReference(Type type)
        {
            String result = "The type " + type.Name;

            if (type.IsValueType)
                Console.WriteLine(result + " is a value type.");
            else
                Console.WriteLine(result + " is a reference type.");
        }
        internal static void ModifyString(ref String text)
        {
            text = "world";
        }

        internal static void TestString()
        {
            String text = "hello";

            ValueOrReference(text.GetType());
            ModifyString(ref text);

            Console.WriteLine(text);
        }

        /* 面试题5：替换空格
         * 实现一个函数，把字符串中的每个空格替换成“%20”
         * 例如，输入“We are happy.”，则输出“We%20are%20happy.”。
         * 因为% 2 0 是三个字符，故字符串会变长
         * 如果在原来的字符串上修改，有可能覆盖修改后面该字符串的内存
         * 如果是创建新的字符串并在新的字符串上进行替换，我们可以自己分配足够多的内存
         */
        public static string ReplaceSpace(string s)
        {
            if (s == null || s.Length == 0)
                return "0";
            int originalLength = s.Length;
            int spaceNumbers = 0;
            for(int i = 0; i < originalLength; i++)
            {
                if (s[i] == ' ')
                    ++spaceNumbers;
            }
            if (spaceNumbers == 0)
                return s;
            int newLength = originalLength + spaceNumbers * 2;
            char[] phraseOriginal = s.ToCharArray();
            char[] phraseNew = new char[newLength];

            int indexOfOriginal = originalLength - 1;
            int indexOfNew = newLength - 1;
            while(indexOfOriginal >= 0)
            { 
                if(phraseOriginal[indexOfOriginal] == ' ')
                {
                    phraseNew[indexOfNew--] = '0';
                    phraseNew[indexOfNew--] = '2';
                    phraseNew[indexOfNew--] = '%';
                }
                else
                {
                    phraseNew[indexOfNew--] = phraseOriginal[indexOfOriginal];
                }
                indexOfOriginal--;
            }
            return new string(phraseNew);
        }

        /* 测试1：字符串中包含空格
         * 空格在字符串中间，空格在字符串最后面，空格位于字符串最前面，字符串中包含多个空格
         */
        private static void Test1()
        {
            string s = "We are happy.";
            Console.WriteLine(s);
            string newstring = ReplaceSpace(s);
            Console.WriteLine(newstring);
        }
        //测试2：字符串中没有空格
        private static void Test2()
        {
            string s = "Wearehappy.";
            Console.WriteLine(s);
            string newstring = ReplaceSpace(s);
            Console.WriteLine(newstring);
        }
        //测试3：字符串为空
        private static void Test3()
        {
            string s = "";
            Console.WriteLine(s);
            string newstring = ReplaceSpace(s);
            Console.WriteLine(newstring);
        }
        private static void Main5(string[] args)
        {
            Test3();
        }
    }
}
