using System;

namespace OptionalParameter
{
    class MainApp
    {
        static void PrintProfile(string name, string phone = "")
        {
            Console.WriteLine("Name:{0}, Phone:{1}", name, phone);
        }

        static void Main(string[] args)
        {
            PrintProfile("태연");
            PrintProfile("윤아", "010-123-1234");
            PrintProfile(name: "유리");
            PrintProfile(name: "서현", phone:"010-789-7890");
        }
    }
}
