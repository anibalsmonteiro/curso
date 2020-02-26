using System;
using Source.Entities;
using Source.Entities.Enums;
using Source.Test;

namespace Source
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order
            {
                Id = 0,
                Moment = DateTime.Now.Date,
                Status = OrderStatus.Processing
            };

            Console.WriteLine(order);

            string txt = OrderStatus.PendingPayment.ToString();
            Console.WriteLine(txt);

            OrderStatus os = Enum.Parse<OrderStatus>("Delivered");
            Console.WriteLine(os);

        }
    }
}
