using System;

namespace TmpFunctionParameter
{
    class Program
    {
        delegate void MyHandler();
        static void Main(string[] args)
        {
            Add(Hello);
        }
        private static void Hello()
        {
            Console.WriteLine("Hello");
        }
        private static void Add(MyHandler myHandler)
        {
            myHandler();
            myHandler();
        }
    }
}
