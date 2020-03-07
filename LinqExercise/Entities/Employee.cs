using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExercise.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double salary)
        {
            Name = name;
            Salary = salary;
        }
    }
}
