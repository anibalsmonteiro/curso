using System;
using System.Linq;

namespace LinqEx
{
    class Program
    {
        static void Main(string[] args)
        {
            //Specify the data source

            int[] numbers = { 2, 3, 4, 5 };

            //Define query expression
            var result = numbers
                .Where(p => p % 2 == 0)
                .Select(p => p * 10)
                .Select(p => p / 2);

            foreach (int n in result)
            {
                Console.WriteLine(n);
            }
        }
    }
}
