using System.Globalization;

namespace TaxPayers.Entities
{
    abstract class Person
    {
        public string Name { get; set; }
        public double AnnualIncome { get; set; }

        public Person() { }

        public Person(string name, double annualIncome)
        {
            Name = name;
            AnnualIncome = annualIncome;
        }

        public abstract double CalculateTax();

        public override string ToString()
        {
            return Name + ": $" + CalculateTax().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
