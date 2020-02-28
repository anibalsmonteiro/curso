using Source.Entities.Enums;
using System;
using System.Globalization;

namespace Source.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public HourContract()
        {
        }

        public HourContract(DateTime date, double valuePerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }

        public static void RunHourContract()
        {
            Console.Write("Enter department's name: ");
            Department department = new Department(Console.ReadLine());

            Console.WriteLine("\nEnter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Worker worker = new Worker(name, level, baseSalary, department);

            Console.Write("\nhow many contracts to this worker? ");
            int qtyContracts = int.Parse(Console.ReadLine());

            for (int i = 1; i <= qtyContracts; i++)
            {
                Console.WriteLine($"\nEnter #{i} contract data: ");

                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract hourContract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(hourContract);
            }

            Console.Write("\nEnter month and year to calculate income (MM/YYYY): ");
            string monthYearSearch = Console.ReadLine();
            int month = int.Parse(monthYearSearch.Substring(0, 2));
            int year = int.Parse(monthYearSearch.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine($"Income for {monthYearSearch}: " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
