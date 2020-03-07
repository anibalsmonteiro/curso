using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using LinqExercise.Entities;

namespace LinqExercise
{
    class Program
    {

        static void Main(string[] args)
        {
            //Console.Write("Enter full file path: ");
            //string path = Console.ReadLine();

            string path = @"C:\Temp\Employees.txt";

            List<Employee> employees = new List<Employee>();

            using (StreamReader sr = new StreamReader(path))
            {

                while (!sr.EndOfStream)
                {
                    string[] emp = sr.ReadLine().Split(',');
                    employees.Add(new Employee(emp[0], double.Parse(emp[1], CultureInfo.InvariantCulture)));
                    Console.WriteLine(emp[0] + ", " + emp[1]);
                }
            };


            var AverageSalary =
                employees.Average(p => p.Salary);

            Console.WriteLine("AVERAGE SALARY: " + AverageSalary.ToString("F2"));

            var AvgSalary =
                employees.Select(p => p.Salary).DefaultIfEmpty(0.0).Average();

            Console.WriteLine("AVERAGE SALARY 2: " + AvgSalary.ToString("F2"));

            // Syntax 1
            var DecrecentNames =
                (from e in employees
                 where e.Salary < AverageSalary
                 orderby e.Name descending
                 select e.Name
                 );
            
            // Syntax 2
            var DecrecentNames2 =
                employees
                .Where(e => e.Salary < AvgSalary)
                .OrderByDescending(p => p.Name)
                .Select(p => p.Name);

            Console.WriteLine("\nEMPLOYEES W/ BELOW AVG SALARY: ");

            foreach (var vs in DecrecentNames2)
            {
                Console.WriteLine(vs);
            }


        }
    }
}
