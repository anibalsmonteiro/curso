using System;
using Source.Entities;
using Source.Entities.Enums;
using Source.Test;
using System.Globalization;

namespace Source
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter department's name: ");
            Department department = new Department(Console.ReadLine());

            Console.WriteLine("\nEnter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level: ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Worker worker = new Worker(name, level, baseSalary, department);

            Console.Write("\nhow many contracts to this worker? ");
            int qtyContracts = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            for (int i = 1; i <= qtyContracts; i++)
            {
                Console.WriteLine($"\nEnter #{i} contract data: ");

                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                HourContract hourContract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(hourContract);
            }

            Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");
            string monthYearSearch = Console.ReadLine();
            int month = int.Parse(monthYearSearch.Substring(0, 2));
            int year = int.Parse(monthYearSearch.Substring(3, 4));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine($"Income for {monthYearSearch}: " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
