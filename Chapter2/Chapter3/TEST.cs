using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter3
{
    class TEST
    {
        int index = 0;
        public bool IsNumber(string s)
        {
            if (s == null)
                return false;
            bool numeric = ScanInteger(s);
            while (index < s.Length && s[index] == ' ')
            {
                index++;
                while (index < s.Length && s[index] == ' ')
                {
                    ++index;
                    if (index != s.Length && (s[index] == '.' || s[index] == 'e' || s[index] == 'E'))
                        numeric = false;
                }
            }
            if (index < s.Length && s[index] == '.')
            {
                ++index;
                numeric = ScanUnsignedInteger(s) || numeric;
            }
            if (index < s.Length && (s[index] == 'e' || s[index] == 'E'))
            {
                ++index;
                numeric = numeric && ScanInteger(s);
            }
            return numeric && index == s.Length;
        }
        private bool ScanInteger(string s)
        {
            if (s[index] == '+' || s[index] == '-')
                index++;
            return ScanUnsignedInteger(s);
        }
        private bool ScanUnsignedInteger(string s)
        {
            int before = index;
            while (index != s.Length && s[index] >= '0' && s[index] <= '9')
                ++index;
            return index > before;
        }
    }
}
