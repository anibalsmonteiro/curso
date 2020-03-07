using System;

namespace ExtensionMethodsEx
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime dt = new DateTime(2020, 03, 04, 0, 0, 0);
            Console.WriteLine(dt.ElapsedTime());

            string s1 = "Good moning dear students!";
            Console.WriteLine(s1.Cut(10)); 
        }
    }
}
