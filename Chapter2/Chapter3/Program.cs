using System;
using System.Runtime.InteropServices.ComTypes;

namespace Chapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            TEST test = new TEST();
            bool t = test.IsNumber(" 2.8");
            Console.WriteLine(t);
        }
    }
}
