using System;
using Source.Entities;
using Source.Entities.Enums;
using System.Globalization;
using System.Collections.Generic;

namespace Source
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static void RunShape()
        {
            List<Shape> shapes = new List<Shape>();

            Console.Write("Enter the number of shapes: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Shape #{i} data:");
                Console.Write("Rectangle or Cirle (R/C)? ");

                char ch = char.Parse(Console.ReadLine());
                Console.Write("Color (Black/Blue/Red): ");
                Color color = Enum.Parse<Color>(Console.ReadLine());

                if (ch == 'r')
                {
                    Console.Write("Width: ");
                    double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Height: ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    shapes.Add(new Rectangle(width, height, color));
                }
                else
                {
                    Console.Write("Radius: ");
                    double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    shapes.Add(new Circle(radius, color));
                }
            }

            Console.WriteLine("Shape areas: ");
            foreach (Shape shape in shapes)
            {
                Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));
            }
        }

        public static void RunEmployee()
        {
            Console.Write("Enter the number of employees: ");
            int qtyEmployees = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();

            for (int i = 1; i <= qtyEmployees; i++)
            {
                Console.WriteLine($"Employee #{i} data: ");
                Console.Write("Outsourced (y/n)? ");
                Boolean outsourced = (Console.ReadLine() == "y" ? true : false);

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Hours: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePH = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (outsourced)
                {
                    Console.Write("Additional charge: ");
                    double addCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    employees.Add(new OutsourceEmployee(name, hours, valuePH, addCharge));
                }
                else
                {
                    employees.Add(new Employee(name, hours, valuePH));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Payments: ");
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }

        }

        public static void OverrideMethods()
        {
            Account acc1 = new Account(1001, "Alex", 500.0);
            Account acc2 = new SavingsAccount(1002, "Maria", 500.0, 0.01);

            acc1.WithDraw(10.0);
            acc2.WithDraw(10.0);

            Console.WriteLine(acc1.Balance);
            Console.WriteLine(acc2.Balance);
        }

        public static void RunAccountUpCastingDowncasting()
        {
            Account acc = new Account(1001, "Alex", 0.0);
            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

            //UPCASTING

            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0);
            Account acc3 = new SavingsAccount(1004, "Anna", 0.0, 0.01);

            //DOWNCASTING

            BusinessAccount acc4 = (BusinessAccount)acc2;

            if (acc3 is BusinessAccount)
            {
                //BusinessAccount acc5 = (BusinessAccount)acc3;
                BusinessAccount acc5 = acc3 as BusinessAccount;
                acc5.Loan(200.0);
                Console.WriteLine("Loan!");
            }

            if (acc3 is SavingsAccount)
            {
                SavingsAccount acc5 = (SavingsAccount)acc3;
                acc5.UpdateBalance();
                Console.WriteLine("Update!");
            }
        }
    }
}
