using System;
using System.Globalization;

namespace IComparableEx.Entities
{
    class Employee : IComparable
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }

        public Employee(string csvEmployee)
        {
            string[] emp = csvEmployee.Split(',');

            Name = emp[0];
            Salary = double.Parse(emp[1], CultureInfo.InvariantCulture);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Employee)) throw new ArgumentException("Comparing error: Argument is not an Employee!");

            Employee other = obj as Employee;

            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return "Name: "
                + Name
                + "Salary: "
                + Salary.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}