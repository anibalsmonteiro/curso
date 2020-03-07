using System;
using System.IO;
using System.Collections.Generic;
using IComparableEx.Entities;

namespace IComparableEx
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"c:\temp\test.txt";

            Comparison<Employee> comp = CompareEmployees;
            Comparison<Employee> Lamb = (p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper());
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    List<Employee> employees = new List<Employee>();
                    while (!sr.EndOfStream)
                    {
                        employees.Add(new Employee(sr.ReadLine()));
                    }


                    //employees.Sort(); //CompareTo
                    //employees.Sort(comp); //Delegate
                    //employees.Sort(CompareEmployees); // Instance of Delegate
                    //employees.Sort(Lamb); //Lambda Expressions
                    employees.Sort((p1, p2) => p1.Name.ToUpper().CompareTo(p2.Name.ToUpper())); //Lambda Expressions Inline

                    foreach (Employee employee in employees)
                    {
                        Console.WriteLine(employee);
                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred!");
                Console.WriteLine(e.Message);
            }
        }

        static int CompareEmployees(Employee e1, Employee e2)
        {
            return e1.Name.ToUpper().CompareTo(e2.Name.ToUpper());
        }

    }
}
