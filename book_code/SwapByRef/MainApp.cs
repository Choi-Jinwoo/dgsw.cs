using System;

namespace SwapByRef
{
    class MainApp
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        static void Main(string[] args)
        {
            int x = 3;
            int y = 4;
            
            Console.WriteLine("x:{0}, y:{1}", x, y);

            Swap(ref x, ref y);

            Console.WriteLine("x:{0}, y:{1}", x, y);
        }
    }
}
