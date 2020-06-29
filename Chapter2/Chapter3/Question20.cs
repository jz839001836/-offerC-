using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class Question20
    {
        /* 面试题20：表示数值的字符串
         * 数字的格式可以用A[.[B]][e|EC]或者.B[e|EC]表示
         * 其中A和C都是整数（可以有正负号，也可以没有）
         * 而B是一个无符号整数
         */

        int index = 0;
        public bool IsNumeric(string s)
        {
            if (s == null)
                return false;
            bool numeric = ScanInteger(s);
            if(index < s.Length && s[index] == '.')
            {
                ++index;
                /* 下面一行用||的原因：
                 * 1.小数可以没有整数部分，如.123等于0.123；
                 * 2.小数点后面可以没有数字，如233.等于233.0；
                 * 3.小数点前面和后面可以都有数字，如233.666；
                 * 
                 * 目的：将index往后推移
                 */
                numeric = ScanUnsignedInteger(s) || numeric;
            }
            //如果出现'e'或者'E'，则接下来是数字的指数部分
            if(index < s.Length && (s[index] == 'e' || s[index] == 'E'))
            {
                ++index;
                /* 下面一行代码用&&的原因：
                 * 1.当e或者E前面没有数字时，整个字符串不能表示数字，如.e1、e1;
                 * 2.当e或者E后面没有整数时，整个字符串不能表示数字，如12e、12e+5.4
                 */
                numeric = numeric && ScanInteger(s);
            }
            return numeric && index == s.Length;
        }
        //扫描可能以表示正负的‘+’或者‘-’为起始的0-9的数位
        //（类似于一个可能带正负符号的整数），用来匹配前面数值模式中的A和C部分
        private bool ScanInteger(string s)
        {
            if (s[index] == '+' || s[index] == '-')
                index++;
            return ScanUnsignedInteger(s);
        }
        //扫描字符串中0-9的数位（类似于一个无符号整数）
        //可以用匹配前面数值模式中的B部分
        private bool ScanUnsignedInteger(string s)
        {
            int before = index;
            while ((index != s.Length) && (s[index] >= '0') && (s[index] <= '9'))
                ++index;
            return index > before;
        }
    }
}
