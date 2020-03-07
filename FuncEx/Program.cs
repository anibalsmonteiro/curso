using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncEx
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            Func<Product, double> func = RoundNumber;

            List<double> result = list.Select(RoundNumber).ToList();
            //List<string> result = list.Select(func).ToList();
            //List<string> result = list.Select(p => p.Price..ToList());

            foreach (double s in result)
            {
                Console.WriteLine(s);
            }
        }

        static double RoundNumber (Product p)
        {
            return Math.Ceiling(p.Price);
        }
    }
}
