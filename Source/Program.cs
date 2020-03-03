using System;
using Source.Entities;
using Source.Entities.Enums;
using System.Globalization;

namespace Source
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractShape circle = new Circle(2.0, Color.Black);
            AbstractShape rectangle = new Rectangle(2.0, 3.0, Color.Orange);

            Console.WriteLine("circle.Area: " + circle.Area().ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("circle.Color: " + circle.Color);

            Console.WriteLine("rectangle.Area: " + rectangle.Area());
            Console.WriteLine("rectangle.Color: " + rectangle.Color);
        }
    }
}
