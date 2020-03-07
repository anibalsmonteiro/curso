using System;
using PredicateEx;
using System.Collections.Generic;
using System.Windows;

namespace PredicateEx
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

            Predicate<Product> predicate = new Predicate<Product>(p => p.Price >= 100.0);
            Predicate<Product> predicate2 =  p => p.Price >= 100.0;

            //list.RemoveAll(p => p.Price >= 100.0);
            //list.RemoveAll(ProductTest);
            //list.RemoveAll(predicate);
            list.RemoveAll(p => p.Price >= 100.00);

            foreach (Product p in list)
            {
                Console.WriteLine(p);
            }
        }

        public static bool ProductTest(Product p)
        {
            return p.Price >= 100.0;
        }

    }
}
