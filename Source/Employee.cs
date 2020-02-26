using System.Globalization;

namespace Source
{
    class Employee
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public double Salary { get; private set; }

        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public void IncreaseSalary(double perc)
        {
            Salary += Salary * perc / 100.0;
        }

        public override string ToString()
        {
            return "Id: " + Id 
                + ", Name: " + Name 
                + ", Salary: " + Salary.ToString("F2",CultureInfo.InvariantCulture);
        }

    }
}
